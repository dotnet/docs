---
title: "Walkthrough: Creating an Extensible Application"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "views [.NET Framework], add-in pipeline"
  - "host-side adapters for add-ins [.NET Framework]"
  - "add-in pipeline [.NET Framework], creating"
  - "add-in-side adapter [.NET Framework]"
  - "contracts for add-in pipelines [.NET Framework]"
ms.assetid: 694a33c5-a040-450d-aed5-ac49fc88ce61
caps.latest.revision: 32
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Walkthrough: Creating an Extensible Application
This walkthrough describes how to create a pipeline for an add-in that performs simple calculator functions. It does not demonstrate a real-world scenario; rather, it demonstrates the basic functionality of a pipeline and how an add-in can provide services for a host.  
  
 This walkthrough describes the following tasks:  
  
-   Creating a Visual Studio solution.  
  
-   Creating the pipeline directory structure.  
  
-   Creating the contract and views.  
  
-   Creating the add-in-side adapter.  
  
-   Creating the host-side adapter.  
  
-   Creating the host.  
  
-   Creating the add-in.  
  
-   Deploying the pipeline.  
  
-   Running the host application.  
  
 This pipeline passes only serializable types (<xref:System.Double> and <xref:System.String>), between the host and the add-in. For an example that shows how to pass collections of complex data types, see [Walkthrough: Passing Collections Between Hosts and Add-Ins](http://msdn.microsoft.com/library/b532c604-548e-4fab-b11c-377257dd0ee5).  
  
 The contract for this pipeline defines an object model of four arithmetic operations: add, subtract, multiply, and divide. The host provides the add-in with an equation to calculate, such as 2 + 2, and the add-in returns the result to the host.  
  
 Version 2 of the calculator add-in provides more calculating possibilities and demonstrates versioning. It is described in [Walkthrough: Enabling Backward Compatibility as Your Host Changes](http://msdn.microsoft.com/library/6fa15bb5-8f04-407d-bd7d-675dc043c848).  
  
## Prerequisites  
 You need the following to complete this walkthrough:  
  
-   [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)].  
  
## Creating a Visual Studio Solution  
 Use a solution in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] to contain the projects of your pipeline segments.  
  
#### To create the pipeline solution  
  
1.  In [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], create a new project named `Calc1Contract`. Base it on the **Class Library** template.  
  
2.  Name the solution `CalculatorV1`.  
  
