namespace command.Common.Models
{
    public class PackingListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public Bag Bag { get; set; }
        public string Comment { get; set; }
    }
}
