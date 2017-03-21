Public Class Transportation
    ' Sets the Namespace property.
    <XmlArrayItem(GetType(Car), Namespace := "http://www.cpandl.com")> _
    Public MyVehicles() As Vehicle
End Class 'Transportation
