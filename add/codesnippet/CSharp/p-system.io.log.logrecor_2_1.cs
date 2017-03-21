				foreach (LogRecord record in sequence1.ReadLogRecords(sequence1.BaseSequenceNumber, LogRecordEnumeratorType.Next))
				{
					byte[] data = new byte[record.Data.Length];
					record.Data.Read(data, 0, (int)record.Data.Length);
					string mystr = enc.GetString(data);
					Console.WriteLine("    {0}", mystr);
				}