// Display all current root ProfilePropertySettings.
Console.WriteLine("Current Root ProfilePropertySettings:");
int rootPPSCtr = 0;
foreach (ProfilePropertySettings rootPPS in profileSection.PropertySettings)
{
    Console.WriteLine("  {0}: ProfilePropertySetting '{1}'", ++rootPPSCtr,
        rootPPS.Name);
}