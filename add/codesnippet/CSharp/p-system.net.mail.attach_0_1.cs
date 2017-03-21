		public static void DisplayFileAttachment(Attachment a)
		{
			Console.WriteLine("Content Disposition {0}", a.ContentDisposition.ToString());
			Console.WriteLine("Content Type {0}", a.ContentType.ToString());
			Console.WriteLine("Name {0}", a.Name);
		}