using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockAlDia
{
    public partial class CnxHioffice : Form
    {
        Funciones funciones;
        Funciones.IniFile ArchivoConfig = new Funciones.IniFile(Funciones.ArchivoConfig);

        public CnxHioffice()
        {
            InitializeComponent();
        }
        public CnxHioffice(Funciones funciones)
        {
            InitializeComponent();
            this.funciones = funciones;
        }

        private void CnxHioffice_Load(object sender, EventArgs e)
        {

        }

        private async Task Main()
        {
            // URL del servicio web (reemplázala con tu propia URL)
            string url = "https://cloudlicense.icg.eu/services/cloud/getCustomerWithAuthToken?email=fashion@hioposmexico.com.mx&password=AD1D4$2023&isoLanguage=ES";

            // Crear una instancia de HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Realizar la solicitud GET
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Verificar si la solicitud fue exitosa (código de estado 200 OK)
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer y mostrar el contenido de la respuesta
                        string responseBody = await response.Content.ReadAsStringAsync();
                        funciones.EscribirLog("info", $"Respuesta servicio Web:{responseBody}", true, 2);
                        
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

        private void Conectar_Click(object sender, EventArgs e)
        {
            //Asignar variables
            funciones.UsuarioWS = UsuarioWS.Text;
            funciones.PassWS = PassWS.Text;
            funciones.IdiomaWS = IdiomaWS.Text;
            funciones.IdExport = idExport.Text;

            //Validar que los campos no esten vacios

            if(funciones.CampVacio(UsuarioWS.Text,"Usuario") == false &&
                funciones.CampVacio(PassWS.Text,"Contraseña") == false &&
                funciones.CampVacio(IdiomaWS.Text,"Idioma")== false)
            {
                if(MessageBox.Show("Al continuar se guardara el archivo de configuracion", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    //Guardar Archivo de configuración Config.
                    ArchivoConfig.Write("ServidorSQL", funciones.ServidorSQL, "DatosSQL");
                    ArchivoConfig.Write("UsuarioSQL", funciones.UsuarioSQL, "DatosSQL");
                    ArchivoConfig.Write("PassSQL", funciones.PassSQL, "DatosSQL");
                    ArchivoConfig.Write("BDGeneral", funciones.BDGeneral, "DatosSQL");
                    ArchivoConfig.Write("UsuarioWS", funciones.UsuarioWS, "DatosWS");
                    ArchivoConfig.Write("PassWS", funciones.PassWS, "DatosWS");
                    ArchivoConfig.Write("IdiomaWS", funciones.IdiomaWS, "DatosWS");
                    ArchivoConfig.Write("ID Exportador", funciones.IdExport, "DatosWS");

                    funciones.EscribirLog("info", $"Se guardo el Archivo de configuracion '{Funciones.ArchivoConfig}' de manera correcta", true, 2);

                    this.Close();
                    System.Environment.Exit(0);
                    this.Hide();
                    PInicial pini = new PInicial();
                    pini.ShowDialog();
                    this.Show();
                }
                else
                {
                    this.Show();
                }
            }
    }

    private void Regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //imagen de ocultar y mostrar contraseña
        private void ImgMostrar_Click(object sender, EventArgs e)
        {
            ImgOcultar.BringToFront();
            PassWS.PasswordChar = '\0';
        }

        private void ImgOcultar_Click_1(object sender, EventArgs e)
        {
            ImgMostrar.BringToFront();
            PassWS.PasswordChar = '*';
        }
    }
}
