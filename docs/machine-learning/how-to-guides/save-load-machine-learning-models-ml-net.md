---
title: Save and load trained models
description: Learn how to save and load trained models
ms.date: 12/15/2021
author: luisquintanilla
ms.author: luquinta
ms.custom: mvc, how-to
ms.topic: how-to
#Customer intent: As a developer, I want to use ML.NET to consume my trained and evaluated machine learning model in my applications.
---

# Save and load trained models

Learn how to save and load trained models in your application.

Throughout the model building process, a model lives in memory and is accessible throughout the application's lifecycle. However, once the application stops running, if the model is not saved somewhere locally or remotely, it's no longer accessible. Typically models are used at some point after training in other applications either for inference or re-training. Therefore, it's important to store the model. Save and load models using the steps described in subsequent sections of this document when using data preparation and model training pipelines like the one detailed below. Although this sample uses a linear regression model, the same process applies to other ML.NET algorithms.

```csharp
HousingData[] housingData = new HousingData[]
{
    new HousingData
    {
        Size = 600f,
        HistoricalPrices = new float[] { 100000f, 125000f, 122000f },
        CurrentPrice = 170000f
    },
    new HousingData
    {
        Size = 1000f,
        HistoricalPrices = new float[] { 200000f, 250000f, 230000f },
        CurrentPrice = 225000f
    },
    new HousingData
    {
        Size = 1000f,
        HistoricalPrices = new float[] { 126000f, 130000f, 200000f },
        CurrentPrice = 195000f
    }
};

// Create MLContext
MLContext mlContext = new MLContext();

// Load Data
IDataView data = mlContext.Data.LoadFromEnumerable<HousingData>(housingData);

// Define data preparation estimator
EstimatorChain<RegressionPredictionTransformer<LinearRegressionModelParameters>> pipelineEstimator =
    mlContext.Transforms.Concatenate("Features", new string[] { "Size", "HistoricalPrices" })
        .Append(mlContext.Transforms.NormalizeMinMax("Features"))
        .Append(mlContext.Regression.Trainers.Sdca());

// Train model
ITransformer trainedModel = pipelineEstimator.Fit(data);

// Save model
mlContext.Model.Save(trainedModel, data.Schema, "model.zip");
```

Because most models and data preparation pipelines inherit from the same set of classes, the save and load method signatures for these components is the same. Depending on your use case, you can either combine the data preparation pipeline and model into a single [`EstimatorChain`](xref:Microsoft.ML.Data.TransformerChain%601) which would output a single [`ITransformer`](xref:Microsoft.ML.ITransformer) or separate them thus creating a separate [`ITransformer`](xref:Microsoft.ML.ITransformer) for each.

## Save a model locally

When saving a model you need two things:

1. The [`ITransformer`](xref:Microsoft.ML.ITransformer) of the model.
2. The [`DataViewSchema`](xref:Microsoft.ML.DataViewSchema) of the [`ITransformer`](xref:Microsoft.ML.ITransformer)'s expected input.

After training the model, use the [`Save`](xref:Microsoft.ML.ModelOperationsCatalog.Save%2A) method to save the trained model to a file called `model.zip` using the `DataViewSchema` of the input data.

```csharp
// Save Trained Model
mlContext.Model.Save(trainedModel, data.Schema, "model.zip");
```

## Save an ONNX model locally

To save an ONNX version of your model locally you will need the **Microsoft.ML.OnnxConverter** NuGet package installed.

With the `OnnxConverter` package installed, we can use it to save our model into the ONNX format. This requires a `Stream` object which we can provide as a `FileStream` using the `File.Create` method. The `File.Create` method takes in a string as a parameter which will be the path of the ONNX model.

```csharp
using FileStream stream = File.Create("./onnx_model.onnx");
```

With the stream created, we can call the `mlContext.Model.ConvertToOnnx` method and give it the trained model, the data used to train the model, and the stream.

```csharp
mlContext.Model.ConvertToOnnx(trainedModel, data, stream);
```

## Load a model stored locally

Models stored locally can be used in other processes or applications like `ASP.NET Core` and `Serverless Web Applications`. See [Use ML.NET in Web API](./serve-model-web-api-ml-net.md) and [Deploy ML.NET Serverless Web App](./serve-model-serverless-azure-functions-ml-net.md) how-to articles to learn more.

