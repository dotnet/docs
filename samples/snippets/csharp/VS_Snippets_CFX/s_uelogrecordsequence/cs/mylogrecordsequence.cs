// snippet for System.IO.Log.LogRecordSequence
// <Snippet0>
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.IO.Log;

namespace MyLogRecordSequence
{
    public class MyLog
    {
        string logName = "test.log";
        string logContainer = "MyExtent0";
        int containerSize = 32 * 1024;
        LogRecordSequence sequence = null;
        bool delete = true;

        // These are used in the TailPinned event handler.
        public static LogRecordSequence MySequence = null;
        public static bool AdvanceBase = true;

        public MyLog()
        {
	    // <Snippet1>
            // Create a LogRecordSequence.
            sequence = new LogRecordSequence(this.logName,
                                              FileMode.CreateNew,
                                              FileAccess.ReadWrite,
                                              FileShare.None);

            // At least one container/extent must be added for Log Record Sequence.
            sequence.LogStore.Extents.Add(this.logContainer, this.containerSize);
     
            MySequence = sequence;
	    // </Snippet1>

        }

        public void AddExtents()
        {
            // Add two additional extents. The extents are 
            // of the same size as the first extent.
            sequence.LogStore.Extents.Add("MyExtent1");
            sequence.LogStore.Extents.Add("MyExtent2");
        }

        public void EnumerateExtents()
        {
            LogStore store = sequence.LogStore;

            Console.WriteLine("Enumerating Log Extents...");
            Console.WriteLine("    Extent Count: {0} extents", store.Extents.Count);
            Console.WriteLine("    Extents Are...");
            foreach (LogExtent extent in store.Extents)
            {
                Console.WriteLine("      {0} ({1}, {2})",
                                  Path.GetFileName(extent.Path),
                                  extent.Size,
                                  extent.State);
            }
            Console.WriteLine("    Free Extents: {0} Free", store.Extents.FreeCount);   
        }

        public void SetLogPolicy()
        {
            Console.WriteLine();
            Console.WriteLine("Setting current log policy...");

	     // <Snippet2>
            // SET LOG POLICY

            LogPolicy policy = sequence.LogStore.Policy;

            // Set AutoGrow policy. This enables the log to automatically grow
            // when the existing extents are full. New extents are added until
            // we reach the MaximumExtentCount extents.
            // AutoGrow policy is supported only in Windows Vista and not available in R2.
            
            //policy.AutoGrow = true;

            // Set the Growth Rate in terms of extents. This policy specifies
            // "how much" the log should grow. 
            policy.GrowthRate = new PolicyUnit(2, PolicyUnitType.Extents);

            // Set the AutoShrink policy. This enables the log to automatically
            // shrink if the available free space exceeds the shrink percentage. 
            // AutoGrow/shrink policy is supported only in Windows Vista and not available in R2.
            
            //policy.AutoShrinkPercentage = new PolicyUnit(30, PolicyUnitType.Percentage);

            // Set the PinnedTailThreshold policy.
            // A tail pinned event is triggered when there is no
            // log space available and log space may be freed by advancing the base.
            // The user must handle the tail pinned event by advancing the base of the log. 
            // If the user is not able to move the base of the log, the user should report with exception in
            // the tail pinned handler.
            // PinnedTailThreashold policy dictates the amount of space that the TailPinned event requests 
            // for advancing the base of the log. The amount of space can be in percentage or in terms of bytes 
            // which is rounded off to the nearest containers in CLFS. The default is 35 percent.

            
            policy.PinnedTailThreshold = new PolicyUnit(10, PolicyUnitType.Percentage);

            // Set the maximum extents the log can have.
            policy.MaximumExtentCount = 6;
            
            // Set the minimum extents the log can have.
            policy.MinimumExtentCount = 2;
            
            // Set the prefix for new containers that are added. 
            // when AutoGrow is enabled.
            //policy.NewExtentPrefix = "MyLogPrefix";
            
            // Set the suffix number for new containers that are added.
            // when AutoGrow is enabled. 
            policy.NextExtentSuffix = 3;

            // Commit the log policy.
            policy.Commit();

            // Refresh updates the IO.Log policy properties with current log policy 
            // set in the log. 
            policy.Refresh();

            // LOG POLICY END
            // 
            // </Snippet2>

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            // Setting up IO.Log provided capabilities...
            // 

	    // <Snippet3>
            // SET RETRY APPEND

            // IO.Log provides a mechanism similar to AutoGrow.
            // If the existing log is full and an append fails, setting RetryAppend
            // invokes the CLFS policy engine to add new extents and re-tries
            // record appends. If MaximumExtent count has been reached, 
            // a SequenceFullException is thrown. 
            // 

            sequence.RetryAppend = true;

            // RETRY APPEND END
	    // </Snippet3>

	    // <Snippet4>
            // REGISTER FOR TAILPINNED EVENT NOTIFICATIONS

            // Register for TailPinned Event by passing in an event handler.
            // An event is raised when the log full condition is reached.
            // The user should either advance the base sequence number to the 
            // nearest valid sequence number recommended in the tail pinned event or
            // report a failure that it is not able to advance the base sequence 
            // number. 
            //

            sequence.TailPinned += new EventHandler<TailPinnedEventArgs>(HandleTailPinned);  

	    // </Snippet4>
            Console.WriteLine("Done...");
        }

