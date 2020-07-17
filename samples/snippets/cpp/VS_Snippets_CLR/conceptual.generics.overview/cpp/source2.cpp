//<snippet6>
using namespace System;

public ref class MyEventArgs : EventArgs
{
private:
    String^ msg;
    
public:
    MyEventArgs(String^ messageArg)
    {
        msg = messageArg;
    }
    
    property String^ Message
    {
        String^ get() {return msg;}
    }
};

ref class Dummy
{
//<snippet7>
public:
    event EventHandler<MyEventArgs^>^ MyEvent;
//</snippet7>

    static void Main()
    {
        Dummy^ dummo = gcnew Dummy();

        dummo->DoEvent();
    }

    void DoEvent()
    {
        MyEventArgs^ eArgs = gcnew MyEventArgs("My Event Message");

        MyEvent += gcnew EventHandler<MyEventArgs^>(this, &Dummy::MyEventHandler);
        MyEvent(this, eArgs);
    }

private:
    void MyEventHandler(Object^ sender, MyEventArgs^ eArgs)
    {
        Console::WriteLine(eArgs->Message);
    }
};

int main()
{
    Dummy::Main();
}
//</snippet6>
