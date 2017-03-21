generic<typename T, typename U>
    public ref class Base { };
generic<typename V>
    public ref class Derived : Base<int, V> { };