void DownloadStringCallback2( Object^ /*sender*/, DownloadStringCompletedEventArgs^ e )
{
   
   // If the request was not canceled and did not throw
   // an exception, display the resource.
   if (  !e->Cancelled && e->Error == nullptr )
   {
      String^ textString = dynamic_cast<String^>(e->Result);
      Console::WriteLine( textString );
   }
}

