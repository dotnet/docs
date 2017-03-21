' Display all current root ProfilePropertySettings.
Console.WriteLine("Current Root ProfilePropertySettings:")
Dim rootPPSCtr As Integer = 0
For Each rootPPS As ProfilePropertySettings In profileSection.PropertySettings
    Console.WriteLine("  {0}: ProfilePropertySetting '{1}'", ++rootPPSCtr, _
        rootPPS.Name)
Next