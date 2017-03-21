        ' Get the generic type definition from the constructed method,
        ' and show that it's the same as the original definition.
        '
        Dim miDef As MethodInfo = miConstructed.GetGenericMethodDefinition()
        Console.WriteLine(vbCrLf & "The definition is the same: {0}", _
            miDef Is mi)