using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.IO.Log;

// This sample demonstrate how to create a multiplexed log with two streams. 
// Doing interleaving appends and reading the log records back for both 
// the streams.

namespace MyMultiplexLog
{
	class MyMultiplexLog
	{
		static void Main2(string[] args)
		{
			try
			{
				string myLog = "MyMultiplexLog";
				string logStream1 = "MyMultiplexLog::MyLogStream1";
				string logStream2 = "MyMultiplexLog::MyLogStream2";
				int containerSize = 32 * 1024;

				LogRecordSequence sequence1 = null;
				LogRecordSequence sequence2 = null;

				Console.WriteLine("Creating Multiplexed log with two streams");
				
		// <Snippet11>
		// Create log stream 1.
				sequence1 = new LogRecordSequence(logStream1,
					FileMode.OpenOrCreate,
					FileAccess.ReadWrite,
					FileShare.ReadWrite);

		// Log Extents are shared between the two streams. 
		// Add two extents to sequence1.
				sequence1.LogStore.Extents.Add("MyExtent0", containerSize);
				sequence1.LogStore.Extents.Add("MyExtent1");

		// Create log stream 2.
				sequence2 = new LogRecordSequence(logStream2,
					FileMode.OpenOrCreate,
					FileAccess.ReadWrite,
					FileShare.ReadWrite);
		// </Snippet11>

		// <Snippet13>
		// Start Appending in two streams with interleaving appends.

				SequenceNumber previous1 = SequenceNumber.Invalid;
				SequenceNumber previous2 = SequenceNumber.Invalid;

				Console.WriteLine("Appending interleaving records in stream1 and stream2...");
				Console.WriteLine();
		// Append two records in stream1.
				previous1 = sequence1.Append(
					CreateData("MyLogStream1: Hello World!"),
					SequenceNumber.Invalid,
					SequenceNumber.Invalid,
					RecordAppendOptions.ForceFlush);
				previous1 = sequence1.Append(
					CreateData("MyLogStream1: This is my first Logging App"),
					previous1,
					previous1,
					RecordAppendOptions.ForceFlush);

		// Append two records in stream2.
				previous2 = sequence2.Append(
					CreateData("MyLogStream2: Hello World!"),
					SequenceNumber.Invalid,
					SequenceNumber.Invalid,
					RecordAppendOptions.ForceFlush);
				previous2 = sequence2.Append(
					CreateData("MyLogStream2: This is my first Logging App"),
					previous2,
					previous2,
					RecordAppendOptions.ForceFlush);

		// Append the third record in stream1.
				previous1 = sequence1.Append(CreateData(
					"MyLogStream1: Using LogRecordSequence..."),
					previous1,
					previous1,
					RecordAppendOptions.ForceFlush);
				
		// Append the third record in stream2.
				previous2 = sequence2.Append(
					CreateData("MyLogStream2: Using LogRecordSequence..."),
					previous2,
					previous2,
					RecordAppendOptions.ForceFlush);
		// </Snippet13>
				
		// Read the log records from stream1 and stream2.

				Encoding enc = Encoding.Unicode;
				Console.WriteLine();
				Console.WriteLine("Reading Log Records from stream1...");
				// <Snippet10>
				foreach (LogRecord record in sequence1.ReadLogRecords(sequence1.BaseSequenceNumber, LogRecordEnumeratorType.Next))
				{
					byte[] data = new byte[record.Data.Length];
					record.Data.Read(data, 0, (int)record.Data.Length);
					string mystr = enc.GetString(data);
					Console.WriteLine("    {0}", mystr);
				}
				// </Snippet10>

				Console.WriteLine();             
				Console.WriteLine("Reading the log records from stream2...");
				foreach (LogRecord record in sequence2.ReadLogRecords(sequence2.BaseSequenceNumber, LogRecordEnumeratorType.Next))
				{
					byte[] data = new byte[record.Data.Length];
					record.Data.Read(data, 0, (int)record.Data.Length);
					string mystr = enc.GetString(data);
					Console.WriteLine("    {0}", mystr);
				}
				// <Snippet12>
				Console.WriteLine();

		// Cleanup...
				sequence1.Dispose();
				sequence2.Dispose();
				// </Snippet12>

				LogStore.Delete(myLog);

				Console.WriteLine("Done...");
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception thrown {0} {1}", e.GetType(), e.Message);
			}
		}

	// Converts the given data to Array of ArraySegment<byte> 
		public static IList<ArraySegment<byte>> CreateData(string str)
		{
			Encoding enc = Encoding.Unicode;

			byte[] array = enc.GetBytes(str);

			ArraySegment<byte>[] segments = new ArraySegment<byte>[1];
			segments[0] = new ArraySegment<byte>(array);

			return Array.AsReadOnly<ArraySegment<byte>>(segments);
		}

	}
}

