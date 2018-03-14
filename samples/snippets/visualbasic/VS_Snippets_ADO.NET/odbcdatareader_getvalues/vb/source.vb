' <Snippet1>
Imports System
Imports System.Data
Imports System.Data.Odbc

Module Module1
   Public Sub Main()
      Using connection As New OdbcConnection("Driver={Microsoft Access Driver (*.mdb)};DBQ=C:\\Northwind.mdb")
         Dim command As New OdbcCommand("select * from Shippers", connection)

         connection.Open()
         Dim reader As OdbcDataReader = command.ExecuteReader()

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