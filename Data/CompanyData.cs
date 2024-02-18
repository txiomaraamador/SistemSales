using SistemSales.Models;
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
                        IdCompany = Convert.ToInt32(dr["id"]),
                        Name = dr["name"].ToString(),
                        Address = dr["address"].ToString(),
                        Phone = dr["phone"].ToString(),
                        });
                    }
                }
            }
            return oList;
        }
        //Obtener
        public CompanyModel GetCompany(int IdCompany)
        {
            var oCompany = new CompanyModel();

            var cn = new Conection();

            using (var conection = new MySqlConnection(cn.getChainMySql()))
            {
                conection.Open();
                MySqlCommand cmd = new MySqlCommand("SpGetCompany", conection);
                cmd.Parameters.AddWithValue("p_id", IdCompany);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oCompany.IdCompany = Convert.ToInt32(dr["id"]);
                        oCompany.Name = dr["name"].ToString();
                        oCompany.Address = dr["address"].ToString();
                        oCompany.Phone = dr["phone"].ToString();
                        
                    }
                }
            }
            return oCompany;
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
                    cmd.Parameters.AddWithValue("p_id", oCompany.IdCompany);

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
                rpta = false;
            }
            return rpta;
        }
        //DELETE
        public bool DeleteCompany(int IdCompany)
        {
            bool rpta;
            try
            {
                var cn = new Conection();

                using (var conection = new MySqlConnection(cn.getChainMySql()))
                {
                    conection.Open();
                    MySqlCommand cmd = new MySqlCommand("SpDeleteCompany", conection);
                    cmd.Parameters.AddWithValue("p_id", IdCompany);

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
