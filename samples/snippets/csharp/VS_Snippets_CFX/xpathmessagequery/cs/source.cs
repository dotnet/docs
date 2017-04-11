//<snippet0>
using System;
using System.IO;
using System.Xml;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml.XPath;

namespace MessageQueryExamples
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // The XPathMessageQueryCollection inherits from MessageQueryCollection.
            XPathMessageQueryCollection queryCollection = MessageHelper.SetupQueryCollection();


            // Create a message and a copy of the message. You must create a buffered copy to access the message body.
            Message mess = MessageHelper.CreateMessage();
            MessageBuffer mb = mess.CreateBufferedCopy(int.MaxValue);


            // Evaluate every query in the collection. 
            foreach (XPathMessageQuery q in queryCollection)
            {
                // Evaluate the query. Note the result type is an XPathResult.
                XPathResult qPathResult = q.Evaluate<XPathResult>(mb);

                // Use the XPathResult to determine the result type.
                Console.WriteLine("Result type: {0}", qPathResult.ResultType);

                // The following code prints the result according to the result type.

                if (qPathResult.ResultType == XPathResultType.String)
                    Console.WriteLine("{0} = {1}", q.Expression, qPathResult.GetResultAsString());

                if (qPathResult.ResultType == XPathResultType.NodeSet)
                {
                    // Iterate through the node set.
                    XPathNodeIterator ns = qPathResult.GetResultAsNodeset();
                    foreach (XPathNavigator n in ns)
                        Console.WriteLine("\t{0} = {1}", q.Expression, n.Value);
                }
                if (qPathResult.ResultType == XPathResultType.Number)
                    Console.WriteLine("\t{0} = {1}", q.Expression, qPathResult.GetResultAsNumber());

                if (qPathResult.ResultType == XPathResultType.Boolean)
                    Console.WriteLine("\t{0} ={1}", q.Expression, qPathResult.GetResultAsBoolean());

                if (qPathResult.ResultType == XPathResultType.Error)
                    Console.WriteLine("\tError!");
            }

            Console.WriteLine();

            // The alternate code below demonstrates similar funcionality using a MessageQueryTable.
            // The difference is the KeyValuePair that requires a key to index each value.
            // The code uses the expression as the key, and an arbitrary value for the value.           

            //MessageQueryTable<string> mq = MessageHelper.SetupTable();
            //foreach (KeyValuePair<MessageQuery, string> kv in mq)
            //{
            //    XPathMessageQuery xp = (XPathMessageQuery)kv.Key;
            //    Console.WriteLine("Value = {0}", kv.Value);
            //    Console.WriteLine("{0} = {1}", xp.Expression, xp.Evaluate<string>(mb));
            //}

            Console.ReadLine();
        }
    }

    public class MessageHelper
    {
        static string messageBody =
              "<PurchaseOrder date='today'>" +
                  "<Number>ABC-2009-XYZ</Number>" +
                  "<Department>OnlineSales</Department>" +
                  "<Items>" +
                      "<Item product='nail' quantity='1'>item1</Item>" +
                      "<Item product='screw' quantity='2'>item2</Item>" +
                      "<Item product='brad' quantity='3'>" +
                          "<SpecialOffer/>" +
                          "Special item4" +
                      "</Item>" +
                      "<Item product='SpecialNails' quantity='9'>item5</Item>" +
                      "<Item product='SpecialBrads' quantity='11'>" +
                          "<SpecialOffer/>" +
                          "Special item6" +
                      "</Item>" +
                      "<Item product='hammer' quantity='1'>item7</Item>" +
                      "<Item product='wrench' quantity='2'>item8</Item>" +
                  "</Items>" +
                "<Comments>" +
                "Rush order" +
                "</Comments>" +
              "</PurchaseOrder>";

        public static string xpath = "/s12:Envelope/s12:Body/PurchaseOrder/Items/Item[@quantity = 1]";
        public static string xpath2 = "/s12:Envelope/s12:Body/PurchaseOrder/Items/Item[@product = 'nail']";
        public static string xpath3 = "/s12:Envelope/s12:Body/PurchaseOrder/Comments";
        public static string xpath4 = "count(/s12:Envelope/s12:Body/PurchaseOrder/Items/Item)";
        public static string xpath5 = "substring(string(/s12:Envelope/s12:Body/PurchaseOrder/Number),5,4)";
        public static string xpath6 = "/s12:Envelope/s12:Body/PurchaseOrder/Department='OnlineSales'";
        public static string xpath7 = "//PurchaseOrder/@date";
        public static string xpath8 = "//SpecialOffer/ancestor::Item[@product = 'brad']";

        // Invoke the correlation data function.

        public static string xpath9 = "sm:correlation-data('CorrelationData1')";
        public static string xpath10 = "sm:correlation-data('CorrelationData2')";

        public static string xpath11 = "/s12:Envelope/s12:Body/PurchaseOrder/Items/Item[@quantity = 2]";


        public static Message CreateMessage()
        {
            StringReader stringReader = new StringReader(messageBody);
            XmlTextReader xmlReader = new XmlTextReader(stringReader);
            Message message = Message.CreateMessage(MessageVersion.Soap12WSAddressing10, "http://purchaseorder", xmlReader);

            // Add two correlation properties using lambda expressions. The property names are
            // CorrelationData1 and CorrelationData2. The first goes to "value1" and the
            // second to "value2". You can use your own property names and values.
            CorrelationDataMessageProperty data = new CorrelationDataMessageProperty();

            data.Add("CorrelationData1", () => "value1");
            data.Add("CorrelationData2", () => "value2");
            message.Properties[CorrelationDataMessageProperty.Name] = data;

            return message;
        }



        public static XPathMessageQueryCollection SetupQueryCollection()
        {
            // Create the query collection and add the XPath queries to it. To create
            // the query, you must also use a new XPathMessageContext.

            XPathMessageQueryCollection queryCollection = new XPathMessageQueryCollection();

            XPathMessageContext context = new XPathMessageContext();
            queryCollection.Add(new XPathMessageQuery(xpath, context));
            queryCollection.Add(new XPathMessageQuery(xpath2, context));
            queryCollection.Add(new XPathMessageQuery(xpath3, context));
            queryCollection.Add(new XPathMessageQuery(xpath4, context));
            queryCollection.Add(new XPathMessageQuery(xpath5, context));
            queryCollection.Add(new XPathMessageQuery(xpath6, context));
            queryCollection.Add(new XPathMessageQuery(xpath7, context));
            queryCollection.Add(new XPathMessageQuery(xpath8, context));
            queryCollection.Add(new XPathMessageQuery(xpath9, context));
            queryCollection.Add(new XPathMessageQuery(xpath10, context));
            queryCollection.Add(new XPathMessageQuery(xpath11, context));

            return queryCollection;
        }

        public static MessageQueryTable<string> SetupTable()
        {
            // This is optional code to demonstrate using a MessageQueryTable.
            // Compare this to the MessageQueryCollection.
            MessageQueryTable<string> table = new MessageQueryTable<string>();
            XPathMessageContext context = new XPathMessageContext();


            // The code adds a KeyValuePair to the table. Each pair requires
            // a query used as the Key, and a value that is paired to the key.
            table.Add(new XPathMessageQuery(xpath, context), "value10");
            table.Add(new XPathMessageQuery(xpath2, context), "value20");
            table.Add(new XPathMessageQuery(xpath3, context), "value30");
            table.Add(new XPathMessageQuery(xpath4, context), "value40");
            table.Add(new XPathMessageQuery(xpath5, context), "value50");
            table.Add(new XPathMessageQuery(xpath6, context), "value60");
            table.Add(new XPathMessageQuery(xpath7, context), "value70");
            table.Add(new XPathMessageQuery(xpath8, context), "value80");
            table.Add(new XPathMessageQuery(xpath9, context), "value90");
            table.Add(new XPathMessageQuery(xpath10, context), "value100");
            table.Add(new XPathMessageQuery(xpath11, context), "value110");
            return table;
        }
    }    
}
//</snippet0>
