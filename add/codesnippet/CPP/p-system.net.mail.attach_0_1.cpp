   static void DisplayFileAttachment( Attachment^ a )
   {
      Console::WriteLine( L"Content Disposition {0}", a->ContentDisposition );
      Console::WriteLine( L"Content Type {0}", a->ContentType );
      Console::WriteLine( L"Name {0}", a->Name );
   }

