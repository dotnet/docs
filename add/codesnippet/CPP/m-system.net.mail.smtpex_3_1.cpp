   static SmtpException^ GenerateSmtpException( String^ message )
   {
      return gcnew SmtpException( message );
   }

