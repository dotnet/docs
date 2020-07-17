/// Class: System.Runtime.Remoting.Metadata.SoapMethodAttribute
///    100    class
///    110    ResponseXmlElementName
///    110    ResponseXmlNamespace
///    110    ReturnXmlElementName
///    110    SoapAction
///    110    XmlNamespace
///    !    #ctor cannot be snippeted because attribute is not constructed
///        using new, but rather implicitly constructed through an attribute
///        tag.
///
///    !    UseAttribute cannot be snippeted because exception is thrown.
//<snippet100>
#using <System.dll>
#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata;

namespace ExampleNamespace
{
   public ref class ExampleClass
   {
   public:
      //<snippet110>
      [SoapMethod(
         ResponseXmlElementName="ExampleResponseElement",
         ResponseXmlNamespace=
         "http://example.org/MethodResponseXmlNamespace",
         ReturnXmlElementName="HelloMessage",
         SoapAction="http://example.org/ExampleSoapAction#GetHello",
         XmlNamespace="http://example.org/MethodCallXmlNamespace")]
      String^ GetHello( String^ name )
      {
         return String::Format( L"Hello, {0}", name );
      }
      //</snippet110>
   };

}

int main()
{
   
   // Get the method info object for the GetHello method.
   System::Reflection::MethodBase^ getHelloMethod = 
      ExampleNamespace::ExampleClass::typeid->GetMethod( L"GetHello" );
   
   // Print the XML namespace for the invocation of this method.
   String^ methodCallXmlNamespace =
      System::Runtime::Remoting::SoapServices::GetXmlNamespaceForMethodCall(
         getHelloMethod );
   Console::WriteLine( L"The XML namespace for the response of the method "
         L"GetHello in ExampleClass is {0}.", methodCallXmlNamespace );
   
   // Print the XML namespace for the response of this method.
   String^ methodResponseXmlNamespace =
      System::Runtime::Remoting::SoapServices::GetXmlNamespaceForMethodCall(
         getHelloMethod );
   Console::WriteLine( L"The XML namespace for the invocation of the method "
         L"GetHello in ExampleClass is {0}.", methodResponseXmlNamespace );
   
   // Print the SOAP action for this method.
   String^ getHelloSoapAction =
      System::Runtime::Remoting::SoapServices::GetXmlNamespaceForMethodCall(
         getHelloMethod );
   Console::WriteLine( L"The SOAP action for the method "
         L"GetHello in ExampleClass is {0}.", getHelloSoapAction );
}
//</snippet100>