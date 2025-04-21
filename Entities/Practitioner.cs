namespace PatientDemoAPI.Entities
{
    public class Practitioner
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Specialty { get; set; }
        public string? Location { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int HospitalId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Hospital? Hospital { get; set; }
        public ICollection<Encounter>? Encounters { get; set; }
    }

}
