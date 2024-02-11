using MySql.Data.MySqlClient;


namespace SistemSales.Data
{
    public class Conection
    {
        private string chainMySql = string.Empty;

        public Conection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            chainMySql = builder.GetSection("ConnectionStrings:ConectionMySql").Value;
        }

        public string getChainMySql(){
            return chainMySql;
        }
    }
}
