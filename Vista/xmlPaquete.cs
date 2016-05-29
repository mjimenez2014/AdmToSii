using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.IO;
using Modelo;

namespace Vista
{
   public class xmlPaquete
    {
       BaseDato bd = new BaseDato();

        public String doc_to_xmlSii(DocumentoModel doc,String TED, String fch)
        {

            String dte = "<DTE version=\"1.0\">\n" +
                         "<Documento ID=\"F" + doc.Folio + "T" + doc.TipoDTE + "\">\n";

            String tipodespacho = "<TipoDespacho>" + doc.TipoDespacho + "</TipoDespacho>\n";
            if (doc.TipoDespacho == 0)
                tipodespacho = "";

            String indtraslado = "<IndTraslado>" + doc.IndTraslado + "</IndTraslado>\n";
            if (doc.IndTraslado == 0)
                indtraslado = "";

            String encabezado = "<Encabezado>\n" +
                "<IdDoc> \n" +
                    "<TipoDTE>" + doc.TipoDTE + "</TipoDTE>\n" +
                    "<Folio>" + doc.Folio + "</Folio> \n" +
                    "<FchEmis>" + doc.FchEmis + "</FchEmis>\n" +
                    tipodespacho +
                    indtraslado +
                "</IdDoc>\n";


            String emisor = "<Emisor>\n" +
                    "<RUTEmisor>" + doc.RUTEmisor + "</RUTEmisor>\n" +
                    "<RznSoc>" + doc.RznSoc + "</RznSoc>\n" +
                    "<GiroEmis>" + doc.GiroEmis + "</GiroEmis>\n" +
                    "<Acteco>" + doc.Acteco + "</Acteco>\n" +
                    "<CdgSIISucur>" + doc.CdgSIISucur + "</CdgSIISucur>\n" +
                    "<DirOrigen>" + doc.DirOrigen + "</DirOrigen>\n" +
                    "<CmnaOrigen>" + doc.CmnaOrigen + "</CmnaOrigen>\n" +
                    "<CiudadOrigen>" + doc.CiudadOrigen + "</CiudadOrigen>\n" +
                    "</Emisor>\n";
            //limita el largo de giro receptor
            String giroreceptor = String.Empty;
            if (doc.GiroRecep.Length < 40)
            {
                giroreceptor = doc.GiroRecep;
            }else{

            giroreceptor = doc.GiroRecep.Substring(0, 40);
            }

            if (doc.DirRecep == " ")
            {
                Console.WriteLine("ERROR EN  DATOS DEL RECEPTOR");
                doc.DirRecep = "SIN DIRECCIÓN";              
            }

            if (doc.CiudadRecep == " ")
            {
                Console.WriteLine("ERROR EN  DATOS DEL RECEPTOR");
                doc.CiudadRecep = bd.getDirLocal();
            }

            if (doc.CmnaRecep == " ")
            {
                Console.WriteLine("ERROR EN  DATOS DEL RECEPTOR");
                doc.CmnaRecep = bd.getDirLocal(); 
            }

            String rznsocrecep = doc.RznSocRecep.Replace("&", "&amp;");
            String rutrecep = doc.RUTRecep.Replace("k","K");
            String dirrecep = doc.DirRecep.Replace("#"," ");
            String cmnarecep = String.Empty;
            String ciudadrecep = String.Empty;
            
            if (doc.CmnaRecep.Length < 20)
            {
                cmnarecep = doc.CmnaRecep;
            }
            else
            {
                cmnarecep = doc.CmnaRecep.Substring(0, 20);
            }

            if (doc.CiudadRecep.Length < 20)
            {
                ciudadrecep = doc.CiudadRecep;
            }
            else
            {
                ciudadrecep = doc.CiudadRecep.Substring(0, 20);
            }

            String receptor = "<Receptor>\n" +
                    "<RUTRecep>" + rutrecep + "</RUTRecep>\n" +
                    "<RznSocRecep>" + rznsocrecep + "</RznSocRecep>\n" +
                    "<GiroRecep>" + giroreceptor + "</GiroRecep>\n" +
                    "<DirRecep>" + dirrecep + "</DirRecep>\n" +
                    "<CmnaRecep>" + cmnarecep + "</CmnaRecep>\n" +
                    "<CiudadRecep>" + ciudadrecep + "</CiudadRecep>\n" +
                "</Receptor>\n";
            
            String impreten = String.Empty;
            string impretenes = String.Empty;
            String ultipimp = String.Empty;

            if (doc.imptoReten !=null )
            {
                foreach (var imp in doc.imptoReten)
                {

                    if (ultipimp == imp.TipoImp && imp.TipoImp != "")
                        Environment.Exit(0);
                    Console.WriteLine("ERROR JSON: Impuesto Retención duplicado");
                    impreten = "<ImptoReten>\n" +
                    "<TipoImp>" + imp.TipoImp + "</TipoImp>\n" +
                    "<TasaImp>" + imp.TasaImp + "</TasaImp>\n" +
                    "<MontoImp>" + imp.MontoImp + "</MontoImp>\n" +
                    "</ImptoReten>\n";

                    if (imp.TipoImp == "" || imp.TipoImp == "0")
                        impreten = "";

                    impretenes += impreten;
                    ultipimp = imp.TipoImp;
                }
            }

               


            String mntneto = "<MntNeto>" + doc.MntNeto + "</MntNeto>\n";
            if (doc.MntNeto == 0)
                mntneto = "";
            String mntexe = "<MntExe>" + doc.MntExe + "</MntExe>\n";
            if (doc.MntExe == 0)
                mntexe = "";
            String tasaiva = "<TasaIVA>" + doc.TasaIVA + "</TasaIVA>\n";
            if (doc.TasaIVA == 0)
                tasaiva = "";
            String iva = "<IVA>" + doc.IVA + "</IVA>\n";
            if (doc.IVA == 0)
                iva = "";

            String totales = "<Totales>\n" +
                     mntneto +
                     mntexe +
                     tasaiva+
                     iva +
                    impretenes +
                     "<MntTotal>" + doc.MntTotal + "</MntTotal>\n"+
                 "</Totales>\n";
            String finencabezado = "</Encabezado>\n";

            //arma encabezado en documento
            String documento = dte + encabezado + emisor + receptor + totales + finencabezado;


            // for para crear detalles y agregarlos al documento
            String detalle;
            String firstNmbItem = String.Empty;
            int i = 0;

            foreach (var det in doc.detalle)
            {
                String indexe = "<IndExe>" + det.IndExe + "</IndExe>\n";
                if (det.IndExe == "0" || det.IndExe == "")
                    indexe = "";

                String qtyitem = "<QtyItem>" + det.QtyItem + "</QtyItem>\n";
                if (det.QtyItem == 0)
                    qtyitem = "";

                String unmditem = "<UnmdItem>" + det.UnmdItem + "</UnmdItem>\n";
                if (det.UnmdItem == "")
                    unmditem = "";

                String prcitem = "<PrcItem>" + det.PrcItem + "</PrcItem>\n";
                if (det.PrcItem == 0)
                    prcitem = "";

                //agrego el punto de float

                String conpunto = det.DescuentoPct.ToString("N1");


                String descuentopct = "<DescuentoPct>" + conpunto + "</DescuentoPct>\n";
                if (det.DescuentoPct == 0)
                    descuentopct = "";

                String descuentomonto = "<DescuentoMonto>" + det.DescuentoMonto + "</DescuentoMonto>\n";
                if (det.DescuentoMonto == 0)
                    descuentomonto = "";

                String codimpadic = "<CodImpAdic>" + det.CodImpAdic + "</CodImpAdic>\n";
                if (det.CodImpAdic == "" || det.CodImpAdic == "0")
                    codimpadic = "";

                String nmbItem = det.NmbItem.Replace("&", "&amp;"); 

 

                detalle = "<Detalle>\n" +
                "<NroLinDet>" + det.NroLinDet + "</NroLinDet>\n" +
                "<CdgItem>\n" +
                "<TpoCodigo>" + det.TpoCodigo + "</TpoCodigo>\n" +
                "<VlrCodigo>" + det.VlrCodigo + "</VlrCodigo>\n" +
                "</CdgItem>\n" +
                indexe +
                "<NmbItem>" + nmbItem + "</NmbItem>\n" +
                 qtyitem +
                 unmditem +
                 prcitem +
                 descuentopct +
                 descuentomonto +
                 codimpadic +
                "<MontoItem>" + det.MontoItem + "</MontoItem>\n" +
                "</Detalle>\n";

                documento = documento + detalle;
                if (i == 0) firstNmbItem = nmbItem.Replace("&"," ");
                i++;
            }

            // for para crear descuento global y agregarlas al documento

            String descuentoglobal = String.Empty;

            if (doc.dscRcgGlobal != null)
            {
                foreach (var desglo in doc.dscRcgGlobal)
                {
                    String nrolindr = "<NroLinDR>" + desglo.NroLinDR + "</NroLinDR>\n";
                    if (desglo.NroLinDR == 0)
                        nrolindr = "";
                    String tpomov = "<TpoMov>" + desglo.TpoMov + "</TpoMov>\n";
                    if (desglo.TpoMov == "")
                        tpomov = "";
                    String glosadr = "<GlosaDR>" + desglo.GlosaDR + "</GlosaDR>\n";
                    if (desglo.GlosaDR == "")
                        glosadr = "";
                    String tpovalor = "<TpoValor>" + desglo.TpoValor + "</TpoValor>\n";
                    if (desglo.TpoValor == "")
                        tpovalor = "";
                    String valordr = "<ValorDR>" + desglo.ValorDR + "</ValorDR>\n";
                    if (desglo.ValorDR == 0)
                        valordr = "";

                    descuentoglobal = "<DscRcgGlobal>\n" +
                        nrolindr +
                        tpomov +
                        glosadr +
                        tpovalor +
                        valordr +
                        "</DscRcgGlobal>\n";
                    if (desglo.NroLinDR == 0)
                        descuentoglobal = "";

                    documento = documento + descuentoglobal;
                }
            }




            // for para crear referencias y agregarlas al documento
            String referencia;

            if (doc.Referencia != null)
            {
                foreach (var refe in doc.Referencia)
                {
                    String indglobal = "<IndGlobal>" + refe.IndGlobal + "</IndGlobal>\n";
                    if (refe.IndGlobal == 0)
                        indglobal = "";
                    String rutotr = "<RUTOtr>" + refe.RUTOtr + "</RUTOtr>\n";
                    if (refe.RUTOtr == "" || refe.RUTOtr == null)
                        rutotr = "";
                    String codref = "<CodRef>" + refe.CodRef + "</CodRef>\n";
                    if (refe.CodRef == 0)
                        codref = "";
                    String folioref = "<FolioRef>" + refe.FolioRef + "</FolioRef>\n";
                    if (refe.FolioRef == "")
                        folioref = "";
                    String fecharef = "<FchRef>" + refe.FchRef + "</FchRef>\n";
                    if (refe.FchRef == "")
                        fecharef = "";

                    referencia = "<Referencia>\n" +
                      "<NroLinRef>" + refe.NroLinRef + "</NroLinRef>\n" +
                      "<TpoDocRef>" + refe.TpoDocRef + "</TpoDocRef>\n" +
                      indglobal +
                      folioref +
                      rutotr +
                        // "<IdAdicOtr>" + refe.IdAdicOtr +  "</IdAdicOtr> \n" +
                      fecharef +
                        codref +
                      "<RazonRef>" + refe.RazonRef + "</RazonRef>\n" +
                    "</Referencia>\n";
                    if (refe.NroLinRef == 0)

                        referencia = "";

                    documento = documento + referencia;
                }

            }

           

            String fechaFirma = "<TmstFirma>" + fch + "</TmstFirma>\r\n";
            String findocumenro = "</Documento>\r\n";

            String findte = "</DTE>\r\n";



            documento = documento+ TED + fechaFirma + findocumenro + findte;

            X509Certificate2 cert = FuncionesComunes.obtenerCertificado(doc.NombreCertificado);

            String signDte = firmarDocumento(documento, cert);

            return signDte;

        }

