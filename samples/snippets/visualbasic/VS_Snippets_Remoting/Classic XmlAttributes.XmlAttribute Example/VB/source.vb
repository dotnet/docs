Option Explicit
Option Strict

' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


' This is the class that will be serialized.
Public Class Group
    ' This is the attribute that will be overridden.
    <XmlAttribute()> Public GroupName As String
    Public GroupNumber As Integer
End Class


Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        test.SerializeObject("OverrideAttribute.xml")
        test.DeserializeObject("OverrideAttribute.xml")
    End Sub
    
    ' Return an XmlSerializer used for overriding. 
    Public Function CreateOverrider() As XmlSerializer
        ' Create the XmlAttributeOverrides and XmlAttributes objects.
        Dim xOver As New XmlAttributeOverrides()
        Dim xAttrs As New XmlAttributes()
        
        ' Create an overriding XmlAttributeAttribute set it to
        ' the XmlAttribute property of the XmlAttributes object.
        Dim xAttribute As New XmlAttributeAttribute("SplinterName")
        xAttrs.XmlAttribute = xAttribute
        
        ' Add to the XmlAttributeOverrides. Specify the member name.
        xOver.Add(GetType(Group), "GroupName", xAttrs)
        
        ' Create the XmlSerializer and return it.
        Return New XmlSerializer(GetType(Group), xOver)
    End Function 'CreateOverrider
    
    
    Public Sub SerializeObject(ByVal filename As String)
        ' Create an instance of the XmlSerializer class.
        Dim mySerializer As XmlSerializer = CreateOverrider()
        ' Writing the file requires a TextWriter.
        Dim writer As New StreamWriter(filename)
        
        ' Create an instance of the class that will be serialized.
        Dim myGroup As New Group()
        
        ' Set the Name property, which will be generated
        ' as an XML attribute. 
        myGroup.GroupName = ".NET"
        myGroup.GroupNumber = 1
        ' Serialize the class, and close the TextWriter.
        mySerializer.Serialize(writer, myGroup)
        writer.Close()
    End Sub
    
    
    Public Sub DeserializeObject(ByVal filename As String)
        Dim mySerializer As XmlSerializer = CreateOverrider()
        Dim fs As New FileStream(filename, FileMode.Open)
        Dim myGroup As Group = CType(mySerializer.Deserialize(fs), Group)

        Console.WriteLine(myGroup.GroupName)
        Console.WriteLine(myGroup.GroupNumber)
    End Sub
End Class

' </Snippet1>
