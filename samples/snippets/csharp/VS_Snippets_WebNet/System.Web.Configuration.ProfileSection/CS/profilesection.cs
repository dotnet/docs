// <Snippet3>
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
// <Snippet4>

// Get the current AutomaticSaveEnabled property value.
Console.WriteLine(
    "Current AutomaticSaveEnabled value: '{0}'", profileSection.AutomaticSaveEnabled);

// Set the AutomaticSaveEnabled property to false.
profileSection.AutomaticSaveEnabled = false;

// </Snippet4>
                
// <Snippet5>

// Get the current DefaultProvider property value.
Console.WriteLine(
    "Current DefaultProvider value: '{0}'", profileSection.DefaultProvider);

// Set the DefaultProvider property to "AspNetSqlProvider".
profileSection.DefaultProvider = "AspNetSqlProvider";

// </Snippet5>
                
// <Snippet6>

// Get the current Inherits property value.
Console.WriteLine(
    "Current Inherits value: '{0}'", profileSection.Inherits);

// Set the Inherits property to
// "CustomProfiles.MyCustomProfile, CustomProfiles.dll".
profileSection.Inherits = "CustomProfiles.MyCustomProfile, CustomProfiles.dll";

// </Snippet6>
                
// <Snippet7>

// <Snippet10>
// Display all current root ProfilePropertySettings.
Console.WriteLine("Current Root ProfilePropertySettings:");
int rootPPSCtr = 0;
foreach (ProfilePropertySettings rootPPS in profileSection.PropertySettings)
{
    Console.WriteLine("  {0}: ProfilePropertySetting '{1}'", ++rootPPSCtr,
        rootPPS.Name);
}
// </Snippet10>

// <Snippet11>
// <Snippet14>
// Get and modify a root ProfilePropertySettings object.
Console.WriteLine(
    "Display and modify 'LastReadDate' ProfilePropertySettings:");
ProfilePropertySettings profilePropertySettings =
    profileSection.PropertySettings["LastReadDate"];
// </Snippet14>

// <Snippet15>
// Get the current ReadOnly property value.
Console.WriteLine(
    "Current ReadOnly value: '{0}'", profilePropertySettings.ReadOnly);

// Set the ReadOnly property to true.
profilePropertySettings.ReadOnly = true;
// </Snippet15>

// <Snippet16>
// Get the current AllowAnonymous property value.
Console.WriteLine(
    "Current AllowAnonymous value: '{0}'", profilePropertySettings.AllowAnonymous);

// Set the AllowAnonymous property to true.
profilePropertySettings.AllowAnonymous = true;
// </Snippet16>

// <Snippet17>
// Get the current SerializeAs property value.
Console.WriteLine(
    "Current SerializeAs value: '{0}'", profilePropertySettings.SerializeAs);

// Set the SerializeAs property to SerializationMode.Binary.
profilePropertySettings.SerializeAs = SerializationMode.Binary;
// </Snippet17>

// <Snippet18>
// Get the current Type property value.
Console.WriteLine(
    "Current Type value: '{0}'", profilePropertySettings.Type);

// Set the Type property to "System.DateTime".
profilePropertySettings.Type = "System.DateTime";
// </Snippet18>

// <Snippet19>
// Get the current DefaultValue property value.
Console.WriteLine(
    "Current DefaultValue value: '{0}'", profilePropertySettings.DefaultValue);

// Set the DefaultValue property to "March 16, 2004".
profilePropertySettings.DefaultValue = "March 16, 2004";
// </Snippet19>

// <Snippet20>
// Get the current ProviderName property value.
Console.WriteLine(
    "Current ProviderName value: '{0}'", profilePropertySettings.Provider);

// Set the ProviderName property to "AspNetSqlRoleProvider".
profilePropertySettings.Provider = "AspNetSqlRoleProvider";
// </Snippet20>

// <Snippet21>
// Get the current Name property value.
Console.WriteLine(
    "Current Name value: '{0}'", profilePropertySettings.Name);

// Set the Name property to "LastAccessDate".
profilePropertySettings.Name = "LastAccessDate";
// </Snippet21>
// </Snippet11>

// <Snippet12>
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
// </Snippet12>

// <Snippet13>
// Add a new group.
ProfileGroupSettings newPropGroup = new ProfileGroupSettings("Forum");
profileSection.PropertySettings.GroupSettings.Add(newPropGroup);

// <Snippet22>
// Add a new PropertySettings to the group.
ProfilePropertySettings newProp = new ProfilePropertySettings("AvatarImage");
newProp.Type = "System.String, System.dll";
newPropGroup.PropertySettings.Add(newProp);
// </Snippet22>

// <Snippet1>
// Remove a PropertySettings from the group.
newPropGroup.PropertySettings.Remove("AvatarImage");
newPropGroup.PropertySettings.RemoveAt(0);
// </Snippet1>

// <Snippet2>
// Clear all PropertySettings from the group.
newPropGroup.PropertySettings.Clear();
// </Snippet2>
// </Snippet13>

// </Snippet7>
                
// <Snippet8>

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

// </Snippet8>
                
// <Snippet9>

// Get the current Enabled property value.
Console.WriteLine(
    "Current Enabled value: '{0}'", profileSection.Enabled);

// Set the Enabled property to false.
profileSection.Enabled = false;

// </Snippet9>
                
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

// </Snippet3>
