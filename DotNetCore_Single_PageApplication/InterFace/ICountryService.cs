using DotNetCore_Single_PageApplication.ModelDTO;

namespace DotNetCore_Single_PageApplication.InterFace
{
    public interface ICountryService
    {
        public Task<List<CountryDTO>> GetCountryDTOs();
    }
}
