using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace Modelo
{
   public class EnvioModel
    {
       BaseDato bd = new BaseDato();
        public Int32 tipoDte;
        public Int32 folio;
        public DateTime fchEmis;
        public Int32 mntTotal;
        public String estado;
        public String envioXml;
        public String recepcionDteXml;
        public String trackId;
        public Int32 CdgSIISucur;

        public void save(EnvioModel envioModel)
        {
            try
            {
                SQLiteConnection myConn = bd.ConnectSqlite();
               // myConn.Open();

                string sql = "INSERT INTO envio VALUES(null,'" +
                             envioModel.tipoDte + "'," +
                             envioModel.folio + ",'" +
                             envioModel.fchEmis.ToString("yyyy-MM-dd hh:MM:ss") +"'," +
                             envioModel.mntTotal + ",'" +
                             envioModel.estado + "','" +
                             envioModel.envioXml + "','" +
                             envioModel.recepcionDteXml + "','" +
                             envioModel.trackId + "'," +
                             envioModel.CdgSIISucur + " " +
                             ")";

                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                command.ExecuteNonQuery();

                myConn.Close();
            }
            catch (Exception empUpdate)
            {
                Console.WriteLine("ERROR: {0}" + empUpdate.ToString());
               // MessageBox.Show("ERROR: {0}" + empUpdate.ToString());
            }


            //MessageBox.Show("Guardado con exito");

                
        }

        public DataTable getEnviosXFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            DataTable datatable = new DataTable();
            string fechaInicialS = fechaInicial.ToString("yyyy-MM-dd");
            string fechaFinalS = fechaFinal.ToString("yyyy-MM-dd");
            try
            {
                SQLiteConnection myConn = bd.ConnectSqlite();

                string sql = "select * from envio where fchEmis between '" + fechaInicialS + " 00:00:00' and '" + fechaFinalS + " 23:59:59'" ;
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                command.ExecuteNonQuery();
                SQLiteDataReader reader = command.ExecuteReader();
                datatable.Load(reader);
                myConn.Close();
            }
            catch (Exception empUpdate)
            {
                Console.WriteLine("ERROR: {0}" + empUpdate.ToString());
                //MessageBox.Show("ERROR: {0}" + empUpdate.ToString());
            }

            return datatable;
            //MessageBox.Show("Guardado con exito");


        }
    }
}
