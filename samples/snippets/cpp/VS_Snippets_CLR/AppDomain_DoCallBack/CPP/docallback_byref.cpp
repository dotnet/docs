
using namespace System;

// <Snippet3>
public ref class PingPong : public MarshalByRefObject
{
private:
   String^ greetings;

public:
    PingPong()
    {
        greetings = "PING!";
    }

    static void Main()
    {
        AppDomain^ otherDomain = AppDomain::CreateDomain("otherDomain");

        PingPong^ pp = gcnew PingPong();
        pp->MyCallBack();
        pp->greetings = "PONG!";
        otherDomain->DoCallBack(gcnew CrossAppDomainDelegate( pp, &PingPong::MyCallBack));

        // Output:
        //   PING! from defaultDomain
        //   PONG! from defaultDomain
    }

    // Callback will always execute within defaultDomain due to inheritance from
    // MarshalByRefObject
    void MyCallBack()
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

// </Snippet3>
