' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml.Serialization
Imports System.Xml


' Apply the XmlRootAttribute and set the IsNullable property to false.
<XmlRoot(IsNullable := False)> _
Public Class Group
    Public Name As String
End Class


Public Class Run
    
    Public Shared Sub Main()
        Console.WriteLine("Running")
        Dim test As New Run()
        test.SerializeObject("NullDoc.xml")
    End Sub     
    
    Public Sub SerializeObject(ByVal filename As String)
        Dim s As New XmlSerializer(GetType(Group))
        
        ' Writing the file requires a TextWriter.
        Dim writer As New StreamWriter(filename)
        
        ' Create the object to serialize.
        Dim mygroup As Group = Nothing
        
        ' Serialize the object, and close the TextWriter.
        s.Serialize(writer, mygroup)
        writer.Close()
    End Sub
End Class

' </Snippet1>
