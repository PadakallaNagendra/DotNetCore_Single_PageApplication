using DotNetCore_Single_PageApplication.Entities;

namespace DotNetCore_Single_PageApplication.InterFace
{
    public interface ICountryRepositary
    {
        Task<List<Country>> GetAllCountry();
        Task<Country> GetCountriesDetailsById(int id);
        Task<bool> AddCountryDetails(Country countryDetail);
        Task<bool> UpdateCountryDetils(Country countryDetail);
        Task<bool> DeleteCountryDetilsById(int id);
    }
}
