namespace Vista
{
    partial class GeneraLibroCompras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNomCliente = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonActualiza = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TipoDTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FchEmis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RUTEmisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RUTRecep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RznSoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MntNeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MntExe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MntTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Tipo_DTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mnt_Neto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mnt_Exe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MntIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impuestos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mnt_Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblNomCliente, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1173, 519);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblNomCliente
            // 
            this.lblNomCliente.AutoSize = true;
            this.lblNomCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNomCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomCliente.Location = new System.Drawing.Point(4, 3);
            this.lblNomCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblNomCliente.Name = "lblNomCliente";
            this.lblNomCliente.Size = new System.Drawing.Size(1165, 18);
            this.lblNomCliente.TabIndex = 4;
            this.lblNomCliente.Text = "LIBRO DE COMPRAS";
            this.lblNomCliente.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.47222F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.52778F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 324F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dateTimePicker1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonActualiza, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 27);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(635, 36);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Periodo Tributario:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(156, 7);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(95, 22);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // buttonActualiza
            // 
            this.buttonActualiza.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonActualiza.Location = new System.Drawing.Point(289, 6);
            this.buttonActualiza.Name = "buttonActualiza";
            this.buttonActualiza.Size = new System.Drawing.Size(75, 23);
            this.buttonActualiza.TabIndex = 6;
            this.buttonActualiza.Text = "Buscar";
            this.buttonActualiza.UseVisualStyleBackColor = true;
            this.buttonActualiza.Click += new System.EventHandler(this.buttonActualiza_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TipoDTE,
            this.Folio,
            this.FchEmis,
            this.RUTEmisor,
            this.RUTRecep,
            this.RznSoc,
            this.MntNeto,
            this.MntExe,
            this.IVA,
            this.MntTotal});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1165, 217);
            this.dataGridView1.TabIndex = 6;
            // 
            // TipoDTE
            // 
            this.TipoDTE.HeaderText = "TipoDTE";
            this.TipoDTE.Name = "TipoDTE";
            this.TipoDTE.ReadOnly = true;
            // 
            // Folio
            // 
            this.Folio.HeaderText = "Folio";
            this.Folio.Name = "Folio";
            this.Folio.ReadOnly = true;
            // 
            // FchEmis
            // 
            this.FchEmis.HeaderText = "FchEmis";
            this.FchEmis.Name = "FchEmis";
            this.FchEmis.ReadOnly = true;
            // 
            // RUTEmisor
            // 
            this.RUTEmisor.HeaderText = "RUTEmisor";
            this.RUTEmisor.Name = "RUTEmisor";
            this.RUTEmisor.ReadOnly = true;
            // 
            // RUTRecep
            // 
            this.RUTRecep.HeaderText = "RUTRecep";
            this.RUTRecep.Name = "RUTRecep";
            this.RUTRecep.ReadOnly = true;
            // 
            // RznSoc
            // 
            this.RznSoc.HeaderText = "RznSoc";
            this.RznSoc.Name = "RznSoc";
            this.RznSoc.ReadOnly = true;
            // 
            // MntNeto
            // 
            this.MntNeto.HeaderText = "MntNeto";
            this.MntNeto.Name = "MntNeto";
            this.MntNeto.ReadOnly = true;
            // 
            // MntExe
            // 
            this.MntExe.HeaderText = "MntExe";
            this.MntExe.Name = "MntExe";
            this.MntExe.ReadOnly = true;
            // 
            // IVA
            // 
            this.IVA.HeaderText = "IVA";
            this.IVA.Name = "IVA";
            this.IVA.ReadOnly = true;
            // 
            // MntTotal
            // 
            this.MntTotal.HeaderText = "MntTotal";
            this.MntTotal.Name = "MntTotal";
            this.MntTotal.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 293);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "RESUMEN LIBRO DE COMPRAS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tipo_DTE,
            this.CantidadDoc,
            this.Mnt_Neto,
            this.Mnt_Exe,
            this.MntIVA,
            this.Impuestos,
            this.Mnt_Total});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(4, 317);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(1165, 150);
            this.dataGridView2.TabIndex = 8;
            // 
            // Tipo_DTE
            // 
            this.Tipo_DTE.HeaderText = "TipoDTE";
            this.Tipo_DTE.Name = "Tipo_DTE";
            this.Tipo_DTE.ReadOnly = true;
            // 
            // CantidadDoc
            // 
            this.CantidadDoc.HeaderText = "CantDoc";
            this.CantidadDoc.Name = "CantidadDoc";
            this.CantidadDoc.ReadOnly = true;
            // 
            // Mnt_Neto
            // 
            this.Mnt_Neto.HeaderText = "MntNeto";
            this.Mnt_Neto.Name = "Mnt_Neto";
            this.Mnt_Neto.ReadOnly = true;
            // 
            // Mnt_Exe
            // 
            this.Mnt_Exe.HeaderText = "MntExe";
            this.Mnt_Exe.Name = "Mnt_Exe";
            this.Mnt_Exe.ReadOnly = true;
            // 
            // MntIVA
            // 
            dataGridViewCellStyle1.NullValue = null;
            this.MntIVA.DefaultCellStyle = dataGridViewCellStyle1;
            this.MntIVA.HeaderText = "IVA";
            this.MntIVA.Name = "MntIVA";
            this.MntIVA.ReadOnly = true;
            // 
            // Impuestos
            // 
            this.Impuestos.HeaderText = "Impuestos";
            this.Impuestos.Name = "Impuestos";
            this.Impuestos.ReadOnly = true;
            // 
            // Mnt_Total
            // 
            this.Mnt_Total.HeaderText = "MntTotal";
            this.Mnt_Total.Name = "Mnt_Total";
            this.Mnt_Total.ReadOnly = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.21247F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.78754F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 474);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(534, 32);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button2.Location = new System.Drawing.Point(92, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Ver Reporte";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.Location = new System.Drawing.Point(3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Crear JSON";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GeneraLibroCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1173, 516);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GeneraLibroCompras";
            this.Text = "GeneraLibroCompras";
            this.Load += new System.EventHandler(this.GeneraLibroCompras_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Label lblNomCliente;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonActualiza;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FchEmis;
        private System.Windows.Forms.DataGridViewTextBoxColumn RUTEmisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn RUTRecep;
        private System.Windows.Forms.DataGridViewTextBoxColumn RznSoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MntNeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn MntExe;
        private System.Windows.Forms.DataGridViewTextBoxColumn IVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn MntTotal;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_DTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mnt_Neto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mnt_Exe;
        private System.Windows.Forms.DataGridViewTextBoxColumn MntIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Impuestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mnt_Total;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}