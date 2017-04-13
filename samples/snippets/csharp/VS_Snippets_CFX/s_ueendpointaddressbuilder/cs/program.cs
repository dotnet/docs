using System;
using System.Text;
using System.IO;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;


namespace Service
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet0>
            // <Snippet3>
            // <Snippet1>
            EndpointAddressBuilder eab = new EndpointAddressBuilder();
            // </Snippet1>
            eab.Uri = new Uri("http://localhost/Uri");
            eab.Headers.Add(AddressHeader.CreateAddressHeader("n", "ns", "val"));
            // </Snippet3>

            // <Snippet4>
            eab.Identity = EndpointIdentity.CreateUpnIdentity("identity");
            // </Snippet4>

            // <Snippet5>
            XmlDictionaryReader xdrExtensions = eab.GetReaderAtExtensions();
            // </Snippet5>

            // <Snippet6>
            StringReader sr = new StringReader(@"<myExtension xmlns=""myExtNs"" />");
            eab.SetExtensionReader(XmlDictionaryReader.CreateDictionaryReader(XmlReader.Create(sr)));
            // </Snippet6>

            // <Snippet7>
            EndpointAddress ea = eab.ToEndpointAddress();
            // </Snippet7>

            // <Snippet8>
            sr = new StringReader(@"<myMetadata xmlns=""myMetaNs"" />");
            XmlDictionaryReader xdrMetaData = eab.GetReaderAtMetadata();
            // </Snippet8>

            // <Snippet9>
            eab.SetMetadataReader(XmlDictionaryReader.CreateDictionaryReader(XmlReader.Create(sr)));
            // </Snippet9>
            // </Snippet0>

            // <Snippet2>
            EndpointAddress endpointAddress = new EndpointAddress("http://localhost/uri2");
            EndpointAddressBuilder eab2 = new EndpointAddressBuilder(endpointAddress);
            // </Snippet2>
        }
    }
}