        public String ted_to_xmlSii(DocumentoModel doc, String fch)
        {

            // for para crear detalles y agregarlos al documento
            String ted;
            String firstNmbItem = String.Empty;

            int i = 0;

            foreach (var det in doc.detalle)
            {

                String nmbItem = det.NmbItem.Replace("&", "&amp;");

                if (i == 0) firstNmbItem = nmbItem;
                i++;
            }

            String rutrecep = doc.RUTRecep.Replace("k", "K");
            String rznsocrecep = doc.RznSocRecep.Replace("&","&amp;");
            

            if (firstNmbItem.Length > 40)
            {
                firstNmbItem = firstNmbItem.Substring(0, 39);
            }
            
            if(rznsocrecep.Length >40)
            {
                rznsocrecep = rznsocrecep.Substring(0, 39);
            }

            String inicioTed = "<TED version=\"1.0\">\r\n";
            // nodo DD
            String dd = "<DD>" +
                    "<RE>" + doc.RUTEmisor + "</RE>" +
                    "<TD>" + doc.TipoDTE + "</TD>" +
                    "<F>" + doc.Folio + "</F>" +
                    "<FE>" + doc.FchEmis + "</FE>" +
                    "<RR>" + rutrecep + "</RR>" +
                    "<RSR>" + rznsocrecep + "</RSR>" +
                    "<MNT>" + doc.MntTotal + "</MNT>" +

                    "<IT1>" + firstNmbItem + "</IT1>" +

                    getXmlFolio("CAF", doc.TipoDTE, doc.RUTEmisor) +

                    "<TSTED>" + fch + "</TSTED>" +
                "</DD>";


            String firma = "<FRMT algoritmo=\"SHA1withRSA\">" + firmaNodoDD(dd, doc.TipoDTE, doc.RUTEmisor) + "</FRMT>\r\n";
            String finTed = "</TED>\r\n";

            
            ted =   inicioTed + dd + firma + finTed;

            return ted;

        }

