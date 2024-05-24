using Microsoft.Data.SqlClient;

class LocationRepo
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
    public LocationRepo(string connString)
    {
        _connectionString = connString;
    }


public Location AddLocation(Location l)
{
    //Set up DB connection  
      using SqlConnection  connection = new(_connectionString);
      connection.Open();  
      //Create the SQL string  
      string sql = "INSERT INTO dbo.Locations OUTPUT inserted.* VALUES (@FirstName, @LastName, @StreetAddress, @City, @State, @PostalCode, @EmailAddress)";
      //set up SqlCommand Object and use its methods to modify the Parameterized values
      using SqlCommand cmd = new(sql, connection);
      cmd.Parameters.AddWithValue("@FirstName", l.FirstName);
      cmd.Parameters.AddWithValue("@LastName", l.LastName);
      cmd.Parameters.AddWithValue("@StreetAddress", l.StreetAddress);
      cmd.Parameters.AddWithValue("@City", l.City);
      cmd.Parameters.AddWithValue("@State", l.State);
      cmd.Parameters.AddWithValue("@PostalCode", l.PostalCode);
      cmd.Parameters.AddWithValue("@EmailAddress", l.EmailAddress);

       //Execute the query 
      //cmd.ExecuteNonQuery();// executes a non-select SQL statement(inserts, updates, deletes)
      using SqlDataReader reader = cmd.ExecuteReader();

      //Extract the results
      if(reader.Read())
      {
        //if Read() found data, then extract it
        Location newLibrary = BuildUser(reader);

        return newLibrary;

      }
     return new Location();
}

public Location GetLocation(int id)
{
     try
        {
            //Set up DB Connection
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            //Create the SQL String
            string sql = "SELECT * FROM dbo.Locations WHERE Id = @Id";

            //Set up SqlCommand Object
            using SqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@Id", id);

            //Execute the Query
            using var reader = cmd.ExecuteReader();

            //Extract the Results
            if (reader.Read())
            {
                //for each iteration -> extract the results to a User object -> add to list.
                Location newLocation = BuildUser(reader);
                return newLocation;
            }

            return new Location(); //Didnt find anyone :(

        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return new Location();
        }
}


public List<Location> GetAllLocations()
{
     List<Location> locations = new List<Location>();
        try
        {
            //set up DB connection
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            //Create the SQL string
            string sql = "SELECT * FROM dbo.Locations";

            //Set up SqlCommand Object
            using SqlCommand cmd = new(sql, connection);

            //Execute the query
            using var reader = cmd.ExecuteReader(); //flexing options here with use of var

            //Extract the results
            while(reader.Read())
            {
                Location newLocation = BuildUser(reader);
                //don't return- instead add to list
                locations.Add(newLocation);

            }
            return locations;
        }
         
    
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return new List<Location> ();
        }
}
public Location UpdateLocation(Location updatedLocation)
{
    try
        {
            //Set up DB Connection
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            //Create the SQL String
            string sql = "UPDATE dbo.Locations SET FirstName = @FirstName, LastName = @LastName, StreetAddress = @StreetAddress, City = @City, State = @State, PostalCode = @PostalCode, EmailAddress = @EmailAddress OUTPUT inserted.* WHERE Id = @Id";

            //Set up SqlCommand Object
            using SqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@Id", updatedLocation.Id);
            cmd.Parameters.AddWithValue("@FirstName", updatedLocation.FirstName);
            cmd.Parameters.AddWithValue("@LastName", updatedLocation.LastName);
            cmd.Parameters.AddWithValue("@StreetAddress", updatedLocation.StreetAddress);
            cmd.Parameters.AddWithValue("@City", updatedLocation.City);
            cmd.Parameters.AddWithValue("@State", updatedLocation.State);
            cmd.Parameters.AddWithValue("@PostalCode", updatedLocation.PostalCode);
            cmd.Parameters.AddWithValue("@EmailAddress", updatedLocation.EmailAddress);

            //Execute the Query
            using var reader = cmd.ExecuteReader();

            //Extract the Results
            if (reader.Read())
            {
                //for each iteration -> extract the results to a User object -> add to list.
                Location newLocation = BuildUser(reader);
                return newLocation;
            }

            return new Location(); //Didnt find anyone :(

        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return new Location();
        }
    
}

public Location DeleteLocation(Location l)
{
        //if have the ID-> remove book from storage
      try
        {
            //Set up DB Connection
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            //Create the SQL String
            string sql = "DELETE FROM dbo.Locations OUTPUT deleted.* WHERE Id = @Id";

            //Set up SqlCommand Object
            using SqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@Id", l.Id);

            //Execute the Query
            using var reader = cmd.ExecuteReader();

            //Extract the Results
            if (reader.Read())
            {
                //for each iteration -> extract the results to a User object -> add to list.
                Location newLocation = BuildUser(reader);
                return newLocation;
            }

            return new Location(); //Didnt find anyone :(

        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return new Location();
        }
}
 private static Location BuildUser(SqlDataReader reader)
    {
        //for each iteration -> extract the results to a user object -> add to list
        Location newLocation = new();
        newLocation.Id = (int)reader["Id"];
        newLocation.FirstName = (string)reader["FirstName"];
        newLocation.LastName = (string)reader["LastName"];
        newLocation.StreetAddress = (string)reader["StreetAddress"];
        newLocation.City = (string)reader["City"];
        newLocation.State = (string)reader["State"];
        newLocation.PostalCode = (string)reader["PostalCode"];
        newLocation.EmailAddress = (string)reader["EmailAddress"];

        return newLocation;
    }

   
}