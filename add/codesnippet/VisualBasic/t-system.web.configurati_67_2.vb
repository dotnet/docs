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