/* Inventory for storing collected items and calculating their combined score.
 */
 
public class Inventory {
    private List<Item> items; //using a List from the collections namespace, use hashset instead? (makes sure you can have no duplicates)

    //Constructor
   public Inventory () {
       items = new List<Item>();
   }

   //Method for adding an Item to inventory/items 
   public void FetchItem (Item item) {
       items.Add(item);
   }
   
   //Method for calculating score
   public int CalculateScore () {
       int total = 0; 
       foreach (Item item in items) {
           total += item.PointValue;
       }
       return total; 
   } 
}