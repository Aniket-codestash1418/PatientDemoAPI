using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientDemoAPI.DatabaseContext;
using PatientDemoAPI.RequestModel;
using PatientDemoAPI.Services;

namespace PatientDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService _hospitalService;
        private readonly ApplicationDbContext _dbContext;

        public HospitalController(IHospitalService hospitalService, ApplicationDbContext dbContext)
        {
            this._hospitalService = hospitalService ?? throw new ArgumentNullException(nameof(hospitalService));
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        #region Add Hospital Details
        [HttpPost]
        [Route("addHospitalDetails")]

        public async Task<ActionResult<ResponseModel>> AddHospitalDetails([FromBody] HospitalDto hospitalDto)
        {
            ResponseModel response = new();
            try
            {
                if (hospitalDto is null)
                {
                    return BadRequest(response);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var hospitalDetails = new HospitalRequestModel()
                {
                    Name = hospitalDto.Name,
                    Address = hospitalDto.Address,
                    City = hospitalDto.City,
                    State = hospitalDto.State,
                    PhoneNumber = hospitalDto.PhoneNumber,
                    Email = hospitalDto.Email,

                };
                //Hospital service to add hospital records
                var CheckResponse = await _hospitalService.AddHospitalDetails(hospitalDetails);
                if (CheckResponse.Id != 0)
                {
                    response.StatusCode = 200;
                    response.Message = "Record Added successfully";
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return null!;
        }
        #endregion

        #region Display Hospital Details
        [HttpGet]
        [Route("getHospitalData")]

        public async Task<ActionResult<ResponseModel>> GetHospitalData()
        {
            ResponseModel response = new();
            List<HospitalResponseModel> listModel = new();
            try
            {
                var lists = await _dbContext.Hospitals.ToListAsync();
                foreach (var list in lists)
                {
                    var practioner = _dbContext.Practitioners.Where(x => x.HospitalId == list.Id).FirstOrDefault()!;
                    HospitalResponseModel hospital = new()
                    {
                        Name = list.Name,
                        Address = list.Address,
                        City = list.City,
                        State = list.State,
                        PhoneNumber = list.PhoneNumber,
                        Email = list.Email,
                        PractitionerName = practioner?.Name,
                    };
                    listModel.Add(hospital);
                }
                if (lists is null)
                {
                    response.StatusCode = 200;
                    response.Message = "No record found";
                    return NotFound(response);
                }
                response.Data = listModel;
                response.Message = "Records fetched successfully";
                response.StatusCode = 200;
                return Ok(response);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Search Hospitals
        [HttpGet]
        [Route("searchHospitals")]

        public async Task<ActionResult<ResponseModel>> SearchHospitals(string query)
        {
            ResponseModel response = new();
            try
            {
                var list = await _hospitalService.SearchHospitalDetails(query);
                if (list is null)
                {
                    response.StatusCode = 200;
                    response.Message = "No record found for above query";
                    response.Data = list;
                    return NotFound(response);
                }
                response.StatusCode = 200;
                response.Message = "Record fetched successfully";
                response.Data = list;
                return Ok(response);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
