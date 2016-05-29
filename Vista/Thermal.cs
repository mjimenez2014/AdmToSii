using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Globalization;
using Modelo;

namespace Vista

{
   public class Thermal
    {
        public DocumentoModel doc {set; get;}
        public String dd { set; get; }
        public int copias { set; get; }
        public String tipoCopia { set; get; }

        public void OpenThermal(object sender, PrintPageEventArgs ev)
        {

            String tipoCopia = String.Empty;
            String nombreDocumento = String.Empty;
            Timbre timbre1 = new Timbre();
            timbre1.CreaTimbre(this.dd);
            // Agrego un rectangulo
            Rectangle rectangulo = new Rectangle(10, 1, 260, 100);
            Pen p = new Pen(Color.Black, 5);
            ev.Graphics.DrawRectangle(p, rectangulo);
            StringFormat alignCenter = new StringFormat();
            alignCenter.Alignment = StringAlignment.Center;
            StringFormat alignRight = new StringFormat();
            alignRight.Alignment = StringAlignment.Near;
            StringFormat alignLeft = new StringFormat();
            alignLeft.Alignment = StringAlignment.Far;
            ev.Graphics.DrawRectangle(p, rectangulo);
            EmpresaModel empresa = new EmpresaModel().getEmpresa();

            switch (this.doc.TipoDTE)
            {
                case 30: nombreDocumento = "FACTURA";
                    break;
                case 33: nombreDocumento = "FACTURA ELECTRÓNICA";
                    break;
                case 34: nombreDocumento = "FACTURA NO AFECTA O EXENTA ELECTRÓNICA";
                    break;
                case 61: nombreDocumento = "NOTA DE CRÉDITO ELECTRÓNICA";
                    break;
                case 56: nombreDocumento = "NOTA DE DÉBITO ELECTRÓNICA";
                    break;
                case 52: nombreDocumento = "GUÍA DE DESPACHO ELECTRÓNICA";
                    break;

            }
            // Agrega separadores al rut

            String rutemisor = this.doc.RUTEmisor;
            rutemisor = rutemisor.Insert(2, ".");
            rutemisor = rutemisor.Insert(6, ".");

            ev.Graphics.DrawString("R.U.T.: " + rutemisor, new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Rectangle(10, 5, 260, 20), alignCenter);
            ev.Graphics.DrawString(nombreDocumento, new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Rectangle(10, 30, 260, 50), alignCenter);
            ev.Graphics.DrawString("Nº "+ this.doc.Folio, new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Rectangle(10, 60, 260, 100), alignCenter);
            ev.Graphics.DrawString(this.doc.DirRegionalSII, new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Rectangle(10, 105, 260, 20), alignCenter);
            ev.Graphics.DrawString(this.doc.RznSoc, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Rectangle(10, 130, 260, 20), alignCenter);
            ev.Graphics.DrawString(this.doc.GiroEmis, new Font("Arial", 8, FontStyle.Italic), Brushes.Black, new Rectangle(0, 150, 260, 50), alignCenter);
            int lineaCabecera = 190;
            // Datos del Emisor
            ev.Graphics.DrawString("FONOS: " + this.doc.Telefono, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, lineaCabecera, 300, 40),alignCenter);
            lineaCabecera += 15;
            ev.Graphics.DrawString("CASA MATRIZ:", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, lineaCabecera, 280, 15), alignCenter);
            lineaCabecera += 15;
            ev.Graphics.DrawString(this.doc.DirMatriz, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, lineaCabecera, 280, 30),alignCenter);
            lineaCabecera += 30; //TODO esta linea cambia segun las sucursales de la empresa
            // Agrego las sucursales
            string sucu = string.Empty;
            string[] sucuremisor = doc.SucurEmisor.Split(new char[] { ';' });
            foreach (string s in sucuremisor)
            {
                Console.WriteLine(s);
                sucu += s + "\n";
            }
            ev.Graphics.DrawString("SUCURSALES: \n" + sucu, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, lineaCabecera, 280, 65),alignCenter);
            lineaCabecera += 3 + 65;// TODO esta linea cambia segun las sucursales de la empresa
            // convierte fecha
            DateTime fechaemis = Convert.ToDateTime(this.doc.FchEmis);
            int dia = fechaemis.Day;
            string mesletra = fechaemis.ToString("MMMMM");
            int ano = fechaemis.Year;
            // Datos del Receptor          
            Rectangle recReceptor = new Rectangle(3, lineaCabecera - 1, 270, 126);
            if (doc.TipoDTE == 52)
                recReceptor.Height = 158;
            Pen p2 = new Pen(Color.Black, 1);
            ev.Graphics.DrawRectangle(p2, recReceptor);
            ev.Graphics.DrawString("Fecha: Santiago, " + dia + " de " + mesletra + " de " + ano, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(5, lineaCabecera, 300, 60));
            lineaCabecera += 13;
            ev.Graphics.DrawString("Señor(es): " + this.doc.RznSocRecep, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(5, lineaCabecera, 300, 60));
            lineaCabecera += 13;
            ev.Graphics.DrawString("Dirección: " + doc.DirRecep, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(5, lineaCabecera, 300, 60));
            lineaCabecera += 13;
            // Agrega separadores al rut
            String rutrecep = this.doc.RUTRecep;
            rutrecep = rutrecep.Insert(2, ".");
            rutrecep = rutrecep.Insert(6, ".");
            ev.Graphics.DrawString("R.U.T.: " + rutrecep, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(5, lineaCabecera, 300, 60));
            lineaCabecera += 13;
            //controla el largo de Giro 
            String giroRecep = String.Empty;
            if (doc.GiroRecep.Length <= 40)
            {
                giroRecep = doc.GiroRecep;
            }
            else
            {
                giroRecep = doc.GiroRecep.Substring(0, 35);
            }
            ev.Graphics.DrawString("Giro: " + giroRecep, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(5, lineaCabecera, 300, 60));
            lineaCabecera += 13;
            ev.Graphics.DrawString("Comuna: " + doc.CmnaRecep, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(5, lineaCabecera, 300, 60));
            lineaCabecera += 13;
            ev.Graphics.DrawString("Teléfono: " + doc.TelRecep, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(5, lineaCabecera, 300, 60));
            lineaCabecera += 13;
            ev.Graphics.DrawString("Vendedor: " + doc.CdgVendedor + " - " + doc.NomVendedor, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(5, lineaCabecera, 300, 60));
 
            if (doc.TipoDTE == 52)
            {
                string nombreTraslado = new TipoTrasladoModel().getTipoTrasXCod(doc.IndTraslado);
                lineaCabecera += 13;
                ev.Graphics.DrawString("Tipo Traslado: (" + doc.IndTraslado+") " + nombreTraslado, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(5, lineaCabecera, 300, 60));
                if (doc.IndTraslado == 5)
                {
                    lineaCabecera += 13;
                    ev.Graphics.DrawString("Bodega Origen: " + doc.BodEmis, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(5, lineaCabecera, 300, 60));
                    lineaCabecera += 13;
                    ev.Graphics.DrawString("Bodega Destino: " + doc.BodRecep + " - " + doc.NomVendedor, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(5, lineaCabecera, 300, 60));
                }
            }
            lineaCabecera += 5 + 39;

            // Titulos de columnas de detalle
            ev.Graphics.DrawString("Item", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, lineaCabecera, 29, 15));
            ev.Graphics.DrawString("Código", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(25, lineaCabecera, 280, 15));
            ev.Graphics.DrawString("Descripción", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(70, lineaCabecera, 280, 15));
            lineaCabecera += 13;
            ev.Graphics.DrawString("Cant.", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(10, lineaCabecera, 280, 15));
            ev.Graphics.DrawString("Precio", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(80, lineaCabecera, 280, 15));
            ev.Graphics.DrawString("Dscto.", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(150, lineaCabecera, 280, 15));
            ev.Graphics.DrawString("Total", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(250, lineaCabecera, 280, 15));

            ev.Graphics.DrawLine(p2, 0, lineaCabecera +15, 300, lineaCabecera+15); // linea de separacion
            lineaCabecera += 3+13;

            //--------------------------------------------- DETALLE ------------------------------------------------------------------------------
            //Captura el codigo de referencia
            String codigoreferencia = String.Empty;
            foreach (var codref in doc.Referencia)
            {
                codigoreferencia = codref.CodRef.ToString();
            }

            int next = lineaCabecera; // 30
            int linea = lineaCabecera+15; //15
            String nmbitem = String.Empty;
            foreach (var det in doc.detalle)
            {
                if (codigoreferencia == "2")
                {
                    ev.Graphics.DrawString(Convert.ToString(det.NmbItem), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(0, next, 280, 90), alignCenter);
                    linea += 30;
                }
                else
                {


                    //Numero Linea Detalle
                    ev.Graphics.DrawString(Convert.ToString(det.NroLinDet) + ") ", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, next, 25, 15));
                    //Codigo de Producto
                    ev.Graphics.DrawString(Convert.ToString(det.VlrCodigo), new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(25, next, 280, 15));
                    //controla el largo de nombre item
                    if (det.NmbItem.Length <= 40)
                    {
                        nmbitem = det.NmbItem;
                    }
                    else
                    {
                        nmbitem = det.NmbItem.Substring(0, 30);
                    }
                    if (codigoreferencia == "2")
                    {
                        nmbitem = det.NmbItem;
                    }
                    ev.Graphics.DrawString(Convert.ToString(nmbitem), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(70, next, 280, 15));
                    //Cantidad de producto mas unidad de medida
                    ev.Graphics.DrawString(Convert.ToString(det.QtyItem) + " " + Convert.ToString(det.UnmdItem), new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(10, linea, 70, 15));
                    //Precio Item
                    if (doc.PrnMtoNeto == "True")
                    {
                        ev.Graphics.DrawString("$ " + det.PrcItem.ToString("N4", CultureInfo.CreateSpecificCulture("es-ES")), new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(80, linea, 280, 15));
                    }
                    else
                    {
                        ev.Graphics.DrawString("$ " + det.PrcBruItem.ToString("N0", CultureInfo.CreateSpecificCulture("es-ES")), new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(80, linea, 280, 15));
                    }
                    // Descuento Item
                    ev.Graphics.DrawString(Convert.ToString(det.DescuentoPct), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, new Rectangle(160, linea, 280, 15));
                    //Total Linea
                    if (doc.PrnMtoNeto == "True")
                    {
                        ev.Graphics.DrawString("$ " + det.MontoItem.ToString("N0", CultureInfo.CreateSpecificCulture("es-ES")), new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, linea, 280, 15), alignLeft);
                    }
                    else
                    {
                        ev.Graphics.DrawString("$ " + det.MontoBruItem.ToString("N0", CultureInfo.CreateSpecificCulture("es-ES")), new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, linea, 280, 15), alignLeft);
                    }

                    ev.Graphics.DrawLine(p2, 0, linea + 14, 300, linea + 14); // linea de separacion
                    next += 30;
                    linea += 30;
                }
            }
            
            //-------------------------------------------Referencias---------------------------------------------------
            int nroLinRef = 0;
            foreach (var x in doc.Referencia)
            {
                nroLinRef = x.NroLinRef; 
            }

            if (nroLinRef != 0 )
            {
                ev.Graphics.DrawString("***REFERENCIAS A OTROS DOCUMENTOS***", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, linea, 280, 15), alignCenter);
                linea += 15;
                ev.Graphics.DrawString("Tipo doc", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, linea, 29, 15));
                ev.Graphics.DrawString("Folio", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(180, linea, 280, 15));
                linea += 15;
                ev.Graphics.DrawString("Fecha", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(10, linea, 280, 15));
                ev.Graphics.DrawString("Razón Ref.", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(100, linea, 280, 15));
                ev.Graphics.DrawLine(p2, 0, linea + 15, 300, linea + 15); // linea de separacion
                linea += 20;
                //"Tipo de Documento", "Folio", "Fecha", "Razón Referancia"
                foreach (var b in doc.Referencia)
                {
                    if (b.NroLinRef == 0)
                    {
                    }
                    else
                    {
                        String tipoDocRef = String.Empty;

                        if (b.TpoDocRef == "SET")
                        {
                            tipoDocRef = "SET";
                        }
                        else
                        {

                            switch (Convert.ToInt32(b.TpoDocRef))
                            {
                                case 30: tipoDocRef = "FACTURA";
                                    break;
                                case 33: tipoDocRef = "FACTURA ELECTRÓNICA";
                                    break;
                                case 34: tipoDocRef = "FACTURA NO AFECTA O EXENTA ELECTRÓNICA";
                                    break;
                                case 61: tipoDocRef = "NOTA DE CRÉDITO ELECTRÓNICA";
                                    break;
                                case 56: tipoDocRef = "NOTA DE DÉBITO ELECTRÓNICA";
                                    break;
                                case 52: tipoDocRef = "GUÍA DESPACHO ELECTRÓNICA";
                                    break;
                                case 35: tipoDocRef = "BOLETA";
                                    break;

                            }
                        }
                        // datos
                        ev.Graphics.DrawString(tipoDocRef, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, linea, 160, 15));
                        ev.Graphics.DrawString(b.FolioRef, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(180, linea, 280, 15));
                        linea += 15;
                        ev.Graphics.DrawString(b.FchRef, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(10, linea, 280, 15));
                        ev.Graphics.DrawString(b.RazonRef, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(100, linea, 280, 15));
                        linea += 30;
                    }
                }


            }

            //-------------------------------------------TOTALES---------------------------------------------------

            int total = linea + 50;
            //Descuento Global
            foreach (var dcto in doc.dscRcgGlobal)
            {
            ev.Graphics.DrawString("Descuento:", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(130, linea, 280, 15));
            ev.Graphics.DrawString(dcto.ValorDR + " %", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, linea, 280, 15), alignLeft);
            }
            linea += 15;
            ev.Graphics.DrawString("Sub Total:", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(130, linea, 280, 15));
            ev.Graphics.DrawString("$ " + doc.MntNeto.ToString("N0", CultureInfo.CreateSpecificCulture("es-ES")), new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, linea, 280, 15), alignLeft);
            linea += 15;
            ev.Graphics.DrawString("Monto Exento:", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(130, linea, 280, 15));
            ev.Graphics.DrawString("$ " + doc.MntExe.ToString("N0", CultureInfo.CreateSpecificCulture("es-ES")), new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, linea, 280, 15), alignLeft);
            linea += 15;
            ev.Graphics.DrawString("I.V.A "+ doc.TasaIVA +"%:", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(130, linea, 280, 15));
            ev.Graphics.DrawString("$ " + doc.IVA.ToString("N0", CultureInfo.CreateSpecificCulture("es-ES")), new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, linea, 280, 15), alignLeft);
            linea += 15;
            // si los impuestos adicionales vienen
            if (doc.imptoReten != null)
            { 
                // agrega Porcentage Impuesto Adicional
                String prcimpadic = String.Empty;
                foreach (var prc in doc.imptoReten)
                {
                    prcimpadic = Convert.ToString(prc.TasaImp);

            ev.Graphics.DrawString("Imp. Adic. (" + prcimpadic + "%):  ", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(130, linea, 280, 15));
            // agrega Monto Impuesto Adicional
            ev.Graphics.DrawString("$ " + prc.MontoImp.ToString("N0", CultureInfo.CreateSpecificCulture("es-ES")), new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, linea, 280, 15), alignLeft);
            linea += 15;
                }
            }

            ev.Graphics.DrawString("Total:", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(130, linea, 280, 15));
            ev.Graphics.DrawString("$ " + doc.MntTotal.ToString("N0", CultureInfo.CreateSpecificCulture("es-ES")), new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, linea, 280, 15), alignLeft);
            linea += 30;
 //-----------------------------------------------------------Acuse Recibo --------------------------------------------------------------------------------------------
            Rectangle rectAcuseRecibo = new Rectangle(0, linea, 280, 100);
            linea += 2;
            ev.Graphics.DrawString("Nombre:", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, linea, 280, 15));
            linea += 30;
            ev.Graphics.DrawString("R.U.T.:", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, linea, 280, 15));
            ev.Graphics.DrawString("Firma:", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(150, linea, 280, 15));
            linea += 30;
            ev.Graphics.DrawString("Fecha:", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, linea, 280, 15));
            ev.Graphics.DrawString("Recinto:", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(120, linea, 280, 15));
            linea += 30;
            if (this.copias == 2)
            {
                ev.Graphics.DrawLine(p2, 2, linea, 280, linea); // linea de separacion
                linea += 2;
                ev.Graphics.DrawString("El acuse de recibo que se declara en este acto, de acuerdo a lo dispuesto en la letra b) del Art. 4º y letra c) del Art. 5º de la ley 19383, acredita la entrega de mercaderia(s) o servicio(s).", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, linea, 280, 60), alignCenter);
                rectAcuseRecibo.Height = 155;
                linea += 70;
            }
            ev.Graphics.DrawRectangle(p2, rectAcuseRecibo);
            linea += 15;
            //Condición de entrega
            if (doc.CondEntrega == "True" && doc.TipoDTE == 33)
            {
                Rectangle rectCondicionEntrega = new Rectangle(0, linea, 280, 50);
                Pen penCondEntr = new Pen(Color.Black, 1);
                ev.Graphics.DrawRectangle(penCondEntr, rectCondicionEntrega);
                ev.Graphics.DrawString("Condición Entrega:\n  ___ Inmediato    ___ Retiro    ___ Despacho", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, linea + 5, 280, 60), alignCenter);
                linea += 55;
            }

            //Timbre
            Image i = Image.FromFile(@"Timbre.jpg");
            ev.Graphics.DrawImage(i , new Rectangle(0, linea, 275, 123));
            linea += 130;
            ev.Graphics.DrawString("Timbre Electronico S.I.I.", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, linea, 280, 15), alignCenter);
            linea += 15;
            ev.Graphics.DrawString("Resolución Ex. SII Nº "+ empresa.NumResol+" del "+Convert.ToDateTime(empresa.FchResol).ToString("dd-MM-yyyy").Replace("-","/")+"", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, linea, 280, 15),alignCenter);
            linea += 15;
            ev.Graphics.DrawString("verifique documento:", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, linea, 280, 15),alignCenter);
            linea += 15;
            ev.Graphics.DrawString("www.sii.cl", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, linea, 280, 15), alignCenter);
            linea += 15;
            ev.Graphics.DrawString(this.tipoCopia, new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(0, linea, 280, 15), alignLeft);
            linea += 15;
            i.Dispose();
            ev.Graphics.Dispose();
            ev.HasMorePages = false;
        }


        	
    }
}
