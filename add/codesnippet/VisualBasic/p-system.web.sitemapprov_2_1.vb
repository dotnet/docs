    ' Implement the ParentProvider property.
    Public Overrides Property ParentProvider() As SiteMapProvider
      Get
        Return parentSiteMapProvider
      End Get
      Set(ByVal value As SiteMapProvider)
        parentSiteMapProvider = Value
      End Set
    End Property

    ' Implement the RootProvider property.
    Public Overrides ReadOnly Property RootProvider() As SiteMapProvider
      Get
        ' If the current instance belongs to a provider hierarchy, it
        ' cannot be the RootProvider. Rely on the ParentProvider.
        If Not (Me.ParentProvider Is Nothing) Then
          Return ParentProvider.RootProvider
          ' If the current instance does not have a ParentProvider, it is
          ' not a child in a hierarchy, and can be the RootProvider.
        Else
          Return Me
        End If
      End Get
    End Property
