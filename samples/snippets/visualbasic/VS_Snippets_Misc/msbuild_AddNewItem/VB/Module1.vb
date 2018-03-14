'<Snippet1>
Module Module1

    ''' <summary>
    ''' This code demonstrates the use of the following methods:
    '''     Engine constructor
    '''     Project constructor
    '''     Project.LoadFromXml
    '''     Project.Xml
    '''     BuildItemGroupCollection.GetEnumerator
    '''     BuildItemGroup.GetEnumerator
    '''     BuildItem.Name (get)
    '''     BuildItem.Include (set)
    '''     BuildItem.GetMetadata
    '''     BuildItem.SetMetadata
    '''     BuildItemGroup.RemoveItem
    '''     BuildItemGroup.AddNewItem
    ''' </summary>
    ''' <remarks></remarks>
    Sub Main()

        ' Create a new Engine object.
        Dim engine As New Engine(Environment.CurrentDirectory)

        ' Create a new Project object.
        Dim project As New Project(engine)

        ' Load the project with the following XML, which contains
        ' two ItemGroups.
        project.LoadXml( _
            "<Project xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>" & _
                "<ItemGroup>" & _
                    "<Compile Include='Program.cs'/>" & _
                    "<Compile Include='Class1.cs'/>" & _
                    "<RemoveThisItemPlease Include='readme.txt'/>" & _
                "</ItemGroup>" & _
                "<ItemGroup>" & _
                    "<EmbeddedResource Include='Strings.resx'>" & _
                        "<LogicalName>Strings.resources</LogicalName>" & _
                        "<Culture>fr-fr</Culture>" & _
                    "</EmbeddedResource>" & _
                "</ItemGroup>" & _
            "</Project>" _
            )

        ' Iterate through each ItemGroup in the Project.  There are two.
        For Each ig As BuildItemGroup In project.ItemGroups

            Dim itemToRemove As BuildItem
            itemToRemove = Nothing

            ' Iterate through each Item in the ItemGroup.
            For Each item As BuildItem In ig

                ' If the item's name is "RemoveThisItemPlease", then
                ' store a reference to this item in a local variable,
                ' so we can remove it later.
                If item.Name = "RemoveThisItemPlease" Then
                    itemToRemove = item
                End If

                ' If the item's name is "EmbeddedResource" and it has a metadata Culture
                ' set to "fr-fr", then ...
                If (item.Name = "EmbeddedResource") And (item.GetMetadata("Culture") = "fr-fr") Then
                    ' Change the item's Include path to "FrenchStrings.fr.resx", 
                    ' and add a new metadata Visiable="false".
                    item.Include = "FrenchStrings.fr.resx"
                    item.SetMetadata("Visible", "false")
                End If
            Next

            ' Remove the item named "RemoveThisItemPlease" from the
            ' ItemGroup
            If Not itemToRemove Is Nothing Then
                ig.RemoveItem(itemToRemove)
            End If

            ' For each ItemGroup that we found, add to the end of it
            ' a new item Content with Include="SplashScreen.bmp".
            ig.AddNewItem("Content", "SplashScreen.bmp")
        Next

        ' The project now looks like this:
        '
        '     <?xml version="1.0" encoding="utf-16"?>
        '     <Project xmlns="http:'schemas.microsoft.com/developer/msbuild/2003">
        '       <ItemGroup>
        '         <Compile Include="Program.cs" />
        '         <Compile Include="Class1.cs" />
        '         <Content Include="SplashScreen.bmp" />
        '       </ItemGroup>
        '       <ItemGroup>
        '         <EmbeddedResource Include="FrenchStrings.fr.resx">
        '           <LogicalName>Strings.resources</LogicalName>
        '           <Culture>fr-fr</Culture>
        '           <Visible>false</Visible>
        '         </EmbeddedResource>
        '         <Content Include="SplashScreen.bmp" />
        '       </ItemGroup>
        '     </Project>
        '
        Console.WriteLine(project.Xml)

    End Sub

End Module
'</Snippet1>