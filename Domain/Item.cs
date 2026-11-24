/* Item class for various interachtable items
*/
public class Item {
    public string name;
    private double pointValue; 
    private string itemMessage;

    //Constructor
    public Item (string name, double pointValue, string itemMessage) {
        this.name = name;
        this.pointValue = pointValue;
        this.itemMessage = itemMessage;
        
    }
    
    //Get Method (Set method not needed currently)
    public string Name {
        get { return name; }
    }

    public double PointValue {
        get { return pointValue; }
    }

    public string ItemMessage {
        get { return itemMessage; }
    }
}