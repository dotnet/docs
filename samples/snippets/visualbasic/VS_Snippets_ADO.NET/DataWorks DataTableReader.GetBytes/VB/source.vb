Option Explicit
Option Strict
' <Snippet1>
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Drawing.Imaging
    
Module Module1
   Sub Main()
      TestGetBytes()
   End Sub
   Private Sub TestGetBytes()
         ' Set up the data adapter, using information from 
      ' the AdventureWorks sample database.
      Dim photoAdapter As SqlDataAdapter = _
         SetupDataAdapter("SELECT ThumbnailPhotoFileName, " & _
         "ThumbNailPhoto FROM Production.ProductPhoto")

      ' Fill the DataTable.
      Dim photoDataTable As New DataTable
      photoAdapter.Fill(photoDataTable)

      ' Create the DataTableReader.
      Using reader As DataTableReader = New DataTableReader(photoDataTable)

         Dim buffer() As Byte
         Dim productName As String
         While reader.Read()
            Try
               ' Get the name of the file.
               productName = reader.GetString(0)

               ' Get the length of the field. Pass Nothing
               ' in the buffer parameter to retrieve the length
               ' of the data field. Ensure that the field isn't 
               ' null before continuing.
               If reader.IsDBNull(1) Then
                  Console.WriteLine( _
                     productName & " is unavailable.")
               Else
                  ' Retrieve the length of the necessary byte array.
                  Dim len As Long = reader.GetBytes(1, 0, Nothing, 0, 0)
                  ' Create a buffer to hold the bytes, and then 
                  ' read the bytes from the DataTableReader.
                  ReDim buffer(CInt(len))
                  reader.GetBytes(1, 0, buffer, 0, CInt(len))

                  ' Create a new Bitmap object, passing the array
                  ' of bytes to the constructor of a MemoryStream.
                  Using productImage As New Bitmap(New MemoryStream(buffer))
                     Dim fileName As String = "C:\" & productName
                     ' Save in gif format.
                     productImage.Save( _
                      fileName, ImageFormat.Gif)
                     Console.WriteLine("Successfully created " & _
                        fileName)
                  End Using
               End If
            Catch ex As Exception
               Console.WriteLine(productName & ": " & _
                  ex.Message)
            End Try
         End While
      End Using
      Console.WriteLine("Press Enter to finish.")
      Console.ReadLine()
   End Sub

   Private Function SetupDataAdapter( _
      ByVal sqlString As String) As SqlDataAdapter
      ' Assuming all the default settings, create a SqlDataAdapter
      ' working with the AdventureWorks sample database that's 
      ' available with SQL Server.
      Dim connectionString As String = _
         "Data Source=(local);" & _
         "Initial Catalog=AdventureWorks;" & _
         "Integrated Security=true"
      Return New SqlDataAdapter(sqlString, connectionString)
   End Function
End Module
' </Snippet1>

