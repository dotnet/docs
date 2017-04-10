Imports System.Data
Imports System.Data.SqlClient

Public Class Form1

   Private connectionString As String = "Data Source=RONPET59\SQLEXPRESS;Initial Catalog=SurveyDB;Integrated Security=True"

   Private Function CompareForMissing(ByVal value As Object) As Boolean
      ' <Snippet1>
      Return DBNull.Value.Equals(value)
      ' </Snippet1> 
   End Function

   ' <Snippet2>
   Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' Define ADO.NET objects.
      Dim conn As New SqlConnection(connectionString)
      Dim cmd As New SqlCommand
      Dim dr As SqlDataReader

      ' Open connection, and retrieve dataset.
      conn.Open()

      ' Define Command object.
      cmd.CommandText = "Select * From Responses"
      cmd.CommandType = CommandType.Text
      cmd.Connection = conn

      ' Retrieve data reader.
      dr = cmd.ExecuteReader()

      Dim fieldCount As Integer = dr.FieldCount
      Dim fieldValues(fieldCount - 1) As Object
      Dim headers(fieldCount - 1) As String

      ' Get names of fields.
      For ctr As Integer = 0 To fieldCount - 1
         headers(ctr) = dr.GetName(ctr)
      Next

      ' Set up data grid.
      grid.ColumnCount = fieldCount

      With grid.ColumnHeadersDefaultCellStyle
         .BackColor = Color.Navy
         .ForeColor = Color.White
         .Font = New Font(grid.Font, FontStyle.Bold)
      End With

      With grid
         .AutoSizeRowsMode = _
             DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
         .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
         .CellBorderStyle = DataGridViewCellBorderStyle.Single
         .GridColor = Color.Black
         .RowHeadersVisible = True

         For columnNumber As Integer = 0 To headers.Length - 1
            .Columns(columnNumber).Name = headers(columnNumber)
         Next
      End With

      ' Get data, replace missing values with "NA", and display it.
      Do While dr.Read()
         dr.GetValues(fieldValues)

         For fieldCounter As Integer = 0 To fieldCount - 1
            If Convert.IsDBNull(fieldValues(fieldCounter)) Then
               fieldValues(fieldCounter) = "NA"
            End If
         Next
         grid.Rows.Add(fieldValues)
      Loop
      dr.Close()
   End Sub
   ' </Snippet2>
End Class
