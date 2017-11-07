using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Modelo;

namespace Vista
{
    public partial class ImportaLibroCompra : Form
    {
        List<string[]> parsedata = new List<string[]>();
        DocumentoModel doc = new DocumentoModel();
        
        public ImportaLibroCompra()
        {
            InitializeComponent();
        }

        private void buttonActualiza_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Text = this.openFileDialog1.FileName;
            }
            this.openFileDialog1.Dispose();

            using (var sr = new StreamReader(@"" + label1.Text + "", Encoding.Default, true)) 
            {
                string line = "";

                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Replace("Ñ", "N");
                    line = line.Replace("&", "Y");
                    string[] row = line.Split(';');
                    parsedata.Add(row);

                }
            }
            dataGridView1.ColumnCount = 15;
            for (int i = 0; i < 15; i++)
            {
                var sb = new StringBuilder(parsedata[0][i]);
                sb.Replace('_', ' ');
                sb.Replace("\"", "");
                dataGridView1.Columns[i].Name = sb.ToString();

            }

            foreach (string[] row in parsedata)
            {
                dataGridView1.Rows.Add(row);
            }
            dataGridView1.Rows.Remove(dataGridView1.Rows[0]);
        
        }

        private DateTime formatFecha(string fecha)
        {
            DateTime fech = Convert.ToDateTime(fecha);
            return fech;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string[] row in parsedata)
            { 
             // elimino la primera linea
                if (row[0] != "tipodoc")
                {
                    try
                    {

                        doc.TipoDTE = Convert.ToInt32(row[0]);
                        doc.Folio = Convert.ToInt32(row[1]);
                        doc.FchEmis = row[2];
                        doc.RUTEmisor = row[3];
                        doc.RUTRecep = row[4];
                        doc.RznSoc = row[5];
                        doc.MntNeto = Convert.ToInt32(row[6]);
                        doc.MntExe = Convert.ToInt32(row[7]);
                        doc.IVA = Convert.ToInt32(row[8]);
                        doc.tipoimp = row[9].ToString();
                        if (row[10] == "") row[10] = "0";
                        doc.tasaimp = Convert.ToDecimal(row[10]);
                        if (row[11] == "") row[11] = "0";
                        doc.montoimp = Convert.ToInt32(row[11]);
                        doc.MntTotal = Convert.ToInt32(row[12]);
                        doc.estado = "PREVIO";
                        if (doc.exist(doc.RUTEmisor,doc.TipoDTE.ToString(),doc.Folio.ToString()) == "False") doc.save(doc);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de Base Dato:" + ex);
                    }
                }                
            }
            MessageBox.Show("Datos importados con exito!");
            this.Close();
        }

        private void ImportaLibroCompra_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
