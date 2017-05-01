' <Snippet1>
Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Web.UI.WebControls
Imports System.Security
Imports System.Web.UI.Design
Imports System.Web.UI.Design.WebControls
Imports Microsoft.VisualBasic

Namespace ASPNET.Examples
    '<Snippet6>
    < _
        Designer("ASPNET.Examples.Design.SimpleGridViewDesigner", _
            "System.Web.UI.Design.GridViewDesigner") _
    > _
    Public Class SimpleGridView
        Inherits GridView

        ' Code to customize your GridView goes here

    End Class
    '</Snippet6>
End Namespace

Namespace ASPNET.Examples.Design
    <Permissions.SecurityPermission( _
    Permissions.SecurityAction.Demand, _
    Flags:=Permissions.SecurityPermissionFlag.UnmanagedCode)> _
    Public Class SimpleGridViewDesigner
        Inherits GridViewDesigner

        Private simpleGView As SimpleGridView

        '<Snippet2>
        Public Overrides Function GetDesignTimeHtml() As String
            Dim designTimeHtml As String = String.Empty

            simpleGView = CType(Component, SimpleGridView)

            ' Check the control's BorderStyle property to  
            ' conditionally render design-time HTML.
            If (simpleGView.BorderStyle = BorderStyle.NotSet) Then
                ' Save the current property settings in variables.
                Dim oldCellPadding As Integer = simpleGView.CellPadding
                Dim oldBorderWidth As Unit = simpleGView.BorderWidth
                Dim oldBorderColor As Color = simpleGView.BorderColor

                ' Set properties and generate the design-time HTML.
                Try
                    simpleGView.Caption = "SimpleGridView"
                    simpleGView.CellPadding = 1
                    simpleGView.BorderWidth = Unit.Pixel(3)
                    simpleGView.BorderColor = Color.Red

                    designTimeHtml = MyBase.GetDesignTimeHtml()

                Catch ex As Exception
                    ' Get HTML from the GetErrorDesignTimeHtml 
                    ' method if an exception occurs.
                    designTimeHtml = GetErrorDesignTimeHtml(ex)

                    ' Return the properties to their original values.
                Finally
                    simpleGView.CellPadding = oldCellPadding
                    simpleGView.BorderWidth = oldBorderWidth
                    simpleGView.BorderColor = oldBorderColor
                End Try

            Else
                designTimeHtml = MyBase.GetDesignTimeHtml()
            End If

            Return designTimeHtml
        End Function

        '<Snippet4>
        Protected Overrides Function _
            GetErrorDesignTimeHtml(ByVal exc As Exception) As String

            Return CreatePlaceHolderDesignTimeHtml( _
                "ASPNET.Examples: An error occurred while rendering the GridView.")

        End Function
        '</Snippet4>
        '</Snippet2>

        '<Snippet5>
        Public Overrides Sub Initialize(ByVal component As IComponent)

            simpleGView = CType(component, SimpleGridView)

            MyBase.Initialize(component)

        End Sub
        '</Snippet5>
    End Class
End Namespace
' </Snippet1>
