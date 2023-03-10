using PRG3_Logbook.Entities;
using PRG3_Logbook.Firebase;

namespace PRG3_Logbook;

public partial class StatisticPage : ContentPage
{
	private readonly IFirebaseService _firebaseService = new FirebaseService();

	public StatisticPage()
	{
		InitializeComponent();
		LoadLogbooks();
	}

	private async void LoadLogbooks()
	{	
		List<LogbookData> logBookData = await _firebaseService.GetLogbooksAsync();
        logbookListView.ItemsSource = logBookData;
    }
}