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

        public async Task<bool> AddCountryDetails(CountryDTO countryDetaildto)
        {
            Country obj = new Country();
            obj.Id = countryDetaildto.Id;
            obj.countryName = countryDetaildto.countryName;


            await _countryRepositary.AddCountryDetails(obj);
            return true;
        }

        public async Task<bool> DeleteCountryDetilsById(int id)
        {
            await _countryRepositary.DeleteCountryDetilsById(id);
            return true;
        }

        public async Task<CountryDTO> GetCountriesDetailsById(int id)
        {
            var countriesObj = await _countryRepositary.GetCountriesDetailsById(id);

            CountryDTO countriesdtoobj = new CountryDTO();
            countriesdtoobj.Id = countriesObj.Id;
            countriesdtoobj.countryName = countriesObj.countryName;
            return countriesdtoobj;
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

        public async Task<bool> UpdateCountryDetils(CountryDTO countryDetaildto)
        {
            Country obj = new Country();
            obj.Id = countryDetaildto.Id;
            obj.countryName = countryDetaildto.countryName;

            await _countryRepositary.UpdateCountryDetils(obj);
            return true;
        }
    }
}
