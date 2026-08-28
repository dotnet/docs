---
title: JSON schema exporter
description: Learn how to use the JsonSchemaExporter class to extract JSON schema documents from .NET types.
ms.date: 08/18/2026
ai-usage: ai-assisted
dev_langs:
  - "csharp"
---

# JSON schema exporter

The <xref:System.Text.Json.Schema.JsonSchemaExporter> class, introduced in .NET 9, lets you extract [JSON schema](https://json-schema.org/) documents from .NET types. Use either a <xref:System.Text.Json.JsonSerializerOptions> or <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo> instance. The resulting schema describes the .NET type's JSON contract for serialization and deserialization.

The following code snippet shows an example.

:::code language="csharp" source="snippets/schema-exporter/ExportSchema.cs" id="1":::

The exporter distinguishes between nullable and non-nullable properties. It sets the `required` keyword based on whether a constructor parameter is optional.

Starting in .NET 11, the exporter recognizes the <xref:System.Numerics.BFloat16>, <xref:System.Numerics.Decimal32>, <xref:System.Numerics.Decimal64>, and <xref:System.Numerics.Decimal128> types. It exports schemas for their nullable forms and for named literals when you enable <xref:System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals>.

## Configure the schema output

To control schema output, pass a configured <xref:System.Text.Json.JsonSerializerOptions> or <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfo> instance to <xref:System.Text.Json.Schema.JsonSchemaExporter.GetJsonSchemaAsNode*>. The following example sets the naming policy to <xref:System.Text.Json.JsonNamingPolicy.KebabCaseUpper>, writes numbers as strings, and disallows unmapped properties.

:::code language="csharp" source="snippets/schema-exporter/ExportSchema.cs" id="2":::

To further control the generated schema, use <xref:System.Text.Json.Schema.JsonSchemaExporterOptions>. The following example sets <xref:System.Text.Json.Schema.JsonSchemaExporterOptions.TreatNullObliviousAsNonNullable> to `true` to mark root-level types as non-nullable.

:::code language="csharp" source="snippets/schema-exporter/ExportSchema.cs" id="3":::

## Transform the generated schema

To transform generated schema nodes, specify a <xref:System.Text.Json.Schema.JsonSchemaExporterOptions.TransformSchemaNode> delegate. The following example incorporates text from <xref:System.ComponentModel.DescriptionAttribute> annotations into the generated schema.

:::code language="csharp" source="snippets/schema-exporter/TransformSchema.cs" id="1":::

The following code example generates a schema that incorporates `description` keyword source from <xref:System.ComponentModel.DescriptionAttribute> annotations:

:::code language="csharp" source="snippets/schema-exporter/TransformSchema.cs" id="2":::
:::code language="csharp" source="snippets/schema-exporter/TransformSchema.cs" id="Person":::
