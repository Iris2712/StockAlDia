﻿using System;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Net;
using System.Text;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Xml;
using Microsoft.Win32;
using System.Net.Http.Headers;

namespace StockAlDia
{
    public partial class PInicial : Form
    {
        private static Funciones funciones = new Funciones();
        private Boolean ComponenetesIniciales;
        private Boolean VariablesIniciales;
        private ConexionBD conexionBD = new ConexionBD();
        public Boolean r;


        public PInicial(string param)
        {
            InitializeComponent();

            funciones.EscribirLog("INICIO", "Inicio aplicación", false, 0);

            ComponenetesIniciales = funciones.Inicializar();
            if (ComponenetesIniciales == false)
            {
                //ocultar pantalla Form1
                this.Hide();
                ConexionBD VentanaConexionBD = new ConexionBD(funciones);   // Se invoca el formulario y se le pasa la instancia de la Funciones
                VentanaConexionBD.ShowDialog();
                this.Show();
                //System.Environment.Exit(0);
            }
            VariablesIniciales = funciones.InicializarVar();
            if (VariablesIniciales == true)
            {
                funciones.ConexionBD();
                // Llamada al método para conectar al WS
                //ConectarWebService("Exportacion");

                if (param == "")
                {//sin parametros
                    this.Show();
                }
                else
                {//si hay parametro
                    if (param == "Plugin")
                    {
                        funciones.fechIni = fechaInicio.Text;
                        funciones.fechFin = fechaFin.Text;
                        ConectarWebService("Exportacion");
                    }
                }



            }
        }


