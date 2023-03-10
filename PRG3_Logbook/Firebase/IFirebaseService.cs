using PRG3_Logbook.Entities;

namespace PRG3_Logbook.Firebase
{
    public interface IFirebaseService
    {
        Task WriteLogbookDataAsync(LogbookData data);
        Task<List<LogbookData>> GetLogbooksAsync();
    }
}
