' <Snippet1>
Imports System
Imports System.Data
Imports System.Data.SqlClient

Module Module1
   Sub Main()
      Using connection As New SqlConnection("Data Source=(local);Initial Catalog=AdventureWorks2012;Integrated Security=SSPI")
         Dim command As New SqlCommand("SELECT p.FirstName, p.MiddleName, p.LastName FROM HumanResources.Employee AS e" & _
                                       " JOIN Person.Person AS p ON e.BusinessEntityID = p.BusinessEntityID;", connection)
         connection.Open()
         Dim reader As SqlDataReader = command.ExecuteReader()
         While reader.Read()
            Console.Write(reader.GetString(reader.GetOrdinal("FirstName")))

            ' display middle name only of not null
            If Not reader.IsDBNull(reader.GetOrdinal("MiddleName")) Then
               Console.Write(" {0}", reader.GetString(reader.GetOrdinal("MiddleName")))
            End If

            Console.WriteLine(" {0}", reader.GetString(reader.GetOrdinal("LastName")))
         End While
         connection.Close()
      End Using
   End Sub
End Module
' </Snippet1>