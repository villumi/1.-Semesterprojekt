/* Main class for launching the game
 */

class Game {
  static World    world    = new World();
  static Context  context  = new Context(world.GetEntry());
  
  static void Main (string[] args) {
    Console.WriteLine("Welcome to the World of Zuul!");
    context.GetCurrent().Welcome();
    
    while (context.IsDone()==false) { //Running game code until IsDone is set to true
      Console.Write("> ");
      string? line = Console.ReadLine();
      if (line==null) continue;
      line=line.ToLower(); //Converts player input to all lower case

      // parse line
      string[] elements = line.Split(" ");
      string command = elements[0];
      string[] parameters = GetParameters(elements);
      
      switch (command) {
        case "exit":
        case "quit":
        case "bye":
          context.MakeDone();
          break;
        case "go":
          if (context.GetCurrent().GetHaveCompleted()) {
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
          Console.WriteLine(" - help  Display a help message");
          Console.WriteLine(" - choose choose a option");
          break;
        case "complete": //remove, made to check functionality of completing player choice. 
            if (context.GetCurrent().GetHaveCompleted()) {
                Console.WriteLine("No choices left to make here");
                break;
            }
            Console.WriteLine("Auto completed room");
            context.GetCurrent().Complete();
            //Incremeants rooms completed variable when a room is completed
            context.IncrementRooms();
            //Checks if rooms completed is equal to total rooms
            if (context.roomsCompleted == Space.totalRooms) {
                //Calls the gamecomplete method
                context.GameComplete();
            }
          break;
        case "choose":
            //Checks if choice has been made already
            if (context.GetCurrent().GetHaveCompleted()) {
                Console.WriteLine("No choices left to make here");
                break;
            }
            if (parameters.Length != 1) {
                    Console.WriteLine("I don't seem to know what that is 🤔");
                    break;
                }
            Item? chosen = context.GetCurrent().FindItem(parameters[0]); //loops through all items in the current space and assigns an item to chosen if it matches the given parameter
            
            if (chosen != null){
                Console.Clear(); //clears terminal 
                context.GetInventory().FetchItem(chosen); //Fetches item to players inventory
                Console.WriteLine("you chose "+parameters[0]);
                //Can add WriteLine here with information on choice, based on chosen. 
                context.GetCurrent().Complete();
                //Incremeants rooms completed variable when a room is completed
                context.IncrementRooms();
                //Checks if rooms completed is equal to total rooms
                if (context.roomsCompleted == Space.totalRooms) {
                    //Calls the gamecomplete method
                    context.GameComplete();
                }
                break;
            } else Console.WriteLine("You cannot choose "+parameters[0]);
            break;
        default:
          Console.WriteLine("Woopsie, I don't understand '"+command+"' 😕");
          break;
      }
    }
    Console.WriteLine("Game Over 😥");
  }
  
  private static string[] GetParameters (string[] input) {
    string[] output = new string[input.Length-1];
    for (int i=0 ; i<output.Length ; i++) {
      output[i] = input[i+1];
    }
    return output;
  }
}
