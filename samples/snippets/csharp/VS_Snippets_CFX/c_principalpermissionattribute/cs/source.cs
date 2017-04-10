//<snippet0>
using System.Security.Permissions;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.IO;
using System.IdentityModel.Claims;
//</snippet0>



namespace Samples
{

    public class Calculator
    {
        //<snippet1>
        // Only members of the CalculatorClients group can call this method.
        [PrincipalPermission(SecurityAction.Demand, Role = "CalculatorClients")]
        public double Add(double a, double b)
        {
            return a + b;
        }
        //</snippet1>


        //<snippet2>
        // Only a client authenticated with a valid certificate that has the 
        // specified subject name and thumbprint can call this method.
        [PrincipalPermission(SecurityAction.Demand,
            Name = "CN=ReplaceWithSubjectName; 123456712345677E8E230FDE624F841B1CE9D41E")]
        public double Multiply(double a, double b)
        {
            return a * b;
        }
        //</snippet2>

        //<snippet4>
        // Run this method from within a method protected by the PrincipalPermissionAttribute
        // to see the security context data, including the primary identity.
        public void WriteServiceSecurityContextData(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                // Write the primary identity and Windows identity. The primary identity is derived from
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

        //</snippet4>
    }

    public class Test
    {
        public static void Main()
        {
            Uri baseUri = new Uri("http://ServiceModelSamples");

            //<snippet3>
            ServiceHost myServiceHost = new ServiceHost(typeof(Calculator), baseUri);
            ServiceAuthorizationBehavior myServiceBehavior =
                myServiceHost.Description.Behaviors.Find<ServiceAuthorizationBehavior>();
            myServiceBehavior.PrincipalPermissionMode =
                PrincipalPermissionMode.UseAspNetRoles;
            //</snippet3>
        }
    }
}
