/* Main class for launching the game
 */

class Game {
  static World    world    = new World();
  static Context  context  = new Context(world.GetEntry());
  
  static void Main (string[] args) {
    Console.WriteLine("Welcome to the World of Zuul!");
    
    context.GetCurrent().Welcome();
    
    while (context.IsDone()==false) {
      Console.Write("> ");
      string? line = Console.ReadLine();
      if (line==null) continue;
      
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
          if (parameters.Length!=1) {
            Console.WriteLine("I don't seem to know where that is 🤔");
            break; //Changed a return to a break (return closed the game)
          }
          try {
            context.Transition(parameters[0]);
          } catch (KeyNotFoundException) {
            Console.WriteLine("Der kan du ikke gå hen.");
          }
          break;
        case "help":
          Console.WriteLine(" - exit  Exit the program");
          Console.WriteLine(" - quit  Exit the program");
          Console.WriteLine(" - bye   Exit the program");
          Console.WriteLine(" - go    Follow an exit");
          Console.WriteLine(" - help  Display a help message");
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
