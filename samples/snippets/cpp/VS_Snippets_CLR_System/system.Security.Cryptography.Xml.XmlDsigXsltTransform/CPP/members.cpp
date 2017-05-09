//<Snippet2>
#using <System.Security.dll>
#using <System.dll>
#using <System.Xml.dll>
using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::Xml;
using namespace System::Text;

ref class Class1
{
public:
   [STAThread]
   static void Main()
   {
      XmlDocument^ productsXml = LoadProducts();
      XmlNodeList^ xsltNodeList = GetXsltAsNodeList();
      TransformDoc( productsXml, xsltNodeList );
      
      // Use XmlDsigXsltTransform to resolve a Uri.
      Uri^ baseUri = gcnew Uri( L"http://www.contoso.com" );
      String^ relativeUri = L"xml";
      Uri^ absoluteUri = ResolveUris( baseUri, relativeUri );
      Console::WriteLine( L"This sample completed successfully; "
      L"press Enter to exit." );
      Console::ReadLine();
   }

private:
   static void TransformDoc( XmlDocument^ xmlDoc, XmlNodeList^ xsltNodeList )
   {
      try
      {
         // Construct a new XmlDsigXsltTransform.
         //<Snippet1>
         XmlDsigXsltTransform^ xmlTransform = gcnew XmlDsigXsltTransform;
         //</Snippet1>

         // Load the Xslt tranform as a node list.
         //<Snippet10>
         xmlTransform->LoadInnerXml( xsltNodeList );
         //</Snippet10>

         // Load the Xml document to perform the tranform on.
         //<Snippet11>
         XmlNamespaceManager^ namespaceManager;
         namespaceManager = gcnew XmlNamespaceManager( xmlDoc->NameTable );
         XmlNodeList^ productsNodeList;
         productsNodeList = xmlDoc->SelectNodes( L"//.", namespaceManager );
         xmlTransform->LoadInput( productsNodeList );
         //</Snippet11>

         // Retrieve the output from the transform.
         //<Snippet7>
         Stream^ outputStream = (Stream^)xmlTransform->GetOutput(
            System::IO::Stream::typeid );
         //</Snippet7>

         // Read the output stream into a stream reader.
         StreamReader^ streamReader = gcnew StreamReader( outputStream );
         
         // Read the stream into a string.
         String^ outputMessage = streamReader->ReadToEnd();
         
         // Close the streams.
         outputStream->Close();
         streamReader->Close();
         
         // Display to the console the Xml before and after
         // encryption.
         Console::WriteLine( L"\nResult of transformation: {0}", outputMessage );
         ShowTransformProperties( xmlTransform );
      }
      catch ( Exception^ ex ) 
      {
         Console::WriteLine( L"Caught exception in TransformDoc method: {0}", ex );
      }
   }

   static XmlNodeList^ GetXsltAsNodeList()
   {
      String^ transformXml = L"<xsl:transform version='1.0' ";
      transformXml = String::Concat( transformXml,
         L"xmlns:xsl='http://www.w3.org/1999/XSL/Transform'>" );
      transformXml = String::Concat( transformXml,
         L"<xsl:template match='products'>" );
      transformXml = String::Concat( transformXml,
         L"<table><tr><td>ProductId</td><td>Name</td></tr>" );
      transformXml = String::Concat( transformXml,
         L"<xsl:apply-templates/></table></xsl:template>" );
      transformXml = String::Concat( transformXml,
         L"<xsl:template match='product'><tr>" );
      transformXml = String::Concat( transformXml,
         L"<xsl:apply-templates/></tr></xsl:template>" );
      transformXml = String::Concat( transformXml,
         L"<xsl:template match='productid'><td>" );
      transformXml = String::Concat( transformXml,
         L"<xsl:apply-templates/></td></xsl:template>" );
      transformXml = String::Concat( transformXml,
         L"<xsl:template match='description'><td>" );
      transformXml = String::Concat( transformXml,
         L"<xsl:apply-templates/></td></xsl:template>" );
      transformXml = String::Concat( transformXml,
         L"</xsl:transform>" );
      Console::WriteLine( L"\nCreated the following Xslt tranform:" );
      Console::WriteLine( transformXml );
      XmlDocument^ xmlDoc = gcnew XmlDocument;
      xmlDoc->LoadXml( transformXml );
      return xmlDoc->GetElementsByTagName( L"xsl:transform" );
   }

   // Encrypt the text in the specified XmlDocument.
   static void ShowTransformProperties( XmlDsigXsltTransform^ xmlTransform )
   {
      //<Snippet12>
      String^ classDescription = xmlTransform->ToString();
      //</Snippet12>
      Console::WriteLine( L"\n** Summary for {0} **", classDescription );
      
      // Retrieve the XML representation of the current transform.
      //<Snippet9>
      XmlElement^ xmlInTransform = xmlTransform->GetXml();
      //</Snippet9>
      Console::WriteLine( L"Xml representation of the current transform:\n{0}",
         xmlInTransform->OuterXml );
      
      // Ensure the transform is using the proper algorithm.
      //<Snippet3>
      xmlTransform->Algorithm = SignedXml::XmlDsigXsltTransformUrl;
      //</Snippet3>
      Console::WriteLine( L"Algorithm used: {0}", classDescription );
      
      // Retrieve the valid input types for the current transform.
      //<Snippet4>
      array<Type^>^validInTypes = xmlTransform->InputTypes;
      //</Snippet4>
      Console::WriteLine( L"Transform accepts the following inputs:" );
      for ( int i = 0; i < validInTypes->Length; i++ )
      {
         Console::WriteLine( L"\t{0}", validInTypes[ i ] );

      }
      
      //<Snippet5>
      array<Type^>^validOutTypes = xmlTransform->OutputTypes;
      //</Snippet5>
      Console::WriteLine( L"Transform outputs in the following types:" );
      for ( int i = validOutTypes->Length - 1; i >= 0; i-- )
      {
         Console::WriteLine( L"\t {0}", validOutTypes[ i ] );
         if ( validOutTypes[ i ] == Object::typeid )
         {
            //<Snippet8>
            Object^ outputObject = xmlTransform->GetOutput();
            //</Snippet8>
         }
      }
   }

   // Create an XML document describing various products.
   static XmlDocument^ LoadProducts()
   {
      String^ contosoProducts = L"<?xml version='1.0'?>";
      contosoProducts = String::Concat( contosoProducts,
         L"<products>" );
      contosoProducts = String::Concat( contosoProducts,
         L"<product><productid>1</productid>" );
      contosoProducts = String::Concat( contosoProducts,
         L"<description>Widgets</description></product>" );
      contosoProducts = String::Concat( contosoProducts,
         L"<product><productid>2</productid>" );
      contosoProducts = String::Concat( contosoProducts,
         L"<description>Gadgits</description></product>" );
      contosoProducts = String::Concat( contosoProducts,
         L"</products>" );
      Console::WriteLine(
         L"\nCreated the following Xml document for tranformation:" );
      Console::WriteLine( contosoProducts );
      XmlDocument^ xmlDoc = gcnew XmlDocument;
      xmlDoc->LoadXml( contosoProducts );
      return xmlDoc;
   }

   // Resolve the specified base and relative Uri's .
   static Uri^ ResolveUris( Uri^ baseUri, String^ relativeUri )
   {
      //<Snippet6>
      XmlUrlResolver^ xmlResolver = gcnew XmlUrlResolver;
      xmlResolver->Credentials =
         System::Net::CredentialCache::DefaultCredentials;

      XmlDsigXsltTransform^ xmlTransform = gcnew XmlDsigXsltTransform;
      xmlTransform->Resolver = xmlResolver;
      //</Snippet6>

      Uri^ absoluteUri = xmlResolver->ResolveUri( baseUri, relativeUri );
      if ( absoluteUri != nullptr )
      {
         Console::WriteLine(
         L"\nResolved the base Uri and relative Uri to the following:" );
         Console::WriteLine( absoluteUri );
      }
      else
      {
         Console::WriteLine( L"Unable to resolve the base Uri and relative Uri" );
      }

      return absoluteUri;
   }
};

