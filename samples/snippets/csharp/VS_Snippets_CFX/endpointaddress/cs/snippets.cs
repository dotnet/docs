using System;
using System.Configuration;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Security.Principal;
using System.Xml;
using System.Runtime.Serialization;

using System.Text;


namespace Microsoft.WCF.Documentation
{
    public class Snippets
    {
	    
        public static void Snippet2()
        {
            // Get base address from app settings in configuration
            Uri baseAddress = new Uri(ConfigurationManager.AppSettings["baseAddress"]);

            // <Snippet2>
            //Create new address headers for special services and add them to an array
            AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
            AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

            AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
           
            EndpointIdentity endpointIdentity = EndpointIdentity.CreateUpnIdentity(WindowsIdentity.GetCurrent().Name);
	    
            EndpointAddress endpointAddress = new EndpointAddress(
                new Uri
		    ("http://localhost:8003/servicemodelsamples/service/incode/identity"),
		    endpointIdentity, addressHeaders);
	    
	    
            // </Snippet2>
        }

        public static void Snippet3()
        {
            // Get base address from app settings in configuration
            Uri baseAddress = new Uri(ConfigurationManager.AppSettings["baseAddress"]);

            // <Snippet3>
            //Create new address headers for special services and add them to an array
            AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
            AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);
            
            AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
            AddressHeaderCollection addressHeaderColl = new AddressHeaderCollection(addressHeaders);

	    // <Snippet#15>
            EndpointIdentity endpointIdentity = EndpointIdentity.CreateUpnIdentity(WindowsIdentity.GetCurrent().Name);
            EndpointAddress endpointAddress = new EndpointAddress(
                new Uri("http://localhost:8003/servicemodelsamples/service/incode/identity"),
		    endpointIdentity,
		    addressHeaderColl);
	    EndpointIdentity thisEndpointIdentity = endpointAddress.Identity;
	    // </Snippet#15>
	    
            // </Snippet3>
        }

        public static void Snippet4()
        {
            AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
            AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

            AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
           
            EndpointIdentity endpointIdentity = EndpointIdentity.CreateUpnIdentity(WindowsIdentity.GetCurrent().Name);
            EndpointAddress endpointAddress = new EndpointAddress(
                new Uri("http://localhost:8003/servicemodelsamples/service/incode/identity"), endpointIdentity, addressHeaders);
            // <Snippet4>
            Message msg = Message.CreateMessage(MessageVersion.Soap11, "urn:action");
            endpointAddress.ApplyTo(msg);
            // </Snippet4>
        }

        public static void Snippet5()
        {
            AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
            AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

            AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
            
            // <Snippet5>
            EndpointAddress endpointAddress = new EndpointAddress(
                new Uri("http://localhost:8003/servicemodelsamples/service/incode/identity"), addressHeaders);
            EndpointAddress endpointAddress2 = new EndpointAddress(
               new Uri("http://localhost:8003/servicemodelsamples/service/incode/identity"), addressHeaders);

            if (endpointAddress == endpointAddress2)
                Console.WriteLine("The two endpoint addresses are equal");
            else
                Console.WriteLine("The two endpoint addresses are not equal");
            // </Snippet5>            
        }

        public static void Snippet6()
        {
            AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
            AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

            AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
             AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);

            EndpointAddress endpointAddress = new EndpointAddress(
                new Uri("http://localhost:8003/servicemodelsamples/service/incode/identity"), addressHeaders);

            // <Snippet6>
            // <Snippet8>
            XmlDictionaryReader metadataReader = endpointAddress.GetReaderAtMetadata();
            // </Snippet8>
            // <Snippet7>
            XmlDictionaryReader extensionReader = endpointAddress.GetReaderAtExtensions();
            // </Snippet7>
            EndpointIdentity identity = EndpointIdentity.CreateUpnIdentity(WindowsIdentity.GetCurrent().Name);

