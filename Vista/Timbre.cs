using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Modelo;

namespace Vista
{
    class Timbre
    {
        public void CreaTimbre(String dd)
        {
            BarcodePDF417 pdf417 = new BarcodePDF417();
            pdf417.Options= BarcodePDF417.PDF417_USE_ASPECT_RATIO;
            pdf417.ErrorLevel = 8;
            pdf417.Options = BarcodePDF417.PDF417_FORCE_BINARY;
            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            byte[] isoBytes = iso.GetBytes(dd);
            pdf417.Text = isoBytes;
            System.Drawing.Bitmap imagen = new Bitmap(pdf417.CreateDrawingImage(Color.Black, Color.White));
            imagen.Save("Timbre.jpg");
            
        }
    }
}
