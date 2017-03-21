void UploadFileCallback2( Object^ /*sender*/, UploadFileCompletedEventArgs^ e )
{
   String^ reply = System::Text::Encoding::UTF8->GetString( e->Result );
   Console::WriteLine( reply );
}

