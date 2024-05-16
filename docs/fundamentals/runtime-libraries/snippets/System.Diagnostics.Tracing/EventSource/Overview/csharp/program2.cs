//<root>
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace Demo
{
    //<InterfaceSource>
    public interface IMyLogging
    {
        void Error(int errorCode, string message);
        void Warning(string message);
    }

    public sealed class MySource : EventSource, IMyLogging
    {
        public static MySource Log = new();

        [Event(1)]
        public void Error(int errorCode, string message) => WriteEvent(1, errorCode, message);

        [Event(2)]
        public void Warning(string message) => WriteEvent(2, message);
    }
    //</InterfaceSource>

    //<UtilitySource>
    public abstract class UtilBaseEventSource : EventSource
    {
        protected UtilBaseEventSource()
            : base()
        { }

        protected UtilBaseEventSource(bool throwOnEventWriteErrors)
            : base(throwOnEventWriteErrors)
        { }

        // helper overload of WriteEvent for optimizing writing an event containing
        // payload properties that don't align with a provided overload. This prevents
        // EventSource from using the object[] overload which is expensive.
        protected unsafe void WriteEvent(int eventId, int arg1, short arg2, long arg3)
        {
            if (IsEnabled())
            {
                EventSource.EventData* descrs = stackalloc EventSource.EventData[3];
                descrs[0] = new EventData { DataPointer = (IntPtr)(&arg1), Size = 4 };
                descrs[1] = new EventData { DataPointer = (IntPtr)(&arg2), Size = 2 };
                descrs[2] = new EventData { DataPointer = (IntPtr)(&arg3), Size = 8 };
                WriteEventCore(eventId, 3, descrs);
            }
        }
    }

    public sealed class OptimizedEventSource : UtilBaseEventSource
    {
        public static OptimizedEventSource Log = new();

        public static class Keywords
        {
            public const EventKeywords Kwd1 = (EventKeywords)1;
        }

        [Event(1, Keywords = Keywords.Kwd1, Level = EventLevel.Informational, Message = "LogElements called {0}/{1}/{2}.")]
        public void LogElements(int n, short sh, long l) => WriteEvent(1, n, sh, l); // uses the overload we added!
    }
    //</UtilitySource>

    //<ComplexSource>
    public class ComplexComponent : IDisposable
    {
        internal static Dictionary<string, string> _internalState = new();

        private string _name;

        public ComplexComponent(string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            ComplexSource.Log.NewComponent(_name);
        }

        public void SetState(string key, string value)
        {
            lock (_internalState)
            {
                _internalState[key] = value;
                ComplexSource.Log.SetState(_name, key, value);
            }
        }

        private void ExpensiveWork1() => System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(250));
        private void ExpensiveWork2() => System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(250));
        private void ExpensiveWork3() => System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(250));
        private void ExpensiveWork4() => System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(250));

        public void DoWork()
        {
            ComplexSource.Log.ExpensiveWorkStart(_name);

            ExpensiveWork1();
            ExpensiveWork2();
            ExpensiveWork3();
            ExpensiveWork4();

            ComplexSource.Log.ExpensiveWorkStop(_name);
        }

        public void Dispose()
        {
            ComplexSource.Log.ComponentDisposed(_name);
        }
    }

    internal sealed class ComplexSource : EventSource
    {
        public static ComplexSource Log = new();

        public static class Keywords
        {
            public const EventKeywords ComponentLifespan = (EventKeywords)1;
            public const EventKeywords StateChanges = (EventKeywords)(1 << 1);
            public const EventKeywords Performance = (EventKeywords)(1 << 2);
            public const EventKeywords DumpState = (EventKeywords)(1 << 3);
            // a utility keyword for a common combination of keywords users might enable
            public const EventKeywords StateTracking = ComponentLifespan & StateChanges & DumpState;
        }

        protected override void OnEventCommand(EventCommandEventArgs args)
        {
            base.OnEventCommand(args);

            if (args.Command == EventCommand.Enable)
            {
                DumpComponentState();
            }
        }

        [Event(1, Keywords = Keywords.ComponentLifespan, Message = "New component with name '{0}'.")]
        public void NewComponent(string name) => WriteEvent(1, name);

        [Event(2, Keywords = Keywords.ComponentLifespan, Message = "Component with name '{0}' disposed.")]
        public void ComponentDisposed(string name) => WriteEvent(2, name);

        [Event(3, Keywords = Keywords.StateChanges)]
        public void SetState(string name, string key, string value) => WriteEvent(3, name, key, value);

        [Event(4, Keywords = Keywords.Performance)]
        public void ExpensiveWorkStart(string name) => WriteEvent(4, name);

        [Event(5, Keywords = Keywords.Performance)]
        public void ExpensiveWorkStop(string name) => WriteEvent(5, name);

        [Event(6, Keywords = Keywords.DumpState)]
        public void ComponentState(string key, string value) => WriteEvent(6, key, value);

        [NonEvent]
        public void DumpComponentState()
        {
            if (IsEnabled(EventLevel.Informational, Keywords.DumpState))
            {
                lock (ComplexComponent._internalState)
                {
                    foreach (var (key, value) in ComplexComponent._internalState)
                        ComponentState(key, value);
                }
            }
        }
    }
    //</ComplexSource>

    //<Main>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"PID: {System.Diagnostics.Process.GetCurrentProcess().Id}");

            long i = 0;
            while (true)
            {
                using ComplexComponent c1 = new($"COMPONENT_{i++}");
                using ComplexComponent c2 = new($"COMPONENT_{i++}");
                using ComplexComponent c3 = new($"COMPONENT_{i++}");
                using ComplexComponent c4 = new($"COMPONENT_{i++}");

                c1.SetState("key1", "value1");
                c2.SetState("key2", "value2");
                c3.SetState("key3", "value3");
                c4.SetState("key4", "value4");

                c1.DoWork();
                c2.DoWork();
                c3.DoWork();
                c4.DoWork();
            }
        }
    }
    //</Main>
}
//</root>
