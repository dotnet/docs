'<Snippet1>
Module Module1
    'You need to add references to Microsoft.Build.BuildEngine and
    'Microsoft.Build.Framework
    Sub Main()
        'Set this to point to the location where the 2.0 clr/tools are installed
        Engine.GlobalEngine.BinPath = "C:\windows\microsoft.net\framework\v2.0.xxxxx"

        'Create a new empty project
        Dim project As New Project()

        'Load a project
        project.Load("c:\temp\validate.proj")

        'Output a header
        Console.WriteLine("Project Properties")
        Console.WriteLine("----------------------------------")

        'Iterate through the various property groups and subsequently
        'through the various properties
        For Each propertyGroup As BuildPropertyGroup In project.PropertyGroups
            For Each prop As BuildProperty In propertyGroup
                Console.WriteLine("{0}:{1}", prop.Name, prop.Value)
            Next
        Next

        Console.WriteLine()
        Console.WriteLine("Project Items")
        Console.WriteLine("----------------------------------")

        'Iterate through the various itemgroups
        'and subsequently through the items
        For Each itemGroup As BuildItemGroup In project.ItemGroups
            For Each item As BuildItem In itemGroup
                Console.WriteLine("{0}:{1}", item.Name, item.Include)
            Next
        Next
    End Sub

End Module
'</Snippet1>