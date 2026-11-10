/* Item class for various interachtable items
*/
public class Item {
    private string name;
    private double pointValue; 

    //Constructor
    public Item (string name, double pointValue) {
        this.name = name;
        this.pointValue = pointValue;
    }
    
    //Get Method (Set method not needed currently)
    public string Name {
        get { return name; }
    }

    public double PointValue {
        get { return pointValue; }
    }
}