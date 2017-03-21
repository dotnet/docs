
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
