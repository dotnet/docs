// Display all current ProfileGroupSettings.
Console.WriteLine("Current ProfileGroupSettings:");
int PGSCtr = 0;
foreach (ProfileGroupSettings propGroups in profileSection.PropertySettings.GroupSettings)
{
    Console.WriteLine("  {0}: ProfileGroupSetting '{1}'", ++PGSCtr,
        propGroups.Name);
    int PPSCtr = 0;
    foreach (ProfilePropertySettings props in propGroups.PropertySettings)
    {
        Console.WriteLine("    {0}: ProfilePropertySetting '{1}'", ++PPSCtr,
            props.Name);
    }
}