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