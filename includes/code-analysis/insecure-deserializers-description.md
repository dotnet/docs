---
author: dotpaul
ms.author: paulming
ms.date: 04/05/2019
ms.topic: include
---
Insecure deserializers are vulnerable when deserializing untrusted data. An attacker could modify the serialized data to include unexpected types to inject objects with malicious side effects. An attack against an insecure deserializer could, for example, execute commands on the underlying operating system, communicate over the network, or delete files.
