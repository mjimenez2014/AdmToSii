using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace Modelo
{
   public class LibroVentaModel
    {
        BaseDato bd = new BaseDato();
        EmpresaModel empresaModel = new EmpresaModel();

        public DataTable listaLibroXFecha(DateTime mesAno)
        {
            DataTable datatable = new DataTable();
            empresaModel = empresaModel.getEmpresa();
            try
            {
                SQLiteConnection myConn = bd.ConnectSqlite();
                string sql = "select TipoDTE,Folio,FchEmis,RUTEmisor,RUTRecep,RznSoc,MntNeto,MntExe,IVA,MntTotal FROM documento where estado='PREVIO' and RUTEmisor = '" + empresaModel.RutEmisor + "' order by TipoDTE";
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
                string sql = "select TipoDTE,count(Folio) as CantDoc,sum(MntNeto) as MntNeto,sum(MntExe) as MntExe,sum(IVA) as IVA,sum(MntTotal)as MntTotal from documento where estado = 'PREVIO' and RUTEmisor = '" + empresaModel.RutEmisor + "' group by TipoDTE";
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

        public DataTable listaDocManualXFecha(DateTime mesAno)
        {
            DataTable datatable = new DataTable();
            empresaModel = empresaModel.getEmpresa();
            try
            {
                SQLiteConnection myConn = bd.ConnectSqlite();
                string sql = "select TipoDTE,Folio,FchEmis,RUTEmisor,RUTRecep,RznSoc,MntNeto,MntExe,IVA,MntTotal FROM documento where estado='PREVIO' and RUTEmisor = '" + empresaModel.RutEmisor + "' and TipoDTE in (30,60) order by TipoDTE";
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

    }
}
