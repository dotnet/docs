---
title: Inspect intermediate data values during ML.NET pipeline processing
description: Learn how to inspect actual intermediate data values during ML.NET machine learning pipeline processing
ms.date: 01/30/2019
ms.custom: mvc,how-to
#Customer intent: As a developer, I want to inspect actual intermediate data values during ML.NET machine learning pipeline processing so that I can make sure that I'm getting the results I expect.
---
# Inspect intermediate data values during ML.NET pipeline processing

During the experiment, you may want to observe and validate the data processing results at a given point. This isn't easy since ML.NET operations are lazy, constructing objects that are 'promises' of data.

The `GetColumn<T>` extension method lets you inspect the intermediate data. It returns the contents of one data column as an `IEnumerable`.

The following example shows how to use the `GetColumn<T>` extension method:

[Example file](https://github.com/dotnet/machinelearning/tree/master/test/data/adult.tiny.with-schema.txt):
```
Label	Workclass	education	marital-status
0	Private	11th	Never-married
0	Private	HS-grad	Married-civ-spouse
1	Local-gov	Assoc-acdm	Married-civ-spouse
1	Private	Some-college	Married-civ-spouse

```

Our class is defined as follows:

```csharp
public class InspectedRow
{
    [LoadColumn(0)]
    public bool IsOver50K { get; set; }
    [LoadColumn(1)]
    public string WorkClass { get; set; }
    [LoadColumn(2)]
    public string Education { get; set; }
    [LoadColumn(3)]
    public string MaritalStatus { get; set; }
}
```

```csharp
// Create a new context for ML.NET operations. It can be used for exception tracking and logging, 
// as a catalog of available operations and as the source of randomness.
var mlContext = new MLContext();

// Read the data into a data view.
var data = mlContext.Data.ReadFromTextFile<InspectedRow>(dataPath, hasHeader: true);

// Start creating our processing pipeline. For now, let's just concatenate all the text columns
// together into one.
var pipeline = mlContext.Transforms.Concatenate("AllFeatures", "WorkClass", "Education", "MaritalStatus");

// Fit our data pipeline and transform data with it.
var transformedData = pipeline.Fit(data).Transform(data);

// Extract the 'AllFeatures' column.
// This will give the entire dataset: make sure to only take several row
// in case the dataset is huge. The is similar to the static API, except
// you have to specify the column name and type.
var featureColumns =
    transformedData
        .GetColumn<string[]>(mlContext, "AllFeatures")
        .Take(20)
        .ToArray();
```
