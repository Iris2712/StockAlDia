using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockAlDia
{
    public partial class ConexionBD : Form
    {
        Funciones funciones;

        public ConexionBD()
        {
            InitializeComponent();
        }

        // Se corrige el nombre del constructor
        public ConexionBD(Funciones funciones2)
        {
            InitializeComponent();
            this.funciones = funciones2;
        }

        private void ConexionBD_Load(object sender, EventArgs e)
        {
            ServidorSQL.Text = funciones.ServidorSQL;
            UsuarioSQL.Text = funciones.UsuarioSQL;
            PassSQL.Text = funciones.PassSQL;
            BDSQL.Text = funciones.BDGeneral;

        }

        private void BtnConectar_Click(object sender, EventArgs e)
        {

            //Asignar Variables
            funciones.ServidorSQL = ServidorSQL.Text;
            funciones.UsuarioSQL = UsuarioSQL.Text;
            funciones.PassSQL = PassSQL.Text;
            funciones.BDGeneral = BDSQL.Text;

            //Validar que el campo no esta vacio

            if (funciones.CampVacio(ServidorSQL.Text, "Servidor") == false &&
                funciones.CampVacio(UsuarioSQL.Text, "Usuario") == false &&
                funciones.CampVacio(PassSQL.Text, "Contraseña") == false &&
                funciones.CampVacio(BDSQL.Text, "Base de datos General") == false)
            {
                //Llamar conexiónBD
                Boolean Conexion;
                Conexion = funciones.ConexionBD();
                if (Conexion == true)
                {
                    //Llamar siguiente ventana
                    this.Hide();
                    CnxHioffice cnxH = new CnxHioffice(funciones);
                    cnxH.ShowDialog();
                    this.Show();
                    
                    funciones.EscribirLog("info", "Conexión a la base de datos con exito",true,2);
                }
            }
        }


        //imagen de ocultar y mostrar contraseña
        private void ImgMostrar_Click(object sender, EventArgs e)
        {
            ImgOcultar.BringToFront();
            PassSQL.PasswordChar = '\0';}

        private void ImgOcultar_Click(object sender, EventArgs e)
        {
            ImgMostrar.BringToFront();
            PassSQL.PasswordChar = '*';}

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            funciones.EscribirLog("info", "Cancelacion de proceso", false, 0);
            //Application.Exit();
            System.Environment.Exit(0);
        }
        private void ConexionBD_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            funciones.EscribirLog("info", "La aplicacion se cerro desde la barra de tareas de windows.(pantalla de conexion a la BD)", false, 0);
            System.Environment.Exit(0);
            //}
        }

    }

}
