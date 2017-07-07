## Introduction
Retargeting changes affect apps that are recompiled to target a different .NET Framework. They include:

* Changes in the design-time environment. For example, build tools may emit warnings when previously they did not.

* Changes in the runtime environment. These affect only apps that specifically target the retargeted .NET Framework. Apps that target previous versions of the .NET Framework behave as they did when running under those versions.

In the topics that describe etargeting changes, we have classified individual items by their expected impact, as follows:

**Major**
This is a significant change that affects a large number of apps or that requires substantial modification of code.

**Minor**
This is a change that affects a small number of apps or that requires minor modification of code.

**Edge case**
This is a change that affects apps under very specific scenarios that are not common.

**Transparent**
This is a change that has no noticeable effect on the app's developer or user. The app should not require modification because of this change.
