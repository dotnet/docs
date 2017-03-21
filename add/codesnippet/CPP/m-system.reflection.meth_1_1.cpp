// Define a class with a generic method.
ref class Example
{
public:
    generic<typename T> static void Generic(T toDisplay)
    {
        Console::WriteLine("\r\nHere it is: {0}", toDisplay);
    }
};