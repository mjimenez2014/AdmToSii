using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace Modelo
{
   public class EmpresaModel
    {
       BaseDato bd = new BaseDato();
        // Rut de la empresa
        public String RutEmisor { get; set; } 
        // Razon social de la empresa
        public String RznSoc { get; set; }
        //Giro de la Empresa
        public String GiroEmis { get; set; }
        //Telefonos de la empresa
        public String Telefono { get; set; }
        //Correo de la empresa
        public String CorreoEmisor { get; set; }
        // Actividad economica de la empresa
        public String Acteco { get; set; }
        //Codigo de sucursal de la empresa
        public String CdgSIISucur { get; set; }
        //Dirección de la casa matriz
        public String DirMatriz { get; set; }
        //Ciudad de Origen de la sucursal
        public String CiudadOrigen { get; set; }
        // Comuna de origen de la sucursal
        public String CmnaOrigen { get; set; }
        // Sucursal del SII
        public String SucurSII { get; set; }
        // Nombre del Certificado Electronico
        public String NomCertificado { get; set; }
        // Nombre Sucursal del Emisor 
        public String SucurEmisor { get; set; }
        // Direccion de la Sucursal de origen
        public String DirOrigen { get; set; }
        //Fecha de Resolución de la empresa
        public String FchResol { get; set; }
        // Rut del Certificado
        public String RutCertificado { get; set; }
        // Numero de Resolución
        public String NumResol { get; set; }
        // Estado de la condiciónd e entrega en pdf
        public String CondEntrega { get; set; }
        // Url Del Core
        public String UrlCore { get; set; }
        // condición para la impresion de documentos
        public string PrnTwoCopy { get; set; }
        // Condición para imprimir montos netos 
        public string PrnMtoNeto { get; set; }
        // condición de impresión thermica o PDF
        public string PrnThermal { get; set; }
        // condición de impresión thermica o PDF
        public string Certificacion { get; set; }




        public EmpresaModel getEmpresa()
        {
            EmpresaModel empresa = new EmpresaModel();

            SQLiteConnection myConn = bd.ConnectSqlite();

            string sql = "select * from empresa";
            SQLiteCommand command = new SQLiteCommand(sql, myConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                empresa.RutEmisor = reader["RutEmisor"].ToString();
                empresa.RznSoc = reader["RznSoc"].ToString();
                empresa.GiroEmis = reader["GiroEmis"].ToString();
                empresa.Telefono = reader["Telefono"].ToString();
                empresa.CorreoEmisor = reader["CorreoEmisor"].ToString();
                empresa.Acteco = reader["Acteco"].ToString();
                empresa.CdgSIISucur = reader["CdgSIISucur"].ToString();
                empresa.DirMatriz = reader["DirMatriz"].ToString();
                empresa.CiudadOrigen = reader["CiudadOrigen"].ToString();
                empresa.CmnaOrigen = reader["CmnaOrigen"].ToString();
                empresa.DirOrigen = reader["DirOrigen"].ToString();
                empresa.SucurSII = reader["SucurSII"].ToString();
                empresa.NomCertificado = reader["NomCertificado"].ToString();
                empresa.SucurEmisor = reader["SucurEmisor"].ToString();
                empresa.FchResol = reader["FchResol"].ToString();
                empresa.RutCertificado = reader["RutCertificado"].ToString();
                empresa.NumResol = reader["NumResol"].ToString();
                empresa.CondEntrega = reader["CondEntrega"].ToString();
                empresa.UrlCore = reader["UrlCore"].ToString();
                empresa.PrnTwoCopy = reader["PrnTwoCopy"].ToString();
                empresa.PrnMtoNeto = reader["PrnMtoNeto"].ToString();
                empresa.PrnThermal = reader["PrnThermal"].ToString();
            }
            myConn.Close();
            return empresa;
        }
    }
}
