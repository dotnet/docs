        ' Generate the design-time markup.
        Private Const capTag As String = "caption"
        Private Const trOpen As String = "tr><td colspan=2 align=center"
        Private Const trClose As String = "td></tr"

        Public Overrides Function GetDesignTimeHtml() As String

            ' Make the full extent of the control more visible in the designer.
            ' If the border style is None or NotSet, change the border to
            ' a wide, blue, dashed line. Include the caption within the border.
            Dim myDV As MyDetailsView = CType(Component, MyDetailsView)
            Dim markup As String = Nothing
            Dim charX As Integer

            ' Check if the border style should be changed.
            If (myDV.BorderStyle = BorderStyle.NotSet Or _
                myDV.BorderStyle = BorderStyle.None) Then

                Dim oldBorderStyle As BorderStyle = myDV.BorderStyle
                Dim oldBorderWidth As Unit = myDV.BorderWidth
                Dim oldBorderColor As Color = myDV.BorderColor

                ' Set design-time properties and catch any exceptions.
                Try
                    myDV.BorderStyle = BorderStyle.Dashed
                    myDV.BorderWidth = Unit.Pixel(3)
                    myDV.BorderColor = Color.Blue

                    ' Call the base method to generate the markup.
                    markup = MyBase.GetDesignTimeHtml()

                Catch ex As Exception
                    markup = GetErrorDesignTimeHtml(ex)

                Finally
                    ' Restore the properties to their original settings.
                    myDV.BorderStyle = oldBorderStyle
                    myDV.BorderWidth = oldBorderWidth
                    myDV.BorderColor = oldBorderColor
                End Try

            Else
                ' Call the base method to generate the markup.
                markup = MyBase.GetDesignTimeHtml()
            End If

            ' Look for a <caption> tag.
            charX = markup.IndexOf(capTag)
            If charX > 0 Then

                ' Replace the first caption with 
                ' "tr><td colspan=2 align=center".
                markup = markup.Remove(charX, _
                    capTag.Length).Insert(charX, trOpen)

                ' Replace the second caption with "td></tr".
                charX = markup.IndexOf(capTag, charX)
                If charX > 0 Then
                    markup = markup.Remove(charX, _
                        capTag.Length).Insert(charX, trClose)
                End If
            End If

            Return markup

        End Function ' GetDesignTimeHtml