---
description: "Learn more about: Throttled Parallel ForEach"
title: "Throttled Parallel ForEach"
ms.date: "03/30/2017"
ms.assetid: f2855b5f-e9a7-433d-96a4-40fc31025215
---
# Throttled Parallel ForEach

The `ThrottleParallelForEach` activity is similar to the <xref:System.Activities.Statements.ParallelForEach%601> activity with the one exception that it allows setting a concurrency factor to restrict the number of simultaneous branches to execute. The `ThrottleParallelForEach` activity derives from <xref:System.Activities.NativeActivity>, because it needs to schedule other activities (the child activities) and this is only accessible through the <xref:System.Activities.NativeActivityContext> class.

## Projects

The [ThrottledParallelForEach sample](https://github.com/dotnet/samples/tree/main/framework/windows-workflow-foundation/scenario/ActivityLibrary/ThrottledParallelForEach/CS) contains the following projects.

|**ProjectName**|**Description**|**Main Files**|
|-|-|-|
|ThrottledParallelForEach|Contains `ThrottledParallelForEach` activity and its designer.|ThrottledParallelForEach.cs<br /><br /> The `ThrottledParallelForEach` activity definition.|
|CodeTestClient|Sample client application that configures and runs a workflow with a `ThrottledParallelForEach` using imperative code.|Program.cs<br /><br /> Defines and runs an instance of the sample workflow.|

## To use this sample

1. Using Visual Studio, open the ThrottledParallelForEach.sln file.

2. To build the solution, press CTRL+SHIFT+B.

3. To run the solution, press F5.
