Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Text

Public Class StrWriter

    Shared Sub Main()

        Dim strWriter As StringWriter = new StringWriter()

        ' Use the three overloads of the Write method that are 
        ' overridden by the StringWriter class.
        strWriter.Write("file path characters are: ")
        strWriter.Write( _
            Path.InvalidPathChars, 0, Path.InvalidPathChars.Length)
        strWriter.Write("."C)

        ' Use the underlying StringBuilder for more complex 
        ' manipulations of the string.
        strWriter.GetStringBuilder().Insert(0, "Invalid ")

        Console.WriteLine("The following string is {0} encoded." _
            & vbCrLf & "{1}", _
            strWriter.Encoding.EncodingName, strWriter.ToString())

    End Sub
End Class