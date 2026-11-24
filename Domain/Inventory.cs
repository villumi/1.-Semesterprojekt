/* Inventory for storing collected items and calculating their combined score.
 */
 
public class Inventory {
   private List<Item> items; //using a List from the collections namespace, use hashset instead? (makes sure you can have no duplicates)

    //Constructor
   public Inventory () {
       items = new List<Item>();
   }

   //Method for adding an Item to inventory/items 
   public void AddItemToInventory (Item item) {
       items.Add(item);
   }

   //prints every item in the list
   public void GetItems() {
       foreach (Item item in this.items) {
           Console.WriteLine(item.Name);
       }
   }
   
   //Method for calculating score
   public double CalculateScore () {
       double total = 23.3; 
       foreach (Item item in items) {
           total += item.PointValue; //Initial pointvalue might have to be added. 
       }
       return total; 
   } 
   //Method for calculating savings vs average
   public double CalculateSavedCO2() {
       int danishPopulation = 6000000;
       double baseline = 23.3;
       double savedCO2 = baseline - CalculateScore();
       double savingsForAll = 365*savedCO2 * danishPopulation;
       double savedTons = savingsForAll/1000;
       return savedTons;
}
}