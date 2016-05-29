using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Drawing.Printing;
using Modelo;
using System.Xml;
using System.Security.Cryptography.Xml;



namespace Vista
{
    public class FuncionesComunes
    {
        BaseDato bd = new BaseDato();
            static bool verbose = false;

            public static RSACryptoServiceProvider crearRsaDesdePEM(string base64)
            {

                ////
                //// Extraiga de la cadena los header y footer
                base64 = base64.Replace("-----BEGIN RSA PRIVATE KEY-----", string.Empty);
                base64 = base64.Replace("-----END RSA PRIVATE KEY-----", string.Empty);

                ////
                //// el resultado que se encuentra en base 64 cambielo a
                //// resultado string
                byte[] arrPK = Convert.FromBase64String(base64);

                ////
                //// obtenga el Rsa object a partir de
                return DecodeRSAPrivateKey(arrPK);

            }

            public static RSACryptoServiceProvider DecodeRSAPrivateKey(byte[] privkey)
            {
                byte[] MODULUS, E, D, P, Q, DP, DQ, IQ;

                // --------- Set up stream to decode the asn.1 encoded RSA private key ------
                MemoryStream mem = new MemoryStream(privkey);
                BinaryReader binr = new BinaryReader(mem);  //wrap Memory Stream with BinaryReader for easy reading
                byte bt = 0;
                ushort twobytes = 0;
                int elems = 0;
                try
                {
                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                        binr.ReadByte();	//advance 1 byte
                    else if (twobytes == 0x8230)
                        binr.ReadInt16();	//advance 2 bytes
                    else
                        return null;

                    twobytes = binr.ReadUInt16();
                    if (twobytes != 0x0102) //version number
                        return null;
                    bt = binr.ReadByte();
                    if (bt != 0x00)
                        return null;


                    //------ all private key components are Integer sequences ----
                    elems = GetIntegerSize(binr);
                    MODULUS = binr.ReadBytes(elems);

                    elems = GetIntegerSize(binr);
                    E = binr.ReadBytes(elems);

                    elems = GetIntegerSize(binr);
                    D = binr.ReadBytes(elems);

                    elems = GetIntegerSize(binr);
                    P = binr.ReadBytes(elems);

                    elems = GetIntegerSize(binr);
                    Q = binr.ReadBytes(elems);

                    elems = GetIntegerSize(binr);
                    DP = binr.ReadBytes(elems);

                    elems = GetIntegerSize(binr);
                    DQ = binr.ReadBytes(elems);

                    elems = GetIntegerSize(binr);
                    IQ = binr.ReadBytes(elems);

                    Console.WriteLine("showing components ..");
                    if (verbose)
                    {
                        showBytes("\nModulus", MODULUS);
                        showBytes("\nExponent", E);
                        showBytes("\nD", D);
                        showBytes("\nP", P);
                        showBytes("\nQ", Q);
                        showBytes("\nDP", DP);
                        showBytes("\nDQ", DQ);
                        showBytes("\nIQ", IQ);
                    }

                    // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                    CspParameters CspParameters = new CspParameters();
                    CspParameters.Flags = CspProviderFlags.UseMachineKeyStore;
                    RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(1024, CspParameters);
                    RSAParameters RSAparams = new RSAParameters();
                    RSAparams.Modulus = MODULUS;
                    RSAparams.Exponent = E;
                    RSAparams.D = D;
                    RSAparams.P = P;
                    RSAparams.Q = Q;
                    RSAparams.DP = DP;
                    RSAparams.DQ = DQ;
                    RSAparams.InverseQ = IQ;
                    RSA.ImportParameters(RSAparams);
                    return RSA;
                }
                catch (Exception e)
                {
                    return null;
                }
                finally
                {
                    binr.Close();
                }
            }

