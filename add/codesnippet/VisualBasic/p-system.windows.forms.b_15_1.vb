    Dim WithEvents bmb As BindingManagerBase

    Private Sub InitializeControlsAndData() 
        ' Initialize the controls and set location, size and 
        ' other basic properties.
        Me.dataGridView1 = New DataGridView()
        
        Me.textBox1 = New TextBox()
        Me.textBox2 = New TextBox()
        Me.dataGridView1.ColumnHeadersHeightSizeMode = _
            DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Dock = DockStyle.Top
        Me.dataGridView1.Location = New Point(0, 0)
        Me.dataGridView1.Size = New Size(292, 150)
        Me.textBox1.Location = New Point(132, 156)
        Me.textBox1.Size = New Size(100, 20)
        Me.textBox2.Location = New Point(12, 156)
        Me.textBox2.Size = New Size(100, 20)
        Me.ClientSize = New Size(292, 266)
        Me.Controls.Add(Me.textBox2)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.dataGridView1)
        
        ' Declare the DataSet and add a table and column.
        Dim set1 As New DataSet()
        set1.Tables.Add("Menu")
        set1.Tables(0).Columns.Add("Beverages")
        
        ' Add some rows to the table.
        set1.Tables(0).Rows.Add("coffee")
        set1.Tables(0).Rows.Add("tea")
        set1.Tables(0).Rows.Add("hot chocolate")
        set1.Tables(0).Rows.Add("milk")
        set1.Tables(0).Rows.Add("orange juice")

        ' Add the control data bindings.
        dataGridView1.DataSource = set1
        dataGridView1.DataMember = "Menu"
        textBox1.DataBindings.Add("Text", set1, "Menu.Beverages", _
            True, DataSourceUpdateMode.OnPropertyChanged)
        textBox2.DataBindings.Add("Text", set1, "Menu.Beverages", _
            True, DataSourceUpdateMode.OnPropertyChanged)

        ' Get the BindingManagerBase for this binding.
        bmb = Me.BindingContext(set1, "Menu")

    End Sub
    
    Private Sub bmb_BindingComplete(ByVal sender As Object, ByVal e As BindingCompleteEventArgs) _
        Handles bmb.BindingComplete

        ' Check if the data source has been updated, and that no error has occured.
        If e.BindingCompleteContext = BindingCompleteContext.DataSourceUpdate _
            AndAlso e.Exception Is Nothing Then

            ' If not, end the current edit.
            e.Binding.BindingManagerBase.EndCurrentEdit()
        End If
    End Sub