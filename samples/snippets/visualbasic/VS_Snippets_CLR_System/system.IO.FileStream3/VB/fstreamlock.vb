' <Snippet1>
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Text

Public Class FStreamLock

    Shared Sub Main()
    
        Dim uniEncoding As New UnicodeEncoding()
        Dim lastRecordText As String = _
            "The last processed record number was: "
        Dim textLength As Integer = _
            uniEncoding.GetByteCount(lastRecordText)
        Dim recordNumber As Integer = 13
        Dim byteCount As Integer = _
            uniEncoding.GetByteCount(recordNumber.ToString())
        Dim tempString As String 

        ' <Snippet2>
        Dim aFileStream As New FileStream( _
            "Test#@@#.dat", FileMode.OpenOrCreate, _
            FileAccess.ReadWrite, FileShare.ReadWrite)
        ' </Snippet2>
        
        Try
            ' <Snippet3>
            ' Write the original file data.
            If aFileStream.Length = 0 Then
                tempString = _
                    lastRecordText + recordNumber.ToString()
                aFileStream.Write(uniEncoding.GetBytes(tempString), _
                    0, uniEncoding.GetByteCount(tempString))
            End If
            ' </Snippet3>

            ' Allow the user to choose the operation.
            Dim consoleInput As Char = "R"C
            Dim readText(CInt(aFileStream.Length)) As Byte
            While consoleInput <> "X"C

                Console.Write(vbcrLf & _
                    "Enter 'R' to read, 'W' to write, 'L' to " & _ 
                    "lock, 'U' to unlock, anything else to exit: ")

                tempString = Console.ReadLine()
                If tempString.Length = 0 Then
                    Exit While
                End If
                consoleInput = Char.ToUpper(tempString.Chars(0))
                Select consoleInput
                
                    ' Read data from the file and 
                    ' write it to the console.
                    Case "R"C
                        Try
                            aFileStream.Seek(0, SeekOrigin.Begin)
                            aFileStream.Read( _
                                readText, 0, CInt(aFileStream.Length))
                            tempString = New String( _
                                uniEncoding.GetChars( _
                                readText, 0, readText.Length))
                            Console.WriteLine(tempString)
                            recordNumber = Integer.Parse( _
                                tempString.Substring( _
                                tempString.IndexOf(":"C) + 2))

                        ' Catch the IOException generated if the 
                        ' specified part of the file is locked.
                        Catch ex As IOException
                            Console.WriteLine("{0}: The read " & _
                                "operation could not be performed " & _
                                "because the specified part of the" & _
                                " file is locked.", _
                                ex.GetType().Name)
                        End Try
                        Exit Select

                    ' <Snippet4>
                    ' Update the file.
                    Case "W"C
                        Try
                            aFileStream.Seek(textLength, _
                                SeekOrigin.Begin)
                            aFileStream.Read( _
                                readText, textLength - 1, byteCount)
                            tempString = New String( _
                                uniEncoding.GetChars( _
                                readText, textLength - 1, byteCount))
                            recordNumber = _
                                Integer.Parse(tempString) + 1
                            aFileStream.Seek( _
                                textLength, SeekOrigin.Begin)
                            aFileStream.Write(uniEncoding.GetBytes( _
                                recordNumber.ToString()), 0, byteCount)
                            aFileStream.Flush()
                            Console.WriteLine( _
                                "Record has been updated.")
                    ' </Snippet4>

                        ' <Snippet6>
                        ' Catch the IOException generated if the 
                        ' specified part of the file is locked.
                        Catch ex As IOException
                            Console.WriteLine( _
                                "{0}: The write operation could " & _
                                "not be performed because the " & _
                                "specified part of the file is " & _
                                "locked.", ex.GetType().Name)
                        End Try
                        ' </Snippet6>
                        Exit Select

                    ' Lock the specified part of the file.
                    Case "L"C
                        Try
                            aFileStream.Lock(textLength - 1, byteCount)
                            Console.WriteLine("The specified part " & _
                                "of file has been locked.")
                        Catch ex As IOException
                            Console.WriteLine( _
                                "{0}: The specified part of file " & _
                                "is already locked.", _
                                ex.GetType().Name)
                        End Try
                        Exit Select

                    ' <Snippet5>
                    ' Unlock the specified part of the file.
                    Case "U"C
                        Try
                            aFileStream.Unlock( _
                                textLength - 1, byteCount)
                            Console.WriteLine("The specified part " & _
                                "of file has been unlocked.")
                        Catch ex As IOException
                            Console.WriteLine( _
                                "{0}: The specified part of file " & _
                                "is not locked by the current " & _
                                "process.", ex.GetType().Name)
                        End Try
                        Exit Select
                    ' </Snippet5>

                    ' Exit the program.
                    Case Else
                        consoleInput = "X"C
                        Exit While
                End Select
            End While

        Finally
            aFileStream.Close()    
        End Try

    End Sub
End Class
' </Snippet1>