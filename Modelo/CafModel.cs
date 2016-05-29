using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data;
using System.Data.SQLite;

namespace Modelo
{
   public class CafModel
    {
       BaseDato bd = new BaseDato();
        public Int32 id { get; set; }
        public String cafxml { get; set; }
        public DateTime fecha { get; set; }
        public string tipoDte { get; set; }
        public string dirCaf { get; set; }
        public Int32 folioInicial { get; set; }
        public Int32 folioFinal { get; set; }
        public string rutEmpresa { get; set; }
        public string nomXml { get; set; }

        public bool isValid(DocumentoModel doc)
        {
            bool valid = true;

            String xmlCaf = String.Empty;
            String cafDir = String.Empty;

            fileAdmin file = new fileAdmin();

            string rut = doc.RUTEmisor;

            try
            {
                switch (doc.TipoDTE)
                {
                    case 33: cafDir = @"C:\AdmToSii\cafs\" + rut + @"\factura\";
                        break;
                    case 61: cafDir = @"C:\AdmToSii\cafs\" + rut + @"\notacredito\";
                        break;
                    case 56: cafDir = @"C:\AdmToSii\cafs\" + rut + @"\notadebito\";
                        break;
                    case 52: cafDir = @"C:\AdmToSii\cafs\" + rut + @"\Guia\";
                        break;
                    case 34: cafDir = @"C:\AdmToSii\cafs\" + rut + @"\facturaexenta\";
                        break;
                }

                xmlCaf = file.nextFile(cafDir, "*.xml");

                String xml = String.Empty;

                if (xmlCaf != null)
                {
                    StreamReader objReader = new StreamReader(xmlCaf, System.Text.Encoding.Default, true);
                    objReader.ToString();
                    xml = objReader.ReadToEnd();
                }


                int start = xml.IndexOf("<TD") + 4;
                int end = xml.IndexOf("</TD>");
                int largo = end - start;

                // Valida tipo de documento
                String td = xml.Substring(start, largo);
                if (td != doc.TipoDTE.ToString()) valid = false;


                start = xml.IndexOf("<FA>") + 4;
                end = xml.IndexOf("</FA>");
                largo = end - start;
                // Valida FECHA de documento
                String fch = xml.Substring(start, largo);

                DateTime fchCaf = DateTime.ParseExact(fch, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);

                DateTime fEmis = DateTime.ParseExact(fch, "yyyy-MM-dd",
                       System.Globalization.CultureInfo.InvariantCulture);

                if (fEmis > fchCaf)
                {
                    valid = false;
                }


                start = xml.IndexOf("<D>") + 3;
                end = xml.IndexOf("</D>");
                largo = end - start;
                String d = xml.Substring(start, largo);

                start = xml.IndexOf("<H>") + 3;
                end = xml.IndexOf("</H>");
                largo = end - start;
                String h = xml.Substring(start, largo);


                // Valida Folio del documento dentro del rango CAF 
                int ds = Convert.ToInt32(d);
                int hs = Convert.ToInt32(h);

                // TO DO: Descomentar esta linea para el proceso de producción
            //    if (!((folio < hs) && (folio >ds)) ) valid = false;


                // OTRAS VALIDACIONES
                if (doc.CiudadRecep == null || doc.CiudadRecep == String.Empty ) valid = false;
                if (doc.CmnaRecep == null || doc.CmnaRecep == String.Empty) valid = false;
                

            }
            catch (Exception e)
            {
                Console.WriteLine("The file CAF could not be read:");
                Console.WriteLine(e.Message);
            }


            return valid;
        }

        public FolioModel getCaf(String rut, String tipoDte)
        {

            XmlDocument xDoc = new XmlDocument();
            FolioModel folio = new FolioModel();

            //La ruta del documento XML permite rutas relativas 
            //respecto del ejecutable!

            xDoc.Load(@"C:/AdmToSii/cafs/77398570-7/notacredito/FoliosSII77398570611382015691252.xml");

            XmlNodeList lista = xDoc.GetElementsByTagName("AUTORIZACION");

            XmlNodeList lista1 = ((XmlElement)lista[0]).GetElementsByTagName("CAF");

            XmlNodeList lista2 = ((XmlElement)lista1[0]).GetElementsByTagName("DA");

            XmlNodeList lista3 = ((XmlElement)lista2[0]).GetElementsByTagName("RNG");

            foreach (XmlElement nodo in lista)
            {

                int i = 0;

                XmlNodeList rutCaf =
                nodo.GetElementsByTagName("RE");

                XmlNodeList rzSoc =
                nodo.GetElementsByTagName("RS");

                XmlNodeList tpoDte =
                nodo.GetElementsByTagName("TD");

                XmlNodeList folioIni =
                nodo.GetElementsByTagName("D");

                XmlNodeList folioFinal =
                nodo.GetElementsByTagName("H");

                folio.rut = rutCaf[i].InnerText;
                folio.rsnsocial = rzSoc[i].InnerText;
              //  folio.tipoDte = tipoDte[i].InnerText;
              //  folio.folioIni = folioIni[i].InnerText;
              //  folio.folioFin = folioFinal[i].InnerText;
                int final = Convert.ToInt32(folioFinal[i].InnerText);
                int inicial = Convert.ToInt32(folioIni[i].InnerText);
              //  folio.rango = final - inicial + 1;

                Console.WriteLine(" Rut: {0} Razon Social: {1} Tipo Dte {2} Folio Inicial: {3} Folio Final {4} Rango {5}",
                                             folio.rut,
                                             folio.rsnsocial,
                                         //    folio.tpoDte,
                                             folio.folioIni,
                                             folio.folioFin,
                                             folio.rango);                                             ;


            }

            return folio;
            
        }

