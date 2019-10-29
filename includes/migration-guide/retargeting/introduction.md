## Introduction

Retargeting changes affect apps that are recompiled to target a different version of the .NET Framework. They include:

* Changes in the design-time environment. For example, build tools may emit warnings when previously they did not.

* Changes in the run-time environment. These changes only affect apps that specifically target the retargeted version. Apps that target previous versions of the .NET Framework behave as they did when running under those versions.

In the topics that describe retargeting changes, individual items are classified by their expected impact, as follows:

**Major**\
A significant change that affects a large number of apps or that requires substantial modification of code.

**Minor**\
A change that affects a small number of apps or that requires minor modification of code.

**Edge case**\
A change that affects apps under very specific scenarios that are not common.

**Transparent**\
A change that has no noticeable effect on the app's developer or user. The app should not require modification because of this change.
