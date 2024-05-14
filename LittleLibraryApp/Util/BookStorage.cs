class BookStorage
{
    /*
    TEMPORARY Setup until we learn SQL
    Placeholder for storing movies
    */

    public Dictionary<int, Book> books;
    public int idCounter = 1;
    public BookStorage() //inventory of books
    {
        Book book1 = new(idCounter, "East of Eden", "John Steinbeck", true); idCounter++;
        Book book2 = new(idCounter, "Catcher in the Rye", "J.D. Salinger", true); idCounter++;
        Book book3 = new(idCounter, "The Last Thing He Told Me", "Laura Dave", true); idCounter++;
        Book book4 = new(idCounter, "Washington's Spies", "Alexander Rose", false); idCounter++;

        books = []; //sets dictionary to empty collection
        books.Add(book1.Id, book1);//adds movie to the dictionary
        books.Add(book2.Id, book2);
        books.Add(book3.Id, book3); //alternative more proper syntax
        books.Add(book4.Id, book4);
    }
}