using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace Modelo
{
  public  class TipoTrasladoModel
    {
      BaseDato bd = new BaseDato();

      public String getTipoTrasXCod(int idTras)
     {
         String tipotraslado = String.Empty;

                SQLiteConnection myConn = bd.ConnectSqlite();
                myConn.Open();

                string sql = "select * from tipotraslado where id = " + idTras;
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tipotraslado = reader.GetString(reader.GetOrdinal("nombre"));
                }
         return tipotraslado;
     }
    }
}
