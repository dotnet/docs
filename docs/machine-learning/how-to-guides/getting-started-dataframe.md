---
title: Getting started with DataFrames
description: Learn how to use DataFrame to manipulate and prepare data.
author: 
ms.author: beccam
ms.date: 1/13/2023
ms.custom: mvc, how-to, title-hack-0625
ms.topic: how-to
---

# What is the DataFrame?

Learn how to get started with DataFrames. [DataFrames](https://learn.microsoft.com/dotnet/api/microsoft.data.analysis.dataframe) are a two-dimensional data structure for storing and manipulating data. DataFrames help with preparation of data for a machine learning model. DataFrames can also be used for data manipulation unrelated to machine learning. 

# Install Microsoft.Data.Analysis

Add the Microsoft.Data.Analysis package.

# Load data

DataFrames make it easy to load tabular data. Create a comma-separated file called housing-prices.csv with the following data. 

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

# Inspect Data (Info/Describe)

DataFrames store data as a collection of columns. This makes it easy to interact with the data. To get a preview of the column datatypes, run `Info()`.

```csharp
dataFrame.Info();
```
# Transform Data

There are a variety of transformative options for data. The DataFrame and DataFrameColumn classes expose a number of useful APIs: binary operations, computations, joins, merges, handling missing values and more.

For example, this data can be edited to compare historical prices to current prices accounting for inflation. We can easily apply a computation to all of the values. 

```csharp
dataFrame["ComputedPrices"] = dataFrame["HistoricalPrice"].Multiply(2);
```

Data can be sorted into groups 

```csharp
var sortedDataFrame = dataFrame.GroupBy("Size");
```

Data can be filtered based on different equality metrics. This uses a ElementWise equality function, and then applies the boolean result column to the DataFrame to get a new, filtered DataFrame. 

```csharp
PrimitiveDataFrameColumn<bool> boolFilter = dataFrame["CurrentPrice"].ElementwiseGreaterThan(200000);
DataFrame filteredDataFrame = dataFrame.Filter(boolFilter);
```

# Combine Data Sources

```text
Id, Bedrooms	
1, 1	
2, 2	
3, 3	
4, 2	
5, 3	
6, 1
```
DataFrames can be constructed from individual data columns. Create a DataFrame from a list of the raw data above. 

```csharp
var ids = new List<Single>() {1,2,3,4,5,6};
var bedrooms = new List<Single>() {1, 2, 3, 2, 3, 1};

var idColumn = new SingleDataFrameColumn("Id", ids);
var bedroomColumn = new SingleDataFrameColumn("BedroomNumber", bedrooms);
var dataFrame2 = new DataFrame(idColumn, bedroomColumn);
```

The two DataFrames can be merged based on the Id value.

```csharp
dataFrame = dataFrame.Merge(dataFrame2, new string[] {"Id"}, new string[] {"Id"});
```

# Save DataFrames

Results can be saved back into a .csv format. 

```csharp
DataFrame.WriteCsv(dataFrame, "result.csv", ',');
```

# Use DataFrame with ML.NEt

DataFrames can also be easily used by ML.NET. 

```csharp
dataFrame.ToIDataView();
```
