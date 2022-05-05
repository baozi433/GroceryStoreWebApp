using MyFirstWeb.Models;
using System.Data.SqlClient;

namespace MyFirstWeb.Services
{
    public class ProductsDAO : IProductService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int Delete(ProductModel product)
        {
            int newIdNumber = -1;
            string sqlStatement = "DELETE FROM dbo.Products WHERE Id = @Id";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, sqlConnection);
                command.Parameters.AddWithValue("@Id", product.Id); 

                try
                {
                    sqlConnection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return newIdNumber;
            }
        }

        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> foundProducts = new List<ProductModel>();
            string sqlStatement = "SELECT * FROM dbo.Products";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, sqlConnection);
                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        foundProducts.Add(new ProductModel { Id = (int)reader["Id"], Name = (string)reader["Name"], Price = (decimal)reader["Price"], Description = (string)reader["Description"]});
                    }         
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return foundProducts;
            }
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            List<ProductModel> foundProducts = new List<ProductModel>();
            string sqlStatement = "SELECT * FROM dbo.Products WHERE Name LIKE @Name";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, sqlConnection);
                command.Parameters.AddWithValue("@Name", '%' + searchTerm + '%'); //partial search support with '%'

                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel { Id = (int)reader["Id"], Name = (string)reader["Name"], Price = (decimal)reader["Price"], Description = (string)reader["Description"] });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return foundProducts;
            }
        }

        public ProductModel GetProductById(int id)
        {
            ProductModel foundProduct = null;
            string sqlStatement = "SELECT * FROM dbo.Products WHERE Id LIKE @Id";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, sqlConnection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProduct = new ProductModel { Id = (int)reader["Id"], Name = (string)reader["Name"], Price = (decimal)reader["Price"], Description = (string)reader["Description"] };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return foundProduct;
            }
        }

        public int Insert(ProductModel product)
        {
            int newId = -1;
            string sqlStatement = "INSERT INTO dbo.Products (Name, Price, Description) VALUES (@Name, @Price, @Description)";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, sqlConnection);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);
                try
                {
                    sqlConnection.Open();
                    newId = Convert.ToInt32(command.ExecuteScalar());                 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return newId;
            }
        }

        public int Update(ProductModel product)
        {
            int newIdNumber = -1;
            string sqlStatement = "UPDATE dbo.Products SET Name = @Name, Price = @Price, Description = @Description WHERE Id = @Id";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, sqlConnection);
                command.Parameters.AddWithValue("@Id", product.Id);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);

                try
                {
                    sqlConnection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return newIdNumber;
            }
        }
    }
}
