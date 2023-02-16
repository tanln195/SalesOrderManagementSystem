namespace SalesOrderManagementSystem.Utility
{
    public static class ConnectionString
    {
        private static string cName = "Data Source=MSI\\SQLEXPRESS; Initial Catalog=SalesOrderDB;Integrated Security=True;";
        public static string CName
        {
            get => cName;
        }
    }
}
