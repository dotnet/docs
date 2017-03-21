    Public Sub New() 
        ' Set up the form.
        Me.Size = New Size(800, 800)
        AddHandler Me.Load, AddressOf Form1_Load
        
        ' Set up the DataGridView control.
        Me.customersDataGridView.AllowUserToAddRows = True
        Me.customersDataGridView.Dock = DockStyle.Fill
        Me.Controls.Add(customersDataGridView)
        
        ' Add the StatusBar control to the form.
        Me.Controls.Add(status)
        
        ' Allow the user to add new items.
        Me.customersBindingSource.AllowNew = True
        
        ' Attach the BindingSource to the DataGridView.
        Me.customersDataGridView.DataSource = Me.customersBindingSource
    
    End Sub