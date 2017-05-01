Imports System
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.WebControls
Imports System.ComponentModel

Public Class MyCustomHierarchicalControl
   Inherits TreeView

    '<Snippet2>
   Private _dataSource As object

   <TypeConverterAttribute(GetType(HierarchicalDataSourceConverter))>  _
   Public Overrides Property DataSource() As Object
      Get
         Return _dataSource
      End Get
      
      Set
        If Not value is Nothing
            ValidateDataSource(value)
        End If
        _dataSource = value
        OnDataPropertyChanged()
         
      End Set
   End Property
    '</Snippet2>       

    ' Define rest of custom control implementation.
    ' ...
End Class