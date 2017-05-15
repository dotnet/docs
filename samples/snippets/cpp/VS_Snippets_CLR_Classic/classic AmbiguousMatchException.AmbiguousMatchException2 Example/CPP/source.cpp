// <Snippet1>
using namespace System;
using namespace System::Reflection;

namespace Ambiguity
{
    ref class Myambiguous
    {
    public:

        //The first overload is typed to an Int32
        static void Mymethod(Int32 number)
        {
            Console::WriteLine("I am from 'Int32' method");
        }

        //The second overload is typed to a String^
        static void Mymethod(String^ alpha)
        {
            Console::WriteLine("I am from 'String^' method.");
        }

        static void Main()
        {
            try
            {
                //The following does not cause as exception
                Mymethod(2);    // goes to Mymethod (Int32)
                Mymethod("3");  // goes to Mymethod (String*)
                Type^ Mytype = Type::GetType("Ambiguity.Myambiguous");
                array<Type^>^temp0 = {Int32::typeid};
                MethodInfo^ Mymethodinfo32 = Mytype->GetMethod("Mymethod", temp0);
                array<Type^>^temp1 = {System::String::typeid};
                MethodInfo^ Mymethodinfostr = Mytype->GetMethod("Mymethod", temp1);

                //Invoke a method, utilizing a Int32 integer
                array<Object^>^temp2 = {2};
                Mymethodinfo32->Invoke(nullptr, temp2);

                //Invoke the method utilizing a String^
                array<Object^>^temp3 = {"1"};
                Mymethodinfostr->Invoke(nullptr, temp3);

                //The following line causes an ambiguous exception
                MethodInfo^ Mymethodinfo = Mytype->GetMethod("Mymethod");
            }
            catch (AmbiguousMatchException^ ex)
            {
                Console::WriteLine("\n{0}\n{1}", ex->GetType()->FullName, ex->Message);
            }
            catch (...)
            {
                Console::WriteLine("\nSome other exception.");
            }

            return;
        }
    };
}

int main()
{
    Ambiguity::Myambiguous::Main();
}

//This code produces the following output:
//
// I am from 'Int32' method
// I am from 'String^' method.
// I am from 'Int32' method
// I am from 'String^' method.
//
// System.Reflection.AmbiguousMatchException
// Ambiguous match found.
// </Snippet1>
