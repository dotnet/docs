---
title: "Breaking change: .NET 7 obsoletions with default diagnostic ID"
titleSuffix: ""
description: Learn about the .NET 7 breaking change in core .NET libraries where some APIs have been marked as obsolete with the default diagnostic ID.
ms.date: 10/19/2022
---
# API obsoletions with default diagnostic ID (.NET 7)

Several [APIs](#affected-apis) have been marked as obsolete in .NET 7. Referencing these APIs in your code will result in build warnings. In C#, the compiler diagnostic for these obsoletions is [CS0618](../../../../csharp/language-reference/compiler-messages/cs0618.md).

## Previous behavior

Previously, the affected APIs could be referenced without any build warnings.

## New behavior

Starting in .NET 7, referencing the affected APIs will result in build warnings.

## Version introduced

.NET 7 Preview 3

## Type of breaking change

These obsoletions can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

These APIs were previously marked obsolete in the implementation assemblies but not in the [reference assemblies](../../../../standard/assembly/reference-assemblies.md). The reference assemblies have now been updated to match the implementation assemblies.

## Recommended action

Follow the recommended action that's emitted when you use the obsolete API.

## Affected APIs

- <xref:System.ComponentModel.IComNativeDescriptorHandler?displayProperty=fullName>
- <xref:System.ComponentModel.MemberDescriptor.GetInvokee(System.Type,System.Object)?displayProperty=fullName>
- <xref:System.ComponentModel.RecommendedAsConfigurableAttribute?displayProperty=fullName>
- <xref:System.Data.OleDb.OleDbParameterCollection.Add(System.String,System.Object)?displayProperty=fullName>
- <xref:System.Net.FileWebRequest.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.FileWebRequest.System%23Runtime%23Serialization%23ISerializable%23GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.FileWebResponse.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.FileWebResponse.System%23Runtime%23Serialization%23ISerializable%23GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.Http.HttpRequestMessage.Properties?displayProperty=fullName>
- <xref:System.Net.WebRequest.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.WebRequest.System%23Runtime%23Serialization%23ISerializable%23GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.WebResponse.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)> constructor
- <xref:System.Net.WebResponse.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Net.WebResponse.System%23Runtime%23Serialization%23ISerializable%23GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Security.Cryptography.PasswordDeriveBytes.GetBytes(System.Int32)?displayProperty=fullName>
- <xref:System.Web.HttpUtility.UrlEncodeUnicode(System.String)?displayProperty=fullName>
- <xref:System.Web.HttpUtility.UrlEncodeUnicodeToBytes(System.String)?displayProperty=fullName>
