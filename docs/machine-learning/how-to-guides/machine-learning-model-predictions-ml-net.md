---
title: Make predictions with a trained model
description: Learn to make predictions using a trained ML.NET model
ms.date: 10/05/2021
author: luisquintanilla
ms.author: luquinta
ms.custom: mvc, how-to
ms.topic: how-to
#Customer intent: As a developer I want to use my model to make predictions
---

# Make predictions with a trained model

Learn how to use a trained model to make predictions

## Create data models

### Input data

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

### Output data

Like the `Features` and `Label` input column names, ML.NET has default names for the predicted value columns produced by a model. Depending on the task the name may differ.

Because the algorithm used in this sample is a linear regression algorithm, the default name of the output column is `Score` which is defined by the [`ColumnName`](xref:Microsoft.ML.Data.ColumnNameAttribute) attribute on the `PredictedPrice` property.

```csharp
class HousingPrediction
{
    [ColumnName("Score")]
    public float PredictedPrice { get; set; }
}
```

## Set up a prediction pipeline

Whether making a single or batch prediction, the prediction pipeline needs to be loaded into the application. This pipeline contains both the data pre-processing transformations as well as the trained model. The code snippet below loads the prediction pipeline from a file named `model.zip`.

```csharp
//Create MLContext
MLContext mlContext = new MLContext();

// Load Trained Model
DataViewSchema predictionPipelineSchema;
ITransformer predictionPipeline = mlContext.Model.Load("model.zip", out predictionPipelineSchema);
```

## Single prediction

To make a single prediction, create a [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) using the loaded prediction pipeline.

```csharp
// Create PredictionEngines
PredictionEngine<HousingData, HousingPrediction> predictionEngine = mlContext.Model.CreatePredictionEngine<HousingData, HousingPrediction>(predictionPipeline);
```

Then, use the [`Predict`](xref:Microsoft.ML.PredictionEngineBase%602.Predict%2A) method and pass in your input data as a parameter. Notice that using the [`Predict`](xref:Microsoft.ML.PredictionEngineBase%602.Predict%2A) method does not require the input to be an [`IDataView`](xref:Microsoft.ML.IDataView)). This is because it conveniently internalizes the input data type manipulation so you can pass in an object of the input data type. Additionally, since `CurrentPrice` is the target or label you're trying to predict using new data, it's assumed there is no value for it at the moment.

```csharp
// Input Data
HousingData inputData = new HousingData
{
    Size = 900f,
    HistoricalPrices = new float[] { 155000f, 190000f, 220000f }
};

// Get Prediction
HousingPrediction prediction = predictionEngine.Predict(inputData);
```

If you access the `Score` property of the `prediction` object, you should get a value similar to `150079`.

> [!TIP]
> [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) is not thread-safe. Additionally, you have to create an instance of it everywhere it is needed within your application. As your application grows, this process can become unmanageable. For improved performance and thread safety, use a combination of dependency injection and the [PredictionEnginePool](xref:Microsoft.Extensions.ML.PredictionEnginePool%602) service, which creates an [`ObjectPool`](xref:Microsoft.Extensions.ObjectPool.ObjectPool%601) of [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) objects for use throughout your application.
>
> For examples on how to use the [PredictionEnginePool](xref:Microsoft.Extensions.ML.PredictionEnginePool%602) service, see [deploy a model to a web API](serve-model-web-api-ml-net.md) and [deploy a model to Azure Functions](serve-model-serverless-azure-functions-ml-net.md).
>
> See [dependency injection in ASP.NET Core](/aspnet/core/fundamentals/dependency-injection) for more information.

## Multiple predictions (IDataView)

Given the following data, load it into an [`IDataView`](xref:Microsoft.ML.IDataView). In this case, the name of the [`IDataView`](xref:Microsoft.ML.IDataView) is `inputData`. Because `CurrentPrice` is the target or label you're trying to predict using new data, it's assumed there is no value for it at the moment.

```csharp
// Actual data
HousingData[] housingData = new HousingData[]
{
    new HousingData
    {
        Size = 850f,
        HistoricalPrices = new float[] { 150000f, 175000f, 210000f }
    },
    new HousingData
    {
        Size = 900f,
        HistoricalPrices = new float[] { 155000f, 190000f, 220000f }
    },
    new HousingData
    {
        Size = 550f,
        HistoricalPrices = new float[] { 99000f, 98000f, 130000f }
    }
};
```

Then, use the [`Transform`](xref:Microsoft.ML.ITransformer.Transform%2A) method to apply the data transformations and generate predictions.

```csharp
// Predicted Data
IDataView predictions = predictionPipeline.Transform(inputData);
```

Inspect the predicted values by using the [`GetColumn`](xref:Microsoft.ML.Data.ColumnCursorExtensions.GetColumn%2A) method.

```csharp
// Get Predictions
float[] scoreColumn = predictions.GetColumn<float>("Score").ToArray();
```

The predicted values in the score column should look like the following:

| Observation | Prediction |
|---|---|
| 1 | 144638.2 |
| 2 | 150079.4 |
| 3 | 107789.8 |

## Multiple predictions (PredictionEnginePool)

To make multiple predictions using [PredictionEnginePool](xref:Microsoft.Extensions.ML.PredictionEnginePool%602), you can take an `IEnumerable` containing multiple instances of your model input. For example an `IEnumerable<HousingInput>` and apply the [`Predict`](xref:Microsoft.Extensions.ML.PredictionEnginePoolExtensions.Predict%2A) method to each element using LINQ's [`Select`](xref:System.Linq.Enumerable.Select%2A) method.

This code sample assumes you have a [PredictionEnginePool](xref:Microsoft.Extensions.ML.PredictionEnginePool%602) called `predictionEnginePool` and an `IEnumerable<HousingData>` called `housingData`.

```csharp
IEnumerable<HousingPrediction> predictions = housingData.Select(input => predictionEnginePool.Predict(input));
```

The result is an `IEnumerable` containing instances of your predictions. In this case, it would be `IEnumerable<HousingPrediction>`.
