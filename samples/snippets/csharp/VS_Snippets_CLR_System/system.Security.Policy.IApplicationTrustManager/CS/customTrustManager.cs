//<Snippet1>
// To use the custom trust manager MyTrustManager, compile it into CustomTrustManager.dll, 
// place that assembly in the GAC, and  put the following elements in
// an ApplicationTrust.config file in the config folder in the Microsoft .NET framework
// installation folder.

//<?xml version="1.0" encoding="utf-8" ?>
//<configuration>
//    <mscorlib>
//        <security>
//            <policy>
//                <ApplicationSecurityManager>
//                    <ApplicationEntries />
//                    <IApplicationTrustManager class="MyNamespace.MyTrustManager, CustomTrustManager, Version=1.0.0.3, Culture=neutral, PublicKeyToken=5659fc598c2a503e"/>
//                </ApplicationSecurityManager>
//            </policy>
//        </security>
//    </mscorlib>
//</configuration>

using System;
using System.Security;
using System.Security.Policy;
using System.Windows.Forms;
namespace MyNamespace
{
	public class MyTrustManager : IApplicationTrustManager
	{
        //<Snippet2>
		public ApplicationTrust DetermineApplicationTrust(ActivationContext appContext, TrustManagerContext context)
		{
			ApplicationTrust trust = new ApplicationTrust(appContext.Identity);
			trust.IsApplicationTrustedToRun = false;

			ApplicationSecurityInfo asi = new ApplicationSecurityInfo(appContext);
			trust.DefaultGrantSet = new PolicyStatement(asi.DefaultRequestSet, PolicyStatementAttribute.Nothing);
			if (context.UIContext == TrustManagerUIContext.Run)
			{
				string message = "Do you want to run " + asi.ApplicationId.Name + " ?";
				string caption = "MyTrustManager";
				MessageBoxButtons buttons = MessageBoxButtons.YesNo;
				DialogResult result;

				// Displays the MessageBox.

				result = MessageBox.Show(message, caption, buttons);

				if (result == DialogResult.Yes)
				{
					trust.IsApplicationTrustedToRun = true;
					if (context != null)
						trust.Persist = context.Persist;
					else
						trust.Persist = false;
				}
			}

			return trust;
		}
        //</Snippet2>

        //<Snippet3>
		public SecurityElement ToXml()
		{
			SecurityElement se = new SecurityElement("IApplicationTrustManager");
			se.AddAttribute("class", typeof(MyTrustManager).AssemblyQualifiedName);
			return se;
		}
        //</Snippet3>

        //<Snippet4>
		public void FromXml(SecurityElement se)
		{
			if (se.Tag != "IApplicationTrustManager" || (string)se.Attributes["class"] != typeof(MyTrustManager).AssemblyQualifiedName)
				throw new ArgumentException("Invalid tag");
		}
        //</Snippet4>
	}
}
//</Snippet1>