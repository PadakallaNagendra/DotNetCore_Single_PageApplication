using DotNetCore_Single_PageApplication.InterFace;
using DotNetCore_Single_PageApplication.ModelDTO;
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
                var countrys = await _countryService.GetAllCountry();
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
        [HttpPost]
        [Route("AddCountryDetails")]
        public async Task<IActionResult> Post([FromBody] CountryDTO countryDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var countryData = await _countryService.AddCountryDetails(countryDTO);
                return StatusCode(StatusCodes.Status201Created, "country Details Added Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        [HttpGet]
        [Route("GetCountriesDetailsById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }
            try
            {
                var countryData = await _countryService.GetCountriesDetailsById(id);
                if (countryData == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "country Id not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, countryData);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        [HttpDelete]
        [Route("DeleteCountryDetilsById/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }

            try
            {
                var countryData = await _countryService.DeleteCountryDetilsById(id);
                if (countryData == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "country Id not found");
                }
                else
                {
                    //var Data = await _countryService.DeleteCountryDetilsById(id);
                    return StatusCode(StatusCodes.Status204NoContent, "country details deleted successfully");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        [HttpPut]
        [Route("UpdateCountryDetils")]
        public async Task<IActionResult> PUT([FromBody] CountryDTO countryDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var countryData = await _countryService.UpdateCountryDetils(countryDTO);
                return StatusCode(StatusCodes.Status201Created, "country Details Updated Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }



        [HttpGet]
        [Route("currentdatetime")]//restful API method
        public string getdateandtime()
        {
            return DateTime.Now.ToString();
        }



    }
}
