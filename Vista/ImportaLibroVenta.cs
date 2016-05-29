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
    public partial class ImportaLibroVenta : Form
    {
        List<string[]> parsedata = new List<string[]>();
        DocumentoModel doc = new DocumentoModel();
        public ImportaLibroVenta()
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
                    Console.WriteLine(row[2]);
                    parsedata.Add(row);

                }
            }
            dataGridView1.ColumnCount = 16;
            for (int i = 0; i < 16; i++)
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
                        doc.MntTotal = Convert.ToInt32(row[10]);
                        doc.estado = "PREVIO";
                        doc.save(doc);
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
    }
}
