---
title: How to use the ML.NET Automated ML (AutoML) API
description: The ML.NET Automated ML (AutoML) API automates the model building process and generates a model ready for deployment. Learn the options that you can use to configure automated machine learning tasks.
ms.date: 11/10/2022
ms.custom: mvc,how-to
ms.topic: how-to
---

# How to use the ML.NET Automated Machine Learning (AutoML) API

## Quick Start

AutoML provides several defaults for quickly training models. In this section you will learn how to:

- Load data
- Define your pipeline
- Configure your experiment
- Run your experiment
- Use the best model to make predictions

### Defining your problem

Given a dataset stored in a comma-separated file called *taxi-fare.csv* that looks like the following:  

| vendor_id | rate_code | passenger_count | trip_time_in_secs | trip_distance|payment_type | fare_amount |
|---|---|---|---|---|---|---|
CMT|1|1|1271|3.8|CRD|17.5
CMT|1|1|474|1.5|CRD|8
CMT|1|1|637|1.4|CRD|8.5

### Load data

To load your data, use the `InferColumn` method.

```csharp
// Initialize MLContext
MLContext ctx = new MLContext();

// Infer column information
ColumnInferenceResults columnInference = 
    ctx.Auto().InferColumns("taxi-fare.csv", labelColumnName: "fare_amount", groupColumns:false);
```

Then, use the `TextLoaderOptions` defined by the `ColumnInferenceResults` to create a `TextLoader` to load your data into an `IDataView`.

```csharp
// Create text loader
TextLoader loader = ctx.Data.CreateTextLoader(columnInference.TextLoaderOptions);

// Load data into IDataView
IDataView data = loader.Load("taxi-fare.csv");
```

It's often good practice to split your data into train and validation sets. Use `TrainTestSplit` to create an 80% training and 20% validation split of your dataset.

```csharp
// Split into train (70%), validation (20%) sets
TrainTestData trainValidationData = ctx.Data.TrainTestSplit(data, testFraction:0.2);
```

### Define your pipeline

Your pipeline defines the data preprocesing steps and machine learning pipeline to use for training your model.

```csharp
SweepablePipeline pipeline = 
    ctx.Auto().Featurizer(data, columnInformation:columnInference.ColumnInformation)
        .Append(ctx.Auto().Regression(labelColumnName:columnInference.ColumnInformation.LabelColumnName));
```

A `SweepablePipeline` is a pipeline containing a colelction of `SweepableEstimators`. A `SweepableEstimator` is an ML.NET `Estimator` with a `SearchSpace`.

The `Featurizer` is a convenience API which builds a `SweepablePipeline` of data processing sweepable estimators based on the column information you provide. Instead of building a pipeline from scratch, `Featurizer` automates the data preprocessing step.

> [!TIP]
> Use `Featurizer` with `ColumnInferenceResults` to maximize the utility of AutoML.

For training, AutoML provides a sweepable pipeline with default trainers and search space configurations for the following machine learning tasks:

- Binary classification
- Multiclass classification
- Regression

For the taxi fare prediction problem, since the goal is to predict a numerical value, use `Regression`. For more information on choosing a task, see the [machine learning tasks in ML.NET guide](/dotnet/machine-learning/resources/tasks.md).

### Configure your experiment

First, create an AutoML experiment. An experiment is a collection of trials.  

```csharp
// Create AutoML experiment
AutoMLExperiment experiment = ctx.Auto().CreateExperiment();
```

Once your experiment is created, use the extension methods it provides to configure different settings.

```csharp
// Configure experiment
experiment
    .SetPipeline(pipeline)
    .SetRegressionMetric(RegressionMetric.RSquared, labelColumn:columnInference.ColumnInformation.LabelColumnName)
    .SetTrainingTimeInSeconds(60)
    .SetDataset(trainValidationData);
```

In this example, you:

- Set the sweepable pipeline to run during the experiment using `SetPipeline`.
- Choose `RSquared` as the metric to optimize during training using `SetRegressionMetric`.
- Set 60 seconds as the amount of time you want to train for using `SetTrainingTimeInSeconds`.
- Provide the training and validation datasets to use using `SetDataset`.

Once your experiment is defined, you'll want some way to track its progress. The quickest way to track progress is by defining the `Log` event from `MLContext`.

