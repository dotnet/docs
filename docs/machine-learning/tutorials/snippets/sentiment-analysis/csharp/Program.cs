// <SnippetAddUsings>
using Microsoft.ML;
using Microsoft.ML.Data;
using SentimentAnalysis;
using static Microsoft.ML.DataOperationsCatalog;
// </SnippetAddUsings>

// <SnippetDeclareGlobalVariables>
string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "yelp_labelled.txt");
// </SnippetDeclareGlobalVariables>

// Create ML.NET context/local environment - allows you to add steps in order to keep everything together
// as you discover the ML.NET trainers and transforms
// <SnippetCreateMLContext>
MLContext mlContext = new MLContext();
// </SnippetCreateMLContext>

// <SnippetCallLoadData>
TrainTestData splitDataView = LoadData(mlContext);
// </SnippetCallLoadData>

// <SnippetCallBuildAndTrainModel>
ITransformer model = BuildAndTrainModel(mlContext, splitDataView.TrainSet);
// </SnippetCallBuildAndTrainModel>

// <SnippetCallEvaluate>
Evaluate(mlContext, model, splitDataView.TestSet);
// </SnippetCallEvaluate>

// <SnippetCallUseModelWithSingleItem>
UseModelWithSingleItem(mlContext, model);
// </SnippetCallUseModelWithSingleItem>

// <SnippetCallUseModelWithBatchItems>
UseModelWithBatchItems(mlContext, model);
// </SnippetCallUseModelWithBatchItems>

Console.WriteLine();
Console.WriteLine("=============== End of process ===============");

TrainTestData LoadData(MLContext mlContext)
{
    // Note that this case, loading your training data from a file,
    // is the easiest way to get started, but ML.NET also allows you
    // to load data from databases or in-memory collections.
    // <SnippetLoadData>
    IDataView dataView = mlContext.Data.LoadFromTextFile<SentimentData>(_dataPath, hasHeader: false);
    // </SnippetLoadData>

    // You need both a training dataset to train the model and a test dataset to evaluate the model.
    // Split the loaded dataset into train and test datasets
    // Specify test dataset percentage with the `testFraction`parameter
    // <SnippetSplitData>
    TrainTestData splitDataView = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
    // </SnippetSplitData>

    // <SnippetReturnSplitData>
    return splitDataView;
    // </SnippetReturnSplitData>
}

ITransformer BuildAndTrainModel(MLContext mlContext, IDataView splitTrainSet)
{
    // Create a flexible pipeline (composed by a chain of estimators) for creating/training the model.
    // This is used to format and clean the data.
    // Convert the text column to numeric vectors (Features column)
    // <SnippetFeaturizeText>
    var estimator = mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(SentimentData.SentimentText))
    //</SnippetFeaturizeText>
    // append the machine learning task to the estimator
    // <SnippetAddTrainer>
    .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));
    // </SnippetAddTrainer>

    // Create and train the model based on the dataset that has been loaded, transformed.
    // <SnippetTrainModel>
    Console.WriteLine("=============== Create and Train the Model ===============");
    var model = estimator.Fit(splitTrainSet);
    Console.WriteLine("=============== End of training ===============");
    Console.WriteLine();
    // </SnippetTrainModel>

    // Returns the model we trained to use for evaluation.
    // <SnippetReturnModel>
    return model;
    // </SnippetReturnModel>
}

