// <SnippetAddUsings>
using Microsoft.ML;
using Microsoft.ML.Data;
// </SnippetAddUsings>

// <SnippetDeclareGlobalVariables>
string _assetsPath = Path.Combine(Environment.CurrentDirectory, "assets");
string _imagesFolder = Path.Combine(_assetsPath, "images");
string _trainTagsTsv = Path.Combine(_imagesFolder, "tags.tsv");
string _testTagsTsv = Path.Combine(_imagesFolder, "test-tags.tsv");
string _predictSingleImage = Path.Combine(_imagesFolder, "toaster3.jpg");
string _inceptionTensorFlowModel = Path.Combine(_assetsPath, "inception", "tensorflow_inception_graph.pb");
// </SnippetDeclareGlobalVariables>

// Create MLContext to be shared across the model creation workflow objects
// <SnippetCreateMLContext>
MLContext mlContext = new MLContext();
// </SnippetCreateMLContext>

// <SnippetCallGenerateModel>
ITransformer model = GenerateModel(mlContext);
// </SnippetCallGenerateModel>

// <SnippetCallClassifySingleImage>
ClassifySingleImage(mlContext, model);
// </SnippetCallClassifySingleImage>

// Build and train model
ITransformer GenerateModel(MLContext mlContext)
{
    // <SnippetImageTransforms>
    IEstimator<ITransformer> pipeline = mlContext.Transforms.LoadImages(outputColumnName: "input", imageFolder: _imagesFolder, inputColumnName: nameof(ImageData.ImagePath))
                    // The image transforms transform the images into the model's expected format.
                    .Append(mlContext.Transforms.ResizeImages(outputColumnName: "input", imageWidth: InceptionSettings.ImageWidth, imageHeight: InceptionSettings.ImageHeight, inputColumnName: "input"))
                    .Append(mlContext.Transforms.ExtractPixels(outputColumnName: "input", interleavePixelColors: InceptionSettings.ChannelsLast, offsetImage: InceptionSettings.Mean))
                    // </SnippetImageTransforms>
                    // The ScoreTensorFlowModel transform scores the TensorFlow model and allows communication
                    // <SnippetScoreTensorFlowModel>
                    .Append(mlContext.Model.LoadTensorFlowModel(_inceptionTensorFlowModel).
                        ScoreTensorFlowModel(outputColumnNames: new[] { "softmax2_pre_activation" }, inputColumnNames: new[] { "input" }, addBatchDimensionInput: true))
                    // </SnippetScoreTensorFlowModel>
                    // <SnippetMapValueToKey>
                    .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "LabelKey", inputColumnName: "Label"))
                    // </SnippetMapValueToKey>
                    // <SnippetAddTrainer>
                    .Append(mlContext.MulticlassClassification.Trainers.LbfgsMaximumEntropy(labelColumnName: "LabelKey", featureColumnName: "softmax2_pre_activation"))
                    // </SnippetAddTrainer>
                    // <SnippetMapKeyToValue>
                    .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabelValue", "PredictedLabel"))
                    .AppendCacheCheckpoint(mlContext);
    // </SnippetMapKeyToValue>

    // <SnippetLoadData>
    IDataView trainingData = mlContext.Data.LoadFromTextFile<ImageData>(path:  _trainTagsTsv, hasHeader: false);
    // </SnippetLoadData>

    // Train the model
    Console.WriteLine("=============== Training classification model ===============");
    // Create and train the model
    // <SnippetTrainModel>
    ITransformer model = pipeline.Fit(trainingData);
    // </SnippetTrainModel>

    // Generate predictions from the test data, to be evaluated
    // <SnippetLoadAndTransformTestData>
    IDataView testData = mlContext.Data.LoadFromTextFile<ImageData>(path: _testTagsTsv, hasHeader: false);
    IDataView predictions = model.Transform(testData);

    // Create an IEnumerable for the predictions for displaying results
    IEnumerable<ImagePrediction> imagePredictionData = mlContext.Data.CreateEnumerable<ImagePrediction>(predictions, true);
    DisplayResults(imagePredictionData);
    // </SnippetLoadAndTransformTestData>

    // Get performance metrics on the model using training data
    Console.WriteLine("=============== Classification metrics ===============");

    // <SnippetEvaluate>
    MulticlassClassificationMetrics metrics =
        mlContext.MulticlassClassification.Evaluate(predictions,
            labelColumnName: "LabelKey",
            predictedLabelColumnName: "PredictedLabel");
    // </SnippetEvaluate>

    //<SnippetDisplayMetrics>
    Console.WriteLine($"LogLoss is: {metrics.LogLoss}");
    Console.WriteLine($"PerClassLogLoss is: {String.Join(" , ", metrics.PerClassLogLoss.Select(c => c.ToString()))}");
    //</SnippetDisplayMetrics>

    // <SnippetReturnModel>
    return model;
    // </SnippetReturnModel>
}

void ClassifySingleImage(MLContext mlContext, ITransformer model)
{
    // load the fully qualified image file name into ImageData
    // <SnippetLoadImageData>
    var imageData = new ImageData()
    {
        ImagePath = _predictSingleImage
    };
    // </SnippetLoadImageData>

    // <SnippetPredictSingle>
    // Make prediction function (input = ImageData, output = ImagePrediction)
    var predictor = mlContext.Model.CreatePredictionEngine<ImageData, ImagePrediction>(model);
    var prediction = predictor.Predict(imageData);
    // </SnippetPredictSingle>

    Console.WriteLine("=============== Making single image classification ===============");
    // <SnippetDisplayPrediction>
    Console.WriteLine($"Image: {Path.GetFileName(imageData.ImagePath)} predicted as: {prediction.PredictedLabelValue} with score: {prediction.Score.Max()} ");
    // </SnippetDisplayPrediction>
}

void DisplayResults(IEnumerable<ImagePrediction> imagePredictionData)
{
    // <SnippetDisplayPredictions>
    foreach (ImagePrediction prediction in imagePredictionData)
    {
        Console.WriteLine($"Image: {Path.GetFileName(prediction.ImagePath)} predicted as: {prediction.PredictedLabelValue} with score: {prediction.Score.Max()} ");
    }
    // </SnippetDisplayPredictions>
}

// <SnippetInceptionSettings>
struct InceptionSettings
{
    public const int ImageHeight = 224;
    public const int ImageWidth = 224;
    public const float Mean = 117;
    public const float Scale = 1;
    public const bool ChannelsLast = true;
}
// </SnippetInceptionSettings>

// <SnippetDeclareImageData>
public class ImageData
{
    [LoadColumn(0)]
    public string ImagePath;

    [LoadColumn(1)]
    public string Label;
}
// </SnippetDeclareImageData>

// <SnippetDeclareImagePrediction>
public class ImagePrediction : ImageData
{
    public float[] Score;

    public string PredictedLabelValue;
}
// </SnippetDeclareImagePrediction>
