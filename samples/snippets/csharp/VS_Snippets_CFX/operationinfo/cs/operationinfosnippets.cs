using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.Activities;

namespace OperationInfoSnippets
{
    class OperationInfoSnippets
    {
        void container0()
        {
            //OperationInfo.OperationInfo()
            //<snippet0>
            OperationInfo info = new OperationInfo();
            //</snippet0>
        }

        void container1()
        {
            //OperationInfo.ContractName
            //<snippet1>
            OperationInfo info = new OperationInfo();
            info.ContractName = "Contract1";
            //</snippet1>
        }
        void container2()
        {
            //OperationInfo.HasProtectionLevel
            //<snippet2>
            OperationInfo info = new OperationInfo();
            bool hasProtectionLevel = info.HasProtectionLevel;
            //</snippet2>
        }
        void container3()
        {
            //OperationInfo.IsOneWay
            //<snippet3>
            OperationInfo info = new OperationInfo();
            bool isOneWay = info.IsOneWay;
            //</snippet3>
        }
        void container4()
        {
            //OperationInfo.Parameters
            //<snippet4>
            ReceiveActivity receive = new ReceiveActivity();
            OperationInfo info = new OperationInfo();
            info.Name = "Echo";
            OperationParameterInfo parameterInfo = new OperationParameterInfo();
            parameterInfo.Attributes = ((System.Reflection.ParameterAttributes)((System.Reflection.ParameterAttributes.Out | System.Reflection.ParameterAttributes.Retval)));
            parameterInfo.Name = "(ReturnValue)";
            parameterInfo.ParameterType = typeof(string);
            parameterInfo.Position = -1;
            info.Parameters.Add(parameterInfo);
            receive.ServiceOperationInfo = info;
            //</snippet4>
        }
        void container5()
        {
            //OperationInfo.ProtectionLevel
            //<snippet5>
            OperationInfo info = new OperationInfo();
            info.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
            //</snippet5>
        }
        void container6()
        {
            //OperationInfo.Clone
            //<snippet6>
            OperationInfo info1 = new OperationInfo();
            OperationInfo info2 = (OperationInfo)info1.Clone();
            //</snippet6>
        }
        bool container7()
        {
            //OperationInfo.Equals
            //<snippet7>
            OperationInfo info1 = new OperationInfo();
            info1.Name = "ProcessData";
            OperationInfo info2 = new OperationInfo();
            info2.Name = "ProcessData";
            return info1.Equals(info2);
            //</snippet7>
        }
        void container8()
        {
            //OperationInfo.GetHashCode
            //<snippet8>
            OperationInfo info = new OperationInfo();
            info.Name = "ProcessData";
            int code = info.GetHashCode();
            //</snippet8>
        }
        void container9()
        {
            //OperationInfo.ToString
            //<snippet9>
            OperationInfo info = new OperationInfo();
            String infoString = info.ToString();
            //</snippet9>
        }



    }
}
