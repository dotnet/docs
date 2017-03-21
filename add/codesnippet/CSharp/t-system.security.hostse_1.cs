// To replace the default security manager with MySecurityManager, add the 
// assembly to the GAC and call MySecurityManager in the
// custom implementation of the AppDomainManager.

using System;
using System.Collections;
using System.Net;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Security.Principal;
using System.Threading;
using System.Runtime.InteropServices;
using System.Runtime.Hosting;

[assembly: System.Security.AllowPartiallyTrustedCallersAttribute()]
namespace MyNamespace
{
    [Serializable()]
    [SecurityPermissionAttribute(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
    public class MySecurityManager : HostSecurityManager
    {
        public MySecurityManager()
        {
            Console.WriteLine(" Creating MySecurityManager.");
        }

        private HostSecurityManagerOptions hostFlags = HostSecurityManagerOptions.HostDetermineApplicationTrust |
                                                   HostSecurityManagerOptions.HostAssemblyEvidence;
        public override HostSecurityManagerOptions Flags
        {
            get
            {
                return hostFlags;
            }
        }

        public override Evidence ProvideAssemblyEvidence(Assembly loadedAssembly, Evidence evidence)
        {
            Console.WriteLine("Provide assembly evidence for: " + (loadedAssembly == null ? "Unknown" : loadedAssembly.ToString()) + ".");
            if (evidence == null)
                return null;

            evidence.AddAssemblyEvidence(new CustomEvidenceType());
            return evidence;
        }
        public override Evidence ProvideAppDomainEvidence(Evidence evidence)
        {
            Console.WriteLine("Provide evidence for the " + AppDomain.CurrentDomain.FriendlyName + " AppDomain.");
            if (evidence == null)
                return null;

            evidence.AddHostEvidence(new CustomEvidenceType());
            return evidence;
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, Execution = true)]
        [SecurityPermissionAttribute(SecurityAction.Assert, Unrestricted = true)]
        public override ApplicationTrust DetermineApplicationTrust(Evidence applicationEvidence, Evidence activatorEvidence, TrustManagerContext context)
        {
            if (applicationEvidence == null)
                throw new ArgumentNullException("applicationEvidence");

            // Get the activation context from the application evidence.
            // This HostSecurityManager does not examine the activator evidence
            // nor is it concerned with the TrustManagerContext;
            // it simply grants the requested grant in the application manifest.

            IEnumerator enumerator = applicationEvidence.GetHostEnumerator();
            ActivationArguments activationArgs = null;
            while (enumerator.MoveNext())
            {
                activationArgs = enumerator.Current as ActivationArguments;
                if (activationArgs != null)
                    break;
            }

            if (activationArgs == null)
                return null;

            ActivationContext activationContext = activationArgs.ActivationContext;
            if (activationContext == null)
                return null;

            ApplicationTrust trust = new ApplicationTrust(activationContext.Identity);
            ApplicationSecurityInfo asi = new ApplicationSecurityInfo(activationContext);
            trust.DefaultGrantSet = new PolicyStatement(asi.DefaultRequestSet, PolicyStatementAttribute.Nothing);
            trust.IsApplicationTrustedToRun = true;
            return trust;
        }

    }
    [Serializable()]
    public class CustomEvidenceType : EvidenceBase
    {
        public CustomEvidenceType() { }

        public override string ToString()
        {
            return "CustomEvidenceType";
        }
    }
}