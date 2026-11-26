/* Main class for launching the game
 */

class Game {
  static World    world    = new World();
  static Context  context  = new Context(world.GetEntry());
  
  static void Main (string[] args) {
    Console.Clear();
    Console.WriteLine("Welcome to the Climate GO-GETTERS!");
    Console.WriteLine("Here are the commands:");
    Console.WriteLine(" - exit  Exit the program");
    Console.WriteLine(" - quit  Exit the program");
    Console.WriteLine(" - bye   Exit the program");
    Console.WriteLine(" - go 'room name'  Follow an exit");
    Console.WriteLine(" - 1,2,3 Choose an option");
    Console.WriteLine(" - help  Display a help message");
    Console.WriteLine("");
    Console.WriteLine("Press Enter to continue");
    while (true){
        Console.ReadLine();
        break;
    }
    context.GetCurrent().Welcome();
    
    while (context.IsDone()==false) {
      Console.Write("> ");
      string? line = Console.ReadLine();
      if (line==null) continue;
      line=line.ToLower();
      // parse line
      string[] elements = line.Split(" ");
      string command = elements[0];
      string[] parameters = GetParameters(elements);
      if(int.TryParse(command, out int choice)) {
          Item? chosen = context.GetCurrent().FindItem(choice);
          if(chosen!=null)
          {
              if (context.GetCurrent().HaveCompleted) {
                  Console.WriteLine("No choices left to make here");
                } else {
                Console.Clear();
                chosen.roomName = context.GetCurrent(). GetName();
                context.GetInventory().AddItemToInventory(chosen);
                Console.WriteLine("You chose " + chosen.Name);
                context.GetCurrent().Complete(chosen);
                context.IncrementRooms();
                //Checks if rooms completed is equal to total rooms
                if (context.RoomsCompleted == Space.TotalRooms) {
                    //Calls the gamecomplete method
                    context.GameComplete();
                }
              }
          }
          else
          {
              Console.WriteLine("That is not a option?");
          }
      } else {
      switch (command) {
        case "exit":
        case "quit":
        case "bye":
          context.MakeDone();
          break;
        case "go":
          if (context.GetCurrent().HaveCompleted) {
            if (parameters.Length!=1) {
                Console.WriteLine("I don't seem to know where that is 🤔");
                break; //Changed a return to a break (return closed the game)
            }
            try {
                context.Transition(parameters[0]);
            } catch (KeyNotFoundException) {
                Console.WriteLine("You cannot enter there.");
            }
          } else {
            Console.WriteLine("You haven't completed the room yet");
          }
          break;
        case "help":
          Console.WriteLine(" - exit  Exit the program");
          Console.WriteLine(" - quit  Exit the program");
          Console.WriteLine(" - bye   Exit the program");
          Console.WriteLine(" - go    Follow an exit");
          Console.WriteLine(" - 1,2,3 Choose an option");
          Console.WriteLine(" - help  Display a help message");
          break;
        case "complete": //remove, made to check functionality of completing player choice. 
          Console.WriteLine("Auto completed room");
          context.GetCurrent().Complete();
          //Incremeants rooms completed variable when a room is completed
          context.IncrementRooms();
          //Checks if rooms completed is equal to total rooms
          if (context.RoomsCompleted == Space.TotalRooms) {
              //Calls the gamecomplete method
              context.GameComplete();
          }
          break;
        default:
          Console.WriteLine("Woopsie, I don't understand '"+command+"' 😕");
          break;
      }
    }
    }
    Console.WriteLine("");
    Console.WriteLine(context.EndingMessage); //EndingMessage is displayed at the end
  }
  
  private static string[] GetParameters (string[] input) {
    string[] output = new string[input.Length-1];
    for (int i=0 ; i<output.Length ; i++) {
      output[i] = input[i+1];
    }
    return output;
  }
}
