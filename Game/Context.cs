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
      PrintStickyNote();
      }
    }

    //Method to call when all rooms are completed
    public void GameComplete () {
        double completescore = inventory.CalculateScore();
        Console.WriteLine("Your total score is: " + Math.Round(completescore, 1));
        if (completescore<15.5) {
            Console.WriteLine("That means you are a CLIMATE FORERUNNER");
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
        Console.WriteLine("A recap of your descisions:");
        inventory.GetItems();
        Console.WriteLine();
        done = true;
    }

    public void PrintStickyNote()
    {
      string[] items =
      {
          "Go to work",
          "Eat dinner",
          "Mow the grass",
          "Go shopping",
          "Buy groceries"
      };
      int previousLeft = Console.CursorLeft;
      int previousTop = Console.CursorTop;
      int noteWidth = 25;
      int left = Math.Max(0, Console.WindowWidth - noteWidth - 2);
      int top = Math.Max(0, Console.WindowHeight - items.Length - 6);

      string border = "+" + new string('-', noteWidth - 2) + "+";

      Console.SetCursorPosition(left, top);
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine(border);

      Console.SetCursorPosition(left, top + 1);
      Console.WriteLine("|       MY TO-DO LIST   |");

      Console.SetCursorPosition(left, top + 2);
      Console.WriteLine(border);

      Console.ForegroundColor = ConsoleColor.White;

      for (int i = 0; i < items.Length; i++)
      {
          Console.SetCursorPosition(left, top + 3 + i);
          Console.WriteLine($"| {i + 1}. {items[i],-19}|");
      }

      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.SetCursorPosition(left, top + 3 + items.Length);
      Console.WriteLine(border);

      Console.ResetColor();
      Console.SetCursorPosition(previousLeft, previousTop);
    }
  
  public void MakeDone () {
    done = true;
  }
  
  public bool IsDone () {
    return done;
  }
}

