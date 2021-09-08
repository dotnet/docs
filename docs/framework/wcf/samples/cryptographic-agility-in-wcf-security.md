---
description: "Learn more about: Cryptographic agility in WCF security"
title: "Cryptographic agility in WCF security"
ms.date: "03/30/2017"
ms.assetid: c2c549e5-ac19-40c5-b686-8f67f52b6dbf
---
# Cryptographic agility in WCF security

The [CryptoAgility sample](https://github.com/dotnet/samples/tree/main/framework/wcf) shows how to specify in a standard/custom algorithm to provide a cryptographic agile implementation in a Windows Communication Foundation (WCF) client and service. The sample is composed of the following projects:

**Service**

This is a self-hosted WCF service that implements the `ICalculator` interface and secures the endpoint using the <xref:System.ServiceModel.WSHttpBinding> with secure session and reliable session disabled. The service defines a custom `SecurityAlgorithmSuite` class to specify the cryptographic algorithms to be used for message security.

**Client**

This is a WCF client that accesses the service after successful authentication. It invokes the operations exposed by the `ICalculator` interface and implemented by the service. The client also defines the same custom `SecurityAlgorithmSuite` class to specify the cryptographic algorithms to be used for message security.

## To use this sample

1. Open the CryptoAgility.sln solution in Visual Studio 2012.

2. Press **Ctrl**+**Shift**+**B** to build the solution.

3. Open File Explorer and navigate to the \WCF\Basic\Security\CryptoAgility\Service\bin directory and run the service.exe file with administrator privileges by right-clicking service.exe and selecting **Run as administrator**.

4. Navigate to \WCF\Basic\Security\CryptoAgility\Client\bin directory and run the client.exe file normally.

## See also

- [Windows Communication Foundation Security](../feature-details/security.md)
