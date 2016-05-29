using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace Modelo
{
   public class PrinterModel
    {
        public String printerName;
        public String directory;
        BaseDato bd = new BaseDato();

        public List<PrinterModel> printerList()
        {

            List<PrinterModel> printers = new List<PrinterModel>();

            try
            {
                SQLiteConnection myConn = bd.ConnectSqlite();
                //myConn.Open();

                string sql = "select * from printers";
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                SQLiteDataReader reader = command.ExecuteReader();

                
                while (reader.Read())
                {
                    PrinterModel printer = new PrinterModel();
                    printer.printerName = reader["printername"].ToString();
                    printer.directory = reader["directory"].ToString();
                    printers.Add( printer);
    
                }

                myConn.Close();

                return printers;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.ToString());
                return printers;
            }

            
        }
    }
}
