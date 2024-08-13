using DotNetCore_Single_PageApplication.Entities;
using DotNetCore_Single_PageApplication.ModelDTO;

namespace DotNetCore_Single_PageApplication.InterFace
{
    public interface ICountryService
    {
        public Task<List<CountryDTO>> GetAllCountry();
        Task<CountryDTO> GetCountriesDetailsById(int id);
        Task<bool> AddCountryDetails(CountryDTO countryDetaildto);
        Task<bool> UpdateCountryDetils(CountryDTO countryDetaildto);
        Task<bool> DeleteCountryDetilsById(int id);
    }
}
