namespace CustomerApp.Models
{
    public class Customer
    {
        public int Id { get; set; } // Unique ID for the customer
        public required string FirstName { get; set; } // Customer's first name
        public required string LastName { get; set; } // Customer's last name
        public required string Email { get; set; } // Customer's email
    }
}
