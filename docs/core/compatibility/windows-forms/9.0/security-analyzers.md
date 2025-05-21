---
title: "Breaking change: New security analyzers"
description: Learn about the .NET 9 breaking change in Windows Forms where new security analyzers have been introduced to prevent accidental leaks of sensitive data.
ms.date: 10/04/2024
ms.topic: concept-article
---
# New security analyzers

New security analyzers have been introduced to prevent the accidental leaking of user data through certain properties. These analyzers enforce best practices by identifying properties that lack explicit serialization settings, for example:

- <xref:System.ComponentModel.DesignerSerializationVisibilityAttribute>
- <xref:System.ComponentModel.DefaultValueAttribute>
- `ShouldSerialize[propertyName]` methods

The analyzers produce warnings such as:

> WFO1000: Property 'property' does not configure the code serialization for its property content.

By default, each analyzer produces an error, ensuring that developers are made aware of potential security and data leakage issues early in the development process.

This change aims to enhance the security and maintainability of Windows Forms apps by enforcing proper serialization practices, thus reducing the risk of accidental data exposure.

## Previous behavior

Previously, properties in Windows Forms and <xref:System.Windows.Forms.UserControl> controls could be serialized by the designer without explicit configuration of their serialization behavior. This could result in unintended data being included in the generated code or resource files, creating a potential security risk. This behavior was particularly problematic in custom line-of-business <xref:System.Windows.Forms.UserControl> objects, where it was easy to overlook the serialization of sensitive data that should not have been exposed. For example, properties containing sensitive information, such as user data or internal configurations, could be written directly into the designer-generated *.cs* files or embedded within *.resx* files.

## New behavior

Starting in .NET 9, the new Windows Forms security analyzers enforce stricter control over the serialization of properties in controls and <xref:System.Windows.Forms.UserControl> objects. By default, the analyzer produces an error if a property does not have its CodeDOM serialization behavior explicitly defined. This behavior ensures that properties aren't inadvertently serialized. You can adjust the *.editorconfig* settings to change the analyzer's [severity](../../../../fundamentals/code-analysis/configuration-options.md#severity-level) or suppress the error.

## Version introduced

.NET 9 RC 1

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This change was made for two primary reasons:

- Enhanced security: By forcing explicit serialization definitions, the analyzer significantly reduces the risk of unintentional data exposure, particularly in LOB applications. This has happened in the past, and it's all the more necessary now in the context of the [BinaryFormatter serializer removal](../../serialization/9.0/binaryformatter-removal.md). By preventing as much as possible from being serialized by accident to begin with, there won't be backwards compatibility or security issues around binary serialization in resource files for types that don't have a dedicated type converter.

- Improved code clarity and maintainability: This feature ensures that serialization behavior is transparent and intentional, which aids in code reviews and future maintenance.

## Recommended action

- Review the properties flagged by the analyzer and configure appropriate serialization settings as needed.
- For a quick fix (not recommended), add the following entry in an *.editorconfig* file at the solution folder or project folder level:

  ```ini
  [*.cs]

  # WFO1000: A property should determine its property content serialization with the DesignerSerializationVisibilityAttribute, DefaultValueAttribute or the ShouldSerializeProperty method
  dotnet_diagnostic.WFO1000.severity = silent
  ```

## Affected APIs

- N/A
