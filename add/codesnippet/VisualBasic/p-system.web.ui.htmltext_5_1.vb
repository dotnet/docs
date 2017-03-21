        ' Override the RenderBeforeTag method to add the 
        ' opening tag of a Font element before the 
        ' opening tag of any Label elements rendered by this 
        ' custom markup writer. 
        Protected Overrides Function RenderBeforeTag() As String
            ' Compare the TagName property value to the
            ' string label to determine whether the element to 
            ' be rendered is a Label. If it is a Label,
            ' the opening tag of the Font element, with a Color
            ' style attribute set to red, is added before
            ' the Label.
            If String.Compare(TagName, "label") = 0 Then
                Return "<font color=""red"">"
                ' If a Label is not being rendered, use 
                ' the base RenderBeforeTag method.
            Else
                Return MyBase.RenderBeforeTag()
            End If
        End Function 'RenderBeforeTag