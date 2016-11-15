    class Base { }
    class Test<T, U>
        where U : struct
        where T : Base, new() { }