    ' Derive the CustomHyperLinkDesigner from the HyperLinkDesigner.
    Public Class CustomHyperLinkDesigner
        Inherits HyperLinkDesigner

        ' Override the GetDesignTimeHtml to set the CustomHyperLink Text
        ' property so that it displays at design time.
        Public Overrides Function GetDesignTimeHtml() As String

            Dim hype As CustomHyperLink = CType(Component, CustomHyperLink)
            Dim designTimeMarkup As String = Nothing

            ' Save the original Text and note if it is empty.
            Dim text As String = hype.Text
            Dim noText As Boolean = (text.Trim().Length = 0)

            Try
                ' If the Text is empty, supply a default value.
                If noText Then
                    hype.Text = "Click here."
                End If

                ' Call the base method to generate the markup.
                designTimeMarkup = MyBase.GetDesignTimeHtml()

            Catch ex As Exception
                ' If an error occurs, generate the markup for an error message.
                designTimeMarkup = GetErrorDesignTimeHtml(ex)

            Finally
                ' Restore the original value of the Text, if necessary.
                If noText Then
                    hype.Text = text
                End If
            End Try

            ' If the markup is empty, generate the markup for a placeholder.
            If ((designTimeMarkup = Nothing) Or _
                (designTimeMarkup.Length = 0)) Then
                designTimeMarkup = GetEmptyDesignTimeHtml()
            End If

            Return designTimeMarkup

        End Function ' GetDesignTimeHtml
    End Class ' CustomHyperLinkDesigner