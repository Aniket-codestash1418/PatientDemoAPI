namespace PatientDemoAPI.RequestModel
{
    public class EncounterRequestModel
    {
        public int PatientId { get; set; }
        public int PractitionerId { get; set; }
        public DateTime Date { get; set; }
        public string? Reason { get; set; }
        public string? Notes { get; set; }
        public string? Diagnosis { get; set; }
        public string? Prescription { get; set; }
    }
}
