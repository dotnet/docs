    // Defining generic parameters for the method makes it a
    // generic method. By convention, type parameters are
    // single alphabetic characters. T and U are used here.
    //
    array<String^>^ genericTypeNames = {"T", "U"};
    array<GenericTypeParameterBuilder^>^ genericTypes =
        sampleMethodBuilder->DefineGenericParameters(
        genericTypeNames);