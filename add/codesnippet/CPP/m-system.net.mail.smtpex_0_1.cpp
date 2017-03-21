   static SmtpException^ GenerateSmtpException( String^ message, Exception^ innerException )
   {
      return gcnew SmtpException( message,innerException );
   }

