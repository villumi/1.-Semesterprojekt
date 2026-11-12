class RoomData
{
    public string roomMessage { get; set; } = "";
    public List<ItemData> items { get; set; } = new();
}
class ItemData
{
    public string option { get; set; } = "";
    public double pointValue { get; set; }
}