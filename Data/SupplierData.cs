using SistemSales.Models;
using System.Data;
using MySql.Data.MySqlClient;
using System.Xml.Linq;

namespace SistemSales.Data;

public class SupplierData
{
    public List<SupplierModel> ShowSuppliers()
    {
        var oList = new List<SupplierModel>();

        var cn = new Conection();

        using (var conection = new MySqlConnection(cn.getChainMySql()))
        {
            conection.Open();
            MySqlCommand cmd = new MySqlCommand("SpShowSuppliers", conection);
            cmd.CommandType = CommandType.StoredProcedure;

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    oList.Add(new SupplierModel()
                    {
                        IdSupplier = Convert.ToInt32(dr["id"]),
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
    public SupplierModel GetSupplier(int IdSupplier)
    {
        var oSupplier = new SupplierModel();

        var cn = new Conection();

        using (var conection = new MySqlConnection(cn.getChainMySql()))
        {
            conection.Open();
            MySqlCommand cmd = new MySqlCommand("SpGetSupplier", conection);
            cmd.Parameters.AddWithValue("p_id", IdSupplier);
            cmd.CommandType = CommandType.StoredProcedure;

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {

                    oSupplier.IdSupplier = Convert.ToInt32(dr["id"]);
                    oSupplier.Name = dr["name"].ToString();
                    oSupplier.Address = dr["address"].ToString();
                    oSupplier.Phone = dr["phone"].ToString();

                }
            }
        }
        return oSupplier;
    }
    //CREATE
    public bool CreateSupplier(SupplierModel oSupplier)
    {
        bool rpta;
        try
        {
            var cn = new Conection();

            using (var conection = new MySqlConnection(cn.getChainMySql()))
            {
                conection.Open();
                MySqlCommand cmd = new MySqlCommand("SpCreateSupplier", conection);
                cmd.Parameters.AddWithValue("p_name", oSupplier.Name);
                cmd.Parameters.AddWithValue("p_address", oSupplier.Address);
                cmd.Parameters.AddWithValue("p_phone", oSupplier.Phone);
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
    public bool EditSupplier(SupplierModel oSupplier)
    {
        bool rpta;
        try
        {
            var cn = new Conection();

            using (var conection = new MySqlConnection(cn.getChainMySql()))
            {
                conection.Open();
                MySqlCommand cmd = new MySqlCommand("SpEditSupplier", conection);
                cmd.Parameters.AddWithValue("p_id", oSupplier.IdSupplier);

                cmd.Parameters.AddWithValue("p_name", oSupplier.Name);
                cmd.Parameters.AddWithValue("p_address", oSupplier.Address);
                cmd.Parameters.AddWithValue("p_phone", oSupplier.Phone);
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
    public bool DeleteSupplier(int IdSupplier)
    {
        bool rpta;
        try
        {
            var cn = new Conection();

            using (var conection = new MySqlConnection(cn.getChainMySql()))
            {
                conection.Open();
                MySqlCommand cmd = new MySqlCommand("SpDeleteSupplier", conection);
                cmd.Parameters.AddWithValue("p_id", IdSupplier);

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
