    Protected Overrides Function GetElementKey(ByVal element As ConfigurationElement) As Object
        Return (CType(element, UrlConfigElement)).Name
    End Function