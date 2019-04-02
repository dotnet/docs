---
title: "How-To: Prepare Data with ML.NET"
description: Learn how to use transforms in ML.NET to manipulate and prepare data for additional processing or model building.
author: luisquintanilla
ms.author: luquinta
ms.date: 04/19/2019
ms.custom: mvc,how-to
#Customer intent: As a developer, I want to know how I can transform and prepare data with ML.NET using transforms
---

# How-To: Prepare Data with ML.NET

Learn how to use transformers in ML.NET to prepare data for additional processing or building a model.

Data can be messy. In addition, ML.NET machine learning algorithms require input to be a numerical vector. ML.NET provides various transforms to help clean your data and get it into the appropriate format. 

## Replace missing values

Missing values are a common occurrence in datasets. One approach to dealing with missing values is to replace them with a placeholder or another meaningful value such as the mean value in the data. 

Using the following input data which is loaded into an [`IDataView`](xref:Microsoft.ML.IDataView):

```csharp
HomeData[] homeDataList = new HomeData[]
{
    new HomeData
    {
        NumberOfBedrooms=1f,
        Price=100000f
    },
    new HomeData
    {
        NumberOfBedrooms=2f,
        Price=300000f
    },
    new HomeData
    {
        NumberOfBedrooms=6f,
        Price=float.NaN
    }
};
```

Notice that the last element in our list has a missing value for `Price`. To replace the missing values in the `Price` column, use the [`ReplaceMissingValues`](xref:Microsoft.ML.ExtensionsCatalog.ReplaceMissingValues*) method to fill in that missing value.

> [!IMPORTANT]
> [`ReplaceMissingValue`](xref:Microsoft.ML.ExtensionsCatalog.ReplaceMissingValues*) only works with numerical data.

```csharp
// Define replacement estimator
var replacementEstimator = mlContext.Transforms.ReplaceMissingValues("Price", replacementMode: MissingValueReplacingEstimator.ReplacementMode.Mean);

// Build transformer to perform operations
ITransformer replacementTransformer = replacementEstimator.Fit(data);

// Transform data
IDataView transformedData = replacementTransformer.Transform(data);
```

ML.NET supports various [replacement modes](xref:Microsoft.ML.Transforms.MissingValueReplacingEstimator.ReplacementMode). The sample above uses the `Mean` replacement mode which will fill in the missing value with that column's average value. The replacement
's result fills in the `Price` property for the last element in our data with 200,000 since it's the average of 100,000 and 300,000. 

## Filter data

Sometimes, not all data in a dataset is relevant for analysis. An approach to remove irrelevant data is filtering.

Using the following input data which is loaded into an [`IDataView`](xref:Microsoft.ML.IDataView):

```csharp
HomeData[] homeDataList = new HomeData[]
{
    new HomeData
    {
        NumberOfBedrooms=1f,
        Price=100000f
    },
    new HomeData
    {
        NumberOfBedrooms=2f,
        Price=300000f
    },
    new HomeData
    {
        NumberOfBedrooms=6f,
        Price=600000f
    }
};
```

To filter data based on the value of a column, use the [`FilterRowsByColumn`](xref:Microsoft.ML.DataOperationsCatalog.FilterRowsByColumn*) method.

```csharp
// Apply filter
IDataView filteredData = mlContext.Data.FilterRowsByColumn(data, "Price", lowerBound: 200000, upperBound: 1000000);
```

The sample above takes rows in the dataset with a price between 200000 and 1000000. The result of applying this filter would return only the last two rows in the data and exclude the first row because its price is 100000 and not between the specified range.

## Use normalizers