            EndpointAddress endpointAddress2 = new EndpointAddress(
                new Uri("http://localhost:8003/servicemodelsamples/service/incode/identity"), identity, headers, metadataReader, extensionReader);
            // </Snippet6>            
        }

        public static void Snippet9()
        {
            AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
            AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

            AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };

            // <Snippet9>
            EndpointAddress endpointAddress = new EndpointAddress(
                new Uri("http://localhost:8003/servicemodelsamples/service/incode/identity"), addressHeaders);
            EndpointAddress endpointAddress2 = new EndpointAddress(
               new Uri("http://localhost:8003/servicemodelsamples/service/incode/identity"), addressHeaders);

            if (endpointAddress != endpointAddress2)
                Console.WriteLine("The two endpoint addresses are not equal");
            else
                Console.WriteLine("The two endpoint addresses are equal");
            // </Snippet9>            
        }

        public static void Snippet10()
        {
            AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
            AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

            AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
            AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);

            EndpointAddress endpointAddress = new EndpointAddress(
                new Uri("http://localhost:8003/servicemodelsamples/service/incode/identity"), addressHeaders);

            XmlDictionaryWriter writer = (XmlDictionaryWriter)XmlDictionaryWriter.Create("addressdata.xml");
            endpointAddress.WriteTo(AddressingVersion.WSAddressing10, writer);
            writer.Close();

            // <Snippet10>
            XmlDictionaryReader reader = (XmlDictionaryReader) XmlDictionaryReader.Create("addressdata.xml");
            EndpointAddress createdEA = EndpointAddress.ReadFrom(reader);
            // </Snippet10>          
        }

        public static void Snippet11()
        {
            AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
            AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

            AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
            AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);

            EndpointAddress endpointAddress = new EndpointAddress(
                new Uri("http://localhost:8003/servicemodelsamples/service/incode/identity"), addressHeaders);
            
	    XmlWriter writer = XmlWriter.Create("addressdata.xml");
	    XmlDictionaryWriter dictWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer);
            endpointAddress.WriteTo(AddressingVersion.WSAddressing10, dictWriter);
            dictWriter.Close();

            // <Snippet11>
            XmlReader reader = XmlReader.Create("addressdata.xml");
            XmlDictionaryReader dictReader = XmlDictionaryReader.CreateDictionaryReader(reader);
            XmlDictionaryString xdLocalName = new XmlDictionaryString(XmlDictionary.Empty, "EndpointReference",0);
            XmlDictionaryString xdNamespace = new XmlDictionaryString(XmlDictionary.Empty, "http://www.w3.org/2005/08/addressing", 0);
            EndpointAddress createdEA = EndpointAddress.ReadFrom(dictReader, xdLocalName, xdNamespace);
            // </Snippet11>          
        }

        public static void Snippet12()
        {
            AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
            AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

            AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
            AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);

            EndpointAddress endpointAddress = new EndpointAddress(
                new Uri("http://localhost:8003/servicemodelsamples/service/incode/identity"), addressHeaders);

            XmlWriter writer = XmlWriter.Create("addressdata.xml");
            XmlDictionaryWriter dictWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer);
            endpointAddress.WriteTo(AddressingVersion.WSAddressing10, dictWriter);
            dictWriter.Close();

            // <Snippet12>
            XmlReader reader = XmlReader.Create("addressdata.xml");
            XmlDictionaryReader dictReader = XmlDictionaryReader.CreateDictionaryReader(reader);
            EndpointAddress createdEA = EndpointAddress.ReadFrom
		(AddressingVersion.WSAddressing10,
		 dictReader,
		 "EndpointReference",
		 "http://www.w3.org/2005/08/addressing");
            // </Snippet12>          
        }


	public static void SnippetAnonymousUri()
	{
		//<Snippet13>
		AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
		AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

		AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
		AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);
		
		EndpointIdentity endpointIdentity =
			EndpointIdentity.CreateUpnIdentity(WindowsIdentity.GetCurrent().Name);
		EndpointAddress endpointAddress = new EndpointAddress(
			new Uri
			("http://localhost:8003/servicemodelsamples/service/incode/identity"),
			endpointIdentity, addressHeaders);

		Uri anonUri = EndpointAddress.AnonymousUri;
		//</Snippet13>
	}

	public static void SnippetHeaders()
	{
		//<Snippet14>
		AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
		AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

		AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
		AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);		
		EndpointIdentity endpointIdentity =
			EndpointIdentity.CreateUpnIdentity(WindowsIdentity.GetCurrent().Name);
		EndpointAddress endpointAddress = new EndpointAddress(
			new Uri
			("http://localhost:8003/servicemodelsamples/service/incode/identity"),
			endpointIdentity, addressHeaders);

		AddressHeaderCollection headerCollection = endpointAddress.Headers;
		//</Snippet14>
	}


	public static void SnippetIdentity()
	{
		AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
		AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

		AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
		AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);
		
		//<Snippet15>
		EndpointIdentity endpointIdentity =
			EndpointIdentity.CreateUpnIdentity(WindowsIdentity.GetCurrent().Name);
		EndpointAddress endpointAddress = new EndpointAddress(
			new Uri
			("http://localhost:8003/servicemodelsamples/service/incode/identity"),
			endpointIdentity, addressHeaders);

		EndpointIdentity identity = endpointAddress.Identity;
		//</Snippet15>
	}

	// This does not exist anymore
	public static void SnippetIsAnonymous()
	{

		AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
		AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

		AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
		AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);

		//<Snippet16>
		EndpointIdentity endpointIdentity =
			EndpointIdentity.CreateUpnIdentity(WindowsIdentity.GetCurrent().Name);
		EndpointAddress endpointAddress = new EndpointAddress(
			new Uri
			("http://localhost:8003/servicemodelsamples/service/incode/identity"),
			endpointIdentity, addressHeaders);

		// bool isAnonymous = endpointAddress.IsAnonynmous;
		//</Snippet16>
	}


	public static void SnippetIsNone()
	{

		AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
		AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

		AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
		AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);

		//<Snippet17>
		EndpointIdentity endpointIdentity =
			EndpointIdentity.CreateUpnIdentity(WindowsIdentity.GetCurrent().Name);
		EndpointAddress endpointAddress = new EndpointAddress(
			new Uri
			("http://localhost:8003/servicemodelsamples/service/incode/identity"),
			endpointIdentity, addressHeaders);

		 bool isNone = endpointAddress.IsNone;
		//</Snippet17>
	}


	public static void SnippetNoneUri()
	{

		AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
		AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

		AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
		AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);

		//<Snippet18>
		EndpointIdentity endpointIdentity =
			EndpointIdentity.CreateUpnIdentity(WindowsIdentity.GetCurrent().Name);
		EndpointAddress endpointAddress = new EndpointAddress(
			new Uri
			("http://localhost:8003/servicemodelsamples/service/incode/identity"),
			endpointIdentity, addressHeaders);

		Uri nonUri = EndpointAddress.NoneUri;
		//</Snippet18>
	}

	public static void SnippetUri()
	{

		AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
		AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

		AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
		AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);

		//<Snippet19>
		EndpointIdentity endpointIdentity =
			EndpointIdentity.CreateUpnIdentity(WindowsIdentity.GetCurrent().Name);
		EndpointAddress endpointAddress = new EndpointAddress(
			new Uri
			("http://localhost:8003/servicemodelsamples/service/incode/identity"),
			endpointIdentity, addressHeaders);

		Uri nonUri = endpointAddress.Uri;
		//</Snippet19>
	}	

	public static void SnippetEquals()
	{

		AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
		AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

		AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
		AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);

		//<Snippet20>
		EndpointIdentity endpointIdentity =
			EndpointIdentity.CreateUpnIdentity(WindowsIdentity.GetCurrent().Name);
		EndpointAddress endpointAddress = new EndpointAddress(
			new Uri
			("http://localhost:8003/servicemodelsamples/service/incode/identity"),
			endpointIdentity, addressHeaders);

		bool isEqual = endpointAddress.Equals(endpointAddress);
		//</Snippet20>
	}

	public static void SnippetGetHashCode()
	{

		AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
		AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

		AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
		AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);

		//<Snippet21>
		EndpointIdentity endpointIdentity =
			EndpointIdentity.CreateUpnIdentity(WindowsIdentity.GetCurrent().Name);
		EndpointAddress endpointAddress = new EndpointAddress(
			new Uri
			("http://localhost:8003/servicemodelsamples/service/incode/identity"),
			endpointIdentity, addressHeaders);

		int hashCode = endpointAddress.GetHashCode();
		//</Snippet21>
	}	


	public static void Snippetop_Inequality()
	{

		AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
		AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

		AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
		AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);

		//<Snippet22>
		EndpointIdentity endpointIdentity =
			EndpointIdentity.CreateUpnIdentity(WindowsIdentity.GetCurrent().Name);
		EndpointAddress endpointAddress1 = new EndpointAddress(
			new Uri
			("http://localhost:8003/servicemodelsamples/service/incode/identity1"),
			endpointIdentity, addressHeaders);
		EndpointAddress endpointAddress2 = new EndpointAddress(
			new Uri
			("http://localhost:8003/servicemodelsamples/service/incode/identity2"),
			endpointIdentity, addressHeaders);

		bool op_Inequality_val = (endpointAddress1 != endpointAddress2);
		//</Snippet22>
	}

	public static void SnippetReadFrom()
	{
		AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
		AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

		AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
		AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);

		EndpointAddress endpointAddress = new EndpointAddress(
			new Uri("http://localhost:8003/servicemodelsamples/service/incode/identity"), addressHeaders);

		XmlDictionaryWriter writer = (XmlDictionaryWriter)XmlDictionaryWriter.Create("addressdata.xml");
		endpointAddress.WriteTo(AddressingVersion.WSAddressing10, writer);
		writer.Close();

	    // <Snippet24>
		XmlDictionaryReader reader = (XmlDictionaryReader) XmlDictionaryReader.Create("addressdata.xml");
		EndpointAddress createdEA = EndpointAddress.ReadFrom(reader);
	    // </Snippet24>
	}

	public static void SnippetReadFrom2()
	{
		AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
		AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

		AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
		AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);

		EndpointAddress endpointAddress = new EndpointAddress(
			new Uri("http://localhost:8003/servicemodelsamples/service/incode/identity"), addressHeaders);

		XmlWriter writer = XmlWriter.Create("addressdata.xml");
		XmlDictionaryWriter dictWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer);
		endpointAddress.WriteTo(AddressingVersion.WSAddressing10, dictWriter);
		dictWriter.Close();

	    // <Snippet25>
		XmlReader reader = XmlReader.Create("addressdata.xml");
		XmlDictionaryReader dictReader = XmlDictionaryReader.CreateDictionaryReader(reader);
		EndpointAddress createdEA = EndpointAddress.ReadFrom
					    (AddressingVersion.WSAddressing10,
					     dictReader);
	    // </Snippet25>          
	}

	public static void SnippetReadFrom4()
	{
		AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
		AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

		AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
		AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);

		EndpointAddress endpointAddress = new EndpointAddress(
			new Uri("http://localhost:8003/servicemodelsamples/service/incode/identity"), addressHeaders);

		XmlWriter writer = XmlWriter.Create("addressdata.xml");
		XmlDictionaryWriter dictWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer);
		endpointAddress.WriteTo(AddressingVersion.WSAddressing10, dictWriter);
		dictWriter.Close();

	    // <Snippet26>
		XmlReader reader = XmlReader.Create("addressdata.xml");
		XmlDictionaryReader xReader = XmlDictionaryReader.CreateDictionaryReader(reader);
	    // Create an XmlDictionary and add values to it.
		XmlDictionary d = new XmlDictionary();
		XmlDictionaryString xdLocalName = new XmlDictionaryString(XmlDictionary.Empty, "EndpointReference",0);
		XmlDictionaryString xdNamespace = new XmlDictionaryString(XmlDictionary.Empty, "http://www.w3.org/2005/08/addressing", 0);
		
		EndpointAddress createdEA = EndpointAddress.ReadFrom
					    (AddressingVersion.WSAddressing10,
					     xReader,
					     xdLocalName,
					     xdNamespace
					    );
	    // </Snippet26>          
	}

	public static void SnippetReadFromVersionToString()
	{
		AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
		AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

		AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
		AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);

		EndpointAddress endpointAddress = new EndpointAddress(
			new Uri("http://localhost:8003/servicemodelsamples/service/incode/identity"), addressHeaders);

	    // <Snippet27>
		string URIstring = endpointAddress.ToString();
	    // </Snippet27>

	}

	public static void SnippetWriteContentsToAddressingVersionXmlDictionaryWriter()
	{
		AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
		AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

		AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
		AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);

		EndpointAddress endpointAddress = new EndpointAddress(
			new Uri("http://localhost:8003/servicemodelsamples/service/incode/identity"), addressHeaders);

	    // <Snippet29>
		XmlWriter writer = XmlWriter.Create("addressdata.xml");
		XmlDictionaryWriter dictWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer);
		endpointAddress.WriteContentsTo(
						AddressingVersion.WSAddressing10,
						dictWriter);
		dictWriter.Close();
	    // </Snippet29>

	}

	public static void SnippetWriteContentsToAddressingVersionXmlWriter()
	{
		AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
		AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

		AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
		AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);

		EndpointAddress endpointAddress = new EndpointAddress(
			new Uri("http://localhost:8003/servicemodelsamples/service/incode/identity"), addressHeaders);

	    // <Snippet30>
		XmlWriter writer = XmlWriter.Create("addressdata.xml");
		endpointAddress.WriteContentsTo(
						AddressingVersion.WSAddressing10,
						writer);
		writer.Close();
	    // </Snippet30>

	}

	public static void SnippetWriteToAddressingVersionXmlDictionaryWriter()
	{
		AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
		AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

		AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
		AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);

		EndpointAddress endpointAddress = new EndpointAddress(
			new Uri("http://localhost:8003/servicemodelsamples/service/incode/identity"), addressHeaders);

	    // <Snippet31>
		XmlWriter writer = XmlWriter.Create("addressdata.xml");
		XmlDictionaryWriter dictWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer);
		endpointAddress.WriteTo(
					AddressingVersion.WSAddressing10,
					dictWriter);
		writer.Close();

	    // </Snippet31>

	}

	public static void SnippetWriteToAddressingVersionXmlWriter()
	{
		AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
		AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

		AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
		AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);

		EndpointAddress endpointAddress = new EndpointAddress(
			new Uri("http://localhost:8003/servicemodelsamples/service/incode/identity"), addressHeaders);

	    // <Snippet32>
		XmlWriter writer = XmlWriter.Create("addressdata.xml");
		endpointAddress.WriteTo(
					AddressingVersion.WSAddressing10,
					writer);
		writer.Close();
	    // </Snippet32>

	}

	public static void SnippetWriteToAddressingVersionXmlWriterXmlDictionaryStringXmlDictionaryString()
	{
		AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
		AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

		AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
		AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);

		EndpointAddress endpointAddress = new EndpointAddress(
			new Uri("http://localhost:8003/servicemodelsamples/service/incode/identity"), addressHeaders);

	    // <Snippet33>
		XmlWriter writer = XmlWriter.Create("addressdata.xml");
		XmlDictionaryWriter dictWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer);
	
		XmlDictionary d = new XmlDictionary();
		XmlDictionaryString xdLocalName = new XmlDictionaryString(XmlDictionary.Empty, "EndpointReference",0);
		XmlDictionaryString xdNamespace = new XmlDictionaryString(XmlDictionary.Empty, "http://www.w3.org/2005/08/addressing", 0);
		
		endpointAddress.WriteTo(
					AddressingVersion.WSAddressing10,
					dictWriter,
					xdLocalName,
					xdNamespace);
		writer.Close();
	    // </Snippet33>

	}
	
	public static void SnippetWriteToAddressingVersionXmlWriterStringString()
	{
		AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
		AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);

		AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };
		AddressHeaderCollection headers = new AddressHeaderCollection(addressHeaders);

		EndpointAddress endpointAddress = new EndpointAddress(
			new Uri("http://localhost:8003/servicemodelsamples/service/incode/identity"), addressHeaders);

	    // <Snippet34>
		XmlWriter writer = XmlWriter.Create("addressdata.xml");
		endpointAddress.WriteTo(
					AddressingVersion.WSAddressing10,
					writer,
					"EndpointReference",
					"http://www.w3.org/2005/08/addressing");
		writer.Close();
	    // </Snippet34>

	}



    }
}
