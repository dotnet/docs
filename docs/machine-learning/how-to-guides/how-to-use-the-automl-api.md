---
title: How to use the ML.NET Automated ML (AutoML) API
description: The ML.NET Automated ML (AutoML) API automates the model building process and generates a model ready for deployment. Learn the options that you can use to configure automated machine learning tasks.
ms.date: 11/10/2022
ms.custom: mvc,how-to
ms.topic: how-to
---

# How to use the ML.NET Automated Machine Learning (AutoML) API

## Installation

To use the AutoML API, install the [`Microsoft.ML.AutoML`](https://www.nuget.org/packages/Microsoft.ML.AutoML) NuGet package in the .NET project you want to reference it in.

> [!NOTE]
> This guide uses version 0.20.0 and later of the `Microsoft.ML.AutoML` NuGet package. Although samples and code from earlier versions still work, it is highly recommended you use the APIs introduced in this version for new projects.

For more information on installing NuGet packages, see the following guides:

- [Install and use a NuGet package in Visual Studio](/nuget/quickstart/install-and-use-a-package-in-visual-studio)
- [Install and use a package in Visual Studio for Mac](nuget/quickstart/install-and-use-a-package-in-visual-studio-mac)
- [Install and use a package (dotnet CLI)](/nuget/quickstart/install-and-use-a-package-using-the-dotnet-cli)

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

Start by inizializing your <xref:Microsoft.ML.MLContext>. `MLContext` is a starting point for all ML.NET operations. Initializing mlContext creates a new ML.NET environment that can be shared across the model creation workflow objects. It's similar, conceptually, to `DBContext` in Entity Framework.

Then, to load your data, use the <xref:Microsoft.ML.AutoML.AutoCatalog.InferColumns%2A> method.

```csharp
// Initialize MLContext
MLContext ctx = new MLContext();

// Infer column information
ColumnInferenceResults columnInference = 
    ctx.Auto().InferColumns("taxi-fare.csv", labelColumnName: "fare_amount", groupColumns:false);
```

<xref:Microsoft.ML.AutoML.AutoCatalog.InferColumns%2A> loads a few rows from the dataset. It then inspects the data and tries to guess or infer the data type for each of the columns based on their content.

The default behavior is to group columns of the same type into feature vectors or arrays containing the elements for each of the grouped columns. Setting `groupColumns` to `false` overrides that default behavior and only performs column inference without grouping columns. By keeping columns separate it allows you to apply different data transformations when preprocessing the data at the individual column level rather than the grouping. 

The result of <xref:Microsoft.ML.AutoML.AutoCatalog.InferColumns%2A> a <xref:Microsoft.ML.AutoML.ColumnInferenceResults> object which contains the options needed to create a <xref:Microsoft.ML.Data.TextLoader> as well as column information.

For the sample dataset in *taxi-fare.csv*, column information might look like the following:

- **LabelColumnName**: fare_amount
- **CategoricalColumnNames**: vendor_id, payment_type
- **NumericColumnNames**: rate_code, passenger_count, trip_time_in_secs, trip_distance

Once you have your column information, use the <xref:Microsoft.ML.Data.TextLoader.Options> defined by the <xref:Microsoft.ML.AutoML.ColumnInferenceResults> to create a <xref:Microsoft.ML.Data.TextLoader> to load your data into an <xref:Microsoft.ML.IDataView>.

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

A `SweepablePipeline` is a pipeline containing a collection of `SweepableEstimators`. A `SweepableEstimator` is an ML.NET <xref:Microsoft.ML.AutoML.Estimator> with a `SearchSpace`.

The `Featurizer` is a convenience API which builds a sweepable pipeline of data processing sweepable estimators based on the column information you provide. Instead of building a pipeline from scratch, `Featurizer` automates the data preprocessing step. For more information on supported transforms by ML.NET, see the [data transformations guide](../resources/transforms.md).

The resulting output is a single column containing a numerical feature vector representing the transformed data for each of the columns. This feature vector is then used as input for the algorithms used to train a machine learning model.

If you want finer control over your data preprocessing, you can create a pipeline with each of the individual preprocessing steps. For more information, see the [prepare data for building a model guide](prepare-data-ml-net.md).

> [!TIP]
> Use `Featurizer` with <xref:Microsoft.ML.AutoML.ColumnInferenceResults> to maximize the utility of AutoML.

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
- Choose `RSquared` as the metric to optimize during training using `SetRegressionMetric`. For more information on evaluation metrics, see the [evaluate your ML.NET model with metrics](../resources/metrics.md) guide.
- Set 60 seconds as the amount of time you want to train for using `SetTrainingTimeInSeconds`. A good heuristic to determing how long to train for is the size of your data. Typically, larger datasets require longer training time. For additional guidance, see [](../automate-training-with-model-builder.md)
- Provide the training and validation datasets to use using `SetDataset`.

Once your experiment is defined, you'll want some way to track its progress. The quickest way to track progress is by defining the <xref:Microsoft.ML.MLContext.Log> event from <xref:Microsoft.ML.MLContext>.

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

Now that you've defined your experiment, use the `RunAsync` method to start your experiment.

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

The process for excluding trainers in other tasks like binary and multiclass classification the same way.

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

In this example, the search space used is for the <xref:Microsoft.ML.Trainers.SdcaRegressionTrainer>.

```csharp
// Initialize default Sdca search space
var sdcaSearchSpace = new SearchSpace<SdcaOption>();
```

Then, use the search space to define a custom factory method to create the <xref:Microsoft.ML.Trainers.SdcaRegressionTrainer>. In this example, the values of `L1Regularization` and `L2Regularization` are both being set to something other than the default. For `L1Regularization`, the value set is determined by the tuner during each trial. The `L2Regularization` is fixed for each trial to the hard-coded value. During each trial, custom factory method's output is an <xref:Microsoft.ML.Trainers.SdcaRegressionTrainer> with the configured hyperparameters.

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

AutoML provides a set of preconfigured search spaces.

### Create your own trial runner

By default, AutoML supports binary classification, multiclass classification, and regression. However, ML.NET supports many more scenarios such as:

- Recommendation
- Forecasting
- Ranking
- Image classification
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

You want to use the <xref:Microsoft.ML.TimeSeriesCatalog.ForecastBySsa%2A> trainer to forecast future demand.

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

AutoML supports a variety of tuning algorithms to iterate through the search space in search of the optimal hyperparameters. By default, it uses the Eci Cost Frugal tuner. Using experiment extension methods, you can choose another tuner that best fits your scenario.  

Use the following methods to set your tuner:

- **SMAC** - `SetSmacTuner`
- **Grid Search** - `SetGridSearchTuner`
- **Random Search** - `SetRandomSearchTuner`
- **Cost Frugal** - `SetCostFrugalTuner`
- **Eci Cost Frugal** - `SetEciCostFrugalTuner`

For example, to use the SMAC tuner, your code might look like the following:

```csharp
experiment.SetSmacTuner();
```

### Configure experiment monitoring

The quickest way to monitor the progress of an experiment is to define the <xref:Microsoft.ML.MLContext.Log> event from <xref:Microsoft.ML.MLContext>. However, the <xref:Microsoft.ML.MLContext.Log> event outputs a raw dump of the logs generated by AutoML during each trial. Because of the large amount of unformatted information, it's difficult.  

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