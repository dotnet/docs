 '<Snippet1>
Imports System
Imports System.Net
Imports System.IO



Public Class Test
    
    Public Shared Sub Main(args() As String)
        If args Is Nothing OrElse args.Length = 0 Then
            Throw New ApplicationException("Specify the URI of the resource to retrieve.")
        End If
        Dim client As New WebClient()
        
        ' Add a user agent header in case the 
        ' requested URI contains a query.
        client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)")
        
        Dim data As Stream = client.OpenRead(args(0))
        Dim reader As New StreamReader(data)
        Dim s As String = reader.ReadToEnd()
        Console.WriteLine(s)
        data.Close()
        reader.Close()
    End Sub 'Main
End Class 'Test
'</Snippet1>