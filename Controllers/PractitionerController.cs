using Microsoft.AspNetCore.Mvc;
using PatientDemoAPI.RequestModel;
using PatientDemoAPI.Services;

namespace PatientDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PractitionerController : ControllerBase
    {
        private readonly IPractitionerService _practitionerService;

        public PractitionerController(IPractitionerService practitionerService)
        {
            this._practitionerService = practitionerService ?? throw new ArgumentNullException(nameof(practitionerService));
        }

        #region Search Practitioner
        [HttpGet]
        [Route("searchPractitioner")]
        public async Task<ActionResult<ResponseModel>> SearchPractitioner(string speciality, string location)
        {
            ResponseModel response = new();
            try
            {
                var data = await _practitionerService.SearchPractitioners(speciality, location);
                if (data == null)
                {
                    response.Message = "Record not found";
                    response.StatusCode = 200;
                    return NotFound(response);
                }
                response.Message = "Records fetched successfully";
                response.StatusCode = 200;
                response.Data = data;
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion
    }
}
