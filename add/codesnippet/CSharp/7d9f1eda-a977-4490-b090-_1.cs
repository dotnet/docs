// Add a RuleSettings object to the Rules collection property.
healthMonitoringSection.Rules.Add(new RuleSettings("Failure Audits Custom",
    "Failure Audits", "EventLogProvider", "Custom", 1, Int32.MaxValue,
    new TimeSpan(0, 1, 0), "MyEvaluators.MyCustomeEvaluator2, MyCustom.dll"));