---
title: Walkthrough - Using Visual F# to Create, Debug, and Deploy an Application
description: Walkthrough-  Using Visual F# to Create, Debug, and Deploy an Application
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: bae1bdc1-289b-412a-b4ba-d5b15a838c54 
---

# Walkthrough: Using Visual F# to Create, Debug, and Deploy an Application

This walkthrough introduces you to the experience of using F# in Visual Studio together with .NET Framework 4.5.

In this walkthrough, you will learn how to get started with using Visual Studio to write F# applications through the example of a historical analysis of United States treasury interest-rate data. You will start with some quick analysis of the data by using the F# interactive window, then write and test some code to analyze the data, and then add a C# front end to explore integrating your F# code with other .NET languages.


## Prerequisites
You need the following components to complete this walkthrough:


- Visual Studio
<br />

>[!NOTE] 
Your computer might show different names or locations for some of the Visual Studio user interface elements in the following instructions. The Visual Studio edition that you have and the settings that you use determine these elements. For more information, see Personalizing the Visual Studio IDE.


### To create an F# script

1. First, create an F# script. On the **File** menu, point to **New**, and then click **File**. In the **New File** dialog box, select **Script** in the **General** category under the **Installed** templates list and then select **F# Script File**. Click **Open** to create the file, and then save the file as **RateAnalysis.fsx**.
<br />

2. Use .NET and F# APIs to access data from the Internet site of the United States Federal Reserve. Type in the following code.
[!code-fsharp[Main](snippets/fsfedrates/snippet100.fs)]

Notice the following:
<br />
  - Strings and keywords are colorized.
<br />

  - Completion lists appear after you type every period (.).
<br />

  - You can have Visual Studio complete method names and other identifiers by using the keyboard shortcut CTRL+SPACE or CTRL+J in the middle of an identifier. A completion list appears when you use CTRL+J.
<br />

  - When you rest the mouse pointer over any identifier in the code, you see a tooltip that contains information about that identifier.
<br />

  - If you press F1 when the cursor is in **WebRequest**, the expected documentation appears.
<br />

  - If you press F1 when the cursor is in **let**, the expected documentation appears.
<br />

  - Types and namespaces from **mscorlib.dll**, **System.dll**, and **System.Windows.Forms.dll** are referenced by default.
<br />

  - The **Timeout** value that is being set here is a property, not a constructor argument. F# allows you to set property values in this manner.
<br />

  - If you copy the URL in the example into a browser, you get back a list of comma-separated values that contain dates and interest rates, published by the United States Federal Reserve.
<br />

3. You will now execute the code by using F# Interactive. Select all the code (by using a mouse or by pressing CTRL+A) and right-click, and then click **Execute In Interactive**. (Alternatively, press ALT+ENTER.)
<br />
  - If it was not visible already, the F# Interactive window appears.
<br />

  - Code executes successfully.
<br />

  - The following appears in the F# Interactive window.
<br />

```fsharp
    val url : string =
    "http://www.federalreserve.gov/datadownload/Output.aspx?rel=H1"+[107 chars]
    val req : System.Net.WebRequest
    val resp : System.Net.WebResponse
    val stream : System.IO.Stream
    val reader : System.IO.StreamReader
    
    val csv : string =
    ""Series Description","Market yield on U.S. Treasury securities"+[224219 chars]
    
    >
```

4. Next, inspect the data by using F# Interactive. At the F# Interactive prompt, type **csv;;** and then press ENTER. Type **csv.Length;;** and then press ENTER. Notice the following:
<br />
  - The data is current.
<br />

  - F# Interactive displays the value of the string **csv** and its length, as shown here.
<br />

```
    07/10/2009, 3.32
    07/13/2009, 3.38
    07/14/2009, 3.50
    07/15/2009, 3.63
    "
    > csv.Length;;
    val it : int = 224513
```

  - The following illustration shows the F# Interactive window.
<br />    

