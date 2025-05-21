---
title: Transport Layer Security (TLS) best practices with .NET Framework
titleSuffix: ""
description: Describes best practices using Transport Layer Security (TLS) with .NET Framework
ms.date: 03/18/2024
helpviewer_keywords:
  - "sending data, Internet security"
  - "protocols, Internet security"
  - "Network security"
  - "network resources, Internet security"
  - "receiving data, Internet security"
  - "authentication [.NET Framework], Internet security"
  - "Internet, security"
  - "security [.NET Framework], Internet"
  - "permissions [.NET Framework], Internet"
ms.topic: best-practice
---
# Transport Layer Security (TLS) best practices with .NET Framework

> [!NOTE]
> This page contains .NET Framework TLS information. If you're looking for .NET TLS information, see: [TLS/SSL Best Practices](../../core/extensions/sslstream-best-practices.md)

.NET Framework supports the use of the Transport Layer Security (TLS) protocol to secure network communications.

## What is Transport Layer Security (TLS)?

> [!WARNING]
> TLS 1.0 and 1.1 has been deprecated by [RFC8996](https://datatracker.ietf.org/doc/rfc8996/). This document covers TLS 1.2 and TLS 1.3 only.

The Transport Layer Security (TLS) protocol is an industry latest version of the standard designed to help protect the privacy of information communicated over the Internet. [TLS 1.3](https://tools.ietf.org/html/rfc8446) is a standard that provides security improvements over previous versions. This article presents recommendations to secure .NET Framework applications that use the TLS protocol.

## Who can benefit from this document?

- Directly using the <xref:System.Net> APIs (for example, <xref:System.Net.Http.HttpClient?displayProperty=nameWithType> and <xref:System.Net.Security.SslStream?displayProperty=nameWithType>).
- Directly using WCF clients and services using the <xref:System.ServiceModel?displayProperty=nameWithType> namespace.

## TLS support in .NET Framework

Since the .NET Framework is dependent on `Schannel` on Windows, which versions can be negotiated and which version will be used depends on the operating system.

Here is an updated example table showing the highest supported TLS version for different combinations of operating system versions and .NET Framework target versions:

| .NET Framework Target Version | Windows 10 | Windows 11 |
|-------------------------------|------------|------------|
| 3.5                           | TLS 1.2    | TLS 1.2    |
| 4.6.2                         | TLS 1.2    | **TLS 1.3**|
| 4.7                           | TLS 1.2    | **TLS 1.3**|
| 4.7.1                         | TLS 1.2    | **TLS 1.3**|
| 4.7.2                         | TLS 1.2    | **TLS 1.3**|
| 4.8                           | TLS 1.2    | **TLS 1.3**|
| 4.8.1                         | TLS 1.2    | **TLS 1.3**|

For more information see [TLS protocol version support in Schannel](/windows/win32/secauthn/protocols-in-tls-ssl--schannel-ssp-#tls-protocol-version-support).

## Recommendations

- For TLS 1.3, target .NET Framework 4.8 or later. Check [Audit your code](#audit-your-code-and-make-code-changes) section how to verify your `target framework`.
- Do not specify the TLS version explicitly, i.e. don't use the method overloads of `SslStream` that take an explicit `SslProtocols` parameter.
  - That way your code will let the OS decide on the TLS version.
  - If you must set <xref:System.Net.ServicePointManager.SecurityProtocol?displayProperty=nameWithType>, then set it to <xref:System.Net.SecurityProtocolType.SystemDefault?displayProperty=nameWithType>. That will also use OS default.
  - If you must use the method overloads of `SslStream` that take an explicit `SslProtocols` parameter, then pass `SslProtocols.SystemDefault` as argument. That will also use OS default.
- Perform a thorough code audit to verify you're not specifying a TLS or SSL version explicitly.

> [!WARNING]
> Do not use `SslProtocols.Default`, because it sets TLS version to SSL3 and TLS 1.0 which are obsoleted.

When your app lets the OS choose the TLS version:

- It automatically takes advantage of new TLS protocols added in the future.
- The OS blocks protocols that are discovered not to be secure (e.g. SSL3 and TLS 1.0).

This article explains how to enable the strongest security available for the version of .NET Framework that your app targets and runs on. When an app explicitly sets a security protocol and version, it opts out of any other alternative, and opts out of .NET Framework and OS default behavior. If you want your app to be able to negotiate a TLS 1.3 connection, explicitly setting to a lower TLS version prevents a TLS 1.3 connection.

If you can't avoid specifying a protocol version explicitly, we strongly recommend that you specify TLS 1.2 or TLS 1.3 (which is `currently considered secure`). For guidance on identifying and removing TLS 1.0 dependencies, download the [Solving the TLS 1.0 Problem](https://www.microsoft.com/download/details.aspx?id=55266) white paper.

WCF supports TLS 1.2 as the default in .NET Framework 4.7. Starting with .NET Framework 4.7.1, WCF defaults to the operating system configured version. If an application is explicitly configured with `SslProtocols.None`, WCF uses the operating system default setting when using the NetTcp transport.

You can ask questions about this document in the GitHub issue [Transport Layer Security (TLS) best practices with the .NET Framework](https://github.com/dotnet/docs/issues/4675).

## Audit your code and make code changes

For ASP.NET applications, inspect the `<system.web><httpRuntime targetFramework>` element of _web.config_ to verify you're using the targeting intended version of the .NET Framework.

For Windows Forms and other applications, see [How to: Target a Version of the .NET Framework](/visualstudio/ide/visual-studio-multi-targeting-overview).

Use the following sections to verify you're not using a specific TLS or SSL version.

## If you must explicitly set a Security Protocol

If you must explicitly set a security protocol instead of letting .NET or the OS pick the security protocol, pick these protocols:

- For .NET Framework 3.5: TLS 1.2
- For .NET Framework 4.6.2 or later: TLS 1.3

If you can't find specified protocols in enum, you can add those as an extension file. See below:

`SslProtocolExtensions.cs`

```c#
namespace System.Security.Authentication
{
    public static class SslProtocolsExtensions
    {
        // For .NET Framework 3.5
        public const SslProtocols Tls12 = (SslProtocols)3072;
        // For .NET Framework 4.6.2 and later
        public const SslProtocols Tls13 = (SslProtocols)12288;
    }
}
```

`SecurityProtocolExtensions.cs`

```c#
using System.Security.Authentication;

namespace System.Net
{
    public static class SecurityProtocolTypeExtensions
    {
        // For .NET Framework 3.5
        public const SecurityProtocolType Tls12 = (SecurityProtocolType)SslProtocolsExtensions.Tls12;
        // For .NET Framework 4.6.2 and later
        public const SecurityProtocolType Tls13 = (SecurityProtocolType)SslProtocolsExtensions.Tls13;
    }
}
```

For more information, see [Support for TLS System Default Versions included in .NET Framework 3.5 on Windows 8.1 and Windows Server 2012 R2](https://support.microsoft.com/help/3154520/support-for-tls-system-default-versions-included-in-the--net-framework).

## For System.Net APIs (HttpClient, SslStream)

### If your app targets .NET Framework 4.7 or later versions

The following sections show how to configure your application to use `currently considered secure versions` of TLS. (TLS 1.2, TLS 1.3)

#### For HttpClient and HttpWebRequest

<xref:System.Net.ServicePointManager>, using .NET Framework 4.7 and later versions, will use the default security protocol configured in the OS. To get the default OS choice, if possible, don't set a value for the <xref:System.Net.ServicePointManager.SecurityProtocol?displayProperty=nameWithType> property, which defaults to <xref:System.Net.SecurityProtocolType.SystemDefault?displayProperty=nameWithType>.

Because the <xref:System.Net.SecurityProtocolType.SystemDefault?displayProperty=nameWithType> setting causes the <xref:System.Net.ServicePointManager> to use the default security protocol configured by the operating system, your application may run differently based on the OS it's run on. For example, Windows 10 uses TLS 1.2 while Windows 11 uses TLS 1.3.

#### For SslStream

<xref:System.Net.Security.SslStream>, using .NET Framework 4.7 and later versions, defaults to the OS choosing the best security protocol and version. To get the default OS best choice, if possible, don't use the method overloads of <xref:System.Net.Security.SslStream> that take an explicit <xref:System.Security.Authentication.SslProtocols> parameter. Otherwise, pass <xref:System.Security.Authentication.SslProtocols.None?displayProperty=nameWithType>. We recommend that you don't use <xref:System.Security.Authentication.SslProtocols.Default>; setting `SslProtocols.Default` forces the use of SSL 3.0 /TLS 1.0 and prevents TLS 1.2.

Don't set a value for the <xref:System.Net.ServicePointManager.SecurityProtocol> property (for HTTP networking).

Don't use the method overloads of <xref:System.Net.Security.SslStream> that take an explicit <xref:System.Security.Authentication.SslProtocols> parameter (for TCP sockets networking). When you retarget your app to .NET Framework 4.7 or later versions, you'll be following the best practices recommendation.

<a name="wcf-tcp-cert"></a>

## For WCF Applications

### If your app targets .NET Framework 4.7 or later versions

The following sections show how to configure your application to use `currently considered secure versions` of TLS. (TLS 1.2, TLS 1.3)

#### Using TCP transport using transport security with certificate credentials

WCF uses the same networking stack as the rest of .NET Framework.

If you're targeting 4.7.1, WCF is configured to allow the OS to choose the best security protocol by default unless explicitly configured:

- In your application configuration file.
- **Or**, in your application in the source code.

By default, .NET Framework 4.7 and later versions are configured to use TLS 1.2 and allow connections using TLS 1.1 or TLS 1.0. Configure WCF to allow the OS to choose the best security protocol by configuring your binding to use <xref:System.Security.Authentication.SslProtocols.None?displayProperty=nameWithType>. This can be set on <xref:System.ServiceModel.TcpTransportSecurity.SslProtocols>. `SslProtocols.None` can be accessed from <xref:System.ServiceModel.NetTcpSecurity.Transport>. `NetTcpSecurity.Transport` can be accessed from <xref:System.ServiceModel.NetTcpBinding.Security>.

If you're using a custom binding:

- Configure WCF to allow the OS to choose the best security protocol by setting <xref:System.ServiceModel.Channels.SslStreamSecurityBindingElement.SslProtocols> to use <xref:System.Security.Authentication.SslProtocols.None?displayProperty=nameWithType>.
- **Or** configure the protocol used with the configuration path `system.serviceModel/bindings/customBinding/binding/sslStreamSecurity:sslProtocols`.

If you're **not** using a custom binding **and** you're setting your WCF binding using configuration, set the protocol used with the configuration path `system.serviceModel/bindings/netTcpBinding/binding/security/transport:sslProtocols`.

#### Using Message Security with certificate credentials

.NET Framework 4.7 and later versions by default use the protocol specified in the <xref:System.Net.ServicePointManager.SecurityProtocol> property. When the [AppContextSwitch](../configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md) `Switch.System.ServiceModel.DisableUsingServicePointManagerSecurityProtocols` is set to `true`, WCF chooses the best protocol, up to TLS 1.0.

### If your app targets a .NET Framework version earlier than 4.7

The following sections show how to configure your application to use `currently considered secure versions` of TLS. (TLS 1.2, TLS 1.3)

#### Using .NET Framework 4.6.2 using TCP transport security with Certificate Credentials

The WCF framework automatically chooses the highest protocol available up to TLS 1.2 unless you explicitly configure a protocol version. For more information, see the preceding section [For WCF TCP transport using transport security with certificate credentials](#wcf-tcp-cert).

#### Using .NET Framework 3.5 using TCP transport security with Certificate Credentials

These versions of the WCF framework are explicitly specified to use values SSL 3.0 and TLS 1.0. These values cannot be changed. You must update and retarget to NET Framework 4.6.2 or later versions to use TLS 1.2.

## Configure security via AppContext switches (for .NET Framework 4.6.2 or later versions)

The [AppContext](../configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md) switches described in this section are relevant if your app targets, or runs on, .NET Framework 4.6.2 or later versions. Whether by default, or by setting them explicitly, the switches should be `false` if possible. If you want to configure security via one or both switches, then don't specify a security protocol value in your code; doing so would override the switch(es).

### For System.Net APIs (HttpClient, SslStream)

The switches have the same effect whether you're doing HTTP networking (<xref:System.Net.ServicePointManager>) or TCP sockets networking (<xref:System.Net.Security.SslStream>).

#### Switch.System.Net.DontEnableSchUseStrongCrypto

A value of `false` for `Switch.System.Net.DontEnableSchUseStrongCrypto` causes your app to use strong cryptography. A value of `false` for `DontEnableSchUseStrongCrypto` uses more secure network protocols (TLS 1.2 and TLS 1.1) and blocks protocols that are not secure. For more info, see [The SCH_USE_STRONG_CRYPTO flag](#the-sch_use_strong_crypto-flag). A value of `true` disables strong cryptography for your app. This switch affects only client (outgoing) connections in your application.

If your app targets .NET Framework 4.6.2 or later versions, this switch defaults to `false`. That's a secure default, which we recommend. If your app runs on .NET Framework 4.6.2, but targets an earlier version, the switch defaults to `true`. In that case, you should explicitly set it to `false`.

`DontEnableSchUseStrongCrypto` should only have a value of `true` if you need to connect to legacy services that don't support strong cryptography and can't be upgraded.

#### Switch.System.Net.DontEnableSystemDefaultTlsVersions

A value of `false` for `Switch.System.Net.DontEnableSystemDefaultTlsVersions` causes your app to allow the operating system to choose the protocol. A value of `true` causes your app to use protocols picked by the .NET Framework.

If your app targets .NET Framework 4.7 or later versions, this switch defaults to `false`. That's a secure default that we recommend. If your app runs on .NET Framework 4.7 or later versions, but targets an earlier version, the switch defaults to `true`. In that case, you should explicitly set it to `false`.

### For WCF applications

#### Switch.System.ServiceModel.DisableUsingServicePointManagerSecurityProtocols

A value of `false` for `Switch.System.ServiceModel.DisableUsingServicePointManagerSecurityProtocols` causes your application to use the value defined in `ServicePointManager.SecurityProtocols` for message security using certificate credentials. A value of `true` uses the highest protocol available, up to TLS1.0

For applications targeting .NET Framework 4.7 and later versions, this value defaults to `false`. For applications targeting .NET Framework 4.6.2 and earlier, this value defaults to `true`.

#### Switch.System.ServiceModel.DontEnableSystemDefaultTlsVersions

A value of `false` for `Switch.System.ServiceModel.DontEnableSystemDefaultTlsVersions` sets the default configuration to allow the operating system to choose the protocol. A value of `true` sets the default to the highest protocol available, up to TLS1.2.

For applications targeting .NET Framework 4.7.1 and later versions, this value defaults to `false`. For applications targeting .NET Framework 4.7 and earlier, this value defaults to `true`.

For more information about TLS protocols, see [Mitigation: TLS Protocols](../migration-guide/mitigation-tls-protocols.md). For more information about `AppContext` switches, see [`<AppContextSwitchOverrides> Element`](../configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md).

## Configure security via the Windows Registry

> [!WARNING]
> Setting registry keys affects all applications on the system. Use this option only if you are in full control of the machine and can control changes to the registry.

If setting one or both `AppContext` switches isn't an option, you can control the security protocols that your app uses with the Windows Registry keys described in this section. You might not be able to use one or both the `AppContext` switches if your app runs on .NET Framework 3.5, or if you can't edit the configuration file. If you want to configure security with the registry, don't specify a security protocol value in your code; doing so overrides the registry setting.

The names of the registry keys are similar to the names of the corresponding `AppContext` switches but without a `DontEnable` prepended to the name. For example, the `AppContext` switch `DontEnableSchUseStrongCrypto` is the registry key called [SchUseStrongCrypto](#schusestrongcrypto).

These keys are available in all .NET Framework versions.

All of the registry keys described below have the same effect whether you're doing HTTP networking (<xref:System.Net.ServicePointManager>) or TCP sockets networking (<xref:System.Net.Security.SslStream>).

### SchUseStrongCrypto

The `HKEY_LOCAL_MACHINE\SOFTWARE\[Wow6432Node\]Microsoft\.NETFramework\<VERSION>: SchUseStrongCrypto` registry entry has a value of type DWORD. A value of 1 causes your app to use strong cryptography. The strong cryptography uses more secure network protocols (TLS 1.2 and TLS 1.1) and blocks protocols that aren't secure. A value of 0 disables strong cryptography. For more information, see [The SCH_USE_STRONG_CRYPTO flag](#the-sch_use_strong_crypto-flag). This registry setting affects only client (outgoing) connections in your application.

If your app targets .NET Framework 4.6 or later versions, this key defaults to a value of 1. That's a secure default that we recommend. If your app targets .NET Framework 4.5.2 or earlier versions, the key defaults to 0. In that case, you should explicitly set its value to 1.

This key should only have a value of 0 if you need to connect to legacy services that don't support strong cryptography and can't be upgraded.

### SystemDefaultTlsVersions

The `HKEY_LOCAL_MACHINE\SOFTWARE\[Wow6432Node\]Microsoft\.NETFramework\<VERSION>: SystemDefaultTlsVersions` registry entry has a value of type DWORD. A value of 1 causes your app to allow the operating system to choose the protocol. A value of 0 causes your app to use protocols picked by the .NET Framework.

`<VERSION>` must be v4.0.30319 (for .NET Framework 4 and above) or v2.0.50727 (for .NET Framework 3.5).

If your app targets .NET Framework 4.7 or later versions, this key defaults to a value of 1. That's a secure default that we recommend. If your app targets .NET Framework 4.6.1 or earlier versions, the key defaults to 0. In that case, you should explicitly set its value to 1.

For more info, see [Cumulative Update for Windows 10 Version 1511 and Windows Server 2016 Technical Preview 4: May 10, 2016](https://support.microsoft.com/help/3156421/cumulative-update-for-windows-10-version-1511-and-windows-server-2016).

For more information with .NET Framework 3.5.1, see [Support for TLS System Default Versions included in .NET Framework 3.5.1 on Windows 7 SP1 and Server 2008 R2 SP1](https://support.microsoft.com/help/3154518/support-for-tls-system-default-versions-included-in-the--net-framework).

The following _.REG_ file sets the registry entries and their variants to their most safe values:

```text
Windows Registry Editor Version 5.00

[HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\.NETFramework\v2.0.50727]
"SystemDefaultTlsVersions"=dword:00000001
"SchUseStrongCrypto"=dword:00000001

[HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\.NETFramework\v4.0.30319]
"SystemDefaultTlsVersions"=dword:00000001
"SchUseStrongCrypto"=dword:00000001

[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\.NETFramework\v2.0.50727]
"SystemDefaultTlsVersions"=dword:00000001
"SchUseStrongCrypto"=dword:00000001

[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\.NETFramework\v4.0.30319]
"SystemDefaultTlsVersions"=dword:00000001
"SchUseStrongCrypto"=dword:00000001
```

## Configure Schannel protocols in the Windows Registry

You can use the registry for fine-grained control over the protocols that your client and/or server app negotiates. Your app's networking goes through Schannel (which is another name for [Secure Channel](/windows/desktop/SecAuthN/secure-channel)). By configuring `Schannel`, you can configure your app's behavior.

Start with the `HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\SecurityProviders\SCHANNEL\Protocols` registry key. Under that key you can create any subkeys in the set `TLS 1.2`, `TLS 1.3`. Under each of those subkeys, you can create subkeys `Client` and/or `Server`. Under `Client` and `Server`, you can create DWORD values `DisabledByDefault` (0 or 1) and `Enabled` (0 or 1).

For more information see: [TLS Registry Settings - Schannel](/windows-server/security/tls/tls-registry-settings?tabs=diffie-hellman#tls-dtls-and-ssl-protocol-version-settings)

## The SCH_USE_STRONG_CRYPTO flag

When it's enabled (by default, by [an `AppContext` switch](#switchsystemnetdontenableschusestrongcrypto), or [by the Windows Registry](#schusestrongcrypto)), .NET Framework uses the `SCH_USE_STRONG_CRYPTO` flag when your app initiates a TLS connection to a server. .NET Framework passes the flag to `Schannel` to instruct it to disable known weak cryptographic algorithms, cipher suites, and TLS/SSL protocol versions that may be otherwise enabled for better interoperability. For more information, see:

- [Secure Channel](/windows/desktop/SecAuthN/secure-channel)
- [SCHANNEL_CRED structure](/windows/win32/api/schannel/ns-schannel-schannel_cred)

The `SCH_USE_STRONG_CRYPTO` flag is also passed to `Schannel` for client (outgoing) connections when you explicitly use the `Tls11` or `Tls12` enumerated values of <xref:System.Net.SecurityProtocolType> or <xref:System.Security.Authentication.SslProtocols>. The `SCH_USE_STRONG_CRYPTO` flag is used only for connections where your application acts the role of the client. You can disable weak protocols and algorithms when your applications acts the role of the server by configuring the machine-wide `Schannel` registry settings.
