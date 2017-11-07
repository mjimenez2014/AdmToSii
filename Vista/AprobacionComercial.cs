using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using System.Security.Cryptography.X509Certificates;

namespace Vista
{
   public class AprobacionComercial
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
            xml = "<RespuestaDTE xmlns=\"http://www.sii.cl/SiiDte\" xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" version=\"1.0\" xsi:schemaLocation=\"http://www.sii.cl/SiiDte RespuestaEnvioDTE_v10.xsd\">\r\n"
	             +"<Resultado ID=\"ResultadoDTE\">\r\n"
		         +"<Caratula version=\"1.0\">\r\n"
			     +"<RutResponde>"+empresa.RutEmisor+"</RutResponde>\r\n"
			     +"<RutRecibe>88888888-8</RutRecibe>\r\n"
                 + "<IdRespuesta>1</IdRespuesta>\r\n"
            + "<NroDetalles>2</NroDetalles>\r\n"
            + "<TmstFirmaResp>2014-12-04T18:20:00</TmstFirmaResp>\r\n"
            + "</Caratula>\r\n"
		    +"<ResultadoDTE>"
            + "<TipoDTE>33</TipoDTE>\r\n"
            + "<Folio>52099</Folio>\r\n"
            + "<FchEmis>2016-08-26</FchEmis>\r\n"
            + "<RUTEmisor>88888888-8</RUTEmisor>\r\n"
            + "<RUTRecep>"+empresa.RutEmisor+"</RUTRecep>\r\n"
            + "<MntTotal>2533</MntTotal>\r\n"
            + "<CodEnvio>535549</CodEnvio>\r\n"
            + "<EstadoDTE>0</EstadoDTE>\r\n"
            + "<EstadoDTEGlosa>DTE Aceptado OK</EstadoDTEGlosa>\r\n"
            + "</ResultadoDTE>\r\n"
            + "</Resultado>\r\n"
            + "</RespuestaDTE>\r\n";

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
