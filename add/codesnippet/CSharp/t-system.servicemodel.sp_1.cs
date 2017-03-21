       static EndpointIdentity CreateIdentity()
        {
            WindowsIdentity self = WindowsIdentity.GetCurrent();
            SecurityIdentifier sid = self.User;

            EndpointIdentity identity = null;

            if (sid.IsWellKnown(WellKnownSidType.LocalSystemSid) ||
                sid.IsWellKnown(WellKnownSidType.NetworkServiceSid) ||
                sid.IsWellKnown(WellKnownSidType.LocalServiceSid))
            {
                identity = EndpointIdentity.CreateSpnIdentity(
                    String.Format(CultureInfo.InvariantCulture, "host/{0}", GetMachineName()));
            }
            else
            {
                // Need an UPN string here
                string domain = GetPrimaryDomain();
                if (domain != null)
                {
                    string[] split = self.Name.Split('\\');
                    if (split.Length == 2)
                    {
                        identity = EndpointIdentity.CreateUpnIdentity(split[1] + "@" + domain);
                    }
                }
            }

            return identity;
        }