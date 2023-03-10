using PRG3_Logbook.Entities;
using PRG3_Logbook.Firebase;

namespace PRG3_Logbook;

public partial class CapturePage : ContentPage
{
	private IFirebaseService _firebaseService;

	public CapturePage()
	{
		InitializeComponent();

		_firebaseService = new FirebaseService();
	}

    public CapturePage(IFirebaseService firebaseService) : this()
    {
        _firebaseService = firebaseService;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
	{
		// Get values from input fields
		string dateFrom = DatePickerFrom.Date.ToString("dd.MM.yyyy");
		string dateUntil = DatePickerUntil.Date.ToString("dd.MM.yyyy");
		double kilometre = 0;

		// Check if kilometre is double
		if (!double.TryParse(KilometerEntry.Text, out kilometre))
		{
			await DisplayAlert("Error", "Enter a valid kilometre value.", "OK");
			return;
		}

		// Write dadta in the firebase-database
		var logbookData = new LogbookData
		{
			DateFrom = dateFrom,
			DateTo = dateUntil,
			Kilometre = kilometre
		};

		await _firebaseService.WriteLogbookDataAsync(logbookData);

		await DisplayAlert("Success", "Die Daten wurden erfolgreich gespeichert.", "OK");
	}
}