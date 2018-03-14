 ' <snippet1>
Imports System
Imports System.IO
Imports System.Web
Imports System.Drawing
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Security.Permissions

Namespace Examples.VB.WebControls.Design

    ' The MyHierarchicalDataBoundControl is a copy of the 
    ' HierarchicalDataBoundControl.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <Designer(GetType(Examples.VB.WebControls.Design. _
        MyHierarchicalDataBoundControlDesigner))> _
    Public Class MyHierarchicalDataBoundControl
        Inherits HierarchicalDataBoundControl
    End Class ' MyHierarchicalDataBoundControl

    ' Override members of the HierarchicalDataBoundControlDesigner.
    <ReflectionPermission(SecurityAction.Demand, Flags:=ReflectionPermissionFlag.MemberAccess)> _
    Public Class MyHierarchicalDataBoundControlDesigner
        Inherits HierarchicalDataBoundControlDesigner

        ' <snippet2>
        Private Const bracketClose As String = ">"
        Private Const spanOpen As String = "<SPAN"
        Private Const spanClose As String = "</SPAN>"

        ' Return the markup for a placeholder, if the inner markup is empty.
        ' For brevity, the code that is used to detect embedded white_space 
        ' in the tags is not shown.
        Public Overrides Function GetDesignTimeHtml() As String

            ' Get the design-time markup from the base method.
            Dim markup As String = MyBase.GetDesignTimeHtml()

            ' If the markup is null or empty, return the markup 
            ' for the placeholder.
            If markup Is Nothing OrElse markup = String.Empty Then
                Return GetEmptyDesignTimeHtml()
            End If

            ' Make the markup uniform case so that the IndexOf will work.
            Dim markupUC As String = markup.ToUpper()
            Dim charX As Integer

            ' Look for a <span ...> tag.
            charX = markupUC.IndexOf(spanOpen)
            If charX >= 0 Then

                ' Find closing bracket of span open tag.
                charX = markupUC.IndexOf(bracketClose, charX + spanOpen.Length)
                If charX >= 0 Then

                    ' If the inner markup of <span ...></span> is empty, 
                    ' return the markup for a placeholder.
                    If String.Compare(markupUC, charX + 1, _
                        spanClose, 0, spanClose.Length) = 0 Then

                        Return GetEmptyDesignTimeHtml()
                    End If
                End If
            End If

            ' Return the original markup, if the inner markup is not empty.
            Return markup
        End Function ' GetDesignTimeHtml
        ' </snippet2>

        ' <snippet3>
        ' Shadow the control properties with design-time properties.
        Protected Overrides Sub PreFilterProperties( _
            ByVal properties As IDictionary)

            Dim namingContainer As String = "NamingContainer"

            ' Call the base method first.
            MyBase.PreFilterProperties(properties)

            ' Make the NamingContainery visible in the Properties grid.
            Dim selectProp As PropertyDescriptor = _
                CType(properties(namingContainer), PropertyDescriptor)
            properties(namingContainer) = _
                TypeDescriptor.CreateProperty(selectProp.ComponentType, _
                    selectProp, BrowsableAttribute.Yes)
        End Sub ' PreFilterProperties
        ' </snippet3>
    End Class ' MyHierarchicalDataBoundControlDesigner
End Namespace ' Examples.VB.WebControls.Design
' </snippet1>