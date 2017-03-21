Dim providers As RoleProviderCollection = Roles.Providers
Dim copiedProviders(providers.Count) As RoleProvider
providers.CopyTo(copiedProviders, 0)