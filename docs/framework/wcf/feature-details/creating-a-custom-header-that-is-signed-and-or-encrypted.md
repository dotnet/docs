---
description: "Learn more about: Creating a custom header that is signed and-or encrypted"
title: "Creating a custom header that is signed and-or encrypted"
ms.date: "03/30/2017"
ms.assetid: e8668b37-c79f-4714-9de5-afcb88b9ff02
---
# Creating a custom header that is signed and-or encrypted

When calling a non-WCF service using a WCF client it is sometimes necessary to use custom SOAP headers. There is a canonicalization bug in WCF that prevents custom headers that are signed and encrypted from working with a non-WCF service. The problem is caused by the incorrect canonicalization of default XML namespaces. This is only problematic when calling non-WCF services with custom headers that are signed and/or encrypted.  When the service receives the message containing the signed and/or encrypted custom header it is unable to verify the signature. This workaround avoids the canonicalization bug, allows interoperability with non-WCF services, but does not prevent interoperability with WCF services.  
  
## Defining the custom header  

 Custom headers are defined by defining a message contract and marking the members you want to be sent as headers with a <xref:System.ServiceModel.MessageHeaderAttribute> attribute. To work around the canonicalization bug you must ensure that the XML serializer declares the namespace for the custom header with a prefix instead of a default namespace declaration. The following code shows how to define the data type that will be used as a message header with the correct namespace declaration.  
  
```csharp
[System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "3.0.4506.648")]  
[System.SerializableAttribute()]  
[System.Diagnostics.DebuggerStepThroughAttribute()]  
[System.ComponentModel.DesignerCategoryAttribute("code")]  
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.example.org/getMessage/")]  
public partial class msgHeaderElement  
{  
   // Define the XML namespace and force it to use an ‘h’ prefix  
    [System.Xml.Serialization.XmlNamespaceDeclarations]  
    public System.Xml.Serialization.XmlSerializerNamespaces _xsns = new System.Xml.Serialization.XmlSerializerNamespaces(new System.Xml.XmlQualifiedName[] { new System.Xml.XmlQualifiedName("h", "http://www.example.org/getMessage/") });  
  
    private string msgHeaderInputField;  
  [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]  
    public string msgHeaderInput  
    {  
        get  
        {  
            return this.msgHeaderInputField;  
        }  
        set  
        {  
            this.msgHeaderInputField = value;  
        }  
    }  
}  
```  
  
 This code declares a new type called `msgHeaderElement` that will be serialized with the XML Serializer. When an instance of this type is serialized, it will define a namespace with an ‘h’ prefix, thus working around the canonicalization bug.  The message contract would then define an instance of `msgHeaderElement` and mark it with the <xref:System.ServiceModel.MessageHeaderAttribute> attribute as shown in the following example.  
  
```csharp
[MessageContract]  
public  class MyMessageContract  
{  
   // other message contents...  
   [MessageHeader(ProductionLevel=ProtectionLevel.EncryptAndSign)]  
   public msgHeaderElement;  
   // other message contents...  
}  
```  
  
## See also

- [Default Message Contract](../samples/default-message-contract.md)
- [Message Contracts](../samples/message-contracts.md)
- [Using Message Contracts](using-message-contracts.md)
