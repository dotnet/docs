---
description: "Learn more about: JSONP"
title: "JSONP"
ms.date: "03/30/2017"
ms.assetid: c13b4d7b-dac7-4ffd-9f84-765c903511e1
---
# JSONP

The [JSONP sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to support JSON with Padding (JSONP) in WCF REST services. JSONP is a convention used to invoke cross-domain scripts by generating script tags in the current document. The result is returned in a specified callback function. JSONP is based on the idea that tags such as `<script src="http://..." >` can evaluate scripts from any domain and the script retrieved by those tags is evaluated within a scope in which other functions may already be defined.

## Demonstrates

Cross-domain scripting with JSONP.

## Discussion

The sample includes a Web page that dynamically adds a script block after the page has been rendered in the browser. This script block calls a WCF REST service that has a single operation, `GetCustomer`. The WCF REST service returns a customer's name and address wrapped in a callback function name. When the WCF REST service responds, the callback function on the Web page is invoked with the customer data and the callback function displays the data on the Web page. The injection of the script tag and the execution of the callback function is automatically handled by the ASP.NET AJAX ScriptManager control. The usage pattern is the same as with all ASP.NET AJAX proxies, with the addition of one line to enable JSONP, as shown in the following code:

```csharp
var proxy = new JsonpAjaxService.CustomerService();
proxy.set_enableJsonp(true);
proxy.GetCustomer(onSuccess, onFail, null);
```

The Web page can call the WCF REST service because the service is using the <xref:System.ServiceModel.Description.WebScriptEndpoint> with `crossDomainScriptAccessEnabled` set to `true`. Both of these configurations are done in the Web.config file under the \<system.serviceModel> element.

```xml
<system.serviceModel>
  <serviceHostingEnvironment aspNetCompatibilityEnabled="true"/>
  <standardEndpoints>
    <webScriptEndpoint>
      <standardEndpoint name="" crossDomainScriptAccessEnabled="true"/>
    </webScriptEndpoint>
  </standardEndpoints>
</system.serviceModel>
```

ScriptManager manages the interaction with the service and hides away the complexity of manually implementing JSONP access. When `crossDomainScriptAccessEnabled` is set to `true` and the response format for an operation is JSON, the WCF infrastructure inspects the URI of the request for a callback query string parameter and wraps the JSON response with the value of the callback query string parameter. In the sample, the Web page calls the WCF REST service with the following URI.

```http
http://localhost:33695/CustomerService/GetCustomer?callback=Sys._json0
```

Because the callback query string parameter has a value of `JsonPCallback`, the WCF service returns a JSONP response shown in the following example.

```json
Sys._json0({"__type":"Customer:#Microsoft.Samples.Jsonp","Address":"1 Example Way","Name":"Bob"});
```

This JSONP response includes the customer data formatted as JSON, wrapped with the callback function name that the Web page requested. ScriptManager will execute this callback using a script tag to accomplish the cross-domain request, and then pass the result to the onSuccess handler that was passed to the GetCustomer operation of the ASP.NET AJAX proxy.

The sample consists of two ASP.NET web applications: one contains just a WCF service, and another one contains the .aspx webpage, which calls the service. When running the solution, Visual Studio will host the two websites on different ports, which creates an environment where the service and client live on different domains.

#### To run the sample

1. Open the solution for the JSONP Sample.

2. press **F5** to launch `http://localhost:26648/JSONPClientPage.aspx` in the browser.

3. Notice that after the page loads, the text inputs for "Name" and "Address" are populated by values. These values were supplied from a call to the WCF service after the browser finished rendering the page.
