namespace EmpresaTrenes.Views
{
    partial class Dashboard
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.trenesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rutasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasajerosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trenesToolStripMenuItem,
            this.estacionesToolStripMenuItem,
            this.rutasToolStripMenuItem,
            this.pasajerosToolStripMenuItem,
            this.reporteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // trenesToolStripMenuItem
            // 
            this.trenesToolStripMenuItem.Name = "trenesToolStripMenuItem";
            this.trenesToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.trenesToolStripMenuItem.Text = "Trenes";
            this.trenesToolStripMenuItem.Click += new System.EventHandler(this.trenesToolStripMenuItem_Click);
            // 
            // estacionesToolStripMenuItem
            // 
            this.estacionesToolStripMenuItem.Name = "estacionesToolStripMenuItem";
            this.estacionesToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.estacionesToolStripMenuItem.Text = "Estaciones";
            this.estacionesToolStripMenuItem.Click += new System.EventHandler(this.estacionesToolStripMenuItem_Click);
            // 
            // rutasToolStripMenuItem
            // 
            this.rutasToolStripMenuItem.Name = "rutasToolStripMenuItem";
            this.rutasToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.rutasToolStripMenuItem.Text = "Rutas";
            this.rutasToolStripMenuItem.Click += new System.EventHandler(this.rutasToolStripMenuItem_Click);
            // 
            // pasajerosToolStripMenuItem
            // 
            this.pasajerosToolStripMenuItem.Name = "pasajerosToolStripMenuItem";
            this.pasajerosToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.pasajerosToolStripMenuItem.Text = "Pasajeros";
            this.pasajerosToolStripMenuItem.Click += new System.EventHandler(this.pasajerosToolStripMenuItem_Click);
            // 
            // reporteToolStripMenuItem
            // 
            this.reporteToolStripMenuItem.Name = "reporteToolStripMenuItem";
            this.reporteToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.reporteToolStripMenuItem.Text = "Reporte";
            this.reporteToolStripMenuItem.Click += new System.EventHandler(this.reporteToolStripMenuItem_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem trenesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rutasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasajerosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteToolStripMenuItem;
    }
}