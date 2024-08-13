using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU1_BookCollection_Indexer_G1
{
    class BookCollection
    {
     //Make use a Generic Collection (List<string>) to hold book titles
        private List<string> books = new List<string>();

        //Add an indexer to access the book list (have some validation)
            public string this[int index]
        {
                get 
                {
                    ValidateIndex(index);
                    return books[index];    
                }
                set 
                {
                    ValidateIndex(index);
                    books[index] = value;
                }

        }

        // Method to do the validation, will be called in the get/set of the indexer
        private void ValidateIndex(int index) 
        {
            if (index < 0 || index >= books.Count) 
                { throw new IndexOutOfRangeException("Index out of range"); }
        }

        //AddBook Method: Add a book title to the Book Collection
        public void AddBook(string book) 
            { 
                books.Add(book);
            }

        //Count property to retrieve the total count of book titles
            public int Count => books.Count;
    }
}
