---
description: "Learn more about: Using the Pick Activity"
title: "Using the Pick Activity"
ms.date: "03/30/2017"
ms.assetid: b89be812-a247-4025-b0e3-ffb20db027a6
---
# Using the Pick Activity

The [Pick sample](https://github.com/dotnet/samples/tree/main/framework/windows-workflow-foundation/basic/Built-InActivities/Pick) demonstrates how to use the <xref:System.Activities.Statements.Pick> activity.

 The <xref:System.Activities.Statements.Pick> activity provides event-based control modeling. It behaves similar to the C# `switch` statement, which executes only one of the branches in the `switch` statement. Unlike the `switch` statement in which a branch is executed based upon on a value, the <xref:System.Activities.Statements.Pick> activity executes a branch based upon how an activity completes.

 This sample prompts a user to type in their name on the console within a given time period. The <xref:System.Activities.Statements.Pick> activity in the sample has two branches that are executed based upon whether the user types in their name within 5 seconds or not. If the user types in their name within 5 seconds, the first branch is executed, which contains a custom `ReadLine` activity; otherwise the other branch is executed, which contains a <xref:System.Activities.Statements.Delay> activity. Once a user's name is typed in on the console, the user's name is printed on the console. If an input is not entered within 5 seconds, the operation is timed out.

## Demonstrates

 <xref:System.Activities.Statements.Pick> activity.

## Discussion

 The sample includes a Designer workflow and coded workflow.

 Designer Workflow
 The Designer version of the sample demonstrates how to create a workflow in the designer. The following files are included:

- Program.cs : Includes the `Main` function that executes the sample workflow.

- ReadString.cs: A custom activity that reads some input from the console.

- Sequence1.xaml: A workflow created using the designer that uses Pick.

 Coded Workflow
 The coded version of the sample demonstrates how to create a workflow in the designer. The following files are included:

- Program.cs : Includes the `Main` function that executes the sample workflow.

- ReadString.cs: A custom activity that reads some input from the console.

#### To use this sample

1. Using Visual Studio, open the Pick.sln solution file.

2. To build the solution, press CTRL+SHIFT+B.

3. To run the solution, press F5.
