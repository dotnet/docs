Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


Public Class Sample
    
    ' <Snippet1>
    Private Function AddNamespaces() As XmlSerializerNamespaces
        Dim xmlNamespaces As New XmlSerializerNamespaces()
        
        ' Add three prefix-namespace pairs.
        xmlNamespaces.Add("money", "http://www.cpandl.com")
        xmlNamespaces.Add("books", "http://www.cohowinery.com")
        xmlNamespaces.Add("software", "http://www.microsoft.com")
        
        Return xmlNamespaces
    End Function
    
    ' </Snippet1>
End Class

