using SqlServerData.Data.Framework;
using SqlServerData.Models;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace SqlServerData.Data
{
    internal class DoodleData : SqlCommands, ISqlCommands<Doodle>
    {
        private const string tableName = "Doodle";
        public DoodleData() : base(tableName)
        {

        }
        public SelectResult Select()
        {
            var result = new SelectResult();
            base.SelectRecords();
            result = (SelectResult)base.Baseresult;
            return result;
        }


        public InsertResult Insert(Doodle doodle)
        {
            var result = new InsertResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert into {tableName}");
                insertQuery.Append($"(Tekst, Created) VALUES ");
                insertQuery.Append($"(@Tekst, @Created)");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    // met behulp van het framework worden de bovenstaande parameters aangevuld met de info uit de entity
                    insertCommand.Parameters.Add("@Tekst", SqlDbType.NVarChar).Value = doodle.Tekst;
                    insertCommand.Parameters.Add("@Created", SqlDbType.DateTime).Value = doodle.SqlDate();
                    

                    result = InsertRecord(insertCommand);
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public UpdateResult Update(Doodle doodle)
        {
            var result = new UpdateResult();
            try
            {
                //SQL Command
                StringBuilder updateQuery = new StringBuilder();
                updateQuery.Append($"Update {tableName} Set");
                updateQuery.Append($"(Tekst, Created) VALUES ");
                updateQuery.Append($"(@Tekst, @Created)");
                using (SqlCommand updateCommand = new SqlCommand(updateQuery.ToString()))
                {
                    // met behulp van het framework worden de bovenstaande parameters aangevuld met de info uit de entity
                    updateCommand.Parameters.Add("@Tekst", SqlDbType.NVarChar).Value = doodle.Tekst;
                    updateCommand.Parameters.Add("@Created", SqlDbType.DateTime2).Value = doodle.Tekst;


                    result = UpdateRecord(updateCommand);
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public DeleteResult Delete(Doodle t)
        {
            var result = new DeleteResult();
            try
            {
                StringBuilder deleteQuery = new StringBuilder();
                deleteQuery.Append($"Delete from {tableName} where DoodleId = '{t.DoodleId}'");
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

