using Microsoft.Data.SqlClient;

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
 private readonly string _connectionString;
    //Dependency Injection -> Constructor Injection
    public BookRepo(string connString)
    {
        _connectionString = connString;
    }

public Book AddBook(Book b)
{
   //Set up DB connection  
      using SqlConnection  connection = new(_connectionString);
      connection.Open();  
      //Create the SQL string  
      string sql = "INSERT INTO dbo.Books OUTPUT inserted.* VALUES (@Title, @Author, @Fiction)";
      //set up SqlCommand Object and use its methods to modify the Parameterized values
      using SqlCommand cmd = new(sql, connection);
      cmd.Parameters.AddWithValue("@Title", b.Title);
      cmd.Parameters.AddWithValue("@Author", b.Author);
      cmd.Parameters.AddWithValue("@Fiction", b.Fiction);

       //Execute the query 
      //cmd.ExecuteNonQuery();// executes a non-select SQL statement(inserts, updates, deletes)
      using SqlDataReader reader = cmd.ExecuteReader();

      //Extract the results
      if(reader.Read())
      {
        //if Read() found data, then extract it
        Book newBook = BuildUser(reader);

        return newBook;

      }
      else
      {
        //else Read() found nothing -> Insert failed
        return null;
      }
      
}

public Book? GetBook(int id)
{
   try
        {
            //Set up DB Connection
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            //Create the SQL String
            string sql = "SELECT * FROM dbo.Books WHERE Id = @Id";

            //Set up SqlCommand Object
            using SqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@Id", id);

            //Execute the Query
            using var reader = cmd.ExecuteReader();

            //Extract the Results
            if (reader.Read())
            {
                //for each iteration -> extract the results to a User object -> add to list.
                Book newBook = BuildUser(reader);
                return newBook;
            }

            return null; //Didnt find anyone :(

        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return null;
        }

}
//method to return all books
public List<Book> GetAllBooks()
{
   List<Book> books = [];
         try
         {
            //set up DB connection
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            //Create the SQL string
            string sql = "SELECT * FROM dbo.Books";

            //Set up SqlCommand Object
            using SqlCommand cmd = new(sql, connection);

            //Execute the query
            using var reader = cmd.ExecuteReader(); //flexing options here with use of var

            //Extract the results
            while(reader.Read())
            {
                Book newBook = BuildUser(reader);
                //don't return- instead add to list
                books.Add(newBook);

            }
            return books;
         }
         
    
         catch (Exception e)
         {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return null;
         }
}

public Book? UpdateBook(Book updatedBook)
{
    try
    {
  //Set up DB connection  
      using SqlConnection  connection = new(_connectionString);
      connection.Open();  
      //Create the SQL string  
      string sql = "UPDATE dbo.Books SET Title = @Title, Author = @Author, Fiction = @Fiction OUTPUT inserted.* WHERE Id = @Id";;
      //set up SqlCommand Object and use its methods to modify the Parameterized values
      using SqlCommand cmd = new(sql, connection);
      cmd.Parameters.AddWithValue("@Title", updatedBook.Title);
      cmd.Parameters.AddWithValue("@Author", updatedBook.Author);
      cmd.Parameters.AddWithValue("@Fiction", updatedBook.Fiction);

       //Execute the query 
      //cmd.ExecuteNonQuery();// executes a non-select SQL statement(inserts, updates, deletes)
      using var reader = cmd.ExecuteReader();

      //Extract the results
        if (reader.Read())
        {
                //for each iteration -> extract the results to a User object -> add to list.
            Book newBook = BuildUser(reader);
            return newBook;
        }
        return null;
    }
      catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return null;
        }
    
}

public Book? DeleteBook(Book b)
{
        //if have the ID-> remove book from storage
   try
        {
            //Set up DB Connection
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            //Create the SQL String
            string sql = "DELETE FROM dbo.Books OUTPUT deleted.* WHERE Id = @Id";

            //Set up SqlCommand Object
            using SqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@Id", b.Id);

            //Execute the Query
            using var reader = cmd.ExecuteReader();

            //Extract the Results
            if (reader.Read())
            {
                //for each iteration -> extract the results to a User object -> add to list.
                Book newBook = BuildUser(reader);
                return newBook;
            }

            return null; //Didnt find anyone :(

        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return null;
        }
}

   private static Book BuildUser(SqlDataReader reader)
    {
        //for each iteration -> extract the results to a user object -> add to list
        Book newBook = new();
        newBook.Id = (int)reader["Id"];
        newBook.Title = (string)reader["Title"];
        newBook.Author = (string)reader["Author"];
        newBook.Fiction = (bool)reader["Fiction"];
        

        return newBook;
    }


}