<Serializable(), SoapTypeAttribute(XmlNamespace := "MyXmlNamespace")> Public Class TestSimpleObject
   
   Public member1 As Integer

   <SoapFieldAttribute(XmlElementName := "MyXmlElement")> Public member2 As String
   
   Public member3 As String
   Public member4 As Double

   ' A field that is not serialized.
   <NonSerialized()> Public member5 As String  


   Public Sub New()
      member1 = 11
      member2 = "hello"
      member3 = "hello"
      member4 = 3.14159265
      member5 = "hello world!"
   End Sub 'New

End Class 'TestSimpleObject