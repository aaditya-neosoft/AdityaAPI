using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace AdityaAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly string _connectionString;

        public Repository(IConfiguration connectionString)
        {
            _connectionString = connectionString.GetConnectionString("TestDemo");
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }

        public IEnumerable<T> GetAll(string tableName, string storedProcedureName)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();

                    // Example: Query using stored procedure
                    var result = dbConnection.Query<T>(storedProcedureName, commandType: CommandType.StoredProcedure);

                    // Or, if you want to query using dynamic SQL with table name
                    // var result = dbConnection.Query<T>($"SELECT * FROM {tableName}");

                    return result;
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception appropriately
                throw new Exception("Error fetching records", ex);
            }
        }



        public IEnumerable<T> GetAll()
        {
            List<T> result = new List<T>();
            try
            {
                //using (IDbConnection dbConnection = new SqlConnection(_connectionString))
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    result = dbConnection.Query<T>("usp_stp_Emp_GetAllEmployee", commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            //List<T> products = new List<T>();

            //using (SqlConnection connection = new SqlConnection(_connectionString))
            //{
            //    string query = "SELECT Id, Name, Price FROM Products";
            //    SqlCommand command = new SqlCommand(query, connection);
            //    connection.Open();
            //    SqlDataReader reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        Product product = new Product
            //        {
            //            Id = reader.GetInt32(0),
            //            Name = reader.GetString(1),
            //            Price = reader.GetDecimal(2)
            //        };
            //        products.Add(product);
            //    }
            //}

            //return products;
        }
        
    }
}
