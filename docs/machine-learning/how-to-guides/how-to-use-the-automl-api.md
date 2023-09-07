---
title: How to use the ML.NET Automated ML (AutoML) API
description: The ML.NET Automated ML (AutoML) API automates the model building process and generates a model ready for deployment. Learn the options that you can use to configure automated machine learning tasks.
ms.date: 12/06/2022
ms.custom: mvc,how-to
ms.topic: how-to
---

# How to use the ML.NET Automated Machine Learning (AutoML) API

In this article, you learn how to use the ML.NET Automated ML (AutoML API).

Samples for the AutoML API can be found in the [dotnet/machinelearning-samples](https://aka.ms/mlnet-2-samples) repo.

## Installation

To use the AutoML API, install the [`Microsoft.ML.AutoML`](https://www.nuget.org/packages/Microsoft.ML.AutoML) NuGet package in the .NET project you want to reference it in.

> [!NOTE]
> This guide uses version 0.20.0 and later of the `Microsoft.ML.AutoML` NuGet package. Although samples and code from earlier versions still work, it is highly recommended you use the APIs introduced in this version for new projects.

For more information on installing NuGet packages, see the following guides:

- [Install and use a NuGet package in Visual Studio](/nuget/quickstart/install-and-use-a-package-in-visual-studio)
- [Install and use a package in Visual Studio for Mac](/nuget/quickstart/install-and-use-a-package-in-visual-studio-mac)
- [Install and use a package (dotnet CLI)](/nuget/quickstart/install-and-use-a-package-using-the-dotnet-cli)

## Quick Start

AutoML provides several defaults for quickly training machine learning models. In this section you'll learn how to:

- Load your data
- Define your pipeline
- Configure your experiment
- Run your experiment
- Use the best model to make predictions

### Define your problem

Given a dataset stored in a comma-separated file called *taxi-fare-train.csv* that looks like the following:  

| vendor_id | rate_code | passenger_count | trip_time_in_secs | trip_distance|payment_type | fare_amount |
|---|---|---|---|---|---|---|
CMT|1|1|1271|3.8|CRD|17.5
CMT|1|1|474|1.5|CRD|8
CMT|1|1|637|1.4|CRD|8.5

### Load your data

Start by initializing your <xref:Microsoft.ML.MLContext>. `MLContext` is a starting point for all ML.NET operations. Initializing mlContext creates a new ML.NET environment that can be shared across the model creation workflow objects. It's similar, conceptually, to `DBContext` in Entity Framework.

Then, to load your data, use the <xref:Microsoft.ML.AutoML.AutoCatalog.InferColumns%2A> method.

```csharp
// Initialize MLContext
MLContext ctx = new MLContext();

// Define data path
var dataPath = Path.GetFullPath(@"..\..\..\..\Data\taxi-fare-train.csv");

// Infer column information
ColumnInferenceResults columnInference =
    ctx.Auto().InferColumns(dataPath, labelColumnName: "fare_amount", groupColumns: false);
```

<xref:Microsoft.ML.AutoML.AutoCatalog.InferColumns%2A> loads a few rows from the dataset. It then inspects the data and tries to guess or infer the data type for each of the columns based on their content.

The default behavior is to group columns of the same type into feature vectors or arrays containing the elements for each of the individual columns. Setting `groupColumns` to `false` overrides that default behavior and only performs column inference without grouping columns. By keeping columns separate, it allows you to apply different data transformations when preprocessing the data at the individual column level rather than the column grouping.  

The result of <xref:Microsoft.ML.AutoML.AutoCatalog.InferColumns%2A> is a <xref:Microsoft.ML.AutoML.ColumnInferenceResults> object that contains the options needed to create a <xref:Microsoft.ML.Data.TextLoader> as well as column information.

For the sample dataset in *taxi-fare-train.csv*, column information might look like the following:

- **LabelColumnName**: fare_amount
- **CategoricalColumnNames**: vendor_id, payment_type
- **NumericColumnNames**: rate_code, passenger_count, trip_time_in_secs, trip_distance

Once you have your column information, use the <xref:Microsoft.ML.Data.TextLoader.Options> defined by the <xref:Microsoft.ML.AutoML.ColumnInferenceResults> to create a <xref:Microsoft.ML.Data.TextLoader> to load your data into an <xref:Microsoft.ML.IDataView>.

```csharp
// Create text loader
TextLoader loader = ctx.Data.CreateTextLoader(columnInference.TextLoaderOptions);

// Load data into IDataView
IDataView data = loader.Load(dataPath);
```

It's often good practice to split your data into train and validation sets. Use <xref:Microsoft.ML.DataOperationsCatalog.TrainTestSplit%2A> to create an 80% training and 20% validation split of your dataset.

```csharp
TrainTestData trainValidationData = ctx.Data.TrainTestSplit(data, testFraction: 0.2);
```

### Define your pipeline

Your pipeline defines the data processing steps and machine learning pipeline to use for training your model.

```csharp
SweepablePipeline pipeline =
    ctx.Auto().Featurizer(data, columnInformation: columnInference.ColumnInformation)
        .Append(ctx.Auto().Regression(labelColumnName: columnInference.ColumnInformation.LabelColumnName));
```

A <xref:Microsoft.ML.AutoML.SweepablePipeline> is a collection of <xref:Microsoft.ML.AutoML.SweepableEstimator>. A <xref:Microsoft.ML.AutoML.SweepableEstimator> is an ML.NET <xref:Microsoft.ML.AutoML.Estimator> with a <xref:Microsoft.ML.SearchSpace.SearchSpace>.

The <xref:Microsoft.ML.AutoML.AutoCatalog.Featurizer%2A> is a convenience API that builds a sweepable pipeline of data processing sweepable estimators based on the column information you provide. Instead of building a pipeline from scratch, <xref:Microsoft.ML.AutoML.AutoCatalog.Featurizer%2A> automates the data preprocessing step. For more information on supported transforms by ML.NET, see the [data transformations guide](../resources/transforms.md).

The <xref:Microsoft.ML.AutoML.AutoCatalog.Featurizer%2A> output is a single column containing a numerical feature vector representing the transformed data for each of the columns. This feature vector is then used as input for the algorithms used to train a machine learning model.

If you want finer control over your data preprocessing, you can create a pipeline with each of the individual preprocessing steps. For more information, see the [prepare data for building a model guide](prepare-data-ml-net.md).

> [!TIP]
> Use <xref:Microsoft.ML.AutoML.AutoCatalog.Featurizer%2A> with <xref:Microsoft.ML.AutoML.ColumnInferenceResults> to maximize the utility of AutoML.

For training, AutoML provides a sweepable pipeline with default trainers and search space configurations for the following machine learning tasks:

- <xref:Microsoft.ML.AutoML.AutoCatalog.BinaryClassification%2A>
- <xref:Microsoft.ML.AutoML.AutoCatalog.MultiClassification%2A>
- <xref:Microsoft.ML.AutoML.AutoCatalog.Regression%2A>

For the taxi fare prediction problem, since the goal is to predict a numerical value, use `Regression`. For more information on choosing a task, see [Machine learning tasks in ML.NET](../resources/tasks.md)

### Configure your experiment

First, create an AutoML experiment. An <xref:Microsoft.ML.AutoML.AutoMLExperiment> is a collection of <xref:Microsoft.ML.AutoML.TrialResult>.

```csharp
AutoMLExperiment experiment = ctx.Auto().CreateExperiment();
```

Once your experiment is created, use the extension methods it provides to configure different settings.

```csharp
experiment
    .SetPipeline(pipeline)
    .SetRegressionMetric(RegressionMetric.RSquared, labelColumn: columnInference.ColumnInformation.LabelColumnName)
    .SetTrainingTimeInSeconds(60)
    .SetDataset(trainValidationData);
```

In this example, you:

- Set the sweepable pipeline to run during the experiment by calling <xref:Microsoft.ML.AutoML.AutoMLExperimentExtension.SetPipeline%2A>.
- Choose `RSquared` as the metric to optimize during training by calling <xref:Microsoft.ML.AutoML.AutoMLExperimentExtension.SetRegressionMetric%2A>. For more information on evaluation metrics, see the [evaluate your ML.NET model with metrics](../resources/metrics.md) guide.
- Set 60 seconds as the amount of time you want to train for by calling <xref:Microsoft.ML.AutoML.AutoMLExperiment.SetTrainingTimeInSeconds%2A>. A good heuristic to determine how long to train for is the size of your data. Typically, larger datasets require longer training time. For more information, see [training time guidance](../automate-training-with-model-builder.md#how-long-should-i-train-for).
- Provide the training and validation datasets to use by calling <xref:Microsoft.ML.AutoML.AutoMLExperimentExtension.SetDataset%2A>.

Once your experiment is defined, you'll want some way to track its progress. The quickest way to track progress is by modifying the <xref:Microsoft.ML.MLContext.Log> event from <xref:Microsoft.ML.MLContext>.

```csharp
// Log experiment trials
ctx.Log += (_, e) => {
    if (e.Source.Equals("AutoMLExperiment"))
    {
        Console.WriteLine(e.RawMessage);
    }
};
```

### Run your experiment

Now that you've defined your experiment, use the <xref:Microsoft.ML.AutoML.AutoMLExperiment.RunAsync%2A> method to start your experiment.

```csharp
TrialResult experimentResults = await experiment.RunAsync();
```

Once the time to train expires, the result is a <xref:Microsoft.ML.AutoML.TrialResult> for the best model found during training.

At this point, you can save your model or use it for making predictions. For more information on how use an ML.NET model, see the following guides:

- [Save and load trained models](save-load-machine-learning-models-ml-net.md)
- [Make predictions with a trained model](machine-learning-model-predictions-ml-net.md)

## Modify column inference results

Because <xref:Microsoft.ML.AutoML.AutoCatalog.InferColumns%2A> only loads a subset of your data, it's possible that edge cases contained outside of the samples used to infer columns aren't caught and the wrong data types are set for your columns. You can update the properties of <xref:Microsoft.ML.AutoML.ColumnInferenceResults.ColumnInformation> to account for those cases where the column inference results aren't correct.

For example, in the taxi fare dataset, the data in the `rate_code` column is a number. However, that numerical value represents a category. By default, calling <xref:Microsoft.ML.AutoML.AutoCatalog.InferColumns%2A> will place `rate_code` in the `NumericColumnNames` property instead of `CategoricalColumnNames`. Because these properties are .NET collections, you can use standard operations to add and remove items from them.

You can do the following to update the <xref:Microsoft.ML.AutoML.ColumnInferenceResults.ColumnInformation> for `rate_code`.  

```csharp
columnInference.ColumnInformation.NumericColumnNames.Remove("rate_code");
columnInference.ColumnInformation.CategoricalColumnNames.Add("rate_code");
```

## Exclude trainers

By default, AutoML tries multiple trainers as part of the training process to see which one works best for your data. However, throughout the training process you might discover there are some trainers that use up too many compute resources or don't provide good evaluation metrics. You have the option to exclude trainers from the training process. Which trainers are used depends on the task. For a list of supported trainers in ML.NET, see the [Machine learning tasks in ML.NET guide](../resources/tasks.md).

For example, in the taxi fare regression scenario, to exclude the LightGBM algorithm, set the `useLgbm` parameter to `false`.

```csharp
ctx.Auto().Regression(labelColumnName: columnInference.ColumnInformation.LabelColumnName, useLgbm:false)
```

The process for excluding trainers in other tasks like binary and multiclass classification works the same way.

## Customize a sweepable estimator

When you want to more granular customization of estimator options included as part of your sweepable pipeline, you need to:

1. Initialize a search space
1. Use the search space to define a custom factory
1. Create a sweepable estimator
1. Add your sweepable estimator to your sweepable pipeline

AutoML provides a set of preconfigured search spaces for trainers in the following machine learning tasks:

- <xref:Microsoft.ML.AutoML.AutoCatalog.BinaryClassification%2A>
- <xref:Microsoft.ML.AutoML.AutoCatalog.MultiClassification%2A>
- <xref:Microsoft.ML.AutoML.AutoCatalog.Regression%2A>

In this example, the search space used is for the <xref:Microsoft.ML.Trainers.SdcaRegressionTrainer>. Initialize it by using <xref:Microsoft.ML.AutoML.CodeGen.SdcaOption>.

```csharp
var sdcaSearchSpace = new SearchSpace<SdcaOption>();
```

Then, use the search space to define a custom factory method to create the <xref:Microsoft.ML.Trainers.SdcaRegressionTrainer>. In this example, the values of `L1Regularization` and `L2Regularization` are both being set to something other than the default. For `L1Regularization`, the value set is determined by the tuner during each trial. The `L2Regularization` is fixed for each trial to the hard-coded value. During each trial, the custom factory's output is an <xref:Microsoft.ML.Trainers.SdcaRegressionTrainer> with the configured hyperparameters.

```csharp
// Use the search space to define a custom factory to create an SdcaRegressionTrainer
var sdcaFactory = (MLContext ctx, SdcaOption param) =>
{
    var sdcaOption = new SdcaRegressionTrainer.Options();
    sdcaOption.L1Regularization = param.L1Regularization;
    sdcaOption.L2Regularization = 0.02f;

    sdcaOption.LabelColumnName = columnInference.ColumnInformation.LabelColumnName;

    return ctx.Regression.Trainers.Sdca(sdcaOption);
};
```

A sweepable estimator is the combination of an estimator and a search space. Now that you've defined a search space and used it to create a custom factory method for generating trainers, use the <xref:Microsoft.ML.AutoML.AutoCatalog.CreateSweepableEstimator%2A> method to create a new sweepable estimator.  

```csharp
// Define Sdca sweepable estimator (SdcaRegressionTrainer + SdcaOption search space)
var sdcaSweepableEstimator = ctx.Auto().CreateSweepableEstimator(sdcaFactory, sdcaSearchSpace);
```

To use your sweepable estimator in your experiment, add it to your sweepable pipeline.  

```csharp
SweepablePipeline pipeline =
    ctx.Auto().Featurizer(data, columnInformation: columnInference.ColumnInformation)
        .Append(sdcaSweepableEstimator);
```

Because sweepable pipelines are a collection of sweepable estimators, you can configure and customize as many of these sweepable estimators as you need.

## Customize your search space

There are scenarios where you want to go beyond customizing the sweepable estimators used in your experiment and want control the search space range. You can do so by accessing the search space properties using keys. In this case, the `L1Regularization` parameter is a `float`. Therefore, to customize the search range, use <xref:Microsoft.ML.SearchSpace.Option.UniformSingleOption>.

```csharp
sdcaSearchSpace["L1Regularization"] = new UniformSingleOption(min: 0.01f, max: 2.0f, logBase: false, defaultValue: 0.01f);
```

Depending on the data type of the hyperparameter you want to set, you can choose from the following options:

- Numbers
  - <xref:Microsoft.ML.SearchSpace.Option.UniformIntOption>
  - <xref:Microsoft.ML.SearchSpace.Option.UniformSingleOption>
  - <xref:Microsoft.ML.SearchSpace.Option.UniformDoubleOption>
- Booleans and strings
  - <xref:Microsoft.ML.SearchSpace.Option.ChoiceOption>

Search spaces can contain nested search spaces as well.

```csharp
var searchSpace = new SearchSpace();
searchSpace["SingleOption"] = new UniformSingleOption(min:-10f, max:10f, defaultValue=0f) 
var nestedSearchSpace = new SearchSpace();
nestedSearchSpace["IntOption"] = new UniformIntOption(min:-10, max:10, defaultValue=0);
searchSpace["Nest"] = nestedSearchSpace;
```

Another option for customizing search ranges is by extending them. For example, <xref:Microsoft.ML.AutoML.CodeGen.SdcaOption> only provides the `L1Regularization` and `L2Regularization` parameters. However, <xref:Microsoft.ML.Trainers.SdcaRegressionTrainer> has more parameters you can set such as `BiasLearningRate`.

To extend the search space, create a new class, such as `SdcaExtendedOption`, that inherits from <xref:Microsoft.ML.AutoML.CodeGen.SdcaOption>.

```csharp
public class SdcaExtendedOption : SdcaOption
{
    [Range(0.10f, 1f, 0.01f)]
    public float BiasLearningRate {get;set;}   
}
```

To specify the search space range, use <xref:Microsoft.ML.SearchSpace.RangeAttribute>, which is equivalent to <xref:Microsoft.ML.SearchSpace.Option>.

Then, anywhere you use your search space, reference the `SdcaExtendedOption` instead of <xref:Microsoft.ML.AutoML.CodeGen.SdcaOption>.

For example, when you initialize your search space, you can do so as follows:  

```csharp
var sdcaSearchSpace = new SearchSpace<SdcaExtendedOption>();
```

## Create your own trial runner

By default, AutoML supports binary classification, multiclass classification, and regression. However, ML.NET supports many more scenarios such as:

- Recommendation
- Forecasting
- Ranking
- Image classification
- Text classification
- Sentence similarity

For scenarios that don't have preconfigured search spaces and sweepable estimators you can create your own and use a trial runner to enable AutoML for that scenario.

For example, given restaurant review data that looks like the following:

:::row:::
    :::column:::
        Wow... Loved this place.
    :::column-end:::
    :::column:::
        1
    :::column-end:::
:::row-end:::
:::row:::
    :::column:::
        Crust is not good.
    :::column-end:::
    :::column:::
        0
    :::column-end:::
:::row-end:::

You want to use the <xref:Microsoft.ML.TorchSharp.NasBert.TextClassificationTrainer> trainer to analyze sentiment where 0 is negative and 1 is positive. However, there is no `ctx.Auto().TextClassification()` configuration.  

To use AutoML with the text classification trainer, you'll have to:

1. Create your own search space.

    ```csharp
    // Define TextClassification search space
    public class TCOption
    {
        [Range(64, 128, 32)]
        public int BatchSize { get; set; }
    }
    ```

    In this case, AutoML will search for different configurations of the `BatchSize` hyperparameter.

1. Create a sweepable estimator and add it to your pipeline.

    ```csharp
    // Initialize search space
    var tcSearchSpace = new SearchSpace<TCOption>();
    
    // Create factory for Text Classification trainer
    var tcFactory = (MLContext ctx, TCOption param) =>
    {
        return ctx.MulticlassClassification.Trainers.TextClassification(
            sentence1ColumnName: textColumnName,
            batchSize:param.BatchSize);
    };
    
    // Create text classification sweepable estimator
    var tcEstimator = 
        ctx.Auto().CreateSweepableEstimator(tcFactory, tcSearchSpace);
    
    // Define text classification pipeline
    var pipeline =
        ctx.Transforms.Conversion.MapValueToKey(columnInference.ColumnInformation.LabelColumnName)
            .Append(tcEstimator);
    ```

    In this example, the `TCOption` search space and a custom <xref:Microsoft.ML.TorchSharp.NasBert.TextClassificationTrainer> factory are used to create a sweepable estimator.

1. Create a custom trial runner

    To create a custom trial runner, implement <xref:Microsoft.ML.AutoML.ITrialRunner>:

    ```csharp
    public class TCRunner : ITrialRunner
    {
        private readonly MLContext _context;
        private readonly TrainTestData _data;
        private readonly IDataView _trainDataset;
        private readonly IDataView _evaluateDataset;
        private readonly SweepablePipeline _pipeline;
        private readonly string _labelColumnName;
        private readonly MulticlassClassificationMetric _metric;

        public TCRunner(
            MLContext context, 
            TrainTestData data, 
            SweepablePipeline pipeline,
            string labelColumnName = "Label", 
            MulticlassClassificationMetric metric = MulticlassClassificationMetric.MicroAccuracy)
        {
            _context = context;
            _data = data;
            _trainDataset = data.TrainSet;
            _evaluateDataset = data.TestSet;
            _labelColumnName = labelColumnName;
            _pipeline = pipeline;
            _metric = metric;
        }

        public void Dispose()
        {
            return;
        }

        // Run trial asynchronously
        public Task<TrialResult> RunAsync(TrialSettings settings, CancellationToken ct)
        {
            try
            {
                return Task.Run(() => Run(settings));
            }
            catch (Exception ex) when (ct.IsCancellationRequested)
            {
                throw new OperationCanceledException(ex.Message, ex.InnerException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Helper function to define trial run logic
        private TrialResult Run(TrialSettings settings)
        {
            try
            {
                // Initialize stop watch to measure time
                var stopWatch = new Stopwatch();
                stopWatch.Start();

                // Get pipeline parameters
                var parameter = settings.Parameter["_pipeline_"];

                // Use parameters to build pipeline
                var pipeline = _pipeline.BuildFromOption(_context, parameter);

                // Train model
                var model = pipeline.Fit(_trainDataset);

                // Evaluate the model
                var predictions = model.Transform(_evaluateDataset);

                // Get metrics
                var evaluationMetrics = _context.MulticlassClassification.Evaluate(predictions, labelColumnName: _labelColumnName);
                var chosenMetric = GetMetric(evaluationMetrics);

                return new TrialResult()
                {
                    Metric = chosenMetric,
                    Model = model,
                    TrialSettings = settings,
                    DurationInMilliseconds = stopWatch.ElapsedMilliseconds
                };
            }
            catch (Exception)
            {
                return new TrialResult()
                {
                    Metric = double.MinValue,
                    Model = null,
                    TrialSettings = settings,
                    DurationInMilliseconds = 0,
                };
            }
        }

        // Helper function to choose metric used by experiment
        private double GetMetric(MulticlassClassificationMetrics metric)
        {
            return _metric switch
            {
                MulticlassClassificationMetric.MacroAccuracy => metric.MacroAccuracy,
                MulticlassClassificationMetric.MicroAccuracy => metric.MicroAccuracy,
                MulticlassClassificationMetric.LogLoss => metric.LogLoss,
                MulticlassClassificationMetric.LogLossReduction => metric.LogLossReduction,
                MulticlassClassificationMetric.TopKAccuracy => metric.TopKAccuracy,
                _ => throw new NotImplementedException(),
            };
        }
    }
    ```

    The `TCRunner` implementation in this example:
      - Extracts the hyperparameters chosen for that trial
      - Uses the hyperparameters to create an ML.NET pipeline
      - Uses the ML.NET pipeline to train a model
      - Evaluates the model
      - Returns a <xref:Microsoft.ML.AutoML.TrialResult> object with the information for that trial

1. Initialize your custom trial runner

    ```csharp
    var tcRunner = new TCRunner(context: ctx, data: trainValidationData, pipeline: pipeline);
    ```

1. Create and configure your experiment. Use the <xref:Microsoft.ML.AutoML.AutoMLExperiment.SetTrialRunner%2A> extension method to add your custom trial runner to your experiment.

    ```csharp
    AutoMLExperiment experiment = ctx.Auto().CreateExperiment();
    
    // Configure AutoML experiment
    experiment
        .SetPipeline(pipeline)
        .SetMulticlassClassificationMetric(MulticlassClassificationMetric.MicroAccuracy, labelColumn: columnInference.ColumnInformation.LabelColumnName)
        .SetTrainingTimeInSeconds(120)
        .SetDataset(trainValidationData)
        .SetTrialRunner(tcRunner);
    ```

1. Run your experiment

    ```csharp
    var tcCts = new CancellationTokenSource();
    TrialResult textClassificationExperimentResults = await experiment.RunAsync(tcCts.Token);
    ```

## Choose a different tuner

AutoML supports various tuning algorithms to iterate through the search space in search of the optimal hyperparameters. By default, it uses the Eci Cost Frugal tuner. Using experiment extension methods, you can choose another tuner that best fits your scenario.  

Use the following methods to set your tuner:

- **SMAC** - <xref:Microsoft.ML.AutoML.AutoMLExperimentExtension.SetSmacTuner%2A>
- **Grid Search** - <xref:Microsoft.ML.AutoML.AutoMLExperimentExtension.SetGridSearchTuner%2A>
- **Random Search** - <xref:Microsoft.ML.AutoML.AutoMLExperimentExtension.SetRandomSearchTuner%2A>
- **Cost Frugal** - <xref:Microsoft.ML.AutoML.AutoMLExperimentExtension.SetCostFrugalTuner%2A>
- **Eci Cost Frugal** - <xref:Microsoft.ML.AutoML.AutoMLExperimentExtension.SetEciCostFrugalTuner%2A>

For example, to use the grid search tuner, your code might look like the following:

```csharp
experiment.SetGridSearchTuner();
```

## Configure experiment monitoring

The quickest way to monitor the progress of an experiment is to define the <xref:Microsoft.ML.MLContext.Log> event from <xref:Microsoft.ML.MLContext>. However, the <xref:Microsoft.ML.MLContext.Log> event outputs a raw dump of the logs generated by AutoML during each trial. Because of the large amount of unformatted information, it's difficult.  

For a more controlled monitoring experience, implement a class with the <xref:Microsoft.ML.AutoML.IMonitor> interface.

```csharp
public class AutoMLMonitor : IMonitor
{
    private readonly SweepablePipeline _pipeline;

    public AutoMLMonitor(SweepablePipeline pipeline)
    {
        _pipeline = pipeline;
    }

    public IEnumerable<TrialResult> GetCompletedTrials() => _completedTrials;

    public void ReportBestTrial(TrialResult result)
    {
        return;
    }

    public void ReportCompletedTrial(TrialResult result)
    {
        var trialId = result.TrialSettings.TrialId;
        var timeToTrain = result.DurationInMilliseconds;
        var pipeline = _pipeline.ToString(result.TrialSettings.Parameter);
        Console.WriteLine($"Trial {trialId} finished training in {timeToTrain}ms with pipeline {pipeline}");
    }

    public void ReportFailTrial(TrialSettings settings, Exception exception = null)
    {
        if (exception.Message.Contains("Operation was canceled."))
        {
            Console.WriteLine($"{settings.TrialId} cancelled. Time budget exceeded.");
        }
        Console.WriteLine($"{settings.TrialId} failed with exception {exception.Message}");
    }

    public void ReportRunningTrial(TrialSettings setting)
    {
        return;
    }
}
```

The <xref:Microsoft.ML.AutoML.IMonitor> interface has four lifecycle events:

- <xref:Microsoft.ML.AutoML.IMonitor.ReportBestTrial%2A>
- <xref:Microsoft.ML.AutoML.IMonitor.ReportCompletedTrial%2A>
- <xref:Microsoft.ML.AutoML.IMonitor.ReportFailTrial%2A>
- <xref:Microsoft.ML.AutoML.IMonitor.ReportRunningTrial%2A>

> [!TIP]
> Although it's not required, include your <xref:Microsoft.ML.AutoML.SweepablePipeline> in your monitor so you can inspect the pipeline that was generated for a trial using the <xref:Microsoft.ML.AutoML.TrialSettings.Parameter> property of the <xref:Microsoft.ML.AutoML.TrialSettings>.

In this example, only the <xref:Microsoft.ML.AutoML.IMonitor.ReportCompletedTrial%2A> and <xref:Microsoft.ML.AutoML.IMonitor.ReportFailTrial%2A> are implemented.

Once you've implemented your monitor, set it as part of your experiment configuration using <xref:Microsoft.ML.AutoML.AutoMLExperiment.SetMonitor%2A>.

```csharp
var monitor = new AutoMLMonitor(pipeline);
experiment.SetMonitor(monitor);
```

Then, run your experiment:

```csharp
var cts = new CancellationTokenSource();
TrialResult experimentResults = await experiment.RunAsync(cts.Token);
```

When you run the experiment with this implementation, the output should look similar to the following:

```text
Trial 0 finished training in 5835ms with pipeline ReplaceMissingValues=>OneHotEncoding=>Concatenate=>FastForestRegression
Trial 1 finished training in 15080ms with pipeline ReplaceMissingValues=>OneHotEncoding=>Concatenate=>SdcaRegression
Trial 2 finished training in 3941ms with pipeline ReplaceMissingValues=>OneHotHashEncoding=>Concatenate=>FastTreeRegression
```

## Persist trials

By default, AutoML only stores the <xref:Microsoft.ML.AutoML.TrialResult> for the best model. However, if you wanted to persist each of the trials, you can do so from within your monitor.

Inside your monitor:  

1. Define a property for your completed trials and a method for accessing them.

    ```csharp
    private readonly List<TrialResult> _completedTrials;
    
    public IEnumerable<TrialResult> GetCompletedTrials() => _completedTrials;
    ```

1. Initialize it in your constructor

    ```csharp
    public AutoMLMonitor(SweepablePipeline pipeline)
    {
        //...
        _completedTrials = new List<TrialResult>();
        //...
    }
    ```

1. Append each trial result inside your <xref:Microsoft.ML.AutoML.IMonitor.ReportCompletedTrial%2A> lifecycle method.

    ```csharp
    public void ReportCompletedTrial(TrialResult result)
    {
        //...
        _completedTrials.Add(result);
    }
    ```

1. When training completes, you can access all the completed trials by calling `GetCompletedTrials`

    ```csharp
    var completedTrials = monitor.GetCompletedTrials();
    ```

At this point, you can perform additional processing on the collection of completed trials. For example, you can choose a model other than the one selected by AutoML, log trial results to a database, or rebuild the pipeline from any of the completed trials.

## Cancel experiments

When you run experiments asynchronously, make sure to cleanly terminate the process. To do so, use a <xref:System.Threading.CancellationToken>.

> [!WARNING]
> Cancelling an experiment will not save any of the intermediary outputs. Set a checkpoint to save intermediary outputs.

```csharp
var cts = new CancellationTokenSource();
TrialResult experimentResults = await experiment.RunAsync(cts.Token);
```

## Set checkpoints

Checkpoints provide a way for you to save intermediary outputs from the training process in the event of an early termination or error. To set a checkpoint, use the <xref:Microsoft.ML.AutoML.AutoMLExperimentExtension.SetCheckpoint%2A> extension method and provide a directory to store the intermediary outputs.

```csharp
var checkpointPath = Path.Join(Directory.GetCurrentDirectory(), "automl");
experiment.SetCheckpoint(checkpointPath);
```

## Determine feature importance

As machine learning is introduced into more aspects of everyday life such as healthcare, it's of utmost importance to understand why a machine learning model makes the decisions it does. Permutation Feature Importance (PFI) is a technique used to explain classification, ranking, and regression models. At a high level, the way it works is by randomly shuffling data one feature at a time for the entire dataset and calculating how much the performance metric of interest decreases. The larger the change, the more important that feature is. For more information on PFI, see [interpret model predictions using Permutation Feature Importance](explain-machine-learning-model-permutation-feature-importance-ml-net.md).

> [!NOTE]
> Calculating PFI can be a time consuming operation. How much time it takes to calculate is proportional to the number of feature columns you have. The more features, the longer PFI will take to run.

To determine feature importance using AutoML:

1. Get the best model.

    ```csharp
    var bestModel = expResult.Model;
    ```

1. Apply the model to your dataset.

    ```csharp
    var transformedData = bestModel.Transform(trainValidationData.TrainSet);
    ```

1. Calculate feature importance using <xref:Microsoft.ML.PermutationFeatureImportanceExtensions.PermutationFeatureImportance%2A>

    In this case, the task is regression but the same concept applies to other tasks like ranking and classification.

    ```csharp
    var pfiResults = 
        mlContext.Regression.PermutationFeatureImportance(bestModel, transformedData, permutationCount:3);
    ```

1. Order feature importance by changes to evaluation metrics.

    ```csharp
    var featureImportance = 
        pfi.Select(x => Tuple.Create(x.Key, x.Value.Regression.RSquared))
            .OrderByDescending(x => x.Item2);    
    ```
