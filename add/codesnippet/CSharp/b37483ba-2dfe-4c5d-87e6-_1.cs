        public override Evidence ProvideAssemblyEvidence(Assembly loadedAssembly, Evidence evidence)
        {
            Console.WriteLine("Provide assembly evidence for: " + (loadedAssembly == null ? "Unknown" : loadedAssembly.ToString()) + ".");
            if (evidence == null)
                return null;

            evidence.AddAssemblyEvidence(new CustomEvidenceType());
            return evidence;
        }