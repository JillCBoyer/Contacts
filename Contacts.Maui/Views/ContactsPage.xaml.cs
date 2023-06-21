using Contact = Contacts.Maui.Models.Contact;
using System.Collections.ObjectModel;
using ContactRepository = Contacts.Maui.Data.ContactRepository;
using Contacts.Maui.Models;

namespace Contacts.Maui.Views;

public partial class ContactsPage : ContentPage
{
	   
    public ContactsPage()
	{
		InitializeComponent(); 
	}

    //called every time the Contacts page regains focus
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadContacts();
    }

    private void btnEditContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EditContactPage));
    }

    private void btnAddContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listContacts.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).ContactId}");
        }
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        
        var menuItem = sender as MenuItem;
        var Contact = menuItem.CommandParameter as Contact;
        App.ContactRepository.Delete(Contact.ContactId);
       
        LoadContacts();
    }

    //helper method to refresh contacts
    private void LoadContacts()
    {
        var contacts = new ObservableCollection<Contact>();

        var db_contacts = App.ContactRepository.GetContacts();

        foreach(var c in db_contacts)
        {
            contacts.Add(c);
        }

        listContacts.ItemsSource = contacts;
    }
}