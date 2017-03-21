        ' Override the DataBindControl.
        Public Overrides Sub DataBindControl( _
        ByVal designerHost As IDesignerHost, _
        ByVal control As Control)

            ' Create a reference, named dataSourceBinding,
            ' to the control's DataSource binding.
            Dim dataSourceBinding As DataBinding _
                = CType( _
                control, _
                IDataBindingsAccessor).DataBindings("DataSource")

            ' If the binding exists, create a reference to the
            ' list control, clear its ListItemCollection, and then add
            ' an item to the collection.
            If Not (dataSourceBinding Is Nothing) Then
                Dim simpleControl As SimpleRadioButtonList = _
                    CType(control, SimpleRadioButtonList)

                simpleControl.Items.Clear()
                simpleControl.Items.Add("Data-bound Radio Button.")
            End If
        End Sub ' DataBindControl