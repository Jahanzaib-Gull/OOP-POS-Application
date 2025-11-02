using Layered_project.Customer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered_project.Product
{
    internal class ProductRepoDB
    {
        private readonly string DBConnection = "Server=localhost;Database=POS;Trusted_Connection=True;";

        public bool Create(ProductModel product)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection))
            {
                string query = "INSERT INTO Product (Name, Description, PurchasePrice, SalePrice, Discount)" +
                               "VALUES (@name, @description, @purchasePrice, @salePrice, @discount)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", product.name);
                cmd.Parameters.AddWithValue("@description", product.description);
                cmd.Parameters.AddWithValue("@purchasePrice", product.purchasePrice);
                cmd.Parameters.AddWithValue("@salePrice", product.salePrice);
                cmd.Parameters.AddWithValue("@discount", product.discount);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0) return true;
                return false;
            }
        }

        public List<ProductModel> GetAll()
        {
            List<ProductModel> products = new List<ProductModel>();
            using (SqlConnection conn = new SqlConnection(DBConnection))
            {
                conn.Open();
                string query = "SELECT * FROM Product";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string name = reader["Name"].ToString();
                    string description = reader["Description"].ToString();
                    float purchasePrice = Convert.ToSingle(reader["PurchasePrice"]);
                    float salePrice = Convert.ToSingle(reader["SalePrice"]);
                    float discount = Convert.ToSingle(reader["Discount"]);
                    ProductModel product = new ProductModel(id, name, description, purchasePrice, salePrice, discount);
                    products.Add(product);
                }
                reader.Close();
            }
            return products;
        }
    }
}

