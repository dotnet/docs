' <snippet1>
Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Security.Permissions

Namespace Examples.VB.WebControls.Design

    ' <snippet2>
    ' The MyObjectDataSource is a copy of the ObjectDataSource.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <Designer(GetType(Examples.VB.WebControls.Design. _
        MyObjectDataSourceDesigner))> _
    Public Class MyObjectDataSource
        Inherits ObjectDataSource
    End Class ' MyObjectDataSource
    ' </snippet2>

    ' Derive a designer that inherits from the ObjectDataSourceDesigner.
    <ReflectionPermission(SecurityAction.Demand, Flags:=ReflectionPermissionFlag.MemberAccess)> _
    Public Class MyObjectDataSourceDesigner
        Inherits ObjectDataSourceDesigner

        ' <snippet3>
        ' Generate the design-time markup.
        Public Overrides Function GetDesignTimeHtml() As String

            ' Get a reference to the control or a copy of the control.
            Dim myODS As MyObjectDataSource = _
                CType(ViewControl, MyObjectDataSource)

            Dim markup As String = _
                CreatePlaceHolderDesignTimeHtml( _
                    "<b>TypeName</b> """ & myODS.TypeName & """<br />" & _
                    "<b>SelectMethod</b> """ & myODS.SelectMethod & """")

            Return markup

        End Function ' GetDesignTimeHtml
        ' </snippet3>

        ' <snippet4>
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
        ' </snippet4>

    End Class ' MyObjectDataSourceDesigner
End Namespace ' Examples.VB.WebControls.Design
' </snippet1>
