' <Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI

Namespace Samples.AspNet.Controls.VB

    '
    ' vbc /t:library /out:Samples.AspNet.Controls.VB.dll SomeDataSource.vb
    '
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class SomeDataSource
       Implements IDataSource, IListSource

       Public Sub New()
       End Sub 'New
       Private view As SomeDataSourceView = Nothing
' <Snippet2>
       #Region "Implementation of IDataSource"

       Public Overridable Function GetView(viewName As String) As DataSourceView Implements IDataSource.GetView
          If view Is Nothing Then
             view = New SomeDataSourceView(Me)
          End If
          Return view
       End Function 'GetView


       Public Overridable Function GetViewNames() As ICollection Implements IDataSource.GetViewNames
          Dim al As New ArrayList(1)
          al.Add(GetView(String.Empty).Name)
          Return CType( al, ICollection)
       End Function 'GetViewNames

       Event DataSourceChanged As EventHandler Implements IDataSource.DataSourceChanged

       #End Region

' <Snippet3>
       #Region "Implementation of IListSource"

       ReadOnly Property ContainsListCollection() As Boolean Implements IListSource.ContainsListCollection
          Get
             Return ListSourceHelper.ContainsListCollection(Me)
          End Get
       End Property


       Function GetList() As IList Implements IListSource.GetList
          Return ListSourceHelper.GetList(Me)
       End Function 'IListSource.GetList

       #End Region
' </Snippet3>
' </Snippet2>
    End Class 'SomeDataSource


    Public Class SomeDataSourceView
       Inherits DataSourceView

       Private Shared defaultViewName As String = "_SomeDataSourceView"

       Public Sub New(owner As IDataSource)
          MyBase.New(owner, defaultViewName)
       End Sub 'New


       Protected Overrides Function ExecuteSelect(selectArguments As DataSourceSelectArguments) As IEnumerable
          Return Nothing
       End Function 'Select
    End Class 'SomeDataSourceView
End Namespace
' </Snippet1>