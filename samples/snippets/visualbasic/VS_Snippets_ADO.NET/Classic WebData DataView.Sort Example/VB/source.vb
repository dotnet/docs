' <Snippet1>
Imports System.Data
Public Class A
   Public Shared Sub Main(args As String())
      Dim locationTable As New DataTable("Location")
      ' Add two columns
      locationTable.Columns.Add("State")
      locationTable.Columns.Add("ZipCode")

      ' Add data 
      locationTable.Rows.Add("Washington", "98052")
      locationTable.Rows.Add("California", "90001")
      locationTable.Rows.Add("Hawaii", "96807")
      locationTable.Rows.Add("Hawaii", "96801")
      locationTable.AcceptChanges()

      Console.WriteLine("Rows in original order" & vbLf & " State " & vbTab & vbTab & " ZipCode")
      For Each row As DataRow In locationTable.Rows
         Console.WriteLine(" {0} " & vbTab & " {1}", row("State"), row("ZipCode"))
      Next

      ' Create DataView
      Dim view As New DataView(locationTable)

      ' Sort by State and ZipCode column in descending order
      view.Sort = "State ASC, ZipCode ASC"

      Console.WriteLine(vbLf & "Rows in sorted order" & vbLf & " State " & vbTab & vbTab & " ZipCode")
      For Each row As DataRowView In view
         Console.WriteLine(" {0} " & vbTab & " {1}", row("State"), row("ZipCode"))
      Next
   End Sub
End Class
' </Snippet1>