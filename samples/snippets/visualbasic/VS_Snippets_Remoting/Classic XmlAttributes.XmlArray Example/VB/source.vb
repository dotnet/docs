Option Explicit
Option Strict

' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


' This is the class that will be serialized.
Public Class Group
    ' This field will be overridden.
    Public Members() As Member
End Class

Public Class Member
    Public MemberName As String
End Class

Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        test.SerializeObject("OverrideArray.xml")
        test.DeserializeObject("OverrideArray.xml")
    End Sub
    
    ' Return an XmlSerializer used for overriding. 
    Public Function CreateOverrider() As XmlSerializer
        ' Creating XmlAttributeOverrides and XmlAttributes objects.
        Dim xOver As New XmlAttributeOverrides()
        Dim xAttrs As New XmlAttributes()
        
        ' Add an override for the XmlArray.    
        Dim xArray As New XmlArrayAttribute("Staff")
        xArray.Namespace = "http://www.cpandl.com"
        xAttrs.XmlArray = xArray
        xOver.Add(GetType(Group), "Members", xAttrs)
        
        ' Create the XmlSerializer and return it.
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
        Dim m As New Member()
        m.MemberName = "Paul"
        myGroup.Members = New Member(0) {m}
        
        ' Serialize the class, and close the TextWriter.
        mySerializer.Serialize(writer, myGroup)
        writer.Close()
    End Sub    
    
    Public Sub DeserializeObject(ByVal filename As String)
        Dim mySerializer As XmlSerializer = CreateOverrider()
        Dim fs As New FileStream(filename, FileMode.Open)
        Dim myGroup As Group = CType(mySerializer.Deserialize(fs), Group)
        Dim m As Member
        For Each m In  myGroup.Members
            Console.WriteLine(m.MemberName)
        Next m
    End Sub
End Class

' </Snippet1>