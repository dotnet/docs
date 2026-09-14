---
title: dnim layout command
description: The layout command creates a cache for offline deployments.
author: joeloff
ms.date: 08/11/2026
---

# dnim layout

## Name

`dnim-win-[x86|x64|arm64] layout` - Creates or updates a cache for offline deployments.

## Synopsis

```dotnetcli
dnim-win-[x86|x64|arm64] layout <DIRECTORY> [-a|--accept-license]
    [--include-installers]
    [--include-previes] 
    [-l|--log-file <LOG_FILE>] 
    [--latest]
    [-v|--verbosity <quiet|normal|diagnostic>]

dnim-win-[x86|x64|arm64] layout -?|-h|--help
```

## Description

## Options

- [!INCLUDE [accept-license](includes/dnim-cli-accept-license.md)]

- [!INCLUDE [include-installers](includes/dnim-cli-include-installers.md)]

- [!INCLUDE [include-previews](includes/dnim-cli-include-previews.md)]

- [!INCLUDE [log-file](includes/dnim-cli-log-file.md)]

- [!INCLUDE [latest](includes/dnim-cli-latest.md)]

- [!INCLUDE [verbosity](includes/dnim-cli-verbosity.md)]

## Results



## Examples

- Create an offline deployment in `C:\dnim\layout` that only include the release metadata (no installers).

  ```console
  dnim-win-[x86|x64|arm64] layout C:\dnim\layout
  ```

- Create an offline deployment in `C:\dnim\layout` that includes the latest installers.

  ```console
  dnim-win-[x86|x64|arm64] layout C:\dnim\layout --latest
  ```

## See also
