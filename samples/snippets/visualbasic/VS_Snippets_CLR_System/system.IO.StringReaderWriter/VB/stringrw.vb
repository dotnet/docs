' <Snippet1>
Option Explicit
Option Strict

Imports Microsoft.VisualBasic
Imports System
Imports System.IO

Public Class StrReader

    Shared Sub Main()
    
        Dim textReaderText As String = "TextReader is the " & _
            "abstract base class of StreamReader and " & _
            "StringReader, which read characters from streams " & _
            "and strings, respectively." & _
            vbCrLf & vbCrLf & _
            "Create an instance of TextReader to open a text " & _
            "file for reading a specified range of characters, " & _
            "or to create a reader based on an existing stream." & _
            vbCrLf & vbCrLf & _
            "You can also use an instance of TextReader to read " & _
            "text from a custom backing store using the same " & _
            "APIs you would use for a string or a stream." & _
            vbCrLf & vbCrLf

        Console.WriteLine("Original text:" & vbCrLf & vbCrLf & _
            textReaderText)

        ' <Snippet2>
        ' From textReaderText, create a continuous paragraph 
        ' with two spaces between each sentence.
        Dim aLine, aParagraph As String
        Dim strReader As New StringReader(textReaderText)
        While True
            aLine = strReader.ReadLine()
            If aLine Is Nothing Then
                aParagraph = aParagraph & vbCrLf
                Exit While
            Else
                aParagraph = aParagraph & aLine & " "
            End If
        End While
        Console.WriteLine("Modified text:" & vbCrLf & vbCrLf & _ 
            aParagraph)
        ' </Snippet2>
    
        ' Re-create textReaderText from aParagraph.
        Dim intCharacter As Integer 
        Dim convertedCharacter As Char 
        Dim strWriter As New StringWriter()
        strReader = New StringReader(aParagraph)
        While True
            intCharacter = strReader.Read()

            ' Check for the end of the string 
            ' before converting to a character.
            If intCharacter = -1 Then
                Exit While
            End If

            ' <Snippet3>
            convertedCharacter = Convert.ToChar(intCharacter)
            If convertedCharacter = "."C Then
                strWriter.Write("." & vbCrLf & vbCrLf)

                ' Bypass the spaces between sentences.
                strReader.Read()
                strReader.Read()
            ' </Snippet3>
            Else
                strWriter.Write(convertedCharacter)
            End If
        End While
        Console.WriteLine(vbCrLf & "Original text:" & vbCrLf & _ 
            vbCrLf & strWriter.ToString())

    End Sub
End Class
' </Snippet1>