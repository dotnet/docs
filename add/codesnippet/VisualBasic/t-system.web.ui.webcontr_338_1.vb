Imports System
Imports System.Web
Imports System.Security.Permissions

Namespace Contoso

    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class HierarchicalTreeViewAdapter
        Inherits _
        System.Web.UI.WebControls.Adapters.HierarchicalDataBoundControlAdapter

        ' Return a strongly-typed TreeView control for adapter.
        Protected Overloads ReadOnly Property Control() As _
            System.Web.UI.WebControls.TreeView

            Get
                Return CType( _
                    MyBase.Control, _
                    System.Web.UI.WebControls.TreeView)
            End Get
        End Property

        ' Verify the DataSourceID property is set prior to binding data.
        Protected Overrides Sub PerformDataBinding()

            If (Not Control.DataSourceID Is Nothing) Then

                MyBase.PerformDataBinding()
            End If
        End Sub
    End Class
End Namespace