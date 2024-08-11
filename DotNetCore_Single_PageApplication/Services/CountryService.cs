using DotNetCore_Single_PageApplication.Entities;
using DotNetCore_Single_PageApplication.InterFace;
using DotNetCore_Single_PageApplication.ModelDTO;

namespace DotNetCore_Single_PageApplication.Services
{
    public class CountryService : ICountryService
    {
        ICountryRepositary _countryRepositary;
        public CountryService(ICountryRepositary countryRepositary)
        {
            _countryRepositary = countryRepositary;
        }
        public async Task<List<CountryDTO>> GetCountryDTOs()
        {
            List<CountryDTO> objCountriesDto = new List<CountryDTO>();
            var result = await _countryRepositary.GetAllCountry();
            foreach (Country countriesObj in result)
            {
                CountryDTO obj = new CountryDTO();
                obj.Id = countriesObj.Id;
                obj.countryName = countriesObj.countryName;
                objCountriesDto.Add(obj);
            }
            return objCountriesDto;
        }
    }
}
