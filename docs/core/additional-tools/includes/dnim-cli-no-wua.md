---
ms.date: 08/12/2026
ms.topic: include
---
**`--no-wua`**

Temporarily stop the Windows Update Agent service when executing installation packages. DNIM stops the service only if it's running and restarts it only if DNIM stopped it. The option is intended to minimize the impact from other updates that may interfere with updating .NET.

> [!CAUTION]
> DNIM will make a best effort to restart WUA. It is possible for DNIM to exit abruptly before it is able to restart WUA if the process is killed. This could leave a device in a vulnerable state.
