Option Explicit
Option Strict

' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


' This is the class that will be serialized.
Public Class Group
    Public GroupName As String
    
    ' This field will be serialized as XML text. 
    Public Comment As String
End Class


Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        test.SerializeObject("OverrideText.xml")
        test.DeserializeObject("OverrideText.xml")
    End Sub

        
    ' Return an XmlSerializer to be used for overriding. 
    Public Function CreateOverrider() As XmlSerializer
        ' Create the XmlAttributeOverrides and XmlAttributes objects.
        Dim xOver As New XmlAttributeOverrides()
        Dim xAttrs As New XmlAttributes()
        
        ' Create an XmlTextAttribute and assign it to the XmlText
        ' property. This instructs the XmlSerializer to treat the
        ' Comment field as XML text. 
        Dim xText As New XmlTextAttribute()
        xAttrs.XmlText = xText
        xOver.Add(GetType(Group), "Comment", xAttrs)
        
        ' Create the XmlSerializer, and return it.
        Return New XmlSerializer(GetType(Group), xOver)
    End Function
    
    
    
    Public Sub SerializeObject(ByVal filename As String)
        ' Create an instance of the XmlSerializer class.
        Dim mySerializer As XmlSerializer = CreateOverrider()
        ' Writing the file requires a TextWriter.
        Dim writer As New StreamWriter(filename)
        
        ' Create an instance of the class that will be serialized.
        Dim myGroup As New Group()
        
        ' Set the object properties.
        myGroup.GroupName = ".NET"
        myGroup.Comment = "Great Stuff!"
        ' Serialize the class, and close the TextWriter.
        mySerializer.Serialize(writer, myGroup)
        writer.Close()
    End Sub
    
    
    Public Sub DeserializeObject(ByVal filename As String)
        Dim mySerializer As XmlSerializer = CreateOverrider()
        Dim fs As New FileStream(filename, FileMode.Open)
        Dim myGroup As Group = CType(mySerializer.Deserialize(fs), Group)
        Console.WriteLine(myGroup.GroupName)
        Console.WriteLine(myGroup.Comment)
    End Sub
End Class

' </Snippet1>