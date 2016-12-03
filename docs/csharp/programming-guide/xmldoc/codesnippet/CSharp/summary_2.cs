    // compile with: /doc:DocFileName.xml 

    // the following cref shows how to specify the reference, such that,
    // the compiler will resolve the reference
    /// <summary cref="C{T}">
    /// </summary>
    class A { }

    // the following cref shows another way to specify the reference, 
    // such that, the compiler will resolve the reference
    // <summary cref="C &lt; T &gt;">

    // the following cref shows how to hard-code the reference
    /// <summary cref="T:C`1">
    /// </summary>
    class B { }

    /// <summary cref="A">
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class C<T> { }