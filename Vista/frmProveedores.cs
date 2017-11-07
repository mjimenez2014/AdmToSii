using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modelo;
using System.Xml;
using Limilabs.Client.POP3;
using Limilabs.Mail;
using Limilabs.Mail.MIME;



namespace Vista
{
    public partial class frmProveedores : Form
    {
        ProcesoIat proc = new ProcesoIat();
        FuncionesComunes funcComunes = new FuncionesComunes();
        DataTable dataTable = new DataTable();
        LibroCompraModel libroCompraM = new LibroCompraModel();
        ImportaLibroCompra impCompras = new ImportaLibroCompra();
        GeneraLibroCompras geneLibroCompras = new GeneraLibroCompras();
        GeneraLibroVenta generaVentas = new GeneraLibroVenta();
        ImportaLibroVenta impVentas = new ImportaLibroVenta();
        fileAdmin fileAdm = new fileAdmin();
        DescargasModel descargaModel = new DescargasModel();

        public frmProveedores()
        {
            InitializeComponent();
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            actualizaDG();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new RespuestaEnvioDte().creaXml();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        public void actualizaDG()
        {
            dataGridView1.Rows.Clear();
            dataTable = libroCompraM.listaLibroXFecha(new DateTime(), "DISCHARGED",dateTimePickerDesde.Value.Date.ToString("yyyy-MM-dd"),dateTimePickerHasta.Value.Date.ToString("yyyy-MM-dd"));
            foreach (DataRow fila in dataTable.Rows)
            {
                Int32 n = this.dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = fila["TipoDTE"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = fila["Folio"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = fila["FchEmis"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = fila["RUTEmisor"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = fila["RUTRecep"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = fila["RznSoc"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = fila["MntNeto"].ToString();
                dataGridView1.Rows[n].Cells[7].Value = fila["MntExe"].ToString();
                dataGridView1.Rows[n].Cells[8].Value = fila["IVA"].ToString();
                dataGridView1.Rows[n].Cells[9].Value = fila["MntTotal"].ToString();
                //dataGridView1.Rows[n].Cells[10].Value = "False";
                //dataGridView1.Rows[n].Cells[11].Value = "False";
                dataGridView1.Rows[n].Cells[12].Value = "Enviar";
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
  


        private void buttonBuscaXml_Click(object sender, EventArgs e)
        {
            fileAdm.buscaXmlProveedor();
            actualizaDG();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            new ReciboMercaderia().creaXml();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new AprobacionComercial().creaXml();
        }

        private void buttonClientPop_Click(object sender, EventArgs e)
        {
            using (Pop3 pop3 = new Pop3())
            {
                pop3.Connect("mail.invoicedigital.cl");       // or ConnectSSL for SSL
                pop3.UseBestLogin("intercambiosctgermany@invoicedigital.cl", "sctgermany2016");
                
                foreach (string uid in pop3.GetAll())
                { 
                    // verifico si existe el uid en la base
                    Console.WriteLine("Message unique-id: {0};", uid);
                    string nomArchivo = string.Empty;
                    if (descargaModel.exist(uid) == "False")
                    {

                        IMail email = new MailBuilder()
                            .CreateFromEml(pop3.GetMessageByUID(uid));

                        Console.WriteLine("===================================================");
                        Console.WriteLine(email.Subject);
                        Console.WriteLine(email.Text);

                        foreach (MimeData mime in email.Attachments)
                        {
                            mime.Save(@"C:\AdmToSii\file\xml\proveedores\" + mime.SafeFileName);
                            nomArchivo = mime.SafeFileName;
                        }
                        Console.WriteLine("===================================================");
                        descargaModel.uid = uid;
                        descargaModel.nomArchivo = nomArchivo;
                        descargaModel.save(descargaModel);
                        
                    }
                }
                pop3.Close();
                
            }
        }
    }
    
}
