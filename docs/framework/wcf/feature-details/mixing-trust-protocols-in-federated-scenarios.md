---
description: "Learn more about: Mixing Trust Protocols in Federated Scenarios"
title: "Mixing Trust Protocols in Federated Scenarios"
ms.date: "03/30/2017"
ms.assetid: d7b5fee9-2246-4b09-b8d7-9e63cb817279
---
# Mixing Trust Protocols in Federated Scenarios

There may be scenarios in which federated clients communicate with a service and a Security Token Service (STS) that do not have the same trust version. The service WSDL can contain a `RequestSecurityTokenTemplate` assertion with WS-Trust elements that are of different versions than the STS. In such cases, a Windows Communication Foundation (WCF) client converts the WS-Trust elements received from the `RequestSecurityTokenTemplate` to match the STS trust version. WCF handles mismatched trust versions only for standard bindings. All standard algorithm parameters that are recognized by WCF are part of the standard binding. This topic describes the WCF behavior with various trust settings between the service and the STS.  
  
## RP Feb 2005 and STS Feb 2005  

 The WSDL for Relying Party (RP) contains the following elements within the `RequestSecurityTokenTemplate` section:  
  
- `CanonicalizationAlgorithm`  
  
- `EncryptionAlgorithm`  
  
- `EncryptWith`  
  
- `SignWith`  
  
- `KeySize`  
  
- `KeyType`  
  
 The client configuration file contains a list of parameters.  
  
 WCF cannot differentiate between the client and service parameters; it adds all the parameters and sends them in the `RequestSecurityTokenTemplate` (RST).  
  
## RP Trust 1.3 and STS Trust 1.3  

 The WSDL for RP contains the following elements within the `RequestSecurityTokenTemplate` section:  
  
- `CanonicalizationAlgorithm`  
  
- `EncryptionAlgorithm`  
  
- `EncryptWith`  
  
- `SignWith`  
  
- `KeySize`  
  
- `KeyType`  
  
- `KeyWrapAlgorithm`  
  
 The client configuration file contains a `secondaryParameters` element that wraps the parameters specified by the RP.  
  
 WCF removes the `EncryptionAlgorithm`, `CanonicalizationAlgorithm` and `KeyWrapAlgorithm` elements from the top-level element under the RST if these are present inside the `SecondaryParameters` element. WCF appends the `SecondaryParameters` element to the outgoing RST unmodified.  
  
## RP Trust Feb 2005 and STS Trust 1.3  

 The WSDL for RP contains the following elements in the `RequestSecurityTokenTemplate` section:  
  
- `CanonicalizationAlgorithm`  
  
- `EncryptionAlgorithm`  
  
- `EncryptWith`  
  
- `SignWith`  
  
- `KeySize`  
  
- `KeyType`  
  
 The client configuration file contains a list of parameters.  
  
 From the client configuration file, WCF cannot differentiate between the service and client parameters. Therefore WCF converts all the parameters to a Trust version 1.3 namespace.  
  
 WCF handles the `KeyType`, `KeySize`, and `TokenType` elements as follows:  
  
- Download the WSDL, create the binding, and assign `KeyType`, `KeySize`, and `TokenType` from the RP parameters. The client configuration file is then generated.  
  
- The client can now change any parameter in the configuration file.  
  
- During runtime, WCF copies all parameters specified into the `AdditionalTokenParameters` section of the client configuration file except `KeyType`, `KeySize` and `TokenType`, because these parameters are accounted for during the configuration file generation.  
  
## RP Trust 1.3 and STS Trust Feb 2005  

 The WSDL for RP contains the following elements in the `RequestSecurityTokenTemplate` section:  
  
- `CanonicalizationAlgorithm`  
  
- `EncryptionAlgorithm`  
  
- `EncryptWith`  
  
- `SignWith`  
  
- `KeySize`  
  
- `KeyType`  
  
- `KeyWrapAlgorithm`  
  
 The client configuration file contains a `secondaryParamters` element that wraps the parameters specified by the RP.  
  
 WCF copies all the parameters specified within the `SecondaryParameters` section to the top-level RST element, but does not convert them to the 2005 WS-Trust namespace.
