        ' This method adds a RadioButton control and any other 
        ' content to the cell's Controls collection.
        Protected Overrides Sub InitializeDataCell( _
            ByVal cell As DataControlFieldCell, _
            ByVal rowState As DataControlRowState)

            Dim radio As New RadioButton()

            ' If the RadioButton is bound to a DataField, add
            ' the OnDataBindingField method event handler to the
            ' DataBinding event.
            If DataField.Length <> 0 Then
                AddHandler radio.DataBinding, AddressOf Me.OnDataBindField
            End If

            radio.Text = Me.Text

            ' Because the RadioButtonField is a BoundField, it only 
            ' displays data. Therefore, unless the row is in edit mode, 
            ' the RadioButton is displayed as disabled.
            radio.Enabled = False
            ' If the row is in edit mode, enable the button.
            If (rowState And DataControlRowState.Edit) <> 0 _
                OrElse (rowState And DataControlRowState.Insert) <> 0 Then
                radio.Enabled = True
            End If

            cell.Controls.Add(radio)
        End Sub