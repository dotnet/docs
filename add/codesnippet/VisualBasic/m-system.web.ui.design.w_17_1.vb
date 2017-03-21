        ' Make the full extent of the control more visible in the designer.
        ' If the border style is None or NotSet, change the border to a 
        ' solid line. 
        Public Overrides Function GetDesignTimeHtml() As String

            ' Get a reference to the control or a copy of the control.
            Dim myCV As SimpleCompareValidator = _
                CType(ViewControl, SimpleCompareValidator)
            Dim markup As String

            ' Check if the border style should be changed.
            If (myCV.BorderStyle = BorderStyle.NotSet Or _
                myCV.BorderStyle = BorderStyle.None) Then

                ' Save the current property setting.
                Dim oldBorderStyle As BorderStyle = myCV.BorderStyle

                ' Set the design-time property and catch any exceptions.
                Try
                    myCV.BorderStyle = BorderStyle.Solid

                    ' Call the base method to generate the markup.
                    markup = MyBase.GetDesignTimeHtml()

                Catch ex As Exception
                    markup = GetErrorDesignTimeHtml(ex)

                Finally
                    ' Restore the property to its original setting.
                    myCV.BorderStyle = oldBorderStyle
                End Try

            Else
                ' Call the base method to generate the markup.
                markup = MyBase.GetDesignTimeHtml()
            End If

            Return markup
        End Function