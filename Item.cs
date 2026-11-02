/* Item class for various interachtable items
*/
public class Item {
    private string name;
    private int pointValue; 

    //Constructor
    public Item (string name, int pointValue) {
        this.name = name;
        this.pointValue = pointValue;
    }
    
    //Get Method (Set method not needed currently)
    public string Name {
        get { return name; }
    }

    public int PointValue {
        get { return pointValue; }
    }
}
 
