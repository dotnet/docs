Imports System
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Soap
Imports System.Runtime.Remoting.Metadata


Public Class Test
   
   Public Shared Sub Main()
      
      ' Creates a new TestSimpleObject object.
      Dim obj As New TestSimpleObject()
      
      ' Opens a file and serializes the object into it in binary format.
      Dim stream As Stream = File.Open("data.xml", FileMode.Create)
      Dim formatter As New SoapFormatter()
      
      formatter.Serialize(stream, obj)
      stream.Close()
      
   End Sub 'Main
   
End Class 'Test


' A test object that needs to be serialized.
' <Snippet1>
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
' </Snippet1>