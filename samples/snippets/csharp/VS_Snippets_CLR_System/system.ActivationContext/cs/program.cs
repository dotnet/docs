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
        [SecurityPermission(SecurityAction.LinkDemand, ControlDomainPolicy=true)]
        public static void Main(string[] args)
        {
            //<Snippet3>
            //<Snippet2>
            ActivationContext ac = AppDomain.CurrentDomain.ActivationContext;
            ApplicationIdentity ai = ac.Identity;
            //</Snippet2>
            Console.WriteLine("Full name = " + ai.FullName);
            Console.WriteLine("Code base = " + ai.CodeBase);
            //</Snippet3>

            Console.Read();
        }
        [SecurityPermission(SecurityAction.LinkDemand, ControlDomainPolicy=true)]
        public void Run()
        {
            Main(new string[] { });
            Console.ReadLine();
        }
    }
}
//</Snippet1>

