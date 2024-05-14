class UserRepo
{
    UserStorage userStorage = new();
    //add, get-one, get-all, update, and delete
    public User AddUser(User u)
    {
        u.Id = userStorage.idCounter++;
        userStorage.users.Add(u.Id, u);
        return u;
    }
    public User GetUser(int id)
    {
        if(userStorage.users.ContainsKey(id))
        {
            User selectedUser = userStorage.users[id];
            return selectedUser;
            //return movieStorage.movies[id]; - fancy approach to above code
        }
        else
        {
            System.Console.WriteLine("Invalid User ID - Please Try Again:");
            return null;
        }
    }
    public List <User> GetAllUsers()
    {
         return userStorage.users.Values.ToList();
    }
    public User UpdateUser(User updatedUser)
    {
           try 
        {
            userStorage.users[updatedUser.Id] = updatedUser;
        
            //choose to send updated movie back as a "response-feedback" system
            //conveys that i've updated the storage with this movie I send back to you
            return updatedUser;
        }
        catch(Exception e)
        {
            System.Console.WriteLine("Invalid User ID - Please Try Again");
            return null;
        }
    }
    public User DeleteUser(User u)
    {
         bool didRemove = userStorage.users.Remove(u.Id);
        if (didRemove)
        {
            //now we will return the movie that got deleted
            return u;
        }
       
        else
        {
            System.Console.WriteLine("Invalid Movie ID - Please Try Again");
            return null;
        }
    }
}