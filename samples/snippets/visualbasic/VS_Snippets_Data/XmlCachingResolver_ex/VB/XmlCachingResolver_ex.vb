Imports System
Imports System.IO
Imports System.Xml
Imports System.Net
Imports System.Net.Cache

Module Module1

    '<snippet1>
    Class XmlCachingResolver
        Inherits XmlUrlResolver
        Dim enableHttpCaching As Boolean
        Public Shadows Credentials As ICredentials

        'resolve resources from cache (if possible) when enableHttpCaching is set to true
        'resolve resources from source when enableHttpcaching is set to false
        Public Sub New(ByVal enableHttpCaching As Boolean)
            Me.enableHttpCaching = enableHttpCaching
        End Sub

        Public Shadows Function GetEntity(ByVal absoluteUri As Uri, ByVal role As String, ByVal returnType As Type) As Object
            If absoluteUri = Nothing Then
                Throw New ArgumentNullException("absoluteUri")
            End If

            'resolve resources from cache (if possible)
            If absoluteUri.Scheme = "http" And enableHttpCaching And (returnType Is GetType(Nullable) Or returnType Is GetType(Stream)) Then
                Dim webReq As WebRequest = WebRequest.Create(absoluteUri)
                webReq.CachePolicy = New HttpRequestCachePolicy(HttpRequestCacheLevel.Default)
                If Not (Credentials Is Nothing) Then
                    webReq.Credentials = Credentials
                End If
                Dim resp As WebResponse = webReq.GetResponse()
                Return resp.GetResponseStream()
                'otherwise use the default behavior of the XmlUrlResolver class (resolve resources from source)
            Else
                Return MyBase.GetEntity(absoluteUri, role, returnType)
            End If

        End Function
    End Class
    '</snippet1>

    Sub Main()
	'<snippet2>
        Dim resolver As New XmlCachingResolver(True)
        Dim baseUri As New Uri("http://localhost/")
        Dim fulluri As Uri = resolver.ResolveUri(baseUri, "books.xml")

        'Get a stream object containing the XML file
        Dim s As Stream = CType(resolver.GetEntity(fulluri, Nothing, GetType(Stream)), Stream)

        'Read the stream object and display the contents of the file
        Dim reader As New XmlTextReader(s)
        Do While reader.Read()
            Console.WriteLine(reader.ReadOuterXml())
        Loop
    End Sub
    '</snippet2>
End Module
