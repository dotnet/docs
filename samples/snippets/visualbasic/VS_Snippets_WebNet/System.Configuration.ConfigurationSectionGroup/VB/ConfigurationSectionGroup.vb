 '<Snippet1>
Imports System
Imports System.Collections
Imports System.Configuration

Class UsingConfigurationSectionGroup
   Private Shared indentLevel As Integer = 0
    
    Public Shared Sub Main(ByVal args() As String)

        '<Snippet10>
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
    '</Snippet10>

    Shared Sub ShowSectionGroupCollectionInfo( _
        ByVal sectionGroups _
        As ConfigurationSectionGroupCollection)

        Dim group As ConfigurationSectionGroup
        For Each group In sectionGroups
            ShowSectionGroupInfo(group)
        Next group
    End Sub 'ShowSectionGroupCollectionInfo

    '<Snippet2>
    Shared Sub ShowSectionGroupInfo( _
    ByVal sectionGroup As ConfigurationSectionGroup)
        '<Snippet3>
        ' Get the section group name.
        indent("Section Group Name: " + sectionGroup.Name)
        '</Snippet3>

        '<Snippet11>
        ' Get the fully qualified section group name.
        indent("Section Group Name: " + sectionGroup.SectionGroupName)
        '</Snippet11>

        indentLevel += 1

        '<Snippet4>
        indent("Type: " + sectionGroup.Type)
        '</Snippet4>
        '<Snippet5>
        indent("Is Group Required?: " + _
           sectionGroup.IsDeclarationRequired.ToString())
        '</Snippet5>
        '<Snippet6>
        indent("Is Group Declared?: " + _
            sectionGroup.IsDeclared.ToString())
        '</Snippet6>
        indent("Contained Sections:")

        indentLevel += 1
        '<Snippet7>
        Dim section As ConfigurationSection
        For Each section In sectionGroup.Sections
            indent("Section Name:" + section.SectionInformation.Name)
        Next section
        '</Snippet7>
        indentLevel -= 1

        If (sectionGroup.SectionGroups.Count > 0) Then
            indent("Contained Section Groups:")

            indentLevel += 1
            '<Snippet8>
            Dim sectionGroups As ConfigurationSectionGroupCollection = _
                sectionGroup.SectionGroups
            ShowSectionGroupCollectionInfo(sectionGroups)
            '</Snippet8>
            indentLevel -= 1
        End If

        indent("")
        indentLevel -= 1

    End Sub 'ShowSectionGroupInfo
    '</Snippet2>
    Shared Sub indent(ByVal text As String)
        Dim i As Integer
        For i = 0 To indentLevel - 1
            Console.Write("  ")
        Next i
        Console.WriteLine(Left(text, 79 - indentLevel * 2))
    End Sub 'getSpacer

End Class 'UsingConfigurationSectionGroup 
'</Snippet1>

Class UsingConfigurationSectionGroup2

    '<Snippet12>
    Overloads Shared Sub ForceDeclaration( _
    ByVal sectionGroup As ConfigurationSectionGroup)

        ' Get the application configuration file.
        Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)

        sectionGroup.ForceDeclaration()

        config.Save(ConfigurationSaveMode.Full)

        Console.WriteLine( _
        "Forced declaration for the group: {0}", _
        sectionGroup.Name)
    End Sub 'ForceDeclaration

    '</Snippet12>
    '<Snippet13>
    Overloads Shared Sub ForceDeclaration( _
    ByVal sectionGroup _
    As ConfigurationSectionGroup, _
    ByVal force As Boolean)
        sectionGroup.ForceDeclaration(force)

        Console.WriteLine( _
        "Forced declaration for the group: {0} is {1}", _
        sectionGroup.Name, force.ToString())
    End Sub 'ForceDeclaration

    '</Snippet13>

End Class