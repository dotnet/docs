---
title: Amazon DynamoDB grain persistence
description: Learn about Azure DynamoDB grain persistence in .NET Orleans.
ms.date: 01/31/2022
---

# Amazon DynamoDB grain persistence

In this article, you'll learn how to install and configure the Amazon DynamoDB grain persistence.

## Installation

Install the [`Microsoft.Orleans.Persistence.DynamoDB`](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.DynamoDB) package from NuGet.

## Configuration

Configure the DynamoDB grain persistence provider using the `ISiloBuilder.AddDynamoDBGrainStorage` extension methods.

```csharp
siloBuilder.AddDynamoDBGrainStorage(
    name: "profileStore",
    configureOptions: options =>
    {
        options.UseJson = true;
        options.AccessKey = "<DynamoDB access key>";
        options.SecretKey = "<DynamoDB secret key>";
        options.Service = "<DynamoDB service name>";
    });
```
