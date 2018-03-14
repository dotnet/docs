Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization



' <Snippet1>
Public Class XClass
    ' Apply the XmlAnyElementAttribute to a field returning an array
    ' of XmlElement objects.
    <XmlAnyElement()> Public AllElements() As XmlElement
End Class 'XClass


Public Class Test
    
    Public Shared Sub Main()
        Dim t As New Test()
        t.DeserializeObject("XFile.xml")
    End Sub 'Main
    
    
    Private Sub DeserializeObject(filename As String)
        ' Create an XmlSerializer.
        Dim mySerializer As New XmlSerializer(GetType(XClass))
        
        ' To read a file, a FileStream is needed.
        Dim fs As New FileStream(filename, FileMode.Open)
        
        ' Deserialize the class.
        Dim x As XClass = CType(mySerializer.Deserialize(fs), XClass)
        
        ' Read the element names and values.
        Dim xel As XmlElement
        For Each xel In  x.AllElements
            Console.WriteLine((xel.LocalName & ": " & xel.Value))
        Next xel
    End Sub 'DeserializeObject
End Class 'Test 
' </Snippet1>
