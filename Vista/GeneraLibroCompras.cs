using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modelo;
using System.IO;

namespace Vista
{
    public partial class GeneraLibroCompras : Form
    {
        DataTable dataTable = new DataTable();
        LibroCompraModel libroCompraM = new LibroCompraModel();
        EmpresaModel empresaM = new EmpresaModel();
        public GeneraLibroCompras()
        {
            InitializeComponent();
        }

        private void GeneraLibroCompras_Load(object sender, EventArgs e)
        {
            actualizaDG();
        }


        public void actualizaDG()
        {
            dateTimePicker1.CustomFormat = "MM-yyyy";
            dataGridView1.Rows.Clear();
            dataTable = libroCompraM.listaLibroXFecha(new DateTime(),"PREVIO","","");
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
            }
            dataTable = libroCompraM.listaResumen(new DateTime());

            foreach (DataRow fila in dataTable.Rows)
            {
                Int32 n = this.dataGridView2.Rows.Add();
                dataGridView2.Rows[n].Cells[0].Value = fila["TipoDTE"].ToString();
                dataGridView2.Rows[n].Cells[1].Value = fila["CantDoc"].ToString();
                dataGridView2.Rows[n].Cells[2].Value = fila["MntNeto"].ToString();
                dataGridView2.Rows[n].Cells[3].Value = fila["MntExe"].ToString();
                dataGridView2.Rows[n].Cells[4].Value = fila["IVA"].ToString();
                dataGridView2.Rows[n].Cells[5].Value = "0";
                dataGridView2.Rows[n].Cells[6].Value = fila["MntTotal"].ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fchActual = DateTime.Now.ToString("yyyyMMddhhmmss");
            string periodoTributario = dateTimePicker1.Value.ToString("yyyy-MM");
            empresaM = empresaM.getEmpresa();
            try
            {
                StreamWriter escribe = new StreamWriter(@"C:\AdmToSii\file\libroCompra\LibroCompras_" + empresaM.RutEmisor + "_" + fchActual + ".json");
                escribe.WriteLine("{");
                escribe.WriteLine(" \"RutEmisorLibro\": \"" + empresaM.RutEmisor + "\",");
                escribe.WriteLine(" \"RutEnvia\": \""+empresaM.RutCertificado+"\",");
                escribe.WriteLine(" \"PeriodoTributario\": \""+periodoTributario+"\",");
                escribe.WriteLine("	\"FchResol\": \"" + empresaM.FchResol + "\",");
                escribe.WriteLine("	\"NroResol\": "+empresaM.NumResol+",");
                escribe.WriteLine("	\"TipoOperacion\": \"COMPRA\",");
                escribe.WriteLine("	\"TipoLibro\": \"MENSUAL\",");
                escribe.WriteLine("	\"TipoEnvio\": \"TOTAL\",");
               //escribe.WriteLine("	\"FolioNotificacion\": 2,");
                escribe.WriteLine("	\"TotalesPeriodo\": [");
                // for para cargar TotalesPeriodo;
                int lineaFinalTotPeriodo = 0;
                foreach (DataRow fila in dataTable.Rows)
                {
                    escribe.WriteLine("      {");
                    escribe.WriteLine("		\"TpoDoc\": "+fila["TipoDTE"].ToString()+",");
                    escribe.WriteLine("		\"TotDoc\": " + fila["CantDoc"].ToString() + ",");
                    escribe.WriteLine("		\"TotMntExe\": " + fila["MntExe"].ToString() + ",");
                    escribe.WriteLine("		\"TotMntNeto\": " + fila["MntNeto"].ToString() + ",");
                    escribe.WriteLine("		\"TotMntIVA\": " + fila["IVA"].ToString() + ",");
                    escribe.WriteLine("		\"TotMntTotal\": " + fila["MntTotal"].ToString() + "");
                    //si es la ultima sin coma

                    if (lineaFinalTotPeriodo != dataTable.Rows.Count - 1)
                    {
                        escribe.WriteLine("      },");
                        lineaFinalTotPeriodo = lineaFinalTotPeriodo + 1;
                    }
                    else
                    {
                        escribe.WriteLine("      }");
                    }

                }
                escribe.WriteLine("		],");
                //fin TotalesPeriodo
                escribe.WriteLine("	\"Detalle\": [");
                //for para cargar Detalle
                dataTable = libroCompraM.listaLibroXFecha(new DateTime(),"PREVIO","","");
                int lineaFinalDetalle = 0;
                foreach (DataRow fila in dataTable.Rows)
                {
                    string fchEmis = Convert.ToDateTime(fila["FchEmis"]).ToString("yyyy-MM-dd");
                    escribe.WriteLine("      {");
                    escribe.WriteLine("		\"TpoDoc\": " + fila["TipoDTE"] + ",");
                    escribe.WriteLine("		\"NroDoc\": " + fila["Folio"] + ",");
                    escribe.WriteLine("		\"TpoImp\": 1,");
                    escribe.WriteLine("		\"TasaImp\": 19,");
                    escribe.WriteLine("		\"FchDoc\": \"" + fchEmis + "\",");
                    escribe.WriteLine("		\"RUTDoc\": \"" + fila["RUTEmisor"]+ "\",");
                    escribe.WriteLine("		\"RznSoc\": \"" + fila["RznSoc"]+ "\",");
                    escribe.WriteLine("		\"MntExe\": " +fila["MntExe"] + ",");
                    escribe.WriteLine("		\"MntNeto\": " + fila["MntNeto"] + ",");
                    escribe.WriteLine("		\"MntIVA\": " + fila["IVA"] + ",");
                    escribe.WriteLine("		\"MntTotal\": " + fila["MntTotal"] + "");
                    if (lineaFinalDetalle != dataTable.Rows.Count - 1)
                    {
                        escribe.WriteLine("      },");
                        lineaFinalDetalle = lineaFinalDetalle + 1;
                    }
                    else
                    {
                        escribe.WriteLine("      }");
                    }

                }
                escribe.WriteLine("		]");
                escribe.WriteLine("}");
                escribe.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al escribir" + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void buttonActualiza_Click(object sender, EventArgs e)
        {

        }
    }
}
