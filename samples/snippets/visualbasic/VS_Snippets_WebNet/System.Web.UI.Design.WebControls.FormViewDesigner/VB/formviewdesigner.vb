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

    ' The MyFormView is a copy of the FormView.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <Designer(GetType(Examples.VB.WebControls.Design.MyFormViewDesigner))> _
    Public Class MyFormView
        Inherits FormView
    End Class ' MyFormView

    ' Override members of the FormViewDesigner.
    Public Class MyFormViewDesigner
        Inherits FormViewDesigner

        ' <snippet2>
        ' Determines the number of design-time links in the pager row.
        Protected Overrides ReadOnly Property SampleRowCount() As Integer
            Get
                ' Render four links in the pager row.
                Return 4
            End Get
        End Property ' SampleRowCount
        ' </snippet2>

        ' <snippet4>
        ' Generate the design-time markup.
        Private Const capTag As String = "caption"
        Private Const trOpen As String = "tr><td colspan=9 align=center"
        Private Const trClose As String = "td></tr"

        Public Overrides Function GetDesignTimeHtml() As String

            ' Make the full extent of the control more visible in the designer.
            ' If the border style is None or NotSet, change the border to
            ' a wide, blue, dashed line. Include the caption within the border.
            Dim myGV As MyFormView = CType(Component, MyFormView)
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
    End Class ' MyFormViewDesigner
End Namespace ' Examples.VB.WebControls.Design
' </snippet1>
