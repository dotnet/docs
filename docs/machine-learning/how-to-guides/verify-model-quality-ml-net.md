---
title: Calculate metrics to evaluate machine learning model quality - ML.NET
description: Learn how to calculate metrics to evaluate and verify the machine learning model quality with ML.NET
ms.date: 11/07/2018
ms.custom: mvc,how-to
#Customer intent: As a developer, I want to use the set of metrics of my machine learning task so that I can evaluate and verify machine learning model quality in ML.NET.
---
# Calculate metrics to evaluate machine learning model quality - ML.NET

How do you evaluate quality after you train the model? Each machine learning task exposes metrics for quality evaluation.

You can use the corresponding 'context' of the task to evaluate the model, as in the following example:

```csharp
// Read the test dataset.
var testData = reader.Read(testDataPath);
// Calculate metrics of the model on the test data.
var metrics = mlContext.Regression.Evaluate(model.Transform(testData), label: "Target");
```