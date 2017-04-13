' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml.Serialization


' This is the class that is the default root element.
Public Class MyClass1
    Public Name As String
End Class

Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        test.SerializeOrder("OverrideAttribute.xml")
    End Sub
        
    Public Sub SerializeOrder(ByVal filename As String)
        ' Create an XmlSerializer instance using the method below.
        Dim xSer As XmlSerializer = CreateOverrider()
        
        ' Create the object, and set its Name property.
        Dim class1 As New MyClass1()
        class1.Name = "New Class Name"
        
        ' Serialize the class, and close the TextWriter.
        Dim writer As New StreamWriter(filename)
        xSer.Serialize(writer, class1)
        writer.Close()
    End Sub 'SerializeOrder
    
    
    ' Return an XmlSerializer to override the root serialization.
    Public Function CreateOverrider() As XmlSerializer
        ' Create an XmlAttributes to override the default root element.
        Dim attrs As New XmlAttributes()
        
        ' Create an XmlRootAttribute and set its element name and namespace.
        Dim xRoot As New XmlRootAttribute()
        xRoot.ElementName = "OverriddenRootElementName"
        xRoot.Namespace = "http://www.microsoft.com"
        
        ' Set the XmlRoot property to the XmlRoot object.
        attrs.XmlRoot = xRoot
        Dim xOver As New XmlAttributeOverrides()
        
        ' Add the XmlAttributes object to the
        ' XmlAttributeOverrides object. 
        xOver.Add(GetType(MyClass1), attrs)
        
        ' Create the Serializer, and return it.
        Dim xSer As New XmlSerializer(GetType(MyClass1), xOver)
        Return xSer
    End Function
End Class

' </Snippet1>