```csharp
// Log experiment trials
ctx.Log += (_,e) => {    
    if (e.Source.Equals("AutoMLExperiment"))
    {
        Console.WriteLine(e.RawMessage);
    }
};
```

### Run your experiment

Now that you've defined your experiment, use the `Run` or `RunAsync` methods to start your experiment.

```csharp
TrialResult experimentResults = await experiment.RunAsync();
```

Once the time to train expires, the result is a `TrialResult` for the best model found during training.

At this point, you can then save your model or use it for making predictions. For more information on how use an ML.NET model, see the following guides:

- [Save and load a trained model](/dotnet/machine-learning/how-to-guides/save-load-machine-learning-models-ml-net.md)
- [Make predictions with a trained model](/dotnet/machine-learning/how-to-guides/machine-learning-model-predictions-ml-net)

## Advanced Scenarios

### Modify column inference results

Because `InferColumn` only loads a subset of your data, it's possible that edge cases contained outside of the samples used to infer columns are not caught and the wrong data types are set for your columns. In those cases, you can update the properties of `ColumnInformation` and `TextLoaderOptions` to account for those cases where the column inference results are not correct.

For example, in the taxi fare dataset, the data in the `rate_code` column is a number. However, that numerical value represents a category. By default, calling `InferColumn` will place `rate_code` in the `NumericColumnNames` property instead of `CategoricalColumnNames`. Because these properties are standard .NET collections, you can use the standard operations to add and remove items from them.  

You can do the following to update the `ColumnInformation` for `rate_code`.  

```csharp
columnInference.ColumnInformation.NumericColumnNames.Remove("rate_code");
columnInference.ColumnInformation.CategoricalColumnNames.Add("rate_code");
```

### Exclude trainers

By default, AutoML tries multiple trainers as part of the training process to see which one works best for your data. However, throughout the training process you might discover there are some trainers that use up too many compute resources or don't provide good evaluation metrics. With AutoML, you have the option to exclude trainers from the training process. Note that which trainers are used depends on the task. For a list of supported trainers in ML.NET, see the [how to choose an ML.NET algorithm guide](/dotnet/machine-learning/how-to-choose-an-ml-net-algorithm.md).

For example, in the taxi fare regression scenario, to exclude the LightGBM algorithm, set the `useLgbm` parameter to `false`.

```csharp
ctx.Auto().Regression(labelColumnName: columnInference.ColumnInformation.LabelColumnName, useLgbm:false)
```

The process for other tasks like binary and multiclass classification and trainers works the same way.

### Customize a sweepable estimator

When you want to more granular customization of estimator options included as part of your sweepable pipeline, you need to:

1. Initialize a search space
1. Use the search space to define a custom factory
1. Define your sweepable estimator
1. Add your sweepable estimator to your sweepable pipeline

AutoML provides a set of preconfigured search spaces for trainers in the following machine learning tasks:

- Binary classification
- Multiclass classification
- Regression

In this example, the search space used is for the `SdcaRegressionTrainer`.

```csharp
// Initialize default Sdca search space
var sdcaSearchSpace = new SearchSpace<SdcaOption>();
```

Then, use the search space to define a custom factory method to create the `SdcaRegressionTrainer`. In this example, the values of `L1Regularization` and `L2Regularization` are both being set to something other than the default. For `L1Regularization`, the value set is determined by the tuner during each trial. The `L2Regularization` is fixed for each trial to the hard-coded value. During each trial, custom factory method's output is an `SdcaRegressionTrainer` with the configured hyperparameters.

```csharp
// Use the search space to define a custom factory to create an SdcaRegressionTrainer
var sdcaEstimatorFactory = (MLContext ctx, SdcaOption param) =>
{
    var sdcaOption = new SdcaRegressionTrainer.Options();
    sdcaOption.L1Regularization = param.L1Regularization;
    sdcaOption.L2Regularization = 0.02f;

    return ctx.Regression.Trainers.Sdca(sdcaOption);
};
```

A sweepable estimator is the combination of an estimator and a search space. Now that you've defined a search space and used it to create a custom factory method for generating trainers. Use the `CreateSweepableEstimator` method to create a new sweepable estimator.  

```csharp
// Define Sdca sweepable estimator (SdcaRegressionTrainer + SdcaOption search space)
var sdcaSweepableEstimator = ctx.Auto().CreateSweepableEstimator(sdcaEstimatorFactory, sdcaSearchSpace);
```

