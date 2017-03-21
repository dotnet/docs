    Private WithEvents bindingSource1 As New BindingSource()
    Private box1 As New TextBox()
   
    
    Private Sub PopulateBindingSourceWithFonts()
      
        bindingSource1.Add(New Font(FontFamily.Families(2), 8.0F))
        bindingSource1.Add(New Font(FontFamily.Families(4), 9.0F))
        bindingSource1.Add(New Font(FontFamily.Families(6), 10.0F))
        bindingSource1.Add(New Font(FontFamily.Families(8), 11.0F))
        bindingSource1.Add(New Font(FontFamily.Families(10), 12.0F))
        Dim view1 As New DataGridView()
        view1.DataSource = bindingSource1
        view1.AutoGenerateColumns = True
        view1.Dock = DockStyle.Top
        Me.Controls.Add(view1)
        box1.Dock = DockStyle.Bottom
        box1.Text = "Sample Text"
        Me.Controls.Add(box1)
        view1.Columns("Name").DisplayIndex = 0
        box1.DataBindings.Add("Text", bindingSource1, "Name")
        
    End Sub
     
    Sub bindingSource1_CurrentChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles bindingSource1.CurrentChanged
        box1.Font = CType(bindingSource1.Current, Font)
    End Sub