        public String creaEnvio(String dte, String rutEmisor, String RutReceptor, List<int> tipos, String RutEnvia, String FchResol, String rutReceptorEnvio, String nroResol )
        {


            String envio_xml = "<EnvioDTE xmlns=\"http://www.sii.cl/SiiDte\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.sii.cl/SiiDte EnvioDTE_v10.xsd\" version=\"1.0\">\r\n";
            envio_xml += "<SetDTE ID=\"SetDoc\">\r\n";
            envio_xml += "<Caratula version=\"1.0\">\r\n";
            envio_xml += "<RutEmisor>" + rutEmisor + "</RutEmisor>\r\n";
           

            envio_xml += "<RutEnvia>" + RutEnvia + "</RutEnvia>\r\n";

           
            if (rutReceptorEnvio == "") 
            {
                rutReceptorEnvio = "60803000-K";
            }
            envio_xml += "<RutReceptor>" + rutReceptorEnvio+ "</RutReceptor>\r\n";

            envio_xml += "<FchResol>" + FchResol +"</FchResol>\r\n";
            envio_xml += "<NroResol>" + nroResol + "</NroResol>\r\n";

       
            DateTime thisDay = DateTime.Now;
            String fch = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", thisDay);
            envio_xml += "<TmstFirmaEnv>"+ fch +"</TmstFirmaEnv>\r\n";



            int tipo56 = 0,
            tipo33 = 0,
            tipo61 = 0,
            tipo52 = 0,
            tipo34 = 0;

            foreach (int tipo in tipos)
            {
                switch (tipo)
                {
                    case 56: tipo56++;
                    break;
                    case 33: tipo33++;
                    break;
                    case 61: tipo61++;
                    break;
                    case 52: tipo52++;
                    break;
                    case 34: tipo34++;
                    break;
                   
                }
            }



            if (tipo56 > 0)
            {
                envio_xml += "<SubTotDTE>\r\n";
                envio_xml += "<TpoDTE>56</TpoDTE>\r\n";
                envio_xml += "<NroDTE>" + tipo56 + "</NroDTE>\r\n";
                envio_xml += "</SubTotDTE>\r\n";
            }

            if (tipo52 > 0)
            {
                envio_xml += "<SubTotDTE>\r\n";
                envio_xml += "<TpoDTE>52</TpoDTE>\r\n";
                envio_xml += "<NroDTE>" + tipo52 + "</NroDTE>\r\n";
                envio_xml += "</SubTotDTE>\r\n";
            }

            if (tipo61 > 0)
            {
                envio_xml += "<SubTotDTE>\r\n";
                envio_xml += "<TpoDTE>61</TpoDTE>\r\n";
                envio_xml += "<NroDTE>" + tipo61 + "</NroDTE>\r\n";
                envio_xml += "</SubTotDTE>\r\n";
            }

            if (tipo33 > 0)
            {
                envio_xml += "<SubTotDTE>\r\n";
                envio_xml += "<TpoDTE>33</TpoDTE>\r\n";
                envio_xml += "<NroDTE>" + tipo33 + "</NroDTE>\r\n";
                envio_xml += "</SubTotDTE>\r\n";
            }

            if (tipo34 > 0)
            {
                envio_xml += "<SubTotDTE>\r\n";
                envio_xml += "<TpoDTE>34</TpoDTE>\r\n";
                envio_xml += "<NroDTE>" + tipo34 + "</NroDTE>\r\n";
                envio_xml += "</SubTotDTE>\r\n";
            }

            

            envio_xml += "</Caratula>\r\n";

            envio_xml += dte;


            envio_xml += "</SetDTE>\r\n";
            envio_xml += "</EnvioDTE>\r\n";

            return envio_xml;

        }

