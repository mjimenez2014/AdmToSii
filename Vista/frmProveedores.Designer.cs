namespace Vista
{
    partial class frmProveedores
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tipodte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaemis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RUTEmisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RUTRecep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RznSoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MtoNeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoExento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MtoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aceptar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rechazar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.enviar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblNomCliente = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerDesde = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonActualiza = new System.Windows.Forms.Button();
            this.buttonBuscaXml = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonClientPop = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Procesar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNomCliente, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(959, 330);
            this.tableLayoutPanel1.TabIndex = 1;
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
            this.RUTEmisor,
            this.RUTRecep,
            this.RznSoc,
            this.MtoNeto,
            this.MontoExento,
            this.IVA,
            this.MtoTotal,
            this.aceptar,
            this.rechazar,
            this.enviar});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(951, 211);
            this.dataGridView1.TabIndex = 2;
            // 
            // tipodte
            // 
            this.tipodte.HeaderText = "Tipo Dte";
            this.tipodte.Name = "tipodte";
            this.tipodte.Width = 73;
            // 
            // folio
            // 
            this.folio.HeaderText = "Folio";
            this.folio.Name = "folio";
            this.folio.Width = 54;
            // 
            // fechaemis
            // 
            this.fechaemis.HeaderText = "Fecha";
            this.fechaemis.Name = "fechaemis";
            this.fechaemis.Width = 62;
            // 
            // RUTEmisor
            // 
            this.RUTEmisor.HeaderText = "Rut Emisor";
            this.RUTEmisor.Name = "RUTEmisor";
            this.RUTEmisor.Width = 83;
            // 
            // RUTRecep
            // 
            this.RUTRecep.HeaderText = "Rut Receptor";
            this.RUTRecep.Name = "RUTRecep";
            this.RUTRecep.Width = 96;
            // 
            // RznSoc
            // 
            this.RznSoc.HeaderText = "Razón Social";
            this.RznSoc.Name = "RznSoc";
            this.RznSoc.Width = 95;
            // 
            // MtoNeto
            // 
            this.MtoNeto.HeaderText = "Neto";
            this.MtoNeto.Name = "MtoNeto";
            this.MtoNeto.Width = 55;
            // 
            // MontoExento
            // 
            this.MontoExento.HeaderText = "MtoExento";
            this.MontoExento.Name = "MontoExento";
            this.MontoExento.Width = 83;
            // 
            // IVA
            // 
            this.IVA.HeaderText = "IVA";
            this.IVA.Name = "IVA";
            this.IVA.Width = 49;
            // 
            // MtoTotal
            // 
            this.MtoTotal.HeaderText = "Total";
            this.MtoTotal.Name = "MtoTotal";
            this.MtoTotal.Width = 56;
            // 
            // aceptar
            // 
            this.aceptar.HeaderText = "Aceptar";
            this.aceptar.Name = "aceptar";
            this.aceptar.Width = 50;
            // 
            // rechazar
            // 
            this.rechazar.HeaderText = "Rechazar";
            this.rechazar.Name = "rechazar";
            this.rechazar.Width = 59;
            // 
            // enviar
            // 
            this.enviar.HeaderText = "Enviar";
            this.enviar.Name = "enviar";
            this.enviar.Width = 43;
            // 
            // lblNomCliente
            // 
            this.lblNomCliente.AutoSize = true;
            this.lblNomCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNomCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomCliente.Location = new System.Drawing.Point(4, 3);
            this.lblNomCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblNomCliente.Name = "lblNomCliente";
            this.lblNomCliente.Size = new System.Drawing.Size(951, 18);
            this.lblNomCliente.TabIndex = 5;
            this.lblNomCliente.Text = "DTE PROVEEDORES";
            this.lblNomCliente.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.dateTimePickerDesde, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dateTimePickerHasta, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonActualiza, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonBuscaXml, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonClientPop, 7, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 27);
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
            this.label2.Location = new System.Drawing.Point(138, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta:";
            // 
            // dateTimePickerDesde
            // 
            this.dateTimePickerDesde.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimePickerDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDesde.Location = new System.Drawing.Point(50, 9);
            this.dateTimePickerDesde.Name = "dateTimePickerDesde";
            this.dateTimePickerDesde.Size = new System.Drawing.Size(82, 20);
            this.dateTimePickerDesde.TabIndex = 0;
            // 
            // dateTimePickerHasta
            // 
            this.dateTimePickerHasta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimePickerHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerHasta.Location = new System.Drawing.Point(182, 9);
            this.dateTimePickerHasta.Name = "dateTimePickerHasta";
            this.dateTimePickerHasta.Size = new System.Drawing.Size(80, 20);
            this.dateTimePickerHasta.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Desde:";
            // 
            // buttonActualiza
            // 
            this.buttonActualiza.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonActualiza.Location = new System.Drawing.Point(268, 8);
            this.buttonActualiza.Name = "buttonActualiza";
            this.buttonActualiza.Size = new System.Drawing.Size(75, 23);
            this.buttonActualiza.TabIndex = 4;
            this.buttonActualiza.Text = "Actualiza";
            this.buttonActualiza.UseVisualStyleBackColor = true;
            this.buttonActualiza.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonBuscaXml
            // 
            this.buttonBuscaXml.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonBuscaXml.Location = new System.Drawing.Point(349, 8);
            this.buttonBuscaXml.Name = "buttonBuscaXml";
            this.buttonBuscaXml.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscaXml.TabIndex = 5;
            this.buttonBuscaXml.Text = "Busca Xml";
            this.buttonBuscaXml.UseVisualStyleBackColor = true;
            this.buttonBuscaXml.Click += new System.EventHandler(this.buttonBuscaXml_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.button3, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 291);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(480, 29);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(115, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Recibo Mercaderia";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(270, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Aprobación Compercial";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonClientPop
            // 
            this.buttonClientPop.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonClientPop.Location = new System.Drawing.Point(430, 8);
            this.buttonClientPop.Name = "buttonClientPop";
            this.buttonClientPop.Size = new System.Drawing.Size(75, 23);
            this.buttonClientPop.TabIndex = 6;
            this.buttonClientPop.Text = "Cliente Pop3";
            this.buttonClientPop.UseVisualStyleBackColor = true;
            this.buttonClientPop.Click += new System.EventHandler(this.buttonClientPop_Click);
            // 
            // frmProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(959, 327);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adm To SII";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmInicio_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerDesde;
        private System.Windows.Forms.DateTimePicker dateTimePickerHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonActualiza;
        public System.Windows.Forms.Label lblNomCliente;
        private System.Windows.Forms.Button buttonBuscaXml;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipodte;
        private System.Windows.Forms.DataGridViewTextBoxColumn folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaemis;
        private System.Windows.Forms.DataGridViewTextBoxColumn RUTEmisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn RUTRecep;
        private System.Windows.Forms.DataGridViewTextBoxColumn RznSoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MtoNeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoExento;
        private System.Windows.Forms.DataGridViewTextBoxColumn IVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn MtoTotal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aceptar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn rechazar;
        private System.Windows.Forms.DataGridViewButtonColumn enviar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonClientPop;
    }
}