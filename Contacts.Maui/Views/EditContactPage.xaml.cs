using Contacts.Maui.Data;
using Contacts.Maui.Models;
using Contact = Contacts.Maui.Models.Contact;
using ContactRepository = Contacts.Maui.Data.ContactRepository;

namespace Contacts.Maui.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
	private Contact contact;
	
	public EditContactPage()
	{
		InitializeComponent();
	}

    //called every time the Contacts page regains focus
    protected override void OnAppearing()
    {
        base.OnAppearing();
        
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
	  Shell.Current.GoToAsync("..");
    }

	public string ContactId
	{
		set
		{
			contact = App.ContactRepository.GetContactById(int.Parse(value));
			if (contact != null)
			{ 
				contactCtrl.Name = contact.Name;
				contactCtrl.Email = contact.Email;
				contactCtrl.Phone = contact.Phone;
				contactCtrl.Address = contact.Address;
			}
		}
	}

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
		ContactRepository contactRepo = new ContactRepository("Server=.;Database=Db;Trusted_Connection=True;TrustServerCertificate=True");
		Contact contact = new Contact();
		contact.Name = contactCtrl.Name;
		contact.Email = contactCtrl.Email;
		contact.Phone = contactCtrl.Phone;
		contact.Address = contactCtrl.Address;

		contactRepo.UpdateContact(contact);
		Shell.Current.GoToAsync("..");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
		DisplayAlert("Error", e, "OK");
    }
}