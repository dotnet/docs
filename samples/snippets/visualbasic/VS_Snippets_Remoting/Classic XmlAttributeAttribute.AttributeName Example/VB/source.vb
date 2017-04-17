' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


Public Class Group
    ' Change the XML attribute name.
    <XmlAttribute(AttributeName := "MgrName")> Public Name As String
    ' Use the AttributeName to collect all the XML attributes
    ' in the XML-document instance. 
    <XmlAttribute(AttributeName := "*")> Public Attrs() As XmlAttribute
End Class

Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        ' To use the AttributeName to collect all the
        ' XML attributes. Call SerializeObject to generate
        ' an XML document and alter the document by adding
        ' new XML attributes to it. Then comment out the SerializeObject
        ' method, and call DeserializeObject.
        test.SerializeObject("MyAtts.xml")
        test.DeserializeObject("MyAtts.xml")
    End Sub
    
    Public Sub SerializeObject(ByVal filename As String)
        Console.WriteLine("Serializing")
        ' Create an instance of the XmlSerializer class.
        Dim mySerializer As New XmlSerializer(GetType(Group))
        ' Writing the file requires a TextWriter.
        Dim writer As New StreamWriter(filename)
        ' Create an instance of the class that will be serialized.
        Dim myGroup As New Group()
        ' Set the Name property, which will be generated
        ' as an XML attribute. 
        myGroup.Name = "Wallace"
        ' Serialize the class, and close the TextWriter.
        mySerializer.Serialize(writer, myGroup)
        writer.Close()
    End Sub
        
    Public Sub DeserializeObject(ByVal filename As String)
        Console.WriteLine("Deserializing")
        Dim mySerializer As New XmlSerializer(GetType(Group))
        Dim fs As New FileStream(filename, FileMode.Open)
        Dim myGroup As Group = CType(mySerializer.Deserialize(fs), Group)
        ' The following code prints all the attributes in the
        ' XML document. To collect the attributes, the AttributeName of the
        ' XmlAttributeAttribute must be set to "*".
        Dim xAtt As XmlAttribute
        For Each xAtt In  myGroup.Attrs
            Console.WriteLine(xAtt.Name & ":" & xAtt.Value)
        Next xAtt
    End Sub
End Class

' </Snippet1>
