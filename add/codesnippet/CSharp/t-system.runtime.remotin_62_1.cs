using System;
using System.Runtime.Remoting;

namespace ExampleNamespace
{
    [System.Runtime.Remoting.Metadata.SoapTypeAttribute(
         XmlElementName="ExampleClassElementName",
         XmlNamespace="http://example.org/ExampleXmlNamespace",
         XmlTypeName="ExampleXmlTypeName",
         XmlTypeNamespace="http://example.org/ExampleXmlTypeNamespace")]
    public class ExampleClass
    {
        // A field that will be serialized as an XML element.
        [System.Runtime.Remoting.Metadata.SoapField(
             XmlElementName="ExampleFieldElementName",
             XmlNamespace="http://example.org/ExampleFieldNamespace")]
        public string ExampleFieldUsingElement;

        // A field that will be serialized as an XML attribute.
        [System.Runtime.Remoting.Metadata.SoapField(
             XmlElementName="ExampleFieldAttributeName",
             XmlNamespace="http://example.org/ExampleAttributeNamespace",
             UseAttribute=true)]
        public string ExampleFieldUsingAttribute;

        [System.Runtime.Remoting.Metadata.SoapMethod(
             SoapAction="http://example.org/ExampleSoapAction#GetHello")]
        public string GetHello(string name)
        {
            return "Hello, " + name;
        }
    }
}

