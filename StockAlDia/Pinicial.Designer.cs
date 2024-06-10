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
            ((System.ComponentModel.ISupportInitialize)(this.btnConfi)).BeginInit();
            this.SuspendLayout();
            // 
            // fechaInicio
            // 
            this.fechaInicio.CustomFormat = "yyyy-MM-dd";
            this.fechaInicio.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaInicio.Location = new System.Drawing.Point(136, 122);
            this.fechaInicio.Name = "fechaInicio";
            this.fechaInicio.Size = new System.Drawing.Size(119, 26);
            this.fechaInicio.TabIndex = 0;
            // 
            // fechaFin
            // 
            this.fechaFin.CustomFormat = "yyyy-MM-dd";
            this.fechaFin.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaFin.Location = new System.Drawing.Point(379, 122);
            this.fechaFin.Name = "fechaFin";
            this.fechaFin.Size = new System.Drawing.Size(120, 26);
            this.fechaFin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha Inicial :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(275, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha Final :";
            // 
            // EjecutaManual
            // 
            this.EjecutaManual.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EjecutaManual.Location = new System.Drawing.Point(534, 382);
            this.EjecutaManual.Name = "EjecutaManual";
            this.EjecutaManual.Size = new System.Drawing.Size(93, 32);
            this.EjecutaManual.TabIndex = 4;
            this.EjecutaManual.Text = "Ejecutar";
            this.EjecutaManual.UseVisualStyleBackColor = true;
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
            this.label3.Font = new System.Drawing.Font("Candara", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(556, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Configuración";
            // 
            // PInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 451);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnConfi);
            this.Controls.Add(this.EjecutaManual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fechaFin);
            this.Controls.Add(this.fechaInicio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PInicial";
            this.Text = "Stock a una Fecha";
            ((System.ComponentModel.ISupportInitialize)(this.btnConfi)).EndInit();
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
    }
}

