//<snippet1>
using System;
using System.IO;
using System.Xml;

namespace Microsoft.Samples.Xml
{
    public class Sample
    {
        private const String filename = "book.xml";

        public static void Main()
        {
            Sample mySample = new Sample();
            mySample.Run(filename);
        }

        public void Run(String args)
        {

            // Create and load the XML document.
            Console.WriteLine("Loading file {0} ...", args);
            XmlDocument doc = new XmlDocument();
            doc.Load(args);

            //Create the event handlers.
            doc.NodeChanged += new XmlNodeChangedEventHandler(this.MyNodeChangedEvent);
            doc.NodeInserted += new XmlNodeChangedEventHandler(this.MyNodeInsertedEvent);

            // Change the book price.
            doc.DocumentElement.LastChild.InnerText = "5.95";

            // Add a new element.
            XmlElement newElem = doc.CreateElement("style");
            newElem.InnerText = "hardcover";
            doc.DocumentElement.AppendChild(newElem);

            Console.WriteLine("\r\nDisplay the modified XML...");
            Console.WriteLine(doc.OuterXml);

        }

        // Handle the NodeChanged event.
        private void MyNodeChangedEvent(Object source, XmlNodeChangedEventArgs args)
        {
            Console.Write("Node Changed Event: <{0}> changed", args.Node.Name);
            if (args.Node.Value != null)
            {
                Console.WriteLine(" with value  {0}", args.Node.Value);
            }
            else
                Console.WriteLine("");
        }

        // Handle the NodeInserted event.
        private void MyNodeInsertedEvent(Object source, XmlNodeChangedEventArgs args)
        {
            Console.Write("Node Inserted Event: <{0}> inserted", args.Node.Name);
            if (args.Node.Value != null)
            {
                Console.WriteLine(" with value {0}", args.Node.Value);
            }
            else
                Console.WriteLine("");
        }

    } // End class 
    //</snippet1>
}