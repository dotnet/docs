---
title: "NETSDK1195: Trimming, or code compatibility analysis for trimming, single-file deployment, or ahead-of-time compilation is not supported for the target framework."
description: How to resolve compatibility problems with features that rely on the ILLink pack.
ms.topic: error-reference
ms.date: 06/05/2023
f1_keywords:
- NETSDK1195
---
# NETSDK1195: Trimming, or code compatibility analysis for trimming, single-file deployment, or ahead-of-time compilation is not supported for the target framework.

NETSDK1195 indicates that you're using a feature of the SDK which is not available for the selected target framework. The following features depend on the ILLink pack, which is only available when targeting `netcoreapp3.0` and above:

- Trimming (via `PublishTrimmed` or `PublishAot`)
- Trim analysis (via `PublishTrimmed`, `PublishAot`, `IsTrimmable`, `IsAotCompatible`, or `EnableTrimAnalyzer`)
- Single-file analysis (via `PublishSingleFile` or `EnableSingleFileAnalyzer`)
- Ahead-of-time compilation analysis (via `PublishAot` or `EnableAotAnalyzer`)

To resolve this error, either target a supported `TargetFramework`, or turn off the setting that requires the ILLink pack.
