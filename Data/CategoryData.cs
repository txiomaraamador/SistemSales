using SistemSales.Models;
using System.Data;
using MySql.Data.MySqlClient;
using System.Xml.Linq;

namespace SistemSales.Data
{
    public class CategoryData
    {
        public List<CategoryModel> ShowCategorys()
        {
            var oList = new List<CategoryModel>();

            var cn = new Conection();

            using (var conection = new MySqlConnection(cn.getChainMySql()))
            {
                conection.Open();
                MySqlCommand cmd = new MySqlCommand("SpShowCategorys", conection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oList.Add(new CategoryModel()
                        {
                            IdCategory = Convert.ToInt32(dr["id"]),
                            Name = dr["name"].ToString(),
                            
                        });
                    }
                }
            }
            return oList;
        }
        //Obtener
        public CategoryModel GetCategory(int IdCategory)
        {
            var oCategory = new CategoryModel();

            var cn = new Conection();

            using (var conection = new MySqlConnection(cn.getChainMySql()))
            {
                conection.Open();
                MySqlCommand cmd = new MySqlCommand("SpGetCategory", conection);
                cmd.Parameters.AddWithValue("p_id", IdCategory);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oCategory.IdCategory = Convert.ToInt32(dr["id"]);
                        oCategory.Name = dr["name"].ToString();
                       

                    }
                }
            }
            return oCategory;
        }
        //CREATE
        public bool CreateCategory(CategoryModel oCategory)
        {
            bool rpta;
            try
            {
                var cn = new Conection();

                using (var conection = new MySqlConnection(cn.getChainMySql()))
                {
                    conection.Open();
                    MySqlCommand cmd = new MySqlCommand("SpCreateCategory", conection);
                    cmd.Parameters.AddWithValue("p_name", oCategory.Name);
             
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
        public bool EditCategory(CategoryModel oCategory)
        {
            bool rpta;
            try
            {
                var cn = new Conection();

                using (var conection = new MySqlConnection(cn.getChainMySql()))
                {
                    conection.Open();
                    MySqlCommand cmd = new MySqlCommand("SpEditCategory", conection);
                    cmd.Parameters.AddWithValue("p_id", oCategory.IdCategory);

                    cmd.Parameters.AddWithValue("p_name", oCategory.Name);
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
        public bool DeleteCategory(int IdCategory)
        {
            bool rpta;
            try
            {
                var cn = new Conection();

                using (var conection = new MySqlConnection(cn.getChainMySql()))
                {
                    conection.Open();
                    MySqlCommand cmd = new MySqlCommand("SpDeleteCategory", conection);
                    cmd.Parameters.AddWithValue("p_id", IdCategory);

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
