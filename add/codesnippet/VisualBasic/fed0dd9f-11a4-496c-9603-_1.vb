' Add a new PropertySettings to the group.
Dim newProp As ProfilePropertySettings = new ProfilePropertySettings("AvatarImage")
newProp.Type = "System.String, System.dll"
newPropGroup.PropertySettings.Add(newProp)