---
title: "Globalize and localize .NET applications"
description: Learn how to develop a world-ready application. Read about globalization, localizability review, and localization in .NET.
ms.date: 03/13/2023
helpviewer_keywords:
  - "international applications [.NET]"
  - "globalization [.NET], encoding"
  - "global applications"
  - "internationalization"
  - "world-ready applications"
  - "application development [.NET], globalization"
  - "multilingual application development"
ms.assetid: 9a59696b-d89b-45bd-946d-c75da4732d02
---

# Globalize and localize .NET applications

Developing a world-ready application, including an application that can be localized into one or more languages, involves three steps: globalization, localizability review, and localization.

[Globalization](globalization.md)

This step involves designing and coding an application that is culture-neutral and language-neutral, and that supports localized user interfaces and regional data for all users. It involves making design and programming decisions that are not based on culture-specific assumptions. While a globalized application is not localized, it nevertheless is designed and written so that it can be subsequently localized into one or more languages with relative ease.

[Localizability review](localizability-review.md)

This step involves reviewing an application's code and design to ensure that it can be localized easily and to identify potential roadblocks for localization, and verifying that the application's executable code is separated from its resources. If the globalization stage was effective, the localizability review will confirm the design and coding choices made during globalization. The localizability stage may also identify any remaining issues so that an application's source code doesn't have to be modified during the localization stage.

[Localization](localization.md)

This step involves customizing an application for specific cultures or regions. If the globalization and localizability steps have been performed correctly, localization consists primarily of translating the user interface.

Following these three steps provides two advantages:

- It frees you from having to retrofit an application that is designed to support a single culture, such as U.S. English, to support additional cultures.

- It results in localized applications that are more stable and have fewer bugs.

.NET provides extensive support for the development of world-ready and localized applications. In particular, many type members in the .NET class library aid globalization by returning values that reflect the conventions of either the current user's culture or a specified culture. Also, .NET supports satellite assemblies, which facilitate the process of localizing an application.

## In this section

[Globalization](globalization.md)

Discusses the first stage of creating a world-ready application, which involves designing and coding an application that is culture-neutral and language-neutral.

[.NET globalization and ICU](globalization-icu.md)

Describes how .NET globalization uses [International Components for Unicode (ICU)](https://icu.unicode.org/).

[Localizability review](localizability-review.md)

Discusses the second stage of creating a localized application, which involves identifying potential roadblocks to localization.

[Localization](localization.md)

Discusses the final stage of creating a localized application, which involves customizing an application's user interface for specific regions or cultures.

[Culture-insensitive string operations](performing-culture-insensitive-string-operations.md)

Describes how to use .NET methods and classes that are culture-sensitive by default to obtain culture-insensitive results.

[Best practices for developing world-ready applications](best-practices-for-developing-world-ready-apps.md)

Describes the best practices to follow for globalization, localization, and developing world-ready ASP.NET applications.

## Reference

- <xref:System.Globalization?displayProperty=nameWithType> namespace

   Contains classes that define culture-related information, including the language, the country/region, the calendars in use, the format patterns for dates, currency, and numbers, and the sort order for strings.

- <xref:System.Resources> namespace

   Provides classes for creating, manipulating, and using resources.

- <xref:System.Text> namespace

   Contains classes representing ASCII, ANSI, Unicode, and other character encodings.

- [Resgen.exe (Resource File Generator)](../../framework/tools/resgen-exe-resource-file-generator.md)

   Describes how to use Resgen.exe to convert .txt files and XML-based resource format (.resx) files to common language runtime binary .resources files.

- [Winres.exe (Windows Forms Resource Editor)](../../framework/tools/winres-exe-windows-forms-resource-editor.md)

   Describes how to use Winres.exe to localize Windows Forms forms.
