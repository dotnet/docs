// <Snippet1>
using Microsoft.ML;
using TaxiFarePrediction;
// </Snippet1>

// <Snippet2>
string _trainDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "taxi-fare-train.csv");
string _testDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "taxi-fare-test.csv");
string _modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "Model.zip");
// </Snippet2>

Console.WriteLine(Environment.CurrentDirectory);

// <Snippet3>
MLContext mlContext = new MLContext(seed: 0);
// </Snippet3>

// <Snippet5>
var model = Train(mlContext, _trainDataPath);
// </Snippet5>

// <Snippet14>
Evaluate(mlContext, model);
// </Snippet14>

// <Snippet20>
TestSinglePrediction(mlContext, model);
// </Snippet20>

ITransformer Train(MLContext mlContext, string dataPath)
{
    // <Snippet6>
    IDataView dataView = mlContext.Data.LoadFromTextFile<TaxiTrip>(dataPath, hasHeader: true, separatorChar: ',');
    // </Snippet6>

    // <Snippet7>
    var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName:"FareAmount")
    // </Snippet7>
            // <Snippet8>
            .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "VendorIdEncoded", inputColumnName:"VendorId"))
            .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "RateCodeEncoded", inputColumnName: "RateCode"))
            .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "PaymentTypeEncoded", inputColumnName: "PaymentType"))
            // </Snippet8>
            // <Snippet9>
            .Append(mlContext.Transforms.Concatenate("Features", "VendorIdEncoded", "RateCodeEncoded", "PassengerCount", "TripDistance", "PaymentTypeEncoded"))
            // </Snippet9>
            // <Snippet10>
            .Append(mlContext.Regression.Trainers.FastTree());
            // </Snippet10>

    Console.WriteLine("=============== Create and Train the Model ===============");

    // <Snippet11>
    var model = pipeline.Fit(dataView);
    // </Snippet11>

    Console.WriteLine("=============== End of training ===============");
    Console.WriteLine();
    // <Snippet12>
    return model;
    // </Snippet12>
}

void Evaluate(MLContext mlContext, ITransformer model)
{
    // <Snippet15>
    IDataView dataView = mlContext.Data.LoadFromTextFile<TaxiTrip>(_testDataPath, hasHeader: true, separatorChar: ',');
    // </Snippet15>

    // <Snippet16>
    var predictions = model.Transform(dataView);
    // </Snippet16>
    // <Snippet17>
    var metrics = mlContext.Regression.Evaluate(predictions, "Label", "Score");
    // </Snippet17>

    Console.WriteLine();
    Console.WriteLine($"*************************************************");
    Console.WriteLine($"*       Model quality metrics evaluation         ");
    Console.WriteLine($"*------------------------------------------------");
    // <Snippet18>
    Console.WriteLine($"*       RSquared Score:      {metrics.RSquared:0.##}");
    // </Snippet18>
    // <Snippet19>
    Console.WriteLine($"*       Root Mean Squared Error:      {metrics.RootMeanSquaredError:#.##}");
    // </Snippet19>
    Console.WriteLine($"*************************************************");
}

void TestSinglePrediction(MLContext mlContext, ITransformer model)
{
    //Prediction test
    // Create prediction function and make prediction.
    // <Snippet22>
    var predictionFunction = mlContext.Model.CreatePredictionEngine<TaxiTrip, TaxiTripFarePrediction>(model);
    // </Snippet22>
    //Sample:
    //vendor_id,rate_code,passenger_count,trip_time_in_secs,trip_distance,payment_type,fare_amount
    //VTS,1,1,1140,3.75,CRD,15.5
    // <Snippet23>
    var taxiTripSample = new TaxiTrip()
    {
        VendorId = "VTS",
        RateCode = "1",
        PassengerCount = 1,
        TripTime = 1140,
        TripDistance = 3.75f,
        PaymentType = "CRD",
        FareAmount = 0 // To predict. Actual/Observed = 15.5
    };
    // </Snippet23>
    // <Snippet24>
    var prediction = predictionFunction.Predict(taxiTripSample);
    // </Snippet24>
    // <Snippet25>
    Console.WriteLine($"**********************************************************************");
    Console.WriteLine($"Predicted fare: {prediction.FareAmount:0.####}, actual fare: 15.5");
    Console.WriteLine($"**********************************************************************");
    // </Snippet25>
}
