Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization



Public Class Sample
    
    ' <Snippet1>
    Public Function CreateOverrider() As XmlSerializer
        ' Create XmlAttributes and XmlAttributeOverrides instances.
        Dim attrs As New XmlAttributes()
        Dim xOver As New XmlAttributeOverrides()
        
        ' Create an XmlElementAttributes to override
        ' the Vehicles property. 
        Dim xElement1 As New XmlElementAttribute(GetType(Truck))
        ' Add the XmlElementAttribute to the collection.
        attrs.XmlElements.Add(xElement1)
        
        ' Create a second XmlElementAttribute, and
        ' add to the collection. 
        Dim xElement2 As New XmlElementAttribute(GetType(Train))
        attrs.XmlElements.Add(xElement2)
        
        ' Add the XmlAttributes to the XmlAttributeOverrides,
        ' specifying the member to override. 
        xOver.Add(GetType(Transportation), "Vehicles", attrs)
        
        ' Create the XmlSerializer, and return it.
        Dim xSer As New XmlSerializer(GetType(Transportation), xOver)
        Return xSer
    End Function
End Class
 
' </Snippet1>

Public Class Truck
    ' Class added so sample will compile
End Class

Public Class Train
    ' Class added so sample will compile
End Class

Public Class Transportation
    ' Class added so sample will compile
End Class
