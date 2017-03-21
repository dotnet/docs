        public override Evidence ProvideAppDomainEvidence(Evidence evidence)
        {
            Console.WriteLine("Provide evidence for the " + AppDomain.CurrentDomain.FriendlyName + " AppDomain.");
            if (evidence == null)
                return null;

            evidence.AddHostEvidence(new CustomEvidenceType());
            return evidence;
        }