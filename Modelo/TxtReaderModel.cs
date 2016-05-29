using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Json;
using System.Data.SQLite;

namespace Modelo
{
    public class TxtReaderModel
    {
        BaseDato bd = new BaseDato();
        public DocumentoModel lectura(String fileJson, bool moveFile, String dirOrigen)
        {
            DocumentoModel doc = new DocumentoModel();
            fileAdmin file = new fileAdmin();
            String fileName = String.Empty;

            if (dirOrigen == "")
            {
                dirOrigen = @"C:\AdmToSii\file";
            }
            

            if (fileJson == "")
            {
                fileName = file.nextFile(dirOrigen, "*.json");
            }
            else
            {
                fileName = dirOrigen + fileJson;
            }


            if (fileName != null)
            {
                StreamReader objReader = new StreamReader(fileName,System.Text.Encoding.Default,true);
                objReader.ToString();
                String data = objReader.ReadToEnd();
        
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(DocumentoModel));
                
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data));

                try
                {
                    doc = (DocumentoModel)js.ReadObject(ms);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                   // MessageBox.Show("Error de lectura JSON"+ e.Message);
                }
  
                // Datos del Emisor
                // Cargo datos en laclase Documento desde sqlite
                string oc = bd.GetOC();
                if (oc == "True")
                {
                    doc.NroOrdenCompra = Convert.ToInt32(getOrdenCompra(data));
                    doc.NroCita = getNroCita(data);
                    doc.Sello = getSello(data);
                }


                if (doc.RUTEmisor == null)
                {
                    try
                    {

                        SQLiteConnection myConn = bd.ConnectSqlite();
                        myConn.Open();

                        string sql = "select * from empresa";
                        SQLiteCommand command = new SQLiteCommand(sql, myConn);
                        SQLiteDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {

                            doc.RUTEmisor = reader["RutEmisor"].ToString();
                            doc.RznSoc = reader["RznSoc"].ToString();
                            doc.GiroEmis = reader["GiroEmis"].ToString();
                            doc.Telefono = reader["Telefono"].ToString();
                            doc.CorreoEmisor = reader["CorreoEmisor"].ToString();
                            doc.Acteco = Convert.ToInt32(reader["Acteco"]);
                            doc.CdgSIISucur = Convert.ToInt32(reader["CdgSIISucur"]);
                            doc.DirMatriz = reader["DirMatriz"].ToString();
                            doc.CmnaOrigen = reader["CmnaOrigen"].ToString();
                            doc.CiudadOrigen = reader["CiudadOrigen"].ToString();
                            doc.DirOrigen = reader["DirOrigen"].ToString();
                            doc.NombreCertificado = reader["NomCertificado"].ToString();
                            doc.SucurEmisor = reader["SucurEmisor"].ToString();
                            doc.FchResol = reader["FchResol"].ToString();
                            doc.RutEnvia = reader["RutCertificado"].ToString();
                            doc.NumResol = reader["NumResol"].ToString();
                            doc.CondEntrega = reader["CondEntrega"].ToString();

                        }
                        myConn.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ERROR: {0}", e.ToString());
                    }
                }
                else
                {
                    try
                    {

                        SQLiteConnection myConn = bd.ConnectSqlite();
                        //myConn.Open();

                        string sql = "select * from empresa where empresa.RutEmisor = '"+ doc.RUTEmisor.ToString() +"'";
                        SQLiteCommand command = new SQLiteCommand(sql, myConn);
                        SQLiteDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {

                            doc.Telefono = reader["Telefono"].ToString();
                            doc.CorreoEmisor = reader["CorreoEmisor"].ToString();
                            doc.Acteco = Convert.ToInt32(reader["Acteco"]);
                            doc.DirRegionalSII = reader["sucurSII"].ToString();
                            doc.DirMatriz = reader["DirMatriz"].ToString();
                            doc.NombreCertificado = reader["NomCertificado"].ToString();
                            doc.SucurEmisor = reader["SucurEmisor"].ToString();
                            doc.FchResol = reader["FchResol"].ToString();
                            doc.RutEnvia = reader["RutCertificado"].ToString();
                            doc.NumResol = reader["NumResol"].ToString();
                            doc.CondEntrega = reader["CondEntrega"].ToString();
                            doc.PrnMtoNeto = reader["PrnMtoNeto"].ToString();
                            doc.PrnTwoCopy = reader["PrnTwoCopy"].ToString();


                        }

                        myConn.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ERROR: {0}", e.ToString());
                    }
               }

                objReader.Close();
                ms.Close();
                if (moveFile)
                {
                    file.mvFile(fileName, dirOrigen, "C:/AdmToSii/fileProcess/");
                }
                
                CafModel caf = new CafModel();

                if(!caf.isValid(doc))
                {
                    doc = null;
                }

                if (fileJson == "")
                {
                    doc.fileName = fileName;
                }
                else
                {
                    doc.fileName = fileJson;
                }
                return doc;
            }
            else
            {
                return null;
            }
            


        }

        private string getOrdenCompra(string json)
        {
            string ordenCompra = string.Empty;
            int start = json.IndexOf("NroOrdenCompra") + 17;
            int end = json.IndexOf("\",\"NumId\"");
            int largo = end - start;

            ordenCompra = json.Substring(start, largo);
            if (json == "")
            {
                json = "";
            }

            return ordenCompra;
        }

        private string getNroCita(string json)
        {
            string nro_cita = string.Empty;
            int start = json.IndexOf("NroCita") + 10;
            int end = json.IndexOf("\",\"NroOrdenCompra\"");
            int largo = end - start;

            nro_cita = json.Substring(start, largo);
            if (json == "")
            {
                json = "";
            }

            return nro_cita;
        }

        private string getSello(string json)
        {
            string sello = string.Empty;
            int start = json.IndexOf("Sello") + 8;
            int end = json.IndexOf("\",\"Sucursal\"");
            int largo = end - start;

            sello = json.Substring(start, largo);
            if (json == "")
            {
                json = "";
            }

            return sello;
        }
    }

}
