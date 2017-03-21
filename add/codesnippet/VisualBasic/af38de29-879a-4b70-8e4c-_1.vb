
        ' Set the module object.
        Dim ModuleAction1 _
        As New HttpModuleAction( _
        "MyModule1Name", "MyModule1Type")
        ' Get the module collection index.
        Dim moduleIndex As Integer = _
        modulesCollection.IndexOf(ModuleAction1)
