
//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::IO;
using namespace System::Threading;

namespace SystemNetExamples
{
    public ref class ServicePointExample
    {
    public:

        // Pass in the name of the Web page to retrieve.    
        static void PrintResponse(String^ page)
        {

            // Create the request.
            HttpWebRequest^ request;
            Uri^ uri;
			
 

            try
            {
                uri = gcnew Uri(page);
            }
            catch (UriFormatException^ ex) 
            {
                Console::WriteLine(ex->Message);
            }

            request = (HttpWebRequest^) WebRequest::Create(uri); 

            // Get the service point that handles the request's 
            // socket connection.
            ServicePoint^ point = request->ServicePoint;

            // Set the receive buffer size on the underlying socket.
            point->ReceiveBufferSize = 2048;

            // Set the connection lease timeout to infinite.
            point->ConnectionLeaseTimeout = Timeout::Infinite;

            // Send the request.
            HttpWebResponse^ response = 
                (HttpWebResponse^) request->GetResponse();
            Stream^ responseStream = response->GetResponseStream();
            StreamReader^ streamReader = 
                gcnew StreamReader(responseStream);
            try
            {
                // Display the response.
                Console::WriteLine(streamReader->ReadToEnd());
                responseStream->Close();
                response->Close();
            }
            finally
            {
                streamReader->Close();
            }
        }
    };
}

//</Snippet1>

using namespace SystemNetExamples;

int main()
{
    array<String^>^ args = Environment::GetCommandLineArgs();
    String^ page;

    if ((args == nullptr)||(args->Length < 2)||(args[1]->Length == 0))
    {
        page = "http://www.contoso.com/default.html";
    }
    else
    {
        page = args[1];
    }
    ServicePointExample::PrintResponse(page);
}

