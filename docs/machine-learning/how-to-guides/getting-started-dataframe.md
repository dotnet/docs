---
title: Get started with DataFrames
description: Learn how to use DataFrame to manipulate and prepare data.
author: beccamc
ms.date: 3/10/2023
ms.custom: mvc, how-to, title-hack-0625
ms.topic: how-to
---

# Get started with DataFrames

Learn how to get started with [DataFrames](/dotnet/api/microsoft.data.analysis.dataframe), which are two-dimensional data structures for storing and manipulating data. DataFrames help with preparation of data for a machine learning model. DataFrames can also be used for data manipulation unrelated to machine learning.

## Install Microsoft.Data.Analysis

In most cases, accessing <xref:Microsoft.Data.Analysis.DataFrame> is as simple as referencing the [Microsoft.Data.Analysis](https://www.nuget.org/packages/Microsoft.Data.Analysis/) NuGet package.

```dotnetcli
dotnet package add Microsoft.Data.Analysis
```

## Load data

DataFrames make it easy to load tabular data. Create a comma-separated file called *housing-prices.csv* with the following data.

```text
Id,Size,HistoricalPrice,CurrentPrice
1,600f,100000,170000
2,1000f,200000,225000
3,1000f,126000,195000
4,850f,150000,205000
5,900f,155000,210000
6,550f,99000,180000
```

Start by loading the data into a DataFrame.

```csharp
using System.IO;
using System.Linq;
using Microsoft.Data.Analysis;

// Define data path
var dataPath = Path.GetFullPath(@"housing-prices.csv");

// Load the data into the data frame
var dataFrame = DataFrame.LoadCsv(dataPath);
```

## Inspect data

DataFrames store data as a collection of columns. This makes it easy to interact with the data.

To get a preview of the column datatypes, run <xref:Microsoft.Data.Analysis.DataFrame.Info>.

```csharp
dataFrame.Info();
```

To get a summary of the data, run <xref:Microsoft.Data.Analysis.DataFrame.Description>.

```csharp
dataFrame.Description();
```

## Transform data

There are a variety of transformative options for data. The <xref:Microsoft.Data.Analysis.DataFrame> and <xref:Microsoft.Data.Analysis.DataFrameColumn> classes expose a number of useful APIs including binary operations, computations, joins, merges, and handling missing values.

For example, this data can be edited to compare historical prices to current prices accounting for inflation. You can apply a computation to all of the values and save the results in a new column.

```csharp
dataFrame["ComputedPrices"] = dataFrame["HistoricalPrice"].Multiply(2);
```

Data can be sorted into groups from the values in a specific column.

```csharp
var sortedDataFrame = dataFrame.GroupBy("Size");
```

Data can be filtered based on different equality metrics. This example uses a [ElementWise](xref:Microsoft.Data.Analysis.DataFrame.ElementwiseGreaterThan``1(``0)) equality function, and then filters based on the Boolean result column to get a new DataFrame with only the appropriate values.

```csharp
PrimitiveDataFrameColumn<bool> boolFilter = dataFrame["CurrentPrice"].ElementwiseGreaterThan(200000);
DataFrame filteredDataFrame = dataFrame.Filter(boolFilter);
```

## Combine data sources

Consider the following raw data:

```text
Id, Bedrooms
1, 1
2, 2
3, 3
4, 2
5, 3
6, 1
```

DataFrames can be constructed from individual data columns. Create a DataFrame from a list of the raw data.

```csharp
var ids = new List<Single>() {1,2,3,4,5,6};
var bedrooms = new List<Single>() {1, 2, 3, 2, 3, 1};

var idColumn = new SingleDataFrameColumn("Id", ids);
var bedroomColumn = new SingleDataFrameColumn("BedroomNumber", bedrooms);
var dataFrame2 = new DataFrame(idColumn, bedroomColumn);
```

The two DataFrames can be merged based on the `Id` value. The merge function takes both DataFrames and combine rows based on their `Id` value.

```csharp
dataFrame = dataFrame.Merge(dataFrame2, new string[] {"Id"}, new string[] {"Id"});
```

## Save DataFrames

Results can be saved back into a .csv format.

```csharp
DataFrame.SaveCsv(dataFrame, "result.csv", ',');
```

## Use DataFrame with ML.NET

DataFrames work directly with ML.NET. DataFrame implements the <xref:Microsoft.ML.IDataView> and can be used to train a model.
