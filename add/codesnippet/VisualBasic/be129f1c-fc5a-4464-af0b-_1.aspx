Dim providers As MembershipProviderCollection = Membership.Providers
Dim copiedProviders(providers.Count) As MembershipProvider
providers.CopyTo(copiedProviders, 0)