        ' Create a Type object representing class Example, and
        ' get a MethodInfo representing the generic method.
        '
        Dim ex As Type = GetType(Example)
        Dim mi As MethodInfo = ex.GetMethod("Generic")
        
        DisplayGenericMethodInfo(mi)
        
        ' Assign the Integer type to the type parameter of the Example 
        ' method.
        '
        Dim arguments() As Type = { GetType(Integer) }
        Dim miConstructed As MethodInfo = mi.MakeGenericMethod(arguments)
        
        DisplayGenericMethodInfo(miConstructed)