public class Demo
{
    [System.Security.Permissions.SecurityPermissionAttribute(
    System.Security.Permissions.SecurityAction.LinkDemand,
    Flags=System.Security.Permissions.SecurityPermissionFlag.Infrastructure)]
    public static void Main(string[] args)
    {
        // Convert a CLR namespace and assembly name into an XML namespace.
        string xmlNamespace = 
            SoapServices.CodeXmlNamespaceForClrTypeNamespace(
            "ExampleNamespace", "AssemblyName");
        Console.WriteLine("The name of the XML namespace is {0}.", 
            xmlNamespace);

        // Extract a CLR namespace and assembly name from an XML namespace.
        string typeNamespace;
        string assemblyName;
        SoapServices.DecodeXmlNamespaceForClrTypeNamespace(xmlNamespace,
            out typeNamespace, out assemblyName);
        Console.WriteLine("The name of the CLR namespace is {0}.", 
            typeNamespace);
        Console.WriteLine("The name of the CLR assembly is {0}.", 
            assemblyName);

        // Get the XML element name and the XML namespace for 
        // an Interop type.
        string xmlElement;
        bool isSoapTypeAttribute =
            SoapServices.GetXmlElementForInteropType(
            typeof(ExampleNamespace.ExampleClass), 
            out xmlElement, out xmlNamespace);

        // Print whether the requested value was flagged 
        // with a SoapTypeAttribute.
        if (isSoapTypeAttribute)
        {
            Console.WriteLine(
                "The requested value was flagged " +
                "with the SoapTypeAttribute.");
        }
        else 
        {
            Console.WriteLine(
                "The requested value was not flagged " +
                "with the SoapTypeAttribute.");
        }

        // Print the XML element and the XML namespace.
        Console.WriteLine(
            "The XML element for the type " +
            "ExampleNamespace.ExampleClass is {0}.",
            xmlElement);
        Console.WriteLine(
            "The XML namespace for the type " +
            "ExampleNamespace.ExampleClass is {0}.",
            xmlNamespace);

        // Get the XML type name and the XML type namespace for 
        // an Interop type.
        string xmlTypeName;
        string xmlTypeNamespace;
        isSoapTypeAttribute =
            SoapServices.GetXmlTypeForInteropType(
            typeof(ExampleNamespace.ExampleClass), 
            out xmlTypeName, out xmlTypeNamespace);

        // Print whether the requested value was flagged 
        // with a SoapTypeAttribute.
        if (isSoapTypeAttribute)
        {
            Console.WriteLine(
                "The requested value was flagged " +
                "with the SoapTypeAttribute.");
        }
        else 
        {
            Console.WriteLine(
                "The requested value was not flagged " +
                "with the SoapTypeAttribute.");
        }

        // Print the XML type name and the XML type namespace.
        Console.WriteLine(
            "The XML type for the type " +
            "ExampleNamespace.ExampleClass is {0}.",
            xmlTypeName);
        Console.WriteLine(
            "The XML type namespace for the type " +
            "ExampleNamespace.ExampleClass is {0}.",
            xmlTypeNamespace);

        // Print the XML namespace for a method invocation and its
        // response.
        System.Reflection.MethodBase getHelloMethod = 
            typeof(ExampleNamespace.ExampleClass).GetMethod("GetHello");
        string methodCallXmlNamespace = 
            SoapServices.GetXmlNamespaceForMethodCall(getHelloMethod);
        string methodResponseXmlNamespace =
            SoapServices.GetXmlNamespaceForMethodResponse(getHelloMethod);
        Console.WriteLine(
            "The XML namespace for the invocation of the method " +
            "GetHello in ExampleClass is {0}.",
            methodResponseXmlNamespace);
        Console.WriteLine(
            "The XML namespace for the response of the method " +
            "GetHello in ExampleClass is {0}.",
            methodCallXmlNamespace);

        // Determine whether an XML namespace represents a CLR namespace.
        string clrNamespace = SoapServices.XmlNsForClrType;
        if (SoapServices.IsClrTypeNamespace(clrNamespace))
        {
            Console.WriteLine(
                "The namespace {0} is a CLR namespace.",
                clrNamespace);
        }
        else 
        {
            Console.WriteLine(
                "The namespace {0} is not a CLR namespace.",
                clrNamespace);
        }

        // Print the XML namespace for the CLR types.
        Console.WriteLine(
            "The XML namespace for the CLR types " + 
            "is {0}.",
            SoapServices.XmlNsForClrType);

        // Print the XML namespace for the CLR types 
        // that have an assembly but no common language runtime namespace.
        Console.WriteLine(
            "The XML namespace for the CLR types " +
            "that have an assembly but no namespace, is {0}.",
            SoapServices.XmlNsForClrTypeWithAssembly);

        // Print the XML namespace for the CLR types 
        // that are a part of the Mscorlib.dll.
        Console.WriteLine(
            "The XML namespace for the CLR types " +
            "that are part of the Mscorlib.dll, is {0}.",
            SoapServices.XmlNsForClrTypeWithNs);

        // Print the XML namespace for the CLR types 
        // that have both an assembly and a common language runtime 
        // namespace.
        Console.WriteLine(
            "The XML namespace for the CLR types " +
            "that have both an assembly and a namespace, is {0}.",
            SoapServices.XmlNsForClrTypeWithNsAndAssembly);

        
        // Get the SOAP action for the method.
        System.Reflection.MethodBase getHelloMethodBase = 
            typeof(ExampleNamespace.ExampleClass).GetMethod("GetHello");
        string getHelloSoapAction =
            SoapServices.GetSoapActionFromMethodBase(getHelloMethodBase);
        Console.WriteLine(
            "The SOAP action for the method " +
            "ExampleClass.GetHello is {0}.", getHelloSoapAction);
        bool isSoapActionValid = SoapServices.IsSoapActionValidForMethodBase(
            getHelloSoapAction,
            getHelloMethodBase);
        if (isSoapActionValid)
        {
            Console.WriteLine(
                "The SOAP action, {0}, " + 
                "is valid for ExampleClass.GetHello", 
                getHelloSoapAction);
        }
        else
        {
            Console.WriteLine(
                "The SOAP action, {0}, " + 
                "is not valid for ExampleClass.GetHello", 
                getHelloSoapAction);
        }

        // Register the SOAP action for the GetHello method.
        SoapServices.RegisterSoapActionForMethodBase(getHelloMethodBase);

        // Get the type and the method names encoded into the SOAP action.
        string encodedTypeName;
        string encodedMethodName;
        SoapServices.GetTypeAndMethodNameFromSoapAction(
            getHelloSoapAction, 
            out encodedTypeName, 
            out encodedMethodName);
        Console.WriteLine(
            "The type name encoded in this SOAP action is {0}.",
            encodedTypeName);
        Console.WriteLine(
            "The method name encoded in this SOAP action is {0}.",
            encodedMethodName);

        // Get the name and the type of the field using its XML 
        // element name and its XML namespace. For this query to work,
        // the containing type must be preloaded, and the XML element 
        // name and the XML namespace must be explicitly declared on 
        // the field using a SoapFieldAttribute.

        // Preload the containing type.
        SoapServices.PreLoad(typeof(ExampleNamespace.ExampleClass));

        // Get the name and the type of a field that will be 
        // serialized as an XML element.
        Type containingType = typeof(ExampleNamespace.ExampleClass);
        string xmlElementNamespace = 
            "http://example.org/ExampleFieldNamespace";
        string xmlElementName = "ExampleFieldElementName";
        Type fieldType;
        string fieldName;
        SoapServices.GetInteropFieldTypeAndNameFromXmlElement(
            containingType, xmlElementName, xmlElementNamespace, 
            out fieldType, out fieldName);
        Console.WriteLine(
            "The type of the field is {0}.",
            fieldType);
        Console.WriteLine(
            "The name of the field is {0}.",
            fieldName);

        // Get the name and the type of a field that will be 
        // serialized as an XML attribute.
        string xmlAttributeNamespace = 
            "http://example.org/ExampleAttributeNamespace";
        string xmlAttributeName = "ExampleFieldAttributeName";
        SoapServices.GetInteropFieldTypeAndNameFromXmlAttribute(
            containingType, xmlAttributeName, xmlAttributeNamespace, 
            out fieldType, out fieldName);
        Console.WriteLine(
            "The type of the field is {0}.",
            fieldType);
        Console.WriteLine(
            "The name of the field is {0}.",
            fieldName);

        
        string interopTypeXmlElementName = 
            "ExampleClassElementName";
        string interopTypeXmlNamespace = 
            "http://example.org/ExampleXmlNamespace";
        Type interopType = SoapServices.GetInteropTypeFromXmlElement(
            interopTypeXmlElementName, 
            interopTypeXmlNamespace);
        Console.WriteLine("The interop type is {0}.", interopType);

        string interopTypeXmlTypeName = 
            "ExampleXmlTypeName";
        string interopTypeXmlTypeNamespace = 
            "http://example.org/ExampleXmlTypeNamespace";
        interopType = SoapServices.GetInteropTypeFromXmlType(
            interopTypeXmlTypeName, interopTypeXmlTypeNamespace);
        Console.WriteLine("The interop type is {0}.", interopType);

        // Get the method base object for the GetHello method.
        System.Reflection.MethodBase methodBase = 
            typeof(ExampleNamespace.ExampleClass).GetMethod("GetHello");

        // Print its current SOAP action.
        Console.WriteLine(
            "The SOAP action for the method " +
            "ExampleClass.GetHello is {0}.",
            SoapServices.GetSoapActionFromMethodBase(methodBase));
        
        // Set the SOAP action of the GetHello method to a new value.
        string newSoapAction = 
            "http://example.org/ExampleSoapAction#NewSoapAction";
        SoapServices.RegisterSoapActionForMethodBase(
            methodBase, newSoapAction);
        Console.WriteLine(
            "The SOAP action for the method " +
            "ExampleClass.GetHello is {0}.",
            SoapServices.GetSoapActionFromMethodBase(methodBase));

        // Reset the SOAP action of the GetHello method to its default
        // value, which is determined using its SoapMethod attribute.
        SoapServices.RegisterSoapActionForMethodBase(methodBase);
        Console.WriteLine(
            "The SOAP action for the method " +
            "ExampleClass.GetHello is {0}.",
            SoapServices.GetSoapActionFromMethodBase(methodBase));

        // Register all types in the assembly with the SoapType attribute.
        System.Reflection.Assembly executingAssembly =
            System.Reflection.Assembly.GetExecutingAssembly();
        SoapServices.PreLoad(executingAssembly);

        // Register a specific type with the SoapType attribute.
        Type exampleType = typeof(ExampleNamespace.ExampleClass);
        SoapServices.PreLoad(exampleType);

        // Get the currently registered type for the given XML element 
        // and namespace.
        string registeredXmlElementName = 
            "ExampleClassElementName";
        string registeredXmlNamespace = 
            "http://example.org/ExampleXmlNamespace";
        Type registeredType = 
            SoapServices.GetInteropTypeFromXmlElement(
            registeredXmlElementName, 
            registeredXmlNamespace);
        Console.WriteLine(
            "The registered interop type is {0}.",
            registeredType);

        // Register a new type for the XML element and namespace.
        SoapServices.RegisterInteropXmlElement(
            registeredXmlElementName,
            registeredXmlNamespace, 
            typeof(String));

        // Get the currently registered type for the given XML element 
        // and namespace.
        registeredType = 
            SoapServices.GetInteropTypeFromXmlElement(
            registeredXmlElementName, 
            registeredXmlNamespace);
        Console.WriteLine(
            "The registered interop type is {0}.",
            registeredType);

        // Get the currently registered type for the given XML element 
        // and namespace.
        string registeredXmlTypeName = 
            "ExampleXmlTypeName";
        string registeredXmlTypeNamespace = 
            "http://example.org/ExampleXmlTypeNamespace";
        registeredType = 
            SoapServices.GetInteropTypeFromXmlType(
            registeredXmlTypeName, 
            registeredXmlTypeNamespace);
        Console.WriteLine(
            "The registered interop type is {0}.",
            registeredType);

        // Register a new type for the XML element and namespace.
        SoapServices.RegisterInteropXmlType(
            registeredXmlTypeName,
            registeredXmlTypeNamespace, 
            typeof(String));

        // Get the currently registered type for the given XML element 
        // and namespace.
        registeredType = 
            SoapServices.GetInteropTypeFromXmlType(
            registeredXmlTypeName, 
            registeredXmlTypeNamespace);
        Console.WriteLine(
            "The registered interop type is {0}.",
            registeredType);
    }
}