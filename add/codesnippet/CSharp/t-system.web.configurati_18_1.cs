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

// Get the current Enabled property value.
Boolean enabledValue = healthMonitoringSection.Enabled;

// Set the Enabled property to false.
healthMonitoringSection.Enabled = false;

                

// Get the current HeartBeatInterval property value.
TimeSpan heartBeatIntervalValue = healthMonitoringSection.HeartbeatInterval;

// Set the HeartBeatInterval property to
// TimeSpan.Parse("00:10:00").
healthMonitoringSection.HeartbeatInterval = TimeSpan.Parse("00:10:00");

                

// Add a BufferModeSettings object to the BufferModes collection property.
BufferModeSettings bufferModeSetting = new BufferModeSettings("Error Log", 
    1024, 256, 512, new TimeSpan(0, 30, 0), new TimeSpan(0, 5, 0), 2);
bufferModeSetting.Name = "Operations Notification";
bufferModeSetting.MaxBufferSize = 128;
bufferModeSetting.MaxBufferThreads = 1;
bufferModeSetting.MaxFlushSize = 24;
bufferModeSetting.RegularFlushInterval = TimeSpan.MaxValue;
bufferModeSetting.UrgentFlushInterval = TimeSpan.Parse("00:01:00");
bufferModeSetting.UrgentFlushThreshold = 1;
healthMonitoringSection.BufferModes.Add(bufferModeSetting);

// Add a BufferModeSettings object to the BufferModes collection property.
healthMonitoringSection.BufferModes.Add(new BufferModeSettings("Error Log", 
    1024, 256, 512, new TimeSpan(0, 30, 0), new TimeSpan(0, 5, 0), 2));

// Display contents of the BufferModes collection property
Console.WriteLine("BufferModes Collection contains {0} values:", 
    healthMonitoringSection.BufferModes.Count);

// Display all elements.
for (System.Int32 i = 0; i < healthMonitoringSection.BufferModes.Count; i++)
{
bufferModeSetting = healthMonitoringSection.BufferModes[i];
string name = bufferModeSetting.Name;
int maxBufferSize = bufferModeSetting.MaxBufferSize;
int maxBufferThreads = bufferModeSetting.MaxBufferThreads;
int maxFlushSize = bufferModeSetting.MaxFlushSize;
TimeSpan regularFlushInterval = bufferModeSetting.RegularFlushInterval;
TimeSpan urgentFlushInterval = bufferModeSetting.UrgentFlushInterval;
int urgentFlushThreshold = bufferModeSetting.UrgentFlushThreshold;
    string item = "Name='" + name + "', MaxBufferSize =  '" + maxBufferSize + 
        "', MaxBufferThreads =  '" + maxBufferThreads +
        "', MaxFlushSize =  '" + maxFlushSize + 
        "', RegularFlushInterval =  '" + regularFlushInterval +
        "', UrgentFlushInterval =  '" + urgentFlushInterval + 
        "', UrgentFlushThreshold =  '" + urgentFlushThreshold + "'";
    Console.WriteLine("  Item {0}: {1}", i, item);
}

// Get a named BufferMode
bufferModeSetting = healthMonitoringSection.BufferModes["Error Log"];

// Remove a BufferModeSettings object from the BufferModes collection property.
healthMonitoringSection.BufferModes.Remove("Error Log");

// Clear all BufferModeSettings object from the BufferModes collection property.
healthMonitoringSection.BufferModes.Clear();

                

// Add a EventMappingsSettings object to the EventMappings collection property.
EventMappingSettings eventMappingSetting = new EventMappingSettings(
    "Failure Audits", "System.Web.Management.WebAuditEvent, System.Web");
eventMappingSetting.Name = "All Errors";
eventMappingSetting.Type = 
    "System.Web.Management.WebErrorEvent, System.Web";
eventMappingSetting.StartEventCode = 0;
eventMappingSetting.EndEventCode = 4096;
healthMonitoringSection.EventMappings.Add(eventMappingSetting);

// Add an EventMappingsSettings object to the EventMappings collection property.
healthMonitoringSection.EventMappings.Add(new EventMappingSettings(
    "Failure Audits", "System.Web.Management.WebAuditEvent, System.Web"));

// Add an EventMappingsSettings object to the EventMappings collection property.
healthMonitoringSection.EventMappings.Add(new EventMappingSettings(
    "Success Audits", "System.Web.Management.WebAuditEvent, System.Web",
    512, Int32.MaxValue));

