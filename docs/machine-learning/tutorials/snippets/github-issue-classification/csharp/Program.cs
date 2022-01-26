// <SnippetAddUsings>
using Microsoft.ML;
using GitHubIssueClassification;
// </SnippetAddUsings>

// <SnippetDeclareGlobalVariables>
string _appPath = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
string _trainDataPath = Path.Combine(_appPath, "..", "..", "..", "Data", "issues_train.tsv");
string _testDataPath = Path.Combine(_appPath, "..", "..", "..", "Data", "issues_test.tsv");
string _modelPath = Path.Combine(_appPath, "..", "..", "..", "Models", "model.zip");

MLContext _mlContext;
PredictionEngine<GitHubIssue, IssuePrediction> _predEngine;
ITransformer _trainedModel;
IDataView _trainingDataView;
// </SnippetDeclareGlobalVariables>

    // Create MLContext to be shared across the model creation workflow objects
// Set a random seed for repeatable/deterministic results across multiple trainings.
// <SnippetCreateMLContext>
_mlContext = new MLContext(seed: 0);
// </SnippetCreateMLContext>

// STEP 1: Common data loading configuration
// CreateTextReader<GitHubIssue>(hasHeader: true) - Creates a TextLoader by inferencing the dataset schema from the GitHubIssue data model type.
// .Read(_trainDataPath) - Loads the training text file into an IDataView (_trainingDataView) and maps from input columns to IDataView columns.
Console.WriteLine($"=============== Loading Dataset  ===============");

// <SnippetLoadTrainData>
_trainingDataView = _mlContext.Data.LoadFromTextFile<GitHubIssue>(_trainDataPath,hasHeader: true);
// </SnippetLoadTrainData>

Console.WriteLine($"=============== Finished Loading Dataset  ===============");

// <SnippetSplitData>
//   var (trainData, testData) = _mlContext.MulticlassClassification.TrainTestSplit(_trainingDataView, testFraction: 0.1);
// </SnippetSplitData>

// <SnippetCallProcessData>
var pipeline = ProcessData();
// </SnippetCallProcessData>

// <SnippetCallBuildAndTrainModel>
var trainingPipeline = BuildAndTrainModel(_trainingDataView, pipeline);
// </SnippetCallBuildAndTrainModel>

// <SnippetCallEvaluate>
Evaluate(_trainingDataView.Schema);
// </SnippetCallEvaluate>

// <SnippetCallPredictIssue>
PredictIssue();
// </SnippetCallPredictIssue>

IEstimator<ITransformer> ProcessData()
{
    Console.WriteLine($"=============== Processing Data ===============");
    // STEP 2: Common data process configuration with pipeline data transformations
    // <SnippetMapValueToKey>
    var pipeline = _mlContext.Transforms.Conversion.MapValueToKey(inputColumnName: "Area", outputColumnName: "Label")
                    // </SnippetMapValueToKey>
                    // <SnippetFeaturizeText>
                    .Append(_mlContext.Transforms.Text.FeaturizeText(inputColumnName: "Title", outputColumnName: "TitleFeaturized"))
                    .Append(_mlContext.Transforms.Text.FeaturizeText(inputColumnName: "Description", outputColumnName: "DescriptionFeaturized"))
                    // </SnippetFeaturizeText>
                    // <SnippetConcatenate>
                    .Append(_mlContext.Transforms.Concatenate("Features", "TitleFeaturized", "DescriptionFeaturized"))
                    // </SnippetConcatenate>
                    //Sample Caching the DataView so estimators iterating over the data multiple times, instead of always reading from file, using the cache might get better performance.
                    // <SnippetAppendCache>
                    .AppendCacheCheckpoint(_mlContext);
                    // </SnippetAppendCache>

    Console.WriteLine($"=============== Finished Processing Data ===============");

    // <SnippetReturnPipeline>
    return pipeline;
    // </SnippetReturnPipeline>
}

