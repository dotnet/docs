' See if the Rules collection property contains the RuleSettings 'All Errors Default'.
Console.WriteLine("EventMappings contains 'All Errors Default': {0}.", _
    healthMonitoringSection.Rules.Contains("All Errors Default"))