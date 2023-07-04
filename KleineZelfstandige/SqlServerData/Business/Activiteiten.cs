using SqlServerData.Data.Framework;
using SqlServerData.Data;
using System.Data;
using SqlServerData.Models;

namespace SqlServerData.Business
{
    public static class Activiteiten
    {
        public static DataTable GetActiviteitenDataTable()
        {
            var dt = new DataTable();
            try
            {
                var activiteitdata = new ActiviteitData();
                var result = activiteitdata.Select();
                dt = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            return dt;
        }

        public static InsertResult AddActiviteit(Activiteit activiteit)
        {
            var result = new InsertResult();
            try
            {
                var activiteitdata = new ActiviteitData();
                result = activiteitdata.Insert(activiteit);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            return result;
        }

        public static UpdateResult AlterActiviteit(Activiteit activiteit)
        {
            var result = new UpdateResult();
            try
            {
                var activiteitdata = new ActiviteitData();
                result = activiteitdata.Update(activiteit);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            return result;
        }
        public static DeleteResult DeleteActiviteit(Activiteit activiteit)
        {
            var result = new DeleteResult();
            try
            {
                var activiteitdata = new ActiviteitData();
                activiteitdata.Delete(activiteit);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            return result;
        }
    }
    
}
