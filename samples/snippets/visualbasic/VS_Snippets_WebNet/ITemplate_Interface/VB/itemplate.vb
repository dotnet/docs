' <snippet1>
' Create a class that implements the ITemplate interface.
' This class overrides the InstantiateIn method to always
' place templates in a Literal object. It also creates a 
' custom BindData method that is used as the event handler
' associated with the Literal object's DataBinding event.  

Imports System
Imports System.Web
Imports System.Data
Imports System.Web.UI
Imports System.Web.UI.WebControls


Namespace UsingItemTemplatesVB

 Public Class GenericItem
   Implements ITemplate 

   Private column As String
   
   Public Sub New(column As String)
      Me.column = column
   End Sub 'New
   
   
   ' <snippet2>
   ' Override the ITemplate.InstantiateIn method to ensure 
   ' that the templates are created in a Literal control and
   ' that the Literal object's DataBinding event is associated
   ' with the BindData method.
   Public Sub InstantiateIn(container As Control) Implements ITemplate.InstantiateIn
      Dim l As New Literal()
      AddHandler l.DataBinding, AddressOf Me.BindData
      container.Controls.Add(l)
   End Sub 'InstantiateIn
   
   ' Create a public method that will handle the
   ' DataBinding event called in the InstantiateIn method.
   Public Sub BindData(sender As Object, e As EventArgs)
      Dim l As Literal = CType(sender, Literal)
      Dim container As DataGridItem = CType(l.NamingContainer, DataGridItem)
      l.Text = CType(container.DataItem, DataRowView)(column).ToString()
   End Sub 'BindData 
   ' </snippet2>
 End Class 'GenericItem
End Namespace 'UsingItemTemplatesVB
' </snippet1>