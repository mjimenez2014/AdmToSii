using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using System.Xml.Linq;
using System.Net;
using System.IO;
using System.Xml;

namespace Vista
{
   class ConnectSii
    {
       FuncionesComunes funcComunes = new FuncionesComunes();
       public string send(string rutEmisor, string rutEmpresa, string nombreArchivo)


       {
           #region PREPARACION
           string recepcionDteXml = string.Empty;

           ////
           //// Prepare  los paramentros para utilizarlos
           //// en el envio del documento.
           rutEmisor = rutEmisor.Replace("-", string.Empty);
           rutEmpresa = rutEmpresa.Replace("-", string.Empty);


           ////
           //// Recupere el cuerpo y digito verificador de los 
           //// rut involucrados.
           string pRutEmisor = rutEmisor.Substring(0, (rutEmisor.Length - 1));
           string pDigEmisor = rutEmisor.Substring(rutEmisor.Length - 1);
           string pRutEmpresa = rutEmpresa.Substring(0, (rutEmpresa.Length - 1));
           string pDigEmpresa = rutEmpresa.Substring(rutEmpresa.Length - 1);
           StringBuilder secuencia = new StringBuilder();
           ////
           //// Cree el header del request a enviar al SII
           //// segun la información solicitada del SII
           secuencia.Append("--9022632e1130lc4\r\n");
           secuencia.Append("Content-Disposition: form-data; name=\"rutSender\"\r\n");
           secuencia.Append("\r\n");
           secuencia.Append(pRutEmisor + "\r\n");
           secuencia.Append("--9022632e1130lc4\r\n");
           secuencia.Append("Content-Disposition: form-data; name=\"dvSender\"\r\n");
           secuencia.Append("\r\n");
           secuencia.Append(pDigEmisor + "\r\n");
           secuencia.Append("--9022632e1130lc4\r\n");
           secuencia.Append("Content-Disposition: form-data; name=\"rutCompany\"\r\n");
           secuencia.Append("\r\n");
           secuencia.Append(pRutEmpresa + "\r\n");
           secuencia.Append("--9022632e1130lc4\r\n");
           secuencia.Append("Content-Disposition: form-data; name=\"dvCompany\"\r\n");
           secuencia.Append("\r\n");
           secuencia.Append(pDigEmpresa + "\r\n");
           secuencia.Append("--9022632e1130lc4\r\n");
           secuencia.Append("Content-Disposition: form-data; name=\"archivo\"; filename=\"" + nombreArchivo + "\"\r\n");
           secuencia.Append("Content-Type: text/xml\r\n");
           secuencia.Append("\r\n");

           ////
           //// Lea el documento xml que se va a enviar al SII
           string uri = @"C:\AdmToSii\file\xml\enviounitario\"+nombreArchivo;
           XDocument xdocument = XDocument.Load(uri, LoadOptions.PreserveWhitespace);

           // StreamReader objReader = new StreamReader(uri, System.Text.Encoding.Default, true);
           // objReader.ToString();
           // String data = objReader.ReadToEnd();

           ////
           //// Cargue el documento en el objeto secuencia
           secuencia.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\r");
           secuencia.Append(xdocument.ToString(SaveOptions.DisableFormatting));
           //secuencia.Append(data);
           secuencia.Append("--7d23e2a11301c4--\r\n");

           #endregion

           ////
           //// Aqui se configura el request que hace la solicitud al SII
           #region CONFIGURACION DE REQUEST

           ////
           //// Defina que ambiente utilizar.
           //string pUrl = "https://maullin.sii.cl/cgi_dte/UPL/DTEUpload";
           //// Certificacion "https://maullin.sii.cl/cgi_dte/UPL/DTEUpload";
           string pUrl = "https://maullin.sii.cl/cgi_dte/UPL/DTEUpload";

           ////
           //// Cree los parametros del header.
           //// Token debe ser el valor asignado por el SII
           string pMethod = "POST";
           string pAccept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg,application/vnd.ms-powerpoint, application/ms-excel,application/msword, */*";
           string pReferer = "www.lubba.cl";
           string pToken = "TOKEN={0}";

           ////
           //// Cree un nuevo request para iniciar el proceso
           HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pUrl);
           request.Method = pMethod;
           request.Accept = pAccept;
           request.Referer = pReferer;

           ////
           //// Agregar el content-type
           request.ContentType = "multipart/form-data: boundary=9022632e1130lc4";
           request.ContentLength = secuencia.Length;

           ////
           //// Defina manualmente los headers del request
           request.Headers.Add("Accept-Language", "es-cl");
           request.Headers.Add("Accept-Encoding", "gzip, deflate");
           request.Headers.Add("Cache-Control", "no-cache");
           request.Headers.Add("Cookie", string.Format(pToken, funcComunes.getToken()));//token));

           ////
           //// Defina el user agent
           request.UserAgent = "Mozilla/4.0 (compatible; PROG 1.0; Windows NT 5.0; YComp 5.0.2.4)";
           request.KeepAlive = true;

           #endregion


           ////
           //// Escritura del request
           #region ESCRIBE LA DATA NECESARIA

           ////
           //// Recupere el streamwriter para escribir la secuencia
           try
           {

               using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
               {                
                   Console.WriteLine(secuencia.ToString());
                   sw.Write(secuencia.ToString());
               }

           }
           catch (Exception ex)
           {
               ////
               //// Error en el metodo
               //// Error del formato del envio
               Console.WriteLine("Error:" + ex);


           }

           #endregion

           ////
           //// Enviar libro/dte y solicitar la respuesta del SII
           #region ENVIA Y SOLICITA RESPUESTA

           try
           {

               ////
               //// Defina donde depositar el resultado
               string respuestaSii = string.Empty;

               ////
               //// Recupere la respuesta del sii
               using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
               {
                   using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("ISO-8859-1")))
                   {
                      // Console.WriteLine(respuestaSii = sr.ReadToEnd().Trim());
                       recepcionDteXml = sr.ReadToEnd().Trim();
                   }

               }

               ////
               //// Hay respuesta?
               if (string.IsNullOrEmpty(respuestaSii))
                   throw new ArgumentNullException("Respuesta del SII es null");


               ////
               //// Interprete la respuesta del SII.
               //// respuestaSii contiene la respuesta del SII acerca del envio en formato XML


           }
           catch (Exception ex)
           {

               ////
               //// Error en el metodo
               //// No fue posible enviar o recepcionar la respuesta del SII
           }

           #endregion
           return recepcionDteXml;
       }

    }
}
