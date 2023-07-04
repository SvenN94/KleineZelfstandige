using SqlServerData.Data.Framework;
using SqlServerData.Data;
using System.Data;
using SqlServerData.Models;

namespace SqlServerData.Business
{
    public static class Doodles
    {
        public static DataTable GetDoodleDataTable()
        {
            var dt = new DataTable();
            try
            {
                var doodledata = new DoodleData();
                var result = doodledata.Select();
                dt = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            return dt;
        }

        public static InsertResult AddDoodle(Doodle doodle)
        {
            var result = new InsertResult();
            try
            {
                var doodledata = new DoodleData();
                result = doodledata.Insert(doodle);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            return result;
        }

        public static UpdateResult AlterDoodle(Doodle doodle)
        {   
            var result = new UpdateResult();
            try
            {
                var doodleData = new DoodleData();
                result = doodleData.Update(doodle);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            return result;
        }
        public static DeleteResult DeleteDoodle(Doodle doodle)
        {   
            var result = new DeleteResult();
            try
            {
                var doodleData = new DoodleData();
                result = doodleData.Delete(doodle);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            return result;
        }
    }
}
