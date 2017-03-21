
' Add a ProfileSettings object to the Profiles collection property.
            Dim profileSetting As ProfileSettings = New ProfileSettings("Default")
profileSetting.Name = "Custom"
profileSetting.MaxLimit = Int32.MaxValue
profileSetting.MinInstances = 1
profileSetting.MinInterval = TimeSpan.Parse("00:01:00")
profileSetting.Custom = "MyEvaluators.MyCustomeEvaluator, MyCustom.dll"
healthMonitoringSection.Profiles.Add(profileSetting)

' Add a ProfileSettings object to the Profiles collection property.
healthMonitoringSection.Profiles.Add(new ProfileSettings("Default"))

' Add a ProfileSettings object to the Profiles collection property.
healthMonitoringSection.Profiles.Add(new ProfileSettings("Critical",  _
    1, 1024, new TimeSpan(0, 0, 00)))

' Add a ProfileSettings object to the Profiles collection property.
healthMonitoringSection.Profiles.Add(new ProfileSettings("Targeted", _
    1, Int32.MaxValue, new TimeSpan(0, 0, 10), _
    "MyEvaluators.MyTargetedEvaluator, MyCustom.dll"))

' Insert an ProfileSettings object into the Profiles collection property.
healthMonitoringSection.Profiles.Insert(1, new ProfileSettings("Default2"))

' Display contents of the Profiles collection property
Console.WriteLine( _
    "Profiles Collection contains {0} values:",  _
    healthMonitoringSection.Profiles.Count)

' Display all elements.
For i As System.Int32 = 0 To healthMonitoringSection.Profiles.Count - 1
profileSetting = healthMonitoringSection.Profiles(i)
Dim name As String = profileSetting.Name
Dim minInstances As Integer = profileSetting.MinInstances
Dim maxLimit As Integer = profileSetting.MaxLimit
Dim minInterval As TimeSpan = profileSetting.MinInterval
Dim custom As String = profileSetting.Custom
    Dim item As String = "Name='" & name & _
        "', MinInstances =  '" & minInstances & "', MaxLimit =  '" & maxLimit & _
        "', MinInterval =  '" & minInterval.ToString() & "', Custom =  '" & custom & "'" 
    Console.WriteLine("  Item {0}: {1}", i, item)
Next

' See if the ProfileSettings collection property contains the event 'Default'.
Console.WriteLine("Profiles contains 'Default': {0}.", _
    healthMonitoringSection.Profiles.Contains("Default"))

' Get the index of the 'Default' ProfileSettings in the Profiles collection property.
Console.WriteLine("Profiles index for 'Default': {0}.", _
    healthMonitoringSection.Profiles.IndexOf("Default"))

' Get a named ProfileSettings
profileSetting = healthMonitoringSection.Profiles("Default")

' Remove a ProfileSettings object from the Profiles collection property.
healthMonitoringSection.Profiles.Remove("Default")

' Remove a ProfileSettings object from the Profiles collection property.
healthMonitoringSection.Profiles.RemoveAt(0)

' Clear all ProfileSettings object from the Profiles collection property.
healthMonitoringSection.Profiles.Clear()
