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
    }
}