![F# Interactive window](images/FSharpInteractive.png)

5. You will now write F# code to parse CSV (Comma-Separated Values) data. A CSV file is so named because it contains values separated by commas. In the Code Editor, add the following code. Also, add **open System.Globalization** at the top of the file. As you add each line, select the code added in this section up to that line and press ALT+ENTER to see the partial results. Notice the following:
<br />
  - IntelliSense gives you helpful information after you type a period, even in the middle of complex nested expressions.
<br />

  - When code is incomplete (or incorrect), red wavy underlines indicate that syntactic and semantic errors appear in the code.
<br />

  - You create pipelines by using the pipe operator (**|&gt;**). The pipe operator takes the return value from one expression and uses it as the argument for the function on the next line. Pipelines and F# Interactive allow for easy partial execution of data processing code.
<br />

[!code-fsharp[Main](snippets/fsfedrates/snippet3.fs)]

6. You will now give this functionality a name. Remove the series ID **bcb44e57fb57efbe90002369321bfb3f** from the definition of **url**, and replace it with **%s** to make the string literal a format string. Add **seriesID** after the format string. Select all code except the open directives, and press TAB. Above the indented block of code, add the following lines of code.

[!code-fsharp[Main](snippets/fsfedrates/snippet41.fs)]

At the end of the indented block, add **interest**. Notice the following:
<br />
  - Indentation is significant in F#. Indentation indicates nesting level.
<br />

  - TAB is almost like [Extract Method Refactoring &#40;C&#35;&#41;](https://msdn.microsoft.com/library/0s21cwxk.aspx).
<br />

The code now resembles the following.

[!code-fsharp[Main](snippets/fsfedrates/snippet4.fs)]

7. You will now use this functionality on new inputs. Select all the code and press ALT+ENTER to execute it by using F# Interactive. At the F# Interactive prompt, call the new **loadRates** function on other maturity rates: **1**, **2**, and **5**, in years. Notice the following:
<br />
  - Previous definitions are not lost in F# Interactive, but new definitions are available.
<br />

  - Complex structured data is rendered by special printing functionality.
<br />


### To develop a component by using F# #

1. Create a library project to expose the functionality that you have created. On the **File** menu, point to **New** and then click **Project**. In the **New Project** dialog box, select **Visual F#** in the **Installed** list and then **F# Library** to create a new library project. Give the project the name **RateAnalysis**. Copy the code that you created previously from **RateAnalysis.fsx** and paste it into **Library1.fs**. Add a module declaration to the top of the file: **module RateLoader**. In **Solution Explorer**, rename **Library1.fs** to **RateLoader.fs**, and save the file. Notice the following:
<br />
  - The default F# Library template provides a code file that has the extension **.fs** and a script that has the extension **.fsx**. You can use the script file to interactively test your library code.
<br />


1. You will now create an F# class that exposes the desired functionality. In **Solution Explorer**, right-click the project, point to **Add**, and then click **New Item**. In the **Add New Item** dialog box, select **F# Source File**. Name the file **Analyzer.fs**. Right-click **Script.fsx** in **Solution Explorer** and then click **Move Down**. (Alternatively, press ALT+DOWN ARROW.) Paste the following code into **Analyzer.fs**:

[!code-fsharp[Main](snippets/fsfedrates/snippet5.fs)]

Notice the following:

<br />
  - F# supports object-oriented programming concepts. For more information, see [Classes &#40;F&#35;&#41;](Classes-%5BFSharp%5D.md), [Inheritance &#40;F&#35;&#41;](Inheritance-%5BFSharp%5D.md), and other relevant topics in the F# Language Reference.
<br />

2. To build the project, press CTRL+SHIFT+B or F6. Notice the following:
<br />
  - The project builds successfully.
<br />

  - The Error List window shows no errors.
<br />

  - The output directory contains **.dll**, **.pdb**, and **.xml** files.
<br />

  - The Output window displays the following:
<br />

```
------ Build started: Project: RateAnalysis, Configuration: Debug Any CPU ------
C:\Program Files (x86)\Microsoft F#\v4.0\fsc.exe -o:obj\Debug\RateAnalysis.exe -g --debug:full --noframework --define:DEBUG --define:TRACE --optimize- --tailcalls- -r:"C:\Program Files (x86)\Microsoft F#\v4.0\FSharp.Core.dll" -r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\mscorlib.dll" -r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.Core.dll" -r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.dll" --target:exe --warn:3 --warnaserror:76 --vserrors --utf8output --fullpaths --flaterrors Program.fs RateLoader.fs ValueAnalyzer.fs 
RateAnalysis -> C:\Users\ghogen\Documents\Visual Studio 10\Projects\RateAnalysis\RateAnalysis\bin\Debug\RateAnalysis.exe
========== Build: 1 succeeded or up-to-date, 0 failed, 0 skipped ==========
```

3. To add a C# client application, open the shortcut menu for the solution node, choose **Add**, and then choose **New Project**. In the **Add New Project** dialog box, choose **Visual C#** in the **Installed Templates** list, and then choose **Console Application**. You might have to expand the **Other Languages** node. Name the project **CSharpDriver**, and then choose the **OK** button. Open the shortcut menu on this project's **References** node, and then choose **Add Reference**. Choose the **Solution** node, and then choose the **Projects** node. Select the check box next to the **RateAnalysis** project, and then choose the **OK** button. Open the shortcut menu for the **CSharpDriver** project node, and then click **Set as Startup Project**. Type the following code in the body of the **Main** method of the C# application.
<br />

```csharp
var maturities = new[] { 1, 2, 5, 10 };
var analyzers = RateAnalysis.Analyzer.Analyzer.GetAnalyzers(maturities);
  
foreach (var item in analyzers)
{
  Console.WriteLine("Min = {0}, \t Max = {1}, \t Current = {2}", item.Min, item.Max, item.Current);
}
Console.WriteLine("Press Enter to exit.");
Console.ReadLine();
```

Notice the following:

<br />
  - You can add project-to-project references to and from C# and F#.
<br />

  - You can use F# defined namespaces and types from C# like any other type.
<br />

  - F# documentation comments are available in C# IntelliSense.
<br />

  - C# can access tuple return values from the F# API. The tuples are **System.Tuple** values in .NET Framework 4.5.
<br />

4. To debug the application, press F11 to build the application, start the application in the debugger, and step into the first line of executed code. Press F11 several more times until you step into F# code in the body of the **GetAnalyzers** member. Notice the following:
<br />
  - You can easily step from C# code into F# code.
<br />

  - Each expression in F# is a step in the debugger.
<br />

  - The Locals window shows the values of **maturities**.
<br />

  - Continuing to press F11 steps through the evaluation of the rest of the application.
<br />

  - Debugger commands like **Run to Cursor**, **Set Next Statement**, **Insert Breakpoint**, **Add Watch**, and **Go to Disassembly** all work as expected.
<br />


### To Deploy the Application

1. If you're still debugging, stop debugging by choosing the SHIFT + F5 keys or by opening the **Debug** menu and then choosing **Stop Debugging**.
<br />

2. Open the shortcut menu for the CSharpDriver project, and then choose **Properties**.
<br />

3. In the project designer, choose the **Publish** tab, which shows options for deploying your app.
<br />

4. Choose the **Publish Wizard** button.
<br />  The Publish Wizard starts, and the first screen asks where you want the published files to be placed.
<br />

5. In the text box, specify a file location on your local disk where you'd like the installation files for your app to be placed when you publish, or choose the **Browse** button to navigate to a location.
<br />

6. Choose the **Finish** button to accept all the defaults to build a standard setup that may be distributed to client machines, or choose the **Next** button to view other publishing options.
<br />  A setup executable and supporting files are published to the location that you specified.
<br />


## Next Steps
Get started writing F# code by reading [Walkthrough: Your First F&#35; Program](Walkthrough-Your-First-FSharp-Program.md), or learn about functions in F# by reading [Functions as First-Class Values &#40;F&#35;&#41;](Functions-as-First-Class-Values-%5BFSharp%5D.md). You can explore the F# language by reading the [F&#35; Language Reference](FSharp-Language-Reference.md).


## See Also
[Visual F&#35; Samples and Walkthroughs](Visual-FSharp-Samples-and-Walkthroughs.md)

[Visual F&#35; Samples and Walkthroughs](Visual-FSharp-Samples-and-Walkthroughs.md)