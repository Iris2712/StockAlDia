using System;
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
using System.Text.Json;

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
                        funciones.EscribirLog("info2", param, true, 4);

                        this.Hide();
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
                        funciones.EscribirLog("info", $"Respuesta del servicio web: {responseBody}", false, 2);
                        AddMessagetxtBox($"Respuesta del servicio web: {responseBody}");

                        //Leer XML de respuesta del WS
                        XDocument xmlDoc = XDocument.Parse(responseBody);
                        XElement adressElement = xmlDoc.Descendants("address").FirstOrDefault();
                        XElement authTokenElement = xmlDoc.Descendants("authToken").FirstOrDefault();

                        funciones.cloudClient = adressElement.Value;
                        funciones.Token = authTokenElement.Value;

                        funciones.EscribirLog("info", $"clodclient:{funciones.cloudClient}\ntoken:{funciones.Token}", false, 2);
                        AddMessagetxtBox($"clodclient:{funciones.cloudClient}\ntoken:{funciones.Token}");

                        if (tipoConx == "Exportacion")
                        {
                            //Exportación(funciones.Token, funciones.cloudClient, "2023-12-20", "2023-12-20");
                            Exportación(funciones.Token, funciones.cloudClient, funciones.fechIni, funciones.fechFin);
                        }
                        else if (tipoConx == "Import")
                        {
                            string pathExportH = $"{funciones.DirectorioInicial}\\Exportaciones\\ImportStockHioffice.csv";
                            ImportHiofficeConArchivo(funciones.cloudClient, "169a946b-2f25-407f-a957-d1001c2ea88b", funciones.Token,pathExportH );
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
                        funciones.EscribirLog("info", $"Respuesta:{funciones.responseData}", false, 2);
                        AddMessagetxtBox($"Respuesta: {funciones.responseData}");

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

                    funciones.EscribirLog("info", $"Data: {dataJson}", false, 2);
                    AddMessagetxtBox($"Data: {dataJson}");
                    
                    // Decodificar la cadena de base64
                    byte[] data = Convert.FromBase64String(dataJson);
                    funciones.decoExport = Encoding.UTF8.GetString(data);// Convertir los bytes a una cadena
                    funciones.EscribirLog("info", $"Cadena decodificada: {funciones.decoExport}", false, 2);
                    AddMessagetxtBox($"Cadena decodificada: {funciones.decoExport}");

                    //Llamar metodo para realizar importacion
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
                funciones.EscribirLog("info", "Se importaron los registros de manera correcta a la base local", false, 2);
                AddMessagetxtBox("Se importaron los registros de manera correcta a la base local");
                
                //Llamada de metodos para reconstruir el stock
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
                funciones.EscribirLog("info", $"Se realizó de manera correcta el Recalculo se Stock", false, 2);
                AddMessagetxtBox("Se realizó de manera correcta el Recalculo se Stock");
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
                funciones.EscribirLog("info", "Archivo CSV creado y guardado en " + csvFilePath, false, 2);
                AddMessagetxtBox("Archivo CSV creado y guardado en:\n " + csvFilePath);

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
                        funciones.EscribirLog("info", "Logout Exitoso", false, 2);
                        AddMessagetxtBox("Logout Exitoso");
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

        public static string ImportHiofficeConArchivo(string cloud, string id_importation, string token, string filePath)
        {
            string url = $"https://{cloud}/bridge-back/api/import/{id_importation}/launchWithFile"; // URL completa para la petición POST

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-auth-token", token); // Establecer el token de autenticación en el encabezado

                var form = new MultipartFormDataContent(); // Crear el contenido multipart/form-data

                // Agregar el archivo al contenido del formulario
                var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath));
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                form.Add(fileContent, "file", Path.GetFileName(filePath));

                try
                {
                    var response = client.PostAsync(url, form).Result; // Hacer la petición POST de manera síncrona
                    response.EnsureSuccessStatusCode(); // Verificar que la respuesta sea exitosa

                    // Leer la respuesta y convertirla en un string de manera síncrona
                    var responseBody = response.Content.ReadAsStringAsync().Result;

                    // Imprimir el cuerpo de la respuesta para depuración
                    Console.WriteLine("Response Body: " + responseBody);
                    funciones.EscribirLog("info", "Response Body: " + responseBody, false, 2);

                    // Deserializar el JSON y extraer el valor de importUUID
                    using (JsonDocument doc = JsonDocument.Parse(responseBody))
                    {
                        JsonElement root = doc.RootElement;
                        if (root.ValueKind == JsonValueKind.Array)
                        {
                            foreach (JsonElement element in root.EnumerateArray())
                            {
                                if (element.TryGetProperty("importUUID", out JsonElement importUUIDElement))
                                {
                                    string importUUID = importUUIDElement.GetString();

                                    // Imprimir el UUID en pantalla y en el log para depuración
                                    Console.WriteLine($"importUUID: {importUUID}");
                                    funciones.EscribirLog("info", "ImportUUID: " + importUUID, false, 4);

                                    // Llamar a EstadoImport 
                                    EstadoImport(importUUID);
                                    return importUUID;
                                }
                            }

                            throw new Exception("La clave 'importUUID' no se encontró en ningún objeto dentro del array JSON.");
                        }
                        else
                        {
                            throw new Exception("El elemento raíz del JSON no es un array.");
                        }
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    funciones.EscribirLog("error", $"Error: {e.Message}", true, 1);
                    return $"Error: {e.Message}";
                }
                catch (System.Text.Json.JsonException e)
                {
                    Console.WriteLine($"Error al procesar el JSON: {e.Message}");
                    funciones.EscribirLog("error", $"Error al procesar el JSON: {e.Message}", true, 1);
                    return $"Error al procesar el JSON: {e.Message}";
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    funciones.EscribirLog("error", $"Error: {e.Message}", true, 1);
                    return $"Error: {e.Message}";
                }
            }
        }

        public static void EstadoImport(string UUID)
        {
            PInicial pini = new PInicial("");
            string servidor = funciones.cloudClient;
            string token = funciones.Token;

            UriBuilder uriBuilder = new UriBuilder($"https://{servidor}/bridge-back/api/import/{UUID}/status");

            using (var client = new HttpClient())
            {
                // Establecer el token de autenticación en el encabezado
                client.DefaultRequestHeaders.Add("x-auth-token", token);

                try
                {
                    HttpResponseMessage response = client.GetAsync(uriBuilder.Uri).Result; // Realizar la petición GET de manera síncrona

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result; // Leer el contenido de la respuesta de manera síncrona
                        var data = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseBody); // Deserializar el JSON a un objeto dinámico

                        int statusId = data.statusId; // Obtener el statusId

                        // Imprimir el estado
                        if (statusId == 1)
                        {
                            funciones.EscribirLog("info", "El statusId de la importación es: En Ejecución", false, 2);
                            pini.AddMessagetxtBox("El statusId de la importación es: En Ejecución");
                        }
                        else if (statusId == 2)
                        {
                            funciones.EscribirLog("info", "El statusId de la importación es: Terminada con errores", false, 2);
                            ObtenerErrores(UUID); // Llamar a ObtenerErrores 
                        }
                        else if (statusId == 3)
                        {
                            funciones.EscribirLog("info", "El statusId de la importación es: Terminada correctamente", false, 2);
                            pini.AddMessagetxtBox("La importación TERMINO CORRECTAMENTE");
                        }
                        else
                        {
                            funciones.EscribirLog("info", "El statusId de la importación es: Estado desconocido", false, 2);
                        }

                    }
                    else
                    {
                        funciones.EscribirLog("info", $"Error en la petición: {response.StatusCode}", true, 1);
                        string errorResponse = response.Content.ReadAsStringAsync().Result;
                        funciones.EscribirLog("info", errorResponse, true, 1);
                    }
                }
                catch (Exception ex)
                {
                    funciones.EscribirLog("info", "Excepción durante la petición: " + ex.Message, true, 1);
                }
            }
        }

        public static void ObtenerErrores(string UUID)
        {
            string servidor = funciones.cloudClient;
            string token = funciones.Token;

            string eCode, eText, eTimestamp;

            UriBuilder uriBuilder = new UriBuilder($"https://{servidor}/bridge-back/api/import/{UUID}/errors");

            using (var client = new HttpClient())
            {
                // Establecer el token de autenticación en el encabezado
                client.DefaultRequestHeaders.Add("x-auth-token", token);

                try
                {
                    // Realizar la petición GET de manera síncrona
                    HttpResponseMessage response = client.GetAsync(uriBuilder.Uri).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta de manera síncrona
                        string responseBody = response.Content.ReadAsStringAsync().Result;

                        // Deserializar el JSON a un objeto dinámico
                        var data = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseBody);

                        // Obtener el objeto errores
                        var errors = data.errors;

                        // Imprimir los errores
                        foreach (var error in errors)
                        {
                            eCode = error.errorCode;
                            eText = error.errorText;
                            eTimestamp = error.errorTimestamp;
                            funciones.EscribirLog("info", $"Codigo Error: {eCode}\nError: {eText}\nError Timestamp: {eTimestamp}", false, 2);
                        }
                    }
                    else
                    {
                        funciones.EscribirLog("info", $"Error en la petición: {response.StatusCode}", true, 1);
                    }
                }
                catch (Exception ex)
                {
                    funciones.EscribirLog("info", $"Excepción capturada: {ex.Message}", true, 1);
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

        private void btnDetener_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }


        // Método para agregar mensajes al TextBox
        public void AddMessagetxtBox(string message)
        {
            const string separator = "*******************************";

            if (textBoxLOG.InvokeRequired)
            {
                textBoxLOG.Invoke(new Action<string>(AddMessagetxtBox), new object[] { message });
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(textBoxLOG.Text))
                {
                    textBoxLOG.AppendText(Environment.NewLine + separator + Environment.NewLine); // Agregar cadena de asteriscos
                }
                textBoxLOG.AppendText(message + Environment.NewLine);
            }
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
