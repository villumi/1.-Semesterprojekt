/* Space class for modeling spaces (rooms, caves, ...)
 */
using System.Text.Json;
class Space : Node {
    static Dictionary<string, string> messages =
            JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("rooms.json"))!; 
    private bool haveVisited;
    private bool haveCompleted; //haveCompleted tracks whether the player has made a choice in a space
    private HashSet<Item> items = new HashSet<Item>(); //Attribute to contain all items in any given space
    private string roomMessage;
    public Space (string name) : base(name)
    {
        World.totalRooms++;
        roomMessage = messages.GetValueOrDefault(name, "");
    }
    
    public void Welcome () {
        Console.WriteLine("You are now at "+name);
        if (!haveVisited)
        {
            Console.WriteLine(roomMessage);
            Console.WriteLine();
            //prints all options/items in a given room
            foreach (Item option in items) {
                Console.WriteLine(" - "+option.Name);
            }
            haveVisited = true;
        } else {
            Console.WriteLine("- This room has been visited there is nothing left to see");
            Console.WriteLine();
            this.Complete();
            }
    }
    
    //Method to complete a room
    public void Complete () {
        haveCompleted = true;
        HashSet<string> exits = edges.Keys.ToHashSet();
        Console.WriteLine("Current exits are:");
        foreach (String exit in exits) {
        Console.WriteLine(" - "+exit);
        }
    }

    public void AddItem (Item item) {
        items.Add(item);
    }
    
    public void Goodbye () {
    }
    
    public override Space FollowEdge (string direction) {
        return (Space) (base.FollowEdge(direction));
    }

    //getters
    public bool GetHaveCompleted() {
        return haveCompleted;
    }

    public bool GetHaveVisited() {
        return haveVisited;
    }

    public Item? FindItem(string name) {
        foreach (Item item in items) {
            if (item.Name == name) {
                return item;
            }
        }
    
        return null;
    }
}
