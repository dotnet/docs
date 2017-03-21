Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.Web.Configuration

Namespace Samples.Aspnet.SystemWebConfiguration
    ' Accesses the
    ' System.Web.Configuration.HealthMonitoringSection members
    ' selected by the user.
    Class UsingHealthMonitoringSection
        Public Shared Sub Main()
            ' Process the
            ' System.Web.Configuration.HealthMonitoringSectionobject.
            Try
                ' Get the Web application configuration.
                Dim configuration As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnet")
                
                ' Get the section.
                Dim healthMonitoringSection As System.Web.Configuration.HealthMonitoringSection = CType(configuration.GetSection("system.web/healthmonitoring"), System.Web.Configuration.HealthMonitoringSection)

' Get the current Enabled property value.
Dim enabledValue As Boolean = healthMonitoringSection.Enabled

' Set the Enabled property to False.
healthMonitoringSection.Enabled = False

                

' Get the current HeartBeatInterval property value.
Dim heartBeatIntervalValue As TimeSpan = healthMonitoringSection.HeartbeatInterval

' Set the HeartBeatInterval property to
' TimeSpan.Parse("00:10:00").
healthMonitoringSection.HeartbeatInterval = TimeSpan.Parse("00:10:00")

                

' Add a BufferModeSettings object to the BufferModes collection property.
Dim bufferModeSetting As BufferModeSettings = new BufferModeSettings("Error Log", _
    1024, 256, 512, new TimeSpan(0, 30, 0), new TimeSpan(0, 5, 0), 2)
bufferModeSetting.Name = "Operations Notification"
bufferModeSetting.MaxBufferSize = 128
bufferModeSetting.MaxBufferThreads = 1
bufferModeSetting.MaxFlushSize = 24
bufferModeSetting.RegularFlushInterval = TimeSpan.MaxValue
bufferModeSetting.UrgentFlushInterval = TimeSpan.Parse("00:01:00")
bufferModeSetting.UrgentFlushThreshold = 1
healthMonitoringSection.BufferModes.Add(bufferModeSetting)

' Add a BufferModeSettings object to the BufferModes collection property.
healthMonitoringSection.BufferModes.Add(new BufferModeSettings("Error Log", _
    1024, 256, 512, new TimeSpan(0, 30, 0), new TimeSpan(0, 5, 0), 2))

' Display contents of the BufferModes collection property
Console.WriteLine("BufferModes Collection contains {0} values:",  _
    healthMonitoringSection.BufferModes.Count)

' Display all elements.
For i As System.Int32 = 0 To healthMonitoringSection.BufferModes.Count - 1
bufferModeSetting = healthMonitoringSection.BufferModes(i)
Dim name As String = bufferModeSetting.Name
Dim maxBufferSize As Integer = bufferModeSetting.MaxBufferSize
Dim maxBufferThreads As Integer = bufferModeSetting.MaxBufferThreads
Dim maxFlushSize As Integer = bufferModeSetting.MaxFlushSize
Dim regularFlushInterval As TimeSpan = bufferModeSetting.RegularFlushInterval
Dim urgentFlushInterval As TimeSpan = bufferModeSetting.UrgentFlushInterval
Dim urgentFlushThreshold As Integer = bufferModeSetting.UrgentFlushThreshold
    Dim item As String = "Name='" & name & "', MaxBufferSize =  '" & maxBufferSize & _
        "', MaxBufferThreads =  '" & maxBufferThreads & _
        "', MaxFlushSize =  '" & maxFlushSize & _
        "', RegularFlushInterval =  '" & regularFlushInterval.ToString() & _
        "', UrgentFlushInterval =  '" & urgentFlushInterval.ToString() & _
        "', UrgentFlushThreshold =  '" & urgentFlushThreshold & "'"
    Console.WriteLine("  Item {0}: {1}", i, item)
Next

' Get a named BufferMode
bufferModeSetting = healthMonitoringSection.BufferModes("Error Log")

' Remove a BufferModeSettings object from the BufferModes collection property.
healthMonitoringSection.BufferModes.Remove("Error Log")

' Clear all BufferModeSettings object from the BufferModes collection property.
healthMonitoringSection.BufferModes.Clear()

                

