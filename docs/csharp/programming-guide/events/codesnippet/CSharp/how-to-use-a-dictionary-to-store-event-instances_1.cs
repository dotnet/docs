    public delegate void EventHandler1(int i);
    public delegate void EventHandler2(string s);

    public class PropertyEventsSample
    {
        private System.Collections.Generic.Dictionary<string, System.Delegate> eventTable;

        public PropertyEventsSample()
        {
            eventTable = new System.Collections.Generic.Dictionary<string, System.Delegate>();
            eventTable.Add("Event1", null);
            eventTable.Add("Event2", null);
        }

        public event EventHandler1 Event1
        {
            add
            {
                lock (eventTable)
                {
                    eventTable["Event1"] = (EventHandler1)eventTable["Event1"] + value;
                }
            }
            remove
            {
                lock (eventTable)
                {
                    eventTable["Event1"] = (EventHandler1)eventTable["Event1"] - value;
                }
            }
        }

        public event EventHandler2 Event2
        {
            add
            {
                lock (eventTable)
                {
                    eventTable["Event2"] = (EventHandler2)eventTable["Event2"] + value;
                }
            }
            remove
            {
                lock (eventTable)
                {
                    eventTable["Event2"] = (EventHandler2)eventTable["Event2"] - value;
                }
            }
        }

        internal void RaiseEvent1(int i)
        {
            EventHandler1 handler1;
            if (null != (handler1 = (EventHandler1)eventTable["Event1"]))
            {
                handler1(i);
            }
        }

        internal void RaiseEvent2(string s)
        {
            EventHandler2 handler2;
            if (null != (handler2 = (EventHandler2)eventTable["Event2"]))
            {
                handler2(s);
            }
        }
    }

    public class TestClass
    {
        public static void Delegate1Method(int i)
        {
            System.Console.WriteLine(i);
        }

        public static void Delegate2Method(string s)
        {
            System.Console.WriteLine(s);
        }

        static void Main()
        {
            PropertyEventsSample p = new PropertyEventsSample();

            p.Event1 += new EventHandler1(TestClass.Delegate1Method);
            p.Event1 += new EventHandler1(TestClass.Delegate1Method);
            p.Event1 -= new EventHandler1(TestClass.Delegate1Method);
            p.RaiseEvent1(2);

            p.Event2 += new EventHandler2(TestClass.Delegate2Method);
            p.Event2 += new EventHandler2(TestClass.Delegate2Method);
            p.Event2 -= new EventHandler2(TestClass.Delegate2Method);
            p.RaiseEvent2("TestString");

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
    /* Output:
        2
        TestString
    */