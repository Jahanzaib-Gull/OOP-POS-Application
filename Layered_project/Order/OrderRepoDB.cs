using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered_project.Order
{
    internal class OrderRepoDB
    {
        private readonly string DBConnection = "Server=localhost;Database=POS;Trusted_Connection=True;";

        public List<OrderModel> GetAll()
        {
            List<OrderModel> all = new List<OrderModel>();

            using (SqlConnection conn = new SqlConnection(DBConnection))
            {
                conn.Open();
                string query = "SELECT * FROM Customer";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string customername = reader["Name"].ToString();
                    string contact = reader["Contact"].ToString();
                    string address = reader["Address"].ToString();
                    string items = reader["items"].ToString();
                    
                }

            }
        }

        public bool Create(OrderModel model)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection))
            {
                conn.Open();
                string query = "INSERT INTO Orders(Name,Contact,Address,Items)" +
                    "VALUES(@name,@contact,@address,@item)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", model.customername);
                cmd.Parameters.AddWithValue("@contact",model.contact);
                cmd.Parameters.AddWithValue("@address", model.address);
                string items = "";
                foreach (var order in model.ordersList)
                {
                    items = items + order.ToString() + "|";
                }
                cmd.Parameters.AddWithValue("@item", items);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0) return true;
                return false;
            }
        }
    }
}
