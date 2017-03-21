        [EventSource(Name = "Litware-ProductName-ComponentName")]
        public sealed class LitwareComponentNameEventSource : EventSource
        {
            [Event(1, Task = Tasks.Request, Opcode = EventOpcode.Send)]
            public void RequestStart(Guid relatedActivityId, int reqId, string url)
            {
                WriteEventWithRelatedActivityId(1, relatedActivityId, reqId, url);
            }

        }