To use your sweepable estimator in your experiment, append it to your sweepable pipeline.  

```csharp
// Add sweepable estimator to sweepable pipeline
SweepablePipeline customEstimatorPipeline =
    ctx.Auto().Featurizer(data, columnInformation: columnInference.ColumnInformation)
        .Append(sdcaSweepableEstimator);
```

Because sweepable pipelines are a collection of sweepable estimators, you can configure and customize as many of these sweepable estimators as you need.

### Customize your search space

There are scenarios where you want to go beyond customizing the sweepable estimators used in your experiment and want control the search space range.

```csharp
var originalSdcaSearchSpace = new SearchSpace<SdcaOption>();
originalSdcaSearchSpace["L1Regularization"] = new UniformSingleOption(min:0.01f, max:2.0f, logBase: false, defaultValue:0.01f);
```

### Create a custom search space

There are a few reasons where you'd want to create your own search space. However, the main one is to support ML.NET tasks that don't have predefined search spaces. These include:

### Create your own trial runner

By default, AutoML supports binary classification, multiclass classification, and regression. However, ML.NET supports many more scenarios such as:

- Recommendation
- Forecasting
- Ranking
- Text classification
- Sentence similarity

For scenarios that don't have preconfigured search spaces and sweepable estimators you can create your own and use a trial runner to enable AutoML for that scenario.

For example, given hourly energy demand data that looks like the following:

| load   |
|---------|
| 20236  |
| 55784  |
| 179759 |
| 314597 |

You want to use the `ForecastBySsa` trainer to forecast future demand.

In order to do so you'll have to:

1. Define a custom search space

    ```csharp
    // Define ForecastBySsa search space
    public class SSAOption
    {
    
        [Range(2, 24 * 7 * 30)]
        public int WindowSize { get; set; } = 2;
    
        [Range(2, 24 * 7 * 30)]
        public int SeriesLength { get; set; } = 2;
    
        [Range(2, 24 * 7 * 30)]
        public int TrainSize { get; set; } = 2;
    
        [Range(1, 24 * 7 * 30)]
        public int Horizon { get; set; } = 1;
    }
    ```

1. Implement a custom trial runner

    To create a trial runner, implement `ITrialRunner`:

    ```csharp
    public class SSARunner : ITrialRunner
    {
        private readonly MLContext _context;
        private readonly TrainTestData _data;
        private readonly IDataView _trainDataset;
        private readonly IDataView _evaluateDataset;
        private readonly SweepablePipeline _pipeline;
        private readonly string _labelColumnName;

        public SSARunner(MLContext context, TrainTestData data, string labelColumnName, SweepablePipeline pipeline)
        {
            _context = context;
            _data = data;
            _trainDataset = data.TrainSet;
            _evaluateDataset = data.TestSet;
            _labelColumnName = labelColumnName;
            _pipeline = pipeline;
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
                
                // Build pipeline from parameters
                var pipeline = _pipeline.BuildFromOption(_context, parameter);
                
                // Train model
                var model = pipeline.Fit(_trainDataset);

                // Create prediction engine for single predictions
                var predictEngine = model.CreateTimeSeriesEngine<ForecastInput, ForecastOutput>(_context);

                // Create a checkpoint for time series engine prediction
                predictEngine.CheckPoint(_context, "origin");

                var predictedLoad1H = new List<float>();
                var N = _evaluateDataset.GetRowCount();

                // Evaluate performance on a rolling basis
                foreach (var load in _evaluateDataset.GetColumn<Single>(_labelColumnName))
                {
                    // First, get next n predictions where n is horizon, in this case, it's always 1.
                    var predict = predictEngine.Predict();

                    // Add prediction to list of predictions
                    predictedLoad1H.Add(predict.Prediction[0]);

                    // Update model with true value
                    predictEngine.Predict(new ForecastInput()
                    {
                        Load = load,
                    });
                }

                // Calculate (Root Mean Squared Error) evaluation metric 
                var rmse = Enumerable.Zip(_evaluateDataset.GetColumn<float>(_labelColumnName), predictedLoad1H)
                                       .Select(x => Math.Pow(x.First - x.Second, 2))
                                       .Average();
                rmse = Math.Sqrt(rmse);

                return new TrialResult()
                {
                    Metric = rmse,
                    Model = model,
                    TrialSettings = settings,
                    DurationInMilliseconds = stopWatch.ElapsedMilliseconds,
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

        // Define input schema
        private class ForecastInput
        {
            [ColumnName("load")]
            public float Load { get; set; }
        }

        // Define output schema
        private class ForecastOutput
        {
            [ColumnName("prediction")]
            public float[] Prediction { get; set; }
        }
    }
    ```

    `ITrialRunner` has an asynchronous run method which produces `TrialResult` information.

