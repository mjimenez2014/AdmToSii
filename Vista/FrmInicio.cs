using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modelo;



namespace Vista
{
    public partial class FrmInicio : Form
    {
        ProcesoIat proc = new ProcesoIat();
        FuncionesComunes funcComunes = new FuncionesComunes();
        DataTable dataTable = new DataTable();
        ImportaLibroCompra impCompras = new ImportaLibroCompra();
        GeneraLibroCompras geneLibroCompras = new GeneraLibroCompras();
        GeneraLibroVenta generaVentas = new GeneraLibroVenta();
        ImportaLibroVenta impVentas = new ImportaLibroVenta();
        EmpresaModel empresaModel = new EmpresaModel();
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            funcComunes.creadirectorios();
            empresaModel = empresaModel.getEmpresa();
            labelNmbEmpresa.Text = empresaModel.RznSoc;
            proc.StartProcessIat();
            actualizaDG();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QueryEstUpService estado = new QueryEstUpService();
            string estadoEnvio = estado.getEstUp("77398570", "7", "0039899330", funcComunes.getToken());
            Console.WriteLine("Estado=====> " + estadoEnvio);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        public void actualizaDG()
        {
            dataGridView1.Rows.Clear();
          dataTable =  new EnvioModel().getEnviosXFecha(Convert.ToDateTime(dateTimePickerDesde.Value),Convert.ToDateTime(dateTimePickerHasta.Value));
          foreach (DataRow fila in dataTable.Rows)
          {
              Int32 n = this.dataGridView1.Rows.Add();
              dataGridView1.Rows[n].Cells[0].Value = fila["tipoDte"].ToString();
              dataGridView1.Rows[n].Cells[1].Value = fila["folio"].ToString();
              dataGridView1.Rows[n].Cells[2].Value = fila["fchEmis"].ToString();
              dataGridView1.Rows[n].Cells[3].Value = fila["CdgSIISucur"].ToString();
              dataGridView1.Rows[n].Cells[5].Value = fila["mntTotal"].ToString();
              dataGridView1.Rows[n].Cells[6].Value = fila["estado"].ToString();
              dataGridView1.Rows[n].Cells[7].Value = fila["trackId"].ToString();
          }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            actualizaDG();
        }


        private void cargarComprasCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            impCompras.ShowDialog();
        }

        private void generaLibroCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            geneLibroCompras.ShowDialog();
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            impVentas.ShowDialog();
        }

        private void generaLibroDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generaVentas.ShowDialog();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmProveedores().ShowDialog();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
