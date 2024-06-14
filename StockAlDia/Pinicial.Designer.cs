namespace StockAlDia
{
    partial class PInicial
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PInicial));
            this.fechaInicio = new System.Windows.Forms.DateTimePicker();
            this.fechaFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EjecutaManual = new System.Windows.Forms.Button();
            this.btnConfi = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDetener = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxLOG = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfi)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fechaInicio
            // 
            this.fechaInicio.CalendarFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaInicio.CustomFormat = "yyyy-MM-dd";
            this.fechaInicio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaInicio.Location = new System.Drawing.Point(174, 77);
            this.fechaInicio.Name = "fechaInicio";
            this.fechaInicio.Size = new System.Drawing.Size(106, 27);
            this.fechaInicio.TabIndex = 0;
            // 
            // fechaFin
            // 
            this.fechaFin.CalendarFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaFin.CustomFormat = "yyyy-MM-dd";
            this.fechaFin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaFin.Location = new System.Drawing.Point(492, 77);
            this.fechaFin.Name = "fechaFin";
            this.fechaFin.Size = new System.Drawing.Size(106, 27);
            this.fechaFin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha Inicial :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(380, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha Final :";
            // 
            // EjecutaManual
            // 
            this.EjecutaManual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EjecutaManual.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.EjecutaManual.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EjecutaManual.Location = new System.Drawing.Point(169, 390);
            this.EjecutaManual.Name = "EjecutaManual";
            this.EjecutaManual.Size = new System.Drawing.Size(83, 38);
            this.EjecutaManual.TabIndex = 4;
            this.EjecutaManual.Text = "Ejecutar";
            this.EjecutaManual.UseVisualStyleBackColor = false;
            this.EjecutaManual.Click += new System.EventHandler(this.EjecutaManual_Click);
            // 
            // btnConfi
            // 
            this.btnConfi.Image = global::StockAlDia.Properties.Resources.configuraciones;
            this.btnConfi.Location = new System.Drawing.Point(622, 13);
            this.btnConfi.Name = "btnConfi";
            this.btnConfi.Size = new System.Drawing.Size(44, 35);
            this.btnConfi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnConfi.TabIndex = 6;
            this.btnConfi.TabStop = false;
            this.btnConfi.Click += new System.EventHandler(this.btnConfi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(533, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Configuración";
            // 
            // btnDetener
            // 
            this.btnDetener.BackColor = System.Drawing.Color.LightCoral;
            this.btnDetener.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetener.Location = new System.Drawing.Point(425, 390);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(83, 38);
            this.btnDetener.TabIndex = 8;
            this.btnDetener.Text = "Detener";
            this.btnDetener.UseVisualStyleBackColor = false;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxLOG);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(56, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 239);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LOG";
            // 
            // textBoxLOG
            // 
            this.textBoxLOG.Location = new System.Drawing.Point(6, 21);
            this.textBoxLOG.Multiline = true;
            this.textBoxLOG.Name = "textBoxLOG";
            this.textBoxLOG.Size = new System.Drawing.Size(530, 198);
            this.textBoxLOG.TabIndex = 0;
            // 
            // PInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 451);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnConfi);
            this.Controls.Add(this.EjecutaManual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fechaFin);
            this.Controls.Add(this.fechaInicio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PInicial";
            this.Text = "Stock a una Fecha";
            ((System.ComponentModel.ISupportInitialize)(this.btnConfi)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker fechaInicio;
        private System.Windows.Forms.DateTimePicker fechaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button EjecutaManual;
        private System.Windows.Forms.PictureBox btnConfi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxLOG;
    }
}

