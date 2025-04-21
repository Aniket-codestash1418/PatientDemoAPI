using PatientDemoAPI.DatabaseContext;
using PatientDemoAPI.Entities;
using PatientDemoAPI.RequestModel;

namespace PatientDemoAPI.Services
{
    public interface IHospitalService
    {
        Task<Hospital> AddHospitalDetails(HospitalRequestModel hospitalDetails);
        Task<List<HospitalRequestModel>> SearchHospitalDetails(string query);
    }

    public class HospitalService : IHospitalService
    {
        private readonly ApplicationDbContext _dbContext;

        public HospitalService(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }


        //To add Hospital 
        public async Task<Hospital> AddHospitalDetails(HospitalRequestModel hospitalDetails)
        {
            try
            {
                if (hospitalDetails is null)
                {
                    return new Hospital();
                }
                var hospital = new Hospital()
                {
                    Name = hospitalDetails.Name,
                    Address = hospitalDetails.Address,
                    City = hospitalDetails.City,
                    State = hospitalDetails.State,
                    PhoneNumber = hospitalDetails.PhoneNumber,
                    Email = hospitalDetails.Email,
                    CreatedAt = DateTime.UtcNow.Date,

                };
                await _dbContext.Hospitals.AddAsync(hospital);
                _dbContext.SaveChanges();
                return hospital;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //To search for Hospitals based on search parameter provided
        public async Task<List<HospitalRequestModel>> SearchHospitalDetails(string query)
        {
            List<HospitalRequestModel> hospitalRequestModels = new();

            if (string.IsNullOrWhiteSpace(query))
            {
                return new List<HospitalRequestModel>();
            }

            var data = _dbContext.Hospitals.Where(x => x.Name == query || x.City == query || x.State == query);
            foreach (var item in data)
            {

                HospitalRequestModel hospitalRequestModel = new()
                {
                    Name = item.Name,
                    Address = item.Address,
                    City = item.City,
                    State = item.State,
                    PhoneNumber = item.PhoneNumber,
                    Email = item.Email,
                };
                hospitalRequestModels.Add(hospitalRequestModel);
            }


            return hospitalRequestModels;
        }


    }

}
