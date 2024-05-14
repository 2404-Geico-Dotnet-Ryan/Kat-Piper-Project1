class User
{
    public int Id { get; set; }
    public string Username { get; set;}

    public string Password { get; set; }

    public string Role { get; set; }

    public User()
    {
        Username = "";
        Password = "";
        Role = "";
    }

    public User(int id, string username, string password, string role)
    {
        Id = id;
        Username = username;
        Password = password;
        Role = role;
    }

    public override string ToString()
    {
        return "{id:" + Id 
        + ", username:'" + Username 
        + " ', password: '" + Password 
        + "', role:'" + Role + "'}";
    }
}