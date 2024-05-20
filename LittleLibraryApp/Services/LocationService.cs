class LocationService
{

LocationRepo lr = new();

public List<Location> GetAllLocations()
{
    List<Location> allLocations = lr.GetAllLocations();
    return allLocations;

}




}