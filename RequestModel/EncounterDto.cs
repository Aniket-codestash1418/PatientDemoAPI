using System.ComponentModel.DataAnnotations;

namespace PatientDemoAPI.RequestModel
{
    public class EncounterDto
    {
        [Required(ErrorMessage = "Patient Id is required")]
        public int PatientId { get; set; }
        [Required(ErrorMessage = "PractitionerId is required")]
        public int PractitionerId { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Reason is required")]
        public string? Reason { get; set; }
        public string? Notes { get; set; }
        [Required(ErrorMessage = "Diagnosis is required")]
        public string? Diagnosis { get; set; }
        [Required(ErrorMessage = "Prescription is required")]
        public string? Prescription { get; set; }
    }
}
