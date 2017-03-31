using System;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.ServiceModel.Channels;
using System.Security.Permissions;

namespace Samples
{
    public class Test
    {
        static void Main()
        {
            // empty.
        }
    }

    //<snippet1>
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        Message GetData();

        [OperationContract]
        void PutData(Message m);
    }
    //</snippet1>


    //<snippet2>
    public class MyService1 : IMyService
    {
        public Message GetData()
        {
            Person p = new Person();
            p.name = "John Doe";
            p.age = 42;
            MessageVersion ver = OperationContext.Current.IncomingMessageVersion;
            return Message.CreateMessage(ver, "GetDataResponse", p);
        }

        public void PutData(Message m)
        {
            // Not implemented.
        }
    }
    [DataContract]
    public class Person
    {
        [DataMember] public string name;
        [DataMember] public int age;
    }
    //</snippet2>

    //<snippet3>
    public class MyService2 : IMyService
    {
        public Message GetData()
        {
            FileStream stream = new FileStream("myfile.xml",FileMode.Open);
            XmlDictionaryReader xdr =
                   XmlDictionaryReader.CreateTextReader(stream, 
                               new XmlDictionaryReaderQuotas());
            MessageVersion ver = 
                OperationContext.Current.IncomingMessageVersion;
            return Message.CreateMessage(ver,"GetDataResponse",xdr);
        }

        public void PutData(Message m)
        {
            // Not implemented.
        }

    }
    //</snippet3>

    //<snippet4>
    public class MyService3 : IMyService
    {
        public Message GetData()
        {
            FaultCode fc = new FaultCode("Receiver");
            MessageVersion ver = OperationContext.Current.IncomingMessageVersion;
                return Message.CreateMessage(ver,fc,"Bad data","GetDataResponse");
        }

        public void PutData(Message m)
        {
            // Not implemented.
        }       
    }
    //</snippet4>

    //<snippet5>
    public class MyService4 : IMyService
    {
        public void PutData(Message m)
        {
            FileStream stream = new FileStream("myfile.xml",FileMode.Create);
            XmlDictionaryWriter xdw =
                XmlDictionaryWriter.CreateTextWriter(stream);
            m.WriteBodyContents(xdw);
            xdw.Flush();
        }

        public Message GetData()
        {
            throw new NotImplementedException();
        }
    }
    //</snippet5>

    //<snippet6>
    public class MyService5 : IMyService
    {
        public void PutData(Message m)
        {
            Person p = m.GetBody<Person>();
            Console.WriteLine(p.name);
        }

        public Message GetData()
        {
            throw new NotImplementedException();
        }
      
    }
}
namespace Samples2
{
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        Message GetData();

        [OperationContract]
        void PutData(Message m);
    }

    [DataContract]
    public class Person
    {
        [DataMember] public string name;
        [DataMember] public int age;
    }
    //</snippet6>

    //<snippet7>
    [ServiceContract]
    public class ForwardingService
    {
        private List<IOutputChannel> forwardingAddresses;

        [OperationContract]
        public void ForwardMessage (Message m)
        {
            //Copy the message to a buffer.
            MessageBuffer mb = m.CreateBufferedCopy(65536);
            
            //Forward to multiple recipients.
            foreach (IOutputChannel channel in forwardingAddresses)
            {
                Message copy = mb.CreateMessage();
                channel.Send(copy);
            }
            
            //Log to a file.
            FileStream stream = new FileStream("log.xml",FileMode.Append);
            mb.WriteMessage(stream);
            stream.Flush();
        }
    }
    //</snippet7>

    //<snippet8>
    public class MyService6 : IMyService
    {
        public void PutData(Message m)
        {
            foreach (MessageHeaderInfo mhi in m.Headers)
            {
                Console.WriteLine(mhi.Name);
            }
        }

        public Message GetData()
        {
            throw new NotImplementedException();
        }
    }
    //</snippet8>

    //<snippet9>
    public class RandomMessage : Message
    {
        override protected  void  OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            Random r = new Random();
            for (int i = 0; i <100000; i++)
            {
                writer.WriteStartElement("number");
                writer.WriteValue(r.Next(1,20));
                writer.WriteEndElement();
            }
        }    
        //code omitted…
    //</snippet9>

        //<snippet10>
        public override MessageHeaders Headers
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override MessageProperties Properties
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override MessageVersion Version
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }
    }

    public class RandomMessage2 : Message
    {
        override protected XmlDictionaryReader OnGetReaderAtBodyContents()
        {
        return new RandomNumbersXmlReader();
        }
        
        override protected void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            XmlDictionaryReader xdr = OnGetReaderAtBodyContents();
            writer.WriteNode(xdr, true); 
        }    
        public override MessageHeaders Headers
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }
        
        public override MessageProperties Properties
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }
        
        public override MessageVersion Version
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }
    }
    
    public class RandomNumbersXmlReader : XmlDictionaryReader
    {
        //code to serve up 100000 random numbers in XML form omitted…

        //</snippet10>
        public override int AttributeCount
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override string BaseURI
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override void Close()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override int Depth
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override bool EOF
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override string GetAttribute(int i)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string GetAttribute(string name, string namespaceURI)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string GetAttribute(string name)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool HasValue
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override bool IsEmptyElement
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override string LocalName
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override string LookupNamespace(string prefix)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool MoveToAttribute(string name, string ns)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool MoveToAttribute(string name)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool MoveToElement()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool MoveToFirstAttribute()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool MoveToNextAttribute()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override XmlNameTable NameTable
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override string NamespaceURI
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override XmlNodeType NodeType
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override string Prefix
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override bool Read()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool ReadAttributeValue()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override ReadState ReadState
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override void ResolveEntity()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string Value
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }
    }


}
