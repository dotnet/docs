	// Read the records added to the log. 
		public void ReadRecords()
		{
			Encoding enc = Encoding.Unicode;

			Console.WriteLine();

			Console.WriteLine("Reading Log Records...");
			try
			{
				foreach (LogRecord record in this.sequence.ReadLogRecords(this.sequence.BaseSequenceNumber, LogRecordEnumeratorType.Next))
				{
					byte[] data = new byte[record.Data.Length];
					record.Data.Read(data, 0, (int)record.Data.Length);
					string mystr = enc.GetString(data);
					Console.WriteLine("    {0}", mystr);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception {0} {1}", e.GetType(), e.Message);
			}

			Console.WriteLine();
		}