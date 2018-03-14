//<snippet0>
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.IO.Log;

namespace MyFileRecordSequence
{
    public class MyLog
    {
        string logName = "test.log";
        FileRecordSequence sequence = null;
        bool delete = true;

        public MyLog()
        {
            // Create a FileRecordSequence
            sequence = new FileRecordSequence(logName, FileAccess.ReadWrite);
        }

	 //<snippet1>
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
	 //</snippet1>
	 
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
            // Dispose the sequence
            sequence.Dispose();

            // Delete the log file...
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

        // Converts the given data to Array of ArraSegment<byte> 
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
        static void Main(string[] args)
        {
            MyLog log = new MyLog();

            log.AppendRecords();
            log.ReadRecords();
            log.Cleanup();
        }
    }
}
//</snippet0>

