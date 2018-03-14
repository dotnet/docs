'<snippet1>
Imports System
Imports System.Xml
Imports System.IO

Module Module1

    Sub Main()
        ' Create an XmlUrlResolver with default credentials.
        Dim resolver As New XmlUrlResolver()
        resolver.Credentials = System.Net.CredentialCache.DefaultCredentials

        ' Point the resolver at the desired resource and resolve as a stream.
        Dim baseUri As New Uri("http://serverName/")
        Dim fulluri As Uri = resolver.ResolveUri(baseUri, "fileName.xml")
        Dim s As Stream = CType(resolver.GetEntity(fulluri, Nothing, GetType(Stream)), Stream)

        ' Create the reader with the resolved stream and display the data.
        Dim reader As XmlReader = XmlReader.Create(s)
        While reader.Read()
            Console.WriteLine(reader.ReadOuterXml())
        End While
    End Sub
End Module
'</snippet1>