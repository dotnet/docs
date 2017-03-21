void UploadStringCallback2( Object^ /*sender*/, UploadStringCompletedEventArgs^ e )
{
   String^ reply = dynamic_cast<String^>(e->Result);
   Console::WriteLine( reply );
}

