' <Snippet1>
Option Strict
Option Explicit

Imports System
Imports System.IO
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic


Public Class Orchestra
    Public Instruments() As Instrument
End Class

Public Class Instrument
    Public Name As String
End Class

Public Class Brass
    Inherits Instrument
    Public IsValved As Boolean
End Class

Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        test.SerializeObject("Override.xml")
        test.DeserializeObject("Override.xml")
    End Sub 'Main
    
    
    Public Sub SerializeObject(filename As String)
        ' To write the file, a TextWriter is required.
        Dim writer As New StreamWriter(filename)
        
        Dim attrOverrides As New XmlAttributeOverrides()
        Dim attrs As New XmlAttributes()
        
        ' Creates an XmlElementAttribute that overrides the Instrument type.
        Dim attr As New XmlElementAttribute(GetType(Brass))
        attr.ElementName = "Brass"
        
        ' Adds the element to the collection of elements.
        attrs.XmlElements.Add(attr)
        attrOverrides.Add(GetType(Orchestra), "Instruments", attrs)
        
        ' Creates the XmlSerializer using the XmlAttributeOverrides.
        Dim s As New XmlSerializer(GetType(Orchestra), attrOverrides)
        
        ' Creates the object to serialize.
        Dim band As New Orchestra()
        
        ' Creates an object of the derived type.
        Dim i As New Brass()
        i.Name = "Trumpet"
        i.IsValved = True
        Dim myInstruments() As Instrument = {i}
        band.Instruments = myInstruments
        s.Serialize(writer, band)
        writer.Close()
    End Sub
    
    
    Public Sub DeserializeObject(filename As String)
        Dim attrOverrides As New XmlAttributeOverrides()
        Dim attrs As New XmlAttributes()
        
        ' Create an XmlElementAttribute that override the Instrument type.
        Dim attr As New XmlElementAttribute(GetType(Brass))
        attr.ElementName = "Brass"
        
        ' Add the element to the collection of elements.
        attrs.XmlElements.Add(attr)
        attrOverrides.Add(GetType(Orchestra), "Instruments", attrs)
        
        ' Create the XmlSerializer using the XmlAttributeOverrides.
        Dim s As New XmlSerializer(GetType(Orchestra), attrOverrides)
        
        Dim fs As New FileStream(filename, FileMode.Open)
        Dim band As Orchestra = CType(s.Deserialize(fs), Orchestra)
        Console.WriteLine("Brass:")
        
        ' Deserializing differs from serializing. To read the
        ' derived-object values, declare an object of the derived
        ' type (Brass) and cast the Instrument instance to it. 
        Dim b As Brass
        Dim i As Instrument
        For Each i In  band.Instruments
            b = CType(i, Brass)
            Console.WriteLine((b.Name + ControlChars.Cr + b.IsValved.ToString()))
        Next i
    End Sub
End Class

' </Snippet1>