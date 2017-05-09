' SimpleRadioButtonList.vb
'
' <snippet5>
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Security.Permissions

Namespace Examples.VB.WebControls.Design

    ' The SimpleRadioButtonList is a copy of the RadioButtonList.
    ' It uses the SimpleRadioButtonListDesigner for design-time support.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <DesignerAttribute(GetType(Examples.VB.WebControls.Design. _
        SimpleRadioButtonListDesigner))> _
    <DataBindingHandler(GetType(Examples.VB.WebControls.Design. _
        SimpleRadioButtonListDataBindingHandler))> _
    Public Class SimpleRadioButtonList
        Inherits RadioButtonList
    End Class ' SimpleRadioButtonList
End Namespace ' Examples.VB.WebControls.Design
' </snippet5>
