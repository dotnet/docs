		public static SmtpException GenerateSmtpException(SmtpStatusCode status, string message)
		{
			return new SmtpException(status, message);
		}