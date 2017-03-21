    Overloads Shared Sub ForceDeclaration( _
    ByVal sectionGroup _
    As ConfigurationSectionGroup, _
    ByVal force As Boolean)
        sectionGroup.ForceDeclaration(force)

        Console.WriteLine( _
        "Forced declaration for the group: {0} is {1}", _
        sectionGroup.Name, force.ToString())
    End Sub 'ForceDeclaration
