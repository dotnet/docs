

' Display all current root ProfilePropertySettings.
Console.WriteLine("Current Root ProfilePropertySettings:")
Dim rootPPSCtr As Integer = 0
For Each rootPPS As ProfilePropertySettings In profileSection.PropertySettings
    Console.WriteLine("  {0}: ProfilePropertySetting '{1}'", ++rootPPSCtr, _
        rootPPS.Name)
Next

' Get and modify a root ProfilePropertySettings object.
Console.WriteLine( _
    "Display and modify 'LastReadDate' ProfilePropertySettings:")
Dim profilePropertySettings As ProfilePropertySettings = _
    profileSection.PropertySettings("LastReadDate")

' Get the current ReadOnly property value.
Console.WriteLine( _
    "Current ReadOnly value: '{0}'", profilePropertySettings.ReadOnly)

' Set the ReadOnly property to true.
profilePropertySettings.ReadOnly = true

' Get the current AllowAnonymous property value.
Console.WriteLine( _
    "Current AllowAnonymous value: '{0}'", profilePropertySettings.AllowAnonymous)

' Set the AllowAnonymous property to true.
profilePropertySettings.AllowAnonymous = true

' Get the current SerializeAs property value.
Console.WriteLine( _
    "Current SerializeAs value: '{0}'", profilePropertySettings.SerializeAs)

' Set the SerializeAs property to SerializationMode.Binary.
profilePropertySettings.SerializeAs = SerializationMode.Binary

' Get the current Type property value.
Console.WriteLine( _
    "Current Type value: '{0}'", profilePropertySettings.Type)

' Set the Type property to "System.DateTime".
profilePropertySettings.Type = "System.DateTime"

' Get the current DefaultValue property value.
Console.WriteLine( _
    "Current DefaultValue value: '{0}'", profilePropertySettings.DefaultValue)

' Set the DefaultValue property to "March 16, 2004".
profilePropertySettings.DefaultValue = "March 16, 2004"

' Get the current ProviderName property value.
            Console.WriteLine( _
                "Current ProviderName value: '{0}'", profilePropertySettings.Provider)

' Set the ProviderName property to "AspNetSqlRoleProvider".
            profilePropertySettings.Provider = "AspNetSqlRoleProvider"

' Get the current Name property value.
Console.WriteLine( _
    "Current Name value: '{0}'", profilePropertySettings.Name)

' Set the Name property to "LastAccessDate".
profilePropertySettings.Name = "LastAccessDate"

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

' Add a new group.
Dim newPropGroup As ProfileGroupSettings = new ProfileGroupSettings("Forum")
profileSection.PropertySettings.GroupSettings.Add(newPropGroup)

' Add a new PropertySettings to the group.
Dim newProp As ProfilePropertySettings = new ProfilePropertySettings("AvatarImage")
newProp.Type = "System.String, System.dll"
newPropGroup.PropertySettings.Add(newProp)

' Remove a PropertySettings from the group.
newPropGroup.PropertySettings.Remove("AvatarImage")
newPropGroup.PropertySettings.RemoveAt(0)

' Clear all PropertySettings from the group.
newPropGroup.PropertySettings.Clear()
