using System.ComponentModel.DataAnnotations;

namespace PatientDemoAPI.RequestModel
{
    public class PatientDetailsDto
    {
        [Required(ErrorMessage = "Patient name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Age is required")]
        public int? Age { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string? Gender { get; set; }
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits")]
        public string? ContactNumber { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
        public string? Address { get; set; }
        [Required(ErrorMessage = "Admission Date is required")]
        public DateTime AdmissionDate { get; set; }
        [Required(ErrorMessage = "Discharge Date is required")]
        public DateTime DischargeDate { get; set; }
    }
}
