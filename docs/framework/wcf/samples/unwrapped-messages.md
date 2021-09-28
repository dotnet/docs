---
description: "Learn more about: Unwrapped Messages"
title: "Unwrapped Messages"
ms.date: "03/30/2017"
ms.assetid: 019657bd-1f9b-4315-ad74-eaa4e7551ff6
---
# Unwrapped Messages

The [Unwrapped sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates unwrapped messages. By default, the message body is formatted such that the parameters to a service operation are wrapped. The following sample shows an `Add` request message to the `ICalculator` service in wrapped mode.

```xml
<s:Envelope
    xmlns:s="http://www.w3.org/2003/05/soap-envelope"
    xmlns:a="http://schemas.xmlsoap.org/ws/2005/08/addressing">
    <s:Header>
        …
    </s:Header>
    <s:Body>
      <Add xmlns="http://Microsoft.ServiceModel.Samples">
        <n1>100</n1>
        <n2>15.99</n2>
      </Add>
    </s:Body>
</s:Envelope>
```

The `<Add>` element in the message body wraps the `n1` and `n2` parameters. In contrast, the following sample shows the equivalent message in the unwrapped mode.

```xml
<s:Envelope
    xmlns:s="http://www.w3.org/2003/05/soap-envelope"
    xmlns:a="http://schemas.xmlsoap.org/ws/2005/08/addressing">
    <s:Header>
        ….
    </s:Header>
    <s:Body>
      <n1 xmlns="http://Microsoft.ServiceModel.Samples">100</n1>
      <n2 xmlns="http://Microsoft.ServiceModel.Samples">15.99</n2>
    </s:Body>
  </s:Envelope>
```

The unwrapped message does not wrap the `n1` and `n2` parameters in a containing element, they are direct children of the soap body element.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

In this sample, an unwrapped message is created by applying the <xref:System.ServiceModel.MessageContractAttribute> to the service operation parameter type and return value type as shown in the following sample code.

```csharp
[ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
public interface ICalculator
{
    [OperationContract]
    ResponseMessage Add(RequestMessage request);
    [OperationContract]
    ResponseMessage Subtract(RequestMessage request);
    [OperationContract]
    ResponseMessage Multiply(RequestMessage request);
    [OperationContract]
    ResponseMessage Divide(RequestMessage request);
}

//setting IsWrapped to false means the n1 and n2
//members will be direct children of the soap body element
[MessageContract(IsWrapped = false)]
public class RequestMessage
{
    [MessageBodyMember]
    private double n1;
    [MessageBodyMember]
    private double n2;
    //…
}

//setting IsWrapped to false means the result
//member will be a direct child of the soap body element
[MessageContract(IsWrapped = false)]
public class ResponseMessage
{
    [MessageBodyMember]
    private double result;
    //…
}
```

To allow you to see the messages being sent and received, this sample uses tracing. In addition, the <xref:System.ServiceModel.WSHttpBinding> has been configured without security, to reduce the number of messages it logs.

The resulting trace log (c:\logs\Message.log) can be viewed by using the [Service Trace Viewer Tool (SvcTraceViewer.exe)](../service-trace-viewer-tool-svctraceviewer-exe.md). To view message contents, select **Messages** in both the left and the right panes of the Service Trace Viewer tool. Trace logs in this sample are configured to be generated into the C:\LOGS folder. Create this folder before running the sample and give the user Network Service write permissions for this directory.

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. Create a C:\LOGS directory for logging messages. Give the user Network Service write permissions for this directory.

3. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

4. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