int main()
{
   Class1::Main();
}

//
// This sample produces the following output:
//
// Created the following Xml document for tranformation:
// <?xml version='1.0'?><products><product><productid>1</productid><descriptio
// n>Widgets</description></product><product><productid>2</productid><descript
// ion>Gadgits</description></product></products>
//
// Created the following Xslt tranform:
// <xsl:transform version='1.0' xmlns:xsl='http://www.w3.org/1999/XSL/Transfor
// m'><xsl:template match='products'><table><tr><td>ProductId</td><td>Name</td
// ></tr><xsl:apply-templates/></table></xsl:template><xsl:template match='pro
// duct'><tr><xsl:apply-templates/></tr></xsl:template><xsl:emplate match='pro
// ductid'><td><xsl:apply-templates/></td></xsl:template><xsl:template match='
// description'><td><xsl:apply-templates/></td></xsl:template></xsl:transform>
//
// Result of transformation: <table><tr><td>ProductId</td><td>Name</td></tr><t
// r><td>1</td><td>Widgets</td></tr><tr><td>2</td><td>Gadgits</td></tr></table
// >
//
// ** Summary for System.Security.Cryptography.Xml.XmlDsigXsltTransform **
// Xml representation of the current transform:
// <Transform Algorithm="http://www.w3.org/TR/1999/REC-xslt-19991116" xmlns="h
// ttp://www.w3.org/2000/09/xmldsig#"><xsl:transform version="1.0" xmlns:xsl="
// http://www.w3.org/1999/XSL/Transform"><xsl:template match="products"><table
//  xmlns=""><tr><td>ProductId</td><td>Name</td></tr><xsl:apply-templates /></
// table></xsl:template><xsl:template match="product"><tr xmlns=""><xsl:apply-
// templates /></tr></xsl:template><xsl:template match="productid"><td xmlns="
// "><xsl:apply-templates /></td></xsl:template><xsl:template match="descripti
// on"><td xmlns=""><xsl:apply-templates /></td></xsl:template></xsl:transform
// ></Transform>
// Algorithm used: System.Security.Cryptography.Xml.XmlDsigXsltTransform
// Transform accepts the following inputs:
// System.IO.Stream
// System.Xml.XmlDocument
// System.Xml.XmlNodeList
// Transform outputs in the following types:
// System.IO.Stream
//
// Resolved the base Uri and relative Uri to the following:
// http://www.contoso.com/xml
// This sample completed successfully; press Enter to exit.
//</Snippet2>
