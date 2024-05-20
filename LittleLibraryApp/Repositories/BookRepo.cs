using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class BookRepo
{
    /*
    this class is in the data access/repo layer of app
    it's responsible for any data access and management centered
    around Book object

    4 Major Operations managed in this location
    C- Create (add data to collection)
    R- Read/Retrieve (retrieve or access data)
    U- Update (changes made to book objects)
    D- Delete (removal of book objects)

    */
BookStorage bookStorage = new();

public Book AddBook(Book b)
{
    //book being added needs correct id
    //assume it doesn't and force it to by using idCounter
    b.Id = bookStorage.idCounter++;//increments value aftwards to prep for next time it's needed

    //add book into collection
    bookStorage.books.Add(b.Id, b);
    return b;
}

public Book? GetBook(int id)
{
    if(bookStorage.books.ContainsKey(id))
    {
        Book selectedBook = bookStorage.books[id]; //uses id to find and retrieve entire book
        return selectedBook;
    }
    else
    {
        //need to adjust this.  If id can't be found, then book does not exist at library.  See loop in main program- need to adjust that too
        System.Console.WriteLine("Invalid Book ID, please enter a book ID");
        return null;
    }

}
//method to return all books
public List<Book> GetAllBooks()
{
    return bookStorage.books.Values.ToList();
}

public Book? UpdateBook(Book updatedBook)
{
    //assuming ID is consistent with an ID that exists
    //just have to update value (Book) for key (ID) within dictionary
    try
    {
    bookStorage.books[updatedBook.Id] = updatedBook;
    return updatedBook;//confirms storage has been updated w/ info sent back to user
    }
    catch(Exception)
    {
        System.Console.WriteLine("Invalid Book ID - Please try again");
        return null;
    }
    
}

public Book? DeleteBook(Book b)
{
        //if have the ID-> remove book from storage
        bool didRemove = bookStorage.books.Remove(b.Id);

        if (didRemove)
        {
            return b;
        }
    
        else
        {
            System.Console.WriteLine("Invalid Book ID - Please Try Again");
            return null;
        }
}


}