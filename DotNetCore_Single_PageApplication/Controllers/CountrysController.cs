using DotNetCore_Single_PageApplication.InterFace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore_Single_PageApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountrysController : ControllerBase
    {
        ICountryService _countryService;
        public CountrysController(ICountryService countryService)
        {
            this._countryService = countryService;
        }
        [HttpGet(Name = "GetAllCountry")]
        public async Task<IActionResult> GetAllCountry()
        {
            try
            {
                var countrys = await _countryService.GetCountryDTOs();
                //var employeeData = _EmployeeManager.GetAllEmployeeDetails();
                if (countrys != null)
                {
                    return StatusCode(StatusCodes.Status200OK, countrys);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        
    }
}
