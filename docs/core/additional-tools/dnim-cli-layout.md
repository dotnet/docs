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
    [--include-previews]
    [-l|--log-file <LOG_FILE>] 
    [--latest]
    [-v|--verbosity <quiet|normal|diagnostic>]

dnim-win-[x86|x64|arm64] layout -?|-h|--help
```

## Description

The command creates or updates a cache used for offline deployments inside network restricted environments. The command requires internet access to download the necessary files and will verify the signatures of any installers that are downloaded. Adminitrators should place the files on a machine that is accessible from client devices inside the network.

## Options

- [!INCLUDE [accept-license](includes/dnim-cli-accept-license.md)]

- [!INCLUDE [include-installers](includes/dnim-cli-include-installers.md)]

- [!INCLUDE [include-previews](includes/dnim-cli-include-previews.md)]

- [!INCLUDE [log-file](includes/dnim-cli-log-file.md)]

- [!INCLUDE [latest](includes/dnim-cli-latest.md)]

- [!INCLUDE [verbosity](includes/dnim-cli-verbosity.md)]

## Examples

- Create an offline deployment in `C:\dnim\layout` that only includes the release metadata (no installers).

  ```console
  dnim-win-[x86|x64|arm64] layout C:\dnim\layout
  ```

- Create an offline deployment in `C:\dnim\layout` that includes the latest installers.

  ```console
  dnim-win-[x86|x64|arm64] layout C:\dnim\layout --include-installers --latest
  ```

## See also
