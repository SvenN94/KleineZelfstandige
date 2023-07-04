using SqlServerData.Data;
using SqlServerData.Data.Framework;
using SqlServerData.Models;
using System;
using System.Data;

namespace SqlServerData.Business
{
    public static class Klanten
    {
        public static DataTable GetKlantenDataTable()
        {
            var dt = new DataTable();
            try
            {
                var klantendata = new KlantenData();
                var result = klantendata.Select();
                dt = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            return dt;
        }

        public static InsertResult AddKlant(Klant klant)
        {
            var result = new InsertResult();
            try
            {
                var klantendata = new KlantenData();
                klantendata.Insert(klant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            return result;
        }
    
        public static UpdateResult AlterKlant(Klant klant)
        {
            var result = new UpdateResult();
            try
            {
                var klantenData = new KlantenData();
                result = klantenData.Update(klant);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            return result;
        }
        public static DeleteResult DeleteKlant(Klant klant)
        {
            var result = new DeleteResult();
            try
            {
                var klantenData = new KlantenData();
                result = klantenData.Delete(klant);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            return result;
        }
    }
}
