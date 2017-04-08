//<Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Collections::Generic;

// Define a base class with two type parameters.
generic< class T,class U >
public ref class Base {};

// Define a derived class. The derived class inherits from a constructed
// class that meets the following criteria:
//   (1) Its generic type definition is Base<T, U>.
//   (2) It specifies int for the first type parameter.
//   (3) For the second type parameter, it uses the same type that is used
//       for the type parameter of the derived class.
// Thus, the derived class is a generic type with one type parameter, but
// its base class is an open constructed type with one type argument and
// one type parameter.
generic<class V>
public ref class Derived : Base<int,V> {};

public ref class Test
{
public:
    static void Main()
    {
        Console::WriteLine( 
            L"\r\n--- Display a generic type and the open constructed");
        Console::WriteLine(L"    type from which it is derived.");
      
        // Create a Type object representing the generic type definition
        // for the Derived type. Note the absence of type arguments.
        //
        Type^ derivedType = Derived::typeid;
        DisplayGenericTypeInfo(derivedType);
      
        // Display its open constructed base type.
        DisplayGenericTypeInfo(derivedType->BaseType);
    }


private:
    static void DisplayGenericTypeInfo(Type^ t)
    {
        Console::WriteLine(L"\r\n{0}", t);
        Console::WriteLine(L"\tIs this a generic type definition? {0}",
            t->IsGenericTypeDefinition);
        Console::WriteLine(L"\tIs it a generic type? {0}", t->IsGenericType);
        Console::WriteLine(L"\tDoes it have unassigned generic parameters? {0}",
            t->ContainsGenericParameters);
        if (t->IsGenericType)
        {
         
            // If this is a generic type, display the type arguments.
            //
            array<Type^>^typeArguments = t->GetGenericArguments();
            Console::WriteLine(L"\tList type arguments ({0}):",
                typeArguments->Length);
            System::Collections::IEnumerator^ myEnum = 
                typeArguments->GetEnumerator();
            while (myEnum->MoveNext())
            {
                Type^ tParam = safe_cast<Type^>(myEnum->Current);
            
                // IsGenericParameter is true only for generic type
                // parameters.
                //
                if (tParam->IsGenericParameter)
                {
                    Console::WriteLine( 
                        L"\t\t{0}  (unassigned - parameter position {1})", 
                        tParam, tParam->GenericParameterPosition);
                }
                else
                {
                    Console::WriteLine(L"\t\t{0}", tParam);
                }
            }
        }
    }
};

int main()
{
    Test::Main();
}

/* This example produces the following output:

--- Display a generic type and the open constructed
    type from which it is derived.

Derived`1[V]
        Is this a generic type definition? True
        Is it a generic type? True
        Does it have unassigned generic parameters? True
        List type arguments (1):
                V  (unassigned - parameter position 0)

Base`2[System.Int32,V]
        Is this a generic type definition? False
        Is it a generic type? True
        Does it have unassigned generic parameters? True
        List type arguments (2):
                System.Int32
                V  (unassigned - parameter position 0)
 */
//</Snippet1>
