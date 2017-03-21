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