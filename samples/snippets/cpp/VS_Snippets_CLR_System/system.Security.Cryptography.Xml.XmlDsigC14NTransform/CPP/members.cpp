//<Snippet2>
#using <System.dll>
#using <System.Xml.dll>
#using <System.Security.dll>
using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::Xml;
using namespace System::Security::Cryptography::X509Certificates;

ref class Class1
{
private:
   static String^ Certificate = L"..\\..\\my509.cer";

public:
   [STAThread]
   static void Main()
   {
      // Encrypt an XML message
      XmlDocument^ productsXml = LoadProducts();
      ShowTransformProperties( productsXml );
      SignDocument( productsXml );
      ShowTransformProperties( productsXml );
      
      // Use XmlDsigC14NTransform to resolve a Uri.
      Uri^ baseUri = gcnew Uri( L"http://www.contoso.com" );
      String^ relativeUri = L"xml";
      Uri^ absoluteUri = ResolveUris( baseUri, relativeUri );
      Console::WriteLine( L"This sample completed successfully; "
         L"press Enter to exit." );
      Console::ReadLine();
   }


private:
   // Encrypt the text in the specified XmlDocument.
   static void ShowTransformProperties( XmlDocument^ xmlDoc )
   {
      //<Snippet1>
      XmlDsigC14NTransform^ xmlTransform =
         gcnew XmlDsigC14NTransform( true );
      //</Snippet1>

      // Ensure the transform is using the appropriate algorithm.
      //<Snippet4>
      xmlTransform->Algorithm =
         SignedXml::XmlDsigExcC14NTransformUrl;
      //</Snippet4>

      // Retrieve the XML representation of the current transform.
      //<Snippet10>
      XmlElement^ xmlInTransform = xmlTransform->GetXml();
      //</Snippet10>

      Console::WriteLine( L"\nXml representation of the current transform: " );
      Console::WriteLine( xmlInTransform->OuterXml );
      
      // Retrieve the valid input types for the current transform.
      //<Snippet5>
      array<Type^>^validInTypes = xmlTransform->InputTypes;
      //</Snippet5>

      // Verify the xmlTransform can accept the XMLDocument as an
      // input type.
      for ( int i = 0; i < validInTypes->Length; i++ )
      {
         if ( validInTypes[ i ] == xmlDoc->GetType() )
         {
            // Load the document into the transfrom.
            //<Snippet12>
            xmlTransform->LoadInput( xmlDoc );
            //</Snippet12>

            //<Snippet3>
            XmlDsigC14NTransform^ secondTransform = gcnew XmlDsigC14NTransform;
            //</Snippet3>

            //<Snippet13>
            String^ classDescription = secondTransform->ToString();
            //</Snippet13>

            // This call does not perform as expected.
            // This transform does not contain inner XML elements
            //<Snippet11>
            secondTransform->LoadInnerXml( xmlDoc->SelectNodes( L"//." ) );
            //</Snippet11>

            break;
         }
      }
      
      //<Snippet6>
      array<Type^>^validOutTypes = xmlTransform->OutputTypes;
      //</Snippet6>

      for ( int i = 0; i < validOutTypes->Length; i++ )
      {
         if ( validOutTypes[ i ] == System::IO::Stream::typeid )
         {
            try
            {
               
               //<Snippet9>
               Type^ streamType = System::IO::Stream::typeid;
               MemoryStream^ outputStream = static_cast<MemoryStream^>(
                  xmlTransform->GetOutput( streamType ));
               //</Snippet9>

               // Read the CryptoStream into a stream reader.
               StreamReader^ streamReader =
                  gcnew StreamReader( outputStream );
               
               // Read the stream into a string.
               String^ outputMessage = streamReader->ReadToEnd();
               
               // Close the streams.
               outputStream->Close();
               streamReader->Close();
               
               // Display to the console the Xml before and after
               // encryption.
               Console::WriteLine( L"Encoding the following xml: {0}",
                  xmlDoc->OuterXml );
               Console::WriteLine( L"Message encoded: {0}", outputMessage );
            }
            catch ( Exception^ ex ) 
            {
               Console::WriteLine( L"Unexpected exception caught: {0}", ex );
            }

            break;
         }
         else
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
      XmlDocument^ xmlDoc = gcnew XmlDocument;
      String^ contosoProducts = L"<PRODUCTS>";
      contosoProducts = String::Concat( contosoProducts,
         L"<PRODUCT><ID>123</ID>");
      contosoProducts = String::Concat( contosoProducts,
         L"<DESCRIPTION>Router</DESCRIPTION></PRODUCT>");
      contosoProducts = String::Concat( contosoProducts,
         L"<PRODUCT><ID>456</ID>");
       contosoProducts = String::Concat( contosoProducts,
        L"<DESCRIPTION>Keyboard</DESCRIPTION></PRODUCT>");
      
      // Include a comment to test the comments feature of the transform.
      contosoProducts = String::Concat( contosoProducts,
         L"<!--Comments are included in the transform-->" );
      
      // Include the CDATA tag to test the transform results.
      contosoProducts = String::Concat( contosoProducts,
         L"<PARTNER_URL><![CDATA['http:\\\\www.contoso.com" );
      contosoProducts = String::Concat( contosoProducts,
         L"\\partner.asp?h1=en&h2=cr']]></PARTNER_URL>" );
      contosoProducts = String::Concat( contosoProducts,
         L"</PRODUCTS>" );

      xmlDoc->LoadXml( contosoProducts );
      return xmlDoc;
   }

   // Create a signature and add it to the specified document.
   static void SignDocument( XmlDocument^ xmlDoc )
   {
      // Generate a signing key.
      RSACryptoServiceProvider^ Key = gcnew RSACryptoServiceProvider;
      
      // Create a SignedXml object.
      SignedXml^ signedXml = gcnew SignedXml( xmlDoc );
      
      // Add the key to the SignedXml document.
      signedXml->SigningKey = Key;
      
      // Create a reference to be signed.
      Reference^ reference = gcnew Reference;
      reference->Uri = L"";
      
      // Add an enveloped transformation to the reference.
      reference->AddTransform( gcnew XmlDsigC14NTransform );
      
      // Add the reference to the SignedXml object.
      signedXml->AddReference( reference );
      try
      {
         // Create a new KeyInfo object.
         KeyInfo^ keyInfo = gcnew KeyInfo;
         
         // Load the X509 certificate.
         X509Certificate^ MSCert =
            X509Certificate::CreateFromCertFile( Certificate );
         
         // Load the certificate into a KeyInfoX509Data object
         // and add it to the KeyInfo object.
         keyInfo->AddClause( gcnew KeyInfoX509Data( MSCert ) );
         
         // Add the KeyInfo object to the SignedXml object.
         signedXml->KeyInfo = keyInfo;
      }
      catch ( FileNotFoundException^ ) 
      {
         Console::WriteLine( L"Unable to locate the following file: {0}",
            Certificate );
      }
      catch ( CryptographicException^ ex ) 
      {
         Console::WriteLine( L"Unexpected exception caught while creating "
         L"the certificate:{0}", ex );
      }
      
      // Compute the signature.
      signedXml->ComputeSignature();
      
      // Add the signature branch to the original tree so it is enveloped.
      xmlDoc->DocumentElement->AppendChild( signedXml->GetXml() );
   }

   // Resolve the specified base and relative Uri's .
   static Uri^ ResolveUris( Uri^ baseUri, String^ relativeUri )
   {
      //<Snippet7>
      XmlUrlResolver^ xmlResolver = gcnew XmlUrlResolver;
      xmlResolver->Credentials =
         System::Net::CredentialCache::DefaultCredentials;
      XmlDsigC14NTransform^ xmlTransform = gcnew XmlDsigC14NTransform;
      xmlTransform->Resolver = xmlResolver;
      //</Snippet7>

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
// Xml representation of the current transform:
// <Transform Algorithm="http://www.w3.org/TR/2001/REC-xml-c14n-20010315" xmln
// s="http://www.w3.org/2000/09/xmldsig#" />
// Encoding the following xml: <PRODUCTS><PRODUCT><ID>123</ID><DESCRIPTION>Rou
// ter</DESCRIPTION></PRODUCT><PRODUCT><ID>456</ID><DESCRIPTION>Keyboard</DESC
// RIPTION></PRODUCT><!--Comments are included in the transform--><PARTNER_URL
// ><![CDATA['http:\\www.contoso.com\partner.asp?h1=en&h2=cr']]></PARTNER_URL>
// </PRODUCTS>Message encoded: <PRODUCTS><PRODUCT><ID>123</ID><DESCRIPTION>Rou
// ter</DESCRIPTION></PRODUCT><PRODUCT><ID>456</ID><DESCRIPTION>Keyboard</DESC
// RIPTION></PRODUCT><!--Comments are included in the transform--><PARTNER_URL
// >'http:\\www.contoso.com\partner.asp?h1=en&amp;h2=cr'</PARTNER_URL></PRODUC
// TS>
// Xml representation of the current transform:
// <Transform Algorithm="http://www.w3.org/TR/2001/REC-xml-c14n-20010315" xmln
// s="http://www.w3.org/2000/09/xmldsig#" />
// Encoding the following xml: <PRODUCTS><PRODUCT><ID>123</ID><DESCRIPTION>Rou
// ter</DESCRIPTION></PRODUCT><PRODUCT><ID>456</ID><DESCRIPTION>Keyboard</DESC
// RIPTION></PRODUCT><!--Comments are included in the transform--><PARTNER_URL
// ><![CDATA['http:\\www.contoso.com\partner.asp?h1=en&h2=cr']]></PARTNER_URL>
// <Signature xmlns="http://www.w3.org/2000/09/xmldsig#"><SignedInfo><Canonica
// lizationMethod Algorithm="http://www.w3.org/TR/2001/REC-xml-c14n-20010315"
// /><SignatureMethod Algorithm="http://www.w3.org/2000/09/xmldsig#rsa-sha1" /
// ><Reference URI=""><Transforms><Transform Algorithm="http://www.w3.org/TR/2
// 001/REC-xml-c14n-20010315" /></Transforms><DigestMethod Algorithm="http://w
// ww.w3.org/2000/09/xmldsig#sha1" /><DigestValue>BFN2s0/NA2NGgb/R0mvfnNM0Ito=
// </DigestValue></Reference></SignedInfo><SignatureValue>vSfZUG5xHuNxzOSEbQjN
// dtEt1D+O7I1LTJ13RrwLaJSfQPrdT/s8IeaA+idw2f2WGuGrdqMJUddpE4GxfK61HmPQ6S7lBG+
// +ND+YaUYf2AtTRs3SnToXQQrARa/pHVjsKxYHR/9tjy6maHBwxjgjFQABvYZu0gZHYRuXvvfxv0
// 8=</SignatureValue><KeyInfo><X509Data xmlns="http://www.w3.org/2000/09/xmld
// sig#"><X509Certificate>MIICCzCCAXSgAwIBAgIQ5eVQY8pRZ5xBF2WLkYPjijANBgkqhkiG
// 9w0BAQQFADAbMRkwFwYDVQQDExBHcmVnc0NlcnRpZmljYXRlMB4XDTAzMDkxNzIzMzU0N1oXDTM
// 5MTIzMTIzNTk1OVowGzEZMBcGA1UEAxMQR3JlZ3NDZXJ0aWZpY2F0ZTCBnzANBgkqhkiG9w0BAQ
// EFAAOBjQAwgYkCgYEAmFJ4v7rS3BYTXgVW9PgBFfTYAcB/m9mOFCmUrrChcBpoEtu/tSESlNfEH
// pECIdqg9vUrCNSkY08HRn3ueNeBSnSpssWd8/XoOboWLh1nd+79Y5uZd1WOJI4s0XM0MegZgCoJ
// cEEhpxCd/HOPIQvEsbpN/DuFiovZLo+Ek3hHoxMCAwEAAaNQME4wTAYDVR0BBEUwQ4AQaCb19dl
// yf/zSxPVYQZY9AKEdMBsxGTAXBgNVBAMTEEdyZWdzQ2VydGlmaWNhdGWCEOXlUGPKUWecQRdli5
// GD44owDQYJKoZIhvcNAQEEBQADgYEAZuZaFDGDJogh7FuT0hfaMAVlRONv6wWVBJVV++eUo38Xu
// RfJ5nNJ0UnhiV2sEtLobYBPEIrNhuk8skdU0AHgx4ILiA4rR96ifWwxtrFQF+h+DL2ZB7xhwcOJ
// +Pa7IC4wIaEp/oBmmX+JHSzfQt6/If4ohwikfxfljKMyIcMlwl4=</X509Certificate></X50
// 9Data></KeyInfo></Signature></PRODUCTS>
//
// Message encoded: <PRODUCTS><PRODUCT><ID>123</ID><DESCRIPTION>Router</DESCRI
// PTION></PRODUCT><PRODUCT><ID>456</ID><DESCRIPTION>Keyboard</DESCRIPTION></P
// RODUCT><!--Comments are included in the transform--><PARTNER_URL>'http:\\ww
// w.contoso.com\partner.asp?h1=en&amp;h2=cr'</PARTNER_URL><Signature><SignedI
// nfo><CanonicalizationMethod Algorithm="http://www.w3.org/TR/2001/REC-xml-c1
// 4n-20010315"></CanonicalizationMethod><SignatureMethod Algorithm="http://ww
// w.w3.org/2000/09/xmldsig#rsa-sha1"></SignatureMethod><Reference URI=""><Tra
// nsforms><Transform Algorithm="http://www.w3.org/TR/2001/REC-xml-c14n-200103
// 15"></Transform></Transforms><DigestMethod Algorithm="http://www.w3.org/200
// 0/09/xmldsig#sha1"></DigestMethod><DigestValue>BFN2s0/NA2NGgb/R0mvfnNM0Ito=
// </DigestValue></Reference></SignedInfo><SignatureValue>vSfZUG5xHuNxzOSEbQjN
// dtEt1D+O7I1LTJ13RrwLaJSfQPrdT/s8IeaA+idw2f2WGuGrdqMJUddpE4GxfK61HmPQ6S7lBG+
// +ND+YaUYf2AtTRs3SnToXQQrARa/pHVjsKxYHR/9tjy6maHBwxjgjFQABvYZu0gZHYRuXvvfxv0
// 8=</SignatureValue><KeyInfo><X509Data xmlns="http://www.w3.org/2000/09/xmld
// sig#"><X509Certificate>MIICCzCCAXSgAwIBAgIQ5eVQY8pRZ5xBF2WLkYPjijANBgkqhkiG
// 9w0BAQQFADAbMRkwFwYDVQQDExBHcmVnc0NlcnRpZmljYXRlMB4XDTAzMDkxNzIzMzU0N1oXDTM
// 5MTIzMTIzNTk1OVowGzEZMBcGA1UEAxMQR3JlZ3NDZXJ0aWZpY2F0ZTCBnzANBgkqhkiG9w0BAQ
// EFAAOBjQAwgYkCgYEAmFJ4v7rS3BYTXgVW9PgBFfTYAcB/m9mOFCmUrrChcBpoEtu/tSESlNfEH
// pECIdqg9vUrCNSkY08HRn3ueNeBSnSpssWd8/XoOboWLh1nd+79Y5uZd1WOJI4s0XM0MegZgCoJ
// cEEhpxCd/HOPIQvEsbpN/DuFiovZLo+Ek3hHoxMCAwEAAaNQME4wTAYDVR0BBEUwQ4AQaCb19dl
// yf/zSxPVYQZY9AKEdMBsxGTAXBgNVBAMTEEdyZWdzQ2VydGlmaWNhdGWCEOXlUGPKUWecQRdli5
// GD44owDQYJKoZIhvcNAQEEBQADgYEAZuZaFDGDJogh7FuT0hfaMAVlRONv6wWVBJVV++eUo38Xu
// RfJ5nNJ0UnhiV2sEtLobYBPEIrNhuk8skdU0AHgx4ILiA4rR96ifWwxtrFQF+h+DL2ZB7xhwcOJ
// +Pa7IC4wIaEp/oBmmX+JHSzfQt6/If4ohwikfxfljKMyIcMlwl4=</X509Certificate></X50
// 9Data></KeyInfo></Signature></PRODUCTS>
//
// Resolved the base Uri and relative Uri to the following:
// http://www.contoso.com/xml
// This sample completed successfully; press Enter to exit.
//</Snippet2>
