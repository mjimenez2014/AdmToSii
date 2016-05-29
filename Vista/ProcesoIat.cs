using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;
using Modelo;


namespace Vista
{
   public class ProcesoIat
    {
        EmpresaModel empresa = new EmpresaModel();
        ConnectSii conSii = new ConnectSii();
        EnvioModel envioM = new EnvioModel();
        FuncionesComunes funcComunes = new FuncionesComunes();
        fileAdmin fileAdm = new fileAdmin();

        public void DoProcessIat()
        {

            PrinterModel print = new PrinterModel();
            List<PrinterModel> printerList = print.printerList();
            if (printerList.Count == 0)
            {
               //MessageBox.Show(@"No hay impresoras configuradas, se usará DefaultPrinter");
            }

            int i = 0;
            int j = 0;


            while (!_shouldStop)
            {
                Console.WriteLine("ProcessIat thread: working...");

                Thread.Sleep(5000);

                i++;

                String paquete = String.Empty;
                String dirCurrentFile = String.Empty;
                String Impresora = String.Empty;

                // instancia fileadmin, para tener las herramientas para mover archivos
                fileAdmin fileAdm = new fileAdmin();

                // inatancia txt_reader
                TxtReaderModel lec = new TxtReaderModel();

                DocumentoModel docLectura = new DocumentoModel();
                FuncionesComunes fc = new FuncionesComunes();

                if (printerList.Count == 0)
                {
                    dirCurrentFile = @"C:\AdmToSii\file";
                    Impresora = fc.GetDefaultPrinter();
                }
                else
                {
                    PrinterModel printDir = printerList.ElementAt(j);
                    dirCurrentFile = printDir.directory;
                    Impresora = printDir.printerName;
                }
                Console.WriteLine("Buscando Json en " + dirCurrentFile);
                j++;


                // Ejecuta metodo de txt_reader que llena y obtienen Clase Documento
                docLectura = lec.lectura("", false, dirCurrentFile);

                xmlPaquete xml = new xmlPaquete();

                List<int> tipos = new List<int>();

                DateTime thisDay = DateTime.Now;
                String fch = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", thisDay);
                String fchName = String.Format("{0:yyyyMMddTHHmmss}", thisDay);

                LogModel log = new LogModel();

                String firsRut = String.Empty;
                empresa = empresa.getEmpresa();
  

                if (docLectura != null)
                {
                    docLectura.estado = "PREVIO";
                    new DocumentoModel().save(docLectura);
                    // Proceso de ReImpresión
                    // ir a directorio procesados y buscar el archivo docLectura.filename 
                    if (System.IO.File.Exists(@"C:\AdmToSii\fileprocess\" + docLectura.fileName)) // si ya existe, reimprimir
                    {
                        if (empresa.PrnThermal == "True")
                        {
                            String fileNameXML = @"DTE_" + docLectura.RUTEmisor + "_" + docLectura.TipoDTE + "_" + docLectura.Folio + "_";
                            fileAdmin f = new fileAdmin();

                            String fileXml = f.fileAprox(fileNameXML, @"C:/AdmToSii/file/xml/", "*.xml");

                            if (fileXml != null)
                            {
                                new ReimpThermal().reimp(docLectura, fileXml, Impresora);
                            }
                            
                        }
                        else
                        {
                            String fileNamePDFRePrint = @"C:/AdmToSii/file/pdf/PRINT_" + docLectura.RUTEmisor + "_" + docLectura.TipoDTE + "_" + docLectura.Folio + ".pdf";

                            if (System.IO.File.Exists(fileNamePDFRePrint))
                            {
                                fc.printPdf(fileNamePDFRePrint, Impresora);
                            }
                        }
                        fileAdm.mvFile(docLectura.fileName, dirCurrentFile, @"C:\AdmToSii\fileprocess\");
                    }
                    else // si no procesar
                    {
                        fileAdm.mvFile(docLectura.fileName, dirCurrentFile, @"C:\AdmToSii\fileprocess\");

                        log.addLog("Inicio proceso TipoDTE :" + docLectura.TipoDTE + " Folio :" + docLectura.Folio, "OK");
                        tipos.Add(docLectura.TipoDTE);

                        String TimbreElec = xml.ted_to_xmlSii(docLectura, fch);
                        log.addLog("Crea Timbre TipoDTE :" + docLectura.TipoDTE + " Folio :" + docLectura.Folio, "OK");

                        String docXmlSign = xml.doc_to_xmlSii(docLectura, TimbreElec, fch);
                        log.addLog("Crea XML Envio TipoDTE :" + docLectura.TipoDTE + " Folio :" + docLectura.Folio, "OK");

                        // Guarda DTE xml
                        String DTE = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\r\n" + docXmlSign;
                        String fileNameXML = @"C:/AdmToSii/file/xml/DTE_" + docLectura.RUTEmisor + "_" + docLectura.TipoDTE + "_" + docLectura.Folio + "_" + fchName + ".xml";
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileNameXML, false, Encoding.GetEncoding("ISO-8859-1")))
                        {
                            file.WriteLine(docXmlSign);
                        }


                        //-----------------------------------------------------------------THERMAL--------------------------------------------------------------
                      
                        if (empresa.PrnThermal == "True")
                        {
                            try
                            {                                  
                                for (int copies = 0; copies < 3; copies++)
                                {
                                    Thermal thermal = new Thermal();
                                    thermal.doc = docLectura;
                                    thermal.dd = TimbreElec;
                                    thermal.copias = copies;
                                    if (docLectura.PrnTwoCopy == "True")
                                        copies = 1;
                                    docLectura.PrnTwoCopy = "False";
                                    if (copies == 2)
                                    {
                                        if (docLectura.TipoDTE == 33 || docLectura.TipoDTE == 34)
                                        {
                                            thermal.tipoCopia = "CEDIBLE";
                                        }
                                        if (docLectura.TipoDTE == 52)
                                        {
                                            thermal.tipoCopia = "CEDIBLE CON SU FACTURA";
                                        }

                                        if (docLectura.TipoDTE == 61)
                                        {
                                            break;
                                        }
                                    }
                                //  
                                PrintDocument pd = new PrintDocument();
                                pd.DefaultPageSettings.PaperSize = new PaperSize("", 284, 1800);
                                 pd.PrintPage += new PrintPageEventHandler(thermal.OpenThermal);
                                 pd.PrinterSettings.PrinterName = Impresora;
                                 Console.WriteLine(pd.ToString());
                                 pd.Print();
                                }

                                Pdf docpdf = new Pdf();

                                String fileNamePDF = @"C:/AdmToSii/file/pdf/DTE_" + docLectura.RUTEmisor + "_" + docLectura.TipoDTE + "_" + docLectura.Folio + "_" + fchName + ".pdf";
                                docpdf.OpenPdf(TimbreElec, docLectura, fileNamePDF, " ");
                                log.addLog("Crea PDF Trib TipoDTE :" + docLectura.TipoDTE + " Folio :" + docLectura.Folio, "OK");

                                String fileNamePDFCed = @"C:/AdmToSii/file/pdf/DTE_" + docLectura.RUTEmisor + "_" + docLectura.TipoDTE + "_" + docLectura.Folio + "_" + fchName + "CEDIBLE.pdf";

                                if (docLectura.TipoDTE == 33 || docLectura.TipoDTE == 34)
                                {
                                    docpdf.OpenPdf(TimbreElec, docLectura, fileNamePDFCed, "CEDIBLE");
                                }

                                if (docLectura.TipoDTE == 52)
                                {
                                    docpdf.OpenPdf(TimbreElec, docLectura, fileNamePDFCed, "CEDIBLE CON SU FACTURA");
                                }
                                log.addLog("Crea PDF C TipoDTE :" + docLectura.TipoDTE + " Folio :" + docLectura.Folio, "OK");
                                log.addLog("IMPRIME TipoDTE :" + docLectura.TipoDTE + " Folio :" + docLectura.Folio, "OK");

                                // Agrega el DTE timbrado al paquete

                                paquete = paquete + docXmlSign;

                                //Estrae el rut del emisor de la primera factura del paquete
                                if (i == 0) firsRut = docLectura.RUTEmisor;
                                i++;



                                // Firma Paquete unitario   
                                String envioCliente = xml.creaEnvio(paquete, docLectura.RUTEmisor, docLectura.RUTRecep, tipos, docLectura.RutEnvia, docLectura.FchResol, docLectura.RUTRecep, docLectura.NumResol);

                                String envioSII = xml.creaEnvio(paquete, docLectura.RUTEmisor, docLectura.RUTRecep, tipos, docLectura.RutEnvia, docLectura.FchResol, "", docLectura.NumResol);

                                X509Certificate2 cert = FuncionesComunes.obtenerCertificado(docLectura.NombreCertificado);

                                String enviox509SII = xml.firmarDocumento(envioSII, cert);
                                String enviox509Cliente = xml.firmarDocumento(envioCliente, cert);

                                log.addLog("FIRMA ENVIO TipoDTE :" + docLectura.TipoDTE + " Folio :" + docLectura.Folio, "OK");

                                enviox509SII = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\r\n" + enviox509SII;
                                enviox509Cliente = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\r\n" + enviox509Cliente;


                                String fileNameEnvioSII = @"C:/AdmToSii/file/xml/enviounitario/EnvioUnit_" + docLectura.RUTEmisor + "_" + docLectura.Folio + "_" + fchName + ".xml";

                                String fileNameEnvioCliente = @"C:/AdmToSii/file/xml/enviounitario/EnvioUnitCliente_" + docLectura.RUTEmisor + "_" + docLectura.Folio + "_" + fchName + ".xml";

                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileNameEnvioSII, false, Encoding.GetEncoding("ISO-8859-1")))
                                {
                                    file.WriteLine(enviox509SII);
                                }

                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileNameEnvioCliente, false, Encoding.GetEncoding("ISO-8859-1")))
                                {
                                    file.WriteLine(enviox509Cliente);
                                }
                                
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(""+ex);

                            }
                            finally
                            {
                               
                            }

                        }
                        else
                        {

                            Pdf docpdf = new Pdf();

                            String fileNamePDF = @"C:/AdmToSii/file/pdf/DTE_" + docLectura.RUTEmisor + "_" + docLectura.TipoDTE + "_" + docLectura.Folio + "_" + fchName + ".pdf";
                            docpdf.OpenPdf(TimbreElec, docLectura, fileNamePDF, " ");
                            log.addLog("Crea PDF Trib TipoDTE :" + docLectura.TipoDTE + " Folio :" + docLectura.Folio, "OK");

                            String fileNamePDFCed = @"C:/AdmToSii/file/pdf/DTE_" + docLectura.RUTEmisor + "_" + docLectura.TipoDTE + "_" + docLectura.Folio + "_" + fchName + "CEDIBLE.pdf";

                            if (docLectura.TipoDTE == 33 || docLectura.TipoDTE == 34)
                            {
                                docpdf.OpenPdf(TimbreElec, docLectura, fileNamePDFCed, "CEDIBLE");
                            }

                            if (docLectura.TipoDTE == 52)
                            {
                                docpdf.OpenPdf(TimbreElec, docLectura, fileNamePDFCed, "CEDIBLE CON SU FACTURA");
                            }
                            log.addLog("Crea PDF C TipoDTE :" + docLectura.TipoDTE + " Folio :" + docLectura.Folio, "OK");

                            // para otro tipo de impresion
                            // FuncionesComunes f = new FuncionesComunes();
                            // f.PrintDocument(@"CutePDF Writer", @"C:/AdmToSii/file/pdf/DTE_" + docLectura.RUTEmisor + "_" + docLectura.TipoDTE + "_" + docLectura.Folio + "_" + fchName + ".pdf");

                            //Imprime pdf

                            String fileNamePDFPrint = @"C:/AdmToSii/file/pdf/PRINT_" + docLectura.RUTEmisor + "_" + docLectura.TipoDTE + "_" + docLectura.Folio + ".pdf";
                            docpdf.OpenPdfPrint(TimbreElec, docLectura, fileNamePDFPrint);
                            log.addLog("Crea PDF PRINT TipoDTE :" + docLectura.TipoDTE + " Folio :" + docLectura.Folio, "OK");



                            fc.printPdf(fileNamePDFPrint, Impresora);

                            log.addLog("IMPRIME TipoDTE :" + docLectura.TipoDTE + " Folio :" + docLectura.Folio, "OK");

                            // Agrega el DTE timbrado al paquete

                            paquete = paquete + docXmlSign;

                            //Estrae el rut del emisor de la primera factura del paquete
                            if (i == 0) firsRut = docLectura.RUTEmisor;
                            i++;


                        
                        // Firma Paquete unitario   
                        String envioCliente = xml.creaEnvio(paquete, docLectura.RUTEmisor, docLectura.RUTRecep, tipos, docLectura.RutEnvia, docLectura.FchResol, docLectura.RUTRecep, docLectura.NumResol);

                        String envioSII = xml.creaEnvio(paquete, docLectura.RUTEmisor, docLectura.RUTRecep, tipos, docLectura.RutEnvia, docLectura.FchResol, "", docLectura.NumResol);

                        X509Certificate2 cert = FuncionesComunes.obtenerCertificado(docLectura.NombreCertificado);

                        String enviox509SII = xml.firmarDocumento(envioSII, cert);
                        String enviox509Cliente = xml.firmarDocumento(envioCliente, cert);

                        log.addLog("FIRMA ENVIO TipoDTE :" + docLectura.TipoDTE + " Folio :" + docLectura.Folio, "OK");

                        enviox509SII = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\r\n" + enviox509SII;
                        enviox509Cliente = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\r\n" + enviox509Cliente;


                        String fileNameEnvioSII = @"C:/AdmToSii/file/xml/enviounitario/EnvioUnit_" + docLectura.RUTEmisor + "_" + docLectura.Folio + "_" + fchName + ".xml";

                        String fileNameEnvioCliente = @"C:/AdmToSii/file/xml/enviounitario/EnvioUnitCliente_" + docLectura.RUTEmisor + "_" + docLectura.Folio + "_" + fchName + ".xml";

                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileNameEnvioSII, false, Encoding.GetEncoding("ISO-8859-1")))
                        {
                            file.WriteLine(enviox509SII);
                        }

                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileNameEnvioCliente, false, Encoding.GetEncoding("ISO-8859-1")))
                        {
                            file.WriteLine(enviox509Cliente);
                        }
                    }



                        // *************  Envía json a server
                        //Connect conn = new Connect();
                        String trib = @"DTE_" + docLectura.RUTEmisor + "_" + docLectura.TipoDTE + "_" + docLectura.Folio + "_" + fchName + ".pdf";
                        String envU = @"EnvioUnit_" + docLectura.RUTEmisor + "_" + docLectura.Folio + "_" + fchName + ".xml";
                        String envC = @"EnvioUnitCliente_" + docLectura.RUTEmisor + "_" + docLectura.Folio + "_" + fchName + ".xml";
                        String envF = @"DTE_" + docLectura.RUTEmisor + "_" + docLectura.TipoDTE + "_" + docLectura.Folio + "_" + fchName + ".xml";
                        String ced = String.Empty;
                        if (docLectura.TipoDTE != 61 && docLectura.TipoDTE != 56)
                        {
                            ced = @"DTE_" + docLectura.RUTEmisor + "_" + docLectura.TipoDTE + "_" + docLectura.Folio + "_" + fchName + "CEDIBLE.pdf";
                        }

                        // Envia al SII

                       string recepcionDteXml = conSii.send(docLectura.RutEnvia, docLectura.RUTEmisor, envU);
                       envioM.tipoDte = docLectura.TipoDTE;
                       envioM.folio = docLectura.Folio;
                       envioM.fchEmis = DateTime.Parse(docLectura.FchEmis);
                       envioM.mntTotal = docLectura.MntTotal;
                       envioM.CdgSIISucur = docLectura.CdgSIISucur;
                       envioM.estado = funcComunes.getStatus(recepcionDteXml);
                       envioM.envioXml = envU;
                       envioM.recepcionDteXml = recepcionDteXml;
                       envioM.trackId = funcComunes.getTrackId(recepcionDteXml);
                       envioM.save(envioM);
                       
                       
                        //envia documentos al core 
                        //conn.sendInvoice(docLectura, trib, ced, envU, envC, envF, "S");
                        // *************  Envía json a server
                        //log.addLog("Envia CORE TipoDTE :" + docLectura.TipoDTE + " Folio :" + docLectura.Folio, "OK");
                        // ************  Crea regsitro del ultimo dte
                        // UltimoDteSqlModel uDTE = new UltimoDteSqlModel();
                        //uDTE.addUltmoDte(docLectura);

                    }
                }
                if (j == printerList.Count()) { j = 0; }
                fileAdm.buscaXmlProveedor();
            }
            Console.WriteLine("ProcessIat thread: terminating gracefully.");
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }

        private volatile bool _shouldStop;

        public void StartProcessIat()
        {
            // Create the thread object. This does not start the thread.

            Thread processIatThread = new Thread(DoProcessIat);

            // Start the worker thread.
            processIatThread.Start();
            Console.WriteLine("main thread: Starting ProcessIat thread...");

            // Loop until worker thread activates. 
            while (!processIatThread.IsAlive) ;


        }

        public void StopProcessIat()
        {

            RequestStop();

            Console.WriteLine("main thread: ProcessIat thread has terminated.");

        }


    }
}
