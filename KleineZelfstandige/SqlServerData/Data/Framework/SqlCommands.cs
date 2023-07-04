using System.Data.SqlClient;
using System.Data;

namespace SqlServerData.Data.Framework
{
    internal abstract class SqlCommands
    {
        private SqlConnection sqlConn;
        

        public SqlCommands(string tableName)
        {
            TableName = tableName;
            // sqlConn -> ServerVersion = {"Invalid operation. The connection is closed."}            
            sqlConn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=KleineZelfstandige;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected string TableName { get; set; }
        protected BaseResult Baseresult { get; set; }
        #region Select

        protected void SelectRecords()
        {
            try
            {
                string query = $"Select * from {TableName}";
                SelectRecords(query);
            }
            catch (Exception ex)
            {
                Baseresult.AddError(ex.Message);

            }
        }
        protected void SelectRecords(string query)
        {
            try
            {
                using (SqlCommand sqlComm = new SqlCommand(query))
                {
                    SelectRecords(sqlComm);
                }
            }
            catch (Exception ex)
            {
                Baseresult.AddError(ex.Message);

            }
        }
        protected void SelectRecords(SqlCommand selectCommand)
        {
            try
            {
                Baseresult = new SelectResult();
                using (sqlConn)
                {
                    selectCommand.Connection = sqlConn;
                    sqlConn.Open();
                    var adapter = new SqlDataAdapter(selectCommand);
                    var ds = new DataSet();
                    Baseresult.Rows = adapter.Fill(ds);
                    if (ds.Tables.Count > 0)
                        Baseresult.DataTable = ds.Tables[0];
                    sqlConn.Close();
                }
                Baseresult.Succeeded = true;
            }
            catch (Exception ex)
            {
                Baseresult.AddError(ex.Message);

            }
        }
        #endregion

        protected UpdateResult UpdateRecord(SqlCommand updateCommand)
        {
            var result = new UpdateResult();
            try
            {
                using (sqlConn)
                {
                    // query uitvoeren
                    updateCommand.Connection = sqlConn;
                    sqlConn.Open();
                    updateCommand.ExecuteNonQuery();
                    sqlConn.Close();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        protected InsertResult InsertRecord(SqlCommand insertCommand)
        {
            var result = new InsertResult();
            try
            {
                using (sqlConn)
                {
                    insertCommand.CommandText += "SET @new_id = SCOPE_IDENTITY();";
                    insertCommand.Parameters.Add("@new_id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    insertCommand.Connection = sqlConn;
                    sqlConn.Open();
                    insertCommand.ExecuteNonQuery();
                    //int newId = Convert.ToInt32(insertCommand.Parameters["@new_id"].Value);
                    //int newId = Convert.ToInt32(insertCommand.Parameters["@new_id"].Value); // connot convert to DBnull
                    // indien we de dbnull fout krijgen -> ga direct naar sqlconn.Close
                    if (!Convert.IsDBNull(insertCommand.Parameters["@new_id"].Value))
                    {
                        int newId = Convert.ToInt32(insertCommand.Parameters["@new_id"].Value);
                        result.NewId = newId;
                    }
                    else
                    {
                        //DataTO.Id = ...some default value or perform some error case management
                        sqlConn.Close();
                    }

                    //result.NewId = newId;
                    //sqlConn.Close();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        protected DeleteResult DeleteRecord(SqlCommand deleteCommand)
        {
            var result = new DeleteResult();
            try
            {
                using (sqlConn)
                {
                    // query uitvoeren
                    deleteCommand.Connection = sqlConn;
                    sqlConn.Open();
                    deleteCommand.ExecuteNonQuery();
                    sqlConn.Close();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        } 
    }
}
