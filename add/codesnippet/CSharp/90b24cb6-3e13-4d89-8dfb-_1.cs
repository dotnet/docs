// Add a ProfileSettings object to the Profiles collection property.
healthMonitoringSection.Profiles.Add(new ProfileSettings("Targeted", 
    1, Int32.MaxValue, new TimeSpan(0, 0, 10), 
    "MyEvaluators.MyTargetedEvaluator, MyCustom.dll"));