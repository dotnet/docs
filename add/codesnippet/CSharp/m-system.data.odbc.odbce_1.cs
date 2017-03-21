		public void DisplayOdbcErrors(OdbcException exception)
		{
			for (int i = 0; i < exception.Errors.Count; i++)
			{
				Console.WriteLine("Index #" + i + "\n" +
					"Error: " + exception.Errors[i].ToString() + "\n");
			}
			Console.ReadLine();
		}