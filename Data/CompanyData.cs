using SistemSales.Models;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using System.Xml.Linq;

namespace SistemSales.Data
{
    public class CompanyData
    {
        public List<CompanyModel> ShowCompanys()
        {
            var oList = new List<CompanyModel>();

            var cn = new Conection();

            using (var conection = new MySqlConnection(cn.getChainMySql()))
            {
                conection.Open();
                MySqlCommand cmd = new MySqlCommand("SpShowCompanys", conection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr  = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oList.Add(new CompanyModel() { 
                        Id = Convert.ToInt32(dr["id"]),
                        Name = dr["name"].ToString(),
                        Address = dr["address"].ToString(),
                        Phone = dr["phone"].ToString(),
                        });
                    }
                }
            }
            return oList;
        }
        //CREATE
        public bool CreateCompany(CompanyModel oCompany)
        {
            bool rpta;
            try
            {
                var cn = new Conection();

                using (var conection = new MySqlConnection(cn.getChainMySql()))
                {
                    conection.Open();
                    MySqlCommand cmd = new MySqlCommand("SpCreateCompany", conection);
                    cmd.Parameters.AddWithValue("p_name", oCompany.Name);
                    cmd.Parameters.AddWithValue("p_address", oCompany.Address);
                    cmd.Parameters.AddWithValue("p_phone", oCompany.Phone);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta=false;
            }
            return rpta;
        }
        //EDIT
        public bool EditCompany(CompanyModel oCompany)
        {
            bool rpta;
            try
            {
                var cn = new Conection();

                using (var conection = new MySqlConnection(cn.getChainMySql()))
                {
                    conection.Open();
                    MySqlCommand cmd = new MySqlCommand("SpEditCompany", conection);
                    cmd.Parameters.AddWithValue("id", oCompany.Id);

                    cmd.Parameters.AddWithValue("name", oCompany.Name);
                    cmd.Parameters.AddWithValue("address", oCompany.Address);
                    cmd.Parameters.AddWithValue("phone", oCompany.Phone);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }
        //DELETE
        public bool DeleteCompany(int Id)
        {
            bool rpta;
            try
            {
                var cn = new Conection();

                using (var conection = new MySqlConnection(cn.getChainMySql()))
                {
                    conection.Open();
                    MySqlCommand cmd = new MySqlCommand("SpDeleteCompany", conection);
                    cmd.Parameters.AddWithValue("id", Id);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}
