---
title: Preprocess training data with normalizers to use in data processing - ML.NET
description: Learn how to use normalizers to preprocess training data for use in machine learning model building, training, and scoring with ML.NET
ms.date: 11/07/2018
ms.topic: how-to
ms.custom: mvc
#Customer intent: As a developer, I want to use normalizers to preprocess training data so that I can optimize it in machine learning model building, training, and scoring with ML.NET.
---
# Preprocess training data with normalizers to use in data processing - ML.NET

ML.NET exposes a number of [parametric and non-parametric algorithms](https://machinelearningmastery.com/parametric-and-nonparametric-machine-learning-algorithms/).

It's **not** as important which normalizer you choose as it is to **use** a normalizer when training linear or other parametric models.

Always include the normalizer directly in the ML.NET learning pipeline, so it:

- is only trained on the training data, and not on your test data,
- is correctly applied to all the new incoming data, without the need for extra pre-processing at prediction time.

Here's a snippet of code that demonstrates normalization in learning pipelines. It assumes the Iris dataset:

```csharp
// Create a new context for ML.NET operations. It can be used for exception tracking and logging, 
// as a catalog of available operations and as the source of randomness.
var mlContext = new MLContext();

// Define the reader: specify the data columns and where to find them in the text file.
var reader = mlContext.Data.TextReader(new TextLoader.Arguments
{
    Column = new[] {
        // The four features of the Iris dataset will be grouped together as one Features column.
        new TextLoader.Column("Features", DataKind.R4, 0, 3),
        // Label: kind of iris.
        new TextLoader.Column("Label", DataKind.TX, 4),
    },
    // Default separator is tab, but the dataset has comma.
    Separator = ","
});

// Read the training data.
var trainData = reader.Read(dataPath);

// Apply all kinds of standard ML.NET normalization to the raw features.
var pipeline =
    mlContext.Transforms.Normalize(
        new NormalizingEstimator.MinMaxColumn("Features", "MinMaxNormalized", fixZero: true),
        new NormalizingEstimator.MeanVarColumn("Features", "MeanVarNormalized", fixZero: true),
        new NormalizingEstimator.BinningColumn("Features", "BinNormalized", numBins: 256));

// Let's train our pipeline of normalizers, and then apply it to the same data.
var normalizedData = pipeline.Fit(trainData).Transform(trainData);

// Inspect one column of the resulting dataset.
var meanVarValues = normalizedData.GetColumn<float[]>(mlContext, "MeanVarNormalized").ToArray();
```
