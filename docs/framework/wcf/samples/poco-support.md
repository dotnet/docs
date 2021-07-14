---
description: "Learn more about: POCO Support"
title: "POCO Support"
ms.date: "03/30/2017"
ms.assetid: 3846ca73-2819-4ca2-8367-dc739dde5a5b
---
# POCO Support

The [POCO sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates the serialization support for unmarked types; that is, types to which serialization attributes have not been applied, sometimes referred to as Plain Old CLR Object (POCO) types. The <xref:System.Runtime.Serialization.DataContractSerializer> infers a data contract for all public unmarked types that have a parameterless constructor. Data contracts allow you to pass structured data to and from services. For more information about unmarked types, see [Serializable Types](../feature-details/serializable-types.md).

This sample is based on the [Getting Started](getting-started-sample.md), but uses complex numbers instead of primitive numeric types. It is also similar to the [Basic Data Contract](basic-data-contract.md) sample, except that the <xref:System.Runtime.Serialization.DataContractAttribute> and <xref:System.Runtime.Serialization.DataMemberAttribute> attributes are not used.

The service is hosted by Internet Information Services (IIS) and the client is a console application (.exe).

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

The `ComplexNumber` class is used in the `ServiceContract`. The `ComplexNumber` type does not have the <xref:System.Runtime.Serialization.DataContractAttribute> and <xref:System.Runtime.Serialization.DataMemberAttribute> attributes, as shown in the following sample code. By default, all public properties and fields are serialized.

```csharp
public class ComplexNumber
{
    public double Real;
    public double Imaginary;
    public ComplexNumber()
    {
        Real = double.MinValue;
        Imaginary = double.MinValue;
    }
    public ComplexNumber(double real, double imaginary)
    {
        this.Real = real;
        this.Imaginary = imaginary;
    }
}
```

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).

## See also

- <xref:System.Runtime.Serialization.IgnoreDataMemberAttribute>
- [Serializable Types](../feature-details/serializable-types.md)
