namespace PRG3_Logbook;

public partial class CapturePage : ContentPage
{
	public CapturePage()
	{
		InitializeComponent();
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

		// Create path and filename for the file
		string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		string filename = Path.Combine(documentsPath, "Logbook.txt");

		// Create text for the file
		string fileText = $"Date from: {dateFrom}\nDate until: {dateUntil}\nKilometre: {kilometre}\n\n";

		// Add text to file
		File.AppendAllText(filename, fileText );

		await DisplayAlert("Success", "Die Daten wurden erfolgreich gespeichert.", "OK");
	}
}