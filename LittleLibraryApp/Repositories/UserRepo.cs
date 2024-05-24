using Microsoft.Data.SqlClient;

class UserRepo
{
    private readonly string _connectionString;
    //Dependency Injection -> Constructor Injection
    public UserRepo(string connString)
    {
        _connectionString = connString;
    }
    //add, get-one, get-all, update, and delete
    public User? AddUser(User u)
    {
      //Set up DB connection  
      using SqlConnection  connection = new(_connectionString);
      connection.Open();  
      //Create the SQL string  
      string sql = "INSERT INTO dbo.[User] OUTPUT inserted.* VALUES (@Username, @Password, @Role)";
      //set up SqlCommand Object and use its methods to modify the Parameterized values
      using SqlCommand cmd = new(sql, connection);
      cmd.Parameters.AddWithValue("@Username", u.Username);
      cmd.Parameters.AddWithValue("@Password", u.Password);
      cmd.Parameters.AddWithValue("@Role", u.Role);

       //Execute the query 
      //cmd.ExecuteNonQuery();// executes a non-select SQL statement(inserts, updates, deletes)
      using SqlDataReader reader = cmd.ExecuteReader();

      //Extract the results
      if(reader.Read())
      {
        //if Read() found data, then extract it
        User newUser = BuildUser(reader);

        return newUser;

      }
      else
      {
        //else Read() found nothing -> Insert failed
        return null;
      }
      
    }
    public User? GetUser(int id)
    {
         try
        {
            //Set up DB Connection
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            //Create the SQL String
            string sql = "SELECT * FROM dbo.[User] WHERE Id = @Id";

            //Set up SqlCommand Object
            using SqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@Id", id);

            //Execute the Query
            using var reader = cmd.ExecuteReader();

            //Extract the Results
            if (reader.Read())
            {
                //for each iteration -> extract the results to a User object -> add to list.
                User newUser = BuildUser(reader);
                return newUser;
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
    public List <User> GetAllUsers()
    {
        List<User> users = [];
         try
         {
            //set up DB connection
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            //Create the SQL string
            string sql = "SELECT * FROM dbo.[User]";

            //Set up SqlCommand Object
            using SqlCommand cmd = new(sql, connection);

            //Execute the query
            using var reader = cmd.ExecuteReader(); //flexing options here with use of var

            //Extract the results
            while(reader.Read())
            {
                User newUser = BuildUser(reader);
                //don't return- instead add to list
                users.Add(newUser);

            }
            return users;
         }
         
    
         catch (Exception e)
         {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return null;
         }
    }

  

    public User? UpdateUser(User updatedUser)
    {
        try
        {
            //Set up DB Connection
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            //Create the SQL String
            string sql = "UPDATE dbo.[User] SET Username = @Username, Password = @Password, Role = @Role OUTPUT inserted.* WHERE Id = @Id";

            //Set up SqlCommand Object
            using SqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@Id", updatedUser.Id);
            cmd.Parameters.AddWithValue("@Username", updatedUser.Username);
            cmd.Parameters.AddWithValue("@Password", updatedUser.Password);
            cmd.Parameters.AddWithValue("@Role", updatedUser.Role);

            //Execute the Query
            using var reader = cmd.ExecuteReader();

            //Extract the Results
            if (reader.Read())
            {
                //for each iteration -> extract the results to a User object -> add to list.
                User newUser = BuildUser(reader);
                return newUser;
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
    public User? DeleteUser(User u)
    {
         
        try
        {
            //Set up DB Connection
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            //Create the SQL String
            string sql = "DELETE FROM dbo.[User] OUTPUT deleted.* WHERE Id = @Id";

            //Set up SqlCommand Object
            using SqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@Id", u.Id);

            //Execute the Query
            using var reader = cmd.ExecuteReader();

            //Extract the Results
            if (reader.Read())
            {
                //for each iteration -> extract the results to a User object -> add to list.
                User newUser = BuildUser(reader);
                return newUser;
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

    //Helper method
     private static User BuildUser(SqlDataReader reader)
    {
        //for each iteration -> extract the results to a user object -> add to list
        User newUser = new();
        newUser.Id = (int)reader["Id"];
        newUser.Username = (string)reader["Username"];
        newUser.Password = (string)reader["Password"];
        newUser.Role = (string)reader["Role"];

        return newUser;
    }
}