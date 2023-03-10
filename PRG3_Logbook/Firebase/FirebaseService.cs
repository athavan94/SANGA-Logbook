using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using PRG3_Logbook.Entities;
using PRG3_Logbook.Firebase;

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

        public Task<List<LogbookData>> GetLogbooksAsync()
        {
            throw new NotImplementedException();
        }
    }
}
