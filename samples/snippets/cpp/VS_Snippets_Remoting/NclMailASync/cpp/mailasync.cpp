//NclMailASync

//<snippet1>
#using <System.dll>
using namespace System;
using namespace System::Net;
using namespace System::Net::Mail;
using namespace System::Net::Mime;
using namespace System::Threading;
using namespace System::ComponentModel;

static bool mailSent;

static void SendCompletedCallback(Object^ sender, AsyncCompletedEventArgs^ e)
{
    // Get the unique identifier for this asynchronous 
    // operation.
    String^ token = (String^) e->UserState;

    if (e->Cancelled)
    {
        Console::WriteLine("[{0}] Send canceled.", token);
    }
    if (e->Error != nullptr)
    {
        Console::WriteLine("[{0}] {1}", token, 
            e->Error->ToString());
    } else
    {
        Console::WriteLine("Message sent.");
    }
    mailSent = true;
}

int main(array<String^>^ args)
{
    if (args->Length > 1)
    {
        // Command line argument must the the SMTP host.
        SmtpClient^ client = gcnew SmtpClient(args[1]);
        // Specify the e-mail sender.
        //<snippet2>
        // Create a mailing address that includes a UTF8 
        // character in the display name.
        MailAddress^ from = gcnew MailAddress("jane@contoso.com",
            "Jane " + (wchar_t)0xD8 + " Clayton",
            System::Text::Encoding::UTF8);
        //</snippet2>
        // Set destinations for the e-mail message.
        MailAddress^ to = gcnew MailAddress("ben@contoso.com");
        // Specify the message content.
        //<snippet3>
        MailMessage^ message = gcnew MailMessage(from, to);
        message->Body = "This is a test e-mail message sent" +
            " by an application. ";
        // Include some non-ASCII characters in body and 
        // subject.
        String^ someArrows = gcnew String(gcnew array<wchar_t>{L'\u2190', 
            L'\u2191', L'\u2192', L'\u2193'});
        message->Body += Environment::NewLine + someArrows;
        message->BodyEncoding = System::Text::Encoding::UTF8;
        message->Subject = "test message 1" + someArrows;
        message->SubjectEncoding = System::Text::Encoding::UTF8;
        //</snippet3>
        // Set the method that is called back when the send
        // operation ends.
        client->SendCompleted += gcnew
            SendCompletedEventHandler(SendCompletedCallback);
        // The userState can be any object that allows your 
        // callback method to identify this send operation.
        // For this example, the userToken is a string constant.
        String^ userState = "test message1";
        client->SendAsync(message, userState);
        Console::WriteLine("Sending message... press c to" +
            " cancel mail. Press any other key to exit.");
        String^ answer = Console::ReadLine();
        // If the user canceled the send, and mail hasn't been 
        // sent yet,then cancel the pending operation.
        if (answer->ToLower()->StartsWith("c") && mailSent == false)
        {
            client->SendAsyncCancel();
        }
        // Clean up.
        delete message;
        client = nullptr;
        Console::WriteLine("Goodbye.");
    }
    else
    {
        Console::WriteLine("Please give SMTP server name!");
    }
}
//</snippet1>
