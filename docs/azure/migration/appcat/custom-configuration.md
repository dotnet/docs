---
title: Azure migrate application and code assessment for .NET installation
description: Learn how to install Azure migrate application and code assessment for .NET
ms.topic: conceptual
ms.date: 08/16/2024
---

# How to customize analysis through run configs

The Azure migrate application and code assessment tool supports custom analysis using run configs. Before the tool runs an analysis, it discovers all available rules and analyzers and then uses the ones that match current project's traits. However, some results might be too noisy for some applications.

Provide a json run config file to manage and scope the rules and analyzers:

- Change default settings to include or exclude binaries  
- Disable existing specific rules or analyzers  
- Change properties in existing rules
- Add new rules  
- Add new analyzers for existing or new rules  

## How to provide run config

# [CLI](#tab/cli)

- **Interactive mode** - Select `Yes` when the CLI asks if you want to provide run config, and then enter the path to the run config file.
- **Non-interactive mode** - Provide the `-c` or `--config` argument, which allows you to provide the path to the run config json.

# [Visual Studio](#tab/visual-studio)

- During the step that allows you to edit analysis settings, select the **Browse** button to locate and specify a run config json file.

---

After the analysis completes, the report stores the run config and reuses it if user opens the report again and refreshes.

## Run config schema

Consider the following sample run config:

```json
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

- **Settings** includes or excludes the binaries that should be analyzed. Results for binaries are often verbose, so you might want to only include specific binaries instead of scanning all of them.

- **Rules** contains rule definitions to override or disable existing rule properties, or define new rules.

- **Analyzers** disables or adds new analyzers.

# Examples for common scenarios

## Add new rule

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

## Modify existing rule

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

## Disable existing rule

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

## Disable existing analyzer

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

## Add new analyzer for some existing or new rule

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
