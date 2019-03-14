using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentApi
{
    public class DocumentRepository
    {
        public Task<IEnumerable<DocumentDto>> GetAllDocuments()
        {
            var connection = new SqlConnection("fake-connection-string");
            var command = connection.CreateCommand();

            var commandText = @"
                SELECT *
                FROM Documents
            ";

            command.CommandText = commandText;

            var documents = new List<DocumentDto>();

            var reader = command.ExecuteReaderAsync().Result;
            while (reader.ReadAsync().Result)
            {
                var document = new DocumentDto();
                document.Id = (string)reader[0];
                document.Name = (string)reader[1];
                document.Content = (string)reader[2];
                documents.Add(document);
            }

            return Task.FromResult(documents.AsEnumerable());
        }
    }
}