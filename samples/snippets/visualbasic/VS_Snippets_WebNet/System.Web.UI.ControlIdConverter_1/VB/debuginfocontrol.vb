' <Snippet1>
Imports System
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.VB

  <DefaultProperty("ControlID")>  _
  Public Class DebugInfoControl
     Inherits Control


     Public Sub New()
     End Sub 'New


     Public Sub New(controlID As String)
        ControlID = controlID
     End Sub 'New


     <DefaultValue(""), TypeConverter(GetType(ControlIDConverter))>  _
     Public Property ControlID() As String
        Get
           Dim o As Object = ViewState("ControlID")
           If o Is Nothing Then
              Return String.Empty
           End If
           Return CStr(o)
        End Get
        Set
           If ControlID <> value Then
              ViewState("ControlID") = value
           End If
        End Set
     End Property


     Protected Overrides Sub Render(writer As HtmlTextWriter)

        Dim info As New Label()

        If Me.ControlID.Length = 0 Then
           writer.Write("<Font Color='Red'>No ControlID set.</Font>")
        End If

        Dim ctrl As Control = Me.FindControl(ControlID)


        If ctrl Is Nothing Then
           writer.Write(("<Font Color='Red'>Could not find control " + ControlID + " in Naming Container.</Font>"))
        Else
           writer.Write(("<Font Color='Green'>Control " + ControlID + " found.<BR>"))
           writer.Write(("Its Naming Container is: " + ctrl.NamingContainer.ID + "<BR>"))
           If ctrl.EnableViewState Then
              writer.Write("It uses view state to persist its state.<BR>")
           End If
           If ctrl.EnableTheming Then
              writer.Write("It can be assigned a Theme ID.<BR>")
           End If
           If ctrl.Visible Then
              writer.Write("It is visible on the page.<BR>")
           Else
              writer.Write("It is not visible on the page.<BR>")
           End If
           writer.Write("</Font>")
        End If
     End Sub 'Render
  End Class 'DebugInfoControl
End Namespace
' </Snippet1>