		public static SmtpException GenerateSmtpException(SmtpStatusCode status)
		{
			return new SmtpException(status);
		}