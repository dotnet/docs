using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;

    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet0>
            MessageVersion msgVersion = MessageVersion.Default;
            // </Snippet0>


            // <Snippet1>
            AddressingVersion addrVersion = msgVersion.Addressing;
            // </Snippet1>

            // <Snippet2>
            EnvelopeVersion envVersion = msgVersion.Envelope;
            // </Snippet2>

            // <Snippet3>
            msgVersion.ToString();
            // </Snippet3>

            // <Snippet4>
            MessageVersion msgVersion2 = MessageVersion.None;
            // </Snippet4>

            // <Snippet5>
            msgVersion = MessageVersion.Soap11;
            // </Snippet5>

            // <Snippet6>
            msgVersion = MessageVersion.Soap11WSAddressing10;
            // </Snippet6>

            // <Snippet7>
            msgVersion = MessageVersion.Soap11WSAddressingAugust2004;
            // </Snippet7>

            // <Snippet8>
            msgVersion = MessageVersion.Soap12;
            // </Snippet8>

            // <Snippet9>
            msgVersion = MessageVersion.Soap12WSAddressing10;
            // </Snippet9>

            // <Snippet10>
            msgVersion = MessageVersion.Soap12WSAddressingAugust2004;
            // </Snippet10>

            // <Snippet11>
            msgVersion = MessageVersion.CreateVersion(envVersion);
            // </Snippet11>

            // <Snippet12>
            msgVersion = MessageVersion.CreateVersion(envVersion, addrVersion);
            // </Snippet12>

            // <Snippet13>
            msgVersion.Equals(msgVersion2);
            // </Snippet13>

            // <Snippet14>
            msgVersion.GetHashCode();
            // </Snippet14>




        }
    }
