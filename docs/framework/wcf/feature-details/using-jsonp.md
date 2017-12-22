---
title: "Using JSONP"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f386718c-b4ba-4931-a610-40c27a46672a
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# Using JSONP

JSON Padding (JSONP) is a mechanism that enables cross-site scripting support in Web browsers. JSONP is designed around the ability of Web browsers to load scripts from a site different from the one the current loaded document was retrieved from. The mechanism works by padding the JSON payload with a user-defined callback function name, as shown in the following example.

```javascript
callback({"a" = \\"b\\"});
```

In the preceding example the JSON payload, `{"a" = \\"b\\"}`, is wrapped in a function call, `callback`. The callback function must already be defined in the current Web page. The content type of a JSONP response is `application/javascript`.

JSONP is not automatically enabled. To enable it, set the `javascriptCallbackEnabled` attribute to `true` on one of the HTTP standard endpoints (<xref:System.ServiceModel.Description.WebHttpEndpoint> or <xref:System.ServiceModel.Description.WebScriptEndpoint>), as shown in the following example.

```xml
<system.serviceModel>
  <standardEndpoints>
    <webHttpEndpoint>
      <standardEndpoint name="" javascriptCallbackEnabled="true"/>
    </webHttpEndpoint>
  </standardEndpoints>
</system.serviceModel>
```

The name of the callback function can be specified in a query variable called callback as shown in the following URL.

`http://baseaddress/Service/RestService?callback=functionName`

When invoked, the service sends a response like the following.

```javascript
functionName({"root":"Something"});
```  

You can also specify the callback function name by applying the <xref:System.ServiceModel.Web.JavascriptCallbackBehaviorAttribute> to the service class, as shown in the following example.

```csharp
[ServiceContract]
[JavascriptCallbackBehavior(ParameterName = "$callback")]
public class Service1
{
    [OperationContract]
    [WebGet(ResponseFormat=WebMessageFormat.Json)]
    public string GetData()
    {
    }
}
```

For the service shown previously, a request looks like the following.

`http://baseaddress/Service/RestService?$callback=anotherFunction`

When invoked, the service responds with the following.

```javascript
anotherFunction ({"root":"Something"});
```

## HTTP Status Codes

JSONP responses with HTTP status codes other than 200 include a second parameter with the numeric representation of the HTTP status code, as shown in the following example.

```javascript
anotherFunction ({"root":"Something"}, 201);
```

## Validations

The following validations are performed when JSONP is enabled:

- The WCF infrastructure throws an exception if `javascriptCallback` is enabled, a callback query-string parameter is present in the request and the response format is set to JSON.

- If the request contains the callback query string parameter but the operation is not an HTTP GET, the callback parameter is ignored.

- If the callback name is `null` or empty string the response is not formatted as JSONP.

## See also

[WCF Web HTTP Programming Model Overview](../../../../docs/framework/wcf/feature-details/wcf-web-http-programming-model-overview.md)
