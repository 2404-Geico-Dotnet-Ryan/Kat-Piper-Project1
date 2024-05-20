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
    //location being added needs correct id
    //assume it doesn't and force it to by using idCounter
    l.Id = locationStorage.idCounter++;//increments value aftwards to prep for next time it's needed

    //add location into collection
    locationStorage.locations.Add(l.Id, l);
    return l;
}

public Location? GetLocation(int id)
{
    if(locationStorage.locations.ContainsKey(id))
    {
        Location selectedLocation = locationStorage.locations[id]; //uses id to find and retrieve entire locations
        return selectedLocation;
    }
    else
    {
        return null;
    }
}


public List<Location> GetAllLocations()
{
    return locationStorage.locations.Values.ToList();
}
public Location? UpdateLocation(Location updatedLocation)
{
    //assuming ID is consistent with an ID that exists
    //just have to update value (Book) for key (ID) within dictionary
    try
    {
    locationStorage.locations[updatedLocation.Id] = updatedLocation;
    return updatedLocation;//confirms storage has been updated w/ info sent back to user
    }
    catch(Exception)
    {
        System.Console.WriteLine("Invalid Location ID - Please try again");
        return null;
    }
    
}

public Location? DeleteLocation(Location l)
{
        //if have the ID-> remove book from storage
        bool didRemove = locationStorage.locations.Remove(l.Id);

        if (didRemove)
        {
            return l;
        }
    
        else
        {
            System.Console.WriteLine("Invalid Location ID - Please Try Again");
            return null;
        }
}





}