    Default Public Shadows Property Item(ByVal index As Integer) As UrlConfigElement
        Get
            Return CType(BaseGet(index), UrlConfigElement)
        End Get
        Set(ByVal value As UrlConfigElement)
            If BaseGet(index) IsNot Nothing Then
                BaseRemoveAt(index)
            End If
            BaseAdd(value)
        End Set
    End Property