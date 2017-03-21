' Display all current ProfileGroupSettings.
Console.WriteLine("Current ProfileGroupSettings:")
Dim PGSCtr As Integer = 0
For Each propGroups As ProfileGroupSettings In profileSection.PropertySettings.GroupSettings
                    Console.WriteLine("  {0}: ProfileGroupSettings '{1}'", ++PGSCtr, _
        propGroups.Name)
    Dim PPSCtr As Integer = 0
    For Each props As ProfilePropertySettings In propGroups.PropertySettings
        Console.WriteLine("    {0}: ProfilePropertySetting '{1}'", ++PPSCtr, _
            props.Name)
    Next
Next