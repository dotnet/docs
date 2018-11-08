---
title: Train a machine learning model with data that's not in a text file - ML.NET 
description: Discover how to use ML.NET to load non-file training data for machine learning model training as part of the prediction pipeline.
ms.date: 11/07/2018
ms.topic: how-to
ms.custom: mvc
#Customer intent: As a developer, I want to use ML.NET to train a machine learning model with data that's not in a text file as part of the prediction pipeline for later use in my applications.
---
# Train a machine learning model with data that's not in a text file - ML.NET

The commonly demonstrated use case for ML.NET is use the `TextLoader` to read the training data from a file.
However, in real-time training scenarios the data can be elsewhere, such as:

* in SQL tables
* extracted from log files
* generated on the fly

Use [schema comprehension](https://github.com/dotnet/machinelearning/tree/master/docs/code/SchemaComprehension.md) to bring an existing C# `IEnumerable` into ML.NET as a `DataView`.

For this example, you'll build the customer churn prediction model, and extract the following features from your production system:

* Customer ID (ignored by the model)
* Whether the customer has churned (the target 'label')
* The 'demographic category' (one string, like 'young adult' etc.)
* The number of visits from the last 5 days.

```csharp
private class CustomerChurnInfo
{
    public string CustomerID { get; set; }
    public bool HasChurned { get; set; }
    public string DemographicCategory { get; set; }
    // Visits during last 5 days, latest to newest.
    [VectorType(5)]
    public float[] LastVisits { get; set; }
}
```

Load this data into the `DataView` and train the model, using the following code:

```csharp
// Create a new context for ML.NET operations. It can be used for exception tracking and logging,
// as a catalog of available operations and as the source of randomness.
var mlContext = new MLContext();

// Step one: read the data as an IDataView.
// Let's assume that 'GetChurnData()' fetches and returns the training data from somewhere.
IEnumerable<CustomerChurnInfo> churnData = GetChurnInfo();

// Turn the data into the ML.NET data view.
// We can use CreateDataView or CreateStreamingDataView, depending on whether 'churnData' is an IList,
// or merely an IEnumerable.
var trainData = mlContext.CreateStreamingDataView(churnData);

// Build the learning pipeline.
// In our case, we will one-hot encode the demographic category, and concatenate that with the number of visits.
// We apply our FastTree binary classifier to predict the 'HasChurned' label.

var pipeline = mlContext.Transforms.Categorical.OneHotEncoding("DemographicCategory")
    .Append(mlContext.Transforms.Concatenate("Features", "DemographicCategory", "LastVisits"))
    .Append(mlContext.BinaryClassification.Trainers.FastTree("HasChurned", "Features", numTrees: 20));

var model = pipeline.Fit(trainData);
```
