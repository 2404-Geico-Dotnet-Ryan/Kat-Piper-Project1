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
LocationStorage locationStorage = new();

public Location AddLocation(Location l)
{
    //movie being added needs correct id
    //assume it doesn't and force it to by using idCounter
    l.Id = locationStorage.idCounter++;//increments value aftwards to prep for next time it's needed

    //add book into collection
    locationStorage.locations.Add(l.Id, l);
    return l;
}

public Location? GetLocation(int id)
{
    if(locationStorage.locations.ContainsKey(id))
    {
        Location selectedLocation = locationStorage.locations[id]; //uses id to find and retrieve entire book
        return selectedLocation;
    }
    else
    {
        return null;
    }
}



}