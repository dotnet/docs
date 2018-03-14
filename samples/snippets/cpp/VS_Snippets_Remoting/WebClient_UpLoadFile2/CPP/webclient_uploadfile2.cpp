

// System::Net::WebClient::UploadFile(String, String, String)
/*
This program demonstrates the 'UploadFile(String, String, String)' method of S"WebClient" class.
It accepts an Uri and the path of a file to be uploaded to the Uri. This file is uploaded to the Uri
provided as input using the 'UploadFile(String, String, String)' method. The custom made site responds back
with whatever was posted to it. Thus the contents of the file are displayed to the console.

Note : The results described were obtained using a custom made site. This behaviour may not be the
same with all other sites. Also certain sites would not accept S"Post" method thereby leading to
an error.It is advisable to construct a site using files accompanying this and provide
url name of this site to the program.
*/
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Text;

public class WebClient_UploadFile {
    public:
    int main()
    {
        try
        {
        // <Snippet1>
            Console::Write( "\nPlease enter the URL to post data to : " );
            String^ uriString = Console::ReadLine();

            // Create a new WebClient instance.
            WebClient^ myWebClient = gcnew WebClient;
            Console::WriteLine
                ("\nPlease enter the fully qualified path of the file to be uploaded to the URL" );
            String^ fileName = Console::ReadLine();
            Console::WriteLine( "Uploading {0} to {1} ...", fileName, uriString );

            // Upload the file to the URL using the HTTP 1.0 POST.
            array<Byte>^responseArray = myWebClient->UploadFile( uriString, "POST", fileName );

            // Decode and display the response.
            Console::WriteLine( "\nResponse Received::The contents of the file uploaded are: \n {0}", 
                System::Text::Encoding::ASCII->GetString( responseArray ));
        // </Snippet1>
        }
        catch ( WebException^ e ) 
        {
            Console::WriteLine( "The following exception was raised: {0}", e->Message );
        }
        catch ( Exception^ e ) 
        {
            Console::WriteLine( "The following exception was raised: {0}", e->Message );
        }
    }
};
