' See if the EventMappings collection property contains the event 'HeartBeats'.
Console.WriteLine("EventMappings contains 'HeartBeats': {0}.", _
    healthMonitoringSection.EventMappings.Contains("HeartBeats"))