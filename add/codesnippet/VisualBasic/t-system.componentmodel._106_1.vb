        <Category("Data"), _
        Description("Indicates the source of data for the control."), _
        RefreshProperties(RefreshProperties.Repaint), _
        AttributeProvider(GetType(IListSource))> _
        Public Property DataSource() As Object
            Get
                Return Me.dataGridView1.DataSource
            End Get

            Set(ByVal value As Object)
                Me.dataGridView1.DataSource = value
            End Set
        End Property