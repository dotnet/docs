// <Snippet1>
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
    // Accesses the
    // System.Web.Configuration.HealthMonitoringSection members
    // selected by the user.
    class UsingHealthMonitoringSection
    {
        public static void Main()
        {
            // Process the
            // System.Web.Configuration.HealthMonitoringSectionobject.
            try
            {
                // Get the Web application configuration.
                System.Configuration.Configuration configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnet");
                
                // Get the section.
                System.Web.Configuration.HealthMonitoringSection healthMonitoringSection = (System.Web.Configuration.HealthMonitoringSection) configuration.GetSection("system.web/healthmonitoring");
// <Snippet2>

// Get the current Enabled property value.
Boolean enabledValue = healthMonitoringSection.Enabled;

// Set the Enabled property to false.
healthMonitoringSection.Enabled = false;

// </Snippet2>
                
// <Snippet3>

// Get the current HeartBeatInterval property value.
TimeSpan heartBeatIntervalValue = healthMonitoringSection.HeartbeatInterval;

// Set the HeartBeatInterval property to
// TimeSpan.Parse("00:10:00").
healthMonitoringSection.HeartbeatInterval = TimeSpan.Parse("00:10:00");

// </Snippet3>
                
// <Snippet4>

// <Snippet9>
// Add a BufferModeSettings object to the BufferModes collection property.
BufferModeSettings bufferModeSetting = new BufferModeSettings("Error Log", 
    1024, 256, 512, new TimeSpan(0, 30, 0), new TimeSpan(0, 5, 0), 2);
// <Snippet15>
bufferModeSetting.Name = "Operations Notification";
// </Snippet15>
// <Snippet16>
bufferModeSetting.MaxBufferSize = 128;
// </Snippet16>
// <Snippet17>
bufferModeSetting.MaxBufferThreads = 1;
// </Snippet17>
// <Snippet18>
bufferModeSetting.MaxFlushSize = 24;
// </Snippet18>
// <Snippet19>
bufferModeSetting.RegularFlushInterval = TimeSpan.MaxValue;
// </Snippet19>
// <Snippet20>
bufferModeSetting.UrgentFlushInterval = TimeSpan.Parse("00:01:00");
// </Snippet20>
// <Snippet21>
bufferModeSetting.UrgentFlushThreshold = 1;
// </Snippet21>
healthMonitoringSection.BufferModes.Add(bufferModeSetting);
// </Snippet9>

// <Snippet10>
// Add a BufferModeSettings object to the BufferModes collection property.
healthMonitoringSection.BufferModes.Add(new BufferModeSettings("Error Log", 
    1024, 256, 512, new TimeSpan(0, 30, 0), new TimeSpan(0, 5, 0), 2));
// </Snippet10>

// <Snippet11>
// Display contents of the BufferModes collection property
Console.WriteLine("BufferModes Collection contains {0} values:", 
    healthMonitoringSection.BufferModes.Count);

// Display all elements.
for (System.Int32 i = 0; i < healthMonitoringSection.BufferModes.Count; i++)
{
// <Snippet22>
bufferModeSetting = healthMonitoringSection.BufferModes[i];
// </Snippet22>
// <Snippet23>
string name = bufferModeSetting.Name;
// </Snippet23>
// <Snippet24>
int maxBufferSize = bufferModeSetting.MaxBufferSize;
// </Snippet24>
// <Snippet25>
int maxBufferThreads = bufferModeSetting.MaxBufferThreads;
// </Snippet25>
// <Snippet26>
int maxFlushSize = bufferModeSetting.MaxFlushSize;
// </Snippet26>
// <Snippet27>
TimeSpan regularFlushInterval = bufferModeSetting.RegularFlushInterval;
// </Snippet27>
// <Snippet28>
TimeSpan urgentFlushInterval = bufferModeSetting.UrgentFlushInterval;
// </Snippet28>
// <Snippet29>
int urgentFlushThreshold = bufferModeSetting.UrgentFlushThreshold;
// </Snippet29>
    string item = "Name='" + name + "', MaxBufferSize =  '" + maxBufferSize + 
        "', MaxBufferThreads =  '" + maxBufferThreads +
        "', MaxFlushSize =  '" + maxFlushSize + 
        "', RegularFlushInterval =  '" + regularFlushInterval +
        "', UrgentFlushInterval =  '" + urgentFlushInterval + 
        "', UrgentFlushThreshold =  '" + urgentFlushThreshold + "'";
    Console.WriteLine("  Item {0}: {1}", i, item);
}
// </Snippet11>

// <Snippet12>
// Get a named BufferMode
bufferModeSetting = healthMonitoringSection.BufferModes["Error Log"];
// </Snippet12>

// <Snippet13>
// Remove a BufferModeSettings object from the BufferModes collection property.
healthMonitoringSection.BufferModes.Remove("Error Log");
// </Snippet13>

// <Snippet14>
// Clear all BufferModeSettings object from the BufferModes collection property.
healthMonitoringSection.BufferModes.Clear();
// </Snippet14>

// </Snippet4>
                
// <Snippet5>

// <Snippet30>
// Add a EventMappingsSettings object to the EventMappings collection property.
EventMappingSettings eventMappingSetting = new EventMappingSettings(
    "Failure Audits", "System.Web.Management.WebAuditEvent, System.Web");
// <Snippet41>
eventMappingSetting.Name = "All Errors";
// </Snippet41>
// <Snippet42>
eventMappingSetting.Type = 
    "System.Web.Management.WebErrorEvent, System.Web";
// </Snippet42>
// <Snippet43>
eventMappingSetting.StartEventCode = 0;
// </Snippet43>
// <Snippet44>
eventMappingSetting.EndEventCode = 4096;
// </Snippet44>
healthMonitoringSection.EventMappings.Add(eventMappingSetting);
// </Snippet30>

// <Snippet31>
// Add an EventMappingsSettings object to the EventMappings collection property.
healthMonitoringSection.EventMappings.Add(new EventMappingSettings(
    "Failure Audits", "System.Web.Management.WebAuditEvent, System.Web"));
// </Snippet31>

// <Snippet32>
// Add an EventMappingsSettings object to the EventMappings collection property.
healthMonitoringSection.EventMappings.Add(new EventMappingSettings(
    "Success Audits", "System.Web.Management.WebAuditEvent, System.Web",
    512, Int32.MaxValue));
// </Snippet32>

// <Snippet33>
// Insert an EventMappingsSettings object into the EventMappings collection property.
healthMonitoringSection.EventMappings.Insert(1, 
    new EventMappingSettings("HeartBeats", "", 1, 2));
// </Snippet33>

// <Snippet34>
// Display contents of the EventMappings collection property
Console.WriteLine(
    "EventMappings Collection contains {0} values:", healthMonitoringSection.EventMappings.Count);

// Display all elements.
for (System.Int32 i = 0; i < healthMonitoringSection.EventMappings.Count; i++)
{
// <Snippet45>
eventMappingSetting = healthMonitoringSection.EventMappings[i];
// </Snippet45>
// <Snippet46>
string name = eventMappingSetting.Name;
// </Snippet46>
// <Snippet47>
string type = eventMappingSetting.Type;
// </Snippet47>
// <Snippet48>
int startCd = eventMappingSetting.StartEventCode;
// </Snippet48>
// <Snippet49>
int endCd = eventMappingSetting.EndEventCode;
// </Snippet49>
    string item = "Name='" + name + "', Type='" + type +
        "', StartEventCode =  '" + startCd.ToString() +
        "', EndEventCode =  '" + endCd.ToString() + "'";
    Console.WriteLine("  Item {0}: {1}", i, item);
}
// </Snippet34>

// <Snippet35>
// See if the EventMappings collection property contains the event 'HeartBeats'.
Console.WriteLine("EventMappings contains 'HeartBeats': {0}.",
    healthMonitoringSection.EventMappings.Contains("HeartBeats"));
// </Snippet35>

// <Snippet36>
// Get the index of the 'HeartBeats' event in the EventMappings collection property.
Console.WriteLine("EventMappings index for 'HeartBeats': {0}.",
    healthMonitoringSection.EventMappings.IndexOf("HeartBeats"));
// </Snippet36>

// <Snippet37>
// Get a named EventMappings
eventMappingSetting = healthMonitoringSection.EventMappings["HeartBeats"];
// </Snippet37>

// <Snippet38>
// Remove an EventMappingsSettings object from the EventMappings collection property.
healthMonitoringSection.EventMappings.Remove("HeartBeats");
// </Snippet38>

// <Snippet39>
// Remove an EventMappingsSettings object from the EventMappings collection property.
healthMonitoringSection.EventMappings.RemoveAt(0);
// </Snippet39>

// <Snippet40>
// Clear all EventMappingsSettings object from the EventMappings collection property.
healthMonitoringSection.EventMappings.Clear();
// </Snippet40>

// </Snippet5>
                
// <Snippet6>

// <Snippet50>
// Add a ProfileSettings object to the Profiles collection property.
ProfileSettings profileSetting = new ProfileSettings("Default");
// <Snippet62>
profileSetting.Name = "Custom";
// </Snippet62>
// <Snippet63>
profileSetting.MaxLimit = Int32.MaxValue;
// </Snippet63>
// <Snippet64>
profileSetting.MinInstances = 1;
// </Snippet64>
// <Snippet65>
profileSetting.MinInterval = TimeSpan.Parse("00:01:00");
// </Snippet65>
// <Snippet66>
profileSetting.Custom = "MyEvaluators.MyCustomeEvaluator, MyCustom.dll";
// </Snippet66>
healthMonitoringSection.Profiles.Add(profileSetting);
// </Snippet50>

// <Snippet51>
// Add a ProfileSettings object to the Profiles collection property.
healthMonitoringSection.Profiles.Add(new ProfileSettings("Default"));
// </Snippet51>

// <Snippet52>
// Add a ProfileSettings object to the Profiles collection property.
healthMonitoringSection.Profiles.Add(new ProfileSettings("Critical", 
    1, 1024, new TimeSpan(0, 0, 00)));
// </Snippet52>

// <Snippet53>
// Add a ProfileSettings object to the Profiles collection property.
healthMonitoringSection.Profiles.Add(new ProfileSettings("Targeted", 
    1, Int32.MaxValue, new TimeSpan(0, 0, 10), 
    "MyEvaluators.MyTargetedEvaluator, MyCustom.dll"));
// </Snippet53>

// <Snippet54>
// Insert an ProfileSettings object into the Profiles collection property.
healthMonitoringSection.Profiles.Insert(1, new ProfileSettings("Default2"));
// </Snippet54>

// <Snippet55>
// Display contents of the Profiles collection property
Console.WriteLine(
    "Profiles Collection contains {0} values:", 
    healthMonitoringSection.Profiles.Count);

// Display all elements.
for (System.Int32 i = 0; i < healthMonitoringSection.Profiles.Count; i++)
{
// <Snippet67>
profileSetting = healthMonitoringSection.Profiles[i];
// </Snippet67>
// <Snippet68>
string name = profileSetting.Name;
// </Snippet68>
// <Snippet69>
int minInstances = profileSetting.MinInstances;
// </Snippet69>
// <Snippet70>
int maxLimit = profileSetting.MaxLimit;
// </Snippet70>
// <Snippet71>
TimeSpan minInterval = profileSetting.MinInterval;
// </Snippet71>
// <Snippet72>
string custom = profileSetting.Custom;
// </Snippet72>
    string item = "Name='" + name + 
        "', MinInstances =  '" + minInstances + "', MaxLimit =  '" + maxLimit +
        "', MinInterval =  '" + minInterval + "', Custom =  '" + custom + "'";
    Console.WriteLine("  Item {0}: {1}", i, item);
}
// </Snippet55>

// <Snippet56>
// See if the ProfileSettings collection property contains the event 'Default'.
Console.WriteLine("Profiles contains 'Default': {0}.",
    healthMonitoringSection.Profiles.Contains("Default"));
// </Snippet56>

// <Snippet57>
// Get the index of the 'Default' ProfileSettings in the Profiles collection property.
Console.WriteLine("Profiles index for 'Default': {0}.",
    healthMonitoringSection.Profiles.IndexOf("Default"));
// </Snippet57>

// <Snippet58>
// Get a named ProfileSettings
profileSetting = healthMonitoringSection.Profiles["Default"];
// </Snippet58>

// <Snippet59>
// Remove a ProfileSettings object from the Profiles collection property.
healthMonitoringSection.Profiles.Remove("Default");
// </Snippet59>

// <Snippet60>
// Remove a ProfileSettings object from the Profiles collection property.
healthMonitoringSection.Profiles.RemoveAt(0);
// </Snippet60>

// <Snippet61>
// Clear all ProfileSettings object from the Profiles collection property.
healthMonitoringSection.Profiles.Clear();
// </Snippet61>

// </Snippet6>
                
// <Snippet7>

// Display contents of the Providers collection property
Console.WriteLine("Providers Collection contains {0} values:", 
    healthMonitoringSection.Providers.Count);

// Display all elements.
for (System.Int32 i = 0; i < healthMonitoringSection.Providers.Count; i++)
{
    System.Configuration.ProviderSettings provider = 
        healthMonitoringSection.Providers[i];
    Console.WriteLine("  Item {0}: Name = '{1}' Type = '{2}'", i, 
        provider.Name, provider.Type);
}

// </Snippet7>
                
// <Snippet8>

// <Snippet73>
// Add a RuleSettings object to the Rules collection property.
RuleSettings ruleSetting = new RuleSettings("All Errors Default",
    "All Errors", "EventLogProvider");
// <Snippet85>
ruleSetting.Name = "All Errors Custom";
// </Snippet85>
// <Snippet86>
ruleSetting.EventName = "All Errors";
// </Snippet86>
// <Snippet87>
ruleSetting.Provider = "EventLogProvider";
// </Snippet87>
// <Snippet88>
ruleSetting.Profile = "Custom";
// </Snippet88>
// <Snippet89>
ruleSetting.MaxLimit = Int32.MaxValue;
// </Snippet89>
// <Snippet90>
ruleSetting.MinInstances = 1;
// </Snippet90>
// <Snippet91>
ruleSetting.MinInterval = TimeSpan.Parse("00:00:30");
// </Snippet91>
// <Snippet92>
ruleSetting.Custom = "MyEvaluators.MyCustomeEvaluator2, MyCustom.dll";
// </Snippet92>
healthMonitoringSection.Rules.Add(ruleSetting);
// </Snippet73>

// <Snippet74>
// Add a RuleSettings object to the Rules collection property.
healthMonitoringSection.Rules.Add(new RuleSettings("All Errors Default", 
    "All Errors", "EventLogProvider"));
// </Snippet74>

// <Snippet75>
// Add a RuleSettings object to the Rules collection property.
healthMonitoringSection.Rules.Add(new RuleSettings("Failure Audits Default",
    "Failure Audits", "EventLogProvider", "Default", 1, Int32.MaxValue,
    new TimeSpan(0, 1, 0)));
// </Snippet75>

// <Snippet76>
// Add a RuleSettings object to the Rules collection property.
healthMonitoringSection.Rules.Add(new RuleSettings("Failure Audits Custom",
    "Failure Audits", "EventLogProvider", "Custom", 1, Int32.MaxValue,
    new TimeSpan(0, 1, 0), "MyEvaluators.MyCustomeEvaluator2, MyCustom.dll"));
// </Snippet76>

// <Snippet77>
// Insert an RuleSettings object into the Rules collection property.
healthMonitoringSection.Rules.Insert(1,
    new RuleSettings("All Errors Default2",
        "All Errors", "EventLogProvider"));
// </Snippet77>

// <Snippet78>
// Display contents of the Rules collection property
Console.WriteLine(
    "Rules Collection contains {0} values:", healthMonitoringSection.Rules.Count);

// Display all elements.
for (System.Int32 i = 0; i < healthMonitoringSection.Rules.Count; i++)
{
// <Snippet93>
ruleSetting = healthMonitoringSection.Rules[i];
// </Snippet93>
// <Snippet94>
string name = ruleSetting.Name;
// </Snippet94>
// <Snippet95>
string eventName = ruleSetting.EventName;
// </Snippet95>
// <Snippet96>
string provider = ruleSetting.Provider;
// </Snippet96>
// <Snippet97>
string profile = ruleSetting.Profile;
// </Snippet97>
// <Snippet98>
int minInstances = ruleSetting.MinInstances;
// </Snippet98>
// <Snippet99>
int maxLimit = ruleSetting.MaxLimit;
// </Snippet99>
// <Snippet100>
TimeSpan minInterval = ruleSetting.MinInterval;
// </Snippet100>
// <Snippet101>
string custom = ruleSetting.Custom;
// </Snippet101>
    string item = "Name='" + name + "', EventName='" + eventName +
        "', Provider =  '" + provider + "', Profile =  '" + profile +
        "', MinInstances =  '" + minInstances + "', MaxLimit =  '" + maxLimit +
        "', MinInterval =  '" + minInterval + "', Custom =  '" + custom + "'";
    Console.WriteLine("  Item {0}: {1}", i, item);
}
// </Snippet78>

// <Snippet79>
// See if the Rules collection property contains the RuleSettings 'All Errors Default'.
Console.WriteLine("EventMappings contains 'All Errors Default': {0}.",
    healthMonitoringSection.Rules.Contains("All Errors Default"));
// </Snippet79>

// <Snippet80>
// Get the index of the 'All Errors Default' RuleSettings in the Rules collection property.
Console.WriteLine("EventMappings index for 'All Errors Default': {0}.",
    healthMonitoringSection.Rules.IndexOf("All Errors Default"));
// </Snippet80>

// <Snippet81>
// Get a named RuleSettings
ruleSetting = healthMonitoringSection.Rules["All Errors Default"];
// </Snippet81>

// <Snippet82>
// Remove a RuleSettings object from the Rules collection property.
healthMonitoringSection.Rules.Remove("All Errors Default");
// </Snippet82>

// <Snippet83>
// Remove a RuleSettings object from the Rules collection property.
healthMonitoringSection.Rules.RemoveAt(0);
// </Snippet83>

// <Snippet84>
// Clear all RuleSettings object from the Rules collection property.
healthMonitoringSection.Rules.Clear();
// </Snippet84>

// </Snippet8>
                
                // Update if not locked.
                if (! healthMonitoringSection.SectionInformation.IsLocked)
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
                    "A invalid argument exception detected in UsingHealthMonitoringSection Main.");
                Console.WriteLine("Check your command line for errors.");
            }
        }
    } // UsingHealthMonitoringSection class end.
    
} // Samples.Aspnet.SystemWebConfiguration namespace end.

// </Snippet1>
