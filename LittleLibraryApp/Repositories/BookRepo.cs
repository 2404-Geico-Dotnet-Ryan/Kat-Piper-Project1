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
    //movie being added needs correct id
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
        return null;
    }
}



}