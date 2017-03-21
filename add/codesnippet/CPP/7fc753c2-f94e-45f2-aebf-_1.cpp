   static SmtpException^ GenerateSmtpException( SmtpStatusCode status, String^ message )
   {
      return gcnew SmtpException( status,message );
   }

