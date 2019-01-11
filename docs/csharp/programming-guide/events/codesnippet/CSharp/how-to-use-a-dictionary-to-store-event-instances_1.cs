using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    public delegate void EventHandler1(int i);
    public delegate void EventHandler2(string s);

    public class PropertyEventsSample
    {
        private readonly object _handlerStorageLock = new object();

        private readonly Dictionary<string, Delegate> _handlers;

        public PropertyEventsSample()
        {
            _handlers = new Dictionary<string, Delegate>
            {
                ["Event1"] = null,
                ["Event2"] = null
            };
        }

        public event EventHandler1 Event1
        {
            add
            {
                lock (_handlerStorageLock)
                {
                    var addList = value;
                    _handlers["Event1"] = AddOperator(_handlers["Event1"], addList);
                }
            }
            remove
            {
                lock (_handlerStorageLock)
                {
                    var removeList = value;
                    _handlers["Event1"] = RemoveOperator(_handlers["Event1"], removeList);
                }
            }
        }

        public event EventHandler2 Event2
        {
            add
            {
                lock (_handlerStorageLock)
                {
                    var addList = value;
                    _handlers["Event2"] = AddOperator(_handlers["Event2"], addList);
                }
            }
            remove
            {
                lock (_handlerStorageLock)
                {
                    var removeList = value;
                    _handlers["Event2"] = RemoveOperator(_handlers["Event2"], removeList);
                }
            }
        }
        /// <summary>
        /// Add addList to eventList
        /// </summary>
        /// <param name="eventList">the delegate list which you want to add into</param>
        /// <param name="addList">the delegate list which you want to add</param>
        /// <returns>Return the latest delegate list after the adding operation</returns>
        private static Delegate AddOperator(Delegate eventList, Delegate addList)
        {
            return addList.GetInvocationList().Aggregate(eventList, AddEvent);
        }
        /// <summary>
        /// Add each addTarget item into the eventList
        /// </summary>
        /// <param name="eventList">the delegate list which you want to add into</param>
        /// <param name="addTarget">the delegate item which you want to add</param>
        /// <returns>Return the latest delegate list after the adding operation</returns>
        private static Delegate AddEvent(Delegate eventList, Delegate addTarget)
        {
            var resultList = eventList;
            if (eventList != null)
            {
                if (!eventList.GetInvocationList().Contains(addTarget))
                    resultList = Delegate.Combine(eventList, addTarget);
            }
            else
                resultList = addTarget;
            return resultList;
        }
        /// <summary>
        /// Remove removeList from eventList
        /// </summary>
        /// <param name="eventList">the delegate list which you want to remove its item from</param>
        /// <param name="removeList">the delegate list which you want to remove</param>
        /// <returns>Return the latest delegate list after the removing operation</returns>
        private static Delegate RemoveOperator(Delegate eventList, Delegate removeList)
        {
            return removeList.GetInvocationList().Aggregate(eventList, RemoveEvent);
        }
        /// <summary>
        /// Remove each removeTarget item from the eventList
        /// </summary>
        /// <param name="eventList">the delegate list which you want to remove its item from</param>
        /// <param name="removeTarget">the delegate item which you want to remove</param>
        /// <returns>Return the latest delegate list after the removing operation</returns>
        private static Delegate RemoveEvent(Delegate eventList, Delegate removeTarget)
        {
            var returnList = eventList;
            if (eventList == null) return returnList;
            while (true)
            {
                var resultList = eventList;
                foreach (var eventItem in eventList.GetInvocationList())
                {
                    if (!eventItem.Equals(removeTarget)) continue;
                    resultList = Delegate.Remove(eventList, eventItem);
                    break;
                }

                var continueRetrieve = resultList != null && resultList.GetInvocationList().Contains(removeTarget);
                if (continueRetrieve)
                {
                    eventList = resultList;
                    continue;
                }
                returnList = resultList;
                break;
            }
            return returnList;
        }

        internal void RaiseEvent1(int i)
        {
            EventHandler1 handler1;
            lock (_handlerStorageLock)
            {
                handler1 = (EventHandler1)_handlers["Event1"];
            }
            handler1?.Invoke(i);
        }

        internal void RaiseEvent2(string s)
        {
            EventHandler2 handler2;
            lock (_handlerStorageLock)
            {
                handler2 = (EventHandler2)_handlers["Event2"];
            }
            handler2?.Invoke(s);
        }
    }

    public static class TestClass
    {
        private static void Delegate1Method1(int i) => Console.Write("Method1: " + i + "/");
        private static void Delegate1Method2(int i) => Console.Write("Method2: " + i + "/");
        private static void Delegate1Method3(int i) => Console.Write("Method3: " + i + "/");
        private static void Delegate2Method1(string s) => Console.Write("Method1: " + s + "/");
        private static void Delegate2Method2(string s) => Console.Write("Method2: " + s + "/");
        private static void Delegate2Method3(string s) => Console.Write("Method3: " + s + "/");

        private static void Main()
        {
            var p = new PropertyEventsSample();

            EventHandler1 handler1Method1 = Delegate1Method1;
            EventHandler1 handler1Method2 = Delegate1Method2;
            EventHandler1 handler1Method3 = Delegate1Method3;

            EventHandler2 handler2Method1 = Delegate2Method1;
            EventHandler2 handler2Method2 = Delegate2Method2;
            EventHandler2 handler2Method3 = Delegate2Method3;

            var combinationHandler1List = handler1Method1 + handler1Method3 + handler1Method2;
            var combinationHandler2List = handler2Method1 + handler2Method3 + handler2Method2;
            p.Event1 += handler1Method1;                        //Method1: 2
            p.Event1 += combinationHandler1List;                //Method1: 2/Method3: 2/Method2: 2
            p.Event1 += (handler1Method3 + handler1Method2);    //Method1: 2/Method3: 2/Method2: 2
            p.Event1 -= (handler1Method2 + handler1Method3);    //Method1: 2
            p.RaiseEvent1(2);
            p.Event2 -= handler2Method3;                        //
            p.Event2 += (handler2Method3 + handler2Method1);    //Method3: TestString/Method1: TestString
            p.Event2 -= combinationHandler2List;                //
            p.RaiseEvent2("TestString");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
    // Output:
    //   Method1: 2
    //   
}
