    Private Function CreateFromQNames() As XmlSerializerNamespaces
        Dim q1 As New XmlQualifiedName("money", "http://www.cohowinery.com")
        Dim q2 As New XmlQualifiedName("books", "http://www.cpandl.com")
        
        Dim names() As XmlQualifiedName =  {q1, q2}
        
        Return New XmlSerializerNamespaces(names)
    End Function
