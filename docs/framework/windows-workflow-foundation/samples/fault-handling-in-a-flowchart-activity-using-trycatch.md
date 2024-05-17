---
description: "Learn more about: Fault Handling in a Flowchart Activity Using TryCatch"
title: "Fault Handling in a Flowchart Activity Using TryCatch"
ms.date: "03/30/2017"
ms.assetid: 50922964-bfe0-4ba8-9422-0e7220d514fd
---
# Fault Handling in a Flowchart Activity Using TryCatch

The [FlowChartWithFaultHandling sample](https://github.com/dotnet/samples/tree/main/framework/windows-workflow-foundation/basic/Built-InActivities/FlowChartWithFaultHandling) shows how the <xref:System.Activities.Statements.TryCatch> activity can be used within a complex control flow activity.

In this sample, a promotion code and number of children are passed as variables to a <xref:System.Activities.Statements.Flowchart> activity that calculates a discount based on formulae that correspond to the promotion code. The sample includes imperative code and workflow designer versions of the sample.

The following table details the variables for the `CreateFlowchartWithFaults` activity.

|Parameters|Description|
|----------------|-----------------|
|promoCode|The promotion code. Type: String<br /><br /> The possible values with description in parentheses:<br /><br /> -   Single (Single)<br />-   MNK (Married with no kids.)<br />-   MWK (Married with kids.)|
|numKids|The number of children. Type: int|

The `CreateFlowchartWithFaults` activity uses a <xref:System.Activities.Statements.FlowSwitch%601> activity that switches on the `promoCode` argument and calculates the discount using the following formula.

|Value of `promoCode`|Discount (%)|
|--------------------------|--------------------|
|Single|10|
|MNK|15|
|MWK|15 + (1 – 1/`numberOfKids`)\*10 **Note:**  Potentially, this calculation can throw a <xref:System.DivideByZeroException>. So, the discount calculation is wrapped in a <xref:System.Activities.Statements.TryCatch> activity that catches the <xref:System.DivideByZeroException> exception and sets the discount to zero.|

## To use this sample

1. Using Visual Studio, open the FlowchartWithFaultHandling.sln solution file.

2. To build the solution, press CTRL+SHIFT+B.

3. To run the solution, press F5.

## See also

- [Flowchart Workflows](../flowchart-workflows.md)
- [Exceptions](../exceptions.md)
