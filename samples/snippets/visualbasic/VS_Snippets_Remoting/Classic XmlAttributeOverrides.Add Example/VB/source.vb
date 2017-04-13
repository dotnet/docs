' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml.Serialization


' This is the class that will be overridden. The XmlIncludeAttribute
' tells the XmlSerializer that the overriding type exists. 
<XmlInclude(GetType(Band))> _
Public Class Orchestra
    Public Instruments() As Instrument
End Class

' This is the overriding class.
Public Class Band
    Inherits Orchestra
    Public BandName As String
End Class

Public Class Instrument
    Public Name As String
End Class

Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        test.SerializeObject("Override.xml")
        test.DeserializeObject("Override.xml")
    End Sub    
    
    Public Sub SerializeObject(ByVal filename As String)
        ' Each object that is being overridden requires
        ' an XmlAttributes object. 
        Dim attrs As New XmlAttributes()
        
        ' An XmlRootAttribute allows overriding the Orchestra class.
        Dim xmlRoot As New XmlRootAttribute()
        
        ' Set the object to the XmlAttribute.XmlRoot property.
        attrs.XmlRoot = xmlRoot
        
        ' Create an XmlAttributeOverrides object.
        Dim attrOverrides As New XmlAttributeOverrides()
        
        ' Add the XmlAttributes to the XmlAttributeOverrrides.
        attrOverrides.Add(GetType(Orchestra), attrs)
        
        ' Create the XmlSerializer using the XmlAttributeOverrides.
        Dim s As New XmlSerializer(GetType(Orchestra), attrOverrides)
        
        ' Writing the file requires a TextWriter.
        Dim writer As New StreamWriter(filename)
        
        ' Create the object using the derived class.
        Dim band As New Band()
        band.BandName = "NewBand"
        
        ' Create an Instrument.
        Dim i As New Instrument()
        i.Name = "Trumpet"
        Dim myInstruments() As Instrument = {i}
        band.Instruments = myInstruments
        
        ' Serialize the object.
        s.Serialize(writer, band)
        writer.Close()
    End Sub    
    
    Public Sub DeserializeObject(ByVal filename As String)
        Dim attrs As New XmlAttributes()
        Dim attr As New XmlRootAttribute()
        attrs.XmlRoot = attr
        Dim attrOverrides As New XmlAttributeOverrides()
        
        attrOverrides.Add(GetType(Orchestra), "Instruments", attrs)
        
        Dim s As New XmlSerializer(GetType(Orchestra), attrOverrides)
        
        Dim fs As New FileStream(filename, FileMode.Open)
        
        ' Deserialize the Band object.
        Dim band As Band = CType(s.Deserialize(fs), Band)
        Console.WriteLine("Brass:")
        
        Dim i As Instrument
        For Each i In  band.Instruments
            Console.WriteLine(i.Name)
        Next i
    End Sub
End Class

' </Snippet1>
