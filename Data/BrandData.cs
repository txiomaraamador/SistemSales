using SistemSales.Models;
using System.Data;
using MySql.Data.MySqlClient;
using System.Xml.Linq;

namespace SistemSales.Data
{
    public class BrandData
    {
        public List<BrandModel> ShowBrands()
        {
            var oList = new List<BrandModel>();

            var cn = new Conection();

            using (var conection = new MySqlConnection(cn.getChainMySql()))
            {
                conection.Open();
                MySqlCommand cmd = new MySqlCommand("SpShowBrands", conection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oList.Add(new BrandModel()
                        {
                            IdBrand = Convert.ToInt32(dr["id"]),
                            Name = dr["name"].ToString(),

                        });
                    }
                }
            }
            return oList;
        }
        //Obtener
        public BrandModel GetBrand(int IdBrand)
        {
            var oBrand = new BrandModel();

            var cn = new Conection();

            using (var conection = new MySqlConnection(cn.getChainMySql()))
            {
                conection.Open();
                MySqlCommand cmd = new MySqlCommand("SpGetBrand", conection);
                cmd.Parameters.AddWithValue("p_id", IdBrand);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oBrand.IdBrand = Convert.ToInt32(dr["id"]);
                        oBrand.Name = dr["name"].ToString();


                    }
                }
            }
            return oBrand;
        }
        //CREATE
        public bool CreateBrand(BrandModel oBrand)
        {
            bool rpta;
            try
            {
                var cn = new Conection();

                using (var conection = new MySqlConnection(cn.getChainMySql()))
                {
                    conection.Open();
                    MySqlCommand cmd = new MySqlCommand("SpCreateBrand", conection);
                    cmd.Parameters.AddWithValue("p_name", oBrand.Name);

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
        //EDIT
        public bool EditBrand(BrandModel oBrand)
        {
            bool rpta;
            try
            {
                var cn = new Conection();

                using (var conection = new MySqlConnection(cn.getChainMySql()))
                {
                    conection.Open();
                    MySqlCommand cmd = new MySqlCommand("SpEditBrand", conection);
                    cmd.Parameters.AddWithValue("p_id", oBrand.IdBrand);

                    cmd.Parameters.AddWithValue("p_name", oBrand.Name);
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
        public bool DeleteBrand(int IdBrand)
        {
            bool rpta;
            try
            {
                var cn = new Conection();

                using (var conection = new MySqlConnection(cn.getChainMySql()))
                {
                    conection.Open();
                    MySqlCommand cmd = new MySqlCommand("SpDeleteBrand", conection);
                    cmd.Parameters.AddWithValue("p_id", IdBrand);

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
