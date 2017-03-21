' Add a RuleSettings object to the Rules collection property.
healthMonitoringSection.Rules.Add(new RuleSettings("Failure Audits Default", _
    "Failure Audits", "EventLogProvider", "Default", 1, Int32.MaxValue, _
    new TimeSpan(0, 1, 0)))