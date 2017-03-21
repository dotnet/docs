// Add a BufferModeSettings object to the BufferModes collection property.
healthMonitoringSection.BufferModes.Add(new BufferModeSettings("Error Log", 
    1024, 256, 512, new TimeSpan(0, 30, 0), new TimeSpan(0, 5, 0), 2));