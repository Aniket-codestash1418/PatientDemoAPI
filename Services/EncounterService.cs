using PatientDemoAPI.DatabaseContext;
using PatientDemoAPI.Entities;
using PatientDemoAPI.RequestModel;

namespace PatientDemoAPI.Services
{
    public interface IEncounterService
    {
        Task<Encounter> AddPatientEncounters(EncounterRequestModel model);
    }
    public class EncounterService : IEncounterService
    {
        private readonly ApplicationDbContext _dbContext;

        public EncounterService(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Encounter> AddPatientEncounters(EncounterRequestModel model)
        {
            try
            {
                if (model is null)
                {
                    return new Encounter();
                }
                var encounter = new Encounter()
                {
                    PatientId = model.PatientId,
                    PractitionerId = model.PractitionerId,
                    Date = model.Date,
                    Reason = model.Reason,
                    Notes = model.Notes,
                    Diagnosis = model.Diagnosis,
                    Prescription = model.Prescription,
                    CreatedAt = DateTime.UtcNow
                };
                await _dbContext.Encounters.AddAsync(encounter);
                await _dbContext.SaveChangesAsync();
                return encounter;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
