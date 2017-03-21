generic<typename T> public ref class Outermost
{
public:
    generic<typename U> ref class Inner
    {
    public:
        generic<typename V> ref class Innermost1 {};
        ref class Innermost2 {};
    };
};