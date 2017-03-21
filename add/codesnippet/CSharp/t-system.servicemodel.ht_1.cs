                // The code uses a shortcut to specify the security mode to Transport.
                WSHttpBinding b = new WSHttpBinding(SecurityMode.Transport);
                b.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;