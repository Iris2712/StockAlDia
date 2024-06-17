using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace StockAlDia
{
    public class Funciones
    {

        //Variables Generales
        public  string DirectorioInicial = $"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}";
        public static string LogNombre = $"Log_StockAlDia_{DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '-')}.txt";
        public static string ArchivoConfig = $"Config.icg";
        //Xml ruta                                                                                                       
        public string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + @"\VirtualStore\Program Files (x86)\ICG\ICGManager\AutGastos.XML");
        

        public SqlConnection CnnxICGMx = null;

        //Variables de ConexionBD
        public string ServidorSQL { get; set; }
        public string UsuarioSQL { get; set; }
        public string PassSQL { get; set; }
        public string BDGeneral { get; set; }

        //Variables Conexion Hioffice
        public string UsuarioWS { get; set; }
        public string PassWS { get; set; }
        public string IdiomaWS { get; set; }
        public string IdExport { get; set; }

        //Exportación
        public string urlWebService { get; set; }
        public string Token { get; set; }
        public string cloudClient { get; set; }
        public string urlPostExport { get; set; }
        public string responseData { get; set; }
        public string decoExport { get; set; }

        //Filtro de fechas
        public string fechIni {  get; set; }
        public string fechFin {  get; set; }

        //Escribir LOG de la Aplicación.
        public void EscribirLog(string Evento, string Mensaje, Boolean CajaTexto, int TipoCaja)
        {
            try
            {
                String CarpetaDoc = DirectorioInicial + $@"\Exportaciones";

                if (Directory.Exists(CarpetaDoc) == false)
                {
                    DirectoryInfo doc = Directory.CreateDirectory(CarpetaDoc);
                }

                String CarpetaLog = DirectorioInicial + $@"\Log";

                if (Directory.Exists(CarpetaLog) == false)
                {
                    DirectoryInfo di = Directory.CreateDirectory(CarpetaLog);
                }
                string Fecha = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                using (StreamWriter outputFile = new StreamWriter(DirectorioInicial + $@"\log\{LogNombre}", true, Encoding.Unicode))
                {
                    outputFile.WriteLine($"[{Fecha}]\t[{Evento}]\t{Mensaje}");
                    outputFile.Close();
                }
                if (CajaTexto == true)
                {
                    if (TipoCaja == 1)
                    { MessageBox.Show(Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                    if (TipoCaja == 2)
                    { MessageBox.Show(Mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                    if (TipoCaja == 3)
                    { MessageBox.Show(Mensaje, "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question); }

                    if (TipoCaja == 4)
                    { MessageBox.Show(Mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

                }
            }
            catch (Exception ex)
            {
                string MensajeEX = string.Empty;
                Mensaje = ex.Message.ToString().Replace("'", "''");
                MessageBox.Show($"Surgió una excepción al intentar escribir en el Log. ({MensajeEX})");
            }

        }

        //inicializar aplicación
        public bool Inicializar()
        {
            try
            {
                //Validar Directorio LOG
                if (File.Exists(DirectorioInicial + $@"\{ArchivoConfig}"))
                {
                    return true;
                }
                else
                {
                    EscribirLog("info", "Falta Archivo de configuración.", true, 1);
                    return false;
                }
            }
            catch (Exception e)
            {
                EscribirLog("info", $"No es posible inicializar la aplicación, faltan componentes. ({e.Message})", true, 1);
                return false;
            }
        }

        //inicializar variables
        public bool InicializarVar()
        {
            try
            {
                //Validar Directorio LOG
                if (File.Exists(DirectorioInicial + $@"\{ArchivoConfig}"))

                {
                    IniFile ArchivoConfig2 = new IniFile(DirectorioInicial + $@"\{ArchivoConfig}");
                    
                    ServidorSQL = ArchivoConfig2.Read("ServidorSQL", "DatosSQL");//SQL
                    UsuarioSQL = ArchivoConfig2.Read("UsuarioSQL", "DatosSQL");
                    PassSQL = ArchivoConfig2.Read("PassSQL", "DatosSQL");
                    BDGeneral = ArchivoConfig2.Read("BDGeneral", "DatosSQL");
                    UsuarioWS = ArchivoConfig2.Read("UsuarioWS", "DatosWS");
                    PassWS = ArchivoConfig2.Read("PassWS", "DatosWS");
                    IdiomaWS = ArchivoConfig2.Read("IdiomaWS", "DatosWS");
                    IdExport = ArchivoConfig2.Read("ID Exportador", "DatosWS");

                    return true;
                }
                else
                {
                    EscribirLog("info", "No se encontro el archivo de configuración", true, 1);
                    return false;
                }
            }
            catch (Exception e)
            {
                EscribirLog("info", $"No es posible inicializar la aplicación.\n({e.Message})", true, 1);

                return false;
            }
        }

        //Conexion a la BD SQL 
        public bool ConexionBD()
        {
            try
            {
                //Validar Conexion a la BD
                CnnxICGMx = new SqlConnection($"Server={ServidorSQL}; Database={BDGeneral}; " +
                    $"User Id={UsuarioSQL}; Password={PassSQL}; MultipleActiveResultSets=true; Connection Timeout=30");

                /* Se abre la conexión */
                CnnxICGMx.Open();

                if (CnnxICGMx.State == ConnectionState.Open)
                {
                    EscribirLog("info", "Conexion a la BD con Exito.", false, 0);
                    //pini.AddMessagetxtBox("Conexion a la BD con Exito.");

                    // Verificar y crear tablas donde se recibe Stock 
                    if (!TableExists(CnnxICGMx, "STOCKEXPORTADO"))
                    {
                        CreateTableStockExp(CnnxICGMx);
                    }

                    if (!TableExists(CnnxICGMx, "STOCKIMPORT"))
                    {
                        CreateTableStockIpor(CnnxICGMx);
                    }
                    return true;
                }
                else
                {
                    EscribirLog("info", "No se pudo conectar a la BD.", true, 1);
                    return false;
                }
            }
            catch (Exception e)
            {

                EscribirLog("info", $"No es posible conectarse a la Base de Datos.\n Servidor: {ServidorSQL}\nUsuario:{UsuarioSQL}\nPass:{PassSQL}\nBD:{BDGeneral}\n ({e.Message})", true, 1);
                return false;
            }
        }

        private bool TableExists(SqlConnection connection, string tableName)//Valida que la tabla exista
        {
            string query = $"SELECT CASE WHEN OBJECT_ID('{tableName}', 'U') IS NOT NULL THEN 1 ELSE 0 END";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                return (int)command.ExecuteScalar() == 1;
            }
        }

        private void CreateTableStockExp(SqlConnection connection)//Crear tabla STOCKEXPORTADO
        {
            string query = @"
            CREATE TABLE STOCKEXPORTADO (
                [Fecha] [date] NULL,
	[CodArticulo] [int] NULL,
	[Referencia] [nvarchar](50) NULL,
	[CodAlmacen] [int] NULL,
	[Almacen] [nvarchar](50) NULL,
	[TipoMovimiento] [nvarchar](50) NULL,
	[VariacionStock] [nvarchar](50) NULL
            )";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
                EscribirLog("info", "Tabla 'STOCKEXPORTADO' creada con éxito.", false, 0);
            }
        }

        private void CreateTableStockIpor(SqlConnection connection)//Crear tabla STOCKIMPORT
        {
            string query = @"
            CREATE TABLE STOCKIMPORT (
    [Fecha] [date] NULL,
	[CodArticulo] [int] NULL,
	[Referencia] [nvarchar](50) NULL,
	[CodAlmacen] [int] NULL,
	[StockFinal] [nvarchar](50) NULL
            )";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
                EscribirLog("info", "Tabla 'STOCKIMPORT' creada con éxito.", false, 0);
            }
        }

        //Validacion de campos vacios
        public bool CampVacio(string NomCampo, string SubNomCamp)
        {
            if (!String.IsNullOrEmpty(NomCampo))
            { return false; }
            else
            {
                MessageBox.Show($"El campo {SubNomCamp} no puede estar vacio.", "Campo Vacio",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
        }

        
        //Leer y Escribir Archivos Ini
        public class IniFile   // revision 11
        {
            string Path;
            string EXE = Assembly.GetExecutingAssembly().GetName().Name;

            [DllImport("kernel32", CharSet = CharSet.Unicode)]
            static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

            [DllImport("kernel32", CharSet = CharSet.Unicode)]
            static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

            public IniFile(string IniPath = null)
            {
                Path = new FileInfo(IniPath ?? EXE + ".ini").FullName;
            }

            public string Read(string Key, string Section = null)
            {
                var RetVal = new StringBuilder(255);
                GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
                return RetVal.ToString();
            }

            public void Write(string Key, string Value, string Section = null)
            {
                WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
            }

            public void DeleteKey(string Key, string Section = null)
            {
                Write(Key, null, Section ?? EXE);
            }

            public void DeleteSection(string Section = null)
            {
                Write(null, null, Section ?? EXE);
            }

            public bool KeyExists(string Key, string Section = null)
            {
                return Read(Key, Section).Length > 0;
            }

        }
    } 

}



