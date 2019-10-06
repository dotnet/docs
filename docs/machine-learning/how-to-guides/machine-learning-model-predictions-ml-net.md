---
title: Make predictions with a trained model
description: Learn to make predictions using a trained model
ms.date: 09/18/2019
author: luisquintanilla
ms.author: luquinta
ms.custom: mvc, how-to
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

Then, use the [`Predict`](xref:Microsoft.ML.PredictionEngineBase%602.Predict*) method and pass in your input data as a parameter. Notice that using the [`Predict`](xref:Microsoft.ML.PredictionEngineBase%602.Predict*) method does not require the input to be an [`IDataView`](xref:Microsoft.ML.IDataView)). This is because it conveniently internalizes the input data type manipulation so you can pass in an object of the input data type. Additionally, since `CurrentPrice` is the target or label you're trying to predict using new data, it's assumed there is no value for it at the moment.

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

## Multiple predictions

Given the following data, load it into an [`IDataView`](xref:Microsoft.ML.IDataView). In this case, the name of the [`IDataView`](xref:Microsoft.ML.IDataView) is `inputData`. Because `CurrentPrice` is the target or label you're trying to predict using new data, it's assumed there is no value for it at the moment.

```csharp
// Actual data
HousingData[] housingData = new HousingData[]
{
    new HousingData
    {
        Size = 850f,
        HistoricalPrices = new float[] { 150000f,175000f,210000f }
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

Then, use the [`Transform`](xref:Microsoft.ML.ITransformer.Transform*) method to apply the data transformations and generate predictions.

```csharp
// Predicted Data
IDataView predictions = predictionPipeline.Transform(inputData);
```

Inspect the predicted values by using the [`GetColumn`](xref:Microsoft.ML.Data.ColumnCursorExtensions.GetColumn*) method.

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
