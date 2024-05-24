namespace StockAlDia
{
    partial class CnxHioffice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CnxHioffice));
            this.label1 = new System.Windows.Forms.Label();
            this.Regresar = new System.Windows.Forms.Button();
            this.Conectar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.UsuarioWS = new System.Windows.Forms.TextBox();
            this.PassWS = new System.Windows.Forms.TextBox();
            this.IdiomaWS = new System.Windows.Forms.TextBox();
            this.ImgOcultar = new System.Windows.Forms.PictureBox();
            this.ImgMostrar = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.idExport = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImgOcultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgMostrar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(134, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Conexión a Hioffcie por WS";
            // 
            // Regresar
            // 
            this.Regresar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Regresar.Location = new System.Drawing.Point(30, 391);
            this.Regresar.Name = "Regresar";
            this.Regresar.Size = new System.Drawing.Size(84, 29);
            this.Regresar.TabIndex = 7;
            this.Regresar.Text = "Regresar";
            this.Regresar.UseVisualStyleBackColor = true;
            this.Regresar.Click += new System.EventHandler(this.Regresar_Click);
            // 
            // Conectar
            // 
            this.Conectar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Conectar.Location = new System.Drawing.Point(427, 391);
            this.Conectar.Name = "Conectar";
            this.Conectar.Size = new System.Drawing.Size(84, 29);
            this.Conectar.TabIndex = 8;
            this.Conectar.Text = "Conectar";
            this.Conectar.UseVisualStyleBackColor = true;
            this.Conectar.Click += new System.EventHandler(this.Conectar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(98, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuario :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(61, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contraseña :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(95, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Idioma : ";
            // 
            // UsuarioWS
            // 
            this.UsuarioWS.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsuarioWS.Location = new System.Drawing.Point(178, 100);
            this.UsuarioWS.Name = "UsuarioWS";
            this.UsuarioWS.Size = new System.Drawing.Size(301, 27);
            this.UsuarioWS.TabIndex = 4;
            // 
            // PassWS
            // 
            this.PassWS.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassWS.Location = new System.Drawing.Point(178, 144);
            this.PassWS.Name = "PassWS";
            this.PassWS.PasswordChar = '*';
            this.PassWS.Size = new System.Drawing.Size(263, 27);
            this.PassWS.TabIndex = 5;
            // 
            // IdiomaWS
            // 
            this.IdiomaWS.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdiomaWS.Location = new System.Drawing.Point(178, 190);
            this.IdiomaWS.Name = "IdiomaWS";
            this.IdiomaWS.Size = new System.Drawing.Size(96, 27);
            this.IdiomaWS.TabIndex = 6;
            // 
            // ImgOcultar
            // 
            this.ImgOcultar.Image = global::StockAlDia.Properties.Resources.ocultar;
            this.ImgOcultar.Location = new System.Drawing.Point(451, 144);
            this.ImgOcultar.Name = "ImgOcultar";
            this.ImgOcultar.Size = new System.Drawing.Size(28, 27);
            this.ImgOcultar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgOcultar.TabIndex = 9;
            this.ImgOcultar.TabStop = false;
            this.ImgOcultar.Click += new System.EventHandler(this.ImgOcultar_Click_1);
            // 
            // ImgMostrar
            // 
            this.ImgMostrar.Image = global::StockAlDia.Properties.Resources.muestra;
            this.ImgMostrar.Location = new System.Drawing.Point(451, 144);
            this.ImgMostrar.Name = "ImgMostrar";
            this.ImgMostrar.Size = new System.Drawing.Size(28, 27);
            this.ImgMostrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgMostrar.TabIndex = 10;
            this.ImgMostrar.TabStop = false;
            this.ImgMostrar.Click += new System.EventHandler(this.ImgMostrar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 21);
            this.label5.TabIndex = 11;
            this.label5.Text = "ID Exportador :";
            // 
            // idExport
            // 
            this.idExport.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idExport.Location = new System.Drawing.Point(178, 250);
            this.idExport.Name = "idExport";
            this.idExport.Size = new System.Drawing.Size(301, 27);
            this.idExport.TabIndex = 12;
            // 
            // CnxHioffice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 432);
            this.Controls.Add(this.idExport);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ImgMostrar);
            this.Controls.Add(this.ImgOcultar);
            this.Controls.Add(this.Conectar);
            this.Controls.Add(this.Regresar);
            this.Controls.Add(this.IdiomaWS);
            this.Controls.Add(this.PassWS);
            this.Controls.Add(this.UsuarioWS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CnxHioffice";
            this.Text = "CnxHioffice";
            this.Load += new System.EventHandler(this.CnxHioffice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImgOcultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgMostrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Regresar;
        private System.Windows.Forms.Button Conectar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox UsuarioWS;
        private System.Windows.Forms.TextBox PassWS;
        private System.Windows.Forms.TextBox IdiomaWS;
        private System.Windows.Forms.PictureBox ImgOcultar;
        private System.Windows.Forms.PictureBox ImgMostrar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox idExport;
    }
}