## Creating the Pipeline Directory Structure  
 The add-in model requires the pipeline segment assemblies to be placed in a specified directory structure. For more information about the pipeline structure, see [Pipeline Development Requirements](http://msdn.microsoft.com/library/ef9fa986-e80b-43e1-868b-247f4c1d9da5).  
  
#### To create the pipeline directory structure  
  
1.  Create an application folder anywhere on your computer.  
  
2.  In that folder, create the following structure:  
  
    ```  
    Pipeline  
      AddIns  
        CalcV1  
        CalcV2  
      AddInSideAdapters  
      AddInViews  
      Contracts  
      HostSideAdapters  
    ```  
  
     It is not necessary to put the pipeline folder structure in your application folder; it is done here only for convenience. At the appropriate step, the walkthrough explains how to change the code if the pipeline folder structure is in a different location. See the discussion of pipeline directory requirements in [Pipeline Development Requirements](http://msdn.microsoft.com/library/ef9fa986-e80b-43e1-868b-247f4c1d9da5).  
  
    > [!NOTE]
    >  The `CalcV2` folder is not used in this walkthrough; it is a placeholder for [Walkthrough: Enabling Backward Compatibility as Your Host Changes](http://msdn.microsoft.com/library/6fa15bb5-8f04-407d-bd7d-675dc043c848).  
  
## Creating the Contract and Views  
 The contract segment for this pipeline defines the `ICalc1Contract` interface, which defines four methods: `add`, `subtract`, `multiply`, and `divide`.  
  
#### To create the contract  
  
1.  In the Visual Studio solution named `CalculatorV1`, open the `Calc1Contract` project.  
  
2.  In **Solution Explorer**, add references to the following assemblies to the `Calc1Contract` project:  
  
     System.AddIn.Contract.dll  
  
     System.AddIn.dll  
  
3.  In **Solution Explorer**, exclude the default class that is added to new **Class Library** projects.  
  
4.  In **Solution Explorer**, add a new item to the project, using the **Interface** template. In the **Add New Item** dialog box, name the interface `ICalc1Contract`.  
  
5.  In the interface file, add namespace references to <xref:System.AddIn.Contract> and <xref:System.AddIn.Pipeline>.  
  
6.  Use the following code to complete this contract segment. Note that this interface must have the <xref:System.AddIn.Pipeline.AddInContractAttribute> attribute.  
  
     [!code-csharp[AddInP1Contract#1](../../../samples/snippets/csharp/VS_Snippets_CLR/AddInP1Contract/cs/ICalc1Contract.cs#1)]
     [!code-vb[AddInP1Contract#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/AddInP1Contract/vb/ICalc1Contract.vb#1)]  
  
7.  Optionally, build the Visual Studio solution. The solution cannot be run until the final procedure, but building it after each procedure ensures that each project is correct.  
  
 Because the add-in view and the host view of the add-in usually have the same code, especially in the first version of an add-in, you can easily create the views at the same time. They differ by only one factor: the add-in view requires the <xref:System.AddIn.Pipeline.AddInBaseAttribute> attribute, while the host view of the add-in does not require any attributes.  
  
#### To create the add-in view  
  
1.  Add a new project named `Calc1AddInView` to the `CalculatorV1` solution. Base it on the **Class Library** template.  
  
2.  In **Solution Explorer**, add a reference to System.AddIn.dll to the `Calc1AddInView` project.  
  
3.  In **Solution Explorer**, exclude the default class that is added to new **Class Library** projects, and add a new item to the project, using the **Interface** template. In the **Add New Item** dialog box, name the interface `ICalculator`.  
  
4.  In the interface file, add a namespace reference to <xref:System.AddIn.Pipeline>.  
  
5.  Use the following code to complete this add-in view. Note that this interface must have the <xref:System.AddIn.Pipeline.AddInBaseAttribute> attribute.  
  
     [!code-csharp[AddInP1AddInViews#1](../../../samples/snippets/csharp/VS_Snippets_CLR/AddInP1AddInViews/cs/Calc1AddInView.cs#1)]
     [!code-vb[AddInP1AddInViews#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/AddInP1AddInViews/vb/Calc1AddInView.vb#1)]  
  
6.  Optionally, build the Visual Studio solution.  
  
#### To create the host view of the add-in  
  
1.  Add a new project named `Calc1HVA` to the `CalculatorV1` solution. Base it on the **Class Library** template.  
  
2.  In **Solution Explorer**, exclude the default class that is added to new **Class Library** projects, and add a new item to the project, using the **Interface** template. In the **Add New Item** dialog box, name the interface `ICalculator`.  
  
3.  In the interface file, use the following code to complete the host view of the add-in.  
  
     [!code-csharp[AddInP1HVA#1](../../../samples/snippets/csharp/VS_Snippets_CLR/AddInP1HVA/cs/calc1hva.cs#1)]
     [!code-vb[AddInP1HVA#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/AddInP1HVA/vb/Calc1HVA.vb#1)]  
  
4.  Optionally, build the Visual Studio solution.  
  
## Creating the Add-in-side Adapter  
 This add-in-side adapter consists of one view-to-contract adapter. This pipeline segment converts the types from the add-in view to the contract.  
  
 In this pipeline, the add-in provides a service to the host, and the types flow from the add-in to the host. Because no types flow from the host to the add-in, you do not have to include a contract-to-view adapter on the add-in side of this pipeline.  
  
#### To create the add-in-side adapter  
  
1.  Add a new project named `Calc1AddInSideAdapter` to the `CalculatorV1` solution. Base it on the **Class Library** template.  
  
2.  In **Solution Explorer**, add references to the following assemblies to the `Calc1AddInSideAdapter` project:  
  
     System.AddIn.dll  
  
     System.AddIn.Contract.dll  
  
3.  Add project references to the projects for the adjacent pipeline segments:  
  
     `Calc1AddInView`  
  
     `Calc1Contract`  
  
4.  Select each project reference, and in **Properties** set **Copy Local** to **False**. In Visual Basic, use the **References** tab of **Project Properties** to set **Copy Local** to **False** for the two project references.  
  
5.  Rename the project's default class `CalculatorViewToContractAddInSideAdapter`.  
  
6.  In the class file, add namespace references to <xref:System.AddIn.Pipeline>.  
  
7.  In the class file, add namespace references for the adjacent segments: `CalcAddInViews` and `CalculatorContracts`. (In Visual Basic, these namespace references are `Calc1AddInView.CalcAddInViews` and `Calc1Contract.CalculatorContracts`, unless you have turned off the default namespaces in your Visual Basic projects.)  
  
8.  Apply the <xref:System.AddIn.Pipeline.AddInAdapterAttribute> attribute to the `CalculatorViewToContractAddInSideAdapter` class, to identify it as the add-in-side adapter.  
  
9. Make the `CalculatorViewToContractAddInSideAdapter` class inherit <xref:System.AddIn.Pipeline.ContractBase>, which provides a default implementation of the <xref:System.AddIn.Contract.IContract> interface, and implement the contract interface for the pipeline, `ICalc1Contract`.  
  
10. Add a public constructor that accepts an `ICalculator`, caches it in a private field, and calls the base class constructor.  
  
11. To implement the members of `ICalc1Contract`, simply call the corresponding members of the `ICalculator` instance that is passed to the constructor, and return the results. This adapts the view (`ICalculator`) to the contract (`ICalc1Contract`).  
  
     The following code shows the completed add-in-side adapter.  
  
     [!code-csharp[AddInP1AddInSideAdapters#1](../../../samples/snippets/csharp/VS_Snippets_CLR/AddInP1AddInSideAdapters/cs/Calc1ViewToContractAddInSideAdapter.cs#1)]
     [!code-vb[AddInP1AddInSideAdapters#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/AddInP1AddInSideAdapters/vb/Calc1ViewToContractAddInSideAdapter.vb#1)]  
  
12. Optionally, build the Visual Studio solution.  
  
## Creating the Host-side Adapter  
 This host-side adapter consists of one contract-to-view adapter. This segment adapts the contract to the host view of the add-in.  
  
 In this pipeline, the add-in provides a service to the host and the types flow from the add-in to the host. Because no types flow from the host to the add-in, you do not have to include a view-to-contract adapter.  
  
 To implement lifetime management, use a <xref:System.AddIn.Pipeline.ContractHandle> object to attach a lifetime token to the contract. You must keep a reference to this handle in order for lifetime management to work. After the token is applied, no additional programming is required because the add-in system can dispose of objects when they are no longer being used and make them available for garbage collection. For more information, see [Lifetime Management](http://msdn.microsoft.com/library/57a9c87e-394c-4fef-89f2-aa4223a2aeb5).  
  
#### To create the host-side adapter  
  
1.  Add a new project named `Calc1HostSideAdapter` to the `CalculatorV1` solution. Base it on the **Class Library** template.  
  
2.  In **Solution Explorer**, add references to the following assemblies to the `Calc1HostSideAdapter` project:  
  
     System.AddIn.dll  
  
     System.AddIn.Contract.dll  
  
3.  Add project references to the projects for the adjacent segments:  
  
     `Calc1Contract`  
  
     `Calc1HVA`  
  
4.  Select each project reference, and in **Properties** set **Copy Local** to **False**. In Visual Basic, use the **References** tab of **Project Properties** to set **Copy Local** to **False** for the two project references.  
  
5.  Rename the project's default class `CalculatorContractToViewHostSideAdapter`.  
  
6.  In the class file, add namespace references to <xref:System.AddIn.Pipeline>.  
  
7.  In the class file, add namespace references for the adjacent segments: `CalcHVAs` and `CalculatorContracts`. (In Visual Basic, these namespace references are `Calc1HVA.CalcHVAs` and `Calc1Contract.CalculatorContracts`, unless you have turned off the default namespaces in your Visual Basic projects.)  
  
8.  Apply the <xref:System.AddIn.Pipeline.HostAdapterAttribute> attribute to the `CalculatorContractToViewHostSideAdapter` class, to identify it as the host-side adapter segment.  
  
9. Make the `CalculatorContractToViewHostSideAdapter` class implement the interface that represents the host view of the add-in: `Calc1HVAs.ICalculator` (`Calc1HVA.CalcHVAs.ICalculator` in Visual Basic).  
  
10. Add a public constructor that accepts the pipeline contract type, `ICalc1Contract`. The constructor must cache the reference to the contract. It must also create and cache a new <xref:System.AddIn.Pipeline.ContractHandle> for the contract, to manage the lifetime of the add-in.  
  
    > [!IMPORTANT]
    >  The <xref:System.AddIn.Pipeline.ContractHandle> is critical to lifetime management. If you fail to keep a reference to the <xref:System.AddIn.Pipeline.ContractHandle> object, garbage collection will reclaim it, and the pipeline will shut down when your program does not expect it. This can lead to errors that are difficult to diagnose, such as <xref:System.AppDomainUnloadedException>. Shutdown is a normal stage in the life of a pipeline, so there is no way for the lifetime management code to detect that this condition is an error.  
  
11. To implement the members of `ICalculator`, simply call the corresponding members of the `ICalc1Contract` instance that is passed to the constructor, and return the results. This adapts the contract (`ICalc1Contract`) to the view (`ICalculator`).  
  
     The following code shows the completed host-side adapter.  
  
     [!code-csharp[AddInP1HostSideAdapters#1](../../../samples/snippets/csharp/VS_Snippets_CLR/AddInP1HostSideAdapters/cs/Calc1ContractToViewHostSideAdapter.cs#1)]
     [!code-vb[AddInP1HostSideAdapters#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/AddInP1HostSideAdapters/vb/Calc1ContractToViewHostSideAdapter.vb#1)]  
  
12. Optionally, build the Visual Studio solution.  
  
## Creating the Host  
 A host application interacts with the add-in through the host view of the add-in. It uses add-in discovery and activation methods provided by the <xref:System.AddIn.Hosting.AddInStore> and <xref:System.AddIn.Hosting.AddInToken> classes to do the following:  
  
-   Update the cache of pipeline and add-in information.  
  
-   Find add-ins of the host view type, `ICalculator`, under the specified pipeline root directory.  
  
-   Prompt the user to specify which add-in to use.  
  
-   Activate the selected add-in in a new application domain with a specified security trust level.  
  
-   Run the custom `RunCalculator` method, which calls the add-in's methods as specified by the host view of the add-in.  
  
#### To create the host  
  
1.  Add a new project named `Calc1Host` to the `CalculatorV1` solution. Base it on the **Console Application** template.  
  
2.  In **Solution Explorer**, add a reference to the System.AddIn.dll assembly to the `Calc1Host` project.  
  
3.  Add a project reference to the `Calc1HVA` project. Select the project reference, and in **Properties** set **Copy Local** to **False**. In Visual Basic, use the **References** tab of **Project Properties** to set **Copy Local** to **False**.  
  
4.  Rename the class file (module in Visual Basic) `MathHost1`.  
  
5.  In Visual Basic, use the **Application** tab of the **Project Properties** dialog box to set **Startup object** to **Sub Main**.  
  
6.  In the class or module file, add a namespace reference to <xref:System.AddIn.Hosting>.  
  
7.  In the class or module file, add a namespace reference for the host view of the add-in: `CalcHVAs`. (In Visual Basic, this namespace reference is `Calc1HVA.CalcHVAs`, unless you have turned off the default namespaces in your Visual Basic projects.)  
  
8.  In **Solution Explorer**, select the solution and from the **Project** menu choose **Properties**. In the **Solution Property Pages** dialog box, set the **Single Startup Project** to be this host application project.  
  
9. In the class or module file, use the <xref:System.AddIn.Hosting.AddInStore.Update%2A?displayProperty=nameWithType> method to update the cache. Use the <xref:System.AddIn.Hosting.AddInStore.FindAddIn%2A?displayProperty=nameWithType> method to get a collection of tokens, and use the <xref:System.AddIn.Hosting.AddInToken.Activate%2A?displayProperty=nameWithType> method to activate an add-in.  
  
     The following code shows the completed host application.  
  
     [!code-csharp[AddInP1Host#1](../../../samples/snippets/csharp/VS_Snippets_CLR/AddInP1Host/cs/MathHost1.cs#1)]
     [!code-vb[AddInP1Host#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/AddInP1Host/vb/MathHost1.vb#1)]  
  
    > [!NOTE]
    >  This code assumes that the pipeline folder structure is located in the application folder. If you located it elsewhere, change the line of code that sets the `addInRoot` variable, so that the variable contains the path to your pipeline directory structure.  
  
     The code uses a `ChooseCalculator` method to list the tokens and to prompt the user to choose an add-in. The `RunCalculator` method prompts the user for simple math expressions, parses the expressions using the `Parser` class, and displays the results returned by the add-in.  
  
10. Optionally, build the Visual Studio solution.  
  
## Creating the Add-In  
 An add-in implements the methods specified by the add-in view. This add-in implements the `Add`, `Subtract`, `Multiply`, and `Divide` operations and returns the results to the host.  
  
#### To create the add-in  
  
1.  Add a new project named `AddInCalcV1` to the `CalculatorV1` solution. Base it on the **Class Library** template.  
  
2.  In **Solution Explorer**, add a reference to the System.AddIn.dll assembly to the project.  
  
3.  Add a project reference to the `Calc1AddInView` project. Select the project reference, and in **Properties**, set **Copy Local** to **False**. In Visual Basic, use the **References** tab of **Project Properties** to set **Copy Local** to **False** for the project reference.  
  
4.  Rename the class `AddInCalcV1`.  
  
5.  In the class file, add a namespace reference to <xref:System.AddIn> and the add-in view segment: `CalcAddInViews` (`Calc1AddInView.CalcAddInViews` in Visual Basic).  
  
6.  Apply the <xref:System.AddIn.AddInAttribute> attribute to the `AddInCalcV1` class, to identify the class as an add-in.  
  
7.  Make the `AddInCalcV1` class implement the interface that represents the add-in view: `CalcAddInViews.ICalculator` (`Calc1AddInView.CalcAddInViews.ICalculator` in Visual Basic).  
  
8.  Implement the members of `ICalculator` by returning the results of the appropriate calculations.  
  
     The following code shows the completed add-in.  
  
     [!code-csharp[AddInP1AddInCalcV1#1](../../../samples/snippets/csharp/VS_Snippets_CLR/AddInP1AddInCalcV1/cs/AddInCalcV1.cs#1)]
     [!code-vb[AddInP1AddInCalcV1#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/AddInP1AddInCalcV1/vb/AddInCalcV1.vb#1)]  
  
9. Optionally, build the Visual Studio solution.  
  
## Deploying the Pipeline  
 You are now ready to build and deploy the add-in segments to the required pipeline directory structure.  
  
#### To deploy the segments to the pipeline  
  
1.  For each project in the solution, use the **Build** tab of **Project Properties** (the **Compile** tab in Visual Basic) to set the value of the **Output path** (the **Build output path** in Visual Basic). If you named your application folder `MyApp`, for example, your projects would build into the following folders:  
  
    |Project|Path|  
    |-------------|----------|  
    |AddInCalcV1|MyApp\Pipeline\AddIns\CalcV1|  
    |Calc1AddInSideAdapter|MyApp\Pipeline\AddInSideAdapters|  
    |Calc1AddInView|MyApp\Pipeline\AddInViews|  
    |Calc1Contract|MyApp\Pipeline\Contracts|  
    |Calc1Host|MyApp|  
    |Calc1HostSideAdapter|MyApp\Pipeline\HostSideAdapters|  
    |Calc1HVA|MyApp|  
  
    > [!NOTE]
    >  If you decided to put your pipeline folder structure in a location other than your application folder, you must modify the paths shown in the table accordingly. See the discussion of pipeline directory requirements in [Pipeline Development Requirements](http://msdn.microsoft.com/library/ef9fa986-e80b-43e1-868b-247f4c1d9da5).  
  
2.  Build the Visual Studio solution.  
  
3.  Check the application and pipeline directories to ensure that the assemblies were copied to the correct directories and that no extra copies of assemblies were installed in the wrong folders.  
  
    > [!NOTE]
    >  If you did not change **Copy Local** to **False** for the `Calc1AddInView` project reference in the `AddInCalcV1` project, loader context problems will prevent the add-in from being located.  
  
     For information about deploying to the pipeline, see [Pipeline Development Requirements](http://msdn.microsoft.com/library/ef9fa986-e80b-43e1-868b-247f4c1d9da5).  
  
## Running the Host Application  
 You are now ready to run the host and interact with the add-in.  
  
#### To run the host application  
  
1.  At the command prompt, go to the application directory and run the host application, `Calc1Host.exe`.  
  
2.  The host finds all available add-ins of its type and prompts you to select an add-in. Enter **1** for the only available add-in.  
  
3.  Enter an equation for the calculator, such as **2 + 2**. There must be spaces between the numbers and the operator.  
  
4.  Type **exit** and press the **Enter** key to close the application.  
  
## See Also  
 [Walkthrough: Enabling Backward Compatibility as Your Host Changes](http://msdn.microsoft.com/library/6fa15bb5-8f04-407d-bd7d-675dc043c848)  
 [Walkthrough: Passing Collections Between Hosts and Add-Ins](http://msdn.microsoft.com/library/b532c604-548e-4fab-b11c-377257dd0ee5)  
 [Pipeline Development Requirements](http://msdn.microsoft.com/library/ef9fa986-e80b-43e1-868b-247f4c1d9da5)  
 [Contracts, Views, and Adapters](http://msdn.microsoft.com/library/a6460173-9507-4b87-8c07-d4ee245d715c)  
 [Pipeline Development](../../../docs/framework/add-ins/pipeline-development.md)
