using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Tracing;

namespace WriteEventRelatedId
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        //<snippet1>
        [EventSource(Name = "Litware-ProductName-ComponentName")]
        public sealed class LitwareComponentNameEventSource : EventSource
        {
            [Event(1, Task = Tasks.Request, Opcode = EventOpcode.Send)]
            public void RequestStart(Guid relatedActivityId, int reqId, string url)
            {
                WriteEventWithRelatedActivityId(1, relatedActivityId, reqId, url);
            }

        }

        //</snippet1>
        //<snippet5>
        [EventSource(Name = "Litware-ProductName-ComponentName")]
        public sealed class LitwareComponentNameEventSource : EventSource
        {
            [Event(1, Task = Tasks.Request, Opcode = EventOpcode.Send)]
            public void RequestStart(Guid relatedActivityId, int reqId, string url)
            {
                WriteEventWithRelatedActivityIdCore(1, relatedActivityId, reqId, url);
            }

        }

        //</snippet5>
        //<snippet2>
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


            //</snippet2>

            //<snippet3>
            #region Keywords / Task / Opcodes
            public static class Tasks
            {
                public const EventTask Request = (EventTask)0x1;
            }
            #endregion
            //</snippet3>

            //<snippet4>
            [Event(2, Level = EventLevel.Informational)]
            public void Info1(string arg1)
            {
                base.WriteEvent(2, arg1);
            }

            //</snippet4>

        }
    }
}
