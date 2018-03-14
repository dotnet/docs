
using namespace System;

// <Snippet1>
public ref class PingPong
{
private:
    static String^ greetings = "PONG!";

public:
    static void Main()
    {
        AppDomain^ otherDomain = AppDomain::CreateDomain("otherDomain");

        greetings = "PING!";
        MyCallBack();
        otherDomain->DoCallBack(gcnew CrossAppDomainDelegate(MyCallBack));

        // Output:
        //   PING! from defaultDomain
        //   PONG! from otherDomain
    }

    static void MyCallBack()
    {
        String^ name = AppDomain::CurrentDomain->FriendlyName;

        if (name == AppDomain::CurrentDomain->SetupInformation->ApplicationName)
        {
            name = "defaultDomain";
        }
        Console::WriteLine(greetings + " from " + name);
    }
};

int main()
{
   PingPong::Main();
}
// </Snippet1>
