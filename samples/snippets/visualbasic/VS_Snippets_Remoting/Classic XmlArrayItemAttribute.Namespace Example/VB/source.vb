Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


' <Snippet1>
Public Class Transportation
    ' Sets the Namespace property.
    <XmlArrayItem(GetType(Car), Namespace := "http://www.cpandl.com")> _
    Public MyVehicles() As Vehicle
End Class 'Transportation

' </Snippet1>

Public Class Vehicle
    ' Class added so sample will compile
End Class

Public Class Car
    Inherits Vehicle
    ' Class added so sample will compile
End Class

