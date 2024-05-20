using System;
using System.Runtime.InteropServices;

class Program
{
    static BookService bs = new();
    static LocationService ls = new();
    static User? currentUser = null;
    static UserService us = new();
    static void Main(string[] args)
    {
            
        System.Console.WriteLine("Welcome to the Little Library app!");
        System.Console.WriteLine("Please log in to get started");
        while(currentUser == null)
        {
        System.Console.WriteLine("Username:");
        string username = (Console.ReadLine()?? "");
        System.Console.WriteLine("Password:");
        string password = (Console.ReadLine()??"");
        currentUser = us.LogInUser(username, password);
        }


        

        bool keepGoing = true;
        while (keepGoing)
        {
            //menu is for user that is logged in (not admin)
            System.Console.WriteLine(" Welcome " + currentUser.Username + "! Please tell us what you'd like to do:");
            System.Console.WriteLine("************************************");
            System.Console.WriteLine("(1) Find a book");
            System.Console.WriteLine("(2) Add a book");
            System.Console.WriteLine("(3) Remove a book");
            System.Console.WriteLine("(0) Exit");

            int input = int.Parse(Console.ReadLine()?? "0");

            keepGoing = DecideNextOption(input);
            
        }

       /* RetrievingBook(br);//tested BookRepo - GetBook()

        //adding a new book into collection
        AddNewBook(br);
        //Updating a book in collection
        UpdatingBook(br);

        //test deleting book in collection
        DeletingBook(br);

        //adding a new location to list of libraries (new library owner)
        LocationRepo lr = new();
        AddingNewLocation(lr);
        RetrievingLocation(lr);
        UpdatingLocation(lr);
        DeletingLocation(lr);*/



    }

    private static bool DecideNextOption(int input)
    {
        switch (input)
        {
            case 1:
            {
                System.Console.WriteLine("What is the book you are looking for?");
                string bookInput  = (Console.ReadLine()??"");
                RetrievingAllLocations();
                break;
            }
            case 2:
            {
                AddNewBook();
                break;

            }
            case 3:
            {
                DeletingBook();
                break;
            }
            case 0:
            default:
            {
                return false;
            }
        }
        return true;
    }

    private static void RetrievingAllBooks(BookRepo br)
    {
        //gets all books in storage
        List<Book> books = br.GetAllBooks();
        //Displays list of all books at location
        System.Console.WriteLine("Here are the books located at this library:");
        foreach(Book b in books)
        {
            System.Console.WriteLine(b);
        }

    }
     private static void RetrievingAllLocations()
    {
        //gets all locations in storage
        List<Location> locations = ls.GetAllLocations();
        //Displays list of all locations
        System.Console.WriteLine("Here are all of the locations containing your book");
        foreach(Location l in locations)
        {
            System.Console.WriteLine(l);
        }

    }
    private static void DeletingLocation(LocationRepo lr)
    {
        //pick a location w/ id and retrieve the location
        //remove location from storage
        Location location = PromptUserForLocation(lr);
        Console.WriteLine("Deleted Location: " + lr.DeleteLocation(location));
    }

    private static void UpdatingLocation(LocationRepo lr)
    {
          //pick a book ->ask for an id of a book-> retrieve the movie with that id
        Location location = PromptUserForLocation(lr);
        //let the user update some fields
        System.Console.WriteLine("Please provide a new Street address:");
        location.StreetAddress = (Console.ReadLine()?? "");
        //can add more steps to update more values

        //save the changed values to storage
        Console.WriteLine("Updated Location: " + lr.UpdateLocation(location));
    }

    private static void DeletingBook()
    {
        //pick a book w/ id and retrieve the book
        //remove book from storage
        Book book = PromptUserForBook();
        Console.WriteLine("You just removed " + book.Title + " from the library");
    }

    private static void UpdatingBook(BookRepo br)
    {
        //pick a book ->ask for an id of a book-> retrieve the movie with that id
        Book book = PromptUserForBook();
        //let the user update some fields
        System.Console.WriteLine("Please provide a new Title:");
        book.Title = (Console.ReadLine()?? "");
        //can add more steps to update more values

        //save the changed values to storage
        Console.WriteLine("Updated Book: " + br.UpdateBook(book));

    }

    private static void RetrievingLocation(LocationRepo lr)
    {
          //retrieving book that exists
        //have to make assumption that user knows what id works

        //Code to handle input validation
        Location? retrievedLocation = null;
        while (retrievedLocation == null)
        {
            System.Console.WriteLine("Please enter location ID:");
            int input = int.Parse(Console.ReadLine() ?? "0");
            retrievedLocation = lr.GetLocation(input);

        }
        System.Console.WriteLine("Location: " + retrievedLocation);
    }

    private static void AddingNewLocation(LocationRepo lr)
    {
        System.Console.WriteLine("Register your library with us!");
        System.Console.WriteLine("Please provide your street address");
        string streetAddress = (Console.ReadLine()??"");

        System.Console.WriteLine("Please provide the postal code for your libaray.");
        string postalCode = (Console.ReadLine()??"");

        System.Console.WriteLine("Please provide an email address where you can be contacted");
        string emailAddress = (Console.ReadLine()??"");

        Location location = new(0, "Liz", "Bowman", streetAddress, "Fredericksburg", "VA", postalCode, emailAddress);
        location = lr.AddLocation(location);

        System.Console.WriteLine("Congratulations!  Your library has been added to our registry!");
    }

    private static void AddNewBook()
    {
        System.Console.WriteLine("Please provide the title of the book you'd like to add");
        string title = (Console.ReadLine()?? "");

        System.Console.WriteLine("Who's the author of the book?");
        string author = (Console.ReadLine()?? "0");

        //assume that fiction will default to true
        //not going to ask for id- book repo AddBook()gives next correct value for id
        //collect info into new Book Object
        //enter arguments for constructor
        Book book = new(0, title, author, true, null);

        //use BookRepo to add new book into data storage
        book = bs.AddNewBook(book); //using book variable to store updated values from AddBook() process

        //inform user of newly added book
        System.Console.WriteLine("You just added " + book.Title + " to the library!");
    }

    private static void RetrievingBook(BookRepo br)
    {
        //retrieving book that exists
        //have to make assumption that user knows what id works

        //Code to handle input validation
       Book retrievedBook = PromptUserForBook();
        //leaving loop indicates have  picked valid book

        //showcases book that was retrieved
        System.Console.WriteLine("Retrieved Book: " + retrievedBook);
    }
    private static Book PromptUserForBook()
    {
        Book? retrievedBook = null;
        while (retrievedBook == null)
        {
            System.Console.WriteLine("Please enter book ID:");
            int input = int.Parse(Console.ReadLine() ?? "0");
            retrievedBook = bs.GetBook(input);

        }
        return retrievedBook;
    }
     private static Location PromptUserForLocation(LocationRepo lr)
    {
        Location? retrievedLocation = null;
        while (retrievedLocation == null)
        {
            System.Console.WriteLine("Please enter location ID:");
            int input = int.Parse(Console.ReadLine() ?? "0");
            retrievedLocation = lr.GetLocation(input);

        }
        return retrievedLocation;
    }
}
