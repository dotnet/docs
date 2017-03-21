        ' Generate the design-time markup.
        Public Overrides Function GetDesignTimeHtml() As String

            ' Make the control more visible in the designer.  If the border 
            ' style is None or NotSet, change the border to an orange dotted line. 
            Dim myMenuCtl As MyMenu = CType(ViewControl, MyMenu)
            Dim markup As String = Nothing

            ' Check if the border style should be changed.
            If (myMenuCtl.BorderStyle = BorderStyle.NotSet Or _
                myMenuCtl.BorderStyle = BorderStyle.None) Then

                Dim oldBorderStyle As BorderStyle = myMenuCtl.BorderStyle
                Dim oldBorderColor As Color = myMenuCtl.BorderColor

                ' Set the design-time properties and catch any exceptions.
                Try
                    myMenuCtl.BorderStyle = BorderStyle.Dotted
                    myMenuCtl.BorderColor = Color.FromArgb(&HFF7F00)

                    ' Call the base method to generate the markup.
                    markup = MyBase.GetDesignTimeHtml()

                Catch ex As Exception
                    markup = GetErrorDesignTimeHtml(ex)

                Finally
                    ' Restore the properties to their original settings.
                    myMenuCtl.BorderStyle = oldBorderStyle
                    myMenuCtl.BorderColor = oldBorderColor
                End Try

            Else
                ' Call the base method to generate the markup.
                markup = MyBase.GetDesignTimeHtml()
            End If

            Return markup

        End Function ' GetDesignTimeHtml