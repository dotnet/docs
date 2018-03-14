Option Explicit
Option Strict

Imports System
Imports System.Web.Services
Imports System.Xml
Imports System.Xml.Serialization



' <Snippet1>
Public Class Vehicle
End Class
 
Public Class Car
    Inherits Vehicle
End Class
 
Public Class Truck
    Inherits Vehicle
End Class
 
Public Class Sample    
    <WebMethod(), _
     XmlInclude(GetType(Car)), _
     XmlInclude(GetType(Truck))> _
    Public Function ReturnVehicle(i As Integer) As Vehicle
        
        If i = 0 Then
            Return New Car()
        Else
            Return New Truck()
        End If
    End Function
End Class
' </Snippet1>
