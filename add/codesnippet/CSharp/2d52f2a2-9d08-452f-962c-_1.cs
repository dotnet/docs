// Insert an RuleSettings object into the Rules collection property.
healthMonitoringSection.Rules.Insert(1,
    new RuleSettings("All Errors Default2",
        "All Errors", "EventLogProvider"));