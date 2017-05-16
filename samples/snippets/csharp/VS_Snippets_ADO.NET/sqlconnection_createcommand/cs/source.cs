// <Snippet1>
using System.Data;
using System.Data.SqlClient;
public class A {
   public static void Main() {
      using (SqlConnection connection = new SqlConnection("Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI;")) {
         connection.Open();
         SqlCommand command= connection.CreateCommand();
         command.CommandText = "SELECT * FROM Categories ORDER BY CategoryID";
         command.CommandTimeout = 15;
         command.CommandType = CommandType.Text;
      }
   }
}
// </Snippet1>