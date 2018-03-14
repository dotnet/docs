Option Explicit
Option Strict

' <Snippet1>
Imports System
Imports System.Data
Imports System.IO

Module Module1

   Private Sub TestGetChars( _
      ByVal reader As DataTableReader, ByVal bufferSize As Integer)

      ' The filename is in column 0, and the contents are in column 1.
      Const FILENAME_COLUMN As Integer = 0
      Const DATA_COLUMN As Integer = 1

      Dim buffer() As Char
      Dim offset As Integer
      Dim charsRead As Integer
      Dim fileName As String
      Dim currentBufferSize As Integer

      While reader.Read
         ' Reinitialize the buffer size and the buffer itself.
         currentBufferSize = bufferSize
         ReDim buffer(bufferSize - 1)

         ' For each row, write the data to the specified file.

         ' First, verify that the FileName column isn't null.
         If Not reader.IsDBNull(FILENAME_COLUMN) Then
            ' Get the file name, and create a file with 
            ' the supplied name.
            fileName = reader.GetString(FILENAME_COLUMN)

            ' Start at the beginning.
            offset = 0

            Using outputStream As New StreamWriter(fileName, False)
               Try

                  ' Loop through all the characters in the input field,
                  ' incrementing the offset for the next time. If this
                  ' pass through the loop reads characters, write them to 
                  ' the output stream.
                  Do
                     charsRead = Cint(reader.GetChars(DATA_COLUMN, offset, _
                        buffer, 0, bufferSize))
                     If charsRead > 0 Then
                        outputStream.Write(buffer, 0, charsRead)
                        offset += charsRead
                     End If
                  Loop While charsRead > 0
               Catch ex As Exception
                  Console.WriteLine(fileName & ": " & ex.Message)
               End Try
            End Using
         End If
      End While
      Console.WriteLine("Press Enter key to finish.")
      Console.ReadLine()
   End Sub

   Sub Main()
      Dim table As New DataTable
      table.Columns.Add("FileName", GetType(System.String))
      table.Columns.Add("Data", GetType(System.Char()))
      table.Rows.Add("File1.txt", "0123456789ABCDEF".ToCharArray)
      table.Rows.Add("File2.txt", "0123456789ABCDEF".ToCharArray)

      Dim reader As New DataTableReader(table)
      TestGetChars(reader, 7)
   End Sub
End Module
' </Snippet1>

