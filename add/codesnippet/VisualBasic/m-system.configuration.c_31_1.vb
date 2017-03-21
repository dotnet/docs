    Default Public Shadows ReadOnly Property Item(ByVal Name As String) As UrlConfigElement
        Get
            Return CType(BaseGet(Name), UrlConfigElement)
        End Get
    End Property