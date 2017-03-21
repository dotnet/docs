
' Add a RuleSettings object to the Rules collection property.
Dim ruleSetting As RuleSettings = new RuleSettings("All Errors Default", _
    "All Errors", "EventLogProvider")
ruleSetting.Name = "All Errors Custom"
ruleSetting.EventName = "All Errors"
ruleSetting.Provider = "EventLogProvider"
ruleSetting.Profile = "Custom"
ruleSetting.MaxLimit = Int32.MaxValue
ruleSetting.MinInstances = 1
ruleSetting.MinInterval = TimeSpan.Parse("00:00:30")
ruleSetting.Custom = "MyEvaluators.MyCustomeEvaluator2, MyCustom.dll"
healthMonitoringSection.Rules.Add(ruleSetting)

' Add a RuleSettings object to the Rules collection property.
healthMonitoringSection.Rules.Add(new RuleSettings("All Errors Default", _
    "All Errors", "EventLogProvider"))

' Add a RuleSettings object to the Rules collection property.
healthMonitoringSection.Rules.Add(new RuleSettings("Failure Audits Default", _
    "Failure Audits", "EventLogProvider", "Default", 1, Int32.MaxValue, _
    new TimeSpan(0, 1, 0)))

' Add a RuleSettings object to the Rules collection property.
healthMonitoringSection.Rules.Add(new RuleSettings("Failure Audits Custom", _
    "Failure Audits", "EventLogProvider", "Custom", 1, Int32.MaxValue, _
    new TimeSpan(0, 1, 0), "MyEvaluators.MyCustomeEvaluator2, MyCustom.dll"))

' Insert an RuleSettings object into the Rules collection property.
healthMonitoringSection.Rules.Insert(1, _
    new RuleSettings("All Errors Default2", _
        "All Errors", "EventLogProvider"))

' Display contents of the Rules collection property
Console.WriteLine( _
    "Rules Collection contains {0} values:", healthMonitoringSection.Rules.Count)

' Display all elements.
For i As System.Int32 = 0 To healthMonitoringSection.Rules.Count -1
ruleSetting = healthMonitoringSection.Rules(i)
Dim name As String = ruleSetting.Name
Dim eventName As String = ruleSetting.EventName
Dim provider As String = ruleSetting.Provider
Dim profile As String = ruleSetting.Profile
Dim minInstances As Integer = ruleSetting.MinInstances
Dim maxLimit As Integer = ruleSetting.MaxLimit
Dim minInterval As TimeSpan = ruleSetting.MinInterval
Dim custom As String = ruleSetting.Custom
    Dim item As String = "Name='" & name & "', EventName='" & eventName & _
        "', Provider =  '" & provider & "', Profile =  '" & profile & _
        "', MinInstances =  '" & minInstances & "', MaxLimit =  '" & maxLimit & _
        "', MinInterval =  '" & minInterval.ToString() & "', Custom =  '" & custom & "'"
    Console.WriteLine("  Item {0}: {1}", i, item)
Next

' See if the Rules collection property contains the RuleSettings 'All Errors Default'.
Console.WriteLine("EventMappings contains 'All Errors Default': {0}.", _
    healthMonitoringSection.Rules.Contains("All Errors Default"))

' Get the index of the 'All Errors Default' RuleSettings in the Rules collection property.
Console.WriteLine("EventMappings index for 'All Errors Default': {0}.", _
    healthMonitoringSection.Rules.IndexOf("All Errors Default"))

' Get a named RuleSettings
ruleSetting = healthMonitoringSection.Rules("All Errors Default")

' Remove a RuleSettings object from the Rules collection property.
healthMonitoringSection.Rules.Remove("All Errors Default")

' Remove a RuleSettings object from the Rules collection property.
healthMonitoringSection.Rules.RemoveAt(0)

' Clear all RuleSettings object from the Rules collection property.
healthMonitoringSection.Rules.Clear()
