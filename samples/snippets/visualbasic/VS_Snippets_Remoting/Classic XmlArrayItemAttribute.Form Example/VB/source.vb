Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization


' <Snippet1>
Public Class Transportation
    ' Specify the Form property value.
    <XmlArray("Vehicles"), _
     XmlArrayItem(GetType(Vehicle), Form := XmlSchemaForm.Unqualified), _
     XmlArrayItem(GetType(Car), Form := XmlSchemaForm.Qualified)> _
    Public MyVehicles() As Vehicle
End Class

Public Class Vehicle
    Public id As String
End Class

Public Class Car
    Inherits Vehicle
    Public Maker As String
End Class

' </Snippet1>
