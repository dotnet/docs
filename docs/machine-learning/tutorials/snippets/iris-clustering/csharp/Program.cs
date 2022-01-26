// <SnippetMLUsings>
using Microsoft.ML;
using IrisFlowerClustering;
// </SnippetMLUsings>

// <SnippetPaths>
string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "iris.data");
string _modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "IrisClusteringModel.zip");
// </SnippetPaths>

// <SnippetCreateContext>
var mlContext = new MLContext(seed: 0);
// </SnippetCreateContext>

// <SnippetCreateDataView>
IDataView dataView = mlContext.Data.LoadFromTextFile<IrisData>(_dataPath, hasHeader: false, separatorChar: ',');
// </SnippetCreateDataView>

// <SnippetCreatePipeline>
string featuresColumnName = "Features";
var pipeline = mlContext.Transforms
    .Concatenate(featuresColumnName, "SepalLength", "SepalWidth", "PetalLength", "PetalWidth")
    .Append(mlContext.Clustering.Trainers.KMeans(featuresColumnName, numberOfClusters: 3));
// </SnippetCreatePipeline>

// <SnippetTrainModel>
var model = pipeline.Fit(dataView);
// </SnippetTrainModel>

// <SnippetSaveModel>
using (var fileStream = new FileStream(_modelPath, FileMode.Create, FileAccess.Write, FileShare.Write))
{
    mlContext.Model.Save(model, dataView.Schema, fileStream);
}
// </SnippetSaveModel>

// <SnippetPredictor>
var predictor = mlContext.Model.CreatePredictionEngine<IrisData, ClusterPrediction>(model);
// </SnippetPredictor>

// <SnippetPredictionExample>
var prediction = predictor.Predict(TestIrisData.Setosa);
Console.WriteLine($"Cluster: {prediction.PredictedClusterId}");
Console.WriteLine($"Distances: {string.Join(" ", prediction.Distances)}");
// </SnippetPredictionExample>
