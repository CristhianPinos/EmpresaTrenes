namespace EmpresaTrenes.Views.Trenes
{
    partial class frm_Trenes_Principal
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
            this.btn_Salir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Trenes = new System.Windows.Forms.DataGridView();
            this.btn_Reporte = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Trenes)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Salir
            // 
            this.btn_Salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_Salir.Location = new System.Drawing.Point(518, 363);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(196, 138);
            this.btn_Salir.TabIndex = 14;
            this.btn_Salir.Text = "Salir";
            this.btn_Salir.UseVisualStyleBackColor = true;
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.Location = new System.Drawing.Point(374, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 36);
            this.label1.TabIndex = 13;
            this.label1.Text = "Lista de Rutas";
            // 
            // dgv_Trenes
            // 
            this.dgv_Trenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Trenes.Location = new System.Drawing.Point(18, 63);
            this.dgv_Trenes.Name = "dgv_Trenes";
            this.dgv_Trenes.RowHeadersWidth = 51;
            this.dgv_Trenes.RowTemplate.Height = 24;
            this.dgv_Trenes.Size = new System.Drawing.Size(934, 294);
            this.dgv_Trenes.TabIndex = 12;
            // 
            // btn_Reporte
            // 
            this.btn_Reporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_Reporte.Location = new System.Drawing.Point(259, 363);
            this.btn_Reporte.Name = "btn_Reporte";
            this.btn_Reporte.Size = new System.Drawing.Size(196, 138);
            this.btn_Reporte.TabIndex = 11;
            this.btn_Reporte.Text = "Reporte";
            this.btn_Reporte.UseVisualStyleBackColor = true;
            this.btn_Reporte.Click += new System.EventHandler(this.btn_Reporte_Click);
            // 
            // frm_Trenes_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 508);
            this.Controls.Add(this.btn_Salir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_Trenes);
            this.Controls.Add(this.btn_Reporte);
            this.Name = "frm_Trenes_Principal";
            this.Text = "frm_Trenes_Principal";
            this.Load += new System.EventHandler(this.frm_Trenes_Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Trenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Trenes;
        private System.Windows.Forms.Button btn_Reporte;
    }
}