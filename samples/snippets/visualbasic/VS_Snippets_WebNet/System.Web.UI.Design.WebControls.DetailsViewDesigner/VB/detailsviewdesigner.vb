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

    ' The MyDetailsView is a copy of the DetailsView.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <Designer(GetType(Examples.VB.WebControls.Design.MyDetailsViewDesigner))> _
    Public Class MyDetailsView
        Inherits DetailsView
    End Class ' MyVBDetailsView

    ' Override members of the DetailsViewDesigner.
    <ReflectionPermission(SecurityAction.Demand, Flags:=ReflectionPermissionFlag.MemberAccess)> _
    Public Class MyDetailsViewDesigner
        Inherits DetailsViewDesigner

        ' <snippet2>
        ' Determines the number of page links in the pager row
        ' when viewed in the designer.
        Protected Overrides ReadOnly Property SampleRowCount() As Integer
            Get
                ' Render five page links in the pager row.
                Return 5
            End Get
        End Property ' SampleRowCount
        ' </snippet2>

        ' <snippet3>
        ' Shadow the control properties with design-time properties.
        Protected Overrides Sub PreFilterProperties( _
            ByVal properties As IDictionary)

            ' Call the base method first.
            MyBase.PreFilterProperties(properties)

            ' Make the NamingContainer visible in the Properties grid.
            Dim selectProp As PropertyDescriptor = _
                CType(properties("NamingContainer"), PropertyDescriptor)
            properties("NamingContainer") = _
                TypeDescriptor.CreateProperty(selectProp.ComponentType, _
                    selectProp, BrowsableAttribute.Yes)
        End Sub ' PreFilterProperties
        ' </snippet3>

        ' <snippet4>
        ' Generate the design-time markup.
        Private Const capTag As String = "caption"
        Private Const trOpen As String = "tr><td colspan=2 align=center"
        Private Const trClose As String = "td></tr"

        Public Overrides Function GetDesignTimeHtml() As String

            ' Make the full extent of the control more visible in the designer.
            ' If the border style is None or NotSet, change the border to
            ' a wide, blue, dashed line. Include the caption within the border.
            Dim myDV As MyDetailsView = CType(Component, MyDetailsView)
            Dim markup As String = Nothing
            Dim charX As Integer

            ' Check if the border style should be changed.
            If (myDV.BorderStyle = BorderStyle.NotSet Or _
                myDV.BorderStyle = BorderStyle.None) Then

                Dim oldBorderStyle As BorderStyle = myDV.BorderStyle
                Dim oldBorderWidth As Unit = myDV.BorderWidth
                Dim oldBorderColor As Color = myDV.BorderColor

                ' Set design-time properties and catch any exceptions.
                Try
                    myDV.BorderStyle = BorderStyle.Dashed
                    myDV.BorderWidth = Unit.Pixel(3)
                    myDV.BorderColor = Color.Blue

                    ' Call the base method to generate the markup.
                    markup = MyBase.GetDesignTimeHtml()

                Catch ex As Exception
                    markup = GetErrorDesignTimeHtml(ex)

                Finally
                    ' Restore the properties to their original settings.
                    myDV.BorderStyle = oldBorderStyle
                    myDV.BorderWidth = oldBorderWidth
                    myDV.BorderColor = oldBorderColor
                End Try

            Else
                ' Call the base method to generate the markup.
                markup = MyBase.GetDesignTimeHtml()
            End If

            ' Look for a <caption> tag.
            charX = markup.IndexOf(capTag)
            If charX > 0 Then

                ' Replace the first caption with 
                ' "tr><td colspan=2 align=center".
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
    End Class ' MyDetailsViewDesigner
End Namespace ' Examples.VB.WebControls.Design
' </snippet1>
