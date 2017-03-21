        ' Override the GetDesignTimeHtml method to display a border on the 
        ' control if the BorderStyle property has not been set by the user.
        Public Overrides Function GetDesignTimeHtml() As String

            Dim sampleCheckBox As SampleCheckBox = CType(Component, _
                SampleCheckBox)
            Dim designTimeHtml As String = Nothing

            ' Check the control's BorderStyle property.
            If (sampleCheckBox.BorderStyle = BorderStyle.NotSet) Then

                ' Save the current value of the BorderStyle property.
                Dim oldBorderStyle As BorderStyle = _
                    sampleCheckBox.BorderStyle

                ' Change the value of the BorderStyle property and 
                ' generate the design-time HTML.
                Try
                    sampleCheckBox.BorderStyle = BorderStyle.Groove
                    designTimeHtml = MyBase.GetDesignTimeHtml()

                    ' If an exception occurs, call the GetErrorDesignTimeHtml
                    ' method.
                Catch ex As Exception
                    designTimeHtml = GetErrorDesignTimeHtml(ex)

                    ' Restore the BorderStyle property to its original value.
                Finally
                    sampleCheckBox.BorderStyle = oldBorderStyle
                End Try

            Else
                designTimeHtml = MyBase.GetDesignTimeHtml()
            End If

            Return designTimeHtml
        End Function