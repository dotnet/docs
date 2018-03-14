'<Snippet1>
Module Module1

    ''' <summary>
    ''' This code demonstrates the use of the following methods:
    '''     Engine constructor
    '''     Project constructor
    '''     Project.LoadFromXml
    '''     Project.Xml
    '''     BuildPropertyGroupCollection.GetEnumerator
    '''     BuildPropertyGroup.GetEnumerator
    '''     BuildProperty.Name (get)
    '''     BuildProperty.Value (set)
    '''     BuildPropertyGroup.RemoveProperty
    '''     BuildPropertyGroup.AddNewProperty
    ''' </summary>
    ''' <remarks></remarks>
    Sub Main()

        ' Create a new Engine object.
        Dim engine As New Engine(Environment.CurrentDirectory)

        ' Create a new Project object.
        Dim project As New Project(engine)

        ' Load the project with the following XML, which contains
        ' two PropertyGroups.
        project.LoadXml( _
            "<Project xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>" & _
                "<PropertyGroup>" & _
                    "<Optimize>true</Optimize>" & _
                    "<WarningLevel>4</WarningLevel>" & _
                "</PropertyGroup>" & _
                "<PropertyGroup>" & _
                    "<OutputPath>bin\debug\</OutputPath>" & _
                    "<RemoveThisPropertyPlease>1</RemoveThisPropertyPlease>" & _
                "</PropertyGroup>" & _
            "</Project>")

        ' Iterate through each PropertyGroup in the Project.  There are two.
        For Each pg As BuildPropertyGroup In project.PropertyGroups

            Dim propertyToRemove As BuildProperty
            propertyToRemove = Nothing

            ' Iterate through each Property in the PropertyGroup.
            For Each buildProperty As BuildProperty In pg

                ' If the property's name is "RemoveThisPropertyPlease", then
                ' store a reference to this property in a local variable,
                ' so we can remove it later.
                If buildProperty.Name = "RemoveThisPropertyPlease" Then
                    propertyToRemove = buildProperty
                End If

                ' If the property's name is "OutputPath", change its value
                ' from "bin\debug\" to "bin\release\".
                If buildProperty.Name = "OutputPath" Then
                    buildProperty.Value = "bin\release\"
                End If

            Next

            ' Remove the property named "RemoveThisPropertyPlease" from the
            ' PropertyGroup
            If Not propertyToRemove Is Nothing Then
                pg.RemoveProperty(propertyToRemove)
            End If

            ' For each PropertyGroup that we found, add to the end of it
            ' a new property called "MyNewProperty".
            pg.AddNewProperty("MyNewProperty", "MyNewValue")

        Next

        '  The project now looks like this:
        ' 
        '      <?xml version="1.0" encoding="utf-16"?>
        '      <Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
        '        <PropertyGroup>
        '          <Optimize>true</Optimize>
        '          <WarningLevel>4</WarningLevel>
        '          <MyNewProperty>MyNewValue</MyNewProperty>
        '        </PropertyGroup>
        '        <PropertyGroup>
        '          <OutputPath>bin\release</OutputPath>
        '          <MyNewProperty>MyNewValue</MyNewProperty>
        '        </PropertyGroup>
        '      </Project>
        Console.WriteLine(project.Xml)

    End Sub

End Module
'</Snippet1>