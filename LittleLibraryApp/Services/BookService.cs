class BookService
{
    /*
    Services: 
        - Remove books from inventory
        - Add books to inventory
        - View list of books

    */
    BookRepo br;
     public BookService(BookRepo br)
    {
        this.br = br;
    }
    public List<Book> GetAvailableBooks()
    {
        //Get all books
        List<Book> allBooks = br.GetAllBooks();
        return allBooks;

    }
    //b is the book that is being removed from the library
    public Book RemoveBook(Book b)
    {
        br.DeleteBook(b);
        return b; //sends back removed movie
        
    }
    public Book AddNewBook(Book b)
    {
        br.AddBook(b);
        return b;
      
    }
    public Book? GetBook(int id)
    {
        return br.GetBook(id);
    }




}