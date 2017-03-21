' Insert an RuleSettings object into the Rules collection property.
healthMonitoringSection.Rules.Insert(1, _
    new RuleSettings("All Errors Default2", _
        "All Errors", "EventLogProvider"))