1. Create a sweepable estimator and add it to your pipeline.

    ```csharp
    var ssaSearchSpace = new SearchSpace<SSAOption>();
    
    var ssaFactory = (MLContext ctx, SSAOption param) =>
    {
        return ctx.Forecasting.ForecastBySsa(
            outputColumnName: "prediction",
            inputColumnName: "load",
            windowSize: param.WindowSize,
            seriesLength: param.SeriesLength,
            trainSize: param.TrainSize,
            horizon: param.Horizon);
    };
    
    var ssaSweepableEstimator = ctx.Auto().CreateSweepableEstimator(ssaFactory, ssaSearchSpace);

    var ssaPipeline =
        new EstimatorChain<ITransformer>()
            .Append(ssaSweepableEstimator);
    ```

1. Initialize your custom trial runner

    ```csharp
    var ssaRunner = new SSARunner(ssaCtx, ssaDataSplit, labelColumnName: "load", pipeline:ssaPipeline);
    ```

1. Create and configure your experiment. Use the `SetTrialRunner` extension method to add your custom trial runner to your experiment.

    ```csharp
    AutoMLExperiment ssaExperiment = ssaCtx.Auto().CreateExperiment();
    
    ssaExperiment
        .SetPipeline(ssaPipeline)
        .SetRegressionMetric(RegressionMetric.RootMeanSquaredError, labelColumn: "load", scoreColumn: "prediction")
        .SetTrainingTimeInSeconds(60)
        .SetDataset(ssaDataSplit)
        .SetTrialRunner(ssaRunner);
    ```

1. Run your experiment

    ```csharp
    var ssaCts = new CancellationTokenSource();
    TrialResult ssaExperimentResults = await ssaExperiment.RunAsync(ssaCts.Token);
    ```

### Choose a different tuner

AutoML supports a variety of tuning algorithms to iterate through the search space in search of the optimal hyperparamters. By default, it uses the Eci Cost Frugal tuner. Using experiment extension methods, you can choose another tuner that best fits your scenario.  

Use the following methods to set your tuner:

- **SMAC** - `SetSmacTuner`
- **Grid Search** - `SetGridSearchTuner`
- **Random Search** - ``SetRandomSearchTuner`
- **Cost Frugal** - `SetCostFrugalTuner`
- **Eci Cost Frugal** - `SetEciCostFrugalTuner`

For example, to use the SMAC tuner, your code might look like the following:

```csharp
experiment.SetSmacTuner();
```

### Configure experiment monitoring

The quickest way to monitor the progress of an experiment is to define the `Log` event from `MLContext`. However, the `Log` event outputs a raw dump of the logs generated by AutoML during each trial. Because of the large amount of unformatted information, it's difficult.  

For a more controlled monitoring experience, implement a class with the `IMonitor` interface.

```csharp
public class AutoMLMonitor : IMonitor
{
    private readonly SweepablePipeline _pipeline;

