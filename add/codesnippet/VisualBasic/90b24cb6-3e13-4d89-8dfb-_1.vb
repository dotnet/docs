' Add a ProfileSettings object to the Profiles collection property.
healthMonitoringSection.Profiles.Add(new ProfileSettings("Targeted", _
    1, Int32.MaxValue, new TimeSpan(0, 0, 10), _
    "MyEvaluators.MyTargetedEvaluator, MyCustom.dll"))