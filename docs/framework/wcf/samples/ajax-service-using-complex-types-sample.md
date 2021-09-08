---
description: "Learn more about: AJAX Service Using Complex Types Sample"
title: "AJAX Service Using Complex Types Sample"
ms.date: "03/30/2017"
ms.assetid: 88242b99-4811-4cbe-8201-52ddf48fb174
---
# AJAX Service Using Complex Types Sample

The [ComplexTypeAjaxService sample](https://github.com/dotnet/samples/tree/main/framework/wcf/Basic/Ajax/ComplexTypeAjaxService) demonstrates how to use Windows Communication Foundation (WCF) to create an ASP.NET Asynchronous JavaScript and XML (AJAX) service that creates instances of complex types and sends them between service and client as JavaScript Object Notation (JSON). You can access an AJAX service by using JavaScript code from a Web browser client. This sample builds on the [Basic AJAX Service](basic-ajax-service.md) sample.

AJAX support in WCF is optimized for use with ASP.NET AJAX through the <xref:System.Web.UI.ScriptManager> control. For an example of using WCF with ASP.NET AJAX, see the [AJAX Samples](ajax.md).

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

The service in the following sample is a WCF service with no AJAX-specific code. Because the <xref:System.ServiceModel.Web.WebGetAttribute> attribute is not applied, the default HTTP verb ("POST") is used. The service has one operation, `DoMath`, which returns a complex type named `MathResult`. The complex type is a standard data contract type, which also contains no AJAX-specific code.

```csharp
[DataContract]
public class MathResult
{
    [DataMember]
    public double sum;
    [DataMember]
    public double difference;
    [DataMember]
    public double product;
    [DataMember]
    public double quotient;
}
```

Create an AJAX endpoint on the service by using the <xref:System.ServiceModel.Activation.WebScriptServiceHostFactory>, just as in the Basic AJAX Service sample.

The client Web page ComplexTypeClientPage.aspx contains ASP.NET and JavaScript code to invoke the service when the user clicks the **Perform calculation** button on the page. The code to invoke the service constructs a JSON body and sends it using HTTP POST, similar to the [AJAX Service Using HTTP POST](ajax-service-using-http-post.md) sample.

After the service call succeeds, you can access the individual data members (`sum`, `difference`, `product` and `quotient`) on the resulting JavaScript object.

```javascript
function onSuccess(mathResult){
     document.getElementById("sum").value = mathResult.sum;
     document.getElementById("difference").value = mathResult.difference;
     document.getElementById("product").value = mathResult.product;
     document.getElementById("quotient").value = mathResult.quotient;
}
```

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. Build the solution ComplexTypeAjaxService.sln as described in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. Navigate to `http://localhost/ServiceModelSamples/ComplexTypeClientPage.aspx` (do not open ComplexTypeClientPage.aspx in the browser from the project directory).

## See also

- [Basic AJAX Service](basic-ajax-service.md)