' Add a EventMappingsSettings object to the EventMappings collection property.
Dim eventMappingSetting As EventMappingSettings = New EventMappingSettings( _
    "Failure Audits", "System.Web.Management.WebAuditEvent, System.Web")
eventMappingSetting.Name = "All Errors"
eventMappingSetting.Type = _
    "System.Web.Management.WebErrorEvent, System.Web"
eventMappingSetting.StartEventCode = 0
eventMappingSetting.EndEventCode = 4096
healthMonitoringSection.EventMappings.Add(eventMappingSetting)

' Add an EventMappingsSettings object to the EventMappings collection property.
healthMonitoringSection.EventMappings.Add(new EventMappingSettings( _
    "Failure Audits", "System.Web.Management.WebAuditEvent, System.Web"))

' Add an EventMappingsSettings object to the EventMappings collection property.
healthMonitoringSection.EventMappings.Add(new EventMappingSettings( _
    "Success Audits", "System.Web.Management.WebAuditEvent, System.Web", _
    512, Int32.MaxValue))

' Insert an EventMappingsSettings object into the EventMappings collection property.
healthMonitoringSection.EventMappings.Insert(1, _
    new EventMappingSettings("HeartBeats", "", 1, 2))

' Display contents of the EventMappings collection property
Console.WriteLine( _
    "EventMappings Collection contains {0} values:", healthMonitoringSection.EventMappings.Count)

' Display all elements.
For i As System.Int32 = 0 To healthMonitoringSection.EventMappings.Count - 1
eventMappingSetting = healthMonitoringSection.EventMappings(i)
Dim name As String = eventMappingSetting.Name
Dim type As String = eventMappingSetting.Type
Dim startCd As Integer = eventMappingSetting.StartEventCode
Dim endCd As Integer = eventMappingSetting.EndEventCode
    Dim item As String = "Name='" & name & "', Type='" & type & _
        "', StartEventCode =  '" & startCd.ToString() & _
        "', EndEventCode =  '" & endCd.ToString() & "'"
    Console.WriteLine("  Item {0}: {1}", i, item)
Next

' See if the EventMappings collection property contains the event 'HeartBeats'.
Console.WriteLine("EventMappings contains 'HeartBeats': {0}.", _
    healthMonitoringSection.EventMappings.Contains("HeartBeats"))

' Get the index of the 'HeartBeats' event in the EventMappings collection property.
Console.WriteLine("EventMappings index for 'HeartBeats': {0}.", _
    healthMonitoringSection.EventMappings.IndexOf("HeartBeats"))

' Get a named EventMappings
eventMappingSetting = healthMonitoringSection.EventMappings("HeartBeats")

' Remove an EventMappingsSettings object from the EventMappings collection property.
healthMonitoringSection.EventMappings.Remove("HeartBeats")

' Remove an EventMappingsSettings object from the EventMappings collection property.
healthMonitoringSection.EventMappings.RemoveAt(0)

' Clear all EventMappingsSettings object from the EventMappings collection property.
healthMonitoringSection.EventMappings.Clear()

                

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

                

' Display contents of the Providers collection property
Console.WriteLine("Providers Collection contains {0} values:", _
    healthMonitoringSection.Providers.Count)

' Display all elements.
For i As System.Int32 = 0 To healthMonitoringSection.Providers.Count - 1
    Dim providerStg As System.Configuration.ProviderSettings = _
        healthMonitoringSection.Providers(i)
    Console.WriteLine("  Item {0}: Name = '{1}' Type = '{2}'", i, _
        providerStg.Name, providerStg.Type)
Next

                

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

                
                ' Update if not locked.
                If Not healthMonitoringSection.SectionInformation.IsLocked Then
                    configuration.Save()
                    Console.WriteLine("** Configuration updated.")
                Else
                    Console.WriteLine("** Could not update, section is locked.")
                End If
            Catch e As System.ArgumentException
                ' Unknown error.
                Console.WriteLine( _
                    "A invalid argument exception detected in UsingHealthMonitoringSection Main.")
                Console.WriteLine("Check your command line for errors.")
            End Try
        End Sub
    End Class ' UsingHealthMonitoringSection.
    
End Namespace ' Samples.Aspnet.SystemWebConfiguration
