---
title: How to customize analysis with JSON run configurations
description: Learn how to include a JSON file to configure your code assessment
ms.topic: conceptual
ms.date: 5/16/2024
author: mckennabarlow
ms.author: mckennabarlow
---
# How to customize analysis with run config

## Overview

Before running an analysis, AppCAT discovers all rules and analyzers provided to it and then uses that information to match the project's `traits`. However, the analysis results can be overly verbose when using the default configuration.

To control/scope rules and/or analyzers used, you can provide a JSON run configuration file. This allows you to:

- Change default settings to include or exclude some binaries.
- Disable existing specific rules or specific analyzers.
- Change properties in existing rules.
- Add new rules.
- Add new analyzers for existing or new rules.

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

Looking at the JSON objects contained in the preceding example:

- `analysis.settings` contains global includes or excludes. These include and exclude binaries to be analyzed. It's recommended to run binary analysis once to see any red flags, but results for binaries tend to be verbose. Some of the results could flag problems inside dependencies your application is consuming. Other results could be valid problems in your app, but located in unused code paths. These can be ignored to reduce the verbosity of the results.
- `analysis.rules` contains rules definitions. These definitions override or disable existing rules, as well as define new rules.
- `analysis.analyzers` contains analyzers. Similarly to the rules definitions, these can be disabled, overridden, or added on to.

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
