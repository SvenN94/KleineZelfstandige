using SqlServerData.Data.Framework;
using System.Data.SqlClient;
using SqlServerData.Models;
using System.Text;
using System.Data;

namespace SqlServerData.Data
{
    internal class KlantenData : SqlCommands, ISqlCommands<Klant>
    {
        private const string tableName = "Klanten";
        public KlantenData() : base(tableName)
        {

        }
        public SelectResult Select()
        {
            var result = new SelectResult();
            base.SelectRecords();
            result = (SelectResult)base.Baseresult;
            return result;
        }       


        public InsertResult Insert(Klant klant)
        {
            var result = new InsertResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert into {tableName}");
                insertQuery.Append($"(BedrijfNaam, Voornaam,Achternaam, Straat, Huisnummer, Gemeente, Telefoon, Email) VALUES ");
                insertQuery.Append($"(@BedrijfNaam,@Voornaam,@Achternaam, @Straat, @Huisnummer, @Gemeente, @Telefoon, @Email )");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    // met behulp van het framework worden de bovenstaande parameters aangevuld met de info uit de entity
                    insertCommand.Parameters.Add("@BedrijfNaam", SqlDbType.NVarChar).Value = klant.BedrijfNaam;
                    insertCommand.Parameters.Add("@Voornaam", SqlDbType.NVarChar).Value =klant.Voornaam;
                    insertCommand.Parameters.Add("@Achternaam", SqlDbType.NVarChar).Value =klant.Achternaam;
                    insertCommand.Parameters.Add("@Straat", SqlDbType.NVarChar).Value =klant.Straat;
                    insertCommand.Parameters.Add("@Huisnummer", SqlDbType.NVarChar).Value =klant.Huisnummer;
                    insertCommand.Parameters.Add("@Gemeente", SqlDbType.NVarChar).Value =klant.Gemeente;
                    insertCommand.Parameters.Add("@Telefoon", SqlDbType.NVarChar).Value =klant.Telefoon;
                    insertCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value =klant.Email;
                    
                    result = InsertRecord(insertCommand);
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public UpdateResult Update(Klant klant)
        {
            var result = new UpdateResult();
            try
            {
                //SQL Command
                StringBuilder updateQuery = new StringBuilder();
                updateQuery.Append($"Update {tableName} Set");
                updateQuery.Append($"(BedrijfNaam, Voornaam,Achternaam, Straat, Huisnummer, Gemeente, Telefoon, Email) VALUES ");
                updateQuery.Append($"(@BedrijfNaam, @Voornaam,@Achternaam, @Straat, @Huisnummer, @Gemeente, @Telefoon, @Email ) where KlantId = @KlantId");
                using (SqlCommand updateCommand = new SqlCommand(updateQuery.ToString()))
                {
                    // met behulp van het framework worden de bovenstaande parameters aangevuld met de info uit de entity
                    updateCommand.Parameters.Add("@KlantId", SqlDbType.Int).Value = klant.KlantId;
                    updateCommand.Parameters.Add("@BedrijfNaam", SqlDbType.NVarChar).Value = klant.BedrijfNaam;
                    updateCommand.Parameters.Add("@Voornaam", SqlDbType.NVarChar).Value = klant.Voornaam;
                    updateCommand.Parameters.Add("@Achternaam", SqlDbType.NVarChar).Value = klant.Achternaam;
                    updateCommand.Parameters.Add("@Straat", SqlDbType.NVarChar).Value = klant.Straat;
                    updateCommand.Parameters.Add("@Huisnummer", SqlDbType.NVarChar).Value = klant.Huisnummer;
                    updateCommand.Parameters.Add("@Gemeente", SqlDbType.NVarChar).Value = klant.Gemeente;
                    updateCommand.Parameters.Add("@Telefoon", SqlDbType.NVarChar).Value = klant.Telefoon;
                    updateCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = klant.Email;

                    result = UpdateRecord(updateCommand);
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public DeleteResult Delete(Klant k)
        {
            var result = new DeleteResult();
            try
            {
                StringBuilder deleteQuery = new StringBuilder();
                deleteQuery.Append($"Delete from {tableName} where KlantId = '{k.KlantId}'");
                using (SqlCommand deletecommand = new SqlCommand(deleteQuery.ToString()))
                {
                    result = DeleteRecord(deletecommand);
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
