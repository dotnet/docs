

//NCLCustomWebClient
#using <System.dll>

using namespace System;
using namespace System::Net;

public ref class CustomWebClient: public WebClient
{
protected:

   //<snippet1>
   virtual WebRequest^ GetWebRequest ( Uri^ address ) override
   {
      WebRequest^ request = dynamic_cast<WebRequest^>(WebClient::GetWebRequest( address ));

      // Perform any customizations on the request.
      // This version of WebClient always preauthenticates.
      request->PreAuthenticate = true;
      return request;
   }
   //</snippet1>

   // <snippet2>
   virtual WebResponse^ GetWebResponse( WebRequest^ request ) override
   {
      WebResponse^ response = WebClient::GetWebResponse( request );

      // Perform any custom actions with the response ...
      return response;
   }
   // </snippet2>

   // <snippet3>
   virtual WebResponse^ GetWebResponse( WebRequest^ request, IAsyncResult^ result ) override
   {
      WebResponse^ response = WebClient::GetWebResponse( request, result );

      // Perform any custom actions with the response ...
      return response;
   }
   // </snippet3>

   // <snippet4>
   virtual void OnDownloadDataCompleted( DownloadDataCompletedEventArgs ^ e ) override
   {
      // Here you can perform any custom actions before the event is raised
      // and event handlers are called...
      WebClient::OnDownloadDataCompleted( e );

      // Here you can perform any post event actions...
   }
   // </snippet4>

   // <snippet5>
   virtual void OnDownloadFileCompleted( System::ComponentModel::AsyncCompletedEventArgs ^ e ) override
   {
      // Here you can perform any custom actions before the event is raised
      // and event handlers are called...
      WebClient::OnDownloadFileCompleted( e );

      // Here you can perform any post event actions...
   }
   // </snippet5>

   // <snippet6>
   virtual void OnDownloadStringCompleted( DownloadStringCompletedEventArgs ^ e ) override
   {
      // Here you can perform any custom actions before the event is raised
      // and event handlers are called...
      WebClient::OnDownloadStringCompleted( e );

      // Here you can perform any post event actions...
   }
   // </snippet6>

   // <snippet7>
   virtual void OnOpenReadCompleted( OpenReadCompletedEventArgs ^ e ) override
   {
      // Here you can perform any custom actions before the event is raised
      // and event handlers are called...
      WebClient::OnOpenReadCompleted( e );

      // Here you can perform any post event actions...
   }
   // </snippet7>

   // <snippet8>
   virtual void OnOpenWriteCompleted( OpenWriteCompletedEventArgs ^ e ) override
   {
      // Here you can perform any custom actions before the event is raised
      // and event handlers are called...
      WebClient::OnOpenWriteCompleted( e );

      // Here you can perform any post event actions...
   }
   // </snippet8>

   // <snippet9>
   virtual void OnUploadDataCompleted( UploadDataCompletedEventArgs ^ e ) override
   {
      // Here you can perform any custom actions before the event is raised
      // and event handlers are called...
      WebClient::OnUploadDataCompleted( e );

      // Here you can perform any post event actions...
   }
   // </snippet9>

   // <snippet10>
   virtual void OnUploadFileCompleted( UploadFileCompletedEventArgs ^ e ) override
   {
      // Here you can perform any custom actions before the event is raised
      // and event handlers are called...
      WebClient::OnUploadFileCompleted( e );

      // Here you can perform any post event actions...
   }
   // </snippet10>

   // <snippet11>
   virtual void OnUploadStringCompleted( UploadStringCompletedEventArgs ^ e ) override
   {
      // Here you can perform any custom actions before the event is raised
      // and event handlers are called...
      WebClient::OnUploadStringCompleted( e );

      // Here you can perform any post event actions...
   }
   // </snippet11>

   // <snippet12>
   virtual void OnDownloadProgressChanged( DownloadProgressChangedEventArgs ^ e ) override
   {
      // Here you can perform any custom actions before the event is raised
      // and event handlers are called...
      WebClient::OnDownloadProgressChanged( e );

      // Here you can perform any post event actions...
   }
   // </snippet12>

   // <snippet13>
   virtual void OnUploadProgressChanged( UploadProgressChangedEventArgs ^ e ) override
   {
      // Here you can perform any custom actions before the event is raised
      // and event handlers are called...
      WebClient::OnUploadProgressChanged( e );

      // Here you can perform any post event actions...
   }
   // </snippet13>

   // <snippet14>
   virtual void OnUploadValuesCompleted( UploadValuesCompletedEventArgs ^ e ) override
   {
      // Here you can perform any custom actions before the event is raised
      // and event handlers are called...
      WebClient::OnUploadValuesCompleted( e );
      
      // Here you can perform any post event actions...
   }
   // </snippet14>
};

int main()
{
   CustomWebClient^ newClient = gcnew CustomWebClient;
}

// Output from this example will be vary depending on the host name specified,
// but will be similar to the following.
/*
Cookie:
CustomerID = 13xyz
Domain: .contoso.com
Path: /
Port:
Secure: False
When issued: 1/14/2003 3:20:57 PM
Expires: 1/17/2013 11:14:07 AM (expired? False)
Don't save: False
Comment: 
Uri for comments:
Version: RFC 2965
String: CustomerID = 13xyz
*/
