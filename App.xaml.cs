using SQLite;
using Vet_Clinic.Data;

namespace Vet_Clinic;

public partial class App : Application
{
    static ProgramariDatabase database;
    public static int SelectedOwnerId { get; set; }

    public static ProgramariDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new ProgramariDatabase(Path.Combine(FileSystem.AppDataDirectory, "VetClinic.db3"));
            }
            return database;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
