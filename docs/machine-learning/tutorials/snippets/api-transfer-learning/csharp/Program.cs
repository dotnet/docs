// <SnippetUsings>
using Microsoft.ML;
using Microsoft.ML.Vision;
using static Microsoft.ML.DataOperationsCatalog;
// </SnippetUsings>

// <SnippetContext>
var projectDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../"));
var assetsRelativePath = Path.Combine(projectDirectory, "Assets");

MLContext mlContext = new();
// </SnippetContext>

// <SnippetSplit>
IEnumerable<ImageData> images = LoadImagesFromDirectory(folder: assetsRelativePath, useFolderNameAsLabel: true);

IDataView imageData = mlContext.Data.LoadFromEnumerable(images);

IDataView shuffledData = mlContext.Data.ShuffleRows(imageData);

var preprocessingPipeline = mlContext.Transforms.Conversion.MapValueToKey(
        inputColumnName: "Label",
        outputColumnName: "LabelAsKey")
    .Append(mlContext.Transforms.LoadRawImageBytes(
        outputColumnName: "Image",
        imageFolder: assetsRelativePath,
        inputColumnName: "ImagePath"));

IDataView preProcessedData = preprocessingPipeline
                    .Fit(shuffledData)
                    .Transform(shuffledData);

TrainTestData trainSplit = mlContext.Data.TrainTestSplit(data: preProcessedData, testFraction: 0.3);
TrainTestData validationTestSplit = mlContext.Data.TrainTestSplit(trainSplit.TestSet);

IDataView trainSet = trainSplit.TrainSet;
IDataView validationSet = validationTestSplit.TrainSet;
IDataView testSet = validationTestSplit.TestSet;
// </SnippetSplit>

// <SnippetTrain>
var classifierOptions = new ImageClassificationTrainer.Options()
{
    FeatureColumnName = "Image",
    LabelColumnName = "LabelAsKey",
    ValidationSet = validationSet,
    Arch = ImageClassificationTrainer.Architecture.ResnetV2101,
    MetricsCallback = (metrics) => Console.WriteLine(metrics),
    TestOnTrainSet = false,
    ReuseTrainSetBottleneckCachedValues = true,
    ReuseValidationSetBottleneckCachedValues = true
};

var trainingPipeline = mlContext.MulticlassClassification.Trainers.ImageClassification(classifierOptions)
    .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

ITransformer trainedModel = trainingPipeline.Fit(trainSet);
// </SnippetTrain>

// <SnippetSingle>
ClassifySingleImage(mlContext, testSet, trainedModel);
// </SnippetSingle>

// <SnippetMultiple>
ClassifyImages(mlContext, testSet, trainedModel);
// </SnippetMultiple>

// <SnippetClassifySingle>
static void ClassifySingleImage(MLContext mlContext, IDataView data, ITransformer trainedModel)
{
    PredictionEngine<ModelInput, ModelOutput> predictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(trainedModel);

    ModelInput image = mlContext.Data.CreateEnumerable<ModelInput>(data, reuseRowObject: true).First();

    ModelOutput prediction = predictionEngine.Predict(image);

    Console.WriteLine("Classifying single image");
    OutputPrediction(prediction);
}
// </SnippetClassifySingle>

// <SnippetClassifyMultiple>
static void ClassifyImages(MLContext mlContext, IDataView data, ITransformer trainedModel)
{
    IDataView predictionData = trainedModel.Transform(data);

    IEnumerable<ModelOutput> predictions = mlContext.Data.CreateEnumerable<ModelOutput>(predictionData, reuseRowObject: true).Take(10);

    Console.WriteLine("Classifying multiple images");
    foreach (var prediction in predictions)
    {
        OutputPrediction(prediction);
    }
}
// </SnippetClassifyMultiple>

// <SnippetOutput>
static void OutputPrediction(ModelOutput prediction)
{
    string? imageName = Path.GetFileName(prediction.ImagePath);
    Console.WriteLine($"Image: {imageName} | Actual Value: {prediction.Label} | Predicted Value: {prediction.PredictedLabel}");
}
// </SnippetOutput>

// <SnippetLoadImages>
static IEnumerable<ImageData> LoadImagesFromDirectory(string folder, bool useFolderNameAsLabel = true)
{
    var files = Directory.GetFiles(folder, "*",
        searchOption: SearchOption.AllDirectories);

    foreach (var file in files)
    {
        if ((Path.GetExtension(file) != ".jpg") && (Path.GetExtension(file) != ".png"))
            continue;

        var label = Path.GetFileName(file);

        if (useFolderNameAsLabel)
            label = Directory.GetParent(file)?.Name;
        else
        {
            for (int index = 0; index < label.Length; index++)
            {
                if (!char.IsLetter(label[index]))
                {
                    label = label[..index];
                    break;
                }
            }
        }

        yield return new ImageData()
        {
            ImagePath = file,
            Label = label
        };
    }
}
// </SnippetLoadImages>

// <SnippetImageData>
class ImageData
{
    public string? ImagePath { get; set; }
    public string? Label { get; set; }
}
// </SnippetImageData>

// <SnippetModelInput>
class ModelInput
{
    public byte[]? Image { get; set; }
    public uint LabelAsKey { get; set; }
    public string? ImagePath { get; set; }
    public string? Label { get; set; }
}
// </SnippetModelInput>

// <SnippetModelOutput>
class ModelOutput
{
    public string? ImagePath { get; set; }
    public string? Label { get; set; }
    public string? PredictedLabel { get; set; }
}
// </SnippetModelOutput>
