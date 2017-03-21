using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web.Configuration;

namespace Samples.Aspnet.SystemWebConfiguration
{
    // Accesses the System.Web.Configuration.ProfileSection members
    // selected by the user.
    class UsingProfileSection
    {
        public static void Main()
        {
            // Process the System.Web.Configuration.ProfileSectionobject.
            try
            {
                // Get the Web application configuration.
                System.Configuration.Configuration configuration = 
                    System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnet");
                
                // Get the section.
                System.Web.Configuration.ProfileSection profileSection = 
                    (System.Web.Configuration.ProfileSection) 
                    configuration.GetSection("system.web/profile");

// Get the current AutomaticSaveEnabled property value.
Console.WriteLine(
    "Current AutomaticSaveEnabled value: '{0}'", profileSection.AutomaticSaveEnabled);

// Set the AutomaticSaveEnabled property to false.
profileSection.AutomaticSaveEnabled = false;

                

// Get the current DefaultProvider property value.
Console.WriteLine(
    "Current DefaultProvider value: '{0}'", profileSection.DefaultProvider);

// Set the DefaultProvider property to "AspNetSqlProvider".
profileSection.DefaultProvider = "AspNetSqlProvider";

                

// Get the current Inherits property value.
Console.WriteLine(
    "Current Inherits value: '{0}'", profileSection.Inherits);

// Set the Inherits property to
// "CustomProfiles.MyCustomProfile, CustomProfiles.dll".
profileSection.Inherits = "CustomProfiles.MyCustomProfile, CustomProfiles.dll";

                

// Display all current root ProfilePropertySettings.
Console.WriteLine("Current Root ProfilePropertySettings:");
int rootPPSCtr = 0;
foreach (ProfilePropertySettings rootPPS in profileSection.PropertySettings)
{
    Console.WriteLine("  {0}: ProfilePropertySetting '{1}'", ++rootPPSCtr,
        rootPPS.Name);
}

// Get and modify a root ProfilePropertySettings object.
Console.WriteLine(
    "Display and modify 'LastReadDate' ProfilePropertySettings:");
ProfilePropertySettings profilePropertySettings =
    profileSection.PropertySettings["LastReadDate"];

// Get the current ReadOnly property value.
Console.WriteLine(
    "Current ReadOnly value: '{0}'", profilePropertySettings.ReadOnly);

// Set the ReadOnly property to true.
profilePropertySettings.ReadOnly = true;

// Get the current AllowAnonymous property value.
Console.WriteLine(
    "Current AllowAnonymous value: '{0}'", profilePropertySettings.AllowAnonymous);

// Set the AllowAnonymous property to true.
profilePropertySettings.AllowAnonymous = true;

// Get the current SerializeAs property value.
Console.WriteLine(
    "Current SerializeAs value: '{0}'", profilePropertySettings.SerializeAs);

// Set the SerializeAs property to SerializationMode.Binary.
profilePropertySettings.SerializeAs = SerializationMode.Binary;

// Get the current Type property value.
Console.WriteLine(
    "Current Type value: '{0}'", profilePropertySettings.Type);

// Set the Type property to "System.DateTime".
profilePropertySettings.Type = "System.DateTime";

// Get the current DefaultValue property value.
Console.WriteLine(
    "Current DefaultValue value: '{0}'", profilePropertySettings.DefaultValue);

// Set the DefaultValue property to "March 16, 2004".
profilePropertySettings.DefaultValue = "March 16, 2004";

// Get the current ProviderName property value.
Console.WriteLine(
    "Current ProviderName value: '{0}'", profilePropertySettings.Provider);

// Set the ProviderName property to "AspNetSqlRoleProvider".
profilePropertySettings.Provider = "AspNetSqlRoleProvider";

// Get the current Name property value.
Console.WriteLine(
    "Current Name value: '{0}'", profilePropertySettings.Name);

// Set the Name property to "LastAccessDate".
profilePropertySettings.Name = "LastAccessDate";

// Display all current ProfileGroupSettings.
Console.WriteLine("Current ProfileGroupSettings:");
int PGSCtr = 0;
foreach (ProfileGroupSettings propGroups in profileSection.PropertySettings.GroupSettings)
{
    Console.WriteLine("  {0}: ProfileGroupSetting '{1}'", ++PGSCtr,
        propGroups.Name);
    int PPSCtr = 0;
    foreach (ProfilePropertySettings props in propGroups.PropertySettings)
    {
        Console.WriteLine("    {0}: ProfilePropertySetting '{1}'", ++PPSCtr,
            props.Name);
    }
}

// Add a new group.
ProfileGroupSettings newPropGroup = new ProfileGroupSettings("Forum");
profileSection.PropertySettings.GroupSettings.Add(newPropGroup);

// Add a new PropertySettings to the group.
ProfilePropertySettings newProp = new ProfilePropertySettings("AvatarImage");
newProp.Type = "System.String, System.dll";
newPropGroup.PropertySettings.Add(newProp);

// Remove a PropertySettings from the group.
newPropGroup.PropertySettings.Remove("AvatarImage");
newPropGroup.PropertySettings.RemoveAt(0);

// Clear all PropertySettings from the group.
newPropGroup.PropertySettings.Clear();

                

// Display all current Providers.
Console.WriteLine("Current Providers:");
int providerCtr = 0;
foreach (ProviderSettings provider in profileSection.Providers)
{
    Console.WriteLine("  {0}: Provider '{1}' of type '{2}'", ++providerCtr, 
        provider.Name, provider.Type);
}

// Add a new provider.
profileSection.Providers.Add(new ProviderSettings("AspNetSqlProvider", "...SqlProfileProvider"));

                

// Get the current Enabled property value.
Console.WriteLine(
    "Current Enabled value: '{0}'", profileSection.Enabled);

// Set the Enabled property to false.
profileSection.Enabled = false;

                
                // Update if not locked.
                if (! profileSection.SectionInformation.IsLocked)
                {
                    configuration.Save();
                    Console.WriteLine("** Configuration updated.");
                }
                else
                    Console.WriteLine("** Could not update, section is locked.");
            }
            catch (System.ArgumentException e)
            {
                // Unknown error.
                Console.WriteLine(
                    "A invalid argument exception detected in UsingProfileSection Main. Check your");
                Console.WriteLine("command line for errors.");
            }
        }
    } // UsingProfileSection class end.
    
} // Samples.Aspnet.SystemWebConfiguration namespace end.
