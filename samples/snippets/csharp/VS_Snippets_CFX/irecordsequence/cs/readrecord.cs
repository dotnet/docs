//<snippet0>

using System; 
using System.IO; 
using System.IO.Log;
using System.Collections.Generic;
using System.Text;


namespace MyFileRecordSequence
{


class ReadRecordsSample 
{
    static SequenceNumber AppendRecord(IRecordSequence sequence, string message, SequenceNumber user, SequenceNumber previous) 
    { 
        MemoryStream data = new MemoryStream();
        BinaryWriter writer = new BinaryWriter(data); 
        writer.Write(message); ArraySegment<byte>[] segments; 
        segments = new ArraySegment<byte>[1]; 
        segments[0] = new ArraySegment<byte>(data.GetBuffer(), 0, (int)data.Length); 
        return sequence.Append(segments, user, previous,RecordAppendOptions.None); 
    } 
    public static void Main(string[] args) 
    { 
        IRecordSequence sequence; 
        sequence = new FileRecordSequence(args[0]); 
        SequenceNumber a, b, c, d; 
        a = AppendRecord(sequence, "This is record A", SequenceNumber.Invalid, SequenceNumber.Invalid); 
        Console.WriteLine("Record A has sequence number System.IO.Log", a); 
        b = AppendRecord(sequence, "This is record B", a, a); 
        Console.WriteLine("Record B has sequence number System.IO.Log", b);
        c = AppendRecord(sequence, "This is record C", a, a); 
        Console.WriteLine("Record C has sequence number System.IO.Log", c); 
        d = AppendRecord(sequence, "This is record D", b, c); 
        Console.WriteLine("Record D has sequence number System.IO.Log", d); 
        foreach(LogRecord record in sequence.ReadLogRecords(a,LogRecordEnumeratorType.Next)) 
        { 
            BinaryReader reader = new BinaryReader(record.Data); 
            Console.WriteLine("System.IO.Log: T:System.IO.Log.IRecordSequence", record.SequenceNumber, reader.ReadString());
        } 
        foreach(LogRecord record in sequence.ReadLogRecords(d, LogRecordEnumeratorType.User)) 
        { 
            BinaryReader reader = new BinaryReader(record.Data); 
            Console.WriteLine("System.IO.Log: T:System.IO.Log.IRecordSequence", record.SequenceNumber, reader.ReadString()); 
        } 
        foreach(LogRecord record in sequence.ReadLogRecords(d, LogRecordEnumeratorType.Previous)) 
        { 
            BinaryReader reader = new BinaryReader(record.Data); 
            Console.WriteLine("System.IO.Log: T:System.IO.Log.IRecordSequence", record.SequenceNumber, reader.ReadString()); 
        } 
    } 
}

//</snippet0>

//<snippet1>

	public class MyLog
	{
		string logName = "test.log";
		FileRecordSequence sequence = null;
		bool delete = true;

		public MyLog()
		{
	    // Create a FileRecordSequence.
			sequence = new FileRecordSequence(logName, FileAccess.ReadWrite);
		}

	//<snippet3>
	// Append records to the record sequence.
		public void AppendRecords()
		{
			Console.WriteLine("Appending Log Records...");
			SequenceNumber previous = SequenceNumber.Invalid;

			previous = sequence.Append(CreateData("Hello World!"), SequenceNumber.Invalid, SequenceNumber.Invalid, RecordAppendOptions.ForceFlush);
			previous = sequence.Append(CreateData("This is my first Logging App"), SequenceNumber.Invalid, SequenceNumber.Invalid, RecordAppendOptions.ForceFlush);
			previous = sequence.Append(CreateData("Using FileRecordSequence..."), SequenceNumber.Invalid, SequenceNumber.Invalid, RecordAppendOptions.ForceFlush);

			Console.WriteLine("Done...");
		}
	//</snippet3>
		 
	//<snippet2>
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
	//</snippet2>

	// Dispose the record sequence and delete the log file. 
		public void Cleanup()
		{
	    // Dispose the sequence.
			sequence.Dispose();

	    // Delete the log file.
			if (delete)
			{
				try
				{
					File.Delete(this.logName);
				}
				catch (Exception e)
				{
					Console.WriteLine("Exception {0} {1}", e.GetType(), e.Message);
				}
			}
		}

	// Converts the given data to an Array of ArraySegment<byte> 
		public static IList<ArraySegment<byte>> CreateData(string str)
		{
			Encoding enc = Encoding.Unicode;

			byte[] array = enc.GetBytes(str);

			ArraySegment<byte>[] segments = new ArraySegment<byte>[1];
			segments[0] = new ArraySegment<byte>(array);

			return Array.AsReadOnly<ArraySegment<byte>>(segments);
		}
	}

	class LogSample
	{
		static void Main2(string[] args)
		{
			MyLog log = new MyLog();

			log.AppendRecords();
			log.ReadRecords();
			log.Cleanup();
		}
	}
//</snippet1>
}

