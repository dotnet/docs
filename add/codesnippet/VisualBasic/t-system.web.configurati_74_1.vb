
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
