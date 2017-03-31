' <snippet1>
Imports System
Imports System.Web
Imports System.Drawing
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Security.Permissions

Namespace Examples.VB.WebControls.Design

    ' The MyGridView is a copy of the GridView.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <Designer(GetType(Examples.VB.WebControls.Design.MyGridViewDesigner))> _
    Public Class MyGridView
        Inherits GridView
    End Class ' MyVBGridView

    ' Override members of the GridViewDesigner.
    <ReflectionPermission(SecurityAction.Demand, Flags:=ReflectionPermissionFlag.MemberAccess)> _
    Public Class MyGridViewDesigner
        Inherits GridViewDesigner

        ' <snippet3>
        ' Shadow the control properties with design-time properties.
        Protected Overrides Sub PreFilterProperties( _
            ByVal properties As IDictionary)

            ' Call the base method first.
            MyBase.PreFilterProperties(properties)

            ' Make the Page visible in the Properties grid.
            Dim selectProp As PropertyDescriptor = _
                CType(properties("Page"), PropertyDescriptor)
            properties("Page") = _
                TypeDescriptor.CreateProperty(selectProp.ComponentType, _
                    selectProp, BrowsableAttribute.Yes)
        End Sub ' PreFilterProperties
        ' </snippet3>

        ' <snippet4>
        ' Generate the design-time markup.
        Private Const capTag As String = "caption"
        Private Const trOpen As String = "tr><td colspan=9 align=center"
        Private Const trClose As String = "td></tr"

        Public Overrides Function GetDesignTimeHtml() As String

            ' Make the full extent of the control more visible in the designer.
            ' If the border style is None or NotSet, change the border to
            ' a wide, blue, dashed line. Include the caption within the border.
            Dim myGV As MyGridView = CType(Component, MyGridView)
            Dim markup As String = Nothing
            Dim charX As Integer

            ' Check if the border style should be changed.
            If (myGV.BorderStyle = BorderStyle.NotSet Or _
                myGV.BorderStyle = BorderStyle.None) Then

                Dim oldBorderStyle As BorderStyle = myGV.BorderStyle
                Dim oldBorderWidth As Unit = myGV.BorderWidth
                Dim oldBorderColor As Color = myGV.BorderColor

                ' Set the design-time properties and catch any exceptions.
                Try
                    myGV.BorderStyle = BorderStyle.Dashed
                    myGV.BorderWidth = Unit.Pixel(3)
                    myGV.BorderColor = Color.Blue

                    ' Call the base method to generate the markup.
                    markup = MyBase.GetDesignTimeHtml()

                Catch ex As Exception
                    markup = GetErrorDesignTimeHtml(ex)

                Finally
                    ' Restore the properties to their original settings.
                    myGV.BorderStyle = oldBorderStyle
                    myGV.BorderWidth = oldBorderWidth
                    myGV.BorderColor = oldBorderColor
                End Try

            Else
                ' Call the base method to generate the markup.
                markup = MyBase.GetDesignTimeHtml()
            End If

            ' Look for a <caption> tag.
            charX = markup.IndexOf(capTag)
            If charX > 0 Then

                ' Replace the first caption with 
                ' "tr><td colspan=9 align=center".
                ' It is okay if the colspan exceeds the 
                ' number of columns in the table.
                markup = markup.Remove(charX, _
                    capTag.Length).Insert(charX, trOpen)

                ' Replace the second caption with "td></tr".
                charX = markup.IndexOf(capTag, charX)
                If charX > 0 Then
                    markup = markup.Remove(charX, _
                        capTag.Length).Insert(charX, trClose)
                End If
            End If

            Return markup

        End Function ' GetDesignTimeHtml
        ' </snippet4>
    End Class ' MyGridViewDesigner
End Namespace ' Examples.VB.WebControls.Design
' </snippet1>
