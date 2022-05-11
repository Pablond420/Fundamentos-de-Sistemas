namespace Calculadora
{
    partial class Interfaz_Grafica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interfaz_Grafica));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LexyaccToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.paso1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paso2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ensamblarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataSourceProgram = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataTabSim = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataObjProg = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataArchInt = new System.Windows.Forms.TextBox();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataErrores = new System.Windows.Forms.TextBox();
            this.menu.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.cargadorToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1120, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.fileToolStripMenuItem.Text = "&Archivo";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.newToolStripMenuItem.Text = "&Nuevo";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.openToolStripMenuItem.Text = "&Abrir";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(153, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.saveToolStripMenuItem.Text = "&Guardar";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(153, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.exitToolStripMenuItem.Text = "Salir";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LexyaccToolStripMenuItem,
            this.toolStripSeparator3,
            this.paso1ToolStripMenuItem,
            this.paso2ToolStripMenuItem,
            this.ensamblarToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.editToolStripMenuItem.Text = "&Ensamblador";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // LexyaccToolStripMenuItem
            // 
            this.LexyaccToolStripMenuItem.Name = "LexyaccToolStripMenuItem";
            this.LexyaccToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.LexyaccToolStripMenuItem.Text = "Analizador Léxico Sintáctico";
            this.LexyaccToolStripMenuItem.Click += new System.EventHandler(this.LexyaccToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(219, 6);
            // 
            // paso1ToolStripMenuItem
            // 
            this.paso1ToolStripMenuItem.Name = "paso1ToolStripMenuItem";
            this.paso1ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.paso1ToolStripMenuItem.Text = "Paso 1";
            this.paso1ToolStripMenuItem.Click += new System.EventHandler(this.paso1ToolStripMenuItem_Click);
            // 
            // paso2ToolStripMenuItem
            // 
            this.paso2ToolStripMenuItem.Enabled = false;
            this.paso2ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.paso2ToolStripMenuItem.Name = "paso2ToolStripMenuItem";
            this.paso2ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.paso2ToolStripMenuItem.Text = "Paso 2";
            this.paso2ToolStripMenuItem.Click += new System.EventHandler(this.paso2ToolStripMenuItem_Click);
            // 
            // ensamblarToolStripMenuItem
            // 
            this.ensamblarToolStripMenuItem.Name = "ensamblarToolStripMenuItem";
            this.ensamblarToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.ensamblarToolStripMenuItem.Text = "Ensamblar";
            this.ensamblarToolStripMenuItem.Click += new System.EventHandler(this.ensamblarToolStripMenuItem_Click);
            // 
            // cargadorToolStripMenuItem
            // 
            this.cargadorToolStripMenuItem.Name = "cargadorToolStripMenuItem";
            this.cargadorToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.cargadorToolStripMenuItem.Text = "Cargador";
            this.cargadorToolStripMenuItem.Click += new System.EventHandler(this.cargadorToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.toolsToolStripMenuItem.Text = "Limpiar";
            this.toolsToolStripMenuItem.Click += new System.EventHandler(this.toolsToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "\"C:\\\"";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "\"Abrir Programa Fuente\"";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.Controls.Add(this.splitter2);
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.splitter1);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1120, 240);
            this.panel4.TabIndex = 23;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(737, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 240);
            this.splitter2.TabIndex = 25;
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(365, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 240);
            this.splitter1.TabIndex = 23;
            this.splitter1.TabStop = false;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(0, 264);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(1120, 3);
            this.splitter3.TabIndex = 26;
            this.splitter3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 240);
            this.panel1.TabIndex = 22;
            // 
            // dataSourceProgram
            // 
            this.dataSourceProgram.AcceptsReturn = true;
            this.dataSourceProgram.AcceptsTab = true;
            this.dataSourceProgram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSourceProgram.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataSourceProgram.Location = new System.Drawing.Point(3, 19);
            this.dataSourceProgram.Multiline = true;
            this.dataSourceProgram.Name = "dataSourceProgram";
            this.dataSourceProgram.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dataSourceProgram.Size = new System.Drawing.Size(359, 218);
            this.dataSourceProgram.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBox1.Controls.Add(this.dataSourceProgram);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Montserrat SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 240);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PROGRAMA FUENTE";
            // 
            // dataTabSim
            // 
            this.dataTabSim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTabSim.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataTabSim.Location = new System.Drawing.Point(3, 19);
            this.dataTabSim.Multiline = true;
            this.dataTabSim.Name = "dataTabSim";
            this.dataTabSim.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dataTabSim.Size = new System.Drawing.Size(363, 218);
            this.dataTabSim.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBox2.Controls.Add(this.dataTabSim);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Font = new System.Drawing.Font("Montserrat SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(368, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(369, 240);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TABSIM";
            // 
            // dataObjProg
            // 
            this.dataObjProg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataObjProg.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataObjProg.Location = new System.Drawing.Point(3, 19);
            this.dataObjProg.Multiline = true;
            this.dataObjProg.Name = "dataObjProg";
            this.dataObjProg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dataObjProg.Size = new System.Drawing.Size(374, 218);
            this.dataObjProg.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBox3.Controls.Add(this.dataObjProg);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Montserrat SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(740, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(380, 240);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PROGRAMA OBJETO";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 267);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1120, 232);
            this.panel2.TabIndex = 27;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBox4.Controls.Add(this.dataArchInt);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Montserrat SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1120, 232);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ARCHIVO INTERMEDIO";
            // 
            // dataArchInt
            // 
            this.dataArchInt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataArchInt.Font = new System.Drawing.Font("Montserrat Medium", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataArchInt.Location = new System.Drawing.Point(3, 19);
            this.dataArchInt.Multiline = true;
            this.dataArchInt.Name = "dataArchInt";
            this.dataArchInt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dataArchInt.Size = new System.Drawing.Size(1114, 210);
            this.dataArchInt.TabIndex = 3;
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter4.Location = new System.Drawing.Point(0, 499);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(1120, 3);
            this.splitter4.TabIndex = 28;
            this.splitter4.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 502);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1120, 86);
            this.panel3.TabIndex = 29;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBox5.Controls.Add(this.dataErrores);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("Montserrat SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1120, 86);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ERRORES";
            // 
            // dataErrores
            // 
            this.dataErrores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataErrores.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataErrores.Location = new System.Drawing.Point(3, 19);
            this.dataErrores.Multiline = true;
            this.dataErrores.Name = "dataErrores";
            this.dataErrores.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dataErrores.Size = new System.Drawing.Size(1114, 64);
            this.dataErrores.TabIndex = 1;
            // 
            // Interfaz_Grafica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1120, 588);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitter4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "Interfaz_Grafica";
            this.Text = "Arquitectura SIC XE";
            this.Load += new System.EventHandler(this.Interfaz_Grafica_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LexyaccToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paso1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem paso2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem ensamblarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargadorToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox dataObjProg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox dataTabSim;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox dataSourceProgram;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox dataArchInt;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox dataErrores;
    }
}