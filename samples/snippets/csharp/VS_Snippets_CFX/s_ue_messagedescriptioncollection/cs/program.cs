using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.Collections;
using System.Collections.Generic;

namespace Test
{
    [ServiceContract]
    public interface IContract
    {
        [OperationContract(Action = "http://SomeAction")]
        string Hello();
        [OperationContract(Action = "http://SomeAction")]
        string HelloTwo();
    }

    class Program
    {
        static void Main(string[] args)
        {
            ContractDescription contract = ContractDescription.GetContract(typeof(IContract));
            OperationDescription op = contract.Operations[0];
            MessageDescriptionCollection  mdc = op.Messages;

            MessageDescription md = mdc.Find("http://SomeAction");
            ICollection<MessageDescription> col = mdc.FindAll("http://SomeAction");

            foreach (MessageDescription desc in col)
            {
                Console.WriteLine("Action = {0}", desc.Action);
            }
        }
    }
}