In a separate application or process, use the [`Load`](xref:Microsoft.ML.ModelOperationsCatalog.Load%2A) method along with the file path to get the trained model into your application.

```csharp
//Define DataViewSchema for data preparation pipeline and trained model
DataViewSchema modelSchema;

// Load trained model
ITransformer trainedModel = mlContext.Model.Load("model.zip", out modelSchema);
```

## Load an ONNX model locally

To load in an ONNX model for predictions, you will need the **Microsoft.ML.OnnxTransformer** NuGet package.

With the `OnnxTransformer` package installed, we can use it to load in an existing ONNX model. This is done using the `mlContext.Transforms.ApplyOnnxModel` method. And the parameter required is a string which is the path of the local ONNX model.

```csharp
OnnxScoringEstimator estimator = mlContext.Transforms.ApplyOnnxModel("./onnx_model.onnx");
```

The `ApplyOnnxModel` method returns an `OnnxScoringEstimator` object. First, we need to load in the new data.

```csharp
HousingData[] newHousingData = new HousingData[]
{
    new()
    {
        Size = 1000f,
        HistoricalPrices = new[] { 300_000f, 350_000f, 450_000f },
        CurrentPrice = 550_00f
    }
};
```

With the new data we can load that into an `IDataView` using the `LoadFromEnumerable` method.

```csharp
IDataView newHousingDataView = mlContext.Data.LoadFromEnumerable(newHousingData);
```

Now, we can use the new `IDataView` to fit on the new data.

```csharp
estimator.Fit(newHousingDataView);
```

## Load a model stored remotely

To load data preparation pipelines and models stored in a remote location into your application, use a [`Stream`](xref:System.IO.Stream) instead of a file path in the [`Load`](xref:Microsoft.ML.ModelOperationsCatalog.Load%2A) method.

```csharp
// Create MLContext
MLContext mlContext = new MLContext();

// Define DataViewSchema and ITransformers
DataViewSchema modelSchema;
ITransformer trainedModel;

// Load data prep pipeline and trained model
using (HttpClient client = new HttpClient())
{
    Stream modelFile = await client.GetStreamAsync("<YOUR-REMOTE-FILE-LOCATION>");

    trainedModel = mlContext.Model.Load(modelFile, out modelSchema);
}
```

## Working with separate data preparation and model pipelines

> [!NOTE]
> Working with separate data preparation and model training pipelines is optional. Separation of pipelines makes it easier to inspect the learned model parameters. For predictions, it's easier to save and load a single pipeline that includes the data preparation and model training operations.

When working with separate data preparation pipelines and models, the same process as single pipelines applies; except now both pipelines need to be saved and loaded simultaneously.

Given separate data preparation and model training pipelines:

```csharp
// Define data preparation estimator
IEstimator<ITransformer> dataPrepEstimator =
    mlContext.Transforms.Concatenate("Features", new string[] { "Size", "HistoricalPrices" })
        .Append(mlContext.Transforms.NormalizeMinMax("Features"));

// Create data preparation transformer
ITransformer dataPrepTransformer = dataPrepEstimator.Fit(data);

// Define StochasticDualCoordinateAscent regression algorithm estimator
var sdcaEstimator = mlContext.Regression.Trainers.Sdca();

// Pre-process data using data prep operations
IDataView transformedData = dataPrepTransformer.Transform(data);

// Train regression model
RegressionPredictionTransformer<LinearRegressionModelParameters> trainedModel = sdcaEstimator.Fit(transformedData);
```

### Save data preparation pipeline and trained model

To save both the data preparation pipeline and trained model, use the following commands:

```csharp
// Save Data Prep transformer
mlContext.Model.Save(dataPrepTransformer, data.Schema, "data_preparation_pipeline.zip");

// Save Trained Model
mlContext.Model.Save(trainedModel, transformedData.Schema, "model.zip");
```

### Load data preparation pipeline and trained model

In a separate process or application, load the data preparation pipeline and trained model simultaneously as follows:

```csharp
// Create MLContext
MLContext mlContext = new MLContext();

// Define data preparation and trained model schemas
DataViewSchema dataPrepPipelineSchema, modelSchema;

// Load data preparation pipeline and trained model
ITransformer dataPrepPipeline = mlContext.Model.Load("data_preparation_pipeline.zip",out dataPrepPipelineSchema);
ITransformer trainedModel = mlContext.Model.Load("model.zip", out modelSchema);
```
