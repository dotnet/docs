Imports System.Data
Imports System.Data.OleDb

Public Module modMain

   Public Sub Main()
      Dim conn As New OleDbConnection
      Dim cmd As New OleDbCommand
      Dim adapter As New OleDbDataAdapter
      Dim ds As New DataSet
      Dim dbFilename As String = "c:\Data\contacts.mdb"
      ' Open database connection
      conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
                               dbFilename & ";"
      conn.Open()
      ' Define command : retrieve all records in contact table
      cmd.CommandText = "SELECT * FROM Contact"
      cmd.Connection = conn
      adapter.SelectCommand = cmd
      ' Fill dataset
      ds.Clear()
      adapter.Fill(ds, "Contact")
      ' Close connection
      conn.Close()
      ' Output labels to console	
      OutputLabels(ds.Tables("Contact"))
   End Sub

   ' <Snippet1>
   Private Sub OUtputLabels(dt As DataTable)
      Dim label As String 

      ' Iterate rows of table
      For Each row As DataRow In dt.Rows
         Dim labelLen As Integer
         label = String.Empty
         label += AddFieldValue(label, row, "Title")
         label += AddFieldValue(label, row, "FirstName")
         label += AddFieldValue(label, row, "MiddleInitial")
         label += AddFieldValue(label, row, "LastName")
         label += AddFieldValue(label, row, "Suffix")
         label += vbCrLf
         label += AddFieldValue(label, row, "Address1")
         label += AddFieldValue(label, row, "AptNo")
         label += vbCrLf
         labelLen = Len(label)
         label += AddFieldValue(label, row, "Address2")
         If Len(label) <> labelLen Then label += vbCrLf
         label += AddFieldValue(label, row, "City")
         label += AddFieldValue(label, row, "State")
         label += AddFieldValue(label, row, "Zip")
         Console.WriteLine(label)
         Console.WriteLine()
      Next
   End Sub

   Private Function AddFieldValue(label As String, row As DataRow, _
                             fieldName As String) As String
      If Not DbNull.Value.Equals(row.Item(fieldName)) Then
         Return CStr(row.Item(fieldName)) & " "
      Else
         Return Nothing
      End If
   End Function
   ' </Snippet1>   
End Module
