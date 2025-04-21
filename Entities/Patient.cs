namespace PatientDemoAPI.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime DischargeDate { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Encounter>? Encounters { get; set; }
    }

}
