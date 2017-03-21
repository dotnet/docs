// Add a RuleSettings object to the Rules collection property.
healthMonitoringSection.Rules.Add(new RuleSettings("Failure Audits Default",
    "Failure Audits", "EventLogProvider", "Default", 1, Int32.MaxValue,
    new TimeSpan(0, 1, 0)));