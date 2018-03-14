//<Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Collections::Generic;

namespace Example
{
    public ref class Test
    {
    public:
        static void CreateConstructedType(void)
        {      
            Console::WriteLine("\r\n--- Create a constructed type"
                " from the generic Dictionary`2 type.");
            
            // Create a type object representing 
            // the generic Dictionary`2 type.
    	    Type^ genericType = Type::GetType(
                "System.Collections.Generic.Dictionary`2");
    	    if (genericType != nullptr)
    	    {  
    	        DisplayTypeInfo(genericType);
    	    }
    	    else
    	    {
    	        Console::WriteLine("The type is not found");
    	        return;
    	    }
            
            // Create an array of types to substitute for the type
            // parameters of Dictionary`2. 
            // The key is of type string, and the type to be 
            // contained in the Dictionary`2 is Test.
            array<Type^>^ typeArgs = {String::typeid, Test::typeid};
            Type^ constructedType = 
                genericType->MakeGenericType(typeArgs);
            DisplayTypeInfo(constructedType);
            
            // Compare the type objects obtained above to type objects
            // obtained using typeof() and GetGenericTypeDefinition().
            Console::WriteLine("\r\n--- Compare types obtained by"
                " different methods:");

    	    Type^ definedType = Dictionary<String^, Test^>::typeid;
            Console::WriteLine("\tAre the constructed types "
                "equal? {0}", definedType == constructedType);
            Console::WriteLine("\tAre the generic types equal? {0}", 
                definedType->GetGenericTypeDefinition() == genericType);
        }

    private:
        static void DisplayTypeInfo(Type^ typeToDisplay)
        {   
            Console::WriteLine("\r\n{0}", typeToDisplay);
            Console::WriteLine("\tIs this a generic type definition? "
                "{0}", typeToDisplay->IsGenericTypeDefinition);
            Console::WriteLine("\tIs it a generic type? "
                "{0}", typeToDisplay->IsGenericType);
            
            array<Type^>^ typeArguments = 
                typeToDisplay->GetGenericArguments();
            Console::WriteLine("\tList type arguments ({0}):", 
                typeArguments->Length);
            
            for each (Type^ typeArgument in typeArguments)
            {   
                Console::WriteLine("\t\t{0}", typeArgument);
            }
        }
    };
}

int main(void)
{
    Example::Test::CreateConstructedType();
}

/* This example produces the following output:

--- Create a constructed type from the generic Dictionary`2 type.

System.Collections.Generic.Dictionary`2[KeyType,ValueType]
          Is this a generic type definition? True
          Is it a generic type? True
          List type arguments (2):
                     K
                     V

System.Collections.Generic.Dictionary`2[System.String, Test]
          Is this a generic type definition? False
          Is it a generic type? True
          List type arguments (2):
                     System.String
                     Test

--- Compare types obtained by different methods:
          Are the constructed types equal? True
          Are the generic types equal? True
 */
//</Snippet1>
