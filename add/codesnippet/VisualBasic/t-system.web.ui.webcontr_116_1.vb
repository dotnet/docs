        ' This method is called by the ExtractRowValues methods of
        ' GridView and DetailsView. Retrieve the current value of the 
        ' cell from the Checked state of the Radio button.
        Public Overrides Sub ExtractValuesFromCell( _
            ByVal dictionary As IOrderedDictionary, _
            ByVal cell As DataControlFieldCell, _
            ByVal rowState As DataControlRowState, _
            ByVal includeReadOnly As Boolean)
            ' Determine whether the cell contain a RadioButton 
            ' in its Controls collection.
            If cell.Controls.Count > 0 Then
                Dim radio As RadioButton = CType(cell.Controls(0), RadioButton)

                Dim checkedValue As Object = Nothing
                If radio Is Nothing Then
                    ' A RadioButton is expected, but a null is encountered.
                    ' Add error handling.
                    Throw New InvalidOperationException( _
                        "RadioButtonField could not extract control.")
                Else
                    checkedValue = radio.Checked
                End If


                ' Add the value of the Checked attribute of the
                ' RadioButton to the dictionary.
                If dictionary.Contains(DataField) Then
                    dictionary(DataField) = checkedValue
                Else
                    dictionary.Add(DataField, checkedValue)
                End If
            End If
        End Sub