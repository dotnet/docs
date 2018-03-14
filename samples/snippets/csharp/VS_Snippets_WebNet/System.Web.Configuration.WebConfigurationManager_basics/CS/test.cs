using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Configuration;
using System.Configuration;

namespace ConfigPlay
{
	class Test
	{
		static void Main(string[] args)
		{
			//<snippet1>
			// Obtains the machine configuration settings on the local machine.
			System.Configuration.Configuration machineConfig = 
				System.Web.Configuration.WebConfigurationManager.OpenMachineConfiguration();
			machineConfig.SaveAs("c:\\machineConfig.xml");
			//</snippet1>


			//<snippet2>
			// Obtains the configuration settings for a Web application.
			System.Configuration.Configuration webConfig =
				System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Temp");
			webConfig.SaveAs("c:\\webConfig.xml");
			//</snippet2>


			//<snippet3>
			// Obtains the configuration settings for the <anonymousIdentification> section.
			System.Configuration.Configuration config =
				System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Temp");
			System.Web.Configuration.SystemWebSectionGroup systemWeb =
				config.GetSectionGroup("system.web") 
				as System.Web.Configuration.SystemWebSectionGroup;
			System.Web.Configuration.AnonymousIdentificationSection sectionConfig =
				systemWeb.AnonymousIdentification;
			if (sectionConfig != null)
			{
				StringBuilder sb = new StringBuilder();
				sb.Append("<anonymousIdentification> attributes:\r\n");
				System.Configuration.PropertyInformationCollection props =
					sectionConfig.ElementInformation.Properties;
				foreach (System.Configuration.PropertyInformation prop in props)
				{
					sb.AppendFormat("{0} = {1}\r\n", prop.Name.ToString(), prop.Value.ToString());
				}
				Console.WriteLine(sb.ToString());
			}
			//</snippet3>


			//<snippet4>
			IntPtr userToken = System.Security.Principal.WindowsIdentity.GetCurrent().Token;

			// Obtains the machine configuration settings on a remote machine.
			System.Configuration.Configuration remoteMachineConfig =
				System.Web.Configuration.WebConfigurationManager.OpenMachineConfiguration
				(null, "ServerName", userToken);
			remoteMachineConfig.SaveAs("c:\\remoteMachineConfig.xml");

			// Obtains the root Web configuration settings on a remote machine.
			System.Configuration.Configuration remoteRootConfig =
				System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration
				(null, null, null, "ServerName", userToken);
			remoteRootConfig.SaveAs("c:\\remoteRootConfig.xml");

			// Obtains the configuration settings for the 
			// W3SVC/1/Root/Temp application on a remote machine.
			System.Configuration.Configuration remoteWebConfig =
				System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration
				("/Temp", "1", null, "ServerName", userToken);
			remoteWebConfig.SaveAs("c:\\remoteWebConfig.xml");
			//</snippet4>


			//<snippet5>
			// Updates the configuration settings for a Web application.
			System.Configuration.Configuration updateWebConfig =
				System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Temp");
			System.Web.Configuration.CompilationSection compilation =
				updateWebConfig.GetSection("system.web/compilation") 
				as System.Web.Configuration.CompilationSection;
			Console.WriteLine("Current <compilation> debug = {0}", compilation.Debug);
			compilation.Debug = true;
			if (!compilation.SectionInformation.IsLocked)
			{
				updateWebConfig.Save();
				Console.WriteLine("New <compilation> debug = {0}", compilation.Debug);
			}
			else
			{
				Console.WriteLine("Could not save configuration.");
			}
			//</snippet5>


			//<snippet6>
			System.Configuration.Configuration rootWebConfig =
				System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
			System.Configuration.ConnectionStringSettings connString;
			if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
			{
				connString =
					rootWebConfig.ConnectionStrings.ConnectionStrings["NorthwindConnectionString"];
				if (connString != null)
					Console.WriteLine("Northwind connection string = \"{0}\"",
						connString.ConnectionString);
				else
					Console.WriteLine("No Northwind connection string");
			}
			//</snippet6>


			//<snippet7>
			System.Configuration.Configuration rootWebConfig1 =
				System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);
			if (rootWebConfig1.AppSettings.Settings.Count > 0)
			{
				System.Configuration.KeyValueConfigurationElement customSetting = 
					rootWebConfig1.AppSettings.Settings["customsetting1"];
				if (customSetting != null)
					Console.WriteLine("customsetting1 application string = \"{0}\"", 
						customSetting.Value);
				else
					Console.WriteLine("No customsetting1 application string");
			}
			//</snippet7>

		}
	}
}
