using Contacts.Maui.Models;
using SQLite;

namespace Contacts.Maui.Data
{
    public class ContactRepository
    {
        string _dbPath;
        private SQLiteConnection conn;

        public ContactRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        //private readonly ContactRepository _conn;

        //public ContactRepository(ContactRepository conn)
        //{
        //  _conn = conn;
        //}

        //Initializes DB one time only  
        public void Init()
        {
            //Create the connection to the db
            conn = new SQLiteConnection(_dbPath);

            //Create the table only if it doesn't exist
            if (conn.GetTableInfo("Contact").Count == 0)
            {
                conn.CreateTable<Models.Contact>();
            }
        }


        //returns list of contacts
        public List<Models.Contact> GetContacts()
        {
            Init();
            return conn.Table<Models.Contact>().ToList();
        }


        //Returns the connection to the db
        //It will first be created if it does not exist
        private SQLiteConnection GetConnection()
        {
            if (conn == null)
            {
                Init();
            }

            return conn;
        }

        //adds contact
        public void Add(Models.Contact contact)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Insert(contact);
        }



        //deletes contact
        public void Delete(int ContactId)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Delete(new { Id = ContactId });

        }

       

        //initializes data
        public static List<Models.Contact> _contacts = new List<Models.Contact>();
        

        //gets one single contact
        public Models.Contact GetContactById(int contactId)
        {
            var db_list = GetContacts();

            foreach(var contact in db_list)
            {
                if(contact.ContactId == contactId)
                {
                    return contact;
                }
            }

            return null;

        }       

        public void UpdateContact(Models.Contact contact)
        {
            GetConnection().Update(contact);
        }
        
    }
}