            private static int GetIntegerSize(BinaryReader binr)
            {
                byte bt = 0;
                byte lowbyte = 0x00;
                byte highbyte = 0x00;
                int count = 0;
                bt = binr.ReadByte();
                if (bt != 0x02)   	 //expect integer
                    return 0;
                bt = binr.ReadByte();

                if (bt == 0x81)
                    count = binr.ReadByte();    // data size in next byte
                else
                    if (bt == 0x82)
                    {
                        highbyte = binr.ReadByte();    // data size in next 2 bytes
                        lowbyte = binr.ReadByte();
                        byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                        count = BitConverter.ToInt32(modint, 0);
                    }
                    else
                    {
                        count = bt;   	 // we already have the data size
                    }

                while (binr.ReadByte() == 0x00)
                {    //remove high order zeros in data
                    count -= 1;
                }
                binr.BaseStream.Seek(-1, SeekOrigin.Current);   	 //last ReadByte wasn't a removed zero, so back up a byte
                return count;
            }

            private static void showBytes(String info, byte[] data)
            {
                Console.WriteLine("{0} [{1} bytes]", info, data.Length);
                for (int i = 1; i <= data.Length; i++)
                {
                    Console.Write("{0:X2} ", data[i - 1]);
                    if (i % 16 == 0)
                        Console.WriteLine();
                }
                Console.WriteLine("\n\n");
            }

            public static X509Certificate2 obtenerCertificado(string CN)
            {

                X509Certificate2 certificado = null;

                if (string.IsNullOrEmpty(CN) || CN.Length == 0)
                    return certificado;

                try
                {

                    X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                    store.Open(OpenFlags.ReadOnly);
                    X509Certificate2Collection Certificados1 = (X509Certificate2Collection)store.Certificates;
                    X509Certificate2Collection Certificados2 = Certificados1.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                    X509Certificate2Collection Certificados3 = Certificados2.Find(X509FindType.FindBySubjectName, CN, false);

                    ////
                    //// Si hay certificado disponible envíe el primero
                    if (Certificados3 != null && Certificados3.Count != 0)
                        certificado = Certificados3[0];

                    store.Close();


                }
                catch (Exception)
                {
                    certificado = null;
                }

                return certificado;

            }

        // Funcion Para imprimir sin adobereader
        //PrintParamter is a custom data structure to capture file related info
        public void PrintDocument(string printerName, String filename)
        {
           // if (!File.Exists(fs.FullyQualifiedName)) return;

           // var filename = fs.FullyQualifiedName ?? string.Empty;
           // printerName = printerName ?? GetDefaultPrinter(); //get your printer here

            string processArgs = " -dPrinted -dBATCH -dNOPAUSE -dNOSAFER -q -dNumCopies=1 -sDEVICE=pdfwrite -sOutputFile=%printer%" + GetDefaultPrinter() + "\" \"" + filename + "\" ";
                //string.Format("-ghostscript -copies=1 -all -printer \"{0}\" \"{1}\"", GetDefaultPrinter(), filename );
         
                var gsProcessInfo = new ProcessStartInfo
                                        {
                                          //  WindowStyle = ProcessWindowStyle.Hidden,
                                            FileName = @"C:\AdmToSii\gswin32c.exe",
                                            Arguments = processArgs
                                        };
                using (var gsProcess = Process.Start(gsProcessInfo))
                {

                //    gsProcess.WaitForExit();

                }

        }

