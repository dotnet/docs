    using System;    
    using System.Collections.Generic;    

    public delegate void EventHandler1(int i);

    public delegate void EventHandler2(string s);

    public class PropertyEventsSample
    {
        private readonly Dictionary<string, Delegate> _eventTable;
        private readonly List<EventHandler1> _event1List = new List<EventHandler1>();
        private readonly List<EventHandler2> _event2List = new List<EventHandler2>();
        public PropertyEventsSample()
        {
            _eventTable = new Dictionary<string, Delegate>
            {
                {"Event1", null},
                {"Event2", null}
            };
        }

        public event EventHandler1 Event1
        {
            add
            {
                _event1List.Add(value);
                lock (_eventTable)
                {
                    _eventTable["Event1"] = (EventHandler1) _eventTable["Event1"] + value;
                }
            }
            remove
            {
                if (!_event1List.Contains(value)) return;
                _event1List.Remove(value);
                lock (_eventTable)
                {
                    _eventTable["Event1"] = null;
                    foreach (var event1 in _event1List)
                    {
                        _eventTable["Event1"] = (EventHandler1) _eventTable["Event1"] + event1;
                    }
                }
            }
        }

        public event EventHandler2 Event2
        {
            add
            {
                _event2List.Add(value);
                lock (_eventTable)
                {
                    _eventTable["Event2"] = (EventHandler2) _eventTable["Event2"] + value;
                }
            }
            remove
            {
                if (!_event2List.Contains(value)) return;
                _event2List.Remove(value);
                lock (_eventTable)
                {
                    _eventTable["Event2"] = null;
                    foreach (var event2 in _event2List)
                    {
                        _eventTable["Event2"] = (EventHandler2) _eventTable["Event2"] + event2;
                    }
                }
            }
        }

        internal void RaiseEvent1(int i)
        {
            lock (_eventTable)
            {
                var handler1 = (EventHandler1) _eventTable["Event1"];
                handler1?.Invoke(i);
            }
        }

        internal void RaiseEvent2(string s)
        {
            lock (_eventTable)
            {
                var handler2 = (EventHandler2) _eventTable["Event2"];
                handler2?.Invoke(s);
            }
        }
    }

    public static class TestClass
    {
        private static void Delegate1Method(int i)
        {
            Console.WriteLine(i);
        }

        private static void Delegate2Method(string s)
        {
            Console.WriteLine(s);
        }

        private static void Main()
        {
            var p = new PropertyEventsSample();

            p.Event1 += Delegate1Method;
            p.Event1 += Delegate1Method;
            p.Event1 -= Delegate1Method;
            p.RaiseEvent1(2);

            p.Event2 += Delegate2Method;
            p.Event2 += Delegate2Method;
            p.Event2 -= Delegate2Method;
            p.RaiseEvent2("TestString");

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /* Output:
        2
        TestString
    */
