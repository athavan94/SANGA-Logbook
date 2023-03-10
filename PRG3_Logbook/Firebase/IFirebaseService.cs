using PRG3_Logbook.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG3_Logbook.Firebase
{
    public interface IFirebaseService
    {
        Task WriteLogbookDataAsync(LogbookData data);
        //Task<List<LogbookData>> GetLogbooksAsync();
    }
}
