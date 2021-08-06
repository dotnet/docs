---
title: Localization in .NET
description: Learn how to use the IStringLocalizer and IStringLocalizerFactory implementations with dependency injection in your .NET workloads.
author: IEvangelist
ms.author: dapine
ms.date: 08/06/2021
---

# Localization in .NET

In this article, you will learn how to use the <xref:Microsoft.Extensions.Localization.IStringLocalizer%601> and <xref:Microsoft.Extensions.Localization.IStringLocalizerFactory> implementations. Localization is the process of translating an application's resources into localized versions for each culture that the application supports.

All of the example source code in this article relies on the [`Microsoft.Extensions.Localization`](https://www.nuget.org/packages/microsoft.extensions.localization) and [`Microsoft.Extensions.Hosting`](https://www.nuget.org/packages/microsoft.extensions.hosting) NuGet packages. For more information on hosting, see [.NET Generic Host](generic-host.md).

## Resource files

The primary mechanism for isolating localizable strings is with **resource files**. A resource file is an XML file with the *.resx* file extension. Resource files are translated prior to the execution of the consuming application &mdash; in other words, they represent translated content at rest. A resource file name most commonly contains a locale identifier, and takes on the following form `{FullTypeName}[.Locale].resx` where:

- The `{FullTypeName}` represents localizable resources for a specific type.
- The optional `[.Locale]` represents the locale of the of the resource file contents.

### Specifying locales

The locale at a bare minimum should define the language, but it can also define the culture (dialect), and even the country. These segments are commonly delimited by the `-` character. With the added specificity of a culture, the "culture fallback" rules are applied where best matches are prioritized. The locale should map to a well-known language tags, see <xref:System.Globalization.CultureInfo.Name?displayProperty=nameWithType>.

### Culture fallback scenarios

Imagine that your localized app supports various Serbian locales, and has the following resource files for its `MessageService`:

| File                             | Dialect                       | Country Code |
|----------------------------------|-------------------------------|--------------|
| *MessageService.sr-Cyrl-RS.resx* | (Cyrillic, Serbia)            | RS           |
| *MessageService.sr-Cyrl.resx*    | Cyrillic                      |              |
| *MessageService.sr-Latn-BA.resx* | (Latin, Bosnia & Herzegovina) | BA           |
| *MessageService.sr-Latn-ME.resx* | (Latin, Montenegro)           | ME           |
| *MessageService.sr-Latn-RS.resx* | (Latin, Serbia)               | RS           |
| *MessageService.sr-Latn.resx*    | Latin                         |              |
| *MessageService.sr.resx*         | <sup>†</sup> Latin            |              |
| *MessageService.resx*            |                               |              |

_<sup>†</sup>  The default dialect for the language._

When your app is running with the <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=nameWithType> set to a culture of `"sr-Cyrl-RS"` localization attempts to resolve files in the following order:

1. *MessageService.sr-Cyrl-RS.resx*
1. *MessageService.sr-Cyrl.resx*
1. *MessageService.sr.resx*
1. *MessageService.resx*

However, if your app was running with the <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=nameWithType> set to a culture of `"sr-Latn-BA"` localization attempts to resolve files in the following order:

1. *MessageService.sr-Latn-BA.resx*
1. *MessageService.sr-Latn.resx*
1. *MessageService.sr.resx*
1. *MessageService.resx*

The "culture fallback" will entirely ignore locales, meaning resource file number four is selected if there are no corresponding matches. If the culture was set to `"fr-CA"`, localization would end up falling to the *MessageService.resx* file as it's the default.

### Resource lookup

Resource files are automatically resolved as part of a lookup routine. If your project file name different than the root namespace of your project, the assembly name might differ. This can prevent resource lookup. To address this mismatch, use the <xref:Microsoft.Extensions.Localization.RootNamespaceAttribute> to provide a hint to the localization services. This is used during resource lookup.

In the sample source, the project is named *example.csproj* which creates *example.dll* and *example.exe* &mdash; however, the namespace that is used is `Localization.Example`. Apply an `assembly` level attribute:

:::code source="snippets/localization/example/Program.cs" range="11":::

## Register localization services

To register localization services call one of the <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A> extension methods durning the configuration of services. This will enable dependency injection (DI), of the following types:

- <xref:Microsoft.Extensions.Localization.IStringLocalizer%601?displayProperty=fullName>
- <xref:Microsoft.Extensions.Localization.IStringLocalizerFactory?displayProperty=fullName>

### Configure localization options

The <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Action{Microsoft.Extensions.Localization.LocalizationOptions})> overload, accepts a `setupAction` parameter of `Action<LocalizationOptions>` type. This allows for the configuring of localization options.

