        ' Do not allow direct resizing unless in TemplateMode
        Public Overrides ReadOnly Property AllowResize() As Boolean
            Get
                If Me.InTemplateMode Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property