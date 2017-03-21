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
