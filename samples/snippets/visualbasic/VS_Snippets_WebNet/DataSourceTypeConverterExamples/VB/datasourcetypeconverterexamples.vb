Imports System
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.WebControls
Imports System.ComponentModel

Public Class DataSourceTypeConverterExampleControl
   Inherits System.Web.UI.WebControls.WebControl

    '<Snippet1>
   ' Associates the DataBindingCollectionConverter 
   ' with a DataBindingCollection property.   
   <TypeConverterAttribute(GetType(DataBindingCollectionConverter))>  _
   Public Property dataBindings() As DataBindingCollection
      Get
         Return bindings
      End Get
      Set
         bindings = value
      End Set
   End Property
   Private bindings As DataBindingCollection
    '</Snippet1>       

   '<Snippet2>
   ' Associates the DataMemberConverter with a string property.   
   <TypeConverterAttribute(GetType(DataMemberConverter))>  _
   Public Property dataMember() As String
      Get
         Return member
      End Get
      Set
         member = value
      End Set
   End Property
   Private member As String
    '</Snippet2>        

   '<Snippet3>
   ' Associates the DataFieldConverter with a string property.   
   <TypeConverterAttribute(GetType(DataMemberConverter))>  _
   Public Property dataField() As String
      Get
         Return field
      End Get
      Set
         field = value
      End Set
   End Property
   Private field As String
    '</Snippet3>        

   '<Snippet4>
   ' Associates the DataSourceConverter with an object property.   
   <TypeConverterAttribute(GetType(DataSourceConverter))>  _
   Public Property dataSource() As Object
      Get
         Return [source]
      End Get
      Set
         [source] = value
      End Set
   End Property
   Private [source] As Object
   '</Snippet4>        
   
   <Bindable(True), Category("Appearance"), DefaultValue("")>  _
   Public Property [Text]() As String
      Get
            Return [text_]
      End Get
      
      Set
            [text_] = Value
      End Set
   End Property
    Private [text_] As String
   
    Protected Overrides Sub Render(ByVal output As HtmlTextWriter)
        output.Write([Text])
    End Sub
End Class