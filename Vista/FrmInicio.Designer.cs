namespace Vista
{
    partial class FrmInicio
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
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.librosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarComprasCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.librosContablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generaLibroDeVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generaLibroCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tipodte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaemis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.neto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoenvio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pdf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xml = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerDesde = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonActualiza = new System.Windows.Forms.Button();
            this.labelNmbEmpresa = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Estado Envio";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 217F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(959, 323);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem,
            this.librosToolStripMenuItem,
            this.librosContablesToolStripMenuItem,
            this.proveedoresToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(1, 1);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(957, 23);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(55, 19);
            this.salirToolStripMenuItem.Text = "Archivo";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // librosToolStripMenuItem
            // 
            this.librosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compraToolStripMenuItem,
            this.cargarComprasCSVToolStripMenuItem});
            this.librosToolStripMenuItem.Name = "librosToolStripMenuItem";
            this.librosToolStripMenuItem.Size = new System.Drawing.Size(94, 19);
            this.librosToolStripMenuItem.Text = "Dctos Manuales";
            // 
            // compraToolStripMenuItem
            // 
            this.compraToolStripMenuItem.Name = "compraToolStripMenuItem";
            this.compraToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.compraToolStripMenuItem.Text = "Cargar Ventas CSV";
            this.compraToolStripMenuItem.Click += new System.EventHandler(this.compraToolStripMenuItem_Click);
            // 
            // cargarComprasCSVToolStripMenuItem
            // 
            this.cargarComprasCSVToolStripMenuItem.Name = "cargarComprasCSVToolStripMenuItem";
            this.cargarComprasCSVToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.cargarComprasCSVToolStripMenuItem.Text = "Cargar Compras CSV";
            this.cargarComprasCSVToolStripMenuItem.Click += new System.EventHandler(this.cargarComprasCSVToolStripMenuItem_Click);
            // 
            // librosContablesToolStripMenuItem
            // 
            this.librosContablesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generaLibroDeVentaToolStripMenuItem,
            this.generaLibroCompraToolStripMenuItem});
            this.librosContablesToolStripMenuItem.Name = "librosContablesToolStripMenuItem";
            this.librosContablesToolStripMenuItem.Size = new System.Drawing.Size(98, 19);
            this.librosContablesToolStripMenuItem.Text = "Libros Contables";
            // 
            // generaLibroDeVentaToolStripMenuItem
            // 
            this.generaLibroDeVentaToolStripMenuItem.Name = "generaLibroDeVentaToolStripMenuItem";
            this.generaLibroDeVentaToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.generaLibroDeVentaToolStripMenuItem.Text = "Genera Libro de Venta";
            this.generaLibroDeVentaToolStripMenuItem.Click += new System.EventHandler(this.generaLibroDeVentaToolStripMenuItem_Click);
            // 
            // generaLibroCompraToolStripMenuItem
            // 
            this.generaLibroCompraToolStripMenuItem.Name = "generaLibroCompraToolStripMenuItem";
            this.generaLibroCompraToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.generaLibroCompraToolStripMenuItem.Text = "Genera Libro Compra";
            this.generaLibroCompraToolStripMenuItem.Click += new System.EventHandler(this.generaLibroCompraToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(80, 19);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipodte,
            this.folio,
            this.fechaemis,
            this.sucursal,
            this.neto,
            this.total,
            this.estadoenvio,
            this.TrackId,
            this.pdf,
            this.xml});
            this.dataGridView1.Location = new System.Drawing.Point(4, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(951, 211);
            this.dataGridView1.TabIndex = 2;
            // 
            // tipodte
            // 
            this.tipodte.HeaderText = "Tipo Dte";
            this.tipodte.Name = "tipodte";
            this.tipodte.ReadOnly = true;
            this.tipodte.Width = 73;
            // 
            // folio
            // 
            this.folio.HeaderText = "Folio";
            this.folio.Name = "folio";
            this.folio.ReadOnly = true;
            this.folio.Width = 54;
            // 
            // fechaemis
            // 
            this.fechaemis.HeaderText = "Fecha";
            this.fechaemis.Name = "fechaemis";
            this.fechaemis.ReadOnly = true;
            this.fechaemis.Width = 62;
            // 
            // sucursal
            // 
            this.sucursal.HeaderText = "Sucursal";
            this.sucursal.Name = "sucursal";
            this.sucursal.ReadOnly = true;
            this.sucursal.Width = 73;
            // 
            // neto
            // 
            this.neto.HeaderText = "Neto";
            this.neto.Name = "neto";
            this.neto.ReadOnly = true;
            this.neto.Visible = false;
            this.neto.Width = 55;
            // 
            // total
            // 
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 56;
            // 
            // estadoenvio
            // 
            this.estadoenvio.HeaderText = "Estado Envio";
            this.estadoenvio.Name = "estadoenvio";
            this.estadoenvio.ReadOnly = true;
            this.estadoenvio.Width = 95;
            // 
            // TrackId
            // 
            this.TrackId.HeaderText = "Track Id";
            this.TrackId.Name = "TrackId";
            this.TrackId.ReadOnly = true;
            this.TrackId.Width = 72;
            // 
            // pdf
            // 
            this.pdf.HeaderText = "Pdf";
            this.pdf.Name = "pdf";
            this.pdf.ReadOnly = true;
            this.pdf.Width = 48;
            // 
            // xml
            // 
            this.xml.HeaderText = "Xml";
            this.xml.Name = "xml";
            this.xml.ReadOnly = true;
            this.xml.Width = 49;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.dateTimePickerDesde, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dateTimePickerHasta, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonActualiza, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelNmbEmpresa, 5, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 28);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(836, 39);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta:";
            // 
            // dateTimePickerDesde
            // 
            this.dateTimePickerDesde.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimePickerDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDesde.Location = new System.Drawing.Point(52, 9);
            this.dateTimePickerDesde.Name = "dateTimePickerDesde";
            this.dateTimePickerDesde.Size = new System.Drawing.Size(82, 20);
            this.dateTimePickerDesde.TabIndex = 0;
            // 
            // dateTimePickerHasta
            // 
            this.dateTimePickerHasta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimePickerHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerHasta.Location = new System.Drawing.Point(186, 9);
            this.dateTimePickerHasta.Name = "dateTimePickerHasta";
            this.dateTimePickerHasta.Size = new System.Drawing.Size(80, 20);
            this.dateTimePickerHasta.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Desde:";
            // 
            // buttonActualiza
            // 
            this.buttonActualiza.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonActualiza.Location = new System.Drawing.Point(273, 8);
            this.buttonActualiza.Name = "buttonActualiza";
            this.buttonActualiza.Size = new System.Drawing.Size(75, 23);
            this.buttonActualiza.TabIndex = 4;
            this.buttonActualiza.Text = "Actualiza";
            this.buttonActualiza.UseVisualStyleBackColor = true;
            this.buttonActualiza.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelNmbEmpresa
            // 
            this.labelNmbEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelNmbEmpresa.AutoSize = true;
            this.labelNmbEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNmbEmpresa.Location = new System.Drawing.Point(355, 10);
            this.labelNmbEmpresa.Name = "labelNmbEmpresa";
            this.labelNmbEmpresa.Size = new System.Drawing.Size(110, 18);
            this.labelNmbEmpresa.TabIndex = 5;
            this.labelNmbEmpresa.Text = "NmbEmpresa";
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(959, 335);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmInicio";
            this.Text = "Adm To SII";
            this.Load += new System.EventHandler(this.FrmInicio_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerDesde;
        private System.Windows.Forms.DateTimePicker dateTimePickerHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonActualiza;
        private System.Windows.Forms.ToolStripMenuItem librosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarComprasCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem librosContablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generaLibroDeVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generaLibroCompraToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipodte;
        private System.Windows.Forms.DataGridViewTextBoxColumn folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaemis;
        private System.Windows.Forms.DataGridViewTextBoxColumn sucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn neto;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoenvio;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackId;
        private System.Windows.Forms.DataGridViewTextBoxColumn pdf;
        private System.Windows.Forms.DataGridViewTextBoxColumn xml;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.Label labelNmbEmpresa;
    }
}