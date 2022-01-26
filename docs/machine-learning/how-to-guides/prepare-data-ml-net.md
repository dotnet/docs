---
title: Prepare data for building a model
description: Learn how to use transforms in ML.NET to manipulate and prepare data for additional processing or model building.
author: luisquintanilla
ms.author: luquinta
ms.date: 10/05/2021
ms.custom: mvc, how-to, title-hack-0625
ms.topic: how-to
#Customer intent: As a developer, I want to know how I can transform and prepare data with ML.NET
---

# Prepare data for building a model

Learn how to use ML.NET to prepare data for additional processing or building a model.

Data is often unclean and sparse. ML.NET machine learning algorithms expect input or features to be in a single numerical vector. Similarly, the value to predict (label), especially when it's categorical data, has to be encoded. Therefore one of the goals of data preparation is to get the data into the format expected by ML.NET algorithms.

## Filter data

Sometimes, not all data in a dataset is relevant for analysis. An approach to remove irrelevant data is filtering. The [`DataOperationsCatalog`](xref:Microsoft.ML.DataOperationsCatalog) contains a set of filter operations that take in an [`IDataView`](xref:Microsoft.ML.IDataView) containing all of the data and return an [IDataView](xref:Microsoft.ML.IDataView) containing only the data points of interest. It's important to note that because filter operations are not an [`IEstimator`](xref:Microsoft.ML.IEstimator%601) or [`ITransformer`](xref:Microsoft.ML.ITransformer) like those in the [`TransformsCatalog`](xref:Microsoft.ML.TransformsCatalog), they cannot be included as part of an [`EstimatorChain`](xref:Microsoft.ML.Data.EstimatorChain%601) or [`TransformerChain`](xref:Microsoft.ML.Data.TransformerChain%601) data preparation pipeline.

Take the following input data and load it into an [`IDataView`](xref:Microsoft.ML.IDataView) called `data`:

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

To filter data based on the value of a column, use the [`FilterRowsByColumn`](xref:Microsoft.ML.DataOperationsCatalog.FilterRowsByColumn%2A) method.

```csharp
// Apply filter
IDataView filteredData = mlContext.Data.FilterRowsByColumn(data, "Price", lowerBound: 200000, upperBound: 1000000);
```

The sample above takes rows in the dataset with a price between 200000 and 1000000. The result of applying this filter would return only the last two rows in the data and exclude the first row because its price is 100000 and not between the specified range.

## Replace missing values

Missing values are a common occurrence in datasets. One approach to dealing with missing values is to replace them with the default value for the given type if any or another meaningful value such as the mean value in the data.

Take the following input data and load it into an [`IDataView`](xref:Microsoft.ML.IDataView) called `data`:

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

Notice that the last element in our list has a missing value for `Price`. To replace the missing values in the `Price` column, use the [`ReplaceMissingValues`](xref:Microsoft.ML.ExtensionsCatalog.ReplaceMissingValues%2A) method to fill in that missing value.

> [!IMPORTANT]
> [`ReplaceMissingValue`](xref:Microsoft.ML.ExtensionsCatalog.ReplaceMissingValues%2A) only works with numerical data.

```csharp
// Define replacement estimator
var replacementEstimator = mlContext.Transforms.ReplaceMissingValues("Price", replacementMode: MissingValueReplacingEstimator.ReplacementMode.Mean);

// Fit data to estimator
// Fitting generates a transformer that applies the operations of defined by estimator
ITransformer replacementTransformer = replacementEstimator.Fit(data);

// Transform data
IDataView transformedData = replacementTransformer.Transform(data);
```

ML.NET supports various [replacement modes](xref:Microsoft.ML.Transforms.MissingValueReplacingEstimator.ReplacementMode). The sample above uses the `Mean` replacement mode, which fills in the missing value with that column's average value. The replacement
's result fills in the `Price` property for the last element in our data with 200,000 since it's the average of 100,000 and 300,000.

## Use normalizers

