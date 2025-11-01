using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered_project.Customer
{
    internal class CustomerRepoDB
    {
        private readonly string DBConnection = "Server=localhost;Database=POS;Trusted_Connection=True;";

        public bool Create(CustomerModel customer)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection))
            {
                string query = "INSERT INTO Customer (Name, Phone, Age, Address)" +
                               "VALUES (@name, @phone, @age, @address)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", customer.name);
                cmd.Parameters.AddWithValue("@phone", customer.phone);
                cmd.Parameters.AddWithValue("@age", customer.age);
                cmd.Parameters.AddWithValue("@address", customer.address);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0) return true;
                return false;
            }
        }

        public List<CustomerModel> GetAll()
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            using (SqlConnection conn = new SqlConnection(DBConnection))
            {
                conn.Open();
                string query = "SELECT * FROM Customer";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string name = reader["Name"].ToString();
                    string phoneNumber = reader["Phone"].ToString();
                    int age = Convert.ToInt32(reader["Age"]);
                    string address = reader["Address"].ToString();
                    customers.Add(new CustomerModel(id, name, phoneNumber, age, address));
                }
                reader.Close();
            }
            return customers;
        }

        public bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection))
            {
                conn.Open();
                string query = "DELETE FROM Customer WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0) return true;
                return false;
            }
        }
    }
}
