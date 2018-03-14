' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


Public Class Vehicle
    Public id As String
End Class

Public Class Car
    Inherits Vehicle
    Public Maker As String
End Class

Public Class Transportation
    <XmlArrayItem(ElementName := "Transportation"), _
     XmlArrayItem(GetType(Car), ElementName := "Automobile")> _
    Public MyVehicles() As Vehicle
End Class

Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        test.SerializeObject("XmlArrayItem2.xml")
        test.DeserializeObject("XmlArrayItem2.xml")
    End Sub    
    
    Private Sub SerializeObject(ByVal filename As String)
        ' Creates an XmlSerializer for the Transportation class.
        Dim MySerializer As New XmlSerializer(GetType(Transportation))
        
        ' Writing the XML file to disk requires a TextWriter.
        Dim myTextWriter As New StreamWriter(filename)
        
        Dim myTransportation As New Transportation()
        
        Dim myVehicle As New Vehicle()
        myVehicle.id = "A12345"
        
        Dim myCar As New Car()
        myCar.id = "Car 34"
        myCar.Maker = "FamousCarMaker"
        
        Dim myVehicles() As Vehicle = {myVehicle, myCar}
        myTransportation.MyVehicles = myVehicles
        
        ' Serializes the object, and closes the StreamWriter.
        MySerializer.Serialize(myTextWriter, myTransportation)
        myTextWriter.Close()
    End Sub
        
    Private Sub DeserializeObject(ByVal filename As String)
        ' Create the serializer with the type to deserialize.
        Dim mySerializer As New XmlSerializer(GetType(Transportation))
        Dim myFileStream As New FileStream(filename, FileMode.Open)
        Dim myTransportation As Transportation = _
            CType(mySerializer.Deserialize(myFileStream), Transportation)
        
        Dim i As Integer
        For i = 0 To myTransportation.MyVehicles.Length - 1
            Console.WriteLine(myTransportation.MyVehicles(i).id)
        Next i
    End Sub
End Class

' </Snippet1>
