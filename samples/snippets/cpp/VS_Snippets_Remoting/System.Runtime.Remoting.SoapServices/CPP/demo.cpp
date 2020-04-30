/// Class: System.Runtime.Remoting.SoapServices
///    100    class
///    101    CodeXmlNamespaceForClrTypeNamespace()
///    102    DecodeXmlNamespaceForClrTypeNamespace()
///    150    GetInteropFieldTypeAndNameFromXmlAttribute()
///    150    GetInteropFieldTypeAndNameFromXmlElement()
///    160    GetInteropTypeFromXmlElement()
///    160    GetInteropTypeFromXmlType()
///    140    GetSoapActionFromMethodBase()
///    140    GetTypeAndMethodNameFromSoapAction()
///    103    GetXmlElementForInteropType()
///    105    GetXmlNamespaceForMethodCall()
///    105    GetXmlNamespaceForMethodResponse()
///    104    GetXmlTypeForInteropType()
///    106    IsClrTypeNamespace()
///    140    IsSoapActionValidForMethodBase()
///    120    PreLoad(Assembly)
///    121    PreLoad(Type)
///    180    RegisterInteropXmlElement()
///    190    RegisterInteropXmlType()
///    170    RegisterSoapActionForMethodBase(MethodBase)
///    170    RegisterSoapActionForMethodBase(MethodBase,String)
///    130    XmlNsForClrType
///    131    XmlNsForClrTypeWithAssembly
///    132    XmlNsForClrTypeWithNs
///    133    XmlNsForClrTypeWithNsAndAssembly
//<snippet100>
#using <System.Runtime.Remoting.dll>
using namespace System;
using namespace System::Runtime::Remoting;

namespace ExampleNamespace
{
   [System::Runtime::Remoting::Metadata::SoapTypeAttribute(
   XmlElementName="ExampleClassElementName",
   XmlNamespace="http://example.org/ExampleXmlNamespace",
   XmlTypeName="ExampleXmlTypeName",
   XmlTypeNamespace="http://example.org/ExampleXmlTypeNamespace")]
   public ref class ExampleClass
   {
   public:

      // A field that will be serialized as an XML element.
      [System::Runtime::Remoting::Metadata::SoapField(
      XmlElementName="ExampleFieldElementName",
      XmlNamespace="http://example.org/ExampleFieldNamespace")]
      String^ ExampleFieldUsingElement;

      // A field that will be serialized as an XML attribute.
      [System::Runtime::Remoting::Metadata::SoapField(
      XmlElementName="ExampleFieldAttributeName",
      XmlNamespace="http://example.org/ExampleAttributeNamespace",
      UseAttribute=true)]
      String^ ExampleFieldUsingAttribute;

      [System::Runtime::Remoting::Metadata::SoapMethod(
      SoapAction="http://example.org/ExampleSoapAction#GetHello")]
      String^ GetHello( String^ name )
      {
         return String::Format( L"Hello, {0}", name );
      }

   };

}

