// <Snippet1>
using System;
using System.Data.SqlClient;

class Program {
   public static void Main() {
      SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

      builder["Password"] = null;
      string aa = builder.Password;
      Console.WriteLine(aa.Length);

      builder["Password"] = "??????";
      aa = builder.Password;
      Console.WriteLine(aa.Length);

      try {
         builder.Password = null;
      }
      catch (ArgumentNullException e) {
         Console.WriteLine("{0}", e);
      }
   }
}
// </Snippet1>