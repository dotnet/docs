using Microsoft.ML;
using Microsoft.ML.Data;

class Program
{
    public record HouseData
    {
        public float Size { get; set; }
        public float Price { get; set; }
    }

    public record Prediction
    {
        [ColumnName("Score")]
        public float Price { get; set; }
    }

    static void Main(string[] args)
    {
        MLContext mlContext = new();

        // 1. Import or create training data.
        HouseData[] houseData = [
                new() { Size = 1.1F, Price = 1.2F },
                new() { Size = 1.9F, Price = 2.3F },
                new() { Size = 2.8F, Price = 3.0F },
                new() { Size = 3.4F, Price = 3.7F }
                ];
        IDataView trainingData = mlContext.Data.LoadFromEnumerable(houseData);

        // 2. Specify data preparation and model training pipeline.
        EstimatorChain<RegressionPredictionTransformer<Microsoft.ML.Trainers.LinearRegressionModelParameters>> pipeline = mlContext.Transforms.Concatenate("Features", ["Size"])
            .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: "Price", maximumNumberOfIterations: 100));

        // 3. Train model.
        TransformerChain<RegressionPredictionTransformer<Microsoft.ML.Trainers.LinearRegressionModelParameters>> model = pipeline.Fit(trainingData);

        // 4. Make a prediction.
        HouseData size = new() { Size = 2.5F };
        Prediction price = mlContext.Model.CreatePredictionEngine<HouseData, Prediction>(model).Predict(size);

        Console.WriteLine($"Predicted price for size: {size.Size * 1000} sq ft = {price.Price * 100:C}k");

        // Predicted price for size: 2500 sq ft = $261.98k
    }
}
