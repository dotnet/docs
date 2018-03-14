' DesignerEditors.vb
' <snippet1>
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Security.Permissions
Imports System.Drawing.Design

Namespace Examples.VB.WebControls.Design

    ' The MyDataSourceControl has a property of the data source controls.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class MyDataSourceControl
        Inherits WebControl

        ' <snippet2>
        Private selectParams As ParameterCollection

        ' Associate the ParameterCollectionEditor with the SelectParameters. 
        <EditorAttribute(GetType(System.Web.UI.Design.WebControls. _
            ParameterCollectionEditor), _
            GetType(UITypeEditor))> _
        Public Property SelectParameters() As ParameterCollection
            Get
                If selectParams Is Nothing Then
                    selectParams = New ParameterCollection()
                End If
                Return selectParams
            End Get
            Set(ByVal value As ParameterCollection)
                selectParams = value
            End Set
        End Property ' SelectParameters
        ' </snippet2>

    End Class ' MyDataSourceControl
End Namespace ' Examples.VB.WebControls.Design
' </snippet1>
