namespace EquipmentAPI.Models
{
    public class Equipment
    {
        private static int _nextId = 1; // simple auto-increment for demo purposes
        public int Id { get; set; }              // server assigns
        public string Name { get; set; } = "";   // required
        public string Category { get; set; }             // simple field
        public string Status { get; set; } = "";  // optional/simple
        public string Location { get; set; } = ""; // optional/simple

        public Equipment(string name, string category, string status, string location)
        {
            Id = _nextId++; // auto-assign unique ID
            Name = name;
            Category = category;
            Status = status;
            Location = location;

        }
    }
}
