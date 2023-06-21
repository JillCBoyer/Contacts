using ContactRepository = Contacts.Maui.Data.ContactRepository;

namespace Contacts.Maui.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void contactCtrl_OnSave(object sender, EventArgs e)
    {

        //ContactRepository contactRepo = new ContactRepository("Server=.;Database=Db;Trusted_Connection=True;TrustServerCertificate=True");
        
        App.ContactRepository.Add(new Models.Contact
        {
            Name = contactCtrl.Name,
            Email = contactCtrl.Email,
            Phone = contactCtrl.Phone,
            Address = contactCtrl.Address
        });

        Shell.Current.GoToAsync("..");

    }

    private void contactCtrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");

    }
}