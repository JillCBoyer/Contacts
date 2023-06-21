using Contacts.Maui.Data;

namespace Contacts.Maui;

public partial class App : Application
{
	public static ContactRepository ContactRepository { get; private set; }
	public App(ContactRepository contactRepository)
	{
		InitializeComponent();

		MainPage = new AppShell();

		ContactRepository = contactRepository;
	}
}
