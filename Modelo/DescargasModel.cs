using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace Modelo
{
   public class DescargasModel
    {
       BaseDato bd = new BaseDato();
       public string uid { get; set; }
       public string nomArchivo { get; set; }

       public void save(DescargasModel descargaModel)
       {
           try
           {
               SQLiteConnection sqliteConn = new SQLiteConnection();
               sqliteConn = bd.ConnectSqlite();

               string sql = "INSERT INTO descargas("
                   + "uid,\"nomArchivo\")"
                   + " VALUES ('"
                   + descargaModel.uid + "','"
                   + descargaModel.nomArchivo + "'"
                   + ");";
               SQLiteCommand command = new SQLiteCommand(sql, sqliteConn);
               command.ExecuteNonQuery();
               sqliteConn.Close();


           }
           catch (SQLiteException ex)
           {
               throw new Exception("Error" + ex.Message);
           }
       }

       public string exist(string uid)
       {
           string exist = "False";
           try
           {
               string stringcon = string.Empty;
               SQLiteConnection sqliteConn = new SQLiteConnection();
               sqliteConn = bd.ConnectSqlite();
               string sql = "SELECT * FROM descargas where uid = '" + uid + "'";
               SQLiteCommand command = new SQLiteCommand(sql, sqliteConn);
               SQLiteDataReader reader = command.ExecuteReader();
               if (reader.HasRows != false)
               {
                   exist = "True";
               }
               sqliteConn.Close();
           }
           catch (SQLiteException ex)
           {
              throw new Exception("Error" + ex.Message);
           }

           return exist;
       }

    }
}
