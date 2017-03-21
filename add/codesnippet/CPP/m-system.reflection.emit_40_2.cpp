    // Set parameter types for the method. The method takes
    // one parameter, and its type is specified by the first
    // type parameter, T.
    array<Type^>^ parameterTypes = {genericTypes[0]};
    sampleMethodBuilder->SetParameters(parameterTypes);

    // Set the return type for the method. The return type is
    // specified by the second type parameter, U.
    sampleMethodBuilder->SetReturnType(genericTypes[1]);