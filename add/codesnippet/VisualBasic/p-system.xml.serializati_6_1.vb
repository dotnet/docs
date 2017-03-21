Public Class Transportation
    ' Specifies acceptable types and the ElementName generated
    '  for each object type. 
    <XmlArray("Vehicles"), _
     XmlArrayItem(GetType(Vehicle), ElementName := "Transport"), _
     XmlArrayItem(GetType(Car), ElementName := "Automobile")> _
    Public MyVehicles() As Vehicle
End Class

' By default, this class results in XML elements named "Vehicle". 
Public Class Vehicle
    Public id As String
End Class

' By default, this class results in XMl elements named "Car". 
Public Class Car
    Inherits Vehicle
    Public Maker As String
End Class
