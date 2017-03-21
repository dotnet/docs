void UploadDataCallback2( Object^ /*sender*/, UploadDataCompletedEventArgs^ e )
{
   array<Byte>^data = dynamic_cast<array<Byte>^>(e->Result);
   String^ reply = System::Text::Encoding::UTF8->GetString( data );
   Console::WriteLine( reply );
}

