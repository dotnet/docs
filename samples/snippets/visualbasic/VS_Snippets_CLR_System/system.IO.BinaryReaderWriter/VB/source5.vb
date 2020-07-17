'<snippet6>
Imports System.IO
Imports System.Text

Module Module1
    Private ReadOnly CHUNK_SIZE As Integer = 1024
    Public Sub Main(args() As String)
        If ((args.Length = 0) OrElse Not File.Exists(args(0))) Then
            Console.WriteLine("Please provide an existing file name.")
        Else
            Using fs As FileStream = New FileStream(args(0), FileMode.Open, FileAccess.Read)
                Using br As New BinaryReader(fs, New ASCIIEncoding())
                    Dim chunk(CHUNK_SIZE) As Byte
                    chunk = br.ReadBytes(CHUNK_SIZE)

                    While chunk.Length > 0
                        DumpBytes(chunk, chunk.Length)
                        chunk = br.ReadBytes(CHUNK_SIZE)
                    End While
                End Using
            End Using
        End If
    End Sub

    Public Sub DumpBytes(bdata() As Byte, len As Integer)
        Dim i As Integer
        Dim j As Integer = 0
        Dim dchar As Char
        ' 3 * 16 chars for hex display, 16 chars for text and 8 chars
        ' for the 'gutter' int the middle.
        Dim dumptext As New StringBuilder("        ", 16 * 4 + 8)
        For i = 0 To len - 1
            dumptext.Insert(j * 3, String.Format("{0:X2} ", CType(bdata(i), Integer)))
            dchar = Convert.ToChar(bdata(i))
            ' replace 'non-printable' chars with a '.'.
            If Char.IsWhiteSpace(dchar) Or Char.IsControl(dchar) Then
                dchar = "."
            End If
            dumptext.Append(dchar)
            j += 1
            If j = 16 Then
                Console.WriteLine(dumptext)
                dumptext.Length = 0
                dumptext.Append("        ")
                j = 0
            End If
        Next i
        ' display the remaining line
        If j > 0 Then
            ' add blank hex spots to align the 'gutter'.
            For i = j To 15
                dumptext.Insert(j * 3, "   ")
            Next i
            Console.WriteLine(dumptext)
        End If
    End Sub

End Module
'</snippet6>
