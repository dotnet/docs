---
title: 'Tutorial: Detect anomalies in phone calls'
description: Learn how to build an anomaly detection application for time series data. This tutorial creates a .NET Core console application using C# in Visual Studio 2019.
ms.date: 07/28/2021
ms.topic: tutorial
ms.custom: mvc
recommendations: false
#Customer intent: As a developer, I want to use ML.NET in a time-series anomaly detection for number of phone calls so that I can analyze the data for anomaly points to take the appropriate action.
---
# Tutorial: Detect anomalies in time series with ML.NET

Learn how to build an anomaly detection application for time series data. This tutorial creates a .NET Core console application using C# in Visual Studio 2019.

In this tutorial, you learn how to:
> [!div class="checklist"]
>
> * Load the data
> * Detect period for a time series
> * Detect anomaly for a periodical time series

You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/main/machine-learning/tutorials/PhoneCallsAnomalyDetection) repository.

## Prerequisites

* [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) with the ".NET Desktop Development" workload installed.

* [The phone-calls.csv dataset](https://github.com/dotnet/machinelearning-samples/blob/main/samples/csharp/getting-started/AnomalyDetection_PhoneCalls/SrEntireDetection/Data/phone-calls.csv).

## Create a console application

1. Create a C# **Console Application** called "PhoneCallsAnomalyDetection". Click the **Next** button.

2. Choose .NET 6 as the framework to use. Click the **Create** button.

3. Create a directory named *Data* in your project to save your data set files.

4. Install the **Microsoft.ML NuGet Package** version **1.5.2**:

    1. In Solution Explorer, right-click on your project and select **Manage NuGet Packages**.
    1. Choose "nuget.org" as the Package source.
    1. Select the **Browse** tab.
    1. Search for **Microsoft.ML**.
    1. Select **Microsoft.ML** from the list of packages and choose version **1.5.2** from the **Version** dropdown.
    1. Select the **Install** button.
    1. Select the **OK** button on the **Preview Changes** dialog and then select the **I Accept** button on the **License Acceptance** dialog if you agree with the license terms for the packages listed.

    Repeat these steps for **Microsoft.ML.TimeSeries** version **1.5.2**.

5. Add the following `using` statements at the top of your *Program.cs* file:

    [!code-csharp[AddUsings](./snippets/phone-calls-anomaly-detection/csharp/Program.cs#AddUsings "Add necessary usings")]

### Download your data

1. Download the dataset and save it to the *Data* folder you previously created:

    Right click on [*phone-calls.csv*](https://raw.githubusercontent.com/dotnet/machinelearning-samples/main/samples/csharp/getting-started/AnomalyDetection_PhoneCalls/SrEntireDetection/Data/phone-calls.csv) and select "Save Link (or Target) As..."

     Make sure you either save the \*.csv file to the *Data* folder, or after you save it elsewhere, move the \*.csv file to the *Data* folder.

2. In Solution Explorer, right-click the \*.csv file and select **Properties**. Under **Advanced**, change the value of **Copy to Output Directory** to **Copy if newer**.

The following table is a data preview from your \*.csv file:

| timestamp  | value |
|--------|--------------|
| 2018/9/3  | 36.69670857  |
| 2018/9/4  | 35.74160571  |
| .....  | .....  |
| 2018/10/3  | 34.49893429  |
| ...    | ....   |

This file represents a time-series. Each row in the file is a data point. Each data point has two attributes, namely, `timestamp` and `value`, to represent the number of phone calls at each day. The number of phone calls is transformed to de-sensitivity.

### Create classes and define paths

Next, define your input and prediction class data structures.

Add a new class to your project:

1. In **Solution Explorer**, right-click the project, and then select **Add > New Item**.

2. In the **Add New Item dialog box**, select **Class** and change the **Name** field to *PhoneCallsData.cs*. Then, select the **Add** button.

   The *PhoneCallsData.cs* file opens in the code editor.

3. Add the following `using` statement to the top of *PhoneCallsData.cs*:

   ```csharp
   using Microsoft.ML.Data;
   ```

4. Remove the existing class definition and add the following code, which has two classes `PhoneCallsData` and `PhoneCallsPrediction`, to the *PhoneCallsData.cs* file:

    [!code-csharp[DeclareTypes](./snippets/phone-calls-anomaly-detection/csharp/PhoneCallsData.cs#DeclareTypes "Declare data record types")]

    `PhoneCallsData` specifies an input data class. The [LoadColumn](xref:Microsoft.ML.Data.LoadColumnAttribute.%23ctor%28System.Int32%29) attribute specifies which columns (by column index) in the dataset should be loaded. It has two attributes `timestamp` and `value` that correspond to the same attributes in the data file.

    `PhoneCallsPrediction` specifies the prediction data class. For SR-CNN detector, the prediction depends on the [detect mode](xref:Microsoft.ML.TimeSeries.SrCnnDetectMode) specified. In this sample, we select the `AnomalyAndMargin` mode. The output contains seven columns. In most cases, `IsAnomaly`, `ExpectedValue`, `UpperBoundary`, and `LowerBoundary` are informative enough. They tell you if a point is an anomaly, the expected value of the point and the lower / upper boundary region of the point.

5. Add the following code to the line right below the using statements to specify the path to your data file:

    [!code-csharp[Declare global variables](./snippets/phone-calls-anomaly-detection/csharp/Program.cs#DeclareGlobalVariables "Declare global variables")]

### Initialize variables

1. Replace the `Console.WriteLine("Hello World!")` line with the following code to declare and initialize the `mlContext` variable:

    [!code-csharp[CreateMLContext](./snippets/phone-calls-anomaly-detection/csharp/Program.cs#CreateMLContext "Create the ML Context")]

    The [MLContext class](xref:Microsoft.ML.MLContext) is a starting point for all ML.NET operations, and initializing `mlContext` creates a new ML.NET environment that can be shared across the model creation workflow objects. It's similar, conceptually, to `DBContext` in Entity Framework.

### Load the data

Data in ML.NET is represented as an [IDataView interface](xref:Microsoft.ML.IDataView). `IDataView` is a flexible, efficient way of describing tabular data (numeric and text). Data can be loaded from a text file or from other sources (for example, SQL database or log files) to an `IDataView` object.

1. Add the following code below the creation of the `mlContext` variable:

    [!code-csharp[LoadData](./snippets/phone-calls-anomaly-detection/csharp/Program.cs#LoadData "loading dataset")]

    The [LoadFromTextFile()](xref:Microsoft.ML.TextLoaderSaverCatalog.LoadFromTextFile%60%601%28Microsoft.ML.DataOperationsCatalog,System.String,System.Char,System.Boolean,System.Boolean,System.Boolean,System.Boolean%29) defines the data schema and reads in the file. It takes in the data path variables and returns an `IDataView`.

## Time series anomaly detection

Time series anomaly detection is the process of detecting time-series data outliers; points on a given input time-series where the behavior isn't what was expected, or "weird". These anomalies are typically indicative of some events of interest in the problem domain: a cyber-attack on user accounts, power outage, bursting RPS on a server, memory leak, etc.

To find anomaly on time series, you should first determine the period of the series. Then, the time series can be decomposed into several components as `Y = T + S + R`, where `Y` is the original series, `T` is the trend component, `S` is the seasonal component, and `R` is the residual component of the series. This step is called [decomposition](https://en.wikipedia.org/wiki/Decomposition_of_time_series). Finally, detection is performed on the residual component to find the anomalies. In ML.NET, The SR-CNN algorithm is an advanced and novel algorithm that is based on Spectral Residual (SR) and Convolutional Neural Network(CNN) to detect anomaly on time-series. For more information on this algorithm, see [Time-Series Anomaly Detection Service at Microsoft](https://arxiv.org/pdf/1906.03821.pdf).

In this tutorial, you will see that these procedures can be completed using two functions.

## Detect Period

In the first step, we invoke the `DetectSeasonality` function to determine the period of the series.

### Create the DetectPeriod method

1. Create the `DetectPeriod` method at the bottom of the **Program.cs** file using the following code:

    ```csharp
    int DetectPeriod(MLContext mlContext, IDataView phoneCalls)
    {

    }
    ```

2. Use the <xref:Microsoft.ML.TimeSeriesCatalog.DetectSeasonality%2A> function to detect period. Add it to the `DetectPeriod` method with the following code:

    [!code-csharp[DetectSeasonality](./snippets/phone-calls-anomaly-detection/csharp/Program.cs#DetectSeasonality)]

3. Display the period value by adding the following as the next line of code in the `DetectPeriod` method:

    [!code-csharp[DisplayPeriod](./snippets/phone-calls-anomaly-detection/csharp/Program.cs#DisplayPeriod)]

4. Return the period value.

    [!code-csharp[ReturnPeriod](./snippets/phone-calls-anomaly-detection/csharp/Program.cs#L52)]

5. Add the following call to the `DetectPeriod` method below the call to the `LoadFromTextFile()` method:

    [!code-csharp[CallDetectPeriod](./snippets/phone-calls-anomaly-detection/csharp/Program.cs#CallDetectPeriod)]

### Period detection results

Run the application. Your results should be similar to the following.

```console
Period of the series is: 7.
```

## Detect Anomaly

In this step, you use the <xref:Microsoft.ML.TimeSeriesCatalog.DetectEntireAnomalyBySrCnn%2A> method to find anomalies.

### Create the DetectAnomaly method

1. Create the `DetectAnomaly` method, just below the `DetectPeriod` method, using the following code:

    ```csharp
    void DetectAnomaly(MLContext mlContext, IDataView phoneCalls, int period)
    {

    }
    ```

2. Set up <xref:Microsoft.ML.TimeSeries.SrCnnEntireAnomalyDetectorOptions> in the `DetectAnomaly` method with the following code:

    [!code-csharp[SetupSrCnnParameters](./snippets/phone-calls-anomaly-detection/csharp/Program.cs#SetupSrCnnParameters)]

3. Detect anomaly by SR-CNN algorithm by adding the following line of code in the `DetectAnomaly` method:

    [!code-csharp[DetectAnomaly](./snippets/phone-calls-anomaly-detection/csharp/Program.cs#DetectAnomaly)]

4. Convert the output data view into a strongly typed `IEnumerable` for easier display using the [`CreateEnumerable`](xref:Microsoft.ML.DataOperationsCatalog.CreateEnumerable%2A) method with the following code:

    [!code-csharp[CreateEnumerableForResult](./snippets/phone-calls-anomaly-detection/csharp/Program.cs#CreateEnumerableForResult)]

5. Create a display header with the following code as the next line in the `DetectAnomaly` method:

    [!code-csharp[DisplayHeader](./snippets/phone-calls-anomaly-detection/csharp/Program.cs#DisplayHeader)]

    You'll display the following information in your change point detection results:

    * `Index` is the index of each point.
    * `Anomaly` is the indicator of whether each point is detected as anomaly.
    * `ExpectedValue` is the estimated value of each point.
    * `LowerBoundary` is the lowest value each point can be to be not anomaly.
    * `UpperBoundary` is the highest value each point can be to be not anomaly.

6. Iterate through the `predictions` `IEnumerable` and display the results with the following code:

    [!code-csharp[DisplayAnomalyDetectionResults](./snippets/phone-calls-anomaly-detection/csharp/Program.cs#DisplayAnomalyDetectionResults)]

7. Add the following call to the `DetectAnomaly` method below the `DetectPeriod()` method call:

    [!code-csharp[CallDetectAnomaly](./snippets/phone-calls-anomaly-detection/csharp/Program.cs#CallDetectAnomaly)]

## Anomaly detection results

Run the application. Your results should be similar to the following. During processing, messages are displayed. You may see warnings or processing messages. Some messages have been removed from the following results for clarity.

```console
Detect period of the series
Period of the series is: 7.
Detect anomaly points in the series
Index   Data    Anomaly AnomalyScore    Mag     ExpectedValue   BoundaryUnit    UpperBoundary   LowerBoundary
0,0,36.841787256739266,41.14206982401966,32.541504689458876
1,0,35.67303618137362,39.97331874865401,31.372753614093227
2,0,34.710132999891826,39.029491313022824,30.390774686760828
3,0,33.44765248883495,37.786086547816545,29.10921842985335
4,0,28.937110922276364,33.25646923540736,24.61775260914537
5,0,5.143895892785781,9.444178460066171,0.843613325505391
6,0,5.163325228419392,9.463607795699783,0.8630426611390014
7,0,36.76414836240396,41.06443092968435,32.46386579512357
8,0,35.77908590657007,40.07936847385046,31.478803339289676
9,0,34.547259536635245,38.847542103915636,30.246976969354854
10,0,33.55193524820608,37.871293561337076,29.23257693507508
11,0,29.091800129624648,33.392082696905035,24.79151756234426
12,0,5.154836630338823,9.455119197619213,0.8545540630584334
13,0,5.234332502492464,9.534615069772855,0.934049935212073
14,0,36.54992549471526,40.85020806199565,32.24964292743487
15,0,35.79526470980883,40.095547277089224,31.494982142528443
16,0,34.34099013096804,38.64127269824843,30.040707563687647
17,0,33.61201516582131,37.9122977331017,29.31173259854092
18,0,29.223563320561812,33.5238458878422,24.923280753281425
19,0,5.170512168851533,9.470794736131923,0.8702296015711433
20,0,5.2614938889462834,9.561776456226674,0.9612113216658926
21,0,36.37103858487317,40.67132115215356,32.07075601759278
22,0,35.813544599026855,40.113827166307246,31.513262031746464
23,0,34.05600492733225,38.356287494612644,29.755722360051863
24,0,33.65828319077884,37.95856575805923,29.358000623498448
25,0,29.381125690882463,33.681408258162854,25.080843123602072
26,0,5.261543539820418,9.561826107100808,0.9612609725400283
27,0,5.4873712582971805,9.787653825577571,1.1870886910167897
28,1,36.504694001629254,40.804976568909645,32.20441143434886  <-- alert is on, detected anomaly
...
```

Congratulations! You've now successfully built machine learning models for detecting period and anomaly on a periodical series.

You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/main/machine-learning/tutorials/PhoneCallsAnomalyDetection) repository.

In this tutorial, you learned how to:
> [!div class="checklist"]
>
> * Load the data
> * Detect period on the time series data
> * Detect anomaly on the time series data

## Next steps

Check out the Machine Learning samples GitHub repository to explore a Power Consumption Anomaly Detection sample.
> [!div class="nextstepaction"]
> [dotnet/machinelearning-samples GitHub repository](https://github.com/dotnet/machinelearning-samples/tree/main/samples/csharp/getting-started/AnomalyDetection_PowerMeterReadings)
