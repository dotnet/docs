MembershipProviderCollection providers = Membership.Providers;
MembershipProvider[] copiedProviders = new MembershipProvider[providers.Count];
providers.CopyTo(copiedProviders, 0);