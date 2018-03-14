' <snippet2>
Imports System
Imports System.Web
Imports System.Web.Security
Imports System.Security.Permissions
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

Namespace Samples.AspNet.VB.Controls

  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Interface IZipCode

    Property ZipCode() As String

  End Interface

  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Class ZipCodeWebPart
    Inherits WebPart
    Implements IZipCode
    Private zipCodeText As String = String.Empty
    Private input As TextBox
    Private send As Button

    Public Sub New()
    End Sub

    ' Make the implemented property personalizable to save 
    ' the Zip Code between browser sessions.
    <Personalizable()> _
    Public Property ZipCode() As String _
      Implements IZipCode.ZipCode

      Get
        Return zipCodeText
      End Get
      Set(ByVal value As String)
        zipCodeText = value
      End Set
    End Property

    ' This is the callback method that returns the provider.
    <ConnectionProvider("Zip Code", "ZipCodeProvider")> _
    Public Function ProvideIZipCode() As IZipCode
      Return Me
    End Function


    Protected Overrides Sub CreateChildControls()
      Controls.Clear()
      input = New TextBox()
      Me.Controls.Add(input)
      send = New Button()
      send.Text = "Enter 5-digit Zip Code"
      AddHandler send.Click, AddressOf Me.submit_Click
      Me.Controls.Add(send)

    End Sub


    Private Sub submit_Click(ByVal sender As Object, _
      ByVal e As EventArgs)

      If input.Text <> String.Empty Then
        zipCodeText = Page.Server.HtmlEncode(input.Text)
        input.Text = String.Empty
      End If

    End Sub

  End Class

  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Class WeatherWebPart
    Inherits WebPart
    Private _provider As IZipCode
    Private _zipSearch As String
    Private DisplayContent As Label

    ' This method is identified by the ConnectionConsumer 
    ' attribute, and is the mechanism for connecting with 
    ' the provider. 
    <ConnectionConsumer("Zip Code", "ZipCodeConsumer")> _
    Public Sub GetIZipCode(ByVal Provider As IZipCode)
      _provider = Provider
    End Sub


    Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
      EnsureChildControls()

      If Not (Me._provider Is Nothing) Then
        _zipSearch = _provider.ZipCode.Trim()
				DisplayContent.Text = "My Zip Code is:  " + _zipSearch
      End If

    End Sub 'OnPreRender

    Protected Overrides Sub CreateChildControls()
      Controls.Clear()
      DisplayContent = New Label()
      Me.Controls.Add(DisplayContent)

    End Sub

  End Class

End Namespace
' </snippet2>