[System::Security::Permissions::SecurityPermissionAttribute(
System::Security::Permissions::SecurityAction::LinkDemand,
Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
int main()
{
   //<snippet101>
   // Convert a CLR namespace and assembly name into an XML namespace.
   String^ xmlNamespace = SoapServices::CodeXmlNamespaceForClrTypeNamespace(
      L"ExampleNamespace", L"AssemblyName" );
   Console::WriteLine( L"The name of the XML namespace is {0}.", xmlNamespace );
   //</snippet101>

   //<snippet102>
   // Extract a CLR namespace and assembly name from an XML namespace.
   String^ typeNamespace;
   String^ assemblyName;
   SoapServices::DecodeXmlNamespaceForClrTypeNamespace(
      xmlNamespace,typeNamespace,assemblyName );
   Console::WriteLine( L"The name of the CLR namespace is {0}.", typeNamespace );
   Console::WriteLine( L"The name of the CLR assembly is {0}.", assemblyName );
   //</snippet102>

   //<snippet103>
   // Get the XML element name and the XML namespace for
   // an Interop type.
   String^ xmlElement;
   bool isSoapTypeAttribute = SoapServices::GetXmlElementForInteropType(
      ExampleNamespace::ExampleClass::typeid,xmlElement,xmlNamespace );
   
   // Print whether the requested value was flagged
   // with a SoapTypeAttribute.
   if ( isSoapTypeAttribute )
   {
      Console::WriteLine( L"The requested value was flagged "
      L"with the SoapTypeAttribute." );
   }
   else
   {
      Console::WriteLine( L"The requested value was not flagged "
      L"with the SoapTypeAttribute." );
   }
   
   // Print the XML element and the XML namespace.
   Console::WriteLine( L"The XML element for the type "
   L"ExampleNamespace.ExampleClass is {0}.", xmlElement );
   Console::WriteLine( L"The XML namespace for the type "
   L"ExampleNamespace.ExampleClass is {0}.", xmlNamespace );
   //</snippet103>

   //<snippet104>
   // Get the XML type name and the XML type namespace for
   // an Interop type.
   String^ xmlTypeName;
   String^ xmlTypeNamespace;
   isSoapTypeAttribute = SoapServices::GetXmlTypeForInteropType( ExampleNamespace::ExampleClass::typeid,xmlTypeName,xmlTypeNamespace );
   
   // Print whether the requested value was flagged
   // with a SoapTypeAttribute.
   if ( isSoapTypeAttribute )
   {
      Console::WriteLine( L"The requested value was flagged "
      L"with the SoapTypeAttribute." );
   }
   else
   {
      Console::WriteLine( L"The requested value was not flagged "
      L"with the SoapTypeAttribute." );
   }
   
   // Print the XML type name and the XML type namespace.
   Console::WriteLine( L"The XML type for the type "
   L"ExampleNamespace.ExampleClass is {0}.", xmlTypeName );
   Console::WriteLine( L"The XML type namespace for the type "
   L"ExampleNamespace.ExampleClass is {0}.", xmlTypeNamespace );
   //</snippet104>

   //<snippet105>
   // Print the XML namespace for a method invocation and its
   // response.
   System::Reflection::MethodBase^ getHelloMethod =
      ExampleNamespace::ExampleClass::typeid->GetMethod( L"GetHello" );
   String^ methodCallXmlNamespace =
      SoapServices::GetXmlNamespaceForMethodCall( getHelloMethod );
   String^ methodResponseXmlNamespace =
      SoapServices::GetXmlNamespaceForMethodResponse( getHelloMethod );
   Console::WriteLine( L"The XML namespace for the invocation of the method "
   L"GetHello in ExampleClass is {0}.", methodResponseXmlNamespace );
   Console::WriteLine( L"The XML namespace for the response of the method "
   L"GetHello in ExampleClass is {0}.", methodCallXmlNamespace );
   //</snippet105>

   //<snippet106>
   // Determine whether an XML namespace represents a CLR namespace.
   String^ clrNamespace = SoapServices::XmlNsForClrType;
   if ( SoapServices::IsClrTypeNamespace( clrNamespace ) )
   {
      Console::WriteLine( L"The namespace {0} is a CLR namespace.",
         clrNamespace );
   }
   else
   {
      Console::WriteLine( L"The namespace {0} is not a CLR namespace.",
         clrNamespace );
   }
   //</snippet106>
   
   //<snippet130>
   // Print the XML namespace for the CLR types.
   Console::WriteLine( L"The XML namespace for the CLR types "
   L"is {0}.", SoapServices::XmlNsForClrType );
   //</snippet130>

   //<snippet131>
   // Print the XML namespace for the CLR types
   // that have an assembly but no common language runtime namespace.
   Console::WriteLine( L"The XML namespace for the CLR types "
      L"that have an assembly but no namespace, is {0}.",
      SoapServices::XmlNsForClrTypeWithAssembly );
   //</snippet131>

   //<snippet132>
   // Print the XML namespace for the CLR types
   // that are a part of the Mscorlib.dll.
   Console::WriteLine( L"The XML namespace for the CLR types "
   L"that are part of the Mscorlib.dll, is {0}.",
      SoapServices::XmlNsForClrTypeWithNs );
   //</snippet132>

   //<snippet133>
   // Print the XML namespace for the CLR types
   // that have both an assembly and a common language runtime
   // namespace.
   Console::WriteLine( L"The XML namespace for the CLR types "
   L"that have both an assembly and a namespace, is {0}.",
      SoapServices::XmlNsForClrTypeWithNsAndAssembly );
   //</snippet133>

   //<snippet140>
   // Get the SOAP action for the method.
   System::Reflection::MethodBase^ getHelloMethodBase =
      ExampleNamespace::ExampleClass::typeid->GetMethod( L"GetHello" );
   String^ getHelloSoapAction =
      SoapServices::GetSoapActionFromMethodBase( getHelloMethodBase );
   Console::WriteLine( L"The SOAP action for the method "
   L"ExampleClass.GetHello is {0}.", getHelloSoapAction );
   bool isSoapActionValid =
      SoapServices::IsSoapActionValidForMethodBase(
         getHelloSoapAction, getHelloMethodBase );
   if ( isSoapActionValid )
   {
      Console::WriteLine( L"The SOAP action, {0}, "
      L"is valid for ExampleClass.GetHello", getHelloSoapAction );
   }
   else
   {
      Console::WriteLine( L"The SOAP action, {0}, "
      L"is not valid for ExampleClass.GetHello", getHelloSoapAction );
   }
   
   // Register the SOAP action for the GetHello method.
   SoapServices::RegisterSoapActionForMethodBase( getHelloMethodBase );
   
   // Get the type and the method names encoded into the SOAP action.
   String^ encodedTypeName;
   String^ encodedMethodName;
   SoapServices::GetTypeAndMethodNameFromSoapAction(
      getHelloSoapAction,encodedTypeName,encodedMethodName );
   Console::WriteLine( L"The type name encoded in this SOAP action is {0}.",
      encodedTypeName );
   Console::WriteLine( L"The method name encoded in this SOAP action is {0}.",
      encodedMethodName );
   //</snippet140>

   //<snippet150>
   // Get the name and the type of the field using its XML
   // element name and its XML namespace. For this query to work,
   // the containing type must be preloaded, and the XML element
   // name and the XML namespace must be explicitly declared on
   // the field using a SoapFieldAttribute.
   // Preload the containing type.
   SoapServices::PreLoad( ExampleNamespace::ExampleClass::typeid );
   
   // Get the name and the type of a field that will be
   // serialized as an XML element.
   Type^ containingType = ExampleNamespace::ExampleClass::typeid;
   String^ xmlElementNamespace = L"http://example.org/ExampleFieldNamespace";
   String^ xmlElementName = L"ExampleFieldElementName";
   Type^ fieldType;
   String^ fieldName;
   SoapServices::GetInteropFieldTypeAndNameFromXmlElement(
      containingType,xmlElementName,xmlElementNamespace,fieldType,fieldName );
   Console::WriteLine( L"The type of the field is {0}.", fieldType );
   Console::WriteLine( L"The name of the field is {0}.", fieldName );
   
   // Get the name and the type of a field that will be
   // serialized as an XML attribute.
   String^ xmlAttributeNamespace =
      L"http://example.org/ExampleAttributeNamespace";
   String^ xmlAttributeName = L"ExampleFieldAttributeName";
   SoapServices::GetInteropFieldTypeAndNameFromXmlAttribute(
      containingType,xmlAttributeName,xmlAttributeNamespace,fieldType,fieldName );
   Console::WriteLine( L"The type of the field is {0}.", fieldType );
   Console::WriteLine( L"The name of the field is {0}.", fieldName );
   //</snippet150>

   //<snippet160>
   String^ interopTypeXmlElementName = L"ExampleClassElementName";
   String^ interopTypeXmlNamespace = L"http://example.org/ExampleXmlNamespace";
   Type^ interopType = SoapServices::GetInteropTypeFromXmlElement(
      interopTypeXmlElementName, interopTypeXmlNamespace );
   Console::WriteLine( L"The interop type is {0}.", interopType );
   String^ interopTypeXmlTypeName = L"ExampleXmlTypeName";
   String^ interopTypeXmlTypeNamespace =
      L"http://example.org/ExampleXmlTypeNamespace";
   interopType = SoapServices::GetInteropTypeFromXmlType(
      interopTypeXmlTypeName,interopTypeXmlTypeNamespace );
   Console::WriteLine( L"The interop type is {0}.", interopType );
   //</snippet160>

   //<snippet170>
   // Get the method base object for the GetHello method.
   System::Reflection::MethodBase^ methodBase = 
     ExampleNamespace::ExampleClass::typeid->GetMethod( L"GetHello" );
   
   // Print its current SOAP action.
   Console::WriteLine( L"The SOAP action for the method "
      L"ExampleClass.GetHello is {0}.",
      SoapServices::GetSoapActionFromMethodBase( methodBase ) );
   
   // Set the SOAP action of the GetHello method to a new value.
   String^ newSoapAction = L"http://example.org/ExampleSoapAction#NewSoapAction";
   SoapServices::RegisterSoapActionForMethodBase( methodBase, newSoapAction );
   Console::WriteLine( L"The SOAP action for the method "
      L"ExampleClass.GetHello is {0}.",
      SoapServices::GetSoapActionFromMethodBase( methodBase ) );
   
   // Reset the SOAP action of the GetHello method to its default
   // value, which is determined using its SoapMethod attribute.
   SoapServices::RegisterSoapActionForMethodBase( methodBase );
   Console::WriteLine( L"The SOAP action for the method "
      L"ExampleClass.GetHello is {0}.",
      SoapServices::GetSoapActionFromMethodBase( methodBase ) );
   //</snippet170>

   //<snippet120>
   // Register all types in the assembly with the SoapType attribute.
   System::Reflection::Assembly^ executingAssembly =
      System::Reflection::Assembly::GetExecutingAssembly();
   SoapServices::PreLoad( executingAssembly );
   //</snippet120>

   //<snippet121>
   // Register a specific type with the SoapType attribute.
   Type^ exampleType = ExampleNamespace::ExampleClass::typeid;
   SoapServices::PreLoad( exampleType );
   //</snippet121>

   //<snippet180>
   // Get the currently registered type for the given XML element
   // and namespace.
   String^ registeredXmlElementName = L"ExampleClassElementName";
   String^ registeredXmlNamespace =
      L"http://example.org/ExampleXmlNamespace";
   Type^ registeredType =
      SoapServices::GetInteropTypeFromXmlElement(
         registeredXmlElementName, registeredXmlNamespace );
   Console::WriteLine( L"The registered interop type is {0}.",
      registeredType );
   
   // Register a new type for the XML element and namespace.
   SoapServices::RegisterInteropXmlElement(
      registeredXmlElementName,registeredXmlNamespace,String::typeid );
   
   // Get the currently registered type for the given XML element
   // and namespace.
   registeredType = SoapServices::GetInteropTypeFromXmlElement(
      registeredXmlElementName,registeredXmlNamespace );
   Console::WriteLine( L"The registered interop type is {0}.",
      registeredType );
   //</snippet180>

   //<snippet190>
   // Get the currently registered type for the given XML element
   // and namespace.
   String^ registeredXmlTypeName = L"ExampleXmlTypeName";
   String^ registeredXmlTypeNamespace =
      L"http://example.org/ExampleXmlTypeNamespace";
   registeredType = SoapServices::GetInteropTypeFromXmlType(
      registeredXmlTypeName, registeredXmlTypeNamespace );
   Console::WriteLine( L"The registered interop type is {0}.",
      registeredType );
   
   // Register a new type for the XML element and namespace.
   SoapServices::RegisterInteropXmlType( registeredXmlTypeName,
      registeredXmlTypeNamespace,String::typeid );
   
   // Get the currently registered type for the given XML element
   // and namespace.
   registeredType = SoapServices::GetInteropTypeFromXmlType(
      registeredXmlTypeName,registeredXmlTypeNamespace );
   Console::WriteLine( L"The registered interop type is {0}.",
      registeredType );
   //</snippet190>
}
//</snippet100>
