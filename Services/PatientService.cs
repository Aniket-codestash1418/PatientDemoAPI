using PatientDemoAPI.DatabaseContext;
using PatientDemoAPI.Entities;
using PatientDemoAPI.RequestModel;

namespace PatientDemoAPI.Services
{

    public interface IPatientService
    {
        Task<Patient> AddPatientDetails(PatientRequestModel patient);
        Task<List<EncounterResponseModel>> GetEncountersForSelectedPatient(int id);
    }
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext _dbContext;

        public PatientService(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Patient> AddPatientDetails(PatientRequestModel patient)
        {
            if (patient == null)
            {
                return null!;
            }
            var patientData = new Patient()
            {
                Name = patient.Name,
                Age = patient.Age,
                Gender = patient.Gender,
                DateOfBirth = patient.DateOfBirth,
                ContactNumber = patient.ContactNumber,
                Email = patient.Email,
                Address = patient.Address,
                AdmissionDate = patient.AdmissionDate,
                DischargeDate = patient.DischargeDate,
                CreatedAt = DateTime.UtcNow
            };
            await _dbContext.PatientDetails.AddAsync(patientData);
            _dbContext.SaveChanges();
            return patientData;
        }

        public async Task<List<EncounterResponseModel>> GetEncountersForSelectedPatient(int id)
        {
            List<EncounterResponseModel> lists = new();
            if (id == 0)
            {
                return null!;
            }

            var data = _dbContext.Encounters.Where(x => x.PatientId == id)
                .OrderBy(x => x.Date).ToList();
            foreach (var item in data)
            {
                var patientName = _dbContext.PatientDetails.Where(x => x.Id == item.PatientId).FirstOrDefault();
                var practitionerName = _dbContext.Practitioners.Where(x => x.Id == item.PractitionerId).FirstOrDefault()!;
                EncounterResponseModel list = new()
                {
                    PatientName = patientName!.Name,
                    PractitionerName = practitionerName.Name,
                    Date = item.Date,
                    Reason = item.Reason,
                    Notes = item.Notes,
                    Diagnosis = item.Diagnosis,
                };
                lists.Add(list);
            }
            return lists;
        }
    }
}
