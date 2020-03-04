// <Snippet1>
using namespace System;
using namespace System::Reflection;

public ref class MyClass1
{
private:
    int x;

public:
    int MyMethod()
    {
        return x;
    }
};

int main()
{
    MyClass1^ myClass1 = gcnew MyClass1;
   
    // Get the RuntimeTypeHandle from an object.
    RuntimeTypeHandle myRTHFromObject = Type::GetTypeHandle( myClass1 );
   
    // Get the RuntimeTypeHandle from a type.
    RuntimeTypeHandle myRTHFromType = MyClass1::typeid->TypeHandle;

    Console::WriteLine( "\nmyRTHFromObject.Value:  {0}", myRTHFromObject.Value );
    Console::WriteLine( "myRTHFromObject.GetType():  {0}", myRTHFromObject.GetType() );
    Console::WriteLine( "Get the type back from the handle..." );
    Console::WriteLine( "Type::GetTypeFromHandle(myRTHFromObject):  {0}", 
        Type::GetTypeFromHandle(myRTHFromObject) );

    Console::WriteLine( "\nmyRTHFromObject.Equals(myRTHFromType):  {0}", 
        myRTHFromObject.Equals(myRTHFromType) );

    Console::WriteLine( "\nmyRTHFromType.Value:  {0}", myRTHFromType.Value );
    Console::WriteLine( "myRTHFromType.GetType():  {0}", myRTHFromType.GetType() );
    Console::WriteLine( "Get the type back from the handle..." );
    Console::WriteLine( "Type::GetTypeFromHandle(myRTHFromType):  {0}", 
        Type::GetTypeFromHandle(myRTHFromType) );
}

/* This code example produces output similar to the following:

myRTHFromObject.Value:  3295832
myRTHFromObject.GetType():  System.RuntimeTypeHandle
Get the type back from the handle...
Type::GetTypeFromHandle(myRTHFromObject):  MyClass1

myRTHFromObject.Equals(myRTHFromType):  True

myRTHFromType.Value:  3295832
myRTHFromType.GetType():  System.RuntimeTypeHandle
Get the type back from the handle...
Type::GetTypeFromHandle(myRTHFromType):  MyClass1
 */
// </Snippet1>
