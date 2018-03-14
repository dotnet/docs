' <Snippet1>
Imports System
Imports System.Data
Imports System.Data.OleDb

Module Module1
   Public Sub Main()
      Using connection As New OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Integrated Security=SSPI;Initial Catalog=Northwind")
         Dim command As New OleDbCommand("select * from Region", connection)

         connection.Open()
         Dim reader As OleDbDataReader = command.ExecuteReader()

         Dim NumberOfColums As Integer
         Dim meta As Object() = New Object(10) {}
         Dim read As Boolean

         If reader.Read() = True Then
            Do
               NumberOfColums = reader.GetValues(meta)

               For i As Integer = 0 To NumberOfColums - 1
                  Console.Write("{0} ", meta(i).ToString())
               Next

               Console.WriteLine()
               read = reader.Read()
            Loop While read = True
         End If

         reader.Close()
      End Using
   End Sub
End Module
' </Snippet1>