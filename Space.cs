/* Space class for modeling spaces (rooms, caves, ...)
 */

class Space : Node {

    //Initiallizes the haveVisted variable for the space class
    public bool haveVisited = false;
    public bool haveCompleted = false; //haveCompleted tracks whether the player has made a choice in a space
    public HashSet<Item> items = new HashSet<Item>(); //Attribute to contain all items in any given space
    private string roomMessage;
    public Space (String name, string roomMessage = "") : base(name)
    {
        this.roomMessage = roomMessage;
    }
    
    public void Welcome () {
        Console.WriteLine("You are now at "+name);
        if (!haveVisited)
        {
            Console.WriteLine("- " + roomMessage);
            Console.WriteLine();
            haveVisited = true;
        } else {
            Console.WriteLine("- This room has been visited there is nothing left to see");
            Console.WriteLine();
            this.Complete();
            }
    }
    
    public void Complete () {
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
}
