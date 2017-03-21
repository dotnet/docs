#using <System.dll>
#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting::Metadata;

namespace ExampleNamespace
{
   public ref class ExampleClass
   {
   public:
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