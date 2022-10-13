---
title: "Breaking change: Endpoint metadata provider interface changes"
description: Learn about the breaking change in ASP.NET Core 7.0 where changes were made to the IEndpointMetadataProvider and IEndpointParameterMetadataProvider interfaces.
ms.date: 10/10/2022
---
# Endpoint metadata provider interface changes

The <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointMetadataProvider> and <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointParameterMetadataProvider> interfaces introduced in .NET 7 Preview 4 have been updated to take an <xref:Microsoft.AspNetCore.Builder.EndpointBuilder> rather than an <xref:Microsoft.AspNetCore.Http.Metadata.EndpointMetadataContext> or <xref:Microsoft.AspNetCore.Http.Metadata.EndpointParameterMetadataContext>.

## Version introduced

ASP.NET Core 7.0 RC 2

## Previous behavior

The `PopulateMetadata()` methods on both the <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointMetadataProvider> and <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointParameterMetadataProvider> interfaces took their respective context arguments as a single parameter. Both contexts included services (<xref:System.IServiceProvider>) and endpoint metadata (`IList<object>`).

<xref:Microsoft.AspNetCore.Http.Metadata.EndpointMetadataContext> included the <xref:System.Reflection.MethodInfo> for the minimal route handler MVC action that took the implementing type as a parameter or returned it. <xref:Microsoft.AspNetCore.Http.Metadata.EndpointParameterMetadataContext> provided <xref:System.Reflection.ParameterInfo> and could only be used on parameter types.

## New behavior

The `PopulateMetadata()` methods on both the <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointMetadataProvider> and <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointParameterMetadataProvider> interfaces take an <xref:Microsoft.AspNetCore.Builder.EndpointBuilder> as their second parameter. The `EndpointBuilder` provides access to the application services (<xref:System.IServiceProvider>) and endpoint metadata (`IList<object>`) previously provided by <xref:Microsoft.AspNetCore.Http.Metadata.EndpointMetadataContext> and <xref:Microsoft.AspNetCore.Http.Metadata.EndpointParameterMetadataContext>.

<xref:Microsoft.AspNetCore.Http.Metadata.IEndpointMetadataProvider> takes a <xref:System.Reflection.MethodInfo> and <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointParameterMetadataProvider> takes a <xref:System.Reflection.ParameterInfo> as the first parameter.

<xref:Microsoft.AspNetCore.Http.Metadata.EndpointMetadataContext> and <xref:Microsoft.AspNetCore.Http.Metadata.EndpointParameterMetadataContext> have been removed.

## Type of breaking change

This change affects [binary compatibility](../../categories.md#binary-compatibility) and [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The metadata providers now get access to more metadata like the `RoutePattern` (with a downcast) and `DisplayName` via the `EndpointBuilder`, and this allowed us to delete unnecessary context types.

## Recommended action

Update implementations of <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointMetadataProvider> and <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointParameterMetadataProvider> to access the necessary information from the new parameters. Everything that was previously available via the contexts is now available via the new parameters of `PopulateMetadata()`.

## Affected APIs

The parameters on the following two methods changed:

- <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointMetadataProvider.PopulateMetadata(Microsoft.AspNetCore.Http.Metadata.EndpointMetadataContext)?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointParameterMetadataProvider.PopulateMetadata(Microsoft.AspNetCore.Http.Metadata.EndpointParameterMetadataContext)?displayProperty=fullName>

The following two types were removed:

- <xref:Microsoft.AspNetCore.Http.Metadata.EndpointMetadataContext?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Http.Metadata.EndpointParameterMetadataContext?displayProperty=fullName>
