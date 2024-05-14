class UserStorage
{
      public  Dictionary<int, User> users;
    public int idCounter = 1;

    public UserStorage()
    {
        User user1 = new(idCounter, "ryan", "pass", "user"); idCounter++;
        User user2 = new(idCounter, "jonathan", "pass2", "user"); idCounter++;
        User user3 = new(idCounter, "admin", "pass3", "admin"); idCounter++;

        users = [];
        users.Add(user1.Id, user1);
        users.Add(user2.Id, user2);
        users.Add(user3.Id, user3);
    }
}