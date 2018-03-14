' <snippet1>
Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design.WebControls
Imports System.ComponentModel
Imports System.Security.Permissions
Imports System.Drawing

Namespace Examples.VB.WebControls.Design

    ' <snippet3>
    ' The MyMenu is a copy of the Menu.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <Designer(GetType(Examples.VB.WebControls.Design.MyMenuDesigner))> _
    Public Class MyMenu
        Inherits Menu
    End Class ' MyMenu
    ' </snippet3>

    ' Override members of the MenuDesigner.
    Public Class MyMenuDesigner
        Inherits MenuDesigner

        ' <snippet2>
        ' Generate the design-time markup for the control when an error occurs.
        Protected Overrides Function GetErrorDesignTimeHtml( _
            ByVal ex As Exception) As String

            ' Write the error message text in red, bold.
            Dim errorRendering As String = _
                "<span style=""font-weight:bold; color:Red; "">" & _
                ex.Message & "</span>"

            Return CreatePlaceHolderDesignTimeHtml(errorRendering)

        End Function ' GetErrorDesignTimeHtml
        ' </snippet2>

        ' <snippet5>
        ' Generate the design-time markup for the control 
        ' when the template is empty.
        Protected Overrides Function GetEmptyDesignTimeHtml() As String

            Dim noElements As String = "Contains no menu items."

            Return CreatePlaceHolderDesignTimeHtml(noElements)

        End Function ' GetEmptyDesignTimeHtml
        ' </snippet5>

        ' <snippet4>
        ' Generate the design-time markup.
        Public Overrides Function GetDesignTimeHtml() As String

            ' Make the control more visible in the designer.  If the border 
            ' style is None or NotSet, change the border to an orange dotted line. 
            Dim myMenuCtl As MyMenu = CType(ViewControl, MyMenu)
            Dim markup As String = Nothing

            ' Check if the border style should be changed.
            If (myMenuCtl.BorderStyle = BorderStyle.NotSet Or _
                myMenuCtl.BorderStyle = BorderStyle.None) Then

                Dim oldBorderStyle As BorderStyle = myMenuCtl.BorderStyle
                Dim oldBorderColor As Color = myMenuCtl.BorderColor

                ' Set the design-time properties and catch any exceptions.
                Try
                    myMenuCtl.BorderStyle = BorderStyle.Dotted
                    myMenuCtl.BorderColor = Color.FromArgb(&HFF7F00)

                    ' Call the base method to generate the markup.
                    markup = MyBase.GetDesignTimeHtml()

                Catch ex As Exception
                    markup = GetErrorDesignTimeHtml(ex)

                Finally
                    ' Restore the properties to their original settings.
                    myMenuCtl.BorderStyle = oldBorderStyle
                    myMenuCtl.BorderColor = oldBorderColor
                End Try

            Else
                ' Call the base method to generate the markup.
                markup = MyBase.GetDesignTimeHtml()
            End If

            Return markup

        End Function ' GetDesignTimeHtml
        ' </snippet4>

        ' <snippet6>
        Public Overrides Sub Initialize(ByVal component As IComponent)

            ' Ensure that only a MyMenu can be created in this designer. 
            If Not TypeOf component Is MyMenu Then
                Throw New ArgumentException( _
                    "The component is not a MyMenu control.")
            End If

            MyBase.Initialize(component)

        End Sub ' Initialize
        ' </snippet6>
    End Class ' MyMenuDesigner
End Namespace ' Examples.VB.WebControls.Design
' </snippet1>
