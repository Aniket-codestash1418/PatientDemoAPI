namespace PatientDemoAPI.RequestModel
{
    using System.ComponentModel.DataAnnotations;

    public class HospitalDto
    {

        [Required(ErrorMessage = "Hospital name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200, ErrorMessage = "Address can't be longer than 200 characters")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(50, ErrorMessage = "City name can't be longer than 50 characters")]
        public string? City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(50, ErrorMessage = "State name can't be longer than 50 characters")]
        public string? State { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits")]
        public string? PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

    }
}
