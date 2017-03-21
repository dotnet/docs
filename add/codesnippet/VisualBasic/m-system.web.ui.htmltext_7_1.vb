        ' Override the RenderAfterTag method to add the 
        ' closing tag of the Font element after the 
        ' closing tag of a Label element has been rendered.
        Protected Overrides Function RenderAfterTag() As String
            ' Compare the TagName property value to the
            ' string label to determine whether the element to 
            ' be rendered is a Label. If it is a Label,
            ' the closing tag of a Font element is rendered
            ' after the closing tag of the Label element.
            If String.Compare(TagName, "label") = 0 Then
                Return "</font>"
                ' If a Label is not being rendered, use 
                ' the base RenderAfterTag method.
            Else
                Return MyBase.RenderAfterTag()
            End If
        End Function 'RenderAfterTag
    End Class 'htwFour 