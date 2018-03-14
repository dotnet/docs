' <Snippet1>
Option Explicit
Option Strict

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
    End Sub
        
    Public Sub SerializeObject(ByVal filename As String)
        ' Each overridden field, property, or type requires
        ' an XmlAttributes object. 
        Dim attrs As New XmlAttributes()
        
        ' Create an XmlElementAttribute to override the
        ' field that returns Instrument objects. The overridden field
        ' returns Brass objects instead. 
        Dim attr As New XmlElementAttribute()
        attr.ElementName = "Brass"
        attr.Type = GetType(Brass)
        
        ' Add the element to the collection of elements.
        attrs.XmlElements.Add(attr)
        
        ' Create the XmlAttributeOverrides object.
        Dim attrOverrides As New XmlAttributeOverrides()
        
        ' Add the type of the class that contains the overridden
        ' member and the XmlAttributes to override it with to the
        ' XmlAttributeOverrides object. 
        attrOverrides.Add(GetType(Orchestra), "Instruments", attrs)
        
        ' Create the XmlSerializer using the XmlAttributeOverrides.
        Dim s As New XmlSerializer(GetType(Orchestra), attrOverrides)
        
        ' Writing the file requires a TextWriter.
        Dim writer As New StreamWriter(filename)
        
        ' Create the object that will be serialized.
        Dim band As New Orchestra()
        
        ' Create an object of the derived type.
        Dim i As New Brass()
        i.Name = "Trumpet"
        i.IsValved = True
        Dim myInstruments() As Instrument = {i}
        band.Instruments = myInstruments
        
        ' Serialize the object.
        s.Serialize(writer, band)
        writer.Close()
    End Sub    
    
    Public Sub DeserializeObject(filename As String)
        Dim attrOverrides As New XmlAttributeOverrides()
        Dim attrs As New XmlAttributes()
        
        ' Create an XmlElementAttribute to override the Instrument.
        Dim attr As New XmlElementAttribute()
        attr.ElementName = "Brass"
        attr.Type = GetType(Brass)
        
        ' Add the XmlElementAttribute to the collection of objects.
        attrs.XmlElements.Add(attr)
        
        attrOverrides.Add(GetType(Orchestra), "Instruments", attrs)
        
        ' Create the XmlSerializer using the XmlAttributeOverrides.
        Dim s As New XmlSerializer(GetType(Orchestra), attrOverrides)
        
        Dim fs As New FileStream(filename, FileMode.Open)
        Dim band As Orchestra = CType(s.Deserialize(fs), Orchestra)
        Console.WriteLine("Brass:")
        
        ' The difference between deserializing the overridden
        ' XML document and serializing it is this: To read the derived
        ' object values, you must declare an object of the derived type
        ' (Brass), and cast the Instrument instance to it. 
        Dim b As Brass
        Dim i As Instrument
        For Each i In  band.Instruments
            b = CType(i, Brass)
            Console.WriteLine(b.Name & ControlChars.Cr & b.IsValved)
        Next i
    End Sub
End Class

' </Snippet1>