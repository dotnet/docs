        [EventSource(Name = "Contoso-ProductName-ComponentName")]
        public sealed class CustomizedForPerfEventSource : EventSource
        {
            [Event(1, Task = Tasks.Request, Opcode = EventOpcode.Send)]
            public void RequestStart(Guid relatedActivityId, int reqId, string url)
            {
                if (IsEnabled())
                    WriteEventWithRelatedActivityId(1, relatedActivityId, reqId, url);
            }

            [NonEvent]
            unsafe protected void WriteEventWithRelatedActivityId(int eventId, Guid relatedActivityId,
                            int arg1, string arg2)
            {
                if (IsEnabled())
                {
                    if (arg2 == null) arg2 = string.Empty;
                    fixed (char* stringBytes = arg2)
                    {
                        EventData* descrs = stackalloc EventData[2];
                        descrs[0].DataPointer = (IntPtr)(&arg1);
                        descrs[0].Size = 4;
                        descrs[1].DataPointer = (IntPtr)stringBytes;
                        descrs[1].Size = ((arg2.Length + 1) * 2);
                        WriteEventWithRelatedActivityIdCore(eventId,
                        &relatedActivityId, 2, descrs);
                    }
                }
            }

