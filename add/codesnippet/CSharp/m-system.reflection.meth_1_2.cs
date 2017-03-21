        // Create a Type object representing class Example, and
        // get a MethodInfo representing the generic method.
        //
        Type ex = typeof(Example);
        MethodInfo mi = ex.GetMethod("Generic");

        DisplayGenericMethodInfo(mi);

        // Assign the int type to the type parameter of the Example 
        // method.
        //
        MethodInfo miConstructed = mi.MakeGenericMethod(typeof(int));

        DisplayGenericMethodInfo(miConstructed);