        public int getCafActual(int tipoDte)
        {
            string idUltimoCaf = string.Empty;
            SQLiteConnection sqliteConn = new SQLiteConnection();
            sqliteConn = bd.ConnectSqlite();

            string sql = "SELECT max(id) FROM caf where \"tipoDte\" =  '" + tipoDte + "';";
            SQLiteCommand command = new SQLiteCommand(sql, sqliteConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                idUltimoCaf = reader.GetString(reader.GetOrdinal("max"));
            }
            return Convert.ToInt32(idUltimoCaf);
        }

        // recupera caf desde xml

        public CafModel xmlToCaf(string dirfile)
        {

            CafModel cafModel = new CafModel();
            XmlDocument xDoc = new XmlDocument();
            //La ruta del documento XML permite rutas relativas 
            //respecto del ejecutable!
            try
            {
                xDoc.Load(@"" + dirfile + "");

                XmlNodeList lista = xDoc.GetElementsByTagName("AUTORIZACION");

                XmlNodeList lista1 = ((XmlElement)lista[0]).GetElementsByTagName("CAF");

                XmlNodeList lista2 = ((XmlElement)lista1[0]).GetElementsByTagName("DA");

                XmlNodeList lista3 = ((XmlElement)lista2[0]).GetElementsByTagName("RNG");

                foreach (XmlElement nodo in lista)
                {

                    int i = 0;

                    XmlNodeList rutCaf =
                    nodo.GetElementsByTagName("RE");

                    XmlNodeList rzSoc =
                    nodo.GetElementsByTagName("RS");

                    XmlNodeList tpoDte =
                    nodo.GetElementsByTagName("TD");

                    XmlNodeList folioIni =
                    nodo.GetElementsByTagName("D");

                    XmlNodeList folioFinal =
                    nodo.GetElementsByTagName("H");

                    XmlNodeList fechaCaf =
                     nodo.GetElementsByTagName("FA");

                    int final = Convert.ToInt32(folioFinal[i].InnerText);
                    int inicial = Convert.ToInt32(folioIni[i].InnerText);
                    int tipoDte = Convert.ToInt32(tpoDte[i].InnerText);
                    DateTime fechacaf = Convert.ToDateTime(fechaCaf[i].InnerText);
                    string rut = rutCaf[i].InnerText;

                    //Cargo el objeto
                    cafModel.tipoDte = tipoDte.ToString();
                    cafModel.fecha = fechacaf;
                    cafModel.folioInicial = inicial;
                    cafModel.folioFinal = final;
                    cafModel.rutEmpresa = rut;
                    cafModel.cafxml = xDoc.InnerXml.ToString();
                }
            }
            catch (IOException ie)
            {

            }


            return cafModel;
        }

        public void save(CafModel cafmodel)
        {
            try
            {
                SQLiteConnection sqliteConn = new SQLiteConnection();
                sqliteConn = bd.ConnectSqlite();

                string sql = "INSERT INTO caf("
                    + "cafxml, fecha, \"tipoDte\", \"dirCaf\", \"folioInicial\", \"folioFinal\",\"rutEmpresa\",\"nomXml\")"
                    + " VALUES ('"
                    + cafmodel.cafxml + "','"
                    + cafmodel.fecha + "','"
                    + cafmodel.tipoDte + "','"
                    + cafmodel.dirCaf + "',"
                    + cafmodel.folioInicial + ","
                    + cafmodel.folioFinal + ",'"
                    + cafmodel.rutEmpresa + "','"
                    + cafmodel.nomXml + "'"
                    + ");";
                SQLiteCommand command = new SQLiteCommand(sql, sqliteConn);
                command.ExecuteNonQuery();
                sqliteConn.Close();


            }
            catch (SQLiteException ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }

        public string exist(string nomxml)
        {
            string exist = "False";
            try
            {
                string stringcon = string.Empty;
                SQLiteConnection sqliteConn = new SQLiteConnection();
                sqliteConn = bd.ConnectSqlite();
                string sql = "SELECT * FROM caf where nomXml = '" + nomxml + "'";
                SQLiteCommand command = new SQLiteCommand(sql, sqliteConn);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows != false)
                {
                    exist = "True";
                }
                sqliteConn.Close();
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Error" + ex.Message);
   
            }
  
            return exist;
        }

        public DataTable getCafs()
        {
            DataTable datatable = new DataTable();
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                string stringcon = string.Empty;
                SQLiteConnection sqliteConn = new SQLiteConnection();
                sqliteConn = bd.ConnectSqlite();

                string sql = "SELECT * FROM caf order by id DESC";
                SQLiteCommand command = new SQLiteCommand(sql, sqliteConn);

                SQLiteDataReader reader = command.ExecuteReader();
                command.ExecuteNonQuery();
                datatable.Load(reader);
                sqliteConn.Close();

            }
            catch (Exception ex)
            {
                datatable = null;
                throw new Exception("Error" + ex.Message);
            }

            finally
            {
                sqlcon.Close();
            }

            return datatable;
        }




    }

}
