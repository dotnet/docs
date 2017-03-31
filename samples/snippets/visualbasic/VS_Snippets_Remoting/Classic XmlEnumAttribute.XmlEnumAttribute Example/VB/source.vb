Option Explicit
Option Strict

' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


' This is the class that will be serialized.
Public Class Food
    Public Type As FoodType
End Class

Public Enum FoodType
    ' Subsequent code overrides these enumerations.
    Low
    High
End Enum



Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        test.SerializeObject("OverrideEnum.xml")
        test.DeserializeObject("OverrideEnum.xml")
    End Sub    
    
    ' Return an XmlSerializer used for overriding. 
    Public Function CreateOverrider() As XmlSerializer
        ' Create the XmlOverrides and XmlAttributes objects.
        Dim xOver As New XmlAttributeOverrides()
        Dim xAttrs As New XmlAttributes()
        
        ' Add an XmlEnumAttribute for the FoodType.Low enumeration.
        Dim xEnum As New XmlEnumAttribute()
        xEnum.Name = "Cold"
        xAttrs.XmlEnum = xEnum
        xOver.Add(GetType(FoodType), "Low", xAttrs)
        
        ' Add an XmlEnumAttribute for the FoodType.High enumeration.
        xAttrs = New XmlAttributes()
        xEnum = New XmlEnumAttribute()
        xEnum.Name = "Hot"
        xAttrs.XmlEnum = xEnum
        xOver.Add(GetType(FoodType), "High", xAttrs)
        
        ' Create the XmlSerializer, and return it.
        Return New XmlSerializer(GetType(Food), xOver)
    End Function
    
        
    Public Sub SerializeObject(ByVal filename As String)
        ' Create an instance of the XmlSerializer class.
        Dim mySerializer As XmlSerializer = CreateOverrider()
        ' Writing the file requires a TextWriter.
        Dim writer As New StreamWriter(filename)
        
        ' Create an instance of the class that will be serialized.
        Dim myFood As New Food()
        
        ' Set the object properties.
        myFood.Type = FoodType.High
        
        ' Serialize the class, and close the TextWriter.
        mySerializer.Serialize(writer, myFood)
        writer.Close()
    End Sub
    
    
    Public Sub DeserializeObject(ByVal filename As String)
        Dim mySerializer As XmlSerializer = CreateOverrider()
        Dim fs As New FileStream(filename, FileMode.Open)
        Dim myFood As Food = CType(mySerializer.Deserialize(fs), Food)
        
        Console.WriteLine(myFood.Type)
    End Sub
End Class

' </Snippet1>