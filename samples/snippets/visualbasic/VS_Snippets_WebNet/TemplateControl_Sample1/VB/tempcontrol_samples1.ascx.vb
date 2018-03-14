' <snippet1>
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

' The custom user control class.
<AspNetHostingPermission(SecurityAction.Demand, _
   Level:=AspNetHostingPermissionLevel.Minimal)> _
Public Class MyControl
   Inherits UserControl
   ' Create a Message property and accessors.
   Private _message As String = Nothing
   
   Public Property Message() As String
      Get
         Return _message
      End Get
      Set
         _message = value
      End Set
   End Property
   
    ' <Snippet2>
    ' Create an event for this user control
    Public Event myControl As System.EventHandler

    ' Override the default constructor.
    Protected Overrides Sub Construct()
        ' Specify the handler for the OnInit method.
        AddHandler Me.myControl, AddressOf MyInit
    End Sub

    Protected Overrides Sub OnInit(ByVal e As EventArgs)
        RaiseEvent myControl(Me, e)
        Response.Write("The OnInit() method is used to raise the Init event.")
    End Sub
   
   
    ' Use the MyInit handler to set the Message property
    Sub MyInit(ByVal sender As Object, ByVal e As System.EventArgs)
        Message = "Hello World!"
    End Sub
   
    ' </Snippet2>
    ' Render the value of the Message property
    Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
        writer.Write(("<br>Message :" & Message))
    End Sub
End Class
' </Snippet1>