```csharp
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddLocalization(options =>
        {
            options.ResourcesPath = "Resources");
        }
    });

// Omitted for brevity.
```

Resource files can live anywhere in a project, but there are common practices in place that have proven to be successful. More often than not, the path of least resistance is followed. The preceding C# code:

- Creates the default host builder.
- Calls <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureServices%2A?displayProperty=nameWithType> with the `IServiceCollection` overload.
- Calls `AddLocalization` to the service collection, specifying <xref:Microsoft.Extensions.Localization.LocalizationOptions.ResourcesPath?displayProperty=nameWithType> as `"Resources"`.

This would cause the localization services to look in the *Resources* directory for resource files.

## Use `IStringLocalizer<T>` and `IStringLocalizerFactory`

After you've [registered](#register-localization-services) (and optionally [configured](#configure-localization-options)) the localization services, you can use the following types with DI:

- <xref:Microsoft.Extensions.Localization.IStringLocalizer%601?displayProperty=fullName>
- <xref:Microsoft.Extensions.Localization.IStringLocalizerFactory?displayProperty=fullName>

To create a message service that is capable of returning localized strings, consider the following `MessageService`:

:::code source="snippets/localization/example/MessageService.cs" highlight="9,11-12,17":::

In the preceding C# code:

- A `IStringLocalizer<MessageService> _localizer` field is declared.
- The constructor takes a `IStringLocalizer<MessageService>` parameter and assigns it to the `_localizer` field.
- The `GetGreetingMessage` method invokes the <xref:Microsoft.Extensions.Localization.IStringLocalizer.Item(System.String)?displayProperty=nameWithType> passing `"GreetingMessage"` as an argument.

The `IStringLocalizer` also supports parameterized string resources, consider the following `ParameterizedMessageService`:

:::code source="snippets/localization/example/ParameterizedMessageService.cs" highlight="9,12-13,18":::

In the preceding C# code:

- A `IStringLocalizer _localizer` field is declared.
- The constructor takes a `IStringLocalizerFactory` parameter, which is used to create a `IStringLocalizer` from the `ParameterizedMessageService` type, and assigns it to the `_localizer` field.
- The `GetFormattedMessage` method invokes the <xref:Microsoft.Extensions.Localization.IStringLocalizer.Item(System.String,System.Object[])?displayProperty=nameWithType> passing `"DinnerPriceFormat"`, a `dateTime`, and the `dinnerPrice` as arguments.

Both <xref:Microsoft.Extensions.Localization.IStringLocalizer.Item%2A?displayProperty=nameWithType> indexers return a <xref:Microsoft.Extensions.Localization.LocalizedString>, which have [implicit conversions](xref:Microsoft.Extensions.Localization.LocalizedString.op_Implicit(Microsoft.Extensions.Localization.LocalizedString)~System.String) to `string?`.

## Put it all together

To exemplify an app using both message services, with localization and resource files consider the following *Program.cs* file:

:::code source="snippets/localization/example/Program.cs":::

In the preceding C# code:

