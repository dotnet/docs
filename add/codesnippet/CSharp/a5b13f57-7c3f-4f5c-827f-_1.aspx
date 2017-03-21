RoleProviderCollection providers = Roles.Providers;
RoleProvider[] copiedProviders = new RoleProvider[providers.Count];
providers.CopyTo(copiedProviders, 0);