        ' If a <font> element is to be rendered, check whether it contains
        ' a size attribute. If it does not, add one and set its value to
        ' 20 points, then return true.
        Protected Overrides Function OnTagRender( _
            name As String, _
            key As HtmlTextWriterTag) _
        As Boolean

            If (key = HtmlTextWriterTag.Font) Then
                If Not (IsAttributeDefined(HtmlTextWriterAttribute.Size)) Then
                    AddAttribute(HtmlTextWriterAttribute.Size, "20pt")
                    Return True
                End If
            End If

            ' If the element is not a <font> element, use
            ' the base functionality of the OnTagRenderMethod.
            Return MyBase.OnTagRender(name, key)
        End Function