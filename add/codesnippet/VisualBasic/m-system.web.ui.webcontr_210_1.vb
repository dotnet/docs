        Public Overrides Function Transform(ByVal providerData As Object) As Object
            _provider = CType(providerData, IWebPartRow)
            Return Me
        End Function