        private HostSecurityManagerOptions hostFlags = HostSecurityManagerOptions.HostDetermineApplicationTrust |
                                                   HostSecurityManagerOptions.HostAssemblyEvidence;
        public override HostSecurityManagerOptions Flags
        {
            get
            {
                return hostFlags;
            }
        }