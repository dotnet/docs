---
title: "NETSDK1137: Don't use the Microsoft.NET.Sdk.WindowsDesktop SDK"
description: How to resolve the `Don't use the Microsoft.NET.Sdk.WindowsDesktop SDK' error message.
ms.topic: error-reference
ms.date: 07/08/2022
f1_keywords:
- NETSDK1137
---
# NETSDK1137: Don't use the Microsoft.NET.Sdk.WindowsDesktop SDK

NETSDK1137 indicates that your project specifies an outdated project SDK. The full error message is similar to the following example:

> It is no longer necessary to use the Microsoft.NET.Sdk.WindowsDesktop SDK. Consider changing the Sdk attribute of the root Project element to 'Microsoft.NET.Sdk'.

To resolve this error, modify your project file to have `<Project Sdk="Microsoft.NET.Sdk">` instead of the `WindowsDesktop` SDK.
