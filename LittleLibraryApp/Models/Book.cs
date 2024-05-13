class Book
{
public int Id { get; set; }
public string Title { get; set; }
public string Author { get; set; }
public bool Fiction { get; set; }

public Book()
{
    Title = "";
}


public Book(int id, string title, string author, bool fiction)
{

	Id = id;
	Title = title;
	Author = author;
	Fiction = fiction;
}

public override string ToString()
{
	return "{'ID':" + Id
	+ ", 'Title':"
	+ Title + " ,Author:"
	+ Author + ",Fiction: "
	+ Fiction + "}";
}
}    