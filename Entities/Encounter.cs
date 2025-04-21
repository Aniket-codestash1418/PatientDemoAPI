namespace PatientDemoAPI.Entities
{
    public class Encounter
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int PractitionerId { get; set; }
        public DateTime Date { get; set; }
        public string? Reason { get; set; }
        public string? Notes { get; set; }
        public string? Diagnosis { get; set; }
        public string? Prescription { get; set; }
        public DateTime CreatedAt { get; set; }

        public Patient? Patient { get; set; }
        public Practitioner? Practitioner { get; set; }
    }

}
