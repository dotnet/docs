        ' Override the HtmlDecodeLiterals method to allow HTML
        ' decoding of literal strings in any controls this builder
        ' is applied to.
        Public Overrides Function HtmlDecodeLiterals() As Boolean
            Return True
        End Function