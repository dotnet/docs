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