Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design.WebControls
Imports System.ComponentModel
Imports System.Security.Permissions

Namespace Examples.VB.WebControls.Design

    ' The MyHiddenField is a copy of the HiddenField.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <Designer(GetType(Examples.VB.WebControls.Design.MyHiddenFieldDesigner))> _
    Public Class MyHiddenField
        Inherits HiddenField
    End Class ' MyVBHiddenField

    ' Derive a designer that inherits from the HiddenFieldDesigner.
    Public Class MyHiddenFieldDesigner
        Inherits HiddenFieldDesigner

        ' Generate the design-time markup.
        Public Overrides Function GetDesignTimeHtml() As String

            ' Get a reference to the control or a copy of the control.
            Dim myHF As MyHiddenField = CType(ViewControl, MyHiddenField)

            Dim markup As String = _
                CreatePlaceHolderDesignTimeHtml( _
                    "Value: """ & myHF.Value.ToString() & """" )

            Return markup

        End Function ' GetDesignTimeHtml
    End Class ' MyHiddenFieldDesigner
End Namespace ' Examples.VB.WebControls.Design