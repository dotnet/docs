        ' Create the markup to display the control on the design surface.
        Public Overrides Function GetDesignTimeHtml() As String

            Dim designTimeHtml As String = String.Empty

            ' Create variables to access the control's
            ' item collection and back color. 
            Dim items As ListItemCollection = simpleRadioButtonList.Items
            Dim oldBackColor As Color = simpleRadioButtonList.BackColor

            ' Check the property values and render the markup
            ' on the design surface accordingly.
            Try
                If (Color.op_Equality(oldBackColor, Color.Empty)) Then
                    simpleRadioButtonList.BackColor = Color.Gainsboro
                End If

                If (changedDataSource) Then
                    items.Add( _
                        "Updated to a new data source: " & DataSource & ".")
                End If

                designTimeHtml = MyBase.GetDesignTimeHtml()

            Catch ex As Exception
                ' Catch any exceptions that occur.
                MyBase.GetErrorDesignTimeHtml(ex)

            Finally
                ' Set the properties back to their original state.
                simpleRadioButtonList.BackColor = oldBackColor
                items.Clear()
            End Try

            Return designTimeHtml
        End Function ' GetDesignTimeHtml