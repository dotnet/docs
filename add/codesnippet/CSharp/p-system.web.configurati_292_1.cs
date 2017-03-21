
// Display all current root ProfilePropertySettings.
Console.WriteLine("Current Root ProfilePropertySettings:");
int rootPPSCtr = 0;
foreach (ProfilePropertySettings rootPPS in profileSection.PropertySettings)
{
    Console.WriteLine("  {0}: ProfilePropertySetting '{1}'", ++rootPPSCtr,
        rootPPS.Name);
}

// Get and modify a root ProfilePropertySettings object.
Console.WriteLine(
    "Display and modify 'LastReadDate' ProfilePropertySettings:");
ProfilePropertySettings profilePropertySettings =
    profileSection.PropertySettings["LastReadDate"];

// Get the current ReadOnly property value.
Console.WriteLine(
    "Current ReadOnly value: '{0}'", profilePropertySettings.ReadOnly);

// Set the ReadOnly property to true.
profilePropertySettings.ReadOnly = true;

// Get the current AllowAnonymous property value.
Console.WriteLine(
    "Current AllowAnonymous value: '{0}'", profilePropertySettings.AllowAnonymous);

// Set the AllowAnonymous property to true.
profilePropertySettings.AllowAnonymous = true;

// Get the current SerializeAs property value.
Console.WriteLine(
    "Current SerializeAs value: '{0}'", profilePropertySettings.SerializeAs);

// Set the SerializeAs property to SerializationMode.Binary.
profilePropertySettings.SerializeAs = SerializationMode.Binary;

// Get the current Type property value.
Console.WriteLine(
    "Current Type value: '{0}'", profilePropertySettings.Type);

// Set the Type property to "System.DateTime".
profilePropertySettings.Type = "System.DateTime";

// Get the current DefaultValue property value.
Console.WriteLine(
    "Current DefaultValue value: '{0}'", profilePropertySettings.DefaultValue);

// Set the DefaultValue property to "March 16, 2004".
profilePropertySettings.DefaultValue = "March 16, 2004";

// Get the current ProviderName property value.
Console.WriteLine(
    "Current ProviderName value: '{0}'", profilePropertySettings.Provider);

// Set the ProviderName property to "AspNetSqlRoleProvider".
profilePropertySettings.Provider = "AspNetSqlRoleProvider";

// Get the current Name property value.
Console.WriteLine(
    "Current Name value: '{0}'", profilePropertySettings.Name);

// Set the Name property to "LastAccessDate".
profilePropertySettings.Name = "LastAccessDate";

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

// Add a new group.
ProfileGroupSettings newPropGroup = new ProfileGroupSettings("Forum");
profileSection.PropertySettings.GroupSettings.Add(newPropGroup);

// Add a new PropertySettings to the group.
ProfilePropertySettings newProp = new ProfilePropertySettings("AvatarImage");
newProp.Type = "System.String, System.dll";
newPropGroup.PropertySettings.Add(newProp);

// Remove a PropertySettings from the group.
newPropGroup.PropertySettings.Remove("AvatarImage");
newPropGroup.PropertySettings.RemoveAt(0);

// Clear all PropertySettings from the group.
newPropGroup.PropertySettings.Clear();
