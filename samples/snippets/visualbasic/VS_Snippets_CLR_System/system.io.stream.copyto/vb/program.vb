Imports System.IO
Module Module1

    Sub Main()
' <Snippet1>
' Create the streams.
Dim destination As New MemoryStream()

Using source As FileStream = File.Open("c:\temp\data.dat", _
                                       FileMode.Open)
    Console.WriteLine("Source length: {0}", source.Length.ToString())

    ' Copy source to destination.
    source.CopyTo(destination)

End Using
Console.WriteLine("Destination length: {0}", destination.Length.ToString())
' </Snippet1>
    End Sub

End Module
