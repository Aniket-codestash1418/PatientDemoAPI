using Microsoft.AspNetCore.Mvc;
using PatientDemoAPI.RequestModel;
using PatientDemoAPI.Services;

namespace PatientDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncounterController : ControllerBase
    {
        private readonly IEncounterService _encounterService;

        public EncounterController(IEncounterService encounterService)
        {
            this._encounterService = encounterService ?? throw new ArgumentNullException(nameof(encounterService));
        }

        [HttpPost]
        [Route("logPatientEncounters")]

        public async Task<ActionResult<ResponseModel>> LogPatientEncounters([FromBody] EncounterDto encounterDto)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                if (encounterDto is null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var encounters = new EncounterRequestModel()
                {
                    PatientId = encounterDto.PatientId,
                    PractitionerId = encounterDto.PractitionerId,
                    Date = encounterDto.Date,
                    Reason = encounterDto.Reason,
                    Notes = encounterDto.Notes,
                    Diagnosis = encounterDto.Diagnosis,
                    Prescription = encounterDto.Prescription,
                };

                var checkResponse = await _encounterService.AddPatientEncounters(encounters);
                if (checkResponse != null)
                {
                    responseModel.StatusCode = 200;
                    responseModel.Message = "Record added successfully";
                    return Ok(responseModel);
                }
                responseModel.StatusCode = 400;
                responseModel.Message = "Record not added";
                return BadRequest(responseModel);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