- The <xref:Microsoft.Extensions.Localization.RootNamespaceAttribute> sets `"Localization.Example"` as the root namespace.
- The <xref:System.Console.OutputEncoding?displayProperty=nameWithType> is assigned to <xref:System.Text.Encoding.Unicode?displayProperty=nameWithType>.
- When a single argument is passed to `args`, the <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=nameWithType> and <xref:System.Globalization.CultureInfo.CurrentUICulture?displayProperty=nameWithType> are assigned the result of <xref:System.Globalization.CultureInfo.GetCultureInfo(System.String)?displayProperty=nameWithType> given the `arg[0]`.
- The host is created with [defaults](generic-host.md#default-builder-settings), localization services, `MessageService`, and `ParameterizedMessageService` are all added to the `IServiceCollection` for DI.
- Logging is configured to ignore any log level lower than a warning to remove noise.
- The `MessageService` is resolved from the `IServiceProvider` instance and its resulting message is logged.
- The `ParameterizedMessageService` is resolved from the `IServiceProvider` instance and its resulting formatted message is logged.

Each of the `*MessageService` classes, define a set of *.resx* files, each with a single entry. Here is the example content for the `MessageService` resource files:

| Resource file                    | Resource key                        | Resource value                                                                                   |
|---------------------------------:|-------------------------------------|--------------------------------------------------------------------------------------------------|
| *MessageService.resx*            | :::no-loc text="GreetingMessage"::: | :::no-loc text="Hi friends, the ".NET" developer community is excited to see you here!":::       |
| *MessageService.sr-Cyrl-RS.resx* | :::no-loc text="GreetingMessage"::: | :::no-loc text="Здраво пријатељи, ".NЕТ" девелопер заједница је узбуђена што вас види овде!":::  |
| *MessageService.sr-Latn.resx*    | :::no-loc text="GreetingMessage"::: | :::no-loc text="Zdravo prijatelji, ".NET" developer zajednica je uzbuđena što vas vidi ovde!"::: |

Here is the example content for the `ParameterizedMessageService` resource files:

| Resource file                                 | Resource key                          | Resource value                                            |
|----------------------------------------------:|---------------------------------------|-----------------------------------------------------------|
| *ParameterizedMessageService.resx*            | :::no-loc text="DinnerPriceFormat"::: | :::no-loc text="On {0:D} my dinner cost {1:C}.":::        |
| *ParameterizedMessageService.sr-Cyrl-RS.resx* | :::no-loc text="DinnerPriceFormat"::: | :::no-loc text="У {0:D} моја вечера је коштала {1:C}."::: |
| *ParameterizedMessageService.sr-Latn.resx*    | :::no-loc text="DinnerPriceFormat"::: | :::no-loc text="U {0:D} moja večera je koštala {1:C}."::: |

### Example runs

The following example runs show the various localized outputs, given targeted locales &mdash; consider `"sr-Latn"`:

```dotnetcli
dotnet run --project .\example\example.csproj sr-Latn
warn: Localization.Example[0]
      Zdravo prijatelji, ".NET" developer zajednica je uzbuđena što vas vidi ovde!
warn: Localization.Example[0]
      U utorak, 03. avgust 2021. moja večera je koštala 37,63 ¤.
```

When omitting an argument to the [.NET CLI to run](../tools/dotnet-run.md) the project, the default system culture is used &mdash; in this case `"en-US"`:

```dotnetcli
dotnet run --project .\example\example.csproj
warn: Localization.Example[0]
      Hi friends, the ".NET" developer community is excited to see you here!
warn: Localization.Example[0]
      On Tuesday, August 3, 2021 my dinner cost $37.63.
```

When passing `"sr-Cryl-RS"`, the correct corresponding resource files are found and the localization applied:

```dotnetcli
dotnet run --project .\example\example.csproj sr-Cryl-RS
warn: Localization.Example[0]
      Здраво пријатељи, ".NЕТ" девелопер заједница је узбуђена што вас види овде!
warn: Localization.Example[0]
      У уторак, 03. август 2021. моја вечера је коштала 38 RSD.
```

The sample application does not provide resource files for `"fr-CA"`, but when called with that locale, the non-locale resource files are fallen back to. But interestingly enough, since the culture is found when formatting is applied you end up with partial localization:

```dotnetcli
dotnet run --project .\example\example.csproj fr-CA
warn: Localization.Example[0]
      Hi friends, the ".NET" developer community is excited to see you here!
warn: Localization.Example[0]
      On mardi 3 août 2021 my dinner cost 37,63 $.
```

## See also

- [Globalizing and localizing .NET applications](../../standard/globalization-localization/index.md)
- [`Microsoft.Extensions.Localization`](https://www.nuget.org/packages/microsoft.extensions.localization)
- [Dependency injection in .NET](dependency-injection.md)
- [Logging in .NET](logging.md)
