#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Threading;
using namespace System::Collections;

ref class DNSChanges
{

//<Snippet1>
public:
    static void DoGetHostEntry(String^ hostname)
    {
        IPHostEntry^ host = Dns::GetHostEntry(hostname);

        Console::WriteLine("GetHostEntry({0}) returns:", host->HostName);

        for (int i = 0; i < host->AddressList->Length; i++)
        {
            Console::WriteLine("    {0}", host->AddressList[i]->ToString());			
        }
    }
//</Snippet1>

//<Snippet4>
public:
    static void DoGetHostEntry(IPAddress^ address)
    {
        IPHostEntry^ host = Dns::GetHostEntry(address);

        Console::WriteLine("GetHostEntry({0}) returns HostName: {1}", address->ToString(), host->HostName);
    }
//</Snippet4>

//<Snippet3>
    // Determine the Internet Protocol(IP) addresses for a host.
public:
    static void DoGetHostAddress(String^ hostname)
    {
        array<IPAddress^>^ addresses;
        addresses = Dns::GetHostAddresses(hostname);

        Console::WriteLine("GetHostAddresses({0}) returns:", hostname);
        for each (IPAddress^ address in addresses)
        {
            Console::Write("{0} ", address);
        }
        Console::WriteLine("");
   }
//</Snippet3>

//<Snippet2>
    // Signals when the resolve has finished.
public:
    static ManualResetEvent^ GetHostEntryFinished =
        gcnew ManualResetEvent(false);

    // define the state object for the callback. 
    // use hostName to correlate calls with the proper result.
    ref class ResolveState
    {
    public:
        String^ hostName;
        IPHostEntry^ resolvedIPs;

        ResolveState(String^ host)
        {
            hostName = host;
        }

        property IPHostEntry^ IPs 
        {
            IPHostEntry^ get()
            {
                return resolvedIPs;
            }

            void set(IPHostEntry^ IPs)
            {
                resolvedIPs = IPs;
            }
        }

        property String^ host 
        {
            String^ get()
            {
                return hostName;
            }

            void set(String^ host)
            {
                hostName = host;
            }
        }
    };

    // Record the IPs in the state object for later use.
    static void GetHostEntryCallback(IAsyncResult^ ar)
    {
        ResolveState^ ioContext = (ResolveState^)(ar->AsyncState);

        ioContext->IPs = Dns::EndGetHostEntry(ar);
        GetHostEntryFinished->Set();
    }


    // Determine the Internet Protocol(IP) addresses for this 
    // host asynchronously.
public:
    static void DoGetHostEntryAsync(String^ hostName)
    {
        GetHostEntryFinished->Reset();
        ResolveState^ ioContext = gcnew ResolveState(hostName);

        Dns::BeginGetHostEntry(ioContext->host,
            gcnew AsyncCallback(GetHostEntryCallback), ioContext);
        // Wait here until the resolve completes 
        // (the callback calls .Set())
        GetHostEntryFinished->WaitOne();

        Console::WriteLine("EndGetHostEntry({0}) returns:", ioContext->host);
      
        for (int i = 0; i < ioContext->IPs->AddressList->Length; i++)
        {
            Console::WriteLine("    {0}", ioContext->IPs->AddressList[i]->ToString());
        }

//      for each (IPAddress^ address in ioContext->IPs)
//      {
//          Console::WriteLine("{0} ", address);
//      }
    }
//</Snippet2>
};

int main()
{
    DNSChanges::DoGetHostEntry("www.contoso.com");
    DNSChanges::DoGetHostEntry(IPAddress::Parse("127.0.0.1"));
    DNSChanges::DoGetHostAddress("www.contoso.com");
    DNSChanges::DoGetHostEntryAsync("");
}