        public String firmaNodoDD(String DD, int tipoDte, string rut)
        {

            string pk = getXmlFolio("RSA",tipoDte, rut);

            Encoding ByteConverter = Encoding.GetEncoding("ISO-8859-1");

            byte[] bytesStrDD = ByteConverter.GetBytes(DD);
            byte[] HashValue = new SHA1CryptoServiceProvider().ComputeHash(bytesStrDD);

            RSACryptoServiceProvider rsa = FuncionesComunes.crearRsaDesdePEM(pk);
            byte[] bytesSing = rsa.SignHash(HashValue, "SHA1");

            string FRMT1 = Convert.ToBase64String(bytesSing);

            return FRMT1;

        }

        public String getXmlFolio(String nodo, int tipo, string rut)
        {

            string nodoValue = string.Empty;

            string caf = string.Empty;
            string xmlCaf = string.Empty;
            string rsa = string.Empty;
            string line = string.Empty;
            bool cafline = false;
            bool rsaline = false;
            try
            {


                fileAdmin file = new fileAdmin();
                String cafDir = String.Empty;

                // Elegir Caf según Rut y tipo 

                switch (tipo)
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
                
                using (StreamReader sr = new StreamReader(xmlCaf))
                {

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line == "<CAF version=\"1.0\">") cafline = true;
                        if (line == "</CAF>")
                        {
                            caf += line;
                            cafline = false;
                        }

                        if (line == "<RSASK>-----BEGIN RSA PRIVATE KEY-----")
                        {
                            rsaline = true;
                            line = sr.ReadLine();
                        }
                        if (line == "-----END RSA PRIVATE KEY-----") rsaline = false;

                        if (cafline) caf += line;
                        if (rsaline) rsa += line;
                    }
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            if (nodo == "CAF") { nodoValue = caf; } else { nodoValue = rsa; }

            System.Console.WriteLine(nodoValue);

            return nodoValue;
        }

        public string firmarDocumento(string documento, X509Certificate2 certificado)
        {
            
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.LoadXml(documento);

            SignedXml signedXml = new SignedXml(doc);

            signedXml.SigningKey = certificado.PrivateKey;

            Signature XMLSignature = signedXml.Signature;

            Reference reference = new Reference("");

            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            XMLSignature.SignedInfo.AddReference(reference);

            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new RSAKeyValue((RSA)certificado.PrivateKey));

            keyInfo.AddClause(new KeyInfoX509Data(certificado));

            XMLSignature.KeyInfo = keyInfo;

            signedXml.ComputeSignature();

            XmlElement xmlDigitalSignature = signedXml.GetXml();

            doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));

            if (doc.FirstChild is XmlDeclaration)
            {
                doc.RemoveChild(doc.FirstChild);
            }

            return doc.InnerXml;

        }
    }


}
