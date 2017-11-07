using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using Modelo;


namespace Vista
{
    public class RespuestaEnvioDte
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
 
               xml = "<RespuestaDTE xmlns=\"http://www.sii.cl/SiiDte\" xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" version=\"1.0\" xsi:schemaLocation=\"http://www.sii.cl/SiiDte RespuestaEnvioDTE_v10.xsd\">\n"
                +"<Resultado ID=\"RecepcionEnvio\">\n"
                + "<Caratula version=\"1.0\">"
                + "<RutResponde>"+empresa.RutEmisor+"</RutResponde>"
                + "<RutRecibe>88888888-8</RutRecibe>"
                + "<IdRespuesta>1</IdRespuesta>"
                + "<NroDetalles>2</NroDetalles>"
                + "<TmstFirmaResp>2016-03-23T16:40:00</TmstFirmaResp>"
                + "</Caratula>"
                + "<RecepcionEnvio>"
                + "<NmbEnvio>ENVIO_DTE_684852.xml</NmbEnvio>"//
                + "<FchRecep>2014-12-04T16:39:00</FchRecep>"
                + "<CodEnvio>1</CodEnvio>"
                + "<EnvioDTEID>SetDoc</EnvioDTEID>"
                + "<EstadoRecepEnv>0</EstadoRecepEnv>"
                + "<RecepEnvGlosa>Envio Recibido Conforme</RecepEnvGlosa>"
                + "<NroDTE>2</NroDTE>"
                //Foreach
                + "<RecepcionDTE>"
                + "<TipoDTE>33</TipoDTE>"
                + "<Folio>52099</Folio>" //TODO
                + "<FchEmis>2016-08-26</FchEmis>"
                + "<RUTEmisor>88888888-8</RUTEmisor>"
                + "<RUTRecep>"+empresa.RutEmisor+"</RUTRecep>"
                + "<MntTotal>2533</MntTotal>"
                + "<EstadoRecepDTE>0</EstadoRecepDTE>"
                + "<RecepDTEGlosa>DTE Aceptado OK</RecepDTEGlosa>"
                + "</RecepcionDTE>"
                //Fin Foreach
                + "<RecepcionDTE>"
                + "<TipoDTE>33</TipoDTE>"
                + "<Folio>52100</Folio>"
                + "<FchEmis>2013-06-21</FchEmis>"
                + "<RUTEmisor>88888888-8</RUTEmisor>"
                + "<RUTRecep>69507000-4</RUTRecep>"
                + "<MntTotal>3723</MntTotal>"
                + "<EstadoRecepDTE>3</EstadoRecepDTE>"
                + "<RecepDTEGlosa>DTE No Recibido - Error RUT Receptor</RecepDTEGlosa>"
                + "</RecepcionDTE>"
                + "</RecepcionEnvio>"
                + "</Resultado>"
                + "</RespuestaDTE>";

           // firmo documento
          String xmlFirmado = firmador.firmarDocumento(xml, cert);
        //  xmlFirmado = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\n" + xmlFirmado; 
          String fileNameEnvio = @"C:\AdmToSii\file\xml\proveedores\respuestaDte\NombredeArchivo" + fch_firmado + "Firmado.xml";
          using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileNameEnvio, false, Encoding.GetEncoding("ISO-8859-1")))
          {
              file.WriteLine(xmlFirmado);
          }
       }

        
    }
}
