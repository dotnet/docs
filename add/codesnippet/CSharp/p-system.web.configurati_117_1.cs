
// Get the current Inherits property value.
Console.WriteLine(
    "Current Inherits value: '{0}'", profileSection.Inherits);

// Set the Inherits property to
// "CustomProfiles.MyCustomProfile, CustomProfiles.dll".
profileSection.Inherits = "CustomProfiles.MyCustomProfile, CustomProfiles.dll";
