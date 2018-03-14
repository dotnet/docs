Option Explicit
Option Strict

imports System
imports System.Data
imports System.Web.UI


Public Class Form1: Inherits Control

' <Snippet1>
<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Protected Overrides Sub Render(Output As HtmlTextWriter)
    If HasControls() And TypeOf Controls(0) Is LiteralControl
        Dim Ctrl As LiteralControl = CType(Controls(0), LiteralControl)
        Output.Write("<H2>Your Message: " & Ctrl.Text & "</H2>")
    End If
End Sub
' </Snippet1>

End Class
