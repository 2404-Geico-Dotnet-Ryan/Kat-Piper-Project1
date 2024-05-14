class Location

{
public int Id { get; set; }
public string FirstName { get; set; }
public string LastName { get; set; }
public string StreetAddress { get; set; }
public string City { get; set; }
public string State { get; set; }
public string  PostalCode { get; set; }
public string EmailAddress { get; set; }

public Location()
{
	FirstName = "";
	LastName = "";
	StreetAddress = "";
	City = "";
	State = "";
	PostalCode = "";
	EmailAddress = "";
}
public Location(int id, string firstName, string lastName, string streetAddress, string city, string state, string postalCode, string emailAddress)
{
	Id = id;
	FirstName = firstName;
	LastName = lastName;
	StreetAddress = streetAddress;
	City = city;
	State = state;
	PostalCode = postalCode;
	EmailAddress = emailAddress;
}
public override string ToString()
{
	return "{'id':" + Id
	+ ", 'First Name':"
	+ FirstName + ", 'Last Name':"
	+ LastName + ", 'Address':"
	+ StreetAddress + ", 'City':"
	+ City + ", 'State':"
	+ State + ", 'Zip Code':"
	+ PostalCode + ", 'Email Address':"
	+ EmailAddress + "}";
}





}