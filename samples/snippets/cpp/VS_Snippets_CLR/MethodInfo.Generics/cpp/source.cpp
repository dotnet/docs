//<Snippet1>
using namespace System;
using namespace System::Reflection;

//<Snippet2>
// Define a class with a generic method.
ref class Example
{
public:
    generic<typename T> static void Generic(T toDisplay)
    {
        Console::WriteLine("\r\nHere it is: {0}", toDisplay);
    }
};
//</Snippet2>

void DisplayGenericMethodInfo(MethodInfo^ mi)
{
    Console::WriteLine("\r\n{0}", mi);

    //<Snippet5>
    Console::WriteLine("\tIs this a generic method definition? {0}", 
        mi->IsGenericMethodDefinition);
    //</Snippet5>

    //<Snippet6>
    Console::WriteLine("\tIs it a generic method? {0}", 
        mi->IsGenericMethod);
    //</Snippet6>

    //<Snippet7>
    Console::WriteLine("\tDoes it have unassigned generic parameters? {0}", 
        mi->ContainsGenericParameters);
    //</Snippet7>

    //<Snippet8>
    // If this is a generic method, display its type arguments.
    //
    if (mi->IsGenericMethod)
    {
        array<Type^>^ typeArguments = mi->GetGenericArguments();

        Console::WriteLine("\tList type arguments ({0}):", 
            typeArguments->Length);

        for each (Type^ tParam in typeArguments)
        {
            // IsGenericParameter is true only for generic type
            // parameters.
            //
            if (tParam->IsGenericParameter)
            {
                Console::WriteLine("\t\t{0}  parameter position {1}" +
                    "\n\t\t   declaring method: {2}",
                    tParam,
                    tParam->GenericParameterPosition,
                    tParam->DeclaringMethod);
            }
            else
            {
                Console::WriteLine("\t\t{0}", tParam);
            }
        }
    }
    //</Snippet8>
};

void main()
{
    Console::WriteLine("\r\n--- Examine a generic method.");

    //<Snippet3>
    // Create a Type object representing class Example, and
    // get a MethodInfo representing the generic method.
    //
    Type^ ex = Example::typeid;
    MethodInfo^ mi = ex->GetMethod("Generic");

    DisplayGenericMethodInfo(mi);

    // Assign the int type to the type parameter of the Example 
    // method.
    //
    MethodInfo^ miConstructed = mi->MakeGenericMethod(int::typeid);

    DisplayGenericMethodInfo(miConstructed);
    //</Snippet3>

    // Invoke the method.
    array<Object^>^ args = { 42 };
    miConstructed->Invoke((Object^) 0, args);

    // Invoke the method normally.
    Example::Generic<int>(42);

    //<Snippet4>
    // Get the generic type definition from the closed method,
    // and show it's the same as the original definition.
    //
    MethodInfo^ miDef = miConstructed->GetGenericMethodDefinition();
    Console::WriteLine("\r\nThe definition is the same: {0}",
            miDef == mi);
    //</Snippet4>
};
        
/* This example produces the following output:

--- Examine a generic method.

Void Generic[T](T)
        Is this a generic method definition? True
        Is it a generic method? True
        Does it have unassigned generic parameters? True
        List type arguments (1):
                T  parameter position 0
                   declaring method: Void Generic[T](T)

Void Generic[Int32](Int32)
        Is this a generic method definition? False
        Is it a generic method? True
        Does it have unassigned generic parameters? False
        List type arguments (1):
                System.Int32

Here it is: 42

Here it is: 42

The definition is the same: True

 */
//</Snippet1>
