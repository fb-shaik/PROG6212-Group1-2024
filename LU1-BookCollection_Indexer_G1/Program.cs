using LU1_BookCollection_Indexer_G1;

class Program
{

    static void main(String[] args)
    {
        //Create an instance of the BookCollection class
        BookCollection myBooks = new BookCollection();

        //Add at least 3 books to the collection
        myBooks.AddBook("The Great Gatsby");
        myBooks.AddBook("1984");
        myBooks.AddBook("To Kill a MockingBird");

        //Access the books using the indexer & display the book title
        Console.WriteLine("Book title at index 1: " + myBooks[1]);

        //Change 1 of the book titles via the indexer
        myBooks[1] = "Brave New World!";

        //Display the change book title
        Console.WriteLine("Book title at index 1 after modification: " + myBooks[1]);

        //Display all books in collection
        Console.WriteLine("\nAll Books in the Collection");
        for (int i = 0; i < myBooks.Count; i++) 
        { 
            Console.WriteLine("Book at index " + i + ": " + myBooks[i]);
        }
    }
}


