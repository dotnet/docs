---
description: "Learn more about: Serializing in Json with Message Level Programming"
title: "Serializing in Json with Message Level Programming"
ms.date: "03/30/2017"
ms.assetid: 5f940ba2-57ee-4c49-a779-957c5e7e71fa
---
# Serializing in Json with Message Level Programming

WCF supports serializing data in JSON format. This topic describes how to tell WCF to serialize your types using the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer>.  
  
## Typed Message Programming  

 The <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> is used when the <xref:System.ServiceModel.Web.WebGetAttribute> or the <xref:System.ServiceModel.Web.WebInvokeAttribute> is applied to a service operation. Both of these attributes allow you to specify the `RequestFormat` and `ResponseFormat`. To use JSON for requests and responses. set both of these to `WebMessageFormat.Json`.  In order to use JSON, you must use the <xref:System.ServiceModel.WebHttpBinding>, which automatically configures the <xref:System.ServiceModel.Description.WebHttpBehavior>. For more information about WCF serialization, see [Serialization and Deserialization](serialization-and-deserialization.md). For more information about JSON and WCF, see [Service Station - An Introduction To RESTful Services With WCF](/archive/msdn-magazine/2009/january/service-station-an-introduction-to-restful-services-with-wcf).  
  
> [!IMPORTANT]
> Using JSON requires use of <xref:System.ServiceModel.WebHttpBinding> and <xref:System.ServiceModel.Description.WebHttpBehavior> which do not support SOAP communication. Services that communicate with the <xref:System.ServiceModel.WebHttpBinding> do not support exposing service metadata so you will not be able to use Visual Studio’s Add Service Reference functionality or the svcutil command-line tool to generate a client-side proxy. For more information how you can programmatically call services that use <xref:System.ServiceModel.WebHttpBinding>, see [How to Consume REST Services with WCF](/archive/blogs/pedram/how-to-consume-rest-services-with-wcf).  
  
## Untyped Message Programming  

 When working directly with untyped Message objects, you must explicitly set the properties on the untyped message to serialize it as JSON. The following code snippet shows how to do this.  
  
```csharp
 Message response = Message.CreateMessage(  
                  MessageVersion.None,    // No SOAP message version  
                             "*",                     // SOAP action, ignored since this is JSON  
                             "Response string: JSON format specified", // Message body  
                             new DataContractJsonSerializer(typeof(string))); // Specify DataContractJsonSerializer  
      response.Properties.Add( WebBodyFormatMessageProperty.Name,
                    new WebBodyFormatMessageProperty(WebContentFormat.Json)); // Use JSON format  
```  
  
## See also

- [AJAX Integration and JSON Support](ajax-integration-and-json-support.md)
- [Stand-Alone JSON Serialization](stand-alone-json-serialization.md)
- [JSON Serialization](/previous-versions/dotnet/framework/wcf/samples/json-serialization)
