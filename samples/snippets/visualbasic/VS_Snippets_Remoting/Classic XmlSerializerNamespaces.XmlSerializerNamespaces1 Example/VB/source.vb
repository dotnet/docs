Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


Public Class Sample
    
    ' <Snippet1>
    Private Function CreateFromQNames() As XmlSerializerNamespaces
        Dim q1 As New XmlQualifiedName("money", "http://www.cohowinery.com")
        Dim q2 As New XmlQualifiedName("books", "http://www.cpandl.com")
        
        Dim names() As XmlQualifiedName =  {q1, q2}
        
        Return New XmlSerializerNamespaces(names)
    End Function

    ' </Snippet1>
End Class 

