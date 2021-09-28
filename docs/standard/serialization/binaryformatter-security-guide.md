---
title: "BinaryFormatter security guide"
description: This article describes the security risks inherent in the BinaryFormatter type and recommendations for different serializers to use.
ms.date: "07/11/2020"
ms.author: levib
author: GrabYourPitchforks
---
# BinaryFormatter security guide

This article applies to the following .NET implementations:

* .NET Framework all versions
* .NET Core 2.1 - 3.1
* .NET 5.0 and later

## Background

> [!WARNING]
> The <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> type is dangerous and is ***not*** recommended for data processing. Applications should stop using `BinaryFormatter` as soon as possible, even if they believe the data they're processing to be trustworthy. `BinaryFormatter` is insecure and can't be made secure.

This article also applies to the following types:

* <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter>
* <xref:System.Runtime.Serialization.NetDataContractSerializer>
* <xref:System.Web.UI.LosFormatter>
* <xref:System.Web.UI.ObjectStateFormatter>

Deserialization vulnerabilities are a threat category where request payloads are processed insecurely. An attacker who successfully leverages these vulnerabilities against an app can cause denial of service (DoS), information disclosure, or remote code execution inside the target app. This risk category consistently makes the [OWASP Top 10](https://owasp.org/www-project-top-ten/). Targets include apps written in [a variety of languages](https://owasp.org/www-community/vulnerabilities/Deserialization_of_untrusted_data), including C/C++, Java, and C#.

In .NET, the biggest risk target is apps that use the <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> type to deserialize data. `BinaryFormatter` is widely used throughout the .NET ecosystem because of its power and its ease of use. However, this same power gives attackers the ability to influence control flow within the target app. Successful attacks can result in the attacker being able to run code within the context of the target process.

As a simpler analogy, assume that calling `BinaryFormatter.Deserialize` over a payload is the equivalent of interpreting that payload as a standalone executable and launching it.

## BinaryFormatter security vulnerabilities

> [!WARNING]
> The `BinaryFormatter.Deserialize` method is __never__ safe when used with untrusted input. We strongly recommend that consumers instead consider using one of the alternatives outlined later in this article.

`BinaryFormatter` was implemented before deserialization vulnerabilities were a well-understood threat category. As a result, the code does not follow modern best practices. The `Deserialize` method can be used as a vector for attackers to perform DoS attacks against consuming apps. These attacks might render the app unresponsive or result in unexpected process termination. This category of attack cannot be mitigated with a `SerializationBinder` or any other `BinaryFormatter` configuration switch. .NET considers this behavior to be ***by design*** and won't issue a code update to modify the behavior.

`BinaryFormatter.Deserialize` may be vulnerable to other attack categories, such as information disclosure or remote code execution. Utilizing features such as a custom <xref:System.Runtime.Serialization.SerializationBinder> may be insufficient to properly mitigate these risks. The possibility exists that a novel vulnerability will be discovered for which .NET cannot practically publish a security update. Consumers should assess their individual scenarios and consider their potential exposure to these risks.

We recommend that `BinaryFormatter` consumers perform individual risk assessments on their apps. It is the consumer's sole responsibility to determine whether to utilize `BinaryFormatter`. Consumers should risk assess the security, technical, reputation, legal, and regulatory requirements of using `BinaryFormatter`.

## Preferred alternatives

.NET offers several in-box serializers that can handle untrusted data safely:

* <xref:System.Xml.Serialization.XmlSerializer> and <xref:System.Runtime.Serialization.DataContractSerializer> to serialize object graphs into and from XML. Do not confuse `DataContractSerializer` with  <xref:System.Runtime.Serialization.NetDataContractSerializer>.
* <xref:System.IO.BinaryReader> and <xref:System.IO.BinaryWriter> for XML and JSON.
* The <xref:System.Text.Json> APIs to serialize object graphs into JSON.

## Dangerous alternatives

Avoid the following serializers:

* <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter>
* <xref:System.Web.UI.LosFormatter>
* <xref:System.Runtime.Serialization.NetDataContractSerializer>
* <xref:System.Web.UI.ObjectStateFormatter>

The preceding serializers all perform unrestricted polymorphic deserialization and are dangerous, just like `BinaryFormatter`.

## The risks of assuming data to be trustworthy

Frequently, an app developer might believe that they are processing only trusted input. The safe input case is true in some rare circumstances. But it's much more common that a payload crosses a trust boundary without the developer realizing it.

__Consider an on-prem server__ where employees use a desktop client from their workstations to interact with the service. This scenario might be seen naïvely as a "safe" setup where utilizing `BinaryFormatter` is acceptable. However, this scenario presents a vector for malware that gains access to a single employee's machine to be able to spread throughout the enterprise. That malware can leverage the enterprise's use of `BinaryFormatter` to move laterally from the employee's workstation to the backend server. It can then exfiltrate the company's sensitive data. Such data could include trade secrets or customer data.

__Consider also an app that uses `BinaryFormatter` to persist save state.__ This might at first seem to be a safe scenario, as reading and writing data on your own hard drive represents a minor threat. However, sharing documents across email or the internet is common, and most end users wouldn't perceive opening these downloaded files as risky behavior.

This scenario can be leveraged to nefarious effect. If the app is a game, users who share save files unknowingly place themselves at risk. The developers themselves can also be targeted. The attacker might email the developers' tech support, attaching a malicious data file and asking the support staff to open it. This kind of attack could give the attacker a foothold in the enterprise.

Another scenario is where the data file is stored in cloud storage and automatically synced between the user's machines. An attacker who is able to gain access to the cloud storage account can poison the data file. This data file will be automatically synced to the user's machines. The next time the user opens the data file, the attacker's payload runs. Thus the attacker can leverage a cloud storage account compromise to gain full code execution permissions.

__Consider an app that moves from a desktop-install model to a cloud-first model.__ This scenario includes apps that move from a desktop app or rich client model into a web-based model. Any threat models drawn for the desktop app aren't necessarily applicable to the cloud-based service. The threat model for the desktop app might dismiss a given threat as "not interesting for the client to attack itself." But that same threat might become interesting when it considers a remote user (the client) attacking the cloud service itself.

> [!NOTE]
> In general terms, the intent of serialization is to transmit an object into or out of an app. A threat modeling exercise almost always marks this kind of data transfer as crossing a trust boundary.

## Further resources

* [YSoSerial.Net](https://github.com/pwntester/ysoserial.net) for research into how adversaries attack apps that utilize `BinaryFormatter`.
* General background on deserialization vulnerabilities:
  * [OWASP Top 10 - A8:2017-Insecure Deserialization](https://owasp.org/www-project-top-ten/OWASP_Top_Ten_2017/Top_10-2017_A8-Insecure_Deserialization)
  * [CWE-502: Deserialization of Untrusted Data](https://cwe.mitre.org/data/definitions/502.html)