    public AutoMLMonitor(SweepablePipeline pipeline)
    {
        _pipeline = pipeline;
    }

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

The `IMonitor` interface has four lifecycle events:

- ReportBestTrial
- ReportCompletedTrial
- ReportFailTrial
- ReportRunningTrial

> [!TIP]
> Although it's not required, include your `SweepablePipeline` in your monitor so you can inspect the pipeline that was generated for a trial using the `Parameter` property of the `TrialSettings`.

In this example, only the `ReportCompletedTrial` and `ReportFailTrial` are implemented.

Once you've implemented your monitor, set it as part of your experiment configuration using `SetMonitor`.

```csharp
var monitor = new AutoMLMonitor(pipeline);
experiment.SetMonitor(monitor);
```

When you run the experiment with this implementation, the output should look similar to the following:

```text
Trial 0 finished training in 5835ms with pipeline ReplaceMissingValues=>OneHotEncoding=>Concatenate=>FastForestRegression
Trial 1 finished training in 15080ms with pipeline ReplaceMissingValues=>OneHotEncoding=>Concatenate=>SdcaRegression
Trial 2 finished training in 3941ms with pipeline ReplaceMissingValues=>OneHotHashEncoding=>Concatenate=>FastTreeRegression
```

### Persist trials

By default, AutoML only stores the `TrialResult` for the best model. However, if you wanted to persist each of the trials, you can do so from within your monitor.

Inside of your monitor, define a property for your completed trials and a method for accessing them.

```csharp
private readonly List<TrialResult> _completedTrials;

public IEnumerable<TrialResult> GetCompletedTrials() => _completedTrials;
```

Initialize it in your constructor

```csharp
public AutoMLMonitor(SweepablePipeline pipeline)
{
    //...
    _completedTrials = new List<TrialResult>();
    //...
}
```

Append each trial result inside your `ReportCompletedTrial` lifecycle method.

```csharp
public void ReportCompletedTrial(TrialResult result)
{
    //...
    _completedTrials.Add(result);
}
```

When training completes, you can access all the completed trials by calling `GetCompletedTrials`

```csharp
monitor.GetCompletedTrials()
```

At this point you can perform additional processing on the collection of completed trials like choosing another model other than the one selected by AutoML, logging trial results to a database, or rebuilding the pipeline from any of the completed trials.

### Cancel asynchronous experiments

When you run experiments asynchronously, make sure to cleanly terminate the process. To do so, use cancellation tokens.

```csharp
var cts = new CancellationTokenSource();
TrialResult experimentResults = await experiment.RunAsync(cts.Token);
```

> [!WARNING]
> Cancelling an experiment will not save any of the intermediary outputs. Set a checkpoint to save intermediary outputs.

### Set checkpoints

Checkpoints provide a way for you to save intermediary outputs from the training process in the event of an early termination or error. To set a checkpoint, use the `SetCheckpoint` extension method and provide a directory to store the intermediary outputs.

```csharp
var checkpointPath = Path.Join(Directory.GetCurrentDirectory(), "automl");
experiment.SetCheckpoint(checkpointPath);
```

<!-- # How to use the ML.NET automated machine learning API

Automated machine learning (AutoML) automates the process of applying machine learning to data. Given a dataset, you can run an AutoML **experiment** to iterate over different data featurizations, machine learning algorithms, and hyperparameters to select the best model.

> [!NOTE]
> This topic refers to the automated machine learning API for ML.NET, which is currently in preview. Material may be subject to change.

## Load data

Automated machine learning supports loading a dataset into an [IDataView](xref:Microsoft.ML.IDataView). Data can be in the form of tab-separated value (TSV) files and comma separated value (CSV) files.

Example:

```csharp
using Microsoft.ML;
using Microsoft.ML.AutoML;
    // ...
    MLContext mlContext = new MLContext();
    IDataView trainDataView = mlContext.Data.LoadFromTextFile<SentimentIssue>("my-data-file.csv", hasHeader: true);
```

## Select the machine learning task type

Before creating an experiment, determine the kind of machine learning problem you want to solve. Automated machine learning supports the following ML tasks:

* Binary Classification
* Multiclass Classification
* Regression
* Recommendation
* Ranking

## Create experiment settings

Create experiment settings for the determined ML task type:

* Binary Classification

  ```csharp
  var experimentSettings = new BinaryExperimentSettings();
  ```

* Multiclass Classification

  ```csharp
  var experimentSettings = new MulticlassExperimentSettings();
  ```

* Regression

  ```csharp
  var experimentSettings = new RegressionExperimentSettings();
  ```

* Recommendation

  ```csharp
  var experimentSettings = new RecommendationExperimentSettings();
  ```

* Ranking

  ```csharp
  var experimentSettings = new RankingExperimentSettings();
  ```

## Configure experiment settings

Experiments are highly configurable. See the [AutoML API docs](/dotnet/api/microsoft.ml.automl?view=ml-dotnet-preview&preserve-view=false) for a full list of configuration settings.

Some examples include:

1. Specify the maximum time that the experiment is allowed to run.

