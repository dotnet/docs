---
description: "Learn more about: How to: Secure Messages within Reliable Sessions"
title: "How to: Secure Messages within Reliable Sessions"
ms.date: "03/30/2017"
ms.assetid: aee33e50-936f-4486-9ca8-c1520c19a62d
---

# How to: Secure Messages within Reliable Sessions

This topic outlines the steps required to enable message-level security for messages exchanged within a reliable session using one of the system-provided bindings that support such a session, but not by default. Enable a secure, reliable session either imperatively by using code or declaratively in the configuration file. This procedure uses the client and service configuration files to enable the secure, reliable session.

This procedure consists of the following three key tasks:

1. Specify that the client and service exchange messages within a reliable session.

1. Require message-level security within the reliable session.

1. Specify the client credential type that the client must use to be authenticated with the service.

It's important in the first task that the endpoint configuration element contain a `bindingConfiguration` attribute that references a binding configuration named (in this example) `MessageSecurity`. The [**\<binding>**](../../configure-apps/file-schema/wcf/bindings.md) configuration element then references this name to enable reliable sessions by setting the `enabled` attribute of the [**\<reliableSession>**](/previous-versions/ms731375(v=vs.90)) element to `true`. You can require that the ordered delivery assurances are available within a reliable session by setting the `ordered` attribute to `true`.

For the source copy of the example on which this configuration procedure is based, see the [WS Reliable Session](/previous-versions/dotnet/framework/wcf/samples/ws-reliable-session).

The essential items of the second task are accomplished by setting the `mode` attribute of the **\<security>** element contained in the **\<binding>** element of the client and service to `Message`.

The essential items of the third task are accomplished by setting the `clientCredentialType` attribute of the **\<message>** element contained in the **\<security>** element of the client and service to `Certificate`.

> [!NOTE]
> When using message security with reliable sessions, Reliable Messaging attempts to authenticate an unauthenticated client until a timeout occurs instead of throwing an exception upon first failure.

### Configure the service with a WSHttpBinding to use a reliable session

This procedure is described in [How to: Exchange Messages Within a Reliable Session](how-to-exchange-messages-within-a-reliable-session.md).

### Configure the client with a WSHttpBinding to use a reliable session

This procedure is described in [How to: Exchange Messages Within a Reliable Session](how-to-exchange-messages-within-a-reliable-session.md).

### Set the mode and ClientCredentialType in configuration

1. Add an appropriate binding element to the [**\<bindings>**](../../configure-apps/file-schema/wcf/bindings.md) element of the configuration file. The following example adds a [**\<wsHttpBinding>**](../../configure-apps/file-schema/wcf/wshttpbinding.md) element.

1. Add a **\<binding>** element and set its `name` attribute to an appropriate value. The example uses the name `MessageSecurity`.

1. Add a **\<security>** element and set the `mode` attribute to `Message`.

1. Within the **\<security>** element, add a **\<message>** element and set the `clientCredentialType` attribute to `Certificate`.

```xml
<wsHttpBinding>
  <binding name="MessageSecurity">
    <security mode="Message">
      <message clientCredentialType="Certificate" />
    </security>
  </binding>
</wsHttpBinding>
```