        private async void ConectarWebService(String tipoConx)
        {
            //email = "fashion@hioposmexico.com.mx";
            //password = "AD1D4$2023";
            //isoLanguage = "ES";

            UriBuilder uriBuilder = new UriBuilder("https://cloudlicense.icg.eu/services/cloud/getCustomerWithAuthToken");

            // Construir manualmente la cadena de consulta
            string queryString = $"email={Uri.EscapeDataString(funciones.UsuarioWS)}&password={Uri.EscapeDataString(funciones.PassWS)}&isoLanguage={Uri.EscapeDataString(funciones.IdiomaWS)}";
            uriBuilder.Query = queryString;
            funciones.urlWebService = uriBuilder.ToString();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(funciones.urlWebService);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        funciones.EscribirLog("info", $"Respuesta del servicio web: {responseBody}", true, 2);

                        //Leer XML de respuesta del WS
                        XDocument xmlDoc = XDocument.Parse(responseBody);
                        XElement adressElement = xmlDoc.Descendants("address").FirstOrDefault();
                        XElement authTokenElement = xmlDoc.Descendants("authToken").FirstOrDefault();

                        funciones.cloudClient = adressElement.Value;
                        funciones.Token = authTokenElement.Value;
                        funciones.EscribirLog("info", $"clodclient:{funciones.cloudClient}\ntoken:{funciones.Token}", true, 2);

                        if (tipoConx == "Exportacion")
                        {
                            //Exportación(funciones.Token, funciones.cloudClient, "2023-12-20", "2023-12-20");
                            Exportación(funciones.Token, funciones.cloudClient, funciones.fechIni, funciones.fechFin);
                        }
                        else if (tipoConx == "Import")
                        {
                            string pathExport = "C:\\Users\\USER\\source\\repos\\Iris2712\\StockAlDia\\bin\\Debug\\Exportaciones\\ExportacionP.csv";
                            ImportHiofficeConArchivo(funciones.cloudClient, "169a946b-2f25-407f-a957-d1001c2ea88b", funciones.Token,pathExport );
                            //MessageBox.Show($"Entró a la conexión WS:{funciones.Token} y\n {funciones.cloudClient}");
                        }
                    }
                    else
                    {
                        funciones.EscribirLog("info", $"Error en la solicitud. Código de estado: {response.StatusCode}", true, 1);
                    }
                }
                catch (Exception ex)
                {
                    funciones.EscribirLog("info", $"Error al realizar la solicitud: {ex.Message}", true, 1);
                }
            }
        }

        private async void Exportación(string token, string cloud, string startDate, string endDate)
        {


            try
            {
                funciones.urlPostExport = $"https://{cloud}/ErpCloud/exportation/launch";// URL de la API
                //string jsonBody = $"{{\"exportationId\":{funciones.IdExport},\"startDate\":\"{startDate}\",\"endDate\":\"{endDate}\"}}";// Cuerpo del JSON si ID Exportacion es entero
                //string jsonBody = $"{{\"exportationId\":\"981abdb1-9eee-11ee-b4fa-00505637c05d\",\"startDate\":\"{startDate}\",\"endDate\":\"{endDate}\"}}";// Cuerpo del JSON valor fijo
                string jsonBody = $"{{\"exportationId\":\"{funciones.IdExport}\",\"startDate\":\"{startDate}\",\"endDate\":\"{endDate}\"}}";// Cuerpo del JSON si ID Exportación es cadena

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("x-auth-token", $"{token}");// Configurar el encabezado con el token de autorización
                    StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");// Configurar el contenido del cuerpo como JSON

                    // Realizar la solicitud POST
                    HttpResponseMessage response = await client.PostAsync(funciones.urlPostExport, content);
                    if (response.IsSuccessStatusCode)// Verificar si la solicitud fue exitosa
                    {
                        // Procesar la respuesta
                        funciones.responseData = await response.Content.ReadAsStringAsync();
                        funciones.EscribirLog("info", $"Respuesta:{funciones.responseData}", true, 2);
                        LeerJson(funciones.responseData);
                    }
                    else
                    {
                        funciones.EscribirLog("info", $"Error: {response.StatusCode} - {response.Content.ReadAsStringAsync()}", true, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                funciones.EscribirLog("error", $"Error durante Exportación: {ex.Message}", true, 1);
            }
        }

        private void LeerJson(string responseData)
        {
            try
            {
                List<RootObject> rootObjects = JsonConvert.DeserializeObject<List<RootObject>>(responseData);

                // Acceder a la propiedad "data"
                if (rootObjects.Count > 0 && rootObjects[0].ExportedDocs.Count > 0)
                {
                    string dataJson = rootObjects[0].ExportedDocs[0].Data;

                    funciones.EscribirLog("info", $"Data: {dataJson}", true, 2);

                    // Decodificar la cadena de base64
                    byte[] data = Convert.FromBase64String(dataJson);
                    funciones.decoExport = Encoding.UTF8.GetString(data);// Convertir los bytes a una cadena
                    funciones.EscribirLog("info", $"Cadena decodificada: {funciones.decoExport}", false, 2);
                    ImportarStockExportador(funciones.decoExport);

                }
                else
                {
                    funciones.EscribirLog("info", "El JSON no tiene la estructura esperada.", true, 1);
                }
            }
            catch (Exception ex)
            {
                funciones.EscribirLog("info", $"Error en la lectura del JSON:{ex.Message}", true, 1);
            }
        }

        private void ImportarStockExportador(string ExportDeco)
        {
            try
            {
                XDocument xmlDoc = XDocument.Parse(ExportDeco);// Cargar el documento XML 

                // Iterar a través de cada elemento <registro> en el XML
                foreach (var registro in xmlDoc.Descendants("registro"))
                {
                    // Obtener los valores de los atributos
                    string fecha = registro.Element("Fecha").Value;
                    string referencia = registro.Element("Referencia").Value;
                    int codAlmacen = Convert.ToInt32(registro.Element("CodAlmacen").Value);
                    string almacen = registro.Element("Almacen").Value;
                    string tipoMovimiento = registro.Element("TipoMovimiento").Value;
                    int variacionStock = Convert.ToInt32(registro.Element("VariacionStock").Value);
                    int codArticulo = Convert.ToInt32(registro.Element("CodArticulo").Value);

                    //Importar Stock del exportador
                    SqlCommand InsertStockExportador = new SqlCommand("INSERT INTO STOCKEXPORTADO (Fecha, CodArticulo, Referencia, CodAlmacen, Almacen, TipoMovimiento, VariacionStock) " +
                        "VALUES (@Fecha, @CodArticulo, @Referencia, @CodAlmacen, @Almacen, @TipoMovimiento, @VariacionStock)", funciones.CnnxICGMx);
                    InsertStockExportador.Parameters.AddWithValue("@fecha", fecha);
                    InsertStockExportador.Parameters.AddWithValue("@Referencia", referencia);
                    InsertStockExportador.Parameters.AddWithValue("@CodAlmacen", codAlmacen);
                    InsertStockExportador.Parameters.AddWithValue("@Almacen", almacen);
                    InsertStockExportador.Parameters.AddWithValue("@TipoMovimiento", tipoMovimiento);
                    InsertStockExportador.Parameters.AddWithValue("@VariacionStock", variacionStock);
                    InsertStockExportador.Parameters.AddWithValue("@CodArticulo", codArticulo);


                    SqlDataReader ReaderInsert = InsertStockExportador.ExecuteReader();
                    while (ReaderInsert.Read()) { }
                    ReaderInsert.Close();
                    //funciones.EscribirLog("info", "Se importo de manera correcta los registros", true, 2);
                }
                funciones.EscribirLog("info", "Se importaron los registros de manera correcta los registros", true, 2);
                ReconstruirStock();
                ArmarImporHioffice();
            }
            catch (Exception ex)
            {
                funciones.EscribirLog("info", $"Error al importar el stock: {ex.Message}", true, 1);
            }
        }

        private void ReconstruirStock()
        {
            try
            {
                SqlCommand ReconstruirStock = new SqlCommand($"DECLARE RecalculaStock CURSOR FOR " +
                    $"SELECT DISTINCT CodArticulo, CodAlmacen, Fecha FROM BDAPPSAD..STOCKEXPORTADO " +
                    $"ORDER BY CodArticulo, Fecha;" +
                    $"DECLARE @CodArticulo INT, @CodAlmacen INT, @Fecha DATE;" +
                    $"DECLARE @TotalVariacionStock FLOAT;" +
                    $"OPEN RecalculaStock;" +
                    $"FETCH NEXT FROM RecalculaStock INTO @CodArticulo, @CodAlmacen, @Fecha;" +
                    $"WHILE @@FETCH_STATUS = 0" +
                    $"BEGIN" +
                    $"  SELECT @TotalVariacionStock = SUM(CAST(VariacionStock AS FLOAT))" +
                    $"  FROM BDAPPSAD..STOCKEXPORTADO " +
                    $"  WHERE CodArticulo = @CodArticulo AND CodAlmacen = @CodAlmacen AND Fecha <= @Fecha;" +
                    $"  DELETE FROM BDAPPSAD..STOCKIMPORT " +
                    $"  WHERE Fecha = @Fecha AND CodArticulo = @CodArticulo AND CodAlmacen = @CodAlmacen;" +
                    $"  INSERT INTO BDAPPSAD..STOCKIMPORT (Fecha, CodArticulo, CodAlmacen, StockFinal) " +
                    $"  VALUES (@Fecha, @CodArticulo, @CodAlmacen, @TotalVariacionStock);" +
                    $"  FETCH NEXT FROM RecalculaStock INTO @CodArticulo, @CodAlmacen, @Fecha;" +
                    $"END;" +
                    $"CLOSE RecalculaStock;" +
                    $"DEALLOCATE RecalculaStock;", funciones.CnnxICGMx);
                SqlDataReader Reconstr = ReconstruirStock.ExecuteReader();
                while (Reconstr.Read())
                {

                }
                Reconstr.Close();
                funciones.EscribirLog("info", $"Se realizó de manera correcta el Recalculo se Stock", true, 2);
            }
            catch (Exception ex)
            {
                funciones.EscribirLog("info", $"Error al regenerar el stock: {ex.Message}", true, 1);
            }
        }

        private void ArmarImporHioffice()
        {
            try
            {
                SqlCommand ArmarCSVaImportar = new SqlCommand($"SELECT * FROM {funciones.BDGeneral}..STOCKIMPORT " +
                    $"WHERE Fecha BETWEEN CAST('{funciones.fechIni}' AS DATE) AND CAST('{funciones.fechFin}' AS DATE);", funciones.CnnxICGMx);
                SqlDataReader ArmaArchivo = ArmarCSVaImportar.ExecuteReader();

                StringBuilder csvContent = new StringBuilder();// Crear un StringBuilder para construir el contenido del CSV

                // Escribir los nombres de las columnas en la primera fila del CSV
                for (int i = 0; i < ArmaArchivo.FieldCount; i++)
                {
                    string columnName = ArmaArchivo.GetName(i);
                    if (columnName != "Referencia")
                    {
                        csvContent.Append(columnName);
                        if (i < ArmaArchivo.FieldCount - 1)
                            csvContent.Append(";");
                    }
                }
                csvContent.AppendLine();

                while (ArmaArchivo.Read())
                {
                    for (int i = 0; i < ArmaArchivo.FieldCount; i++)
                    {
                        string columnName = ArmaArchivo.GetName(i);
                        if (columnName != "Referencia")
                        {
                            object value = ArmaArchivo.GetValue(i);

                            // Si el valor es de tipo fecha, formatearlo solo con la fecha
                            if (value is DateTime)
                            {
                                DateTime dateValue = (DateTime)value;
                                csvContent.Append(dateValue.ToString("yyyy-MM-dd"));
                            }
                            else
                            {
                                csvContent.Append(value.ToString());
                            }

                            if (i < ArmaArchivo.FieldCount - 1)
                                csvContent.Append(";");
                        }
                    }
                    csvContent.AppendLine();
                }
                ArmaArchivo.Close();

                //// Generar el nombre del archivo basado en la fecha actual
                ////-- string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                ////-- string csvFileName = $"Exportacion_{currentDate}.csv";

                //// Definir la ruta del archivo CSV por nombre con fecha
                //string csvPathArchivo = $@"{funciones.DirectorioInicial}\Exportaciones\ExportacionStock.csv";
                ////string csvPathArchivo = $@"{funciones.DirectorioInicial}\Exportaciones\{csvFileName}";
                //string csvFilePath = Path.Combine(csvPathArchivo, "ExportacionStock.csv");

                // Definir la ruta del archivo CSV
                string csvFilePath = $@"{funciones.DirectorioInicial}\Exportaciones\ImportStockHioffice.csv"; // Reemplaza esta ruta con la ubicación deseada
                if (File.Exists(csvFilePath))//Validar si existe el archivo
                {
                    File.Delete(csvFilePath);
                }

                // Guardar el contenido en un archivo CSV
                File.WriteAllText(csvFilePath, csvContent.ToString(), Encoding.UTF8);
                // Registrar en el log
                funciones.EscribirLog("info", "Archivo CSV creado y guardado en " + csvFilePath, true, 1);

                CloseConexionWebService(funciones.Token, funciones.cloudClient);//Logout
                ConectarWebService("Import");//Nueva conexión para Importación

            }
            catch (Exception ex)
            {
                funciones.EscribirLog("info", $"Error al armar el archivo a importar: {ex.Message}", true, 1);
            }

        }



        private async void CloseConexionWebService(string token, string cloud)
        {
            string Servidor = $"https://{cloud}";

            using (HttpClient httpClient = new HttpClient { BaseAddress = new Uri(Servidor) })
            {
                httpClient.DefaultRequestHeaders.Add("x-auth-token", token);
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync("ErpCloud/session/logout");
                    if (response.IsSuccessStatusCode)
                    {
                        funciones.EscribirLog("info", "Logout Exitoso", true, 2);
                    }
                    else
                    {
                        funciones.EscribirLog("info", "Logout failed. Status code:" + response.StatusCode, true, 4);
                    }
                }
                catch (Exception ex)
                {
                    funciones.EscribirLog("info", "Request error: " + ex.Message, true, 1);
                }
            }
        }

        public static async Task<string> ImportHiofficeConArchivo(string cloud, string id_importation, string token, string filePath)
        {
            string url = $"https://{cloud}/bridge-back/api/import/{id_importation}/launchWithFile";// URL completa para la petición POST

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-auth-token", token);// Establecer el token de autenticación en el encabezado

                var form = new MultipartFormDataContent();// Crear el contenido multipart/form-data

                // Agregar el archivo al contenido del formulario
                var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath));
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                form.Add(fileContent, "file", Path.GetFileName(filePath));

                try
                {
                    var response = await client.PostAsync(url, form);// Hacer la petición POST
                    response.EnsureSuccessStatusCode();// Verificar que la respuesta sea exitosa

                    // Leer la respuesta y convertirla en un string
                    var responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                    //-- funciones.EscribirLog("info", responseBody, true, 4);
                }
                catch (HttpRequestException e)
                {
                    return $"Error: {e.Message}";
                }
            }

        }

        private void EjecutaManual_Click(object sender, EventArgs e)
        {
            //Asignar variables
            funciones.fechIni = fechaInicio.Text;
            funciones.fechFin = fechaFin.Text;
            funciones.EscribirLog("info", $"Se ejecuto de manera manual: \nFecha Inicio:{funciones.fechIni} < - - > Fecha Fin:{funciones.fechFin}", false, 2); 

            ConectarWebService("Exportacion");
        }

        private void btnConfi_Click(object sender, EventArgs e)
        {
            ConexionBD conBD = new ConexionBD(funciones);
            conBD.ShowDialog();

        }
    }

    public class ExportedDoc
    {
        public string Name { get; set; }
        public string Data { get; set; }
        public int Type { get; set; }
    }

    public class RootObject
    {
        public List<object> GeneratedDocs { get; set; }
        public List<ExportedDoc> ExportedDocs { get; set; }
    }





}
