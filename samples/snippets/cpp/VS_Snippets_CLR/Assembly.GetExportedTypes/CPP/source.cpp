//<Snippet1>
using namespace System;
using namespace System::Reflection;

namespace ExportedClassExample
{
    public ref class Example sealed
    {
    private:
        Example() 
        {
        }

    public:
        void static EnumerateExportedTypes()
        {
            for each (Type^ exportedType in 
                Example::typeid->Assembly->GetExportedTypes())
            {
                Console::WriteLine(exportedType);
            }
        }
    };

    public ref class PublicClass
    {
    public:
        ref class PublicNestedClass 
        { 
        };

    protected:
        ref class ProtectedNestedClass 
        { 
        };

    internal:
        ref class FriendNestedClass 
        { 
        };

    private:
        ref class PrivateNestedClass
        { 
        };
    };

    ref class FriendClass
    {
    public:
        ref class PublicNestedClass
        { 
        };

    protected:
        ref class ProtectedNestedClass 
        { 
        };

    internal:
        ref class FriendNestedClass 
        { 
        };

    private:
        ref class PrivateNestedClass 
        { 
        };
    };
}

int main()
{
    ExportedClassExample::Example::EnumerateExportedTypes();

    return 0;
}
//</Snippet1>
