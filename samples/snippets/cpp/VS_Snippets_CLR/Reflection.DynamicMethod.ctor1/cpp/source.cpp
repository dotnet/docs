//<Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

public ref class Test
{   
};

// Declare a delegate that will be used to execute the completed
// dynamic method.
delegate int HelloInvoker(String^ msg, int ret);

int main()
{
    // Create an array that specifies the types of the parameters
    // of the dynamic method. This method has a string parameter
    // and an int parameter.
    array<Type^>^ helloArgs = {String::typeid, int::typeid};

    // Create a dynamic method with the name "Hello", a return type
    // of int, and two parameters whose types are specified by the
    // array helloArgs. Create the method in the module that
    // defines the Test class.
    DynamicMethod^ hello = gcnew DynamicMethod("Hello", 
        int::typeid,
        helloArgs,
        Test::typeid->Module);

    // <Snippet2>
    // Create an array that specifies the parameter types of the
    // overload of Console.WriteLine to be used in Hello.
    array<Type^>^ writeStringArgs = {String::typeid};
    // Get the overload of Console.WriteLine that has one
    // String parameter.
    MethodInfo^ writeString =
        Console::typeid->GetMethod("WriteLine", writeStringArgs);

    // Get an ILGenerator and emit a body for the dynamic method.
    ILGenerator^ ilgen = hello->GetILGenerator();
    // Load the first argument, which is a string, onto the stack.
    ilgen->Emit(OpCodes::Ldarg_0);
    // Call the overload of Console.WriteLine that prints a string.
    ilgen->EmitCall(OpCodes::Call, writeString, nullptr);
    // The Hello method returns the value of the second argument;
    // to do this, load the onto the stack and return.
    ilgen->Emit(OpCodes::Ldarg_1);
    ilgen->Emit(OpCodes::Ret);
    // </Snippet2>

    // <Snippet3>
    // Create a delegate that represents the dynamic method. This
    // action completes the method, and any further attempts to
    // change the method will cause an exception.
    HelloInvoker^ helloDelegate =
        (HelloInvoker^) hello->CreateDelegate(HelloInvoker::typeid);
    // </Snippet3>

    // Use the delegate to execute the dynamic method. Save and
    // print the return value.
    int returnValue = helloDelegate("\r\nHello, World!", 42);
    Console::WriteLine("helloDelegate(\"Hello, World!\", 42) returned {0}",
        returnValue);

    // Do it again, with different arguments.
    returnValue = helloDelegate("\r\nHi, Mom!", 5280);
    Console::WriteLine("helloDelegate(\"Hi, Mom!\", 5280) returned {0}",
        returnValue);

    // <Snippet4>
    // Create an array of arguments to use with the Invoke method.
    array<Object^>^ delegateArgs = {"\r\nHello, World!", 42};
    // Invoke the dynamic method using the arguments. This is much
    // slower than using the delegate, because you must create an
    // array to contain the arguments, and ValueType arguments
    // must be boxed.
    Object^ returnValueObject = hello->Invoke(nullptr, delegateArgs);
    Console::WriteLine("hello.Invoke returned {0}", returnValueObject);
    // </Snippet4>
}
//</Snippet1>
