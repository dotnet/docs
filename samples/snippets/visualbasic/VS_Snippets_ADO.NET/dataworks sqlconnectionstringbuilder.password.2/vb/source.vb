' <Snippet1>
Imports System.Data.SqlClient
Public Class Program
   Public Shared Sub Main()

      Dim builder As New SqlConnectionStringBuilder()

      builder("Password") = Nothing
      Dim aa As String = builder.Password
      Console.WriteLine(aa.Length)

      builder("Password") = "??????"
      aa = builder.Password
      Console.WriteLine(aa.Length)

      Try
         builder.Password = Nothing
      Catch e As ArgumentNullException
         Console.WriteLine("{0}", e)
      End Try
   End Sub
End Class
' </Snippet1>