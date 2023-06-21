using SQLite;

namespace Contacts.Maui.Models
{
    [Table("Contacts")]
    public class Contact
    {
        [PrimaryKey, AutoIncrement, Column("ContactId")]
        public int ContactId { get; set; }
        [MaxLength(50), Unique]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}



 