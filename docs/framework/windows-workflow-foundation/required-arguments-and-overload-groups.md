---
title: "Required Arguments and Overload Groups"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4ca3ed06-b9af-4b85-8b70-88c2186aefa3
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Required Arguments and Overload Groups
Activities can be configured so that certain arguments are required to be bound for the activity to be valid for execution. The `RequiredArgument` attribute is used to indicate that certain arguments on an activity are required and the `OverloadGroup` attribute is used to group categories of required arguments together. By using the attributes, activity authors can provide simple or complex activity validation configurations.  
  
## Using Required Arguments  
 To use the `RequiredArgument` attribute in an activity, indicate the desired arguments using <xref:System.Activities.RequiredArgumentAttribute>. In this example, an `Add` activity is defined that has two required arguments.  
  
```csharp  
public sealed class Add : CodeActivity<int>  
{  
    [RequiredArgument]  
    public InArgument<int> Operand1 { get; set; }  
  
    [RequiredArgument]  
    public InArgument<int> Operand2 { get; set; }  
  
    protected override int Execute(CodeActivityContext context)  
    {  
        return Operand1.Get(context) + Operand2.Get(context);  
    }  
}  
```  
  
 In XAML, required arguments are also indicated by using <xref:System.Activities.RequiredArgumentAttribute>. In this example the `Add` activity is defined by using three arguments and uses an <xref:System.Activities.Statements.Assign%601> activity to perform the add operation.  
  
```xaml  
<Activity x:Class="ValidationDemo.Add" ...>  
  <x:Members>  
    <x:Property Name="Operand1" Type="InArgument(x:Int32)">  
      <x:Property.Attributes>  
        <RequiredArgumentAttribute />  
      </x:Property.Attributes>  
    </x:Property>  
    <x:Property Name="Operand2" Type="InArgument(x:Int32)">  
      <x:Property.Attributes>  
        <RequiredArgumentAttribute />  
      </x:Property.Attributes>  
    </x:Property>  
    <x:Property Name="Result" Type="OutArgument(x:Int32)" />  
  </x:Members>  
  <Assign>  
    <Assign.To>  
      <OutArgument x:TypeArguments="x:Int32">[Result]</OutArgument>  
    </Assign.To>  
    <Assign.Value>  
      <InArgument x:TypeArguments="x:Int32">[Operand1 + Operand2]</InArgument>  
    </Assign.Value>  
  </Assign>  
</Activity>  
```  
  
 If the activity is used and either of the required arguments is not bound the following validation error is returned.  
  
 **Value for a required activity argument 'Operand1' was not supplied.**  
> [!NOTE]
>  [!INCLUDE[crabout](../../../includes/crabout-md.md)] about checking for and handling validation errors and warnings, see [Invoking Activity Validation](../../../docs/framework/windows-workflow-foundation/invoking-activity-validation.md).  
  
## Using Overload Groups  
 Overload groups provide a method for indicating which combinations of arguments are valid in an activity. Arguments are grouped together by using <xref:System.Activities.OverloadGroupAttribute>. Each group is given a name that is specified by the <xref:System.Activities.OverloadGroupAttribute>, The activity is valid when only one set of arguments in an overload group are bound. In the following example, taken from the [OverloadGroups](../../../docs/framework/windows-workflow-foundation/samples/overloadgroups.md) sample, a `CreateLocation` class is defined.  
  
```csharp  
class CreateLocation: Activity  
{  
    [RequiredArgument]  
    public InArgument<string> Name { get; set; }  
  
    public InArgument<string> Description { get; set; }  
  
    [RequiredArgument]  
    [OverloadGroup("G1")]  
    public InArgument<int> Latitude { get; set; }  
  
    [RequiredArgument]  
    [OverloadGroup("G1")]  
    public InArgument<int> Longitude { get; set; }  
  
    [RequiredArgument]  
    [OverloadGroup("G2")]  
    [OverloadGroup("G3")]  
    public InArgument<string> Street { get; set; }  
  
    [RequiredArgument]  
    [OverloadGroup("G2")]  
    public InArgument<string> City { get; set; }  
  
    [RequiredArgument]  
    [OverloadGroup("G2")]  
    public InArgument<string> State { get; set; }  
  
    [RequiredArgument]  
    [OverloadGroup("G3")]  
    public InArgument<int> Zip { get; set; }                  
}  
```  
  
 The objective of this activity is to specify a location in the US. To do this, the user of the activity can specify the location using one of three groups of arguments. To specify the valid combinations of arguments, three overload groups are defined. `G1` contains the `Latitude` and `Longitude` arguments. `G2` contains `Street`, `City`, and `State`. `G3` contains `Street` and `Zip`. `Name` is also a required argument, but it is not part of an overload group. For this activity to be valid, `Name` would have to be bound together with all of the arguments from one and only one overload group.  
  
 In the following example, taken from the [Database Access Activities](../../../docs/framework/windows-workflow-foundation/samples/database-access-activities.md) sample, there are two overload groups: `ConnectionString` and `ConfigFileSectionName`. For this activity to be valid, either the `ProviderName` and `ConnectionString` arguments must be bound, or the `ConfigName` argument, but not both.  
  
```  
Public class DbUpdate: AsyncCodeActivity  
{  
    [RequiredArgument]  
    [OverloadGroup("ConnectionString")]  
    [DefaultValue(null)]  
    public InArgument<string> ProviderName { get; set; }  
  
    [RequiredArgument]  
    [OverloadGroup("ConnectionString")]  
    [DependsOn("ProviderName")]  
    [DefaultValue(null)]  
    public InArgument<string> ConnectionString { get; set; }  
  
    [RequiredArgument]  
    [OverloadGroup("ConfigFileSectionName")]  
    [DefaultValue(null)]  
    public InArgument<string> ConfigName { get; set; }  
  
    [DefaultValue(null)]  
    public CommandType CommandType { get; set; }  
  
    [RequiredArgument]  
    public InArgument<string> Sql { get; set; }  
  
    [DependsOn("Sql")]  
    [DefaultValue(null)]  
    public IDictionary<string, Argument> Parameters { get; }  
  
    [DependsOn("Parameters")]  
    public OutArgument<int> AffectedRecords { get; set; }       
}  
```  
  
 When defining an overload group:  
  
-   An overload group cannot be a subset or an equivalent set of another overload group.  
  
    > [!NOTE]
    >  There is one exception to this rule. If an overload group is a subset of another overload group, and the subset contains only arguments where `RequiredArgument` is `false`, then the overload group is valid.  
  
-   Overload groups can overlap but it is an error if the intersection of the groups contains all the required arguments of one or both of the overload groups. In the previous example the `G2` and `G3` overload groups overlapped, but because the intersection did not contain all the arguments of one or both of the groups this was valid.  
  
 When binding arguments in an overload group:  
  
-   An overload group is considered bound if all the `RequiredArgument` arguments in the group are bound.  
  
-   If a group has zero `RequiredArgument` arguments and at least one argument bound, then the group is considered bound.  
  
-   It is a validation error if no overload groups are bound unless one overload group has no `RequiredArgument` arguments in it.  
  
-   It is an error to have more than one overload group bound, that is, all required arguments in one overload group are bound and any argument in another overload group is also bound.
