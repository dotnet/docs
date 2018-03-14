'<Snippet1>
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Security.Permissions

Namespace Contoso
    <AspNetHostingPermission( _
        SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission( _
        SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class HideDisabledControlContosoAdapter
        Inherits System.Web.UI.WebControls.Adapters.HideDisabledControlAdapter
    
        Protected Overloads ReadOnly Property Control() As _
            System.Web.UI.WebControls.Label
            Get
                Return CType( _
                    MyBase.Control, _
                    System.Web.UI.WebControls.Label)
            End Get
        End Property

        ' Do not render the control if Enabled is false.
        '<Snippet2>
        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
            If (Control.ID.StartsWith("Contoso")) Then
                If (Not Control.Enabled) Then
                    Return
                End If
            End If

            MyBase.Render(writer)
        End Sub
        '</Snippet2>
    End Class
End Namespace
'</Snippet1>
