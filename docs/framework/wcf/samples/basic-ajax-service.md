---
description: "Learn more about: Basic AJAX Service"
title: "Basic AJAX Service"
ms.date: "03/30/2017"
ms.assetid: d66d0c91-0109-45a0-a901-f3e4667c2465
---
# Basic AJAX Service

The [SimpleAjaxService sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to use Windows Communication Foundation (WCF) to create a basic ASP.NET Asynchronous JavaScript and XML (AJAX) service (a service that you can access using JavaScript code from a Web browser client). The service uses the <xref:System.ServiceModel.Web.WebGetAttribute> attribute to ensure that the service responds to HTTP GET requests and is configured to use the JavaScript Object Notation (JSON) data format for responses.

AJAX support in WCF is optimized for use with ASP.NET AJAX through the `ScriptManager` control. For an example of using WCF with ASP.NET AJAX, see the [AJAX Samples](ajax.md).

> [!NOTE]
> The set-up procedure and build instructions for this sample are located at the end of this topic.

In the following code, the <xref:System.ServiceModel.Web.WebGetAttribute> attribute is applied to the `Add` operation to ensure that the service responds to HTTP GET requests. The code uses GET for simplicity (you can construct an HTTP GET request from any Web browser). You can also use GET to enable caching. HTTP POST is the default in the absence of the `WebGetAttribute` attribute.

```csharp
[ServiceContract(Namespace = "SimpleAjaxService")]
public interface ICalculator
{
    [WebGet]
    double Add(double n1, double n2);
    //Other operations omitted…
}
```

The sample .svc file uses <xref:System.ServiceModel.Activation.WebScriptServiceHostFactory>, which adds a <xref:System.ServiceModel.Description.WebScriptEndpoint> standard endpoint to the service. The endpoint is configured at an empty address relative to the .svc file. This means that the address of the service is `http://localhost/ServiceModelSamples/service.svc`, with no additional suffixes other than the operation name.

`<%@ServiceHost language="C#" Debug="true" Service="Microsoft.Samples.SimpleAjaxService.CalculatorService" Factory="System.ServiceModel.Activation.WebScriptServiceHostFactory" %>`

The <xref:System.ServiceModel.Description.WebScriptEndpoint> is pre-configured to make the service accessible from an ASP.NET AJAX client page. The following section in Web.config can be used to make additional configuration changes to the endpoint. It can be removed if no extra changes are required.

```xml
<system.serviceModel>
  <standardEndpoints>
    <webScriptEndpoint>
      <!-- Use this element to configure the endpoint -->
      <standardEndpoint name=""  />
    </webScriptEndpoint>
  </standardEndpoints>
</system.serviceModel>
```

The <xref:System.ServiceModel.Description.WebScriptEndpoint> sets the default data format for the service to JSON instead of XML. To invoke the service, navigate to `http://localhost/ServiceModelSamples/service.svc/Add?n1=100&n2=200` after completing the set up and build steps shown later in this topic. This testing functionality is enabled by the use of a HTTP GET request.

The client Web page SimpleAjaxClientPage.aspx contains ASP.NET code to invoke the service whenever the user clicks one of the operation buttons on the page. The `ScriptManager` control is used to make a proxy to the service accessible through JavaScript.

```aspx-csharp
<asp:ScriptManager ID="ScriptManager" runat="server">
    <Services>
        <asp:ServiceReference Path="service.svc" />
    </Services>
</asp:ScriptManager>
```

The local proxy is instantiated and operations are invoked using the following JavaScript code.

```javascript
// Code for extracting arguments n1 and n2 omitted…
// Instantiate a service proxy
var proxy = new SimpleAjaxService.ICalculator();
// Code for selecting operation omitted…
proxy.Add(parseFloat(n1), parseFloat(n2), onSuccess, onFail, null);
```

If the service call succeeds, the code invokes the `onSuccess` handler and the result of the operation is displayed in a text box.

```javascript
function onSuccess(mathResult){
     document.getElementById("result").value = mathResult;
}
```
