        // Run this method from within a method protected by the PrincipalPermissionAttribute
        // to see the security context data, including the primary identity.
        public void WriteServiceSecurityContextData(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                // Write the primary identity and Windows identity. The primary identity is derived from the
                // the credentials used to authenticate the user. The Windows identity may be a null string.
                sw.WriteLine("PrimaryIdentity: {0}", ServiceSecurityContext.Current.PrimaryIdentity.Name);
                sw.WriteLine("WindowsIdentity: {0}", ServiceSecurityContext.Current.WindowsIdentity.Name);
                sw.WriteLine();
                // Write the claimsets in the authorization context. By default, there is only one claimset
                // provided by the system. 
                foreach (ClaimSet claimset in ServiceSecurityContext.Current.AuthorizationContext.ClaimSets)
                {
                    foreach (Claim claim in claimset)
                    {
                        // Write out each claim type, claim value, and the right. There are two
                        // possible values for the right: "identity" and "possessproperty". 
                        sw.WriteLine("Claim Type = {0}", claim.ClaimType);
                        sw.WriteLine("\t Resource = {0}", claim.Resource.ToString());
                        sw.WriteLine("\t Right = {0}", claim.Right);
                    }
                }
            }
        }
