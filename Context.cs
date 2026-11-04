/* Context class to hold all context relevant to a session.
 */

class Context {
  Space current;
  bool done = false;
  public Inventory inventory = new Inventory(); 
  
  public Context (Space node) {
    current = node;
  }
  
  public Space GetCurrent() {
    return current;
  }

  public Inventory GetInventory() {
      return inventory;
  }
  
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
  
  public void MakeDone () {
    done = true;
  }
  
  public bool IsDone () {
    return done;
  }
}

