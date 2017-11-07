using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using System.Security.Cryptography.X509Certificates;

namespace Vista
{
   public  class ReciboMercaderia
    {
        EmpresaModel empresa = new EmpresaModel();
        Firmador firmador = new Firmador();
        DateTime thisDay = DateTime.Now;  
       public void creaXml()
       {
           empresa = empresa.getEmpresa();
           X509Certificate2 cert = FuncionesComunes.obtenerCertificado(empresa.NomCertificado);
           string xml = string.Empty;
           String fch_firmado = String.Format("{0:yyyyMMdd_HHmmss}", thisDay);

         xml = 
               "<Recibo version=\"1.0\">\r\n"
              + "<DocumentoRecibo ID=\"T33\">\r\n"
              + "<TipoDoc>33</TipoDoc>\r\n"
              + "<Folio>52099</Folio>\r\n"
              + "<FchEmis>2016-08-26</FchEmis>\r\n"
              + "<RUTEmisor>88888888-8</RUTEmisor>\r\n"
              + "<RUTRecep>"+empresa.RutEmisor+"</RUTRecep>\r\n"
              + "<MntTotal>2533</MntTotal>\r\n" //TODO
              + "<Recinto>Bodega Central</Recinto>\r\n"
              + "<RutFirma>12891016-6</RutFirma>\r\n"
              + "<Declaracion>El acuse de recibo que se declara en este acto, de acuerdo a lo dispuesto en la letra b) del Art. 4, y la letra c) del Art. 5 de la Ley 19.983, acredita que la entrega de mercaderias o servicio(s) prestado(s) ha(n) sido recibido(s).</Declaracion>\r\n"
              + "<TmstFirmaRecibo>2015-03-31T11:00:00</TmstFirmaRecibo>\r\n"
              + "</DocumentoRecibo >\r\n"
              + "</Recibo>\r\n";

         String xmlMercaderia = firmador.firmarDocumento(xml, cert);


         string xmlMercaderiaFirmado = string.Empty;
         xmlMercaderiaFirmado = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\r\n" +
                    "<EnvioRecibos xmlns=\"http://www.sii.cl/SiiDte\" xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\" version=\"1.0\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.sii.cl/SiiDte file:///C:/schema_InterMerca/EnvioRecibos_v10.xsd\">\r\n" +
                    "<SetRecibos ID=\"Recibo\">\r\n" +
                    "<Caratula version=\"1.0\">\r\n" +
                    "<RutResponde>"+empresa.RutEmisor+"</RutResponde>\r\n" +
                    "<RutRecibe>88888888-8</RutRecibe>\r\n" +
                    "<TmstFirmaEnv>2016-03-25T10:50:00</TmstFirmaEnv>\r\n" +
                     "</Caratula>\r\n" +
                     xmlMercaderia +
                    "</SetRecibos></EnvioRecibos>\r\n";

         String xmlFirmado = firmador.firmarDocumento(xmlMercaderiaFirmado, cert);
         xmlFirmado = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\r\n" + xmlFirmado; 
         String fileNameEnvio = @"C:\AdmToSii\file\xml\proveedores\respuestaDte\NombredeArchivo" + fch_firmado + "Firmado.xml";
         using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileNameEnvio, false, Encoding.GetEncoding("ISO-8859-1")))
         {
             file.WriteLine(xmlFirmado);
         }

       }

    }
}
