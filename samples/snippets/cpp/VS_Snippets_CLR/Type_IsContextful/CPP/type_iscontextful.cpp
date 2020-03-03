
// <Snippet1>
using namespace System;
using namespace System::Runtime::Remoting::Contexts;

public ref class ContextBoundClass: public ContextBoundObject
{
   public:
      String^ Value;
};

public ref class Example
{
public:
   void Demo()
   {
      // Determine whether the types can be hosted in a Context.
      Console::WriteLine("The IsContextful property for the {0} type is {1}.",
                         Example::typeid->Name, Example::typeid->IsContextful);
      Console::WriteLine("The IsContextful property for the {0} type is {1}.",
                         ContextBoundClass::typeid->Name, ContextBoundClass::typeid->IsContextful);
      
      // Determine whether the types are marshalled by reference.
      Console::WriteLine("The IsMarshalByRef property of {0} is {1}.",
                         Example::typeid->Name, Example::typeid->IsMarshalByRef );
      Console::WriteLine("The IsMarshalByRef property of {0} is {1}.",
                         ContextBoundClass::typeid->Name, ContextBoundClass::typeid->IsMarshalByRef );
      
      // Determine whether the types are primitive datatypes.
      Console::WriteLine("{0} is a primitive data type: {1}.",
                         int::typeid->Name, int::typeid->IsPrimitive );
      Console::WriteLine("{0} is a primitive data type: {1}.",
                         String::typeid->Name, String::typeid->IsPrimitive );
   }
};

int main()
{
   Example^ ex = gcnew Example;
   ex->Demo();
}
// The example displays the following output:
//    The IsContextful property for the Example type is False.
//    The IsContextful property for the ContextBoundClass type is True.
//    The IsMarshalByRef property of Example is False.
//    The IsMarshalByRef property of ContextBoundClass is True.
//    Int32 is a primitive data type: True.
//    String is a primitive data type: False.
// </Snippet1>
