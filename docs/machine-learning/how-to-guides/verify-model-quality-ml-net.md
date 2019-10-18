---
title: Calculate metrics to evaluate machine learning model quality 
description: Learn how to calculate metrics to evaluate and verify the machine learning model quality with ML.NET
ms.date: 03/05/2019
ms.custom: mvc,how-to
#Customer intent: As a developer, I want to use the set of metrics of my machine learning task so that I can evaluate and verify machine learning model quality in ML.NET.
---
# Calculate metrics to evaluate machine learning model quality 

> [!NOTE]
> This topic refers to ML.NET, which is currently in Preview, and material may be subject to change. For more information, visit the [ML.NET](https://dotnet.microsoft.com/apps/machinelearning-ai/ml-dotnet) page.

This how-to and related sample are currently using **ML.NET version 0.10**. For more information, see the release notes at the [dotnet/machinelearning GitHub repo](https://github.com/dotnet/machinelearning/tree/master/docs/release-notes).

How do you evaluate quality after you train the model? Each machine learning task exposes metrics for quality evaluation.

You can use the corresponding 'context' of the task to evaluate the model, as in the following example:

```csharp
// Read the test dataset.
var testData = reader.Read(testDataPath);
// Calculate metrics of the model on the test data.
var metrics = mlContext.Regression.Evaluate(model.Transform(testData), label: "Target");
```
