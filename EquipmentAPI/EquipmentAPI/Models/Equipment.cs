using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentAPI.Models
{
    public class Equipment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // simple auto-increment for demo purposes
        public int Id { get; set; }              // server assigns
        public string Name { get; set; } = "";   // required
        public string Category { get; set; }             // simple field
        public string Status { get; set; } = "";  // optional/simple
        public string Location { get; set; } = ""; // optional/simple

        public Equipment(string name, string category, string status, string location)
        {
            Name = name;
            Category = category;
            Status = status;
            Location = location;

        }
    }
}
