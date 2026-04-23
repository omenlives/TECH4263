namespace CRMS.Api.Models
{
    public class RegisterDto
    {
        public string Username { get; set; } = "";

        public string Password { get; set; } = "";

        public string FullName { get; set; } = "";

        public string Email { get; set; } = "";

        public string Phone { get; set; } = "";
    }

    public class CarDto
    {
        public string Make { get; set; } = "";

        public string Model { get; set; } = "";

        public int Year { get; set; }

        public string Category { get; set; } = "";

        public decimal DailyRate { get; set; }

        public string LicencePlate { get; set; } = "";

        public string Color { get; set; } = "";

        public string Status { get; set; } = "Available";
    }

    public class BookingDto
    {
        public int CarId { get; set; }

        public DateTime PickupDate { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}
