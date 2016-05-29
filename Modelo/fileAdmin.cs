using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace Modelo
{
   public class fileAdmin
    {
        public String nextFile(String path, String fileType)
        {

            //fileType ejemplo:  "*.txt"
            //path     ejemplo:   @"c:\files\"  

            String fileName = String.Empty;

            string currentDirName = System.IO.Directory.GetCurrentDirectory();
       
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            System.IO.Directory.SetCurrentDirectory(path);

            currentDirName = System.IO.Directory.GetCurrentDirectory();

            string[] files = System.IO.Directory.GetFiles(currentDirName, fileType);

            if (files.Count() > 0)
            {
                string s = files.First();

                System.IO.FileInfo fi = null;
                try
                {
                    fi = new System.IO.FileInfo(s);
                }
                catch (System.IO.FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }

                fileName = fi.Name;
                Console.WriteLine("NextFile   {0} : {1}", fi.Name, fi.Directory);

                return fileName;
            }
            else
            {
                return null;
            }
        }


        public void mvFile(String fileName, String path, String path2)
        {
            Console.WriteLine("Mueve el archivo");


            try
            {
                if (!Directory.Exists(path2))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path2);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }


            try
            {

                if (System.IO.File.Exists(path2 + fileName)) System.IO.File.Delete(path2 + fileName);

               System.IO.File.Move(path +"/"+ fileName, path2+"/" + fileName);


            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }


        }

        public String fileAprox(String fileN, String path, String fileType)
        {
            String fileName = null;

            string currentDirName = System.IO.Directory.GetCurrentDirectory();

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            System.IO.Directory.SetCurrentDirectory(path);

            currentDirName = System.IO.Directory.GetCurrentDirectory();

            string[] files = System.IO.Directory.GetFiles(currentDirName, fileType);

            if (files.Count() > 0)
            {
              //  string s = files.First();

                foreach (var s in files)
                {
                    System.IO.FileInfo fi = null;
                    try
                    {
                        fi = new System.IO.FileInfo(s);
                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    String f =fi.Name;

                    int largo = f.Length - 19; // 19 es el largo de la fecha hora mi ss el . y la extencion xml
                    String fName = fi.Name.Substring(0, largo);
                    if (fName == fileN)
                    {
                        fileName = fi.Name;
                    }
                    Console.WriteLine("NextFile   {0} : {1}", fi.Name, fi.Directory);
                }   
                return fileName;
            }
            else
            {
                return null;
            }
        }

        public void buscaXmlProveedor()
        {
            string urlXml = string.Empty;
            string fileName = nextFile(@"C:\AdmToSii\file\xml\proveedores", "*.xml");
            urlXml = @"C:\AdmToSii\file\xml\proveedores\" + fileName;
            //serializar xml
            XmlTextReader reader = new XmlTextReader(urlXml);
            if (fileName != null)
            {
                while (reader.ReadToFollowing("Documento"))
                {
                    DocumentoModel doc = new DocumentoModel();
                    XmlReader readerDoc = reader.ReadSubtree();
                    while (readerDoc.Read())
                    {
                        if (readerDoc.Name == "TipoDTE") doc.TipoDTE = Convert.ToInt32(reader.ReadString());
                        if (readerDoc.Name == "Folio") doc.Folio = Convert.ToInt32(reader.ReadString());
                        if (readerDoc.Name == "FchEmis") doc.FchEmis = reader.ReadString();
                        if (readerDoc.Name == "RUTEmisor") doc.RUTEmisor = reader.ReadString();
                        if (readerDoc.Name == "RznSoc") doc.RznSoc = reader.ReadString();
                        if (readerDoc.Name == "GiroEmis") doc.GiroEmis = reader.ReadString();
                        if (readerDoc.Name == "RUTRecep") doc.RUTRecep = reader.ReadString();
                        if (readerDoc.Name == "RznSocRecep") doc.RznSocRecep = reader.ReadString();
                        if (readerDoc.Name == "GiroRecep") doc.GiroRecep = reader.ReadString();
                        if (readerDoc.Name == "MntNeto") doc.MntNeto = Convert.ToInt32(reader.ReadString());
                        if (readerDoc.Name == "IVA") doc.IVA = Convert.ToInt32(reader.ReadString());
                        if (readerDoc.Name == "MntTotal") doc.MntTotal = Convert.ToInt32(reader.ReadString());
                        doc.estado = "DISCHARGED";
                        doc.NombreXml = fileName;

                    }
                    if (doc.exist(doc.RUTEmisor, doc.TipoDTE.ToString(), doc.Folio.ToString()) == "False")
                    {
                        doc.save(doc);
                    }
                }
                reader.Close();
                //Muevo el archivo
                mvFile(fileName, @"C:\AdmToSii\file\xml\proveedores\", @"C:\AdmToSii\file\xml\proveedores\fileprocess\");
                //Actualizo grilla
            }
        }

    }
}
