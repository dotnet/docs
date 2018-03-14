---
title: "Creating WCF AJAX Services without ASP.NET"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ba4a7d1b-e277-4978-9f62-37684e6dc934
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Creating WCF AJAX Services without ASP.NET
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] AJAX services can be accessed from any JavaScript-enabled Web page, without requiring ASP.NET AJAX. This topic describes how to create such a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service.  
  
 For instructions on using [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] with ASP.NET AJAX, see [Creating WCF Services for ASP.NET AJAX](../../../../docs/framework/wcf/feature-details/creating-wcf-services-for-aspnet-ajax.md).  
  
 There are three parts to a creating a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] AJAX service:  
  
-   Creating an AJAX endpoint that can be accessed from the browser.  
  
-   Creating an AJAX-compatible service contract.  
  
-   Accessing WCF AJAX services.  
  
## Creating an AJAX Endpoint  
 The most basic way to enable AJAX support in a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service is to use the <xref:System.ServiceModel.Activation.WebServiceHostFactory> in the .svc file associated with the service, as in the following example.  
  
```  
<%ServiceHost   
    language=c#  
    Debug="true"  
    Service="Microsoft.Ajax.Samples.CityService"  
    Factory=System.ServiceModel.Activation.WebServiceHostFactory  
%>  
```  
  
 Alternatively, you can also use configuration to add an AJAX endpoint. Use the <xref:System.ServiceModel.WebHttpBinding> on the service endpoint and configure that endpoint with the <xref:System.ServiceModel.Description.WebHttpBehavior> as shown in the following code snippet.  
  
```xml  
<configuration>  
  <system.serviceModel>  
    <behaviors>  
      <endpointBehaviors>  
        <behavior name="AjaxBehavior">  
          <webHttp/>  
        </behavior>  
      </endpointBehaviors>  
    </behaviors>  
    <services>  
      <service name="Microsoft.Ajax.Samples.CityService">  
        <endpoint   
          address="ajaxEndpoint"  
          behaviorConfiguration="AjaxBehavior"  
          binding="webHttpBinding"  
          contract="Microsoft.Ajax.Samples.ICityService" />  
      </service>  
    </services>  
  </system.serviceModel>  
</configuration>  
```  
  
 For a working example, see the [AJAX Service with JSON and XML](../../../../docs/framework/wcf/samples/ajax-service-with-json-and-xml-sample.md).  
  
## Creating an AJAX-Compatible Service Contract  
 By default, service contracts exposed over an AJAX endpoint return data in the XML format. Also, by default service operations are accessible through HTTP POST requests to URLs that include the endpoint address followed by the operation name, as shown in the following example.  
  
```  
[OperationContract]  
string[] GetCities(string firstLetters);  
```  
  
 This operation is accessible using an HTTP POST to `http://serviceaddress/endpointaddress/GetCities` and return an XML message.  
  
 You can use the full Web Programming Model to customize these basic aspects. For example, you can use the <xref:System.ServiceModel.Web.WebGetAttribute> or <xref:System.ServiceModel.Web.WebInvokeAttribute> attributes to control the HTTP verb to which the operation responds or use the `UriTemplate` property of these respective attributes to specify custom URIs. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] the [WCF Web HTTP Programming Model](../../../../docs/framework/wcf/feature-details/wcf-web-http-programming-model.md) topic.  
  
 The JSON data format is often used in AJAX services. To create an operation that returns JSON instead of XML, set the <xref:System.ServiceModel.Web.WebGetAttribute.ResponseFormat%2A> (or the <xref:System.ServiceModel.Web.WebInvokeAttribute.ResponseFormat%2A>) property to <xref:System.ServiceModel.Web.WebMessageFormat.Json>. The [Stand-Alone JSON Serialization](../../../../docs/framework/wcf/feature-details/stand-alone-json-serialization.md) topic shows how built-in .NET types and data contract types map to JSON.  
  
 Normally, JSON requests and responses consist of just one item. For the preceding `GetCities` operation, the request resembles the following statement.  
  
```  
"na"  
```  
  
 The response to that request resembles the following statement.  
  
```  
["Nairobi", "Naples", "Nashville"]  
```  
  
 If the operation takes an extra parameter, the request style must be wrapped to wrap both parameters in a single JSON object. An example of this style JSON message is in the following example.  
  
```json  
{"firstLetters": "na", "maxNumber": 2}  
```  
  
 The following contract accepts this message.  
  
```  
[WebInvoke(BodyStyle=WebMessageBodyStyle.WrappedRequest, ResponseFormat=WebMessageFormat.Json)]  
[OperationContract]  
string[] GetCities(string firstLetters, int maxNumber);  
```  
  
## Accessing AJAX Services  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] AJAX endpoints always accept both JSON and XML requests.  
  
 HTTP POST requests with a content-type of "application/json" are treated as JSON, and those with content-type that indicate XML (for example, "text/xml") are treated as XML.  
  
 HTTP GET requests contain all the request parameters in the URL itself.  
  
 It is up to the user to decide how to create the HTTP request to the endpoint. Also, the user has full control over constructing the JSON that forms the body of the request. For an example of creating a request from JavaScript, see the [AJAX Service with JSON and XML](../../../../docs/framework/wcf/samples/ajax-service-with-json-and-xml-sample.md).