[Normalization](https://en.wikipedia.org/wiki/Feature_scaling) is a data pre-processing technique used to scale features to be in the same range, usually between 0 and 1, so that they can be more accurately processed by a machine learning algorithm. For example, the ranges for age and income vary significantly with age generally being in the range of 0-100 and income generally being in the range of zero to thousands. Visit the [transforms page](../resources/transforms.md) for a more detailed list and description of normalization transforms.

### Min-Max normalization

Take the following input data and load it into an [`IDataView`](xref:Microsoft.ML.IDataView) called `data`:

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

Normalization can be applied to columns with single numerical values as well as vectors. Normalize the data in the `Price` column using min-max normalization with the [`NormalizeMinMax`](xref:Microsoft.ML.NormalizationCatalog.NormalizeMinMax%2A) method.

```csharp
// Define min-max estimator
var minMaxEstimator = mlContext.Transforms.NormalizeMinMax("Price");

// Fit data to estimator
// Fitting generates a transformer that applies the operations of defined by estimator
ITransformer minMaxTransformer = minMaxEstimator.Fit(data);

// Transform data
IDataView transformedData = minMaxTransformer.Transform(data);
```

The original price values `[200000,100000]` are converted to `[ 1, 0.5 ]` using the `MinMax` normalization formula that generates output values in the range of 0-1.

### Binning

[Binning](https://en.wikipedia.org/wiki/Data_binning) converts continuous values into a discrete representation of the input. For example, suppose one of your features is age. Instead of using the actual age value,  binning creates ranges for that value. 0-18 could be one bin, another could be 19-35 and so on.

Take the following input data and load it into an [`IDataView`](xref:Microsoft.ML.IDataView) called `data`:

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

Normalize the data into bins using the [`NormalizeBinning`](xref:Microsoft.ML.NormalizationCatalog.NormalizeBinning%2A) method. The `maximumBinCount` parameter enables you to specify the number of bins needed to classify your data. In this example, data will be put into two bins.

```csharp
// Define binning estimator
var binningEstimator = mlContext.Transforms.NormalizeBinning("Price", maximumBinCount: 2);

// Fit data to estimator
// Fitting generates a transformer that applies the operations of defined by estimator
var binningTransformer = binningEstimator.Fit(data);

// Transform Data
IDataView transformedData = binningTransformer.Transform(data);
```

The result of binning creates bin bounds of `[0,200000,Infinity]`. Therefore the resulting bins are `[0,1,1]` because the first observation is between 0-200000 and the others are greater than 200000 but less than infinity.

## Work with categorical data

One of the most common types of data is categorical data. Categorical data has a finite number of categories. For example, the states of the USA, or a list of the types of animals found in a set of pictures. Whether the categorical data are features or labels, they must be mapped onto a numerical value so they can be used to generate a machine learning model. There are a number of ways of working with categorical data in ML.NET, depending on the problem you are solving.

### Key value mapping

In ML.NET, a key is an integer value that represents a category. Key value mapping is most often used to map string labels into unique integer values for training, then back to their string values when the model is used to make a prediction.

The transforms used to perform key value mapping are [MapValueToKey](xref:Microsoft.ML.ConversionsExtensionsCatalog.MapValueToKey%2A) and [MapKeyToValue](xref:Microsoft.ML.ConversionsExtensionsCatalog.MapKeyToValue%2A).

`MapValueToKey` adds a dictionary of mappings in the model, so that `MapKeyToValue` can perform the reverse transform when making a prediction.

### One hot encoding

One hot encoding takes a finite set of values and maps them onto integers whose binary representation has a single `1` value in unique positions in the string. One hot encoding can be the best choice if there is no implicit ordering of the categorical data. The following table shows an example with zip codes as raw values.

|Raw value|One hot encoded value|
|---------|---------------------|
|98052|00...01|
|98100|00...10|
|...|...|
|98109|10...00|

The transform to convert categorical data to one-hot encoded numbers is [`OneHotEncoding`](xref:Microsoft.ML.CategoricalCatalog.OneHotEncoding%2A).

### Hashing

Hashing is another way to convert categorical data to numbers. A hash function maps data of an arbitrary size (a string of text for example) onto a number with a fixed range. Hashing can be a fast and space-efficient way of vectorizing features. One notable example of hashing in machine learning is email spam filtering where, instead of maintaining a dictionary of known words, every word in the email is hashed and added to a large feature vector. Using hashing in this way avoids the problem of malicious spam filtering circumvention by the use of words that are not in the dictionary.

ML.NET provides [Hash](xref:Microsoft.ML.ConversionsExtensionsCatalog.Hash%2A) transform to perform hashing on text, dates, and numerical data. Like value key mapping, the outputs of the hash transform are key types.

## Work with text data

Like categorical data, text data needs to be transformed into numerical features before using it to build a machine learning model. Visit the [transforms page](../resources/transforms.md) for a more detailed list and description of text transforms.

Using data like the data below that has been loaded into an [`IDataView`](xref:Microsoft.ML.IDataView):

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

ML.NET provides the [`FeaturizeText`](xref:Microsoft.ML.TextCatalog.FeaturizeText%2A) transform that takes a text's string value and creates a set of features from the text, by applying a series of individual transforms.

```csharp
// Define text transform estimator
var textEstimator  = mlContext.Transforms.Text.FeaturizeText("Description");

// Fit data to estimator
// Fitting generates a transformer that applies the operations of defined by estimator
ITransformer textTransformer = textEstimator.Fit(data);

// Transform data
IDataView transformedData = textTransformer.Transform(data);
```

The resulting transform converts the text values in the `Description` column to a numerical vector that looks similar to the output below:

```text
[ 0.2041241, 0.2041241, 0.2041241, 0.4082483, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0.2041241, 0, 0, 0, 0, 0.4472136, 0.4472136, 0.4472136, 0.4472136, 0.4472136, 0 ]
```

The transforms that make up `FeaturizeText` can also be applied individually for finer grain control over feature generation.

```csharp
// Define text transform estimator
var textEstimator = mlContext.Transforms.Text.NormalizeText("Description")
    .Append(mlContext.Transforms.Text.TokenizeIntoWords("Description"))
    .Append(mlContext.Transforms.Text.RemoveDefaultStopWords("Description"))
    .Append(mlContext.Transforms.Conversion.MapValueToKey("Description"))
    .Append(mlContext.Transforms.Text.ProduceNgrams("Description"))
    .Append(mlContext.Transforms.NormalizeLpNorm("Description"));
```

`textEstimator` contains a subset of operations performed by the [`FeaturizeText`](xref:Microsoft.ML.TextCatalog.FeaturizeText%2A) method. The benefit of a more complex pipeline is control and visibility over the transformations applied to the data.

Using the first entry as an example, the following is a detailed description of the results produced by the transformation steps defined by `textEstimator`:

**Original Text: This is a good product**

|Transform | Description | Result
|--|--|--|
|1. NormalizeText | Converts all letters to lowercase by default | this is a good product
|2. TokenizeWords | Splits string into individual words | ["this","is","a","good","product"]
|3. RemoveDefaultStopWords | Removes stopwords like *is* and *a*. | ["good","product"]
|4. MapValueToKey | Maps the values to keys (categories) based on the input data |  [1,2]
|5. ProduceNGrams | Transforms text into sequence of consecutive words | [1,1,1,0,0]
|6. NormalizeLpNorm | Scale inputs by their lp-norm | [ 0.577350529, 0.577350529, 0.577350529, 0, 0 ]