        public void ShowLogPolicy()
        {
            Console.WriteLine();
            Console.WriteLine("Showing current log policy...");

            LogPolicy policy = sequence.LogStore.Policy;

            Console.WriteLine("    Minimum extent count:  {0}", policy.MinimumExtentCount);
            Console.WriteLine("    Maximum extent count:  {0}", policy.MaximumExtentCount);
            Console.WriteLine("    Growth rate:           {0}", policy.GrowthRate);
            Console.WriteLine("    Pinned tail threshold: {0}", policy.PinnedTailThreshold);
            Console.WriteLine("    Auto shrink percent:   {0}", policy.AutoShrinkPercentage);
            Console.WriteLine("    Auto grow enabled:     {0}", policy.AutoGrow);
            Console.WriteLine("    New extent prefix:     {0}", policy.NewExtentPrefix);
            Console.WriteLine("    Next extent suffix:    {0}", policy.NextExtentSuffix);

	}

        // <Snippet5>
        // Append records. Appending three records.  
        public void AppendRecords()
        {
            Console.WriteLine("Appending Log Records...");
            SequenceNumber previous = SequenceNumber.Invalid;

            previous = sequence.Append(CreateData("Hello World!"), SequenceNumber.Invalid, SequenceNumber.Invalid, RecordAppendOptions.ForceFlush);
            previous = sequence.Append(CreateData("This is my first Logging App"), SequenceNumber.Invalid, SequenceNumber.Invalid, RecordAppendOptions.ForceFlush);
            previous = sequence.Append(CreateData("Using LogRecordSequence..."), SequenceNumber.Invalid, SequenceNumber.Invalid, RecordAppendOptions.ForceFlush);
	    
            Console.WriteLine("Done...");
        }
        // </Snippet5>


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

        public void FillLog()
        {
            bool append = true;

            while (append)
            {
                try
                {
                    sequence.Append(CreateData(16 * 1024), SequenceNumber.Invalid, SequenceNumber.Invalid, RecordAppendOptions.ForceFlush);
                }

                catch (SequenceFullException)
                {
                    Console.WriteLine("Log is Full...");
                    append = false;
                }
            }
        }

        // Dispose the record sequence and delete the log file. 
        public void Cleanup()
        {
            // Dispose the sequence
            sequence.Dispose();

            // Delete the log file.
            if (delete)
            {
                try
                {
                    // This deletes the base log file and all the extents associated with the log.
                    LogStore.Delete(this.logName);
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

        public static IList<ArraySegment<byte>> CreateData(int size)
        {
            byte[] array = new byte[size];

            Random rnd = new Random();
            rnd.NextBytes(array);

            ArraySegment<byte>[] segments = new ArraySegment<byte>[1];
            segments[0] = new ArraySegment<byte>(array);

            return Array.AsReadOnly<ArraySegment<byte>>(segments);
        }

        public static SequenceNumber GetAdvanceBaseSeqNumber(SequenceNumber recTargetSeqNum)
        {
            SequenceNumber targetSequenceNumber = SequenceNumber.Invalid;

            Console.WriteLine("Getting actual target sequence number...");
            
            // 
            // Implement the logic for returning a valid sequence number closer to
            // recommended target sequence number. 
            //

            return targetSequenceNumber;
        }

        public static void HandleTailPinned(object arg, TailPinnedEventArgs tailPinnedEventArgs)
        {
            Console.WriteLine("TailPinned has fired");

            // Based on the implementation of a logging application, the log base can be moved
            // to free up more log space and if it is not possible to move the 
            // base, the application should report by throwing an exception.

            if(MyLog.AdvanceBase)
            {
                try
                {
                    // TailPnnedEventArgs has the recommended sequence number and its generated 
                    // based on PinnedTailThreshold policy. 
                    // This does not map to an actual sequence number in the record sequence
                    // but an approximation and potentially frees up the threshold % log space
                    // when the log base is advanced to a valid sequence number closer to the 
                    // recommended sequence number. 
                    // The user should use this sequence number to locate a closest valid sequence
                    // number to advance the base of the log.

                    SequenceNumber recommendedTargetSeqNum = tailPinnedEventArgs.TargetSequenceNumber; 
                    
                    // Get the actual Target sequence number.
                    SequenceNumber actualTargetSeqNum = MyLog.GetAdvanceBaseSeqNumber(recommendedTargetSeqNum);

                    MySequence.AdvanceBaseSequenceNumber(actualTargetSeqNum);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception thrown {0} {1}", e.GetType(), e.Message);
                }
            }
            else
            {
                // Report back Error if under some conditions the log cannot
                // advance the base sequence number.

                Console.WriteLine("Reporting Error! Unable to move the base sequence number!");
                throw new IOException();
            }
        }
    }

    class LogSample
    {
        static void Main(string[] args)
        {
            // Create log record sequence.
            MyLog log = new MyLog();

            // Add additional extents.
            log.AddExtents();

            // Enumerate the current log extents.
            log.EnumerateExtents();

            // Set log policies and register for TailPinned event notifications. 
            log.SetLogPolicy();

            log.ShowLogPolicy();
            
            // Append a few records and read the appended records. 
            log.AppendRecords();
            log.ReadRecords();

            // Fill the Log to trigger log growth...and subsequent TailPinned notifications.
            log.FillLog();

            log.EnumerateExtents();

            log.Cleanup();
        }
    }
}

// </Snippet0>
