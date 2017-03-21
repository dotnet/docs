        // When this method runs, the caller must be an authenticated user 
        // and the ServiceSecurityContext is not a null instance. 
        public double Add(double n1, double n2)
        {
            // Write data from the ServiceSecurityContext to a file using the StreamWriter class.
            using (StreamWriter sw = new StreamWriter(@"c:\ServiceSecurityContextInfo.txt"))
            {
                // Write the primary identity and Windows identity. The primary identity is derived from 
                // the credentials used to authenticate the user. The Windows identity may be a null string.
                sw.WriteLine("PrimaryIdentity: {0}", ServiceSecurityContext.Current.PrimaryIdentity.Name);
                sw.WriteLine("WindowsIdentity: {0}", ServiceSecurityContext.Current.WindowsIdentity.Name);

                // Write the claimsets in the authorization context. By default, there is only one claimset
                // provided by the system. 
                foreach (ClaimSet claimset in ServiceSecurityContext.Current.AuthorizationContext.ClaimSets)
                {
                    foreach (Claim claim in claimset)
                    {
                        // Write out each claim type, claim value, and the right. There are two
                        // possible values for the right: "identity" and "possessproperty". 
                        sw.WriteLine("Claim Type: {0}, Resource: {1} Right: {2}",
                            claim.ClaimType,
                            claim.Resource.ToString(),
                            claim.Right);
                        sw.WriteLine();
                    }
                }
            }
            return n1 + n2;
        }