IEstimator<ITransformer> BuildAndTrainModel(IDataView trainingDataView, IEstimator<ITransformer> pipeline)
{
    // STEP 3: Create the training algorithm/trainer
    // Use the multi-class SDCA algorithm to predict the label using features.
    //Set the trainer/algorithm and map label to value (original readable state)
    // <SnippetAddTrainer>
    var trainingPipeline = pipeline.Append(_mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
            .Append(_mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));
    // </SnippetAddTrainer>

    // STEP 4: Train the model fitting to the DataSet
    Console.WriteLine($"=============== Training the model  ===============");

    // <SnippetTrainModel>
    _trainedModel = trainingPipeline.Fit(trainingDataView);
    // </SnippetTrainModel>
    Console.WriteLine($"=============== Finished Training the model Ending time: {DateTime.Now.ToString()} ===============");

    // (OPTIONAL) Try/test a single prediction with the "just-trained model" (Before saving the model)
    Console.WriteLine($"=============== Single Prediction just-trained-model ===============");

    // Create prediction engine related to the loaded trained model
    // <SnippetCreatePredictionEngine1>
    _predEngine = _mlContext.Model.CreatePredictionEngine<GitHubIssue, IssuePrediction>(_trainedModel);
    // </SnippetCreatePredictionEngine1>
    // <SnippetCreateTestIssue1>
    GitHubIssue issue = new GitHubIssue() {
        Title = "WebSockets communication is slow in my machine",
        Description = "The WebSockets communication used under the covers by SignalR looks like is going slow in my development machine.."
    };
    // </SnippetCreateTestIssue1>

    // <SnippetPredict>
    var prediction = _predEngine.Predict(issue);
    // </SnippetPredict>

    // <SnippetOutputPrediction>
    Console.WriteLine($"=============== Single Prediction just-trained-model - Result: {prediction.Area} ===============");
    // </SnippetOutputPrediction>

    // <SnippetReturnModel>
    return trainingPipeline;
    // </SnippetReturnModel>
}

void Evaluate(DataViewSchema trainingDataViewSchema)
{
    // STEP 5:  Evaluate the model in order to get the model's accuracy metrics
    Console.WriteLine($"=============== Evaluating to get model's accuracy metrics - Starting time: {DateTime.Now.ToString()} ===============");

    //Load the test dataset into the IDataView
    // <SnippetLoadTestDataset>
    var testDataView = _mlContext.Data.LoadFromTextFile<GitHubIssue>(_testDataPath,hasHeader: true);
    // </SnippetLoadTestDataset>

    //Evaluate the model on a test dataset and calculate metrics of the model on the test data.
    // <SnippetEvaluate>
    var testMetrics = _mlContext.MulticlassClassification.Evaluate(_trainedModel.Transform(testDataView));
    // </SnippetEvaluate>

    Console.WriteLine($"=============== Evaluating to get model's accuracy metrics - Ending time: {DateTime.Now.ToString()} ===============");
    // <SnippetDisplayMetrics>
    Console.WriteLine($"*************************************************************************************************************");
    Console.WriteLine($"*       Metrics for Multi-class Classification model - Test Data     ");
    Console.WriteLine($"*------------------------------------------------------------------------------------------------------------");
    Console.WriteLine($"*       MicroAccuracy:    {testMetrics.MicroAccuracy:0.###}");
    Console.WriteLine($"*       MacroAccuracy:    {testMetrics.MacroAccuracy:0.###}");
    Console.WriteLine($"*       LogLoss:          {testMetrics.LogLoss:#.###}");
    Console.WriteLine($"*       LogLossReduction: {testMetrics.LogLossReduction:#.###}");
    Console.WriteLine($"*************************************************************************************************************");
    // </SnippetDisplayMetrics>

    // Save the new model to .ZIP file
    // <SnippetCallSaveModel>
    SaveModelAsFile(_mlContext, trainingDataViewSchema, _trainedModel);
    // </SnippetCallSaveModel>
}

void PredictIssue()
{
    // <SnippetLoadModel>
    ITransformer loadedModel = _mlContext.Model.Load(_modelPath, out var modelInputSchema);
    // </SnippetLoadModel>

    // <SnippetAddTestIssue>
    GitHubIssue singleIssue = new GitHubIssue() { Title = "Entity Framework crashes", Description = "When connecting to the database, EF is crashing" };
    // </SnippetAddTestIssue>

    //Predict label for single hard-coded issue
    // <SnippetCreatePredictionEngine>
    _predEngine = _mlContext.Model.CreatePredictionEngine<GitHubIssue, IssuePrediction>(loadedModel);
    // </SnippetCreatePredictionEngine>

    // <SnippetPredictIssue>
    var prediction = _predEngine.Predict(singleIssue);
    // </SnippetPredictIssue>

    // <SnippetDisplayResults>
    Console.WriteLine($"=============== Single Prediction - Result: {prediction.Area} ===============");
    // </SnippetDisplayResults>
}

void SaveModelAsFile(MLContext mlContext,DataViewSchema trainingDataViewSchema, ITransformer model)
{
    // <SnippetSaveModel>
    mlContext.Model.Save(model, trainingDataViewSchema, _modelPath);
    // </SnippetSaveModel>

    Console.WriteLine("The model is saved to {0}", _modelPath);
}
