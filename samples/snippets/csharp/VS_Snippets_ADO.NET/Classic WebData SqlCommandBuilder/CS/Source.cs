using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlCommandBuilderCS
{
    class Program
    {
        static void Main()
        {
            string cnnst = "";
            string queryst = "";
            string tablen = "";
            DataSet ds = SelectSqlRows(cnnst, queryst, tablen);

        }
        // <Snippet1>
        public static DataSet SelectSqlRows(string connectionString,
            string queryString, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(queryString, connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                connection.Open();

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, tableName);

                //code to modify data in DataSet here

                builder.GetUpdateCommand();

                //Without the SqlCommandBuilder this line would fail
                adapter.Update(dataSet, tableName);

                return dataSet;
            }
        }
        // </Snippet1>
    }
}
