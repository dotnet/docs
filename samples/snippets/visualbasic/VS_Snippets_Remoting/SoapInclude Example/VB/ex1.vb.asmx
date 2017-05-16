'<Snippet1>
<%@ WebService Language="VB" Class="Test" %>
 
Imports System
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Services.Description
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports System.Data
 
Public Class Test : 
Inherits WebService 
   <WebMethod()> Public Function EchoString( _
   <XmlElement(DataType:="string")> ByVal strval As String) _
   As <XmlElement("MyTime", DataType:="time")> DateTime
      Return DateTime.Now
   End Function

 
   <WebMethod(), SoapRpcMethod, SoapInclude(GetType(Car)), _
   SoapInclude(GetType(Bike))> _
   Public Function Vehicle (licenseNumber As string ) As Vehicle

      If licenseNumber = "0" Then
         Dim v As Vehicle  = new Car()
         v.licenseNumber = licenseNumber
         return v

      ElseIf licenseNumber = "1" Then
          Dim v As Vehicle  = new Bike()
          v.licenseNumber = licenseNumber
          return v
      
      else 
         return Nothing
      End If
   End Function
End Class

<XmlRoot("NewVehicle")> _
public MustInherit Class Vehicle 
    public licenseNumber As String 
    public make As DateTime 
End Class
 
public class Car 
   Inherits Vehicle 
End Class
 
public Class Bike 
   Inherits Vehicle 
End Class
   
'</Snippet1>

