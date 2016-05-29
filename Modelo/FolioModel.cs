using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace Modelo
{
  public  class FolioModel
    {
      BaseDato bd = new BaseDato();

        public String rut {get;set;}
        public String rsnsocial{get;set;}
        public Int32 tipoDte{get;set;}
        public Int32 folioSgte { get; set; }
        public Int32 folioIni{get;set;}
        public Int32 folioFin{get;set;}
        public String fecha{get;set;}
        public String rango { get; set; }



        public void incrementaSgte(String tDte, String rutEmisor)
        {
            try
            {
                SQLiteConnection myConn = bd.ConnectSqlite();
                myConn.Open();

                string sql = "UPDATE folio set folioSgte = folioSgte+1" +
                                "WHERE tipoDte = "+tDte+" and rut ='"+ rutEmisor +"';";

                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                command.ExecuteNonQuery();

                myConn.Close();
            }
            catch (Exception empUpdate)
            {
                Console.WriteLine("ERROR: {0}" + empUpdate.ToString());
               // MessageBox.Show("ERROR: {0}" + empUpdate.ToString());
            }


        }

        public FolioModel getFolio(int tDte, String rutEmisor)
        {
            FolioModel f = new FolioModel();
            try
            {
                SQLiteConnection myConn =bd.ConnectSqlite();
                myConn.Open();

                string sql = "select * from folio where tipoDte = "+tDte+" and rut ='"+ rutEmisor +"' order by fch;";
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    f.rut = reader["rut"].ToString();
                    f.rsnsocial = reader["rsnsocial"].ToString();
                    f.tipoDte = Int32.Parse(reader["tipoDte"].ToString());
                    f.folioIni = Int32.Parse(reader["folioIni"].ToString());
                    f.folioFin = Int32.Parse(reader["folioFin"].ToString());
                    f.folioSgte = Int32.Parse(reader["folioSgte"].ToString());
                    f.fecha = reader["fecha"].ToString();
                    f.rango = reader["rango"].ToString();
                myConn.Close();
                return f;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.ToString());
                return f;
            }
        }
    }
}
