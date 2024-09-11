using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace ContactsApp
{
    public class Contact : IComparable // Inherits from IComparable to allow contact instances to be compared.
    {
        // Properties to store contact details.
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        // Default constructor
        public Contact()
        { }

        // Parameterized constructor to initialize a new instance of Contact with specified details.
        public Contact(int id, string name, string surname, string email, string telephone)
        {
            ID = id;           // Assigns the unique identifier of the contact.
            Name = name;       // Assigns the first name of the contact.
            Surname = surname; // Assigns the last name of the contact.
            Email = email;     // Assigns the email address of the contact.
            Telephone = telephone; // Assigns the telephone number of the contact.
        }

        // Implements the CompareTo method to provide a default sort order.
        public int CompareTo(object obj)
        {
            // Safely casts the object to a Contact, and if successful, compares it by Name.
            Contact other = obj as Contact;
            if (other != null)
                return Name.CompareTo(other.Name);
            else
                throw new ArgumentException("Object is not a Contact");
        }

        // Overrides the ToString method to return the contact's name when the object is used in a context that expects a string.
        public override string ToString()
        {
            return Name; // Useful for displaying the name directly, e.g., in UI elements.
        }
    }
}
