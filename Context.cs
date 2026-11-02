/* Context class to hold all context relevant to a session.
 */

class Context {
  Space current;
  bool done = false;
  
  public Context (Space node) {
    current = node;
  }
  
  public Space GetCurrent() {
    return current;
  }
  
  public void Transition (string direction) {
    //Sets the value of haveVisited to true before we transition to the next room
    current.haveVisited = true;
    Space next = current.FollowEdge(direction);
    if (next==null) {
      Console.WriteLine("You are confused, and walk in a circle looking for '"+direction+"'. In the end you give up 😩");
    } else {
      current.Goodbye();
      current = next;
      current.Welcome();
      //Prints haveVisited value for debugging can be deleted
      Console.WriteLine("haveVisited for : " + GetCurrent().GetName() + " is: " + GetCurrent().haveVisited);
      //Checks if the current room has been visited and prints a message if it has
      if (GetCurrent().haveVisited == true)
      {
        Console.WriteLine("This room has been visited there is nothing left to see");
      }
    }
  }
  
  public void MakeDone () {
    done = true;
  }
  
  public bool IsDone () {
    return done;
  }
}

