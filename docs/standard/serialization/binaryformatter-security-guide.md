---
title: "BinaryFormatter security guide"
description: This article describes the security risks inherent in the BinaryFormatter type and recommendations for different serializers to use.
ms.date: "07/11/2020"
helpviewer_keywords: 
ms.assetid: 00000000-0000-0000-0000-000000000000
author: "GrabYourPitchforks"
---
# BinaryFormatter security guide

This document applies to the following framework versions:

* .NET Framework (all versions)
* .NET Core 2.1 - 3.1
* .NET 5.0+

## Background

> __Summary__: The `BinaryFormatter` type is dangerous and is not recommended for data processing. Applications should stop using it at their earliest opportunity, even if they believe the data they're processing to be trustworthy.

> This document also applies to the `SoapFormatter`, `NetDataContractSerializer`, `LosFormatter`, and `ObjectStateFormatter` types.

Deserialization vulnerabilities are a threat category where request payloads are processed insecurely. An attacker who successfully leverages this against an application can cause denial of service, information disclosure, or even remote code execution inside the target application. This risk category consistently makes the [OWASP Top 10](https://owasp.org/www-project-top-ten/). Targets include applications written in [a variety of languages](https://owasp.org/www-community/vulnerabilities/Deserialization_of_untrusted_data), including C/C++, Java, and C#.

In .NET, the biggest risk target is applications which use `BinaryFormatter` to deserialize data. `BinaryFormatter` is widely used throughout the .NET ecosystem because of its power and its ease of use. However, this same power gives attackers the ability to influence control flow within the target application. This commonly results in the adversary being able to run code within the context of the target process.

As a simpler analogy, assume that calling `BinaryFormatter.Deserialize` over a payload is the equivalent of interpreting that payload as a standalone executable and launching it.

## BinaryFormatter security guarantees

> The `BinaryFormatter.Deserialize` method is __never__ safe when used with untrusted input. We strongly recommend that consumers instead consider using one of the alternatives outlined later in this document.

The implementation of `BinaryFormatter` was originally created before serialization vulnerabilities were a well-understood threat category. As a result, the code does not follow modern best practices. The `Deserialize` method can be used as a vector for attackers to perform DoS attacks against consuming applications. These attacks might render the application unresponsive or could even result in unexpected process termination. This category of attack cannot be mitigated with a `SerializationBinder` or any other `BinaryFormatter` configuration switch. .NET considers this behavior _by design_ and will not issue a code update to modify the behavior.

`BinaryFormatter.Deserialize` may be vulnerable to other attack categories, such as information disclosure or remote code execution. Utilizing features such as a custom [serialization binder](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.serializationbinder) may be insufficient to properly mitigate these risks. The possibility exists that a novel vulnerability will be discovered for which .NET cannot practically publish a security update. Consumers should assess their individual scenarios and consider their potential exposure to these risks.

We recommend that `BinaryFormatter` consumers perform individual risk assessments on their applications. It is the consumer's sole responsibility to determine for itself whether to utilize this API. Consumers should assess any security, technical, reputational, and legal risks (including regulatory requirements) that may accompany using `BinaryFormatter` within their applications.

## Preferred alternatives

.NET offers several in-box serializers which can handle untrusted data safely.

The in-box types [`XmlSerializer`](https://docs.microsoft.com/en-us/dotnet/api/system.xml.serialization.xmlserializer) and [`DataContractSerializer`](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.datacontractserializer) (not to be confused with `NetDataContractSerializer`) can be used to serialize object graphs into and from XML safely.

The [_System.Text.Json_](https://docs.microsoft.com/en-us/dotnet/api/system.text.json) APIs can be used to serialize object graphs into JSON safely.

### Dangerous alternatives

Avoid the in-box serializers `SoapFormatter`, `LosFormatter`, `NetDataContractSerializer`, and `ObjectStateFormatter`. These serializers all perform unrestricted polymorphic deserialization and are dangerous, just like `BinaryFormatter`.

## The risks of assuming data to be trustworthy

Frequently, an app developer might believe that they are processing only trusted input. This is certainly the case in some rare circumstances. It's much more common that a payload crosses a trust boundary without the developer realizing it.

__Consider an on-prem server__ where employees use a desktop client from their workstations to interact with the service. This might be seen naïvely as a "safe" setup where utilizing `BinaryFormatter` is acceptable. However, this now presents a vector for malware which gains access to a single employee's machine to be able to spread throughout the enterprise. That malware can leverage the enterprise's use of `BinaryFormatter` to move laterally from the employee's workstation to the backend server. It can then exfiltrate the company's sensitive data. This may include trade secrets or customer data.

__Consider also an application which uses `BinaryFormatter` to persist save state.__ One might at first believe this to be inconsequential, as reading and writing data on your own hard drive represents a minor threat. In truth, however, sharing documents across email or the internet is common, and most end users wouldn't perceive opening these downloaded files as a risky behavior.

This can be leveraged to nefarious effect. If the application is a game, users who share save files unknowingly place themselves at risk. The developers themselves can also be targeted. The attacker might email the developers' tech support, attaching a malicious data file and asking the support staff to open it. This gives the attacker a foothold in the enterprise.

Of further interest is the scenario where the data file is stored in cloud storage and automatically synced between the user's machines. An attacker who is able to gain access to the cloud storage account can poison the data file. This data file will be automatically synced to the user's machines. The next time the user opens the data file, the attacker's payload runs. Thus the attacker can leverage a cloud storage account compromise to gain full code execution permissions.

__Finally, consider an aplication which moves from a desktop-install model to a cloud-first model.__ This would include applications that move from a box product / rich client model into a web-based model. Any threat models drawn for the desktop app aren't necessarily applicable to the cloud-based service. While the model for the desktop app might dismiss a given threat as "it's not interesting for the client to attack itself," that same threat might suddenly become interesting when it considers a remote user (the client) attacking the cloud service itself.

> In general terms, the intent of serialization is to transmit an object into or out of an application. A threat modeling exercise will almost always mark this kind of data transfer as crossing a trust boundary.

## Further resources

https://github.com/pwntester/ysoserial.net for research into how adversaries attack applications which utilize `BinaryFormatter`.

https://www.microsoft.com/en-us/securityengineering/sdl/threatmodeling for information on threat modeling applications and services.

https://owasp.org/www-project-top-ten/OWASP_Top_Ten_2017/Top_10-2017_A8-Insecure_Deserialization and https://cwe.mitre.org/data/definitions/502.html for general background on deserialization vulnerabilities.
