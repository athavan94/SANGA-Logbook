using Firebase.Database;
using Firebase.Database.Query;
using PRG3_Logbook.Entities;
using System.Diagnostics;

namespace PRG3_Logbook.Firebase
{
    class FirebaseService: IFirebaseService
    {
        private readonly FirebaseClient _client;

        public FirebaseService()
        {
            string databaseUrl = "https://logbook-320d8-default-rtdb.europe-west1.firebasedatabase.app/";
            _client = new FirebaseClient(databaseUrl);
        }

        public async Task WriteLogbookDataAsync(LogbookData data)
        {
            await _client.Child("SANGA-Logbook").PostAsync(data);
        }

        public async Task<List<LogbookData>> GetLogbooksAsync()
        {
            var logbooks = await _client.Child("SANGA-Logbook").OnceAsync<LogbookData>();
            return logbooks.Select(item => item.Object).ToList();
        }
    }
}
