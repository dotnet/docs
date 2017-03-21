		public static SmtpException GenerateSmtpException(string message, Exception innerException)
		{
			return new SmtpException(message, innerException);
		}