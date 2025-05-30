---
title: How to customize analysis with JSON run configurations
description: Learn how to include a JSON file to configure your code assessment
ms.topic: concept-article
ms.date: 08/02/2024
author: mckennabarlow
ms.author: mcbarlow
---
# How to customize analysis using run configs

The Azure Migrate application and code assessment tool supports custom analysis using run configs. Before the tool runs an analysis, it discovers all available rules and analyzers and then uses the ones that match current project's traits. However, some results might be too noisy for some applications.

To control/scope rules and/or analyzers used, you can provide a JSON run configuration file. This allows you to:

- Change default settings to include or exclude some binaries.
- Disable existing specific rules or specific analyzers.
- Change properties in existing rules.
- Add new rules.
- Add new analyzers for existing or new rules.

## How to provide a JSON run configuration

## [.NET CLI](#tab/cli)

The Azure Migrate application and code assessment tool enables you to [Analyze applications with the .NET CLI](dotnet-cli.md). When using the CLI, there are two options to provide a run config:

- **Interactive mode**: The CLI asks if you want to provide run config. Select `Yes` and then provide the path to the run config file.
- **Non-interactive mode**: Provide the `-c` or `--config` argument, which allows you to provide the path to the run config JSON.

## [Visual Studio](#tab/visual-studio)

The Azure Migrate application and code assessment tool enables you to [Analyze applications with Visual Studio](visual-studio.md). During the step that allows you to edit analysis settings, select the **Browse** button to locate and select a run config JSON file. After analysis is done, run configuration is stored in the report. The configuration is re-used if the user reopens the report and refreshes.

---

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

- `analysis.settings` contains global includes or excludes. These include and exclude binaries to be analyzed. It's recommended to run binary analysis once to see any red flags, but results for binaries tend to be verbose. Some of the results could flag problems inside dependencies your application is consuming. Other results could be valid problems in your app, but located in unused code paths. These can be ignored to reduce the verbosity of the results.
- `analysis.rules` contains rules definitions. These definitions override or disable existing rules, as well as define new rules.
- `analysis.analyzers` contains analyzers. Similarly to the rules definitions, these can be disabled, overridden, or added on to.

## Examples for common scenarios

### Add new rule

```json
{
  "rules": [
    {
      "id": "Category.NumericId",
      "severity": "potential",
      "effort": 5
    }
  ]
}
```

### Modify existing rule

```json
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

```json
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

```json
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

```json
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
