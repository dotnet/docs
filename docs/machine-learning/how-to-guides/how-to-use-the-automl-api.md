---
title: How to use the ML.NET automated ML API
description: The ML.NET automated ML API automates the model building process and generates a model ready for deployment. Learn the options that you can use to configure automated machine learning tasks.
ms.date: 04/24/2019
ms.custom: mvc,how-to
---

# How to use the ML.NET automated machine learning API

Automated machine learning performs feature engineering, trainer selection and hyper-parameter tuning. In this guide, learn how to define various configuration settings, and run the task.

> [!NOTE]
> This topic refers to the automated machine learning API for ML.NET, which are currently in Preview, and material may be subject to change.

## Select your machine learning task type
Before you begin your task, determine the kind of machine learning problem you are solving. Automated machine learning allows you to select among the following supported ML tasks:
* Binary Classification
* Multiclass Classification
* Regression

## Data source and format

Automated machine learning supports loading a dataset into an [IDataView](https://docs.microsoft.com/en-us/dotnet/api/microsoft.ml.idataview?view=ml-dotnet). Data can be in the form of tab-separated value (TSV) files and comma separated value (CSV) files.

Example:

```csharp
using Microsoft.ML;
using Microsoft.ML.AutoML;
    ...
    MLContext mlContext = new MLContext();
    IDataView trainDataView = mlContext.Data.LoadFromTextFile<SentimentIssue>("my-data-file.csv", hasHeader: true);
```

## Configure your experiment settings

In automated ML, an experiment is the process of selecting the optimal algorithm for your machine learning task.

Experiments are highly configurable. See the [AutoML API docs](https://docs.microsoft.com/dotnet/api/microsoft.ml.auto?view=ml-dotnet) for a full list of configuration settings.

Some examples include:

1. Specify the maximum time that the experiment is allowed to run.

    ```csharp
    var experimentSettings = new RegressionExperimentSettings();
    experimentSettings.MaxExperimentTimeInSeconds = 3600;
    ```

1. Use a cancellation token to cancel the experiment before it is scheduled to finish.

    ```csharp
    experimentSettings.CancellationToken = cts.Token;

    // Cancel experiment after the user presses any key
    CancelExperimentAfterAnyKeyPress(cts);
    ```

1. Specify a different optimizing metric.

    ```csharp
    var experimentSettings = new RegressionExperimentSettings();
    experimentSettings.OptimizingMetric = RegressionMetric.MeanSquaredError;
    ```

1. The `CacheDirectory` setting is a pointer to a directory where all models trained during the AutoML task will be saved. If `CacheDirectory` is set to null, models will be kept in memory instead of written to disk.
 
    ```csharp
    experimentSettings.CacheDirectory = null;
    ```

1. Instruct automated ML not to use certain trainers.

    A default list of trainers to optimize are explored per task. This list can be modified for each experiment. Trainers which are operating slowly on your dataset can be removed from the list, or non-default trainers, such as GAM, can be added to focus on explainable models. To optimize on one specific trainer call `experimentSettings.Trainers.Clear()`, the adding the trainers that you want to use. 

    ```csharp
    var experimentSettings = new RegressionExperimentSettings();
    experimentSettings.Trainers.Remove(RegressionTrainer.LbfgsPoissonRegression);
    experimentSettings.Trainers.Remove(RegressionTrainer.OnlineGradientDescent);
    ```

The list of supported trainers per ML task can be found at the corresponding link below:
* [Supported Binary Classification Algorithms](https://docs.microsoft.com/en-us/dotnet/api/microsoft.ml.automl.binaryclassificationtrainer?view=automl-dotnet)
* [Supported Multiclass Classification Algorithms](https://docs.microsoft.com/en-us/dotnet/api/microsoft.ml.automl.multiclassclassificationtrainer?view=automl-dotnet)
* [Supported Regression Algorithms](https://docs.microsoft.com/en-us/dotnet/api/microsoft.ml.automl.regressiontrainer?view=automl-dotnet)

## Optimizing metric

The optimizing metric, as shown in the example above, determines the metric to be optimized during model training. The optimizing metric you can select is determined by the task type you choose. Below is a list of available metrics.

|[Binary Classification](https://docs.microsoft.com/en-us/dotnet/api/microsoft.ml.automl.binaryclassificationmetric?view=automl-dotnet) | [Multiclass Classification](https://docs.microsoft.com/en-us/dotnet/api/microsoft.ml.automl.multiclassclassificationmetric?view=automl-dotnet) | [Regression](https://docs.microsoft.com/en-us/dotnet/api/microsoft.ml.automl.regressionmetric?view=automl-dotnet)
|-- |-- |--
|Accuracy| LogLoss | RSquared
|AreaUnderPrecisionRecallCurve | LogLossReduction | MeanAbsoluteError
|AreaUnderRocCurve | MacroAccuracy | MeanSquaredError
|F1Score | MicroAccuracy | RootMeanSquaredError
|NegativePrecision | TopKAccuracy
|NegativeRecall |
|PositivePrecision
|PositiveRecall

## Data pre-processing and featurization

Data pre-processing happens by default and the following steps are performed automatically for you:

1. Drop features with no useful information

    Drop features with no useful information from training and validation sets. These include features with all values missing, same value across all rows or with extremely high cardinality (e.g., hashes, IDs or GUIDs).

1. Missing value indication and imputation

    Fill missing value cells with the default value for the datatype. Append indicator features with the same number of slots as the input column. The value in the appended indicator features is `1` if the value in the input column is missing and `0` otherwise.

1. Generate additional features
    
    For text features: Bag-of-word features using unigrams and tri-character-grams.
    
    For categorical features: One-hot encoding for low cardinality features, and one-hot-hash encoding for high cardinality categorical features.

1. Transformations and encodings

    Text features with very few unique values transformed into categorical features. Depending on cardinality of categorical features, perform one-hot encoding or one-hot hash encoding.

## Exit criteria

Define the criteria to complete your task:

1. Exit after a length of time - Using `MaxExperimentTimeInSeconds` in your experiment settings you can define how long in seconds that an task should continue to run.

1. Exit on a cancellation token -  You can use a cancellation token that lets you cancel the task before it is scheduled to finish.

    ```csharp
    var cts = new CancellationTokenSource();
    var experimentSettings = new RegressionExperimentSettings();
    experimentSettings.MaxExperimentTimeInSeconds = 3600;
    experimentSettings.CancellationToken = cts.Token;
    ```

## Run task

Once you have set the parameters of the experiment, you are ready to execute the task. Executing triggers data pre-processing, learning algorithm selection and hyperparameter tuning. AutoML will continue to generate combinations of featurization, learning algorithms and hyper-parameters until the `MaxExperimentTimeInSeconds` is reached or the experiment is terminated.

```csharp
ExperimentResult<RegressionMetrics> experimentResult = mlContext.Auto()
    .CreateRegressionExperiment(ExperimentTime)
    .Execute(trainingDataView, LabelColumnName, progressHandler: progressHandler);
```

Explore other overloads for `Execute()` if you want to pass in validation data, column information indicating the column purpose or prefeaturizers.

## Training modes

### Training dataset

AutoML provides an overloaded experiment execute method which allows you to provide training data. Internally, automated ML divides the data into train-validate splits.

```csharp
experiment.Execute(trainDataView);   
```

### Custom validation dataset

Use custom validation dataset if random split is not acceptable, as is usually the case with time series data. You can specify your own validation dataset. The model will be evaluated against the validation dataset specified instead of one or more random datasets.

```csharp
experiment.Execute(trainDataView, validationDataView);   
```

## Explore model metrics

After each iteration of an ML experiment, metrics relating to that task are stored.

For example, we can access validation metrics from the best run:

```csharp
RegressionMetrics metrics = experimentResult.BestRun.ValidationMetrics;
Console.WriteLine($"R-Squared: {metrics.RSquared:0.##}");
Console.WriteLine($"Root Mean Squared Error: {metrics.RootMeanSquaredError:0.##}");
```

The following are all the available metrics per ML task:
* [Binary classification metrics](https://docs.microsoft.com/en-us/dotnet/api/microsoft.ml.automl.binaryclassificationmetric?view=automl-dotnet
)
* [Multiclass classification metrics](https://docs.microsoft.com/en-us/dotnet/api/microsoft.ml.automl.multiclassclassificationmetric?view=automl-dotnet
)
* [Regression metrics](https://docs.microsoft.com/en-us/dotnet/api/microsoft.ml.automl.regressionmetric?view=automl-dotnet
)

## See also

For full code samples and more visit the [dotnet/machinelearning-samples](https://github.com/dotnet/machinelearning-samples/tree/master#automate-mlnet-models-generation-preview-state) GitHub repository.