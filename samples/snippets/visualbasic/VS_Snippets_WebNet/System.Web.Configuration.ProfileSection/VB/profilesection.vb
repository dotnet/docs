' <Snippet3>
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.Web.Configuration

Namespace Samples.Aspnet.SystemWebConfiguration
    ' Accesses the System.Web.Configuration.ProfileSection members
    ' selected by the user.
    Class UsingProfileSection
        Public Shared Sub Main()
            ' Process the System.Web.Configuration.ProfileSectionobject.
            Try
                ' Get the Web application configuration.
                Dim configuration As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnet")
                
                ' Get the section.
                Dim profileSection As System.Web.Configuration.ProfileSection = CType(configuration.GetSection("system.web/profile"), System.Web.Configuration.ProfileSection)
' <Snippet4>

' Get the current AutomaticSaveEnabled property value.
Console.WriteLine( _
    "Current AutomaticSaveEnabled value: '{0}'", profileSection.AutomaticSaveEnabled)

' Set the AutomaticSaveEnabled property to false.
profileSection.AutomaticSaveEnabled = false

' </Snippet4>
                
' <Snippet5>

' Get the current DefaultProvider property value.
Console.WriteLine( _
    "Current DefaultProvider value: '{0}'", profileSection.DefaultProvider)

' Set the DefaultProvider property to "AspNetSqlProvider".
profileSection.DefaultProvider = "AspNetSqlProvider"

' </Snippet5>
                
' <Snippet6>

' Get the current Inherits property value.
Console.WriteLine( _
    "Current Inherits value: '{0}'", profileSection.Inherits)

' Set the Inherits property to
' "CustomProfiles.MyCustomProfile, CustomProfiles.dll".
profileSection.Inherits = "CustomProfiles.MyCustomProfile, CustomProfiles.dll"

' </Snippet6>
                
' <Snippet7>


' <Snippet10>
' Display all current root ProfilePropertySettings.
Console.WriteLine("Current Root ProfilePropertySettings:")
Dim rootPPSCtr As Integer = 0
For Each rootPPS As ProfilePropertySettings In profileSection.PropertySettings
    Console.WriteLine("  {0}: ProfilePropertySetting '{1}'", ++rootPPSCtr, _
        rootPPS.Name)
Next
' </Snippet10>

' <Snippet11>
' <Snippet14>
' Get and modify a root ProfilePropertySettings object.
Console.WriteLine( _
    "Display and modify 'LastReadDate' ProfilePropertySettings:")
Dim profilePropertySettings As ProfilePropertySettings = _
    profileSection.PropertySettings("LastReadDate")
' </Snippet14>

' <Snippet15>
' Get the current ReadOnly property value.
Console.WriteLine( _
    "Current ReadOnly value: '{0}'", profilePropertySettings.ReadOnly)

' Set the ReadOnly property to true.
profilePropertySettings.ReadOnly = true
' </Snippet15>

' <Snippet16>
' Get the current AllowAnonymous property value.
Console.WriteLine( _
    "Current AllowAnonymous value: '{0}'", profilePropertySettings.AllowAnonymous)

' Set the AllowAnonymous property to true.
profilePropertySettings.AllowAnonymous = true
' </Snippet16>

' <Snippet17>
' Get the current SerializeAs property value.
Console.WriteLine( _
    "Current SerializeAs value: '{0}'", profilePropertySettings.SerializeAs)

' Set the SerializeAs property to SerializationMode.Binary.
profilePropertySettings.SerializeAs = SerializationMode.Binary
' </Snippet17>

' <Snippet18>
' Get the current Type property value.
Console.WriteLine( _
    "Current Type value: '{0}'", profilePropertySettings.Type)

' Set the Type property to "System.DateTime".
profilePropertySettings.Type = "System.DateTime"
' </Snippet18>

' <Snippet19>
' Get the current DefaultValue property value.
Console.WriteLine( _
    "Current DefaultValue value: '{0}'", profilePropertySettings.DefaultValue)

' Set the DefaultValue property to "March 16, 2004".
profilePropertySettings.DefaultValue = "March 16, 2004"
' </Snippet19>

' <Snippet20>
' Get the current ProviderName property value.
            Console.WriteLine( _
                "Current ProviderName value: '{0}'", profilePropertySettings.Provider)

' Set the ProviderName property to "AspNetSqlRoleProvider".
            profilePropertySettings.Provider = "AspNetSqlRoleProvider"
' </Snippet20>

' <Snippet21>
' Get the current Name property value.
Console.WriteLine( _
    "Current Name value: '{0}'", profilePropertySettings.Name)

' Set the Name property to "LastAccessDate".
profilePropertySettings.Name = "LastAccessDate"
' </Snippet21>
' </Snippet11>

' <Snippet12>
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
' </Snippet12>

' <Snippet13>
' Add a new group.
Dim newPropGroup As ProfileGroupSettings = new ProfileGroupSettings("Forum")
profileSection.PropertySettings.GroupSettings.Add(newPropGroup)

' <Snippet22>
' Add a new PropertySettings to the group.
Dim newProp As ProfilePropertySettings = new ProfilePropertySettings("AvatarImage")
newProp.Type = "System.String, System.dll"
newPropGroup.PropertySettings.Add(newProp)
' </Snippet22>

' <Snippet1>
' Remove a PropertySettings from the group.
newPropGroup.PropertySettings.Remove("AvatarImage")
newPropGroup.PropertySettings.RemoveAt(0)
' </Snippet1>

' <Snippet2>
' Clear all PropertySettings from the group.
newPropGroup.PropertySettings.Clear()
' </Snippet2>
' </Snippet13>

' </Snippet7>
                
' <Snippet8>

Console.WriteLine("Current Providers:")
Dim providerCtr As Integer = 0
For Each provider As ProviderSettings In profileSection.Providers
    Console.WriteLine("  {0}: Provider '{1}' of type '{2}'", ++providerCtr, _
        provider.Name, provider.Type)
Next

' Add a new provider.
profileSection.Providers.Add(new ProviderSettings("AspNetSqlProvider", "...SqlProfileProvider"))

' </Snippet8>
                
' <Snippet9>

' Get the current Enabled property value.
Console.WriteLine( _
    "Current Enabled value: '{0}'", profileSection.Enabled)

' Set the Enabled property to false.
profileSection.Enabled = false

' </Snippet9>
                
                ' Update if not locked.
                If Not profileSection.SectionInformation.IsLocked Then
                    configuration.Save()
                    Console.WriteLine("** Configuration updated.")
                Else
                    Console.WriteLine("** Could not update, section is locked.")
                End If
            Catch e As System.ArgumentException
                ' Unknown error.
                Console.WriteLine( _
                    "A invalid argument exception detected in UsingProfileSection Main. Check your")
                Console.WriteLine("command line for errors.")
            End Try
        End Sub
    End Class ' UsingProfileSection.
    
End Namespace ' Samples.Aspnet.SystemWebConfiguration

' </Snippet3>
