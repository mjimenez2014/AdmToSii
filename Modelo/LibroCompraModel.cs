using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Xml.Serialization;

namespace Modelo
{

   public class LibroCompraModel
    {
        BaseDato bd = new BaseDato();
        EmpresaModel empresaModel = new EmpresaModel();


        public DataTable listaLibroXFecha(DateTime mesAno ,string estado,string fechaInicial,string fechaFinal)
        {
            DataTable datatable = new DataTable();
            empresaModel = empresaModel.getEmpresa();
            try
            {
                SQLiteConnection myConn = bd.ConnectSqlite();
                string sql = "select TipoDTE,Folio,FchEmis,RUTEmisor,RUTRecep,RznSoc,MntNeto,MntExe,IVA, MntTotal "
                            +"FROM documento "
                            +"where estado='"+estado+"'" 
                           // +"and FchEmis between '"+fechaInicial+"' and '"+fechaFinal+"'"
                            +"and RUTEmisor <> '"+ empresaModel.RutEmisor+"'"
                            +"order by TipoDTE";
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                SQLiteDataReader reader = command.ExecuteReader();
                datatable.Load(reader);
            }
            catch (Exception ex)
            {
                datatable = null;
                throw new Exception("Error" + ex.Message);
            }
            return datatable;
        }

        public DataTable listaResumen(DateTime mesAno)
        {
            DataTable datatable = new DataTable();
            try
            {
                SQLiteConnection myConn = bd.ConnectSqlite();
                string sql = "select TipoDTE, tipoimp,count(Folio) as CantDoc,sum(MntNeto) as MntNeto,sum(MntExe) as MntExe,sum(IVA) as IVA,sum(MntTotal)as MntTotal from documento where estado = 'PREVIO' and RUTEmisor <> '" + empresaModel.RutEmisor + "' group by TipoDTE";
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                SQLiteDataReader reader = command.ExecuteReader();
                datatable.Load(reader);
                myConn.Close();
            }
            catch (Exception ex)
            {
                datatable = null;
                throw new Exception("Error" + ex.Message);
            }
            return datatable;
        }

        public DataTable listaOtrosImpuestos()
        {
            DataTable datatable = new DataTable();
            try
            {
                SQLiteConnection myConn = bd.ConnectSqlite();
                string sql = "select \"TipoDTE\",tipoimp, sum(montoimp) as montoimp "+
                             "from documento " +
                             "where montoimp <> 0 "+
                             "and estado = 'PREVIO'"+
                             "group by TipoDTE, tipoimp";
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                SQLiteDataReader reader = command.ExecuteReader();
                datatable.Load(reader);
                myConn.Close();
            }
            catch (Exception ex)
            {
                datatable = null;
                throw new Exception("Error" + ex.Message);
            }
            
            return datatable;
        }

        public DataTable listaOtrosImpuestos(string DTE)
        {
            DataTable datatable = new DataTable();
            try
            {
                SQLiteConnection myConn = bd.ConnectSqlite();
                string sql = "select \"TipoDTE\",tipoimp, sum(montoimp) as montoimp " +
                             "from documento " +
                             "where montoimp <> 0 " +
                             "and \"TipoDTE\" = '" + DTE + "' "+
                             "and estado = 'PREVIO'" +
                             "group by TipoDTE, tipoimp";
                SQLiteCommand command = new SQLiteCommand(sql, myConn);
                SQLiteDataReader reader = command.ExecuteReader();
                datatable.Load(reader);
                myConn.Close();
            }
            catch (Exception ex)
            {
                datatable = null;
                throw new Exception("Error" + ex.Message);
            }

            return datatable;
        }



    }
}
