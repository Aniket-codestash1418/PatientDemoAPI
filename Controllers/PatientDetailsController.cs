using Microsoft.AspNetCore.Mvc;
using PatientDemoAPI.RequestModel;
using PatientDemoAPI.Services;

namespace PatientDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDetailsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientDetailsController(IPatientService patientService)
        {
            this._patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
        }

        #region Add Patient Details
        [HttpPost]
        [Route("addPatientDetails")]
        public async Task<ActionResult<ResponseModel>> AddPatientDetails([FromBody] PatientDetailsDto patientDetails)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                if (patientDetails == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var patientData = new PatientRequestModel()
                {
                    Name = patientDetails.Name,
                    Age = patientDetails.Age,
                    Gender = patientDetails.Gender,
                    DateOfBirth = patientDetails.DateOfBirth,
                    ContactNumber = patientDetails.ContactNumber,
                    Email = patientDetails.Email,
                    Address = patientDetails.Address,
                    AdmissionDate = patientDetails.AdmissionDate,
                    DischargeDate = patientDetails.DischargeDate,
                };
                var checkResponse = await _patientService.AddPatientDetails(patientData);
                if (checkResponse.Id != 0)
                {
                    responseModel.Message = "Patient Details added Successfully";
                    responseModel.StatusCode = 200;
                    return Ok(responseModel);
                }
                responseModel.Message = "Patient Details not added";
                responseModel.StatusCode = 400;
                return BadRequest(responseModel);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Display all encounters for a selected patient in a chronological format.
        [HttpGet]
        [Route("patientEncounters")]
        public async Task<ActionResult<ResponseModel>> PatientEncounters(int id)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                if (id <= 0 || string.IsNullOrEmpty(id.ToString()))
                {
                    return BadRequest();
                }
                var data = await _patientService.GetEncountersForSelectedPatient(id);
                if (data is null || data.Count is 0)
                {
                    responseModel.Message = "Records not found";
                    responseModel.StatusCode = 200;
                    responseModel.Data = null;
                    return Ok(responseModel);
                }
                responseModel.StatusCode = 200;
                responseModel.Data = data;
                responseModel.Message = "Records fetched successfully";
                return Ok(responseModel);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
