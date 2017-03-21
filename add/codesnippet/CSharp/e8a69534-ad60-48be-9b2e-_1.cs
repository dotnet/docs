        static void Configure(ServiceHost serviceHost)
        {
            /*
             * There are certain settings that cannot be configured via app.config.  
             * The security state encoder is one of them.
             * Plug in a SecurityStateEncoder that uses the configured certificate 
             * to protect the security context token state.
             * 
             * Note: You don't need a security state encoder for cookie mode.  This was added to the 
             * sample to illustrate how you would plug in a custom security state encoder should
             * your scenario require one.
             * */
            serviceHost.Credentials.SecureConversationAuthentication.SecurityStateEncoder = 
                    new CertificateSecurityStateEncoder(serviceHost.Credentials.ServiceCertificate.Certificate);
           Collection<Type> myClaimTypes = new Collection<Type>();
            myClaimTypes = serviceHost.Credentials.SecureConversationAuthentication.SecurityContextClaimTypes;
        }
