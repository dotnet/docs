---
description: "Learn more about: MTOM Encoding"
title: "MTOM Encoding"
ms.date: "03/30/2017"
ms.assetid: 820e316f-4ee1-4eb5-ae38-b6a536e8a14f
---
# MTOM Encoding

The [MTOM sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates the use of the Message Transmission Optimization Mechanism (MTOM) message encoding with a WSHttpBinding. MTOM is a mechanism for transmitting large binary attachments with SOAP messages as raw bytes, allowing for smaller messages.

By default, the WSHttpBinding sends and received messages as normal text XML. To enable sending and receiving MTOM messages, set the `messageEncoding` attribute on the binding's configuration (as in the following example code), or directly on the binding using the `MessageEncoding` property. The service or client can now send and receive MTOM messages.

```xml
<wsHttpBinding>
  <binding name="WSHttpBinding_IUpload" messageEncoding="Mtom" />
</wsHttpBinding>
```

The MTOM encoder can optimize arrays of bytes and streams. In this sample, the operation uses a `Stream` parameter and can therefore be optimized.

```csharp
[ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
  public interface IUpload
  {
      [OperationContract]
      int Upload(Stream data);
  }
```

The contract chosen for this sample transmits binary data to the service and receives the number of bytes uploaded as the return value. When the service is installed and the client is run, it prints out the number 1000, which indicates that all 1000 bytes were received. The remainder of the output lists optimized and non-optimized message sizes for various payloads.

```console
Output:
1000

Text encoding with a 100 byte payload: 433
MTOM encoding with a 100 byte payload: 912

Text encoding with a 1000 byte payload: 1633
MTOM encoding with a 1000 byte payload: 2080

Text encoding with a 10000 byte payload: 13633
MTOM encoding with a 10000 byte payload: 11080

Text encoding with a 100000 byte payload: 133633
MTOM encoding with a 100000 byte payload: 101080

Text encoding with a 1000000 byte payload: 1333633
MTOM encoding with a 1000000 byte payload: 1001080

Press <ENTER> to terminate client.
```

The purpose for using MTOM is to optimize the transmission of large binary payloads. Sending a SOAP message using MTOM has a noticeable overhead for small binary payloads, but becomes a great savings when they grow over a few thousand bytes. The reason for this is that normal text XML encodes binary data using Base64, which requires four characters for every three bytes, and increases the size of the data by one third. MTOM is able to transmit binary data as raw bytes, saving the encoding/decoding time and resulting is smaller messages. The threshold of a few thousand bytes is small when compared to today's business documents and digital photographs.

### To set up, build, and run the sample

1. Install ASP.NET 4.0 using the following command.

    ```console
    %windir%\Microsoft.NET\Framework\v4.0.XXXXX\aspnet_regiis.exe /i /enable
    ```

2. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

3. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

4. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).
