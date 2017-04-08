'<Snippet1>
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace Contoso

    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class ContosoMenuAdapter
        Inherits System.Web.UI.WebControls.Adapters.MenuAdapter
        '        Implements IPostBackEventHandler

        ' String variable to hold the currently selected path.
        Private menuPath As String = String.Empty

        ' Link the adapter to the current Menu control instance.
        '<Snippet2>
        Protected Overloads ReadOnly Property Control() As _
            System.Web.UI.WebControls.Menu

            Get
                Return CType( _
                    MyBase.Control, _
                    System.Web.UI.WebControls.Menu)
            End Get
        End Property
        '</Snippet2>

        ' Set the menuPath variable to the saved state variable.
        '<Snippet3>
        Protected Overrides Sub LoadAdapterControlState( _
            ByVal controlState As Object)

            If (Not controlState Is Nothing) Then
                If (TypeOf (controlState) Is String) Then
                    menuPath = CType(controlState, String)

                End If
            End If

            MyBase.LoadAdapterControlState(controlState)
        End Sub
        '</Snippet3>

        ' Return the menu path at the current location.
        '<Snippet4>
        Protected Overrides Function SaveAdapterControlState() As Object

            Return menuPath
        End Function
        '</Snippet4>

        '<Snippet5>
        Protected Overrides Sub OnInit(ByVal e As EventArgs)

            AddHandler Control.Init, AddressOf ShowMap
            MyBase.OnInit(e)
        End Sub

        Public Sub ShowMap(ByVal sender As Object, ByVal e As EventArgs)

            Dim menuNav As Control
            menuNav = Me.Control.FindControl("contosoMenuNav")

            If (menuNav Is Nothing) Then
                Dim labelStyle As New Style()
                labelStyle.BackColor = System.Drawing.Color.Blue
                labelStyle.ForeColor = System.Drawing.Color.White
                labelStyle.Font.Name = "Arial"
                labelStyle.Font.Size = FontUnit.XXSmall

                Dim newLabel As New Label()
                newLabel.ApplyStyle(labelStyle)
                newLabel.ID = "contosoMenuNav"
                newLabel.Text = "Initialized label"

                Me.CreateChildControls()
                Me.Control.Controls.Add(newLabel)
            End If
        End Sub
        '</Snippet5>

        ' Set the text of the contosoMenuNav to the current menu path.
        '<Snippet6>
        Protected Overrides Sub OnPreRender(ByVal e As EventArgs)

            If (Not menuPath = String.Empty) Then
                Dim menuNav As Control
                menuNav = Me.Control.FindControl("contosoMenuNav")

                If (Not menuNav Is Nothing) Then
                    Dim newLabel As Label
                    newLabel = CType(menuNav, Label)
                    newLabel.Text = "Nav:: " + menuPath.Replace("\\", "-->")
                End If
            End If

            MyBase.OnPreRender(e)
        End Sub
        '</Snippet6>

        '<Snippet7>
        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)

            ' Pass the modified writer to the parent class for rendering.
            MyBase.Render(writer)

            ' Render the MenuNav label control.
            Dim menuNav As Control
            menuNav = Me.Control.FindControl("contosoMenuNav")
            If (Not menuNav Is Nothing) Then
                menuNav.RenderControl(writer)
            End If
        End Sub
        '</Snippet7>

        ' Wrap a panel with the inherited menu styles around the menu control.
        '<Snippet8>
        Public Overrides Sub RenderBeginTag(ByVal writer As HtmlTextWriter)

            writer.Write("<i>")
            MyBase.RenderBeginTag(writer)
        End Sub
        '</Snippet8>

        '<Snippet9>
        Public Overrides Sub RenderEndTag(ByVal writer As HtmlTextWriter)

            MyBase.RenderEndTag(writer)
            writer.Write("</i>")
        End Sub
        '</Snippet9>

        ' Set the menuPath to the current location in the menu hierarchy.
        '<Snippet10>
        Protected Shadows Sub RaisePostBackEvent( _
            ByVal eventArgument As String)

            If (Not eventArgument Is Nothing) Then
                Dim newPath As String
                newPath = eventArgument.Substring(1, eventArgument.Length - 1)

                If (eventArgument(0) = "u") Then
                    Dim lastDelim As Integer = menuPath.LastIndexOf("\\")
                    menuPath = menuPath.Substring(0, lastDelim)
                Else
                    menuPath = newPath
                End If

                ' Call the parent RaisePostBackEvent method.
                MyBase.RaisePostBackEvent(eventArgument)
            End If
        End Sub
        '</Snippet10>
    End Class
End Namespace
'</Snippet1>