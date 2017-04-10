Option Explicit
Option Strict

' <Snippet1>
Imports System
Imports System.Collections
Imports System.IO
Imports System.Xml.Serialization


Public Class Group
    ' Apply two XmlElementAttributes to the field. Set the DataType
    ' to string and int to allow the ArrayList to accept
    ' both types. The Namespace is also set to different values
    ' for each type. 
    <XmlElement(DataType := "string", _
        Type := GetType(String), _
        Namespace := "http://www.cpandl.com"), _
     XmlElement(DataType := "int", _                    
        Type := GetType(Integer), _
        Namespace := "http://www.cohowinery.com")> _
    Public ExtraInfo As ArrayList
End Class


Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        test.SerializeObject("ElementTypes.xml")
    End Sub    
    
    Public Sub SerializeObject(filename As String)
        ' A TextWriter is needed to write the file.
        Dim writer As New StreamWriter(filename)
        
        ' Create the XmlSerializer using the XmlAttributeOverrides.
        Dim s As New XmlSerializer(GetType(Group))
        
        ' Create the object to serialize.
        Dim myGroup As New Group()
        
        ' Add a string and an integer to the ArrayList returned
        ' by the ExtraInfo field. 
        myGroup.ExtraInfo = New ArrayList()
        myGroup.ExtraInfo.Add("hello")
        myGroup.ExtraInfo.Add(100)
        
        ' Serialize the object and close the TextWriter.
        s.Serialize(writer, myGroup)
        writer.Close()
    End Sub
End Class

' </Snippet1>
