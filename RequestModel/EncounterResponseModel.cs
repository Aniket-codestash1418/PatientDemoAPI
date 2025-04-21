namespace PatientDemoAPI.RequestModel
{
    public class EncounterResponseModel
    {
        public string? PatientName { get; set; }
        public string? PractitionerName { get; set; }
        public DateTime Date { get; set; }
        public string? Reason { get; set; }
        public string? Notes { get; set; }
        public string? Diagnosis { get; set; }
    }
}
