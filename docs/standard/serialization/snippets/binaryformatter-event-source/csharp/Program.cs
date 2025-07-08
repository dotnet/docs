using System;
using System.Diagnostics.Tracing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinaryFormatterEventSample
{
    class Program
    {
        static EventListener? _globalListener = null;

        static void Main(string[] args)
        {
            // First, set up the event listener.
            // Note: We assign it to a static field so that it doesn't get GCed.
            // We also provide a callback that subscribes this listener to all
            // events produced by the well-known BinaryFormatter source.

            _globalListener = new ConsoleEventListener();
            _globalListener.EventSourceCreated += (sender, args) =>
            {
                if (args.EventSource?.Name ==
                    "System.Runtime.Serialization.Formatters.Binary.BinaryFormatterEventSource")
                {
                    ((EventListener?)sender)?
                        .EnableEvents(args.EventSource, EventLevel.LogAlways);
                }
            };

            // Next, create the Person object and serialize it.

            Person originalPerson = new Person()
            {
                FirstName = "Logan",
                LastName = "Edwards",
                FavoriteBook = new Book()
                {
                    Title = "A Tale of Two Cities",
                    Author = "Charles Dickens",
                    Price = 10.25m
                }
            };

            byte[] serializedPerson = SerializePerson(originalPerson);

            // Finally, deserialize the Person object.

            Person rehydratedPerson = DeserializePerson(serializedPerson);

            Console.WriteLine
                ($"Rehydrated person {rehydratedPerson.FirstName} {rehydratedPerson.LastName}");
            Console.Write
                ($"Favorite book: {rehydratedPerson.FavoriteBook?.Title} ");
            Console.Write
                ($"by {rehydratedPerson.FavoriteBook?.Author}, ");
            Console.WriteLine
                ($"list price {rehydratedPerson.FavoriteBook?.Price}");
        }

        private static byte[] SerializePerson(Person p)
        {
            MemoryStream memStream = new MemoryStream();
#pragma warning disable SYSLIB0011 // BinaryFormatter is obsolete
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(memStream, p);
#pragma warning restore SYSLIB0011

            return memStream.ToArray();
        }

        private static Person DeserializePerson(byte[] serializedData)
        {
            MemoryStream memStream = new MemoryStream(serializedData);
#pragma warning disable SYSLIB0011 // BinaryFormatter is obsolete
            BinaryFormatter formatter = new BinaryFormatter();

            return (Person)formatter.Deserialize(memStream);
#pragma warning restore SYSLIB0011
        }
    }

    [Serializable]
    public class Person
    {
        public string? FirstName;
        public string? LastName;
        public Book? FavoriteBook;
    }

    [Serializable]
    public class Book
    {
        public string? Title;
        public string? Author;
        public decimal? Price;
    }

    // A sample EventListener that writes data to System.Console.
    public class ConsoleEventListener : EventListener
    {
        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            base.OnEventWritten(eventData);

            Console.WriteLine($"Event {eventData.EventName} (id={eventData.EventId}) received.");
            if (eventData.PayloadNames != null)
            {
                for (int i = 0; i < eventData.PayloadNames.Count; i++)
                {
                    Console.WriteLine($"{eventData.PayloadNames[i]} = {eventData.Payload?[i]}");
                }
            }
        }
    }
}