    ```csharp
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

    A default list of trainers to optimize are explored per task. This list can be modified for each experiment. For instance, trainers that run slowly on your dataset can be removed from the list. To optimize on one specific trainer call `experimentSettings.Trainers.Clear()`, then add the trainer that you want to use.

    ```csharp
    var experimentSettings = new RegressionExperimentSettings();
    experimentSettings.Trainers.Remove(RegressionTrainer.LbfgsPoissonRegression);
    experimentSettings.Trainers.Remove(RegressionTrainer.OnlineGradientDescent);
    ```

The list of supported trainers per ML task can be found at the corresponding link below:

* [Supported Binary Classification Algorithms](xref:Microsoft.ML.AutoML.BinaryClassificationTrainer)
* [Supported Multiclass Classification Algorithms](xref:Microsoft.ML.AutoML.MulticlassClassificationTrainer)
* [Supported Regression Algorithms](xref:Microsoft.ML.AutoML.RegressionTrainer)
* [Supported Recommendation Algorithms](xref:Microsoft.ML.AutoML.RecommendationTrainer)
* [Supported Ranking Algorithms](xref:Microsoft.ML.AutoML.RankingTrainer)

## Optimizing metric

The optimizing metric, as shown in the example above, determines the metric to be optimized during model training. The optimizing metric you can select is determined by the task type you choose. Below is a list of available metrics.

|[Binary Classification](xref:Microsoft.ML.AutoML.BinaryClassificationMetric)  | [Multiclass Classification](xref:Microsoft.ML.AutoML.MulticlassClassificationMetric) | [Regression & Recommendation](xref:Microsoft.ML.AutoML.RegressionMetric)  | [Ranking](xref:Microsoft.ML.AutoML.RankingMetric)  |
|---------|---------|---------|---------|
|Accuracy                     | LogLoss         | RSquared             | Discounted Cumulative Gains            |
|AreaUnderPrecisionRecallCurve| LogLossReduction| MeanAbsoluteError    | Normalized Discounted Cumulative Gains |
|AreaUnderRocCurve            | MacroAccuracy   | MeanSquaredError     |                                        |
|F1Score                      | MicroAccuracy   | RootMeanSquaredError |                                        |
|NegativePrecision            | TopKAccuracy    |                      |                                        |
|NegativeRecall               |                 |                      |                                        |
|PositivePrecision            |                 |                      |                                        |
|PositiveRecall               |                 |                      |                                        |

## Data pre-processing and featurization

> [!NOTE]
> The feature column only supported types of <xref:System.Boolean>, <xref:System.Single>, and <xref:System.String>.

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

1. Exit after a length of time - Using `MaxExperimentTimeInSeconds` in your experiment settings you can define how long in seconds that a task should continue to run.

1. Exit on a cancellation token -  You can use a cancellation token that lets you cancel the task before it is scheduled to finish.

    ```csharp
    var cts = new CancellationTokenSource();
    var experimentSettings = new RegressionExperimentSettings();
    experimentSettings.MaxExperimentTimeInSeconds = 3600;
    experimentSettings.CancellationToken = cts.Token;
    ```

## Create an experiment

Once you have configured the experiment settings, you are ready to create the experiment.

```csharp
RegressionExperiment experiment = mlContext.Auto().CreateRegressionExperiment(experimentSettings);
```

## Run the experiment

Running the experiment triggers data pre-processing, learning algorithm selection, and hyperparameter tuning. AutoML will continue to generate combinations of featurization, learning algorithms, and hyperparameters until the `MaxExperimentTimeInSeconds` is reached or the experiment is terminated.

```csharp
ExperimentResult<RegressionMetrics> experimentResult = experiment
    .Execute(trainingDataView, LabelColumnName, progressHandler: progressHandler);
```

Explore other overloads for `Execute()` if you want to pass in validation data, column information indicating the column purpose, or prefeaturizers.

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

* [Binary classification metrics](xref:Microsoft.ML.AutoML.BinaryClassificationMetric)
* [Multiclass classification metrics](xref:Microsoft.ML.AutoML.MulticlassClassificationMetric)
* [Regression & recommendation metrics](xref:Microsoft.ML.AutoML.RegressionMetric)
* [Ranking](xref:Microsoft.ML.AutoML.RankingMetric)

## See also

For full code samples and more visit the [dotnet/machinelearning-samples](https://github.com/dotnet/machinelearning-samples/tree/main#automate-mlnet-models-generation-preview-state) GitHub repository. -->
