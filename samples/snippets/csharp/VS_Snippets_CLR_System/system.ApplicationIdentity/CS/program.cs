//<Snippet1>
using System;
using System.Collections;
using System.Text;
using System.Security.Policy;
using System.Reflection;
using System.Security;
using System.Security.Permissions;

namespace ActivationContextSample
{
    public class Program : MarshalByRefObject
    {
        [SecurityPermission(SecurityAction.Demand, ControlDomainPolicy = true)]
        public static void Main(string[] args)
        {
            //<Snippet2>
            Console.WriteLine("Full name = " +
                AppDomain.CurrentDomain.ActivationContext.Identity.FullName);
            //</Snippet2>
            //<Snippet3>
            Console.WriteLine("Code base = " +
                AppDomain.CurrentDomain.ActivationContext.Identity.CodeBase);
            //</Snippet3>
            //<Snippet6>
            //<Snippet7>
            ApplicationSecurityInfo asi = new ApplicationSecurityInfo(AppDomain.CurrentDomain.ActivationContext);

            Console.WriteLine("ApplicationId.Name property = " + asi.ApplicationId.Name);
            //</Snippet7>
            //<Snippet8>
            if (asi.ApplicationId.Culture != null)
                Console.WriteLine("ApplicationId.Culture property = " + asi.ApplicationId.Culture.ToString());
            //</Snippet8>
            //<Snippet9>
            Console.WriteLine("ApplicationId.ProcessorArchitecture property = " + asi.ApplicationId.ProcessorArchitecture);
            //</Snippet9>
            //<Snippet10>
            Console.WriteLine("ApplicationId.Version property = " + asi.ApplicationId.Version);
            //</Snippet10>
            //<Snippet11>
            // To display the value of the public key, enumerate the Byte array for the property.
            Console.Write("ApplicationId.PublicKeyToken property = ");
            byte[] pk = asi.ApplicationId.PublicKeyToken;
            for (int i = 0; i < pk.GetLength(0); i++)
                Console.Write("{0:x}", pk[i]);
            //</Snippet11>
            //</Snippet6>

            Console.Read();
        }

        public void Run()
        {
            Main(new string[] { });
            Console.ReadLine();
        }
    }
}
//</Snippet1>