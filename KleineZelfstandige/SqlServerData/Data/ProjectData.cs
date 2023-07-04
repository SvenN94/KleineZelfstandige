using SqlServerData.Data.Framework;
using SqlServerData.Models;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace SqlServerData.Data
{
    internal class ProjectData : SqlCommands,ISqlCommands<Project>
    {
        private const string tableName = "Projecten";
        public ProjectData() : base(tableName)
        {

        }
        public SelectResult Select()
        {
            var result = new SelectResult();
            base.SelectRecords();
            result = (SelectResult)base.Baseresult;
            return result;
        }


        public InsertResult Insert(Project project)
        {
            var result = new InsertResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert into {tableName}");
                insertQuery.Append($"(Locatie, EindDatum) VALUES ");
                insertQuery.Append($"(@Locatie, @Einddatum)");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    // met behulp van het framework worden de bovenstaande parameters aangevuld met de info uit de entity
                    insertCommand.Parameters.Add("@Locatie", SqlDbType.NVarChar).Value = project.Locatie;
                    insertCommand.Parameters.Add("@Einddatum", SqlDbType.DateTime).Value = project.SqlDate();


                    result = InsertRecord(insertCommand);
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public UpdateResult Update(Project project)
        {
            var result = new UpdateResult();
            try
            {
                //SQL Command
                StringBuilder updateQuery = new StringBuilder();
                updateQuery.Append($"Update {tableName} Set");
                updateQuery.Append($"(Locatie, EindDatum) VALUES ");
                updateQuery.Append($"(@Locatie, @Einddatum)");
                using (SqlCommand updateCommand = new SqlCommand(updateQuery.ToString()))
                {
                    // met behulp van het framework worden de bovenstaande parameters aangevuld met de info uit de entity
                    updateCommand.Parameters.Add("@Locatie", SqlDbType.NVarChar).Value = project.Locatie;
                    updateCommand.Parameters.Add("@Einddatum", SqlDbType.DateTime2).Value = project.EindDatum;


                    result = UpdateRecord(updateCommand);
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public DeleteResult Delete(Project project) 
        {
            var result = new DeleteResult();
            try
            {
                StringBuilder deleteQuery = new StringBuilder();
                deleteQuery.Append($"Delete from {tableName} where ProjectId = '{project.Id}'");
                using (SqlCommand deletecommand = new SqlCommand(deleteQuery.ToString()))
                {
                    result = DeleteRecord(deletecommand);
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
            return result;
        }
    }
}
