/* Context class to hold all context relevant to a session.
 */

class Context {
  private Space current;
  private bool done = false;
  public string EndingMessage{get; private set;} = "Game Over 😥";
  public int RoomsCompleted { get; private set; }
  private Inventory inventory = new Inventory(); 
  
  public Context (Space node) {
    current = node;
  }

  //Getters and setters
  public Space GetCurrent() {
    return current;
  }

  public Inventory GetInventory() {
      return inventory;
  }

  public void IncrementRooms() {
      RoomsCompleted++;
  }

  //Transition between rooms
  public void Transition (string direction) {
    Space next = current.FollowEdge(direction);
    if (next==null) {
      Console.WriteLine("You are confused, and walk in a circle looking for '"+direction+"'. In the end you give up 😩");
    } else {
      Console.Clear();
      current.Goodbye();
      current = next;
      current.Welcome();
      }
    }

    //Method to call when all rooms are completed
    public void GameComplete () {
        double completescore = inventory.CalculateScore();
        Console.WriteLine("Your total score is: " + Math.Round(completescore, 1));
        if (completescore<15.5) {
            Console.WriteLine("That means you are a CLIMATE FORERUNNER");
            EndingMessage = "The Game has been Completed"; //Gives the player the "nice to have" of a different ending message depending on score
        } else if (completescore>20) {
            Console.WriteLine("That means you are an AVERAGE CONSUMER");
        } else {
            Console.WriteLine("That means you are CLIMATE CONSCIOUS");
        }

        double savedTons = Math.Round(inventory.CalculateSavedCO2(), 1);
        
        Console.WriteLine();
        Console.WriteLine("The amount of saved tons of CO2e pr year if a percentage of the danish population did as you:");
        Console.WriteLine($"If 100% did as you: {savedTons:N0} tons CO2e");
        Console.WriteLine($"If 50% did as you: {savedTons*0.5:N0} tons CO2e");
        Console.WriteLine($"If 20% did as you: {savedTons*0.20:N0} tons CO2e");
        Console.WriteLine();
        Console.WriteLine("A recap of the choices made:");
        inventory.GetItems();
        done = true;
    }
  
  public void MakeDone () {
    done = true;
  }
  
  public bool IsDone () {
    return done;
  }
}

