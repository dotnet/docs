---
title: Inspect intermediate data values during ML.NET processing
description: Learn how to inspect actual intermediate data values during ML.NET machine learning pipeline processing
ms.date: 04/17/2019
author: luisquintanilla
ms.author: luquinta
ms.custom: mvc,how-to
#Customer intent: As a developer, I want to inspect actual intermediate data values during ML.NET machine learning pipeline processing so that I can make sure that I'm getting the results I expect.
---

# Inspect intermediate data values during processing

Learn how to inspect values during loading, processing and training steps in ML.NET.

Data like the one represented below which is loaded into an [`IDataView`](xref:Microsoft.ML.IDataView) can be inspected in various ways in ML.NET.
 
```csharp
HousingData[] housingData = new HousingData[]
{
    new HousingData
    {
        Size = 600f,
        HistoricalPrices = new float[] { 100000f ,125000f ,122000f },
        CurrentPrice = 170000f
    },
    new HousingData
    {
        Size = 1000f,
        HistoricalPrices = new float[] { 200000f, 250000f, 230000f },
        CurrentPrice = 225000f
    },
    new HousingData
    {
        Size = 1000f,
        HistoricalPrices = new float[] { 126000f, 130000f, 200000f },
        CurrentPrice = 195000f
    },
    new HousingData
    {
        Size = 850f,
        HistoricalPrices = new float[] { 150000f,175000f,210000f },
        CurrentPrice = 205000f
    },
    new HousingData
    {
        Size = 900f,
        HistoricalPrices = new float[] { 155000f, 190000f, 220000f },
        CurrentPrice = 210000f
    },
    new HousingData
    {
        Size = 550f,
        HistoricalPrices = new float[] { 99000f, 98000f, 130000f },
        CurrentPrice = 180000f
    }
};
```

## Convert IDataView to IEnumerable

One of the simplest ways to inspect the values of an IDataView is to convert it to an [`IEnumerable`](xref:System.Collections.Generic.IEnumerable`1). To convert an [`IDataView`](xref:Microsoft.ML.IDataView) to [`IEnumerable`](xref:System.Collections.Generic.IEnumerable`1) use the [`CreateEnumerable`](xref:Microsoft.ML.DataOperationsCatalog.CreateEnumerable*) method.

> [!WARNING]
> [`CreateEnumerable`](xref:Microsoft.ML.DataOperationsCatalog.CreateEnumerable*) will load the entire [`IDataView`](xref:Microsoft.ML.IDataView) into memory which may affect performance.

```csharp
// Create an IEnumerable from IDataView
HousingData[] housingDataEnumerable =
    mlContext.Data.CreateEnumerable<HousingData>(data, reuseRowObject: false).ToArray();

// Get first element of IEnumerable
HousingData firstRow = housingDataEnumerable[0];
```

## Inspect values in a single column

At any point in the process, values in a single column of an [`IDataView`](xref:Microsoft.ML.IDataView) can be accessed using the [`GetColumn`](xref:Microsoft.ML.Data.ColumnCursorExtensions.GetColumn*) method. The [`GetColumn`](xref:Microsoft.ML.Data.ColumnCursorExtensions.GetColumn*) method returns all of the values in a single column as an [`IEnumerable`](xref:System.Collections.Generic.IEnumerable`1)

```csharp
IEnumerable<float> sizeColumn = data.GetColumn<float>("Size").ToList();
```

## Inspect values one row at a time

[`IDataView`](xref:Microsoft.ML.IDataView) is lazily evaluated. To iterate over the rows, create a [`DataViewRowCursor`](xref:Microsoft.ML.DataViewRowCursor) by using the [`GetRowCursor`](xref:Microsoft.ML.IDataView.GetRowCursor*) method and passing in the [DataViewSchema](xref:Microsoft.ML.DataViewSchema) of your [`IDataView`](xref:Microsoft.ML.IDataView) as a parameter. Then, to iterate over rows, use the [`MoveNext`](xref:Microsoft.ML.DataViewRowCursor.MoveNext*) cursor method. 

```csharp

DataViewSchema columns = data.Schema;

using (DataViewRowCursor cursor = data.GetRowCursor(columns))
{
    float size = default;
    VBuffer<float> historicalPrices = default;
    float currentPrice = default;

    while (cursor.MoveNext())
    {
        cursor.GetGetter<float>(columns[0]).Invoke(ref size);
        cursor.GetGetter<VBuffer<float>>(columns[1]).Invoke(ref historicalPrices);
        cursor.GetGetter<float>(columns[2]).Invoke(ref currentPrice);
    }
}
```

> [!IMPORTANT]
> For performance purposes, vectors in ML.NET use [`VBuffer`](xref:Microsoft.ML.Data.VBuffer`1) instead of native collection types (i.e. Vector,float[]). 

## Preview result of pre-processing or training on a subset of the data

The model building process is experimental and iterative. To preview what data would look like after pre-processing or training a machine learning model on a subset of the data, use the [`Preview`](xref:Microsoft.ML.DebuggerExtensions.Preview*) method which returns a [`DataDebuggerPreview`](xref:Microsoft.ML.Data.DataDebuggerPreview). The result is an object with `ColumnView` and `RowView` properties which are both an [`IEnumerable`](xref:System.Collections.Generic.IEnumerable`1) and contain the values in a particular column or row. Specify the number of rows to apply the transformation to with the `maxRows` parameter.

![Data Debugger Preview Object](./media/inspect-intermediate-data-ml-net/data-debugger-preview-01.png)

### Preview contents of an IDataView

The snippet below takes an [`IDataView`](xref:Microsoft.ML.IDataView) inspects the contents of the rows and columns.

```csharp
// Preview IDataView
DataDebuggerPreview dataPreview = data.Preview(maxRows:5);
```

![Data Debugger Preview Row View](./media/inspect-intermediate-data-ml-net/data-debugger-preview-02.png)

### Preview results after applying data pre-processing transformations

Call the [`Preview`](xref:Microsoft.ML.DebuggerExtensions.Preview*) method on a data pre-processing [`IEstimator`](xref:Microsoft.ML.IEstimator`1) and pass in an [`IDataView`](xref:Microsoft.ML.IDataView) as a parameter to preview what the result of applying pre-processing transformations would look like on the data.

```csharp
// Define data pre-processing estimator
IEstimator<ITransformer> dataPrepEstimator = 
    mlContext.Transforms.Concatenate("Features", new string[] { "Size", "HistoricalPrices" })
        .Append(mlContext.Transforms.NormalizeMinMax("Features"));

// Preview results of applying pre-processing transformations
DataDebuggerPreview dataPrepPreview = dataPrepEstimator.Preview(data,maxRows:5);
```

### Preview results after training a machine learning model

Upon inspection of the first element in the `ColumnView` of `regressionModelPreview`, the contents in addition to the data pre-processing transformations also have the predicted output of the machine learning model which is in the `Score` column. 
 
```csharp
// Preview results of training sdca regression model
IDataView transformedData = dataPrepEstimator.Fit(data).Transform(data);

IEstimator<ITransformer> sdcaEstimator = mlContext.Regression.Trainers.Sdca();

DataDebuggerPreview regressionModelPreview = sdcaEstimator.Preview(transformedData,maxRows:5);
```