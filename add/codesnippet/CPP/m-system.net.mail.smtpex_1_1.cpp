   static SmtpException^ GenerateSmtpException( SmtpStatusCode status )
   {
      return gcnew SmtpException( status );
   }

