---
title: JSON schema exporter
description: Learn how to use the JsonSchemaExporter class to extract JSON schema documents from .NET types.
ms.date: 10/15/2024
dev_langs:
  - "csharp"
ms.topic: article
---

# JSON schema exporter

The <xref:System.Text.Json.Schema.JsonSchemaExporter> class, introduced in .NET 9, lets you extract [JSON schema](https://json-schema.org/) documents from .NET types using either a <xref:System.Text.Json.JsonSerializerOptions> or <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo> instance. The resultant schema provides a specification of the JSON serialization contract for the .NET type. The schema describes the shape of what would be serialized and what can be deserialized.

The following code snippet shows an example.

:::code language="csharp" source="snippets/schema-exporter/ExportSchema.cs" id="1":::

As can be seen in this example, the exporter distinguishes between nullable and non-nullable properties, and it populates the `required` keyword by virtue of a constructor parameter being optional or not.

## Configure the schema output

You can influence the schema output by configuration specified in the <xref:System.Text.Json.JsonSerializerOptions> or <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo> instance that you call the <xref:System.Text.Json.Schema.JsonSchemaExporter.GetJsonSchemaAsNode*> method on. The following example sets the naming policy to <xref:System.Text.Json.JsonNamingPolicy.KebabCaseUpper>, writes numbers as strings, and disallows unmapped properties.

:::code language="csharp" source="snippets/schema-exporter/ExportSchema.cs" id="2":::

You can further control the generated schema using the <xref:System.Text.Json.Schema.JsonSchemaExporterOptions> configuration type. The following example sets the <xref:System.Text.Json.Schema.JsonSchemaExporterOptions.TreatNullObliviousAsNonNullable> property to `true` to mark root-level types as non-nullable.

:::code language="csharp" source="snippets/schema-exporter/ExportSchema.cs" id="3":::

## Transform the generated schema

You can apply your own transformations to generated schema nodes by specifying a <xref:System.Text.Json.Schema.JsonSchemaExporterOptions.TransformSchemaNode> delegate. The following example incorporates text from <xref:System.ComponentModel.DescriptionAttribute> annotations into the generated schema.

:::code language="csharp" source="snippets/schema-exporter/TransformSchema.cs" id="1":::

The following code example generates a schema that incorporates `description` keyword source from <xref:System.ComponentModel.DescriptionAttribute> annotations:

:::code language="csharp" source="snippets/schema-exporter/TransformSchema.cs" id="2":::
:::code language="csharp" source="snippets/schema-exporter/TransformSchema.cs" id="Person":::
