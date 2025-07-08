---
title: Retrain a model
description: Learn how to retrain a model in ML.NET
ms.date: 11/02/2021
author: luisquintanilla
ms.author: luquinta
ms.custom: mvc, how-to
ms.topic: how-to
#Customer intent: As a developer, I want to retrain a model using existing model parameters.
---

# Retrain a model

Learn how to retrain a machine learning model in ML.NET.

The world and its data change constantly. As such, models need to change and update as well. ML.NET provides functionality for retraining models using learned model parameters as a starting point to continually build on previous experience rather than starting from scratch every time.

The following algorithms are retrainable in ML.NET:

- [AveragedPerceptronTrainer](xref:Microsoft.ML.Trainers.AveragedPerceptronTrainer)
- [FieldAwareFactorizationMachineTrainer](xref:Microsoft.ML.Trainers.FieldAwareFactorizationMachineTrainer)
- [LbfgsLogisticRegressionBinaryTrainer](xref:Microsoft.ML.Trainers.LbfgsLogisticRegressionBinaryTrainer)
- [LbfgsMaximumEntropyMulticlassTrainer](xref:Microsoft.ML.Trainers.LbfgsMaximumEntropyMulticlassTrainer)
- [LbfgsPoissonRegressionTrainer](xref:Microsoft.ML.Trainers.LbfgsPoissonRegressionTrainer)
- [LinearSvmTrainer](xref:Microsoft.ML.Trainers.LinearSvmTrainer)
- [OnlineGradientDescentTrainer](xref:Microsoft.ML.Trainers.OnlineGradientDescentTrainer)
- [SgdCalibratedTrainer](xref:Microsoft.ML.Trainers.SgdCalibratedTrainer)
- [SgdNonCalibratedTrainer](xref:Microsoft.ML.Trainers.SgdNonCalibratedTrainer)
- [SymbolicSgdLogisticRegressionBinaryTrainer](xref:Microsoft.ML.Trainers.SymbolicSgdLogisticRegressionBinaryTrainer)

## Load pretrained model

First, load the pretrained model into your application. To learn more about loading training pipelines and models, see [Save and load a trained model](save-load-machine-learning-models-ml-net.md).

```csharp
// Create MLContext
MLContext mlContext = new MLContext();

// Define DataViewSchema of data prep pipeline and trained model
DataViewSchema dataPrepPipelineSchema, modelSchema;

// Load data preparation pipeline
ITransformer dataPrepPipeline = mlContext.Model.Load("data_preparation_pipeline.zip", out dataPrepPipelineSchema);

// Load trained model
ITransformer trainedModel = mlContext.Model.Load("ogd_model.zip", out modelSchema);
```

## Extract pretrained model parameters

Once the model is loaded, extract the learned model parameters by accessing the [`Model`](xref:Microsoft.ML.Data.PredictionTransformerBase%601.Model%2A) property of the pretrained model. The pretrained model was trained using the linear regression model [`OnlineGradientDescentTrainer`](xref:Microsoft.ML.Trainers.OnlineGradientDescentTrainer), which creates a [`RegressionPredictionTransformer`](xref:Microsoft.ML.Data.RegressionPredictionTransformer%601) that outputs [`LinearRegressionModelParameters`](xref:Microsoft.ML.Trainers.LinearRegressionModelParameters). These model parameters contain the learned bias and weights or coefficients of the model. These values are used as a starting point for the new retrained model.

```csharp
// Extract trained model parameters
LinearRegressionModelParameters originalModelParameters =
    ((ISingleFeaturePredictionTransformer<object>)trainedModel).Model as LinearRegressionModelParameters;
```

> [!NOTE]
> The model parameters output depend on the algorithm used. For example [`OnlineGradientDescentTrainer`](xref:Microsoft.ML.Trainers.OnlineGradientDescentTrainer) uses [`LinearRegressionModelParameters`](xref:Microsoft.ML.Trainers.LinearRegressionModelParameters), while [LbfgsMaximumEntropyMulticlassTrainer](xref:Microsoft.ML.Trainers.LbfgsMaximumEntropyMulticlassTrainer) outputs [`MaximumEntropyModelParameters`](xref:Microsoft.ML.Trainers.MaximumEntropyModelParameters). When extracting model parameters, cast to the appropriate type.

## Retrain a model

The process for retraining a model is no different than that of training a model. The only difference is that you pass an additional argument to the <xref:Microsoft.ML.Trainers.OnlineLinearTrainer`2.Fit(Microsoft.ML.IDataView,Microsoft.ML.Trainers.LinearModelParameters)> method: the original learned model parameters. `Fit()` uses them as a starting point in the retraining process.

```csharp
// New Data
HousingData[] housingData = new HousingData[]
{
    new HousingData
    {
        Size = 850f,
        HistoricalPrices = new float[] { 150000f,175000f,210000f },
        CurrentPrice = 205000f
    },
    new HousingData
    {
        Size = 900f,
        HistoricalPrices = new float[] { 155000f, 190000f, 220000f },
        CurrentPrice = 210000f
    },
    new HousingData
    {
        Size = 550f,
        HistoricalPrices = new float[] { 99000f, 98000f, 130000f },
        CurrentPrice = 180000f
    }
};

//Load New Data
IDataView newData = mlContext.Data.LoadFromEnumerable<HousingData>(housingData);

// Preprocess Data
IDataView transformedNewData = dataPrepPipeline.Transform(newData);

// Retrain model
RegressionPredictionTransformer<LinearRegressionModelParameters> retrainedModel =
    mlContext.Regression.Trainers.OnlineGradientDescent()
        .Fit(transformedNewData, originalModelParameters);
```

At this point, you can save your retrained model and use it in your application. For more information, see [Save and load a trained model](save-load-machine-learning-models-ml-net.md) and [Make predictions with a trained model](machine-learning-model-predictions-ml-net.md).

## Compare model parameters

How do you know if retraining actually happened? One way is to compare whether the retrained model's parameters are different than those of the original model. The following code sample compares the original against the retrained model weights and outputs them to the console.

```csharp
// Extract Model Parameters of re-trained model
LinearRegressionModelParameters retrainedModelParameters = retrainedModel.Model as LinearRegressionModelParameters;

// Inspect Change in Weights
var weightDiffs =
    originalModelParameters.Weights.Zip(
        retrainedModelParameters.Weights, (original, retrained) => original - retrained).ToArray();

Console.WriteLine("Original | Retrained | Difference");
for(int i=0;i < weightDiffs.Count();i++)
{
    Console.WriteLine($"{originalModelParameters.Weights[i]} | {retrainedModelParameters.Weights[i]} | {weightDiffs[i]}");
}
```

The following table shows what the output might look like.

| Original | Retrained | Difference |
|----------|-----------|------------|
| 33039.86 | 56293.76  | -23253.9   |
| 29099.14 | 49586.03  | -20486.89  |
| 28938.38 | 48609.23  | -19670.85  |
| 30484.02 | 53745.43  | -23261.41  |