[Normalization](https://en.wikipedia.org/wiki/Feature_scaling) is a data pre-processing technique used to standardize features that are not on the same scale. For example, the ranges for values like age and income vary significantly with age generally being in the range of 0-100 and income generally being in the range of zero to thousands. Visit the [transforms page](../resources/transforms.md) for a more detailed list and description of normalization transforms. 

### Min-Max normalization

Using the following input data which is loaded into an [`IDataView`](xref:Microsoft.ML.IDataView):

```csharp
HomeData[] homeDataList = new HomeData[]
{
    new HomeData
    {
        NumberOfBedrooms = 2f,
        Price = 200000f
    },
    new HomeData
    {
        NumberOfBedrooms = 1f,
        Price = 100000f
    }
};
```

Normalize the data using min-max normalization using the [`NormalizeMinMax`](xref:Microsoft.ML.NormalizationCatalog.NormalizeMinMax*) method.

```csharp
// Define min-max estimator
var minMaxEstimator = mlContext.Transforms.NormalizeMinMax("Price");

// Build ITransformer that performs operation
ITransformer minMaxTransformer = minMaxEstimator.Fit(data);

// Transform data
IDataView transformedData = minMaxTransformer.Transform(data);
```

The original price values `[200000,100000]` are converted to `[ 1, 0.5 ]` using the `MinMax` normalization formula.

### Binning

[Binning](https://en.wikipedia.org/wiki/Data_binning) converts continuous values into a discrete representation. For example, suppose one of your features is age. Instead of using the actual age value, with binning you can create ranges for that value. 0-18 could be one bin, another could be 19-35 and so on. 

Using the following input data which is loaded into an [`IDataView`](xref:Microsoft.ML.IDataView):

```csharp
HomeData[] homeDataList = new HomeData[]
{
    new HomeData
    {
        NumberOfBedrooms=1f,
        Price=100000f
    },
    new HomeData
    {
        NumberOfBedrooms=2f,
        Price=300000f
    },
    new HomeData
    {
        NumberOfBedrooms=6f,
        Price=600000f
    }
};
```

Normalize the data into bins using the [`NormalizeBinning`](xref:Microsoft.ML.NormalizationCatalog.NormalizeBinning*) method. The `maximumBinCount` parameter enables you to specify the numer of bins needed to classify your data. In this example, data will be put into two bins.  

```csharp
// Define binning estimator
var binningEstimator = mlContext.Transforms.NormalizeBinning("Price", maximumBinCount: 2);

// Build ITransformer that performs operation
var binningTransformer = binningEstimator.Fit(data);

// Transform Data
IDataView transformedData = binningTransformer.Transform(data);
```

The result of binning creates bin bounds of `[0,200000,Infinity]`. Therefore the resulting bins are `[0,1,1]` because the first observation is between 0-200000 and the others are greater than 200000 but less than infinity.

## Work with categorical data

Non-numeric categorical data needs to be converted to a number before being used to build a machine learning model. 

Using the following input data which is loaded into an [`IDataView`](xref:Microsoft.ML.IDataView):

```csharp
CarData[] cars = new CarData[] 
{
    new CarData
    {
        Color="Red",
        VehicleType="SUV"
    },
    new CarData
    {
        Color="Blue",
        VehicleType="Sedan"
    },
    new CarData
    {
        Color="Black",
        VehicleType="SUV"
    }
};
```

The categorical `VehicleType` property can be converted into a number using the [`OneHotEncoding`](xref:Microsoft.ML.CategoricalCatalog.OneHotEncoding*) method. 

```csharp
// Define categorical transform estimator
var categoricalEstimator = mlContext.Transforms.Categorical.OneHotEncoding("VehicleType");

// Build ITransformer that performs operation
ITransformer categoricalTransformer = categoricalEstimator.Fit(data);

// Transform Data
IDataView transformedData = categoricalTransformer.Transform(data);
```

The resulting transform converts the text value of `VehicleType` to a number. The entries in the `VehicleType` column become the following when the transform is applied: 

```text
[
    1, // SUV
    2, // Sedan
    1 // SUV
]
```

## Work with text data

Text data needs to be transformed into numbers before using it to build a machine learning model. Visit the [transforms page](../resources/transforms.md) for a more detailed list and description of text transforms.

Using the following input data which is loaded into an [`IDataView`](xref:Microsoft.ML.IDataView):

```csharp
ReviewData[] reviews = new ReviewData[]
{
    new ReviewData
    {
        Description="This is a good product",
        Rating=4.7f
    },
    new ReviewData
    {
        Description="This is a bad product",
        Rating=2.3f
    }
};
```

The minimum step to convert text to a numerical vector representation is to use the [`FeaturizeText`](xref:Microsoft.ML.TextCatalog.FeaturizeText*) method.

```csharp
// Define text transform estimator
var textEstimator  = mlContext.Transforms.Text.FeaturizeText("Description");

// Build ITransformer that performs operation
ITransformer textTransformer = textEstimator.Fit(data);

// Transform data
IDataView transformedData = textTransformer.Transform(data);
```

The resulting transform would convert the text values in the `Description` column to a numerical vector that looks similar to the output below:

```text
[ 0.2041241, 0.2041241, 0.2041241, 0.4082483, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0, 0, 0, 0, 0.4472136, 0.4472136, 0.4472136, 0.4472136, 0.4472136, 0 ]
```

Combine complex text processing steps to remove noise and potentially reduce the amount of required processing resources as needed.

```csharp
// Define text transform estimator
var textEstimator = mlContext.Transforms.Text.NormalizeText("Description")
    .Append(mlContext.Transforms.Text.TokenizeIntoWords("Description"))
    .Append(mlContext.Transforms.Text.RemoveDefaultStopWords("Description"))
    .Append(mlContext.Transforms.Text.FeaturizeText("Description"));
```

Using the first entry as an example, the following is a detailed description of the results produced by the transformation steps defined in the previous code sample:

**Original Text: This is a good product**

|Transform | Description | Result
|--|--|--|
|1. NormalizeText |Converts all letters to lowercase by default | this is a good product
|2. TokenizeWords |Splits string into individual words | ["this","is","a","good","product"]
|3. RemoveDefaultStopWords |Removes stopwords like *is* and *a*. | ["good","product"]
|4. FeaturizeText |Converts text to numerical vector representation | [ 0.2886751, 0.2886751, 0.2886751, 0.2886751, 0.2886751, 0.2886751, 0.2886751, 0.2886751, 0.2886751, 0.2886751, 0.2886751, 0.2886751, 0, 0, 0, 0.7071068, 0.7071068, 0 ]