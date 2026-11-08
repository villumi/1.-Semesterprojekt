/* Context class to hold all context relevant to a session.
 */

class Context {
  private Space current;
  private bool done = false;
  public int roomsCompleted { get; private set; }
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
      roomsCompleted++;
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
        Console.WriteLine("Congratulations you have completed every room!");
        Console.WriteLine("You picked up these items");
        inventory.GetItems();
        Console.WriteLine("Your total score is: " + inventory.CalculateScore());
        done = true;
    }
  
  public void MakeDone () {
    done = true;
  }
  
  public bool IsDone () {
    return done;
  }
}

