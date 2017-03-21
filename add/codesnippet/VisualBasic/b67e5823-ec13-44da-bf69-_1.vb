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