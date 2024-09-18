namespace EmpresaTrenes
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SistemaIngreso = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(52, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido al Sistema";
            // 
            // btn_SistemaIngreso
            // 
            this.btn_SistemaIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_SistemaIngreso.Location = new System.Drawing.Point(97, 126);
            this.btn_SistemaIngreso.Name = "btn_SistemaIngreso";
            this.btn_SistemaIngreso.Size = new System.Drawing.Size(176, 95);
            this.btn_SistemaIngreso.TabIndex = 1;
            this.btn_SistemaIngreso.Text = "Ingresar";
            this.btn_SistemaIngreso.UseVisualStyleBackColor = true;
            this.btn_SistemaIngreso.Click += new System.EventHandler(this.btn_SistemaIngreso_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 299);
            this.ControlBox = false;
            this.Controls.Add(this.btn_SistemaIngreso);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Entrada al sistema";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_SistemaIngreso;
    }
}

