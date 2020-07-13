---
title: "BinaryFormatter security guide"
description: This article describes the security risks inherent in the BinaryFormatter type and recommendations for different serializers to use.
ms.date: "07/11/2020"
helpviewer_keywords: 
ms.assetid: c828a558-094b-441e-eeee-790b87315faa
author: "GrabYourPitchforks"
---
# BinaryFormatter security guide

This document applies to the following framework versions:

* .NET Framework all versions
* .NET Core 2.1 - 3.1
* .NET 5.0 and later

<!-- TODO Add:
 `BinaryReader` and `BinaryWriter` should be considered as an alternatives next to XML & JSON for those that require binary data.
-->
## Background

> [!WARNING]
> The <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> type is dangerous and is not recommended for data processing. Applications should stop using `BinaryFormatter` as soon as possible, even if they believe the data they're processing to be trustworthy.

This document also applies to the following types:

* <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter>
* <xref:System.Runtime.Serialization.NetDataContractSerializer>
* <xref:System.Web.UI.LosFormatter>
* <xref:System.Web.UI.ObjectStateFormatter>

Deserialization vulnerabilities are a threat category where request payloads are processed insecurely. An attacker who successfully leverages this against an app can cause denial of service (Dos), information disclosure, or remote code execution inside the target app. This risk category consistently makes the [OWASP Top 10](https://owasp.org/www-project-top-ten/). Targets include apps written in [a variety of languages](https://owasp.org/www-community/vulnerabilities/Deserialization_of_untrusted_data), including C/C++, Java, and C#.

In .NET, the biggest risk target is apps which use `BinaryFormatter` to deserialize data. `BinaryFormatter` is widely used throughout the .NET ecosystem because of its power and its ease of use. However, this same power gives attackers the ability to influence control flow within the target app. This commonly results in the adversary being able to run code within the context of the target process.

As a simpler analogy, assume that calling `BinaryFormatter.Deserialize` over a payload is the equivalent of interpreting that payload as a standalone executable and launching it.

## BinaryFormatter security guarantees

> [!WARNING]
> The `BinaryFormatter.Deserialize` method is __never__ safe when used with untrusted input. We strongly recommend that consumers instead consider using one of the alternatives outlined later in this document.

The implementation of `BinaryFormatter` was originally created before serialization vulnerabilities were a well-understood threat category. As a result, the code does not follow modern best practices. The `Deserialize` method can be used as a vector for attackers to perform DoS attacks against consuming apps. These attacks might render the app unresponsive or result in unexpected process termination. This category of attack cannot be mitigated with a `SerializationBinder` or any other `BinaryFormatter` configuration switch. .NET considers this behavior ***by design*** and won't issue a code update to modify the behavior.

`BinaryFormatter.Deserialize` may be vulnerable to other attack categories, such as information disclosure or remote code execution. Utilizing features such as a custom <xref:System.Runtime.Serialization.SerializationBinder> may be insufficient to properly mitigate these risks. The possibility exists that a novel vulnerability will be discovered for which .NET cannot practically publish a security update. Consumers should assess their individual scenarios and consider their potential exposure to these risks.

We recommend that `BinaryFormatter` consumers perform individual risk assessments on their apps. It is the consumer's sole responsibility to determine whether to utilize `BinaryFormatter`. Consumers should risk assess security, technical, reputation, legal, and regulatory requirements of using `BinaryFormatter`.

## Preferred alternatives

.NET offers several in-box serializers which can handle untrusted data safely:

* <xref:System.Xml.Serialization.XmlSerializer) and <xref:System.Runtime.Serialization.DataContractSerializer> to serialize object graphs into and from XML. Do not confuse `DataContractSerializer` with  <xref:System.Runtime.Serialization.NetDataContractSerializer>.
<!-- Levi review pre review comment-->
* <xref:System.IO.BinaryReader> and <xref:System.IO.BinaryWriter> for XML and JSON.
* The <xref:System.Text.Json> APIs to serialize object graphs into JSON.

### Dangerous alternatives

Avoid the following serializers:

* <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter>
* <xref:System.Web.UI.LosFormatter>
* <xref:System.Runtime.Serialization.NetDataContractSerializer>
* <xref:System.Web.UI.ObjectStateFormatter>

The preceding serializers all perform unrestricted polymorphic deserialization and are dangerous, just like `BinaryFormatter`.

## The risks of assuming data to be trustworthy

Frequently, an app developer might believe that they are processing only trusted input. The safe input case is true in some rare circumstances. It's much more common that a payload crosses a trust boundary without the developer realizing it.

__Consider an on-prem server__ where employees use a desktop client from their workstations to interact with the service. This might be seen naïvely as a "safe" setup where utilizing `BinaryFormatter` is acceptable. However, this now presents a vector for malware which gains access to a single employee's machine to be able to spread throughout the enterprise. That malware can leverage the enterprise's use of `BinaryFormatter` to move laterally from the employee's workstation to the backend server. It can then exfiltrate the company's sensitive data. This may include trade secrets or customer data.

__Consider also an app which uses `BinaryFormatter` to persist save state.__ One might at first believe this to be inconsequential, as reading and writing data on your own hard drive represents a minor threat. In truth, however, sharing documents across email or the internet is common, and most end users wouldn't perceive opening these downloaded files as a risky behavior.

This can be leveraged to nefarious effect. If the app is a game, users who share save files unknowingly place themselves at risk. The developers themselves can also be targeted. The attacker might email the developers' tech support, attaching a malicious data file and asking the support staff to open it. This gives the attacker a foothold in the enterprise.

Of further interest is the scenario where the data file is stored in cloud storage and automatically synced between the user's machines. An attacker who is able to gain access to the cloud storage account can poison the data file. This data file will be automatically synced to the user's machines. The next time the user opens the data file, the attacker's payload runs. Thus the attacker can leverage a cloud storage account compromise to gain full code execution permissions.

<!-- Levi review: What's a box product? That's won't translate 
We like sentences to be generally between 15-20 words. Can you help me split up the following 42 word sentence? I'm not sure how an embedded sentence translates. I'm made an attempt to shorten it and make it easier to read in all languages.

While the model for the desktop app might dismiss a given threat as "it's not interesting for the client to attack itself," that same threat might suddenly become interesting when it considers a remote user (the client) attacking the cloud service itself.

The model for the desktop app: 

* Might appear to not be risky, because the client will not attack itself.
* Is at risk when moved to the cloud. A remote user, the client, attacking the cloud service itself.
-->
__Consider an app which moves from a desktop-install model to a cloud-first model.__ This includes apps that move from a box product or rich client model into a web-based model. Any threat models drawn for the desktop app aren't necessarily applicable to the cloud-based service. While the model for the desktop app might dismiss a given threat as "it's not interesting for the client to attack itself," that same threat might suddenly become interesting when it considers a remote user (the client) attacking the cloud service itself.

> [!NOTE]
> In general terms, the intent of serialization is to transmit an object into or out of an app. A threat modeling exercise almost always marks this kind of data transfer as crossing a trust boundary.

## Further resources

* [github.com/pwntester/ysoserial.net](https://github.com/pwntester/ysoserial.net) for research into how adversaries attack apps which utilize `BinaryFormatter`.
* [Threat Modeling](/securityengineering/sdl/threatmodeling) for information on threat modeling apps and services.
* General background on deserialization vulnerabilities:
  * [OWASP Top Ten](https://owasp.org/www-project-top-ten/OWASP_Top_Ten_2017/Top_10-2017_A8-Insecure_Deserialization)
  * [CWE-502: Deserialization of Untrusted Data](https://cwe.mitre.org/data/definitions/502.html)
