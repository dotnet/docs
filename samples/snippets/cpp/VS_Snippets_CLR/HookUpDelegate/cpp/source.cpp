//<Snippet1>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
using namespace System::Windows::Forms;

//<Snippet2>
public ref class ExampleForm : public Form
{
public:
    ExampleForm() : Form()
    {
        this->Text = "Click me";
    }
};
//</Snippet2>

public ref class Example
{
public:
    static void Main()
    {
        Example^ ex = gcnew Example();
        ex->HookUpDelegate();
    }

private:
    void HookUpDelegate()
    {
        // Load an assembly, for example using the Assembly.Load
        // method. In this case, the executing assembly is loaded, to
        // keep the demonstration simple.
        //
        //<Snippet3>
        Assembly^ assem = Example::typeid->Assembly;
        //</Snippet3>

        // Get the type that is to be loaded, and create an instance
        // of it. Activator::CreateInstance has other overloads, if
        // the type lacks a default constructor. The new instance
        // is stored as type Object, to maintain the fiction that
        // nothing is known about the assembly. (Note that you can
        // get the types in an assembly without knowing their names
        // in advance.)
        //
        //<Snippet4>
        Type^ tExForm = assem->GetType("ExampleForm");
        Object^ exFormAsObj = Activator::CreateInstance(tExForm);
        //</Snippet4>

        // Get an EventInfo representing the Click event, and get the
        // type of delegate that handles the event.
        //
        //<Snippet5>
        EventInfo^ evClick = tExForm->GetEvent("Click");
        Type^ tDelegate = evClick->EventHandlerType;
        //</Snippet5>

        // If you already have a method with the correct signature,
        // you can simply get a MethodInfo for it. 
        //
        //<Snippet6>
        MethodInfo^ miHandler =
            Type::GetType("Example")->GetMethod("LuckyHandler",
                BindingFlags::NonPublic | BindingFlags::Instance);
        //</Snippet6>
			
        // Create an instance of the delegate. Using the overloads
        // of CreateDelegate that take MethodInfo is recommended.
        //
        //<Snippet7>
        Delegate^ d = Delegate::CreateDelegate(tDelegate, this, miHandler);
        //</Snippet7>

        // Get the "add" accessor of the event and invoke it late-
        // bound, passing in the delegate instance. This is equivalent
        // to using the += operator in C#, or AddHandler in Visual
        // Basic. The instance on which the "add" accessor is invoked
        // is the form; the arguments must be passed as an array.
        //
        //<Snippet8>
        MethodInfo^ addHandler = evClick->GetAddMethod();
        array<Object^>^ addHandlerArgs = { d };
        addHandler->Invoke(exFormAsObj, addHandlerArgs);
        //</Snippet8>

        // Event handler methods can also be generated at run time,
        // using lightweight dynamic methods and Reflection.Emit.
        // To construct an event handler, you need the return type
        // and parameter types of the delegate. These can be obtained
        // by examining the delegate's Invoke method. 
        //
        // It is not necessary to name dynamic methods, so the empty 
        // string can be used. The last argument associates the 
        // dynamic method with the current type, giving the delegate
        // access to all the public and private members of Example,
        // as if it were an instance method.
        //
        //<Snippet9>
        Type^ returnType = GetDelegateReturnType(tDelegate);
        if (returnType != void::typeid)
            throw gcnew ApplicationException("Delegate has a return type.");
            
        DynamicMethod^ handler =
            gcnew DynamicMethod("",
                              nullptr,
                              GetDelegateParameterTypes(tDelegate),
                              Example::typeid);
        //</Snippet9>

        // Generate a method body. This method loads a string, calls 
        // the Show method overload that takes a string, pops the
        // return value off the stack (because the handler has no
        // return type), and returns.
        //
        //<Snippet10>
        ILGenerator^ ilgen = handler->GetILGenerator();

        array<Type^>^ showParameters = { String::typeid };
        MethodInfo^ simpleShow =
            MessageBox::typeid->GetMethod("Show", showParameters);

        ilgen->Emit(OpCodes::Ldstr,
            "This event handler was constructed at run time.");
        ilgen->Emit(OpCodes::Call, simpleShow);
        ilgen->Emit(OpCodes::Pop);
        ilgen->Emit(OpCodes::Ret);
        //</Snippet10>

        // Complete the dynamic method by calling its CreateDelegate
        // method. Use the "add" accessor to add the delegate to
        // the invocation list for the event.
        //
        //<Snippet11>
        Delegate^ dEmitted = handler->CreateDelegate(tDelegate);
        addHandler->Invoke(exFormAsObj, gcnew array<Object^> { dEmitted });
        //</Snippet11>

        // Show the form. Clicking on the form causes the two
        // delegates to be invoked.
        //
        //<Snippet12>
        Application::Run((Form^) exFormAsObj);
        //</Snippet12>
    }

    void LuckyHandler(Object^ sender, EventArgs^ e)
    {
        MessageBox::Show("This event handler just happened to be lying around.");
    }

    array<Type^>^ GetDelegateParameterTypes(Type^ d)
    {
        if (d->BaseType != MulticastDelegate::typeid)
            throw gcnew ApplicationException("Not a delegate.");

        MethodInfo^ invoke = d->GetMethod("Invoke");
        if (invoke == nullptr)
            throw gcnew ApplicationException("Not a delegate.");

        array<ParameterInfo^>^ parameters = invoke->GetParameters();
        array<Type^>^ typeParameters = gcnew array<Type^>(parameters->Length);
        for (int i = 0; i < parameters->Length; i++)
        {
            typeParameters[i] = parameters[i]->ParameterType;
        }
        return typeParameters;
    }

    Type^ GetDelegateReturnType(Type^ d)
    {
        if (d->BaseType != MulticastDelegate::typeid)
            throw gcnew ApplicationException("Not a delegate.");

        MethodInfo^ invoke = d->GetMethod("Invoke");
        if (invoke == nullptr)
            throw gcnew ApplicationException("Not a delegate.");

        return invoke->ReturnType;
    }
};

int main()
{
    Example::Main();
}
//</Snippet1>
