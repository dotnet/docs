' CustomCompareValidatorDesigner.vb
'
' <snippet1>
Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design.WebControls
Imports System.ComponentModel
Imports System.Security.Permissions

Namespace Examples.VB.WebControls.Design

    ' <snippet2>
    ' The SimpleCompareValidator is a copy of the CompareValidator.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <Designer(GetType(Examples.VB.WebControls.Design. _
        SimpleCompareValidatorDesigner))> _
    Public Class SimpleCompareValidator
        Inherits CompareValidator
    End Class ' SimpleCompareValidator
    ' </snippet2>

    ' Derive a designer that inherits from the BaseValidatorDesigner.
    Public Class SimpleCompareValidatorDesigner
        Inherits BaseValidatorDesigner

        '<snippet3>
        ' Make the full extent of the control more visible in the designer.
        ' If the border style is None or NotSet, change the border to a 
        ' solid line. 
        Public Overrides Function GetDesignTimeHtml() As String

            ' Get a reference to the control or a copy of the control.
            Dim myCV As SimpleCompareValidator = _
                CType(ViewControl, SimpleCompareValidator)
            Dim markup As String

            ' Check if the border style should be changed.
            If (myCV.BorderStyle = BorderStyle.NotSet Or _
                myCV.BorderStyle = BorderStyle.None) Then

                ' Save the current property setting.
                Dim oldBorderStyle As BorderStyle = myCV.BorderStyle

                ' Set the design-time property and catch any exceptions.
                Try
                    myCV.BorderStyle = BorderStyle.Solid

                    ' Call the base method to generate the markup.
                    markup = MyBase.GetDesignTimeHtml()

                Catch ex As Exception
                    markup = GetErrorDesignTimeHtml(ex)

                Finally
                    ' Restore the property to its original setting.
                    myCV.BorderStyle = oldBorderStyle
                End Try

            Else
                ' Call the base method to generate the markup.
                markup = MyBase.GetDesignTimeHtml()
            End If

            Return markup
        End Function
        '</snippet3>
    End Class ' SimpleCompareValidatorDesigner
End Namespace ' Examples.VB.WebControls.Design
' </snippet1>


