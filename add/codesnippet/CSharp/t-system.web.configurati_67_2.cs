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