// Insert an EventMappingsSettings object into the EventMappings collection property.
healthMonitoringSection.EventMappings.Insert(1, 
    new EventMappingSettings("HeartBeats", "", 1, 2));

// Display contents of the EventMappings collection property
Console.WriteLine(
    "EventMappings Collection contains {0} values:", healthMonitoringSection.EventMappings.Count);

// Display all elements.
for (System.Int32 i = 0; i < healthMonitoringSection.EventMappings.Count; i++)
{
eventMappingSetting = healthMonitoringSection.EventMappings[i];
string name = eventMappingSetting.Name;
string type = eventMappingSetting.Type;
int startCd = eventMappingSetting.StartEventCode;
int endCd = eventMappingSetting.EndEventCode;
    string item = "Name='" + name + "', Type='" + type +
        "', StartEventCode =  '" + startCd.ToString() +
        "', EndEventCode =  '" + endCd.ToString() + "'";
    Console.WriteLine("  Item {0}: {1}", i, item);
}

// See if the EventMappings collection property contains the event 'HeartBeats'.
Console.WriteLine("EventMappings contains 'HeartBeats': {0}.",
    healthMonitoringSection.EventMappings.Contains("HeartBeats"));

// Get the index of the 'HeartBeats' event in the EventMappings collection property.
Console.WriteLine("EventMappings index for 'HeartBeats': {0}.",
    healthMonitoringSection.EventMappings.IndexOf("HeartBeats"));

// Get a named EventMappings
eventMappingSetting = healthMonitoringSection.EventMappings["HeartBeats"];

// Remove an EventMappingsSettings object from the EventMappings collection property.
healthMonitoringSection.EventMappings.Remove("HeartBeats");

// Remove an EventMappingsSettings object from the EventMappings collection property.
healthMonitoringSection.EventMappings.RemoveAt(0);

// Clear all EventMappingsSettings object from the EventMappings collection property.
healthMonitoringSection.EventMappings.Clear();

                

// Add a ProfileSettings object to the Profiles collection property.
ProfileSettings profileSetting = new ProfileSettings("Default");
profileSetting.Name = "Custom";
profileSetting.MaxLimit = Int32.MaxValue;
profileSetting.MinInstances = 1;
profileSetting.MinInterval = TimeSpan.Parse("00:01:00");
profileSetting.Custom = "MyEvaluators.MyCustomeEvaluator, MyCustom.dll";
healthMonitoringSection.Profiles.Add(profileSetting);

// Add a ProfileSettings object to the Profiles collection property.
healthMonitoringSection.Profiles.Add(new ProfileSettings("Default"));

// Add a ProfileSettings object to the Profiles collection property.
healthMonitoringSection.Profiles.Add(new ProfileSettings("Critical", 
    1, 1024, new TimeSpan(0, 0, 00)));

// Add a ProfileSettings object to the Profiles collection property.
healthMonitoringSection.Profiles.Add(new ProfileSettings("Targeted", 
    1, Int32.MaxValue, new TimeSpan(0, 0, 10), 
    "MyEvaluators.MyTargetedEvaluator, MyCustom.dll"));

// Insert an ProfileSettings object into the Profiles collection property.
healthMonitoringSection.Profiles.Insert(1, new ProfileSettings("Default2"));

// Display contents of the Profiles collection property
Console.WriteLine(
    "Profiles Collection contains {0} values:", 
    healthMonitoringSection.Profiles.Count);

// Display all elements.
for (System.Int32 i = 0; i < healthMonitoringSection.Profiles.Count; i++)
{
profileSetting = healthMonitoringSection.Profiles[i];
string name = profileSetting.Name;
int minInstances = profileSetting.MinInstances;
int maxLimit = profileSetting.MaxLimit;
TimeSpan minInterval = profileSetting.MinInterval;
string custom = profileSetting.Custom;
    string item = "Name='" + name + 
        "', MinInstances =  '" + minInstances + "', MaxLimit =  '" + maxLimit +
        "', MinInterval =  '" + minInterval + "', Custom =  '" + custom + "'";
    Console.WriteLine("  Item {0}: {1}", i, item);
}

// See if the ProfileSettings collection property contains the event 'Default'.
Console.WriteLine("Profiles contains 'Default': {0}.",
    healthMonitoringSection.Profiles.Contains("Default"));

