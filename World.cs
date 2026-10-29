/* World class for modeling the entire in-game world
 */

class World {
  Space entry;
  
  public World () {
    Space room    = new Space("Room");
    Space home = new Space("Home");
    Space garden = new Space("Garden");
    Space garage = new Space("Garage");
    Space driveway     = new Space("Driveway");
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
  }
  
  public Space GetEntry () {
    return entry;
  }
}

