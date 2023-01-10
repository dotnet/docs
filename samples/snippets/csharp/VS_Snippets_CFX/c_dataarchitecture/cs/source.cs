using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Security;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security.Tokens;
using System.ServiceModel.Description;

namespace Samples
{
    //<snippet1>
    [ServiceContract]
    public interface IAirfareFinderService
    {
        [OperationContract]
        int FindAirfare(string FromCity, string ToCity, out bool IsDirectFlight);
    }
    //</snippet1>

    //<snippet2>
    public class AirfareRequestMessage : Message
    {
        public string fromCity = "Tokyo";
        public string toCity = "London";
        //code omitted…
        protected override void OnWriteBodyContents(XmlDictionaryWriter w)
        {
            w.WriteStartElement("airfareRequest");
            w.WriteElementString("from", fromCity);
            w.WriteElementString("to", toCity);
            w.WriteEndElement();
        }

        public override MessageVersion Version
        {
            get { throw new NotImplementedException("The method is not implemented.") ; }
        }

        public override MessageProperties Properties
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }
        public override MessageHeaders Headers
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override bool IsEmpty
        {
            get
            {
                return base.IsEmpty;
            }
        }

        public override bool IsFault
        {
            get
            {
                return base.IsFault;
            }
        }
    }
    //</snippet2>

    public interface  Weather
    {
        //<snippet3>
        [OperationContract]
        int GetCurrentTemperature();
        //</snippet3>

        //<snippet4>
        [OperationContract]
        void SetDesiredTemperature(int t);
        //</snippet4>

        //<snippet5>
        [OperationContract(IsOneWay = true)]
        void SetLightbulb(bool isOn);
        //</snippet5>
    }

    //<snippet6>
    public class FileMessage : Message
    // Code not shown.
    //</snippet6>
    {

        public FileMessage( string someFileName)
        {
            throw new NotImplementedException();
        }

        public override MessageVersion Version
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override MessageProperties Properties
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override MessageHeaders Headers
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override bool IsEmpty
        {
            get
            {
                return base.IsEmpty;
            }
        }

        public override bool IsFault
        {
            get
            {
                return base.IsFault;
            }
        }
    }

    //Elsewhere in the code, a part of some service:

    public class SomeClass
    {
        //<snippet7>
        [OperationContract]
        public FileMessage GetFile()
        {
            //code omitted…
            FileMessage fm = new FileMessage("myFile.xml");
            return fm;
        }
        //</snippet7>
    }

    //<snippet8>
    [ServiceContract]
    public interface IForwardingService
    {
        [OperationContract(Action = "*")]
        void ForwardMessage(Message m);
    }
    //</snippet8>

    //<snippet9>
    [MessageContract(IsWrapped = true, WrapperName = "Order")]
    public class SubmitOrderMessage
    {
        [MessageHeader]
        public string customerID;
        [MessageBodyMember]
        public string item;
        [MessageBodyMember]
        public int quantity;
    }
    //</snippet9>
    //Elsewhere in the code, a part of some service contract:
    public interface AnotherClass
    {
        //<snippet10>
        [OperationContract]
         void SubmitOrder(SubmitOrderMessage m);
        //</snippet10>
    }
    public interface  three
    {
        //<snippet11>
        [OperationContract]
        void SubmitOrder(string customerID, string item, int quantity);
        //</snippet11>
    }
}
