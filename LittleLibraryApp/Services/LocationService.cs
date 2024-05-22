class LocationService
{

LocationRepo lr = new();

public List<Location> GetAllLocations()
{
    List<Location> allLocations = lr.GetAllLocations();
    return allLocations;

}

public Location AddNewLocation(Location l)
{
    lr.AddLocation(l);
    return l;
}

public Location ChangeLocation(Location l)
{
    lr.UpdateLocation(l);
    return l;

}
public Location? GetLocation(int id)
{
    return lr.GetLocation(id);
    
}
 public Location RemoveLocation(Location l)
    {
        lr.DeleteLocation(l);
        return l; //sends back removed movie
        
    }




}