        public string GetDefaultPrinter()
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)
                    return printer;
            }
            return string.Empty;
        }

        public void printPdf(String fileName,String impresora)
        {
            ProcessStartInfo copiaOriginal = new ProcessStartInfo();
            copiaOriginal.Arguments = "\"" + impresora + "\"";
            copiaOriginal.Verb = "printTo";
            copiaOriginal.FileName = fileName;
            copiaOriginal.CreateNoWindow = true;
            copiaOriginal.WindowStyle = ProcessWindowStyle.Hidden;

            Process p = new Process();
            p.StartInfo = copiaOriginal;
            p.Start();

            p.WaitForInputIdle();

            System.Threading.Thread.Sleep(10000);
            
            if (false == p.CloseMainWindow())
            {
                p.Kill();
            }

        }

        public String getTed(String fileName)
        {
            String ted = String.Empty;
            String xml = String.Empty;

            if (fileName != null)
            {
                StreamReader objReader = new StreamReader(fileName, System.Text.Encoding.Default, true);
                objReader.ToString();
                xml = objReader.ReadToEnd();
            }


            int start = xml.IndexOf("<TED");
            int end = xml.IndexOf("</TED>");

            int largo = (end + 6) - start;

            ted = xml.Substring(start, largo);


            return ted;
        }

        /// <summary>
        /// Firma la semilla para poder validarla en el SII
        /// </summary>
        public string FirmarSemilla(string seed, string cn)
        {

            ////
            //// Construya el cuerpo del documento en formato string.
            string resultado = string.Empty;
            string body = string.Format("<gettoken><item><Semilla>{0}</Semilla></item></gettoken>", double.Parse(seed).ToString());

            ////
            //// Recuperar el certificado para firmar el documento.
            //// utilizando el nombre del propietario del certificado o CN
            X509Certificate2 certificado = obtenerCertificado(cn);

            ////
            //// Firme la semilla.
            try
            {
                resultado = firmarDocumentoSemilla(body, certificado);

            }
            catch (Exception)
            {
                resultado = string.Empty;
            }


            ////
            //// Regrese el valor de retorno
            return resultado;


        }


        /// <summary>
        /// Recupera un determinado certificado para poder firmar un documento
        /// </summary>
        /// <param name="CN">Nombre del certificado que se busca
        /// <returns>X509Certificate2</returns>
        //// 
        //// Firma el documento xml semilla
        //// 
        public static string firmarDocumentoSemilla(string documento, X509Certificate2 certificado)
        {

            ////
            //// Cree un nuevo documento xml y defina sus caracteristicas
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = false;
            doc.LoadXml(documento);

            ////
            //// Cree el objeto XMLSignature.
            SignedXml signedXml = new SignedXml(doc);

            ////
            //// Agregue la clave privada al objeto xmlSignature.
            signedXml.SigningKey = certificado.PrivateKey;

            ////
            //// Obtenga el objeto signature desde el objeto SignedXml.
            Signature XMLSignature = signedXml.Signature;

            ////
            //// Cree una referencia al documento que va a firmarse
            //// si la referencia es "" se firmara todo el documento
            Reference reference = new Reference("");

            ////
            //// Representa la transformación de firma con doble cifrado para una firma XML  digital que define W3C.
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            ////
            //// Agregue el objeto referenciado al obeto firma.
            XMLSignature.SignedInfo.AddReference(reference);

            ////
            //// Agregue RSAKeyValue KeyInfo  ( requerido para el SII ).
            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new RSAKeyValue((RSA)certificado.PrivateKey));

            ////
            //// Agregar información del certificado x509
            keyInfo.AddClause(new KeyInfoX509Data(certificado));

            //// 
            //// Agregar KeyInfo al objeto Signature 
            XMLSignature.KeyInfo = keyInfo;

            ////
            //// Cree la firma
            signedXml.ComputeSignature();

            ////
            //// Recupere la representacion xml de la firma
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            ////
            //// Agregue la representacion xml de la firma al documento xml
            doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));

            ////
            //// Limpie el documento xml de la declaracion xml ( Opcional, pera para nuestro proceso es valido  )
            if (doc.FirstChild is XmlDeclaration)
            {
                doc.RemoveChild(doc.FirstChild);
            }

            ////
            //// Regrese el valor de retorno
            string todo = "<?xml version=\"1.0\"?>" + doc.InnerXml;
            return todo;

        }

        private string getSemilla()
        {
            CrSeedService maullin = new CrSeedService();
            string semilla = maullin.getSeed();
            Console.WriteLine("Semilla====>" + semilla);
            int start = semilla.IndexOf("<SEMILLA>") + 9;
            int end = semilla.IndexOf("</SEMILLA>");
            int largo = end - start;
            string soloSemilla = semilla.Substring(start, largo);
            return soloSemilla;
        }

        private string getSemillaFirmada()
        {
            string semillaFirmada = string.Empty;
            semillaFirmada = FirmarSemilla(getSemilla(), bd.GetNomCertificado());//Recupera el nombre de certificado
            Console.WriteLine("Semilla Firmada: " + semillaFirmada);
            return semillaFirmada;
        }

        public string getToken()
        {
            string token = string.Empty;
            GetTokenFromSeedService conToken = new GetTokenFromSeedService();
            token = conToken.getToken(getSemillaFirmada());
            int start = token.IndexOf("<TOKEN>") + 7;
            int end = token.IndexOf("</TOKEN>");
            int largo = end - start;
            string soloToken = token.Substring(start, largo);
            Console.WriteLine("TOKEN ==============> " + token+ " <==============");
            return soloToken;
        }

        public string getTrackId(string xml)
        {
            string recepcionDte = xml;
            int start = recepcionDte.IndexOf("<TRACKID>") + 9;
            int end = recepcionDte.IndexOf("</TRACKID>");
            int largo = end - start;
            string trackId = recepcionDte.Substring(start, largo);
            return trackId;
        }

        public string getStatus(string xml)
        {
            string recepcionDte = xml;
            int start = recepcionDte.IndexOf("<STATUS>") + 8;
            int end = recepcionDte.IndexOf("</STATUS>");
            int largo = end - start;
            string status = recepcionDte.Substring(start, largo);

            switch (status)
            {
                case "0": status = "Upload OK";
                    break;
                case "1": status = "El Sender no tiene permiso para enviar";
                    break;
                case "2": status = "Error en tamaño del archivo (muy grande o muy chico)";
                    break;
                case "3": status = "Archivo cortado (tamaño <> al parámetro size)";
                    break;
                case "5": status = "No está autenticado";
                    break;
                case "6": status = "Empresa no autorizada a enviar archivos";
                    break;
                case "7": status = "Esquema Invalido";
                    break;
                case "8": status = "Firma del Documento";
                    break;
                case "9": status = "Sistema Bloqueado";
                    break;
            }

            return status;
        }

        public void creadirectorios()
        {
            Directory.CreateDirectory(@"" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Iat", "unidadIat", null).ToString() + "://AdmToSii");
            Directory.CreateDirectory(@"" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Iat", "unidadIat", null).ToString() + "://AdmToSii/cafs");
            Directory.CreateDirectory(@"" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Iat", "unidadIat", null).ToString() + "://AdmToSii/cajas");
            Directory.CreateDirectory(@"" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Iat", "unidadIat", null).ToString() + "://AdmToSii/cajas/caj1");
            Directory.CreateDirectory(@"" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Iat", "unidadIat", null).ToString() + "://AdmToSii/config");
            Directory.CreateDirectory(@"" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Iat", "unidadIat", null).ToString() + "://AdmToSii/file");
            Directory.CreateDirectory(@"" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Iat", "unidadIat", null).ToString() + "://AdmToSii/file/libroCompra");
            Directory.CreateDirectory(@"" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Iat", "unidadIat", null).ToString() + "://AdmToSii/file/libroVenta");
            Directory.CreateDirectory(@"" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Iat", "unidadIat", null).ToString() + "://AdmToSii/file/pdf");
            Directory.CreateDirectory(@"" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Iat", "unidadIat", null).ToString() + "://AdmToSii/file/xml");
            Directory.CreateDirectory(@"" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Iat", "unidadIat", null).ToString() + "://AdmToSii/file/xml/enviounitario");
            Directory.CreateDirectory(@"" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Iat", "unidadIat", null).ToString() + "://AdmToSii/file/xml/proveedores");
            Directory.CreateDirectory(@"" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Iat", "unidadIat", null).ToString() + "://AdmToSii/file/xml/proveedores/respuestaDte");
            Directory.CreateDirectory(@"" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Iat", "unidadIat", null).ToString() + "://AdmToSii/file/xml/proveedores/fileprocess");
            Directory.CreateDirectory(@"" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Iat", "unidadIat", null).ToString() + "://AdmToSii/fileprocess");
            Directory.CreateDirectory(@"" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Iat", "unidadIat", null).ToString() + "://AdmToSii/migrate");









        }
    }

}
