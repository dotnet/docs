---
title: How to customize analysis with JSON run configurations
description: Learn how to include a JSON file to configure your code assessment
ms.topic: conceptual
ms.date: 5/16/2024
author: mcbarlow
ms.author: mcbarlow
---
# How to customize analysis with run config

## Overview

Before running an analysis we discover all rules and analyzers provided to AppCAT and then use all that match current project's `traits`. However some results could be too noisy for some applications.

To control/scope rules and/or analyzers used, you can provide a json run config file which would allow you to:

- change default settings to include or exclude some binaries
- disable existing specific rules or specific analyzers
- change properties in existing rules
- add new rules
- add new analyzers for existing or new rules

## How to provide run config

For CLI:

- in the interactive mode CLI will ask if you want to provide run config and then if you said yes, asks to type/paste path to the run config file.
- in non-interactive mode there is new argument `-c|--config` which allows to provide the path to the run config json.

For VS:

- at the step where we allow to edit analysis settings we added a text box and `Browse` button to let you specify a run config json.

After analysis is done, run config is stored in the report and re-used if user opens report again and refreshes.

## Run config schema

Here is a sample run config:

```
{
  "analysis": {
    "settings": {
      "binaries": {
        "useDefaultExclusions": true,
        "include": [
          "**/*webmvc.dll",
          "**/*Transit.dll"
        ],
        "exclude": [
        ]
      }
    },
    "rules": [
      {
        "id": "Identity.0001",
        "severity": "potential",
        "effort": 5
      },
      {
        "id": "Local.0001",
        "enabled": false
      },
      {
        "id": "Local.0003",
        "enabled": false
      }
    ],
    "analyzers": [
      {
        "id": "Identity.0001.Types",
        "enabled": false
      },
      {
        "ruleId": "Local.0004",
        "id": "Local.0004.Profiles",
        "kind": "namespace",
        "properties": {
          "namespaces": [
            "Microsoft.Win32"
          ]
        }
      }
    ]
  }
}

```

`Settings` section contains globing includes or excludes applied to filter in or out binaries that are going to be analyzed. It probably makes sense to run binary analysis once to see any red flags, however results for binaries are pretty verbose. Some findings could indeed flag a real problem inside binary dependency application is using without realizing it. However others could be (although valid) but in code paths not used by the application and could be ignored. To avoid being overwhelmed by amount of results for binaries, users could include only ones they really interested in instead of scanning all of them.

`Rules` section contains rules definitions which could override existing rules' properties, disable existing rule or even define new ones.

`Analyzers` section contains analyzers, which similarly to rules could be disabled or new analyzers could be added.

## Examples for common scenarios

### Add new rule

```
{
  "rules": [
    {
      "id": "Category.NumericId",
      "severity": "potential",
      "effort": 5
      ...
    }
  ]
}
```

### Modify existing rule

```
{
  "rules": [
    {
      "id": "Category.NumericId",
      // specify new property values
    }
  ]
}
```

### Disable existing rule

```
{
  "rules": [
    {
      "id": "Category.NumericId",
      "enabled": false
    }
  ]
}
```

### Disable existing analyzer

```
{
  "analyzers": [
    {
      "id": "analyzerId",
      "enabled": false
    }
  ]
}
```

### Add new analyzer for some existing or new rule

```
{
  "analyzers": [
    {
      "ruleId": "rule id",
      "id": "analyzer id",
      "kind": "analyzer kind",
      "properties": {
        // properties specific for analyzer kind
      }
    }
  ]
}
```
