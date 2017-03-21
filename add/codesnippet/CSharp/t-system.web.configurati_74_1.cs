
// Add a BufferModeSettings object to the BufferModes collection property.
BufferModeSettings bufferModeSetting = new BufferModeSettings("Error Log", 
    1024, 256, 512, new TimeSpan(0, 30, 0), new TimeSpan(0, 5, 0), 2);
bufferModeSetting.Name = "Operations Notification";
bufferModeSetting.MaxBufferSize = 128;
bufferModeSetting.MaxBufferThreads = 1;
bufferModeSetting.MaxFlushSize = 24;
bufferModeSetting.RegularFlushInterval = TimeSpan.MaxValue;
bufferModeSetting.UrgentFlushInterval = TimeSpan.Parse("00:01:00");
bufferModeSetting.UrgentFlushThreshold = 1;
healthMonitoringSection.BufferModes.Add(bufferModeSetting);

// Add a BufferModeSettings object to the BufferModes collection property.
healthMonitoringSection.BufferModes.Add(new BufferModeSettings("Error Log", 
    1024, 256, 512, new TimeSpan(0, 30, 0), new TimeSpan(0, 5, 0), 2));

// Display contents of the BufferModes collection property
Console.WriteLine("BufferModes Collection contains {0} values:", 
    healthMonitoringSection.BufferModes.Count);

// Display all elements.
for (System.Int32 i = 0; i < healthMonitoringSection.BufferModes.Count; i++)
{
bufferModeSetting = healthMonitoringSection.BufferModes[i];
string name = bufferModeSetting.Name;
int maxBufferSize = bufferModeSetting.MaxBufferSize;
int maxBufferThreads = bufferModeSetting.MaxBufferThreads;
int maxFlushSize = bufferModeSetting.MaxFlushSize;
TimeSpan regularFlushInterval = bufferModeSetting.RegularFlushInterval;
TimeSpan urgentFlushInterval = bufferModeSetting.UrgentFlushInterval;
int urgentFlushThreshold = bufferModeSetting.UrgentFlushThreshold;
    string item = "Name='" + name + "', MaxBufferSize =  '" + maxBufferSize + 
        "', MaxBufferThreads =  '" + maxBufferThreads +
        "', MaxFlushSize =  '" + maxFlushSize + 
        "', RegularFlushInterval =  '" + regularFlushInterval +
        "', UrgentFlushInterval =  '" + urgentFlushInterval + 
        "', UrgentFlushThreshold =  '" + urgentFlushThreshold + "'";
    Console.WriteLine("  Item {0}: {1}", i, item);
}

// Get a named BufferMode
bufferModeSetting = healthMonitoringSection.BufferModes["Error Log"];

// Remove a BufferModeSettings object from the BufferModes collection property.
healthMonitoringSection.BufferModes.Remove("Error Log");

// Clear all BufferModeSettings object from the BufferModes collection property.
healthMonitoringSection.BufferModes.Clear();
