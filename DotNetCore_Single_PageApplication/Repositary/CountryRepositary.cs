using DotNetCore_Single_PageApplication.Entities;
using DotNetCore_Single_PageApplication.InterFace;
using System.Data.SqlClient;

namespace DotNetCore_Single_PageApplication.Repositary
{
    public class CountryRepositary : ICountryRepositary
    {
        string connectionstring = "data source=DESKTOP-NORDVAN\\MSSQLSERVER01;integrated security=sspi;initial catalog=NagendraDB";
        public async Task<List<Country>> GetAllCountry()
        {
            List<Country> result = new List<Country>();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {


                con.Open();
                SqlCommand cmd = new SqlCommand("Usp_GetCountries", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader r1 = await cmd.ExecuteReaderAsync();
                 while (r1.Read())
                {
                    Country obj = new Country();
                    obj.Id = Convert.ToInt32(r1["Id"]);
                    obj.countryName = Convert.ToString(r1["countryName"]);
                    
                    result.Add(obj);

                }
                con.Close();
            }
            return result;
        }
    }
}
