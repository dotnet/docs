Option Explicit
Option Strict

Imports System
Imports System.Data
Module Module1

   Sub Main()

   End Sub
    
' <Snippet1>
Private Function GetValueByName( _
   ByVal reader As DataTableReader, _
   ByVal columnName As String) As Object

   ' Consider when to use a procedure like this one carefully:
   ' If you're going to retrieve information from a column
   ' in a loop, it would be better to retrieve the column
   ' ordinal once, store the value, and use the methods
   ' of the DataTableReader class directly. 
   Dim columnValue As Object

   Try
      Dim columnOrdinal As Integer = reader.GetOrdinal(columnName)
      columnValue = reader.GetValue(columnOrdinal)
   Catch ex As ArgumentException
      ' Throw all other errors back out to the caller.
      columnValue = Nothing
   End Try
   Return columnValue
End Function
' </Snippet1>
End Module


