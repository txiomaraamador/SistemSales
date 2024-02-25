using MySql.Data.MySqlClient;
using SistemSales.Models;
using System.Data;

namespace SistemSales.Data
{
    public class SizeData
    {
        public List<SizeModel> ShowSizes()
        {
            var oList = new List<SizeModel>();

            var cn = new Conection();

            using (var conection = new MySqlConnection(cn.getChainMySql()))
            {
                conection.Open();
                MySqlCommand cmd = new MySqlCommand("SpShowSizes", conection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oList.Add(new SizeModel()
                        {
                            IdSize = Convert.ToInt32(dr["id"]),
                            Name = dr["name"].ToString(),

                        });
                    }
                }
            }
            return oList;
        }
        //Obtener
        public SizeModel GetSize(int IdSize)
        {
            var oSize = new SizeModel();

            var cn = new Conection();

            using (var conection = new MySqlConnection(cn.getChainMySql()))
            {
                conection.Open();
                MySqlCommand cmd = new MySqlCommand("SpGetSize", conection);
                cmd.Parameters.AddWithValue("p_id", IdSize);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oSize.IdSize = Convert.ToInt32(dr["id"]);
                        oSize.Name = dr["name"].ToString();


                    }
                }
            }
            return oSize;
        }
        //CREATE
        public bool CreateSize(SizeModel oSize)
        {
            bool rpta;
            try
            {
                var cn = new Conection();

                using (var conection = new MySqlConnection(cn.getChainMySql()))
                {
                    conection.Open();
                    MySqlCommand cmd = new MySqlCommand("SpCreateSize", conection);
                    cmd.Parameters.AddWithValue("p_name", oSize.Name);

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
        public bool EditSize(SizeModel oSize)
        {
            bool rpta;
            try
            {
                var cn = new Conection();

                using (var conection = new MySqlConnection(cn.getChainMySql()))
                {
                    conection.Open();
                    MySqlCommand cmd = new MySqlCommand("SpEditSize", conection);
                    cmd.Parameters.AddWithValue("p_id", oSize.IdSize);

                    cmd.Parameters.AddWithValue("p_name", oSize.Name);
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
        public bool DeleteSize(int IdSize)
        {
            bool rpta;
            try
            {
                var cn = new Conection();

                using (var conection = new MySqlConnection(cn.getChainMySql()))
                {
                    conection.Open();
                    MySqlCommand cmd = new MySqlCommand("SpDeleteSize", conection);
                    cmd.Parameters.AddWithValue("p_id", IdSize);

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
