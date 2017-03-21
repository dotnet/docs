          ChannelFactory<ISimpleChannel> cf =
              new ChannelFactory<ISimpleChannel>();
          cf.Credentials.ClientCertificate.SetCertificate(
              StoreLocation.CurrentUser, StoreName.My,
              X509FindType.FindByThumbprint,
"37 28 05 09 22 81 07 08 a0 cd 2a af dd c3 83 cd c3 3b 8f 9d");
          cf.Credentials.ServiceCertificate.SetDefaultCertificate(
              StoreLocation.CurrentUser,
              StoreName.TrustedPeople,
              X509FindType.FindByThumbprint,
"33 93 68 cc 7c 75 80 24 a2 80 9f 45 8c 81 fa 92 ad 5b 04 39");
          cf.Credentials.ServiceCertificate.Authentication.CertificateValidationMode
              = X509CertificateValidationMode.PeerOrChainTrust;