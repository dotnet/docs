// <Snippet3>
using System;
using System.Configuration;
using System.Globalization;
using System.Xml;

public class Example
{
   private const String SettingName = "AppContextSwitchOverrides";
   private const String SwitchName = "Switch.Application.Utilities.SwitchName"; 
   
   public static void Main()
   {
      bool flag = false;
      
      // Determine whether the caller has used the AppContext class directly.
      if (! AppContext.TryGetSwitch(SwitchName, out flag)) {
         // If switch is not defined directly, attempt to retrieve it from a configuration file.
         try {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config == null) return;
            
            ConfigurationSection sec = config.GetSection("runtime");
            if (sec != null) { 
               String rawXml = sec.SectionInformation.GetRawXml();
               if (String.IsNullOrEmpty(rawXml)) return;
               
               var doc = new XmlDocument();
               doc.LoadXml(rawXml);
               XmlNode root = doc.FirstChild;
               // Navigate the children.
               if (root.HasChildNodes) {
                  foreach (XmlNode node in root.ChildNodes) {
                     if (node.Name.Equals(SettingName, StringComparison.Ordinal)) {
                        // Get attribute value
                        XmlAttribute attr = node.Attributes["value"];
                        String[] nameValuePair = attr.Value.Split('=');
                        // Determine whether the switch we want is present.
                        if (SwitchName.Equals(nameValuePair[0], StringComparison.Ordinal)) {  
                           bool tempFlag = false;
                           if (Boolean.TryParse(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(nameValuePair[1]),
                                                out tempFlag))
                              AppContext.SetSwitch(nameValuePair[0], tempFlag);                 
                        }
                     }
                  } 
               }
            }   
         }
         catch (ConfigurationErrorsException)
         {}
      }
   }
}
// </Snippet3>
