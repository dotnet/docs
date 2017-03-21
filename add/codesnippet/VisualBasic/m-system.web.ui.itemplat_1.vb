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