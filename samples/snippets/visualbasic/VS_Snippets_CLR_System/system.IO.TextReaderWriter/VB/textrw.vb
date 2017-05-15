' <Snippet1>
Imports System
Imports System.IO

Public Class TextRW

    Shared Sub Main()
        ' <Snippet2>
        Dim aStringWriter, aStreamWriter As TextWriter
        aStringWriter = New StringWriter()
        aStreamWriter = New StreamWriter("InvalidPathChars.txt")
        ' </Snippet2>
        
        WriteText(aStringWriter)
        WriteText(aStreamWriter)
        aStreamWriter.Close()
        
        ' <Snippet3>
        Dim aStringReader, aStreamReader As TextReader
        aStringReader = New StringReader(aStringWriter.ToString())
        aStreamReader = New StreamReader("InvalidPathChars.txt")
        ' </Snippet3>
        
        ReadText(aStringReader)
        ReadText(aStreamReader)
        aStreamReader.Close()
    End Sub

    ' <Snippet4>
    Shared Sub WriteText(aTextWriter As TextWriter)
        aTextWriter.Write("Invalid file path characters are: ")
        aTextWriter.Write(Path.InvalidPathChars)
        aTextWriter.Write("."C)
    End Sub
    ' </Snippet4>

    ' <Snippet5>
    Shared Sub ReadText(aTextReader As TextReader)
        Console.WriteLine("From {0} - {1}", _
            aTextReader.GetType().Name, aTextReader.ReadToEnd())
    End Sub
    ' </Snippet5>

End Class
' </Snippet1>
