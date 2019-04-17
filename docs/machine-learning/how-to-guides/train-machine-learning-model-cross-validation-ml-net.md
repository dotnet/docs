---
title: "How-To: Learn how to train and evaluate a machine learning model using cross validation in ML.NET"
description: Learn how to train and evaluate a machine learning model using cross validation in ML.NET
ms.date: 04/17/2019
author: luisquintanilla
ms.author: luquinta
ms.custom: mvc,how-to
#Customer intent: As a developer, I want to use cross validation to train a machine learning model in ML.NET
---

# How-To: Learn how to train and evaluate a machine learning model using cross validation in ML.NET

Learn how to use cross validation to build more robust machine learning models in ML.NET. Although this sample uses a regression model, it is applicable to other algorithms in ML.NET.

## The data and data model

Given data from a file that has the following format:

```text
Size (Sq. ft.), HistoricalPrice1 ($), HistoricalPrice2 ($), HistoricalPrice3 ($), Current Price ($)
620.00, 148330.32, 140913.81, 136686.39, 146105.37
550.00, 557033.46, 529181.78, 513306.33, 548677.95
1127.00, 479320.99, 455354.94, 441694.30, 472131.18
1120.00, 47504.98, 45129.73, 43775.84, 46792.41
```

The data can be modeled by a class like `HousingData`:

```csharp
public class HousingData
{
    [LoadColumn(0)]
    public float Size { get; set; }
 
    [LoadColumn(1, 3)]
    [VectorType(3)]
    public float[] HistoricalPrices { get; set; }

    [LoadColumn(4)]
    [ColumnName("Label")]
    public float CurrentPrice { get; set; }
}
```

Load the data in into an [`IDataView`](xref:Microsoft.ML.IDataView).

## Prepare the data

Pre-process the data before using it to build the machine learning model. In this sample, the `Size` and `HistoricalPrices` columns are combined into a single feature vector,  which is output to a new column called `Features` using the [`Concatenate`](xref:Microsoft.ML.TransformExtensionsCatalog.Concatenate*) method. Then, [`NormalizeMinMax`](xref:Microsoft.ML.NormalizationCatalog.NormalizeMinMax*) is applied to the `Features` column to get `Size` and `HistoricalPrices` in the same range between 0-1.

```csharp
// Define data prep estimator
IEstimator<ITransformer> dataPrepEstimator = 
    mlContext.Transforms.Concatenate("Features", new string[] { "Size", "HistoricalPrices" })
        .Append(mlContext.Transforms.NormalizeMinMax("Features"));

// Create data prep transformer
ITransformer dataPrepTransformer = dataPrepEstimator.Fit(data);

// Transform data
IDataView transformedData = dataPrepTransformer.Transform(data);
```

## Train model with cross validation

Once the data has been pre-processed, it's time to train the model. First, select the algorithm that most closely aligns with the machine learning task to be performed. Because the predicted value is a numerically continuous value, the task is regression. One of the regression algorithms implemented by ML.NET is the [`StochasticDualCoordinateAscentCoordinator`](xref:Microsoft.ML.Trainers.SdcaRegressionTrainer) algorithm. To train the model with cross-validation use the [`CrossValidate`](xref:Microsoft.ML.RegressionCatalog.CrossValidate*) method.

> [!NOTE]
> CrossValidate is also available for clustering, binary classification and multiclass classification algorithms.

```csharp
// Define StochasticDualCoordinateAscent algorithm estimator
IEstimator<ITransformer> sdcaEstimator = mlContext.Regression.Trainers.Sdca();

// Apply 5-fold cross validation
var cvResults = mlContext.Regression.CrossValidate(transformedData, sdcaEstimator, numberOfFolds: 5);
```

[`CrossValidate`](xref:Microsoft.ML.RegressionCatalog.CrossValidate*) performs the following operations:

1. Partitions the data into a number of partitions equal to the value specified in the `numberOfFolds` parameter. The result of these each partition is a [`TrainTestData`](xref:Microsoft.ML.DataOperationsCatalog.TrainTestData) object.
1. A model is trained on each of the partitions by applying the specified machine learning algorithm estimator to the training data set.
1. Each model's performance is evaluated using the [`Evaluate`](xref:Microsoft.ML.RegressionCatalog.Evaluate*) method on the test data set. 
1. The model along with its metrics are returned for each of the models.

The result stored in `cvResults` is a collection of [`CrossValidationResult`](xref:Microsoft.ML.TrainCatalogBase.CrossValidationResult`1) objects. This object includes the trained model as well as metrics which are both accessible form the [`Model`](xref:Microsoft.ML.TrainCatalogBase.CrossValidationResult`1.Model) and [`Metrics`](xref:Microsoft.ML.TrainCatalogBase.CrossValidationResult`1.Metrics) properties respectively. In this sample, the `Model` property is of type [`ITransformer`](xref:Microsoft.ML.ITransformer) and the `Metrics` property is of type [`RegressionMetrics`](xref:Microsoft.ML.Data.RegressionMetrics). 

## Extract metrics

Metrics for the different trained models can be accessed through the `Metrics` property of the individual [`CrossValidationResult`](xref:Microsoft.ML.TrainCatalogBase.CrossValidationResult`1) object. In this case, the R-Squared metric is being accessed and stored in the variable `rSquared`. 

```csharp
IEnumerable<double> rSquared = 
    cvResults
        .Select(fold => fold.Metrics.RSquared);
```

If you inspect the contents of the `rSquared` variable, the output should be five values ranging from 0-1 where closer to 1 means best.

## Select the best performing model

Using metrics like R-Squared, select the models from best to worst performing. 

```csharp
// Select all models
ITransformer[] models =
    cvResults
        .OrderByDescending(fold => fold.Metrics.RSquared)
        .Select(fold => fold.Model)
        .ToArray();

// Get Top Model
ITransformer topModel = models[0];
```

Then, select the top model to make predictions or perform additional operations with.