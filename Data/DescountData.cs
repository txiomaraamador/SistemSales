using MySql.Data.MySqlClient;
using SistemSales.Models;
using System.Data;

namespace SistemSales.Data
{
    public class DescountData
    {
        public List<DescountModel> ShowDescounts()
        {
            var oList = new List<DescountModel>();

            var cn = new Conection();

            using (var conection = new MySqlConnection(cn.getChainMySql()))
            {
                conection.Open();
                MySqlCommand cmd = new MySqlCommand("SpShowDescounts", conection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oList.Add(new DescountModel()
                        {
                            IdDescount = Convert.ToInt32(dr["id"]),
                            Code = dr["code"].ToString(),
                            Cant = dr["cant"].ToString(),
                            
                        });
                    }
                }
            }
            return oList;
        }
        //Obtener
        public DescountModel GetDescount(int IdDescount)
        {
            var oDescount = new DescountModel();

            var cn = new Conection();

            using (var conection = new MySqlConnection(cn.getChainMySql()))
            {
                conection.Open();
                MySqlCommand cmd = new MySqlCommand("SpGetDescount", conection);
                cmd.Parameters.AddWithValue("p_id", IdDescount);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oDescount.IdDescount = Convert.ToInt32(dr["id"]);
                        oDescount.Code = dr["code"].ToString();
                        oDescount.Cant = dr["cant"].ToString();
                       

                    }
                }
            }
            return oDescount;
        }
        //CREATE
        public bool CreateDescount(DescountModel oDescount)
        {
            bool rpta;
            try
            {
                var cn = new Conection();

                using (var conection = new MySqlConnection(cn.getChainMySql()))
                {
                    conection.Open();
                    MySqlCommand cmd = new MySqlCommand("SpCreateDescount", conection);
                    cmd.Parameters.AddWithValue("p_code", oDescount.Code);
                    cmd.Parameters.AddWithValue("p_cant", oDescount.Cant);
                 
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
        public bool EditDescount(DescountModel oDescount)
        {
            bool rpta;
            try
            {
                var cn = new Conection();

                using (var conection = new MySqlConnection(cn.getChainMySql()))
                {
                    conection.Open();
                    MySqlCommand cmd = new MySqlCommand("SpEditDescount", conection);
                    cmd.Parameters.AddWithValue("p_id", oDescount.IdDescount);

                    cmd.Parameters.AddWithValue("p_code", oDescount.Code);
                    cmd.Parameters.AddWithValue("p_cant", oDescount.Cant);
                   
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
        public bool DeleteDescount(int IdDescount)
        {
            bool rpta;
            try
            {
                var cn = new Conection();

                using (var conection = new MySqlConnection(cn.getChainMySql()))
                {
                    conection.Open();
                    MySqlCommand cmd = new MySqlCommand("SpDeleteDescount", conection);
                    cmd.Parameters.AddWithValue("p_id", IdDescount);

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