// Get the index of the 'Default' ProfileSettings in the Profiles collection property.
Console.WriteLine("Profiles index for 'Default': {0}.",
    healthMonitoringSection.Profiles.IndexOf("Default"));

// Get a named ProfileSettings
profileSetting = healthMonitoringSection.Profiles["Default"];

// Remove a ProfileSettings object from the Profiles collection property.
healthMonitoringSection.Profiles.Remove("Default");

// Remove a ProfileSettings object from the Profiles collection property.
healthMonitoringSection.Profiles.RemoveAt(0);

// Clear all ProfileSettings object from the Profiles collection property.
healthMonitoringSection.Profiles.Clear();

                

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

                

// Add a RuleSettings object to the Rules collection property.
RuleSettings ruleSetting = new RuleSettings("All Errors Default",
    "All Errors", "EventLogProvider");
ruleSetting.Name = "All Errors Custom";
ruleSetting.EventName = "All Errors";
ruleSetting.Provider = "EventLogProvider";
ruleSetting.Profile = "Custom";
ruleSetting.MaxLimit = Int32.MaxValue;
ruleSetting.MinInstances = 1;
ruleSetting.MinInterval = TimeSpan.Parse("00:00:30");
ruleSetting.Custom = "MyEvaluators.MyCustomeEvaluator2, MyCustom.dll";
healthMonitoringSection.Rules.Add(ruleSetting);

// Add a RuleSettings object to the Rules collection property.
healthMonitoringSection.Rules.Add(new RuleSettings("All Errors Default", 
    "All Errors", "EventLogProvider"));

// Add a RuleSettings object to the Rules collection property.
healthMonitoringSection.Rules.Add(new RuleSettings("Failure Audits Default",
    "Failure Audits", "EventLogProvider", "Default", 1, Int32.MaxValue,
    new TimeSpan(0, 1, 0)));

// Add a RuleSettings object to the Rules collection property.
healthMonitoringSection.Rules.Add(new RuleSettings("Failure Audits Custom",
    "Failure Audits", "EventLogProvider", "Custom", 1, Int32.MaxValue,
    new TimeSpan(0, 1, 0), "MyEvaluators.MyCustomeEvaluator2, MyCustom.dll"));

// Insert an RuleSettings object into the Rules collection property.
healthMonitoringSection.Rules.Insert(1,
    new RuleSettings("All Errors Default2",
        "All Errors", "EventLogProvider"));

// Display contents of the Rules collection property
Console.WriteLine(
    "Rules Collection contains {0} values:", healthMonitoringSection.Rules.Count);

// Display all elements.
for (System.Int32 i = 0; i < healthMonitoringSection.Rules.Count; i++)
{
ruleSetting = healthMonitoringSection.Rules[i];
string name = ruleSetting.Name;
string eventName = ruleSetting.EventName;
string provider = ruleSetting.Provider;
string profile = ruleSetting.Profile;
int minInstances = ruleSetting.MinInstances;
int maxLimit = ruleSetting.MaxLimit;
TimeSpan minInterval = ruleSetting.MinInterval;
string custom = ruleSetting.Custom;
    string item = "Name='" + name + "', EventName='" + eventName +
        "', Provider =  '" + provider + "', Profile =  '" + profile +
        "', MinInstances =  '" + minInstances + "', MaxLimit =  '" + maxLimit +
        "', MinInterval =  '" + minInterval + "', Custom =  '" + custom + "'";
    Console.WriteLine("  Item {0}: {1}", i, item);
}

// See if the Rules collection property contains the RuleSettings 'All Errors Default'.
Console.WriteLine("EventMappings contains 'All Errors Default': {0}.",
    healthMonitoringSection.Rules.Contains("All Errors Default"));

// Get the index of the 'All Errors Default' RuleSettings in the Rules collection property.
Console.WriteLine("EventMappings index for 'All Errors Default': {0}.",
    healthMonitoringSection.Rules.IndexOf("All Errors Default"));

// Get a named RuleSettings
ruleSetting = healthMonitoringSection.Rules["All Errors Default"];

// Remove a RuleSettings object from the Rules collection property.
healthMonitoringSection.Rules.Remove("All Errors Default");

// Remove a RuleSettings object from the Rules collection property.
healthMonitoringSection.Rules.RemoveAt(0);

// Clear all RuleSettings object from the Rules collection property.
healthMonitoringSection.Rules.Clear();

                
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
