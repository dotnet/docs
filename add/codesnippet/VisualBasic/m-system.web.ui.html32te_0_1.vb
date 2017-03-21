        ' Override the RenderAfterContent method to close
        ' styles opened during the call to the RenderBeforeContent
        ' method.
        Protected Overrides Function RenderAfterContent() As String

            ' Check whether the element being rendered is a <th> element.
            ' If so, and the requesting device supports bold formatting,
            ' render the closing tag of the <b> element. If not,
            ' render the closing tag of the <font> element.
            If TagKey = HtmlTextWriterTag.Th Then
                If SupportsBold Then
                    Return "</b>"
                Else
                    Return "</font>"
                End If
            End If

            ' Check whether the element being rendered is an <H4>.
            ' element. If so, and the requesting device supports italic
            ' formatting, render the closing tag of the <i> element.
            ' If not, render the closing tag of the <font> element.
            If TagKey = HtmlTextWriterTag.H4 Then
                If (SupportsItalic) Then
                    Return "</i>"
                Else
                    Return "</font>"
                End If
            End If
            ' Call the base method.
            Return MyBase.RenderAfterContent()
        End Function