Imports System
Imports System.Collections
Imports System.Configuration

Class UsingConfigurationSectionGroup
   Private Shared indentLevel As Integer = 0
    
    Public Shared Sub Main(ByVal args() As String)

        ' Get the application configuration file.
        Dim config As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

        ' Get the collection of the section groups.
        Dim sectionGroups As ConfigurationSectionGroupCollection = _
            config.SectionGroups

        ' Display the section groups.
        ShowSectionGroupCollectionInfo(sectionGroups)
    End Sub 'Main

    Shared Sub ShowSectionGroupCollectionInfo( _
        ByVal sectionGroups _
        As ConfigurationSectionGroupCollection)

        Dim group As ConfigurationSectionGroup
        For Each group In sectionGroups
            ShowSectionGroupInfo(group)
        Next group
    End Sub 'ShowSectionGroupCollectionInfo

    Shared Sub ShowSectionGroupInfo( _
    ByVal sectionGroup As ConfigurationSectionGroup)
        ' Get the section group name.
        indent("Section Group Name: " + sectionGroup.Name)

        ' Get the fully qualified section group name.
        indent("Section Group Name: " + sectionGroup.SectionGroupName)

        indentLevel += 1

        indent("Type: " + sectionGroup.Type)
        indent("Is Group Required?: " + _
           sectionGroup.IsDeclarationRequired.ToString())
        indent("Is Group Declared?: " + _
            sectionGroup.IsDeclared.ToString())
        indent("Contained Sections:")

        indentLevel += 1
        Dim section As ConfigurationSection
        For Each section In sectionGroup.Sections
            indent("Section Name:" + section.SectionInformation.Name)
        Next section
        indentLevel -= 1

        If (sectionGroup.SectionGroups.Count > 0) Then
            indent("Contained Section Groups:")

            indentLevel += 1
            Dim sectionGroups As ConfigurationSectionGroupCollection = _
                sectionGroup.SectionGroups
            ShowSectionGroupCollectionInfo(sectionGroups)
            indentLevel -= 1
        End If

        indent("")
        indentLevel -= 1

    End Sub 'ShowSectionGroupInfo
    Shared Sub indent(ByVal text As String)
        Dim i As Integer
        For i = 0 To indentLevel - 1
            Console.Write("  ")
        Next i
        Console.WriteLine(Left(text, 79 - indentLevel * 2))
    End Sub 'getSpacer

End Class 'UsingConfigurationSectionGroup 