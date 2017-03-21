        static EndpointIdentity CreateSpnIdentity()
        {
            WindowsIdentity self = WindowsIdentity.GetCurrent();
            SecurityIdentifier sid = self.User;

            SpnEndpointIdentity identity = null;

            identity = new SpnEndpointIdentity(String.Format(CultureInfo.InvariantCulture, "host/{0}", GetMachineName()));

            return identity;
        }
        static string GetMachineName()
        {
            return Dns.GetHostEntry(string.Empty).HostName;
        }