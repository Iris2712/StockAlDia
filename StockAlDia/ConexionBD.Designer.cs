namespace StockAlDia
{
    partial class ConexionBD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConexionBD));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ServidorSQL = new System.Windows.Forms.TextBox();
            this.UsuarioSQL = new System.Windows.Forms.TextBox();
            this.PassSQL = new System.Windows.Forms.TextBox();
            this.BDSQL = new System.Windows.Forms.TextBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnConectar = new System.Windows.Forms.Button();
            this.ImgOcultar = new System.Windows.Forms.PictureBox();
            this.ImgMostrar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImgOcultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgMostrar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(109, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Conexión a la Base de Datos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(107, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Servidor :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(113, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Usuario :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(76, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Contraseña :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Base de Datos :";
            // 
            // ServidorSQL
            // 
            this.ServidorSQL.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServidorSQL.Location = new System.Drawing.Point(191, 94);
            this.ServidorSQL.Name = "ServidorSQL";
            this.ServidorSQL.Size = new System.Drawing.Size(248, 27);
            this.ServidorSQL.TabIndex = 1;
            // 
            // UsuarioSQL
            // 
            this.UsuarioSQL.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsuarioSQL.Location = new System.Drawing.Point(191, 129);
            this.UsuarioSQL.Name = "UsuarioSQL";
            this.UsuarioSQL.Size = new System.Drawing.Size(248, 27);
            this.UsuarioSQL.TabIndex = 2;
            // 
            // PassSQL
            // 
            this.PassSQL.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassSQL.Location = new System.Drawing.Point(191, 168);
            this.PassSQL.Name = "PassSQL";
            this.PassSQL.PasswordChar = '*';
            this.PassSQL.Size = new System.Drawing.Size(248, 27);
            this.PassSQL.TabIndex = 3;
            // 
            // BDSQL
            // 
            this.BDSQL.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BDSQL.Location = new System.Drawing.Point(191, 206);
            this.BDSQL.Name = "BDSQL";
            this.BDSQL.Size = new System.Drawing.Size(248, 27);
            this.BDSQL.TabIndex = 4;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(52, 291);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(102, 27);
            this.BtnCancelar.TabIndex = 6;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnConectar
            // 
            this.BtnConectar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConectar.Location = new System.Drawing.Point(380, 291);
            this.BtnConectar.Name = "BtnConectar";
            this.BtnConectar.Size = new System.Drawing.Size(102, 27);
            this.BtnConectar.TabIndex = 5;
            this.BtnConectar.Text = "Conectar";
            this.BtnConectar.UseVisualStyleBackColor = true;
            this.BtnConectar.Click += new System.EventHandler(this.BtnConectar_Click);
            // 
            // ImgOcultar
            // 
            this.ImgOcultar.Image = global::StockAlDia.Properties.Resources.ocultar;
            this.ImgOcultar.Location = new System.Drawing.Point(445, 170);
            this.ImgOcultar.Name = "ImgOcultar";
            this.ImgOcultar.Size = new System.Drawing.Size(26, 27);
            this.ImgOcultar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgOcultar.TabIndex = 7;
            this.ImgOcultar.TabStop = false;
            this.ImgOcultar.Click += new System.EventHandler(this.ImgOcultar_Click);
            // 
            // ImgMostrar
            // 
            this.ImgMostrar.Image = global::StockAlDia.Properties.Resources.muestra;
            this.ImgMostrar.Location = new System.Drawing.Point(445, 170);
            this.ImgMostrar.Name = "ImgMostrar";
            this.ImgMostrar.Size = new System.Drawing.Size(26, 27);
            this.ImgMostrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgMostrar.TabIndex = 8;
            this.ImgMostrar.TabStop = false;
            this.ImgMostrar.Click += new System.EventHandler(this.ImgMostrar_Click);
            // 
            // ConexionBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 334);
            this.Controls.Add(this.ImgMostrar);
            this.Controls.Add(this.ImgOcultar);
            this.Controls.Add(this.BtnConectar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BDSQL);
            this.Controls.Add(this.PassSQL);
            this.Controls.Add(this.UsuarioSQL);
            this.Controls.Add(this.ServidorSQL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConexionBD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conexión a la Base de Datos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConexionBD_FormClosing);
            this.Load += new System.EventHandler(this.ConexionBD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImgOcultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgMostrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ServidorSQL;
        private System.Windows.Forms.TextBox UsuarioSQL;
        private System.Windows.Forms.TextBox PassSQL;
        private System.Windows.Forms.TextBox BDSQL;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnConectar;
        private System.Windows.Forms.PictureBox ImgOcultar;
        private System.Windows.Forms.PictureBox ImgMostrar;
    }
}