void Evaluate(MLContext mlContext, ITransformer model, IDataView splitTestSet)
{
    // Evaluate the model and show accuracy stats

    //Take the data in, make transformations, output the data.
    // <SnippetTransformData>
    Console.WriteLine("=============== Evaluating Model accuracy with Test data===============");
    IDataView predictions = model.Transform(splitTestSet);
    // </SnippetTransformData>

    // BinaryClassificationContext.Evaluate returns a BinaryClassificationEvaluator.CalibratedResult
    // that contains the computed overall metrics.
    // <SnippetEvaluate>
    CalibratedBinaryClassificationMetrics metrics = mlContext.BinaryClassification.Evaluate(predictions, "Label");
    // </SnippetEvaluate>

    // The Accuracy metric gets the accuracy of a model, which is the proportion
    // of correct predictions in the test set.

    // The AreaUnderROCCurve metric is equal to the probability that the algorithm ranks
    // a randomly chosen positive instance higher than a randomly chosen negative one
    // (assuming 'positive' ranks higher than 'negative').

    // The F1Score metric gets the model's F1 score.
    // The F1 score is the harmonic mean of precision and recall:
    //  2 * precision * recall / (precision + recall).

    // <SnippetDisplayMetrics>
    Console.WriteLine();
    Console.WriteLine("Model quality metrics evaluation");
    Console.WriteLine("--------------------------------");
    Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
    Console.WriteLine($"Auc: {metrics.AreaUnderRocCurve:P2}");
    Console.WriteLine($"F1Score: {metrics.F1Score:P2}");
    Console.WriteLine("=============== End of model evaluation ===============");
    //</SnippetDisplayMetrics>
}

void UseModelWithSingleItem(MLContext mlContext, ITransformer model)
{
    // <SnippetCreatePredictionEngine1>
    PredictionEngine<SentimentData, SentimentPrediction> predictionFunction = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);
    // </SnippetCreatePredictionEngine1>

    // <SnippetCreateTestIssue1>
    SentimentData sampleStatement = new SentimentData
    {
        SentimentText = "This was a very bad steak"
    };
    // </SnippetCreateTestIssue1>

    // <SnippetPredict>
    var resultPrediction = predictionFunction.Predict(sampleStatement);
    // </SnippetPredict>
    // <SnippetOutputPrediction>
    Console.WriteLine();
    Console.WriteLine("=============== Prediction Test of model with a single sample and test dataset ===============");

    Console.WriteLine();
    Console.WriteLine($"Sentiment: {resultPrediction.SentimentText} | Prediction: {(Convert.ToBoolean(resultPrediction.Prediction) ? "Positive" : "Negative")} | Probability: {resultPrediction.Probability} ");

    Console.WriteLine("=============== End of Predictions ===============");
    Console.WriteLine();
    // </SnippetOutputPrediction>
}

void UseModelWithBatchItems(MLContext mlContext, ITransformer model)
{
    // Adds some comments to test the trained model's data points.
    // <SnippetCreateTestIssues>
    IEnumerable<SentimentData> sentiments = new[]
    {
        new SentimentData
        {
            SentimentText = "This was a horrible meal"
        },
        new SentimentData
        {
            SentimentText = "I love this spaghetti."
        }
    };
    // </SnippetCreateTestIssues>

    // Load batch comments just created
    // <SnippetPrediction>
    IDataView batchComments = mlContext.Data.LoadFromEnumerable(sentiments);

    IDataView predictions = model.Transform(batchComments);

    // Use model to predict whether comment data is Positive (1) or Negative (0).
    IEnumerable<SentimentPrediction> predictedResults = mlContext.Data.CreateEnumerable<SentimentPrediction>(predictions, reuseRowObject: false);
    // </SnippetPrediction>

    // <SnippetAddInfoMessage>
    Console.WriteLine();

    Console.WriteLine("=============== Prediction Test of loaded model with multiple samples ===============");
    // </SnippetAddInfoMessage>

    Console.WriteLine();

    // <SnippetDisplayResults>
    foreach (SentimentPrediction prediction  in predictedResults)
    {
        Console.WriteLine($"Sentiment: {prediction.SentimentText} | Prediction: {(Convert.ToBoolean(prediction.Prediction) ? "Positive" : "Negative")} | Probability: {prediction.Probability} ");
    }
    Console.WriteLine("=============== End of predictions ===============");
    // </SnippetDisplayResults>
}
