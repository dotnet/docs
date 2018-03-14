<%-- <Snippet1> --%>
<%@ WebService Language="VB" Class="Samples.AspNet.ColorService" %>

Imports System
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services

Namespace Samples.AspNet
    
    <WebService([Namespace]:="http://tempuri.org/")> _
    <WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
    <ScriptService()> _
    <GenerateScriptType(GetType(FavoriteColors))> _
    Public Class ColorService
        Inherits System.Web.Services.WebService

        ' <Snippet2>
        <GenerateScriptType(GetType(ColorObject), ScriptTypeId:="Color")> _
        <WebMethodAttribute()> _
        Public Function GetDefaultColor() As String()
            ' Instantiate the default color object.
            Dim co As New ColorObject()

            Return co.RGB

        End Function
        ' </Snippet2>

        <WebMethod()> _
        Public Function EchoFavoriteColor() As String
            ' Instantiate the default color object.
            Dim co As New ColorObject()

            Return co.defaultColor.ToString()

        End Function
    End Class 'EmployeeService

    Public Class ColorObject
        Public rgb() As String = {"00", "00", "FF"}
        Public defaultColor As FavoriteColors = FavoriteColors.Blue
    End Class

    Public Enum FavoriteColors
        Black
        White
        Blue
        Red
    End Enum
End Namespace
' </Snippet1>
   
