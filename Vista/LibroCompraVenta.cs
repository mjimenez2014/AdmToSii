using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Vista
{
    [XmlRoot("LibroCompraVenta")]
  public  class LibroCompraVenta
    {

        [XmlAttribute("RutEmisorLibro")]
        public string RutEmisorLibro { get; set; }

        public LibroCompraVenta getIECSinceXml(string path)
        {
            LibroCompraVenta libroCompra = new LibroCompraVenta();
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(LibroCompraVenta));
                System.IO.StreamReader sr = new System.IO.StreamReader(path);
                LibroCompraVenta libroCompras = (LibroCompraVenta)xmlSerializer.Deserialize(sr);
                libroCompra.RutEmisorLibro = libroCompras.RutEmisorLibro;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return libroCompra;

        }
    }
}
