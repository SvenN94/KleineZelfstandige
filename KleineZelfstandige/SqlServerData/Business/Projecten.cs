using SqlServerData.Data.Framework;
using SqlServerData.Data;
using System.Data;
using SqlServerData.Models;

namespace SqlServerData.Business
{
    public static class Projecten
    {
        public static DataTable GetProjectenDataTable()
        {
            var dt = new DataTable();
            try
            {
                var projectdata = new ProjectData();
                var result = projectdata.Select();
                dt = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            return dt;
        }

        public static InsertResult AddProject(Project project)
        {
            var result = new InsertResult();
            try
            {
                var projectdata = new ProjectData();
                result = projectdata.Insert(project);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            return result;
        }

        public static UpdateResult AlterProject(Project project)
        {
            var result = new UpdateResult();
            try
            {
                var projectdata = new ProjectData();
                result = projectdata.Update(project);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            return result;
        }
        public static DeleteResult DeleteProject(Project project)
        {
            var result = new DeleteResult();
            try
            {
                var projectdata = new ProjectData();
                result = projectdata.Delete(project);
                        
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            return result;

        }
    }
}
