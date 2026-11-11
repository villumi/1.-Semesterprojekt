/* Context class to hold all context relevant to a session.
 */

class Context {
  private Space current;
  private bool done = false;
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
            Console.WriteLine("That means you are an CLIMATE FORERUNNER");
        } else if (completescore>20) {
            Console.WriteLine("That means you are an AVERAGE CONSUMER");
        } else {
            Console.WriteLine("That means you are a CLIMATE CONSCIOUS");
        }
        done = true;
    }
  
  public void MakeDone () {
    done = true;
  }
  
  public bool IsDone () {
    return done;
  }
}

