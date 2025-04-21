using PatientDemoAPI.DatabaseContext;
using PatientDemoAPI.RequestModel;

namespace PatientDemoAPI.Services
{
    public interface IPractitionerService
    {
        Task<List<PractitionerRequestModel>> SearchPractitioners(string speciality, string location);
    }
    public class PractitionerService : IPractitionerService
    {
        private readonly ApplicationDbContext _dbContext;

        public PractitionerService(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<PractitionerRequestModel>> SearchPractitioners(string speciality, string location)
        {
            List<PractitionerRequestModel> list = new();
            try
            {
                var data = _dbContext.Practitioners.Where(x => x.Specialty!.Contains(speciality) || x.Location!.Contains(location));

                foreach (var item in data!)
                {
                    var lists = new PractitionerRequestModel()
                    {
                        Name = item.Name,
                        Specialty = item.Specialty,
                        PhoneNumber = item.PhoneNumber,
                        Location = item.Location,
                    };
                    list.Add(lists);
                }
                return list;


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
