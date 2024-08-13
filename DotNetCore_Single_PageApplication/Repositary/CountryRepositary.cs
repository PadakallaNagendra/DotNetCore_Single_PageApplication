using DotNetCore_Single_PageApplication.Entities;
using DotNetCore_Single_PageApplication.InterFace;
using System.Data;
using System.Data.SqlClient;

namespace DotNetCore_Single_PageApplication.Repositary
{
    public class CountryRepositary : ICountryRepositary
    {
        string connectionstring = "data source=DESKTOP-NORDVAN\\MSSQLSERVER01;integrated security=sspi;initial catalog=NagendraDB";

        public async Task<bool> AddCountryDetails(Country countryDetail)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))//here we are getting the conection string
            {
                SqlCommand cmd = new SqlCommand("Usp_AddCountries", con);
                
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", countryDetail.Id);
                cmd.Parameters.AddWithValue("@countryName", countryDetail.countryName);
                cmd.Parameters.AddWithValue("@customername", countryDetail.customername);
                cmd.Parameters.AddWithValue("@Email", countryDetail.email);
                cmd.Parameters.AddWithValue("@city", countryDetail.city);
                con.Open();
                await cmd.ExecuteNonQueryAsync();//used for insert,update delete
                                                 // cmd.ExecuteScalar();//used in aggregation operation[max,min,count..]
                                                 //cmd.ExecuteReader();//used for fetching the records
                con.Close();
            }
            return true;
        }

        public async Task<bool> DeleteCountryDetilsById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("Usp_deleteCountries", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
            return true;

        }

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
                    obj.customername = Convert.ToString(r1["customername"]);
                    obj.email = Convert.ToString(r1["Email"]);
                    obj.city = Convert.ToString(r1["city"]);

                    result.Add(obj);

                }
                con.Close();
            }
            return result;
        }

        public async Task<Country> GetCountriesDetailsById(int id)
        {
            Country student = new Country();

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                // string sqlQuery = "SELECT * FROM Countries WHERE Id= " + id;//inline query usage 

                SqlCommand cmd = new SqlCommand("Usp_GetCountryDetailsById", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();

                while (rdr.Read())
                {
                    student.Id = Convert.ToInt32(rdr["id"]);
                    student.countryName = rdr["countryName"].ToString();
                    student.customername = rdr["customername"].ToString();
                    student.email = rdr["Email"].ToString();
                    student.city = rdr["city"].ToString();
                }
            }
            return student;
        }

        public async Task<bool> UpdateCountryDetils(Country countryDetail)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("Usp_UpdateCountries", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", countryDetail.Id);
                cmd.Parameters.AddWithValue("@countryName", countryDetail.countryName);
                cmd.Parameters.AddWithValue("@customername",countryDetail.customername);
                cmd.Parameters.AddWithValue("@Email", countryDetail.email);
                cmd.Parameters.AddWithValue("@city", countryDetail.city);
                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
            return true;
        }
    }
}
