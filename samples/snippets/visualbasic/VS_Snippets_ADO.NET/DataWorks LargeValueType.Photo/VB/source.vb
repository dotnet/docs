Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO

Module Module1

    Sub Main()
        ' Supply any valid DocumentID value and file path.
        ' The value 3 is supplied for DocumentID, and a literal
        ' string for the file path where the image will be saved.
        GetPhoto(7, "c:\temp\")
        Console.ReadLine()
    End Sub

    ' <Snippet1>
    Private Sub GetPhoto( _
      ByVal documentID As Integer, ByVal filePath As String)
        ' Assumes GetConnectionString returns a valid connection string.
        Using connection As New SqlConnection(GetConnectionString())
            Dim command As SqlCommand = connection.CreateCommand()
            Dim reader As SqlDataReader
            Try
                ' Setup the command
                command.CommandText = _
                  "SELECT LargePhotoFileName, LargePhoto FROM" _
                    & " Production.ProductPhoto" _
                    & " WHERE ProductPhotoID=@ProductPhotoID"
                command.CommandType = CommandType.Text

                ' Declare the parameter
                Dim paramID As SqlParameter = _
                    New SqlParameter("@ProductPhotoID", SqlDbType.Int)
                paramID.Value = documentID
                command.Parameters.Add(paramID)
                connection.Open()

                Dim photoName As String

                reader = _
                 command.ExecuteReader(CommandBehavior.CloseConnection)

                If reader.HasRows Then
                    While reader.Read()
                        ' Get the name of the file
                        photoName = reader.GetString(0)

                        ' Ensure that the column isn't null
                        If (reader.IsDBNull(1)) Then
                            Console.WriteLine("{0} is unavailable.", photoName)
                        Else
                            Dim bytes As SqlBytes = reader.GetSqlBytes(1)
                            Using productImage As Bitmap = _
                              New Bitmap(bytes.Stream)
                                Dim fileName As String = filePath & photoName

                                ' Save in gif format.
                                productImage.Save( _
                                  fileName, ImageFormat.Gif)
                                Console.WriteLine("Successfully created {0}.", fileName)
                            End Using
                        End If
                    End While
                Else
                    Console.WriteLine("No records returned.")
                End If
            Catch ex As Exception
                Console.WriteLine("Exception: {0}", ex.Message)
            End Try
        End Using
    End Sub
    ' </Snippet1>

    Private Function GetConnectionString() As String
        ' To avoid storing the connectionection string in your code,  
        ' you can retrieve it from a configuration file, using the
        ' System.Configuration.ConfigurationSettings.AppSettings property
        Return "Data Source=(local);Initial Catalog=AdventureWorks;" _
          & "Integrated Security=SSPI;"
    End Function


End Module
