
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
