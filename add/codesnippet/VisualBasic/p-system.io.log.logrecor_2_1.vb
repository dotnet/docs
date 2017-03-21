                For Each record In sequence1.ReadLogRecords(sequence1.BaseSequenceNumber, LogRecordEnumeratorType.Next)
                    Dim data(record.Data.Length - 1) As Byte
                    record.Data.Read(data, 0, CInt(Fix(record.Data.Length)))
                    Dim mystr As String = enc.GetString(data)
                    Console.WriteLine("    {0}", mystr)
                Next record