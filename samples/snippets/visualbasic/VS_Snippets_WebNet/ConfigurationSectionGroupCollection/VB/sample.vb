Imports System
Imports System.Collections
Imports System.Configuration

'<Snippet1>
Class ListSectionGroupCollectionInfo
    Private Shared indentLevel As Integer = 0

    '<Snippet10>
    Public Overloads Shared Sub Main()
      Dim config As System.Configuration.Configuration = _
       ConfigurationManager.OpenMachineConfiguration()
        Dim mySectionGroupCollection As System.Configuration.ConfigurationSectionGroupCollection = config.SectionGroups
        ShowSectionGroupCollectionInfo(mySectionGroupCollection)
    End Sub
    '</Snippet10>
    Shared Function getSpacer() As String
        Dim spacer As String = ""
        Dim i As Integer
        For i = 0 To indentLevel - 1
            spacer = spacer & "     "
        Next i
        Return spacer
    End Function 'getSpacer
    '<Snippet9>
    Shared Sub ShowSectionGroupCollectionInfo(mySectionGroupCollection As System.Configuration.ConfigurationSectionGroupCollection)
        Dim mySectionGroupName As String
        For Each mySectionGroupName In  mySectionGroupCollection.Keys
            Dim mySectionGroup As System.Configuration.ConfigurationSectionGroup = CType(mySectionGroupCollection(mySectionGroupName), System.Configuration.ConfigurationSectionGroup)
            ShowSectionGroupInfo(mySectionGroup)
        Next mySectionGroupName
    End Sub 'ShowSectionGroupCollectionInfo
    '</Snippet9>
    '<Snippet2>
    Shared Sub ShowSectionGroupInfo(mySectionGroup As System.Configuration.ConfigurationSectionGroup)
        '<Snippet3>
        Console.WriteLine((getSpacer() & "Section Group Name:" & mySectionGroup.Name))
        '</Snippet3>
        indentLevel += 1
        '<Snippet4>
      Console.WriteLine((getSpacer() & "Type:" & mySectionGroup.Type))
        '</Snippet4>
        '<Snippet6>
        Console.WriteLine((getSpacer() & "Is Group Declared?:" & mySectionGroup.IsDeclared))
        '</Snippet6>
        Console.WriteLine((getSpacer() & "Contained Sections:"))
        indentLevel += 1
        '<Snippet7>
        Dim mySectionCollection As System.Configuration.ConfigurationSectionCollection = mySectionGroup.Sections
        Dim mySectionName As String
        For Each mySectionName In mySectionCollection.Keys
            Dim mySection As System.Configuration.ConfigurationSection = CType(mySectionCollection(mySectionName), System.Configuration.ConfigurationSection)
         Console.WriteLine((getSpacer() & "Section Name:" & mySection.SectionInformation.Name))
        Next mySectionName
        '</Snippet7>
        indentLevel -= 1
        Console.WriteLine((getSpacer() & "Contained Section Groups:"))
        indentLevel += 1
        '<Snippet8>
        Dim mySectionGroupCollection As System.Configuration.ConfigurationSectionGroupCollection = mySectionGroup.SectionGroups
        ShowSectionGroupCollectionInfo(mySectionGroupCollection)
        '</Snippet8>
        indentLevel -= 1
    End Sub 'ShowSectionGroupInfo
    '</Snippet2>
End Class 'ListSectionGroupCollectionInfo
'</Snippet1>