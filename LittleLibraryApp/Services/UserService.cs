class UserService
{
    UserRepo ur;
    public UserService(UserRepo ur)
    {
        this.ur = ur;
    }

    //Register
    public User? RegisterUser(User u)
    {
        //don't let them register if role is anything other than "user"
        if(u.Role != "user")
        {
            //reject them
            System.Console.WriteLine("Invalid Role - Please try again!");
            return null;
        }

        //let's not let them register if username is already taken
        //Get all users
        List<User> allUsers = ur.GetAllUsers()??[];
        foreach(User user in allUsers)
        {
            if(user.Username == u.Username)
            {
                //reject them
                System.Console.WriteLine("Username already taken.  Please try again");
                return null;
            }
        }
        //If make it this far, then role and username are good to go

        //if don't care about validation, this is simple service method
        return ur.AddUser(u);
    }

    //Login
    public User? LogInUser(string username, string password)
    {
        //Get all users
        List<User> allUsers = ur.GetAllUsers()??[];

        //check each one to see if we find a match
        foreach (User user in allUsers)
        {
            //if matching username and password, they 'login' -> return that user
            if(user.Username == username && user.Password == password)
            {
                //yay! login
                return user; //us returning user will indicate success
            }
        }
        //if make it this far- didn't find a match
        System.Console.WriteLine("Invalid username and/or password. Please try again");
        return null; //reject login
    }
}