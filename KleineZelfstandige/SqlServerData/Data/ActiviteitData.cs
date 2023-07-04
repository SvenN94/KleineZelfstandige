using SqlServerData.Data.Framework;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using SqlServerData.Models;

namespace SqlServerData.Data
{
    internal class ActiviteitData : SqlCommands , ISqlCommands<Activiteit>
    {
        private const string tableName = "Activiteiten";
        public ActiviteitData() : base(tableName)
        {

        }
        public SelectResult Select()
        {
            var result = new SelectResult();
            base.SelectRecords();
            result = (SelectResult)base.Baseresult;
            return result;
        }


        public InsertResult Insert(Activiteit activiteit)
        {
            var result = new InsertResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert into {tableName}");
                insertQuery.Append($"(klantId, GeplandeDatum, GewerkteUren, SoortWerk, Materialen, Locatie) VALUES ");
                insertQuery.Append($"(@KlantId, @GeplandeDatum, @GewerkteUren, @SoortWerk, @Materialen, @Locatie)");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    // met behulp van het framework worden de bovenstaande parameters aangevuld met de info uit de entity
                    insertCommand.Parameters.Add("@KlantId", SqlDbType.Int).Value = activiteit.KlantId;
                    insertCommand.Parameters.Add("@GeplandeDatum", SqlDbType.DateTime).Value = activiteit.SqlDate();
                    insertCommand.Parameters.Add("@GewerkteUren", SqlDbType.Decimal).Value = activiteit.GewerkteUren;
                    insertCommand.Parameters.Add("@SoortWerk", SqlDbType.NVarChar).Value = activiteit.SoortWerk;
                    insertCommand.Parameters.Add("@Materialen", SqlDbType.NVarChar).Value = activiteit.Materialen;
                    insertCommand.Parameters.Add("@Locatie", SqlDbType.NVarChar).Value = activiteit.Locatie;


                    result = InsertRecord(insertCommand);
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public UpdateResult Update(Activiteit activiteit)
        {
            var result = new UpdateResult();
            try
            {
                //SQL Command
                StringBuilder updateQuery = new StringBuilder();
                updateQuery.Append($"Update {tableName} Set");
                updateQuery.Append($"(GeplandeDatum, GewerkteUren, SoortWerk, Materialen, Locatie) VALUES ");
                updateQuery.Append($"(@GeplandeDatum, @GewerkteUren, @SoortWerk, @Materialen, @Locatie)");
                using (SqlCommand updateCommand = new SqlCommand(updateQuery.ToString()))
                {
                    // met behulp van het framework worden de bovenstaande parameters aangevuld met de info uit de entity
                    updateCommand.Parameters.Add("@GeplandeDatum", SqlDbType.DateTime2).Value = activiteit.GeplandeDatum;
                    updateCommand.Parameters.Add("@GewerkteUren", SqlDbType.Decimal).Value = activiteit.GewerkteUren;
                    updateCommand.Parameters.Add("@SoortWerk", SqlDbType.NVarChar).Value = activiteit.SoortWerk;
                    updateCommand.Parameters.Add("@Materialen", SqlDbType.NVarChar).Value = activiteit.Materialen;
                    updateCommand.Parameters.Add("@Locatie", SqlDbType.NVarChar).Value = activiteit.Locatie;


                    result = UpdateRecord(updateCommand);
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public DeleteResult Delete(Activiteit t)
        {
            throw new NotImplementedException();
        }
    }
}
