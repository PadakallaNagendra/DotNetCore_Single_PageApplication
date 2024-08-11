using DotNetCore_Single_PageApplication.Entities;

namespace DotNetCore_Single_PageApplication.InterFace
{
    public interface ICountryRepositary
    {
        Task<List<Country>> GetAllCountry();
    }
}
