using System;

class Program
{
    static void Main(string[] args)
    {
        BookRepo br = new(); //creates book repo object

        //retrieving book at exists
        //have to make assumption that user knows what id works
        System.Console.WriteLine("Please enter book ID:");
        int input = int.Parse(Console.ReadLine()?? "0");
        Book retrievedBook = br.GetBook(input);

        System.Console.WriteLine("Retrieved Book: " + retrievedBook);

        //adding a new book into collection

    }
}
