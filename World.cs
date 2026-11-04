/* World class for modeling the entire in-game world
 */

class World {
  Space entry;
  //intialize total rooms (this is a bit inconvinient to track total rooms like this but was the only way i could find around adding all the spaces into list and looping through them)
  public int totalRooms = 8;
  //tracks rooms completed
  public int roomsCompleted;
  
  public World () {
    Space room    = new Space("Room", "Der er en nøgle, du kan samle den op ved at skrive 'interact'");
    Space home = new Space("Home", "Something 1");
    Space garden = new Space("Garden");
    Space garage = new Space("Garage");
    Space driveway     = new Space("Driveway", "Choose method of transport:");
    Space workplace      = new Space("Workplace");
    Space supermarket  = new Space("Supermarket");
    Space shopping  = new Space("Shopping");

    room.AddEdge("home", home);
    home.AddEdge("room", room);
    home.AddEdge("driveway", driveway);
    home.AddEdge("garden", garden);
    home.AddEdge("garage", garage);
    garden.AddEdge("home", home);
    garage.AddEdge("home", home);
    garage.AddEdge("driveway", driveway);
    driveway.AddEdge("home", home);
    driveway.AddEdge("garage", garage);
    driveway.AddEdge("workplace", workplace);
    driveway.AddEdge("supermarket", supermarket);
    driveway.AddEdge("shopping", shopping);
    workplace.AddEdge("driveway", driveway);
    workplace.AddEdge("shopping", shopping);
    workplace.AddEdge("supermarket", supermarket);
    shopping.AddEdge("driveway", driveway);
    shopping.AddEdge("supermarket", supermarket);
    supermarket.AddEdge("driveway", driveway);
    supermarket.AddEdge("shopping", shopping);
    
    this.entry = home;

    //creating items
    Item car = new Item("car",5000);
    Item bicycle = new Item("bicycle", -5000);
    Item bus = new Item("bus",-100);
    
    //adding items to spaces
    driveway.AddItem(car);
    driveway.AddItem(bicycle);
    driveway.AddItem(bus);
    
    
  }
  
  public Space GetEntry () {
    return entry;
  }
}

