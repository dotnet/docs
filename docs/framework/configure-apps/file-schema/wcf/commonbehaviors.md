---
description: "Learn more about: <commonBehaviors>"
title: "<commonBehaviors>"
ms.date: "03/30/2017"
ms.assetid: 5260aeca-388d-4e82-94c0-124fa8054cf5
---
# \<commonBehaviors>

The `commonBehaviors` section can only be defined in the machine.config file. It defines two child collections named `endpointBehaviors` and `serviceBehaviors`.  Each collection defines behavior elements consumed by all WCF endpoints and services on the machine respectively. Behaviors defined in `endpointBehaviors` are only applied to clients, and behaviors defined in `serviceBehaviors` are only applied to services. If a behavior is defined in both `commonBehaviors` and `behaviors` sections, the behavior in the `behaviors` section is given preference.
