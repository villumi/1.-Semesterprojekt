/* Main class for launching the game
 */

class Game {
  static World    world    = new World();
  static Context  context  = new Context(world.GetEntry());
  
  static void Main (string[] args) {
    Console.WriteLine("Welcome to the World of Zuul!");
    Console.WriteLine(world.totalRooms);
    
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
      
      switch (command) {
        case "exit":
        case "quit":
        case "bye":
          context.MakeDone();
          break;
        case "go":
          if (context.GetCurrent().haveCompleted) {
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
          break;
        case "complete": //remove, made to check functionality of completing player choice. 
          Console.WriteLine("Auto completed room");
          context.GetCurrent().Complete();
          //Incremeants rooms completed variable when a room is completed
          world.roomsCompleted++;
          //Checks if rooms completed is equal to total rooms
          if (world.roomsCompleted == world.totalRooms) {
              //Calls the gamecomplete method
              context.GameComplete();
          }
          break;
        case "choose":
            //Checks if choice has been made already
            if (context.GetCurrent().haveCompleted) {
                Console.WriteLine("No choices left to make here");
                break;
            }
            if (parameters.Length != 1) {
                    Console.WriteLine("I don't seem to know what that is 🤔");
                    break;
                }
            Item? chosen = null; //variable to hold players chosen item
            foreach(Item item in context.GetCurrent().items) { //loops through all items in the current space and assigns an item if it matches the given parameter
                if (item.Name == parameters[0]) {
                    chosen = item;
                    break;
                }
            }
            if (chosen != null){
                Console.Clear();
                context.GetInventory().FetchItem(chosen); //Fetches item to players inventory
                Console.WriteLine("you chose "+parameters[0]);
                //Can add WriteLine here with information on choice, based on chosen. 
                context.GetCurrent().Complete();
                //Incremeants rooms completed variable when a room is completed
                world.roomsCompleted++;
                //Checks if rooms completed is equal to total rooms
                if (world.roomsCompleted == world.totalRooms) {
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
