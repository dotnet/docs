Option Explicit
Option Strict

' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


' This is the class that will be serialized.
Public Class Group
    Public Members() As Member
End Class

Public Class Member
    Public MemberName As String
End Class

Public Class NewMember
    Inherits Member
    Public MemberID As Integer
End Class

Public Class RetiredMember
    Inherits NewMember
    Public RetireDate As DateTime
End Class


Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        test.SerializeObject("OverrideArrayItem.xml")
        test.DeserializeObject("OverrideArrayItem.xml")
    End Sub    
    
    ' Return an XmlSerializer used for overriding. 
    Public Function CreateOverrider() As XmlSerializer
        ' Create XmlAttributeOverrides and XmlAttributes objects.
        Dim xOver As New XmlAttributeOverrides()
        Dim xAttrs As New XmlAttributes()
        
        ' Add an override for the XmlArrayItem.    
        Dim xArrayItem As New XmlArrayItemAttribute(GetType(NewMember))
        xArrayItem.Namespace = "http://www.cpandl.com"
        xAttrs.XmlArrayItems.Add(xArrayItem)
        
        ' Add a second override.
        Dim xArrayItem2 As New XmlArrayItemAttribute(GetType(RetiredMember))
        xArrayItem2.Namespace = "http://www.cpandl.com"
        xAttrs.XmlArrayItems.Add(xArrayItem2)
        
        ' Add all overrides to XmlAttribueOverrides object.
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
        Dim m As New NewMember()
        m.MemberName = "Paul"
        m.MemberID = 2
        
        ' Create a second member.
        Dim m2 As New RetiredMember()
        m2.MemberName = "Renaldo"
        m2.MemberID = 23
        m2.RetireDate = New DateTime(2000, 10, 10)
        
        myGroup.Members = New Member(1) {m, m2}
        
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