using SalesOrderManagementSystem.Utility;
using System.Data;
using System.Data.SqlClient;

namespace SalesOrderManagementSystem.Models
{
    public class OrderDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Order> GetAllOrder()
        {
            List<Order> lstOrder = new List<Order>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Order order = new Order();
                    order.SalesOrder = rdr["SalesOrder"].ToString();
                    order.SalesOrderItem = rdr["SalesOrderItem"].ToString();
                    order.WorkOrder = rdr["WorkOrder"].ToString();
                    order.ProductID = rdr["ProductID"].ToString();
                    order.ProductDescription = rdr["ProductDescription"].ToString();
                    order.OrderQty = rdr.GetDecimal("OrderQty");
                    order.OrderStatus = rdr["OrderStatus"].ToString();
                    order.Timestamp = (DateTime)rdr["Timestamp"];

                    lstOrder.Add(order);
                }
                con.Close();
            }
            return lstOrder;
        }
        public void AddOrder(Order order)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SalesOrder", order.SalesOrder);
                cmd.Parameters.AddWithValue("@SalesOrderItem", order.SalesOrderItem);
                cmd.Parameters.AddWithValue("@WorkOrder", order.WorkOrder);
                cmd.Parameters.AddWithValue("@ProductID", order.ProductID);
                cmd.Parameters.AddWithValue("@ProductDescription", order.ProductDescription);
                cmd.Parameters.AddWithValue("@OrderQty", order.OrderQty);
                cmd.Parameters.AddWithValue("@OrderStatus", order.OrderStatus);
                cmd.Parameters.AddWithValue("@Timestamp", order.Timestamp);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateOrder(Order order)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SalesOrder", order.SalesOrder);
                cmd.Parameters.AddWithValue("@SalesOrderItem", order.SalesOrderItem);
                cmd.Parameters.AddWithValue("@WorkOrder", order.WorkOrder);
                cmd.Parameters.AddWithValue("@ProductID", order.ProductID);
                cmd.Parameters.AddWithValue("@ProductDescription", order.ProductDescription);
                cmd.Parameters.AddWithValue("@OrderQty", order.OrderQty);
                cmd.Parameters.AddWithValue("@OrderStatus", order.OrderStatus);
                cmd.Parameters.AddWithValue("@Timestamp", order.Timestamp);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Order GetOrderData(string workOrder)
        {
            Order order = new Order();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM OrderProductDetails WHERE WorkOrder= " + "'" + workOrder + "'";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    order.SalesOrder = rdr["SalesOrder"].ToString();
                    order.SalesOrderItem = rdr["SalesOrderItem"].ToString();
                    order.WorkOrder = rdr["WorkOrder"].ToString();
                    order.ProductID = rdr["ProductID"].ToString();
                    order.ProductDescription = rdr["ProductDescription"].ToString();
                    order.OrderQty = rdr.GetDecimal("OrderQty");
                    order.OrderStatus = rdr["OrderStatus"].ToString();
                    order.Timestamp = (DateTime)rdr["Timestamp"];
                }
            }
            return order;
        }

        public void DeleteOrder(string workOrder)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WorkOrder", workOrder);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
