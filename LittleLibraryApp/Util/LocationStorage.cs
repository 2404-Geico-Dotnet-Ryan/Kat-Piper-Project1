class LocationStorage
{
     public Dictionary<int, Location> locations;
    public int idCounter = 1;
    public LocationStorage() //inventory of library locations
    {
        Location location1 = new(idCounter, "Kat", "Piper", "1411 Buckner Street", "Fredericksburg", "VA", "22401", "kpiper@gmail.com" ); idCounter++;
        Location location2 = new(idCounter, "Liz", "Belcher", "1018 Rappahannock Avenue", "Fredericksburg", "VA", "22401", "LBelcher@gmail.com"); idCounter++;
        Location location3 = new(idCounter, "Seth", "Smith", "917 Sylvania Avenue", "Fredericksburg", "VA", "22401", "SSmith@gmail.com"); idCounter++;
        Location location4 = new(idCounter, "Juliet", "Brown", "311 Lee Avenue", "Fredericksburg", "VA", "22401", "JBrown@gmail.com" ); idCounter++;

        locations= []; //sets dictionary to empty collection
        locations.Add(location1.Id, location1);//adds movie to the dictionary
        locations.Add(location2.Id, location2);
        locations.Add(location3.Id, location3); //alternative more proper syntax
        locations.Add(location4.Id, location4);
    }
}