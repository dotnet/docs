---
description: "Learn more about: WebContentTypeMapper Sample"
title: "WebContentTypeMapper Sample"
ms.date: "03/30/2017"
ms.assetid: a4fe59e7-44d8-43c6-a1f8-40c45223adca
---
# WebContentTypeMapper Sample

The [WebContentTypeMapper sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to map new content types to Windows Communication Foundation (WCF) message body formats.

The <xref:System.ServiceModel.Description.WebHttpEndpoint> element plugs in the Web message encoder, which allows WCF to receive JSON, XML, or raw binary messages at the same endpoint. The encoder determines the body format of the message by looking at the HTTP content-type of the request. This sample introduces the <xref:System.ServiceModel.Channels.WebContentTypeMapper> class, which allows the user to control the mapping between content type and body format.

WCF provides a set of default mappings for content types. For example, `application/json` maps to JSON and `text/xml` maps to XML. Any content type that is not mapped to JSON or XML is mapped to raw binary format.

In some scenarios (for example, push-style APIs), the service developer does not control the content type returned by the client. For example, clients might return JSON as `text/javascript` instead of `application/json`. In this case, the service developer must provide a type that derives from <xref:System.ServiceModel.Channels.WebContentTypeMapper> to handle the given content type correctly, as shown in the following sample code.

```csharp
public class JsonContentTypeMapper : WebContentTypeMapper
{
    public override WebContentFormat
               GetMessageFormatForContentType(string contentType)
    {
        if (contentType == "text/javascript")
        {
            return WebContentFormat.Json;
        }
        else
        {
            return WebContentFormat.Default;
        }
    }
}
```

The type must override the <xref:System.ServiceModel.Channels.WebContentTypeMapper.GetMessageFormatForContentType%28System.String%29> method. The method must evaluate the `contentType` argument and return one of the following values: <xref:System.ServiceModel.Channels.WebContentFormat.Json>, <xref:System.ServiceModel.Channels.WebContentFormat.Xml>, <xref:System.ServiceModel.Channels.WebContentFormat.Raw>, or <xref:System.ServiceModel.Channels.WebContentFormat.Default>. Returning <xref:System.ServiceModel.Channels.WebContentFormat.Default> defers to the default Web message encoder mappings. In the previous sample code, the `text/javascript` content type is mapped to JSON, and all other mappings remain unchanged.

To use the `JsonContentTypeMapper` class, use the following in your Web.config:

```xml
<system.serviceModel>
  <standardEndpoints>
    <webHttpEndpoint>
      <standardEndpoint name="" contentTypeMapper="Microsoft.Samples.WebContentTypeMapper.JsonContentTypeMapper, JsonContentTypeMapper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" />
    </webHttpEndpoint>
  </standardEndpoints>
</system.serviceModel>
```

To verify the requirement for using the JsonContentTypeMapper, remove the contentTypeMapper attribute from the above configuration file. The client page fails to load when attempting to use `text/javascript` to send JSON content.

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. Build the solution WebContentTypeMapperSample.sln as described in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. Navigate to `http://localhost/ServiceModelSamples/JCTMClientPage.htm` (do not open JCTMClientPage.htm in the browser from within the project directory).
