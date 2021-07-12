---
description: "Learn more about: XmlSerializer Faults"
title: "XmlSerializer Faults"
ms.date: "03/30/2017"
ms.assetid: c6b80f14-64f4-4162-ae76-71664cf42fd3
---
# XmlSerializer Faults

The [XmlSerializerFaults sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to communicate error information from a service to a client using the <xref:System.Xml.Serialization.XmlSerializer>. The sample is based on the [Getting Started](getting-started-sample.md), with some additional code added to the service to convert an internal exception to a fault. The client attempts to perform division by zero to force an error condition on the service.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

The calculator contract has been modified to include a <xref:System.ServiceModel.FaultContractAttribute> as shown in the following sample code. Also, the <xref:System.ServiceModel.XmlSerializerFormatAttribute> is used to enable serialization using the <xref:System.Xml.Serialization.XmlSerializer>. The <xref:System.ServiceModel.XmlSerializerFormatAttribute.SupportFaults%2A> property is set to `true` on this attribute, which instructs the serializer to use the <xref:System.Xml.Serialization.XmlSerializer> for reading and writing faults.

```csharp
[XmlSerializerFormat(SupportFaults=true)]
[ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
public interface ICalculator
{
    [OperationContract]
    int Add(int n1, int n2);

    [OperationContract]
    int Subtract(int n1, int n2);

    [OperationContract]
    int Multiply(int n1, int n2);

    [OperationContract]
    [FaultContract(typeof(MathFault))]
    int Divide(int n1, int n2);
}
```

When generating code for the client proxy, you must apply the **/UseSerializerForFaults** flag to [ServiceModel Metadata Utility Tool (Svcutil.exe)](../servicemodel-metadata-utility-tool-svcutil-exe.md).

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).

## See also

- <xref:System.ServiceModel.XmlSerializerFormatAttribute>
- <xref:System.ServiceModel.XmlSerializerFormatAttribute.SupportFaults%2A>
