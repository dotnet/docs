            rcc.SetScopedCertificate(StoreLocation.CurrentUser, _
                        StoreName.TrustedPeople, _
                        X509FindType.FindBySubjectName, _
                        "FabrikamSTS", _
                        New Uri("http://fabrikam.com/sts"))