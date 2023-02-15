//<snippet1>
using namespace System;

namespace GenericsExample1
{
    //<snippet2>
    generic<typename T>
    public ref class SimpleGenericClass
    {
    public:
        T Field;
    };
    //</snippet2>

    public ref class GenericsTest
    {
    public:
        //<snippet3>
        static void Main()
        {
            SimpleGenericClass<String^>^ g = gcnew SimpleGenericClass<String^>();
            g->Field = "A string";
            //...
            Console::WriteLine("SimpleGenericClass.Field           = \"{0}\"", g->Field);
            Console::WriteLine("SimpleGenericClass.Field.GetType() = {0}", g->Field->GetType()->FullName);
        }
        //</snippet3>

       //<snippet4>
        generic<typename T>
        T MyGenericMethod(T arg)
        {
            T temp = arg;
            //...
            return temp;
        }
        //</snippet4>

    };
}  // GenericsExample1

namespace GenericsExample2
{
    //<snippet5>
    ref class A
    {
        generic<typename T>
        T G(T arg)
        {
            T temp = arg;
            //...
            return temp;
        }
    };
    generic<typename T>
    ref class MyGenericClass
    {
        T M(T arg)
        {
            T temp = arg;
            //...
            return temp;
        }
    };
   //</snippet5>
} // GenericsExample2

int main()
{
    GenericsExample1::GenericsTest::Main();
}
//</snippet1>
