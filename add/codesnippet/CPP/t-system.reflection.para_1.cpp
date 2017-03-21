        // Create an array containing the arguments.
        array<Object^>^ args = {"Argument 1", "Argument 2", "Argument 3" };

        // Initialize a ParameterModifier with the number of parameters.
        ParameterModifier p = ParameterModifier(3);

        // Pass the first and third parameters by reference.
        p[0] = true;
        p[2] = true;

        // The ParameterModifier must be passed as the single element
        // of an array.

        array<ParameterModifier>^ mods = { p };

        // Invoke the method late bound.
        obj->GetType()->InvokeMember("MethodName", BindingFlags::InvokeMethod,
             nullptr, obj, args, mods, nullptr, nullptr);