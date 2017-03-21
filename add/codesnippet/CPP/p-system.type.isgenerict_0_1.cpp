generic<typename T, typename U> public ref class Base {};

generic<typename T> public ref class G {};

generic<typename V> public ref class Derived : Base<String^, V>
{
public:
    G<Derived<V>^>^ F;

    ref class Nested {};
};