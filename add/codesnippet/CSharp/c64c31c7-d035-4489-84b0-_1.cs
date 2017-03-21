        [SecurityPermissionAttribute(SecurityAction.Demand, Execution = true)]
        [SecurityPermissionAttribute(SecurityAction.Assert, Unrestricted = true)]
        public override ApplicationTrust DetermineApplicationTrust(Evidence applicationEvidence, Evidence activatorEvidence, TrustManagerContext context)
        {
            if (applicationEvidence == null)
                throw new ArgumentNullException("applicationEvidence");

            // Get the activation context from the application evidence.
            // This HostSecurityManager does not examine the activator evidence
            // nor is it concerned with the TrustManagerContext;
            // it simply grants the requested grant in the application manifest.

            IEnumerator enumerator = applicationEvidence.GetHostEnumerator();
            ActivationArguments activationArgs = null;
            while (enumerator.MoveNext())
            {
                activationArgs = enumerator.Current as ActivationArguments;
                if (activationArgs != null)
                    break;
            }

            if (activationArgs == null)
                return null;

            ActivationContext activationContext = activationArgs.ActivationContext;
            if (activationContext == null)
                return null;

            ApplicationTrust trust = new ApplicationTrust(activationContext.Identity);
            ApplicationSecurityInfo asi = new ApplicationSecurityInfo(activationContext);
            trust.DefaultGrantSet = new PolicyStatement(asi.DefaultRequestSet, PolicyStatementAttribute.Nothing);
            trust.IsApplicationTrustedToRun = true;
            return trust;
        }