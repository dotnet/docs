---
title: "Breaking change: Obsolete properties on ConsoleLoggerOptions"
description: Learn about the .NET 5 breaking change in core .NET libraries where the ConsoleLoggerFormat type and some properties on ConsoleLoggerOptions are now obsolete.
ms.date: 11/01/2020
---
# Obsolete properties on ConsoleLoggerOptions

The <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerFormat?displayProperty=nameWithType> type and some properties on <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions> are now obsolete.

## Change description

Starting in .NET 5, the <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerFormat?displayProperty=nameWithType> type and several properties on <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions> are obsolete. The obsolete properties are:

- <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.DisableColors?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.IncludeScopes?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.TimestampFormat?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.UseUtcTimestamp?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.Format?displayProperty=nameWithType>

With the introduction of new formatters, these properties are now available on the individual formatters.

## Reason for change

The <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.Format> property is an enumeration type, which cannot represent a custom formatter.

The remaining properties were set on <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions> and applied to both of the built-in formats for console logs. However, with the introduction of a new formatter API, it makes more sense for formatting to be represented on the formatter-specific options. This change provides better separation between the logger and logger formatters.

## Version introduced

5.0

## Recommended action

- Use the new <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.FormatterName?displayProperty=nameWithType> property in place of the <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.Format?displayProperty=nameWithType> property. For example:

  ```csharp
  loggingBuilder.AddConsole(options =>
  {
    options.FormatterName = ConsoleFormatterNames.Systemd;
  });
  ```

  There are several differences between <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.FormatterName> and <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.Format>:

  - <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.Format> has only two possible options: `Default` and `Systemd`.
  - <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.FormatterName> is case insensitive and can be any string. The reserved, built-in names are `Simple`, `Systemd`, and `Json` (.NET 5 and later).
  - `"Format": "Systemd"` maps to `"FormatterName": "Systemd"`.
  - `"Format": "Default"` maps to `"FormatterName": "Simple"`.

- For the <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.DisableColors>, <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.IncludeScopes>, <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.TimestampFormat>, and <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.UseUtcTimestamp> properties, use the corresponding property on the new <xref:Microsoft.Extensions.Logging.Console.ConsoleFormatterOptions>, <xref:Microsoft.Extensions.Logging.Console.JsonConsoleFormatterOptions>, or <xref:Microsoft.Extensions.Logging.Console.SimpleConsoleFormatterOptions> types instead. For example, the corresponding setting for <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.DisableColors?displayProperty=nameWithType> is <xref:Microsoft.Extensions.Logging.Console.SimpleConsoleFormatterOptions.ColorBehavior?displayProperty=nameWithType>.

  Previous code:

  ```csharp
  loggingBuilder.AddConsole(options =>
  {
      options.DisableColors = true;
  });
  ```

  New code:

  ```csharp
  loggingBuilder.AddSimpleConsole(options =>
  {
      options.ColorBehavior = LoggerColorBehavior.Disabled;
  });
  ```

The following two JSON snippets show how the configuration file changes. Old configuration file:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "None",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    },

    "Console": {
      "LogLevel": {
        "Default": "Information"
      },
      "Format": "Systemd",
      "IncludeScopes": true,
      "TimestampFormat": "HH:mm:ss",
      "UseUtcTimestamp": true
    }
  },
  "AllowedHosts": "*"
}
```

New configuration file:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "None",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    },

    "Console": {
      "LogLevel": {
        "Default": "Information"
      },
      "FormatterName": "Systemd",
      "FormatterOptions": {
        "IncludeScopes": true,
        "TimestampFormat": "HH:mm:ss",
        "UseUtcTimestamp": true
      }
    }
  },
  "AllowedHosts": "*"
}
```

## Affected APIs

- <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.DisableColors?displayProperty=fullName>
- <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.IncludeScopes?displayProperty=fullName>
- <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.TimestampFormat?displayProperty=fullName>
- <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.UseUtcTimestamp?displayProperty=fullName>
- <xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.Format?displayProperty=fullName>

<!--

#### Category

- Core .NET libraries
- ASP.NET

### Affected APIs

- `P:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.DisableColors`
- `P:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.IncludeScopes`
- `P:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.TimestampFormat`
- `P:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.UseUtcTimestamp`
- `P:Microsoft.Extensions.Logging.Console.ConsoleLoggerOptions.Format`

-->
