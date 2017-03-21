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