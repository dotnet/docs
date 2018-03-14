// REDMOND\glennha
//<Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

public ref class Example
{
    // The following constructor and private field are used to
    // demonstrate a method bound to an object.
private:
    int test;
    
public:
    Example(int test) { this->test = test; }

    // Declare delegates that can be used to execute the completed 
    // SquareIt dynamic method. The OneParameter delegate can be 
    // used to execute any method with one parameter and a return
    // value, or a method with two parameters and a return value
    // if the delegate is bound to an object.
    //
    //<Snippet2>
private: 
    delegate long long SquareItInvoker(int input);

    //<Snippet12>
    generic<typename TReturn, typename TParameter0> 
        delegate TReturn OneParameter(TParameter0 p0);
    //</Snippet12>
    //</Snippet2>

public:
    static void Main()
    {
        // Example 1: A simple dynamic method.
        //
        // Create an array that specifies the parameter types for the
        // dynamic method. In this example the only parameter is an 
        // int, so the array has only one element.
        //
        //<Snippet3>
        array<Type^>^ methodArgs = { int::typeid };
        //</Snippet3>

        // Create a DynamicMethod. In this example the method is
        // named SquareIt. It is not necessary to give dynamic 
        // methods names. They cannot be invoked by name, and two
        // dynamic methods can have the same name. However, the 
        // name appears in calls stacks and can be useful for
        // debugging. 
        //
        // In this example the return type of the dynamic method is
        // long long. The method is associated with the module that 
        // contains the Example class. Any loaded module could be
        // specified. The dynamic method is like a module-level
        // static method.
        //
        //<Snippet4>
        DynamicMethod^ squareIt = gcnew DynamicMethod(
            "SquareIt", 
            long long::typeid, 
            methodArgs, 
            Example::typeid->Module);
        //</Snippet4>

        // Emit the method body. In this example ILGenerator is used
        // to emit the MSIL. DynamicMethod has an associated type
        // DynamicILInfo that can be used in conjunction with 
        // unmanaged code generators.
        //
        // The MSIL loads the argument, which is an int, onto the 
        // stack, converts the int to a long long, duplicates the top
        // item on the stack, and multiplies the top two items on the
        // stack. This leaves the squared number on the stack, and 
        // all the method has to do is return.
        //
        //<Snippet5>
        ILGenerator^ il = squareIt->GetILGenerator();
        il->Emit(OpCodes::Ldarg_0);
        il->Emit(OpCodes::Conv_I8);
        il->Emit(OpCodes::Dup);
        il->Emit(OpCodes::Mul);
        il->Emit(OpCodes::Ret);
        //</Snippet5>

        // Create a delegate that represents the dynamic method. 
        // Creating the delegate completes the method, and any further 
        // attempts to change the method (for example, by adding more
        // MSIL) are ignored. The following code uses a generic 
        // delegate that can produce delegate types matching any
        // single-parameter method that has a return type.
        //
        //<Snippet6>
        OneParameter<long long, int>^ invokeSquareIt = 
            (OneParameter<long long, int>^)
            squareIt->CreateDelegate(OneParameter<long long, int>::typeid);

        Console::WriteLine("123456789 squared = {0}",
            invokeSquareIt(123456789));
        //</Snippet6>

        // Example 2: A dynamic method bound to an instance.
        //
        // Create an array that specifies the parameter types for a
        // dynamic method. If the delegate representing the method
        // is to be bound to an object, the first parameter must 
        // match the type the delegate is bound to. In the following
        // code the bound instance is of the Example class. 
        //
        //<Snippet13>
        array<Type^>^ methodArgs2 = { Example::typeid, int::typeid };
        //</Snippet13>

        // Create a DynamicMethod. In this example the method has no
        // name. The return type of the method is int. The method 
        // has access to the protected and private data of the 
        // Example class.
        //
        //<Snippet14>
        DynamicMethod^ multiplyHidden = gcnew DynamicMethod(
            "", 
            int::typeid, 
            methodArgs2, 
            Example::typeid);
        //</Snippet14>

        // Emit the method body. In this example ILGenerator is used
        // to emit the MSIL. DynamicMethod has an associated type
        // DynamicILInfo that can be used in conjunction with 
        // unmanaged code generators.
        //
        // The MSIL loads the first argument, which is an instance of
        // the Example class, and uses it to load the value of a 
        // private instance field of type int. The second argument is
        // loaded, and the two numbers are multiplied. If the result
        // is larger than int, the value is truncated and the most 
        // significant bits are discarded. The method returns, with
        // the return value on the stack.
        //
        //<Snippet15>
        ILGenerator^ ilMH = multiplyHidden->GetILGenerator();
        ilMH->Emit(OpCodes::Ldarg_0);

        FieldInfo^ testInfo = Example::typeid->GetField("test",
            BindingFlags::NonPublic | BindingFlags::Instance);

        ilMH->Emit(OpCodes::Ldfld, testInfo);
        ilMH->Emit(OpCodes::Ldarg_1);
        ilMH->Emit(OpCodes::Mul);
        ilMH->Emit(OpCodes::Ret);
        //</Snippet15>

        // Create a delegate that represents the dynamic method. 
        // Creating the delegate completes the method, and any further 
        // attempts to change the method — for example, by adding more
        // MSIL — are ignored. 
        // 
        // The following code binds the method to a new instance
        // of the Example class whose private test field is set to 42.
        // That is, each time the delegate is invoked the instance of
        // Example is passed to the first parameter of the method.
        //
        // The delegate OneParameter is used, because the first
        // parameter of the method receives the instance of Example.
        // When the delegate is invoked, only the second parameter is
        // required. 
        //
        //<Snippet16>
        OneParameter<int, int>^ invoke = (OneParameter<int, int>^)
            multiplyHidden->CreateDelegate(
                OneParameter<int, int>::typeid, 
                gcnew Example(42)
            );

        Console::WriteLine("3 * test = {0}", invoke(3));
        //</Snippet16>
    }
};

void main()
{
    Example::Main();
}
/* This code example produces the following output:

123456789 squared = 15241578750190521
3 * test = 126
 */
//</Snippet1>