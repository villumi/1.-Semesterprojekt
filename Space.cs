/* Space class for modeling spaces (rooms, caves, ...)
 */
using System.Text.Json;
class Space : Node {
    static Dictionary<string, RoomData> rooms =
    JsonSerializer.Deserialize<Dictionary<string, RoomData>>(
        File.ReadAllText("rooms.json"),
        new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }
    )!;
    private bool haveVisited;
    public bool HaveCompleted {get; private set;} //haveCompleted tracks whether the player has made a choice in a space
    private HashSet<Item> items = new HashSet<Item>(); //Attribute to contain all items in any given space
    public IReadOnlyCollection<Item> Items => items;
    private string roomMessage;
    public static int TotalRooms { get; private set; }
    public Space (string name) : base(name)
    {
        TotalRooms++;
        RoomData data = rooms[name];
        roomMessage = data.roomMessage;
        foreach (ItemData item in data.items)
        {
            AddItem(new Item(item.option, item.pointValue));
        }
    }
    
    public void Welcome () {
        Console.WriteLine("You are now at "+name);
        if (!haveVisited)
        {
            Console.WriteLine(roomMessage);
            Console.WriteLine();
            //prints all options/items in a given room
            foreach (Item option in items)
            {
                Console.WriteLine(" - " + option.Name + " (" + option.PointValue + " kg CO2e)");
            }
            haveVisited = true;
        } else {
            Console.WriteLine("- This room has been visited there is nothing left to see");
            Console.WriteLine();
            Console.WriteLine("Current exits are:");
            foreach (String exit in edges.Keys) { //Has access to edges.Keys as space is a child class of node
                Console.WriteLine(" - "+exit);
                }
            }
    }
    
    //Method to complete a room
    public void Complete () {
        if (!HaveCompleted){ //Guard so a room can only be completed once
            HaveCompleted = true;
            Console.WriteLine("Current exits are:");
            foreach (String exit in edges.Keys) { //Has access to edges.Keys as space is a child class of node
            Console.WriteLine(" - "+exit);
            }
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
        return HaveCompleted;
    }

    public bool GetHaveVisited() {
        return haveVisited;
    }

    //returns a specific item given its name
    public Item? FindItem(string name) { 
        foreach (Item item in items) {
            if (item.Name == name) {
                return item;
            }
        }
        return null;
    }
}
