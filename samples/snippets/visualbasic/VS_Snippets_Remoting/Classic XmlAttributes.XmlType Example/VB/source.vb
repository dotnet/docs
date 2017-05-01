Option Explicit
Option Strict

' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml.Serialization


Public Class Transportation
    Public Cars() As Car
End Class

Public Class Car
    Public ID As Integer
End Class


Public Class Test
    
    Public Shared Sub Main()
        Dim t As New Test()
        t.SerializeObject("XmlType.xml")
    End Sub
    
    
    ' Return an XmlSerializer used for overriding.
    Public Function CreateOverrider() As XmlSerializer
        ' Create the XmlAttributes and XmlAttributeOverrides objects.
        Dim attrs As New XmlAttributes()
        Dim xOver As New XmlAttributeOverrides()
        
        ' Create an XmlTypeAttribute and change the name of the
        ' XML type. 
        Dim xType As New XmlTypeAttribute()
        xType.TypeName = "Autos"
        
        ' Set the XmlTypeAttribute to the XmlType property.
        attrs.XmlType = xType
        
        ' Add the XmlAttributes to the XmlAttributeOverrides,
        ' specifying the member to override. 
        xOver.Add(GetType(Car), attrs)
        
        ' Create the XmlSerializer, and return it.
        Dim xSer As New XmlSerializer(GetType(Transportation), xOver)
        Return xSer
    End Function
    
    
    Public Sub SerializeObject(ByVal filename As String)
        ' Create an XmlSerializer instance.
        Dim xSer As XmlSerializer = CreateOverrider()
        
        ' Create an object and serialize it.
        Dim myTransportation As New Transportation()
        
        Dim c1 As New Car()
        c1.ID = 12
        
        Dim c2 As New Car()
        c2.ID = 44
        
        myTransportation.Cars = New Car(1) {c1, c2}
        
        ' To write the file, a TextWriter is required.
        Dim writer As New StreamWriter(filename)
        xSer.Serialize(writer, myTransportation)
    End Sub
End Class

' </Snippet1>
