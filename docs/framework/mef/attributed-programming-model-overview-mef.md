---
title: "Attributed Programming Model Overview (MEF)"
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "MEF, attributed programming model"
  - "attributed programming model [MEF]"
ms.assetid: 49b787ff-2741-4836-ad51-c3017dc592d4
caps.latest.revision: 24
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Attributed Programming Model Overview (MEF)
In the Managed Extensibility Framework (MEF), a *programming model* is a particular method of defining the set of conceptual objects on which MEF operates. These conceptual objects include parts, imports, and exports. MEF uses these objects, but does not specify how they should be represented. Therefore, a wide variety of programming models are possible, including customized programming models.  
  
 The default programming model used in MEF is the *attributed programming model*. In the attributed programming model parts, imports, exports, and other objects are defined with attributes that decorate ordinary .NET Framework classes. This topic explains how to use the attributes provided by the attributed programming model to create a MEF application.  
  
<a name="import_and_export_basics"></a>   
## Import and Export Basics  
 An *export* is a value that a part provides to other parts in the container, and an *import* is a requirement that a part expresses to the container, to be filled from the available exports. In the attributed programming model, imports and exports are declared by decorating classes or members with the `Import` and `Export` attributes. The `Export` attribute can decorate a class, field, property, or method, while the `Import` attribute can decorate a field, property, or constructor parameter.  
  
 In order for an import to be matched with an export, the import and export must have the same *contract*. The contract consists of a string, called the *contract name*, and the type of the exported or imported object, called the *contract type*. Only if both the contract name and contract type match is an export considered to fulfill a particular import.  
  
 Either or both of the contract parameters can be implicit or explicit. The following code shows a class that declares a basic import.  
  
```vb  
Public Class MyClass1  
    <Import()>  
    Public Property MyAddin As IMyAddin  
End Class  
```  
  
```csharp  
public class MyClass  
{  
    [Import]  
    public IMyAddin MyAddin { get; set; }  
}  
```  
  
 In this import, the `Import` attribute has neither a contract type nor a contract name parameter attached. Therefore, both will be inferred from the decorated property. In this case, the contract type will be `IMyAddin`, and the contract name will be a unique string created from the contract type. (In other words, the contract name will match only exports whose names are also inferred from the type `IMyAddin`.)  
  
 The following shows an export that matches the previous import.  
  
```vb  
<Export(GetType(IMyAddin))>  
Public Class MyLogger  
    Implements IMyAddin  
  
End Class  
```  
  
```csharp  
[Export(typeof(IMyAddin))]  
public class MyLogger : IMyAddin { }  
```  
  
 In this export, the contract type is `IMyAddin` because it is specified as a parameter of the `Export` attribute. The exported type must be either the same as the contract type, derive from the contract type, or implement the contract type if it is an interface. In this export, the actual type `MyLogger` implements the interface `IMyAddin`. The contract name is inferred from the contract type, which means that this export will match the previous import.  
  
> [!NOTE]
>  Exports and imports should usually be declared on public classes or members. Other declarations are supported, but exporting or importing a private, protected, or internal member breaks the isolation model for the part and is therefore not recommended.  
  
 The contract type must match exactly for the export and import to be considered a match. Consider the following export.  
  
```vb  
<Export()> 'WILL NOT match the previous import!  
Public Class MyLogger  
    Implements IMyAddin  
  
End Class  
```  
  
```csharp  
[Export] //WILL NOT match the previous import!  
public class MyLogger : IMyAddin { }  
```  
  
 In this export, the contract type is `MyLogger` instead of `IMyAddin`. Even though `MyLogger` implements `IMyAddin`, and therefore could be cast to an `IMyAddin` object, this export will not match the previous import because the contract types are not the same.  
  
 In general, it is not necessary to specify the contract name, and most contracts should be defined in terms of the contract type and metadata. However, under certain circumstances, it is important to specify the contract name directly. The most common case is when a class exports several values that share a common type, such as primitives. The contract name can be specified as the first parameter of the `Import` or `Export` attribute. The following code shows an import and an export with a specified contract name of `MajorRevision`.  
  
```vb  
Public Class MyExportClass  
  
    'This one will match  
    <Export("MajorRevision")>  
    Public ReadOnly Property MajorRevision As Integer  
        Get  
            Return 4  
        End Get  
    End Property  
  
    <Export("MinorRevision")>  
    Public ReadOnly Property MinorRevision As Integer  
        Get  
            Return 16  
        End Get  
    End Property  
End Class  
```  
  
```csharp  
public class MyClass  
{  
    [Import("MajorRevision")]  
    public int MajorRevision { get; set; }  
}  
  
public class MyExportClass  
{   
    [Export("MajorRevision")] //This one will match.  
    public int MajorRevision = 4;  
  
    [Export("MinorRevision")]  
    public int MinorRevision = 16;  
}  
```  
  
 If the contract type is not specified, it will still be inferred from the type of the import or export. However, even if the contract name is specified explicitly, the contract type must also match exactly for the import and export to be considered a match. For example, if the `MajorRevision` field was a string, the inferred contract types would not match and the export would not match the import, despite having the same contract name.  
  
### Importing and Exporting a Method  
 The `Export` attribute can also decorate a method, in the same way as a class, property, or function. Method exports must specify a contract type or contract name, as the type cannot be inferred. The specified type can be either a custom delegate or a generic type, such as `Func`. The following class exports a method named `DoSomething`.  
  
```vb  
Public Class MyAddin  
  
    'Explicitly specifying a generic type  
    <Export(GetType(Func(Of Integer, String)))>  
    Public Function DoSomething(ByVal TheParam As Integer) As String  
        Return Nothing 'Function body goes here  
    End Function  
  
End Class  
```  
  
```csharp  
public class MyAddin  
{  
    //Explicitly specifying a generic type.  
    [Export(typeof(Func<int, string>)]  
    public string DoSomething(int TheParam);  
}  
```  
  
 In this class, the `DoSomething` method takes a single `int` parameter and returns a `string`. To match this export, the importing part must declare an appropriate member. The following class imports the `DoSomething` method.  
  
```vb  
Public Class MyClass1  
  
    'Contract name must match!  
    <Import()>  
    Public Property MajorRevision As Func(Of Integer, String)  
End Class  
```  
  
```csharp  
public class MyClass  
{  
    [Import] //Contract name must match!  
    public Func<int, string> DoSomething { get; set; }  
}  
```  
  
 For more information about how to use of the `Func<T, T>` object, see <xref:System.Func%602>.  
  
<a name="types_of_imports"></a>   
## Types of Imports  
 MEF support several import types, including dynamic, lazy, prerequisite, and optional.  
  
### Dynamic Imports  
 In some cases, the importing class may want to match exports of any type that have a particular contract name. In this scenario, the class can declare a *dynamic import*. The following import matches any export with contract name "TheString".  
  
```vb  
Public Class MyClass1  
  
    <Import("TheString")>  
    Public Property MyAddin  
  
End Class  
```  
  
```csharp  
public class MyClass  
{  
    [Import("TheString")]  
    public dynamic MyAddin { get; set; }  
}  
```  
  
 When the contract type is inferred from the `dynamic` keyword, it will match any contract type. In this case, an import should **always** specify a contract name to match on. (If no contract name is specified, the import will be considered to match no exports.) Both of the following exports would match the previous import.  
  
```vb  
<Export("TheString", GetType(IMyAddin))>  
Public Class MyLogger  
    Implements IMyAddin  
  
End Class  
  
<Export("TheString")>  
Public Class MyToolbar  
  
End Class  
```  
  
```csharp  
[Export("TheString", typeof(IMyAddin))]  
public class MyLogger : IMyAddin { }  
  
[Export("TheString")]  
public class MyToolbar { }  
```  
  
 Obviously, the importing class must be prepared to deal with an object of arbitrary type.  
  
### Lazy Imports  
 In some cases, the importing class may require an indirect reference to the imported object, so that the object is not instantiated immediately. In this scenario, the class can declare a *lazy import* by using a contract type of `Lazy<T>`. The following importing property declares a lazy import.  
  
```vb  
Public Class MyClass1  
  
    <Import()>  
    Public Property MyAddin As Lazy(Of IMyAddin)  
  
End Class  
```  
  
```csharp  
public class MyClass  
{  
    [Import]  
    public Lazy<IMyAddin> MyAddin { get; set; }  
}  
```  
  
 From the point of view of the composition engine, a contract type of `Lazy<T>` is considered identical to contract type of `T`. Therefore, the previous import would match the following export.  
  
```vb  
<Export(GetType(IMyAddin))>  
Public Class MyLogger  
    Implements IMyAddin  
  
End Class  
```  
  
```csharp  
[Export(typeof(IMyAddin))]  
public class MyLogger : IMyAddin { }  
```  
  
 The contract name and contract type can be specified in the `Import` attribute for a lazy import, as described earlier in the "Basic Imports and Exports" section.  
  
### Prerequisite Imports  
 Exported MEF parts are typically created by the composition engine, in response to a direct request or the need to fill a matched import. By default, when creating a part, the composition engine uses the parameter-less constructor. To make the engine use a different constructor, you can mark it with the `ImportingConstructor` attribute.  
  
 Each part may have only one constructor for use by the composition engine. Providing no default constructor and no `ImportingConstructor` attribute, or providing more than one `ImportingConstructor` attribute, will produce an error.  
  
 To fill the parameters of a constructor marked with the `ImportingConstructor` attribute, all of those parameters are automatically declared as imports. This is a convenient way to declare imports that are used during part initialization. The following class uses `ImportingConstructor` to declare an import.  
  
```vb  
Public Class MyClass1  
  
    Private _theAddin As IMyAddin  
  
    'Default constructor will NOT be used  
    'because the ImportingConstructor  
    'attribute is present.  
    Public Sub New()  
  
    End Sub  
  
    'This constructor will be used.  
    'An import with contract type IMyAddin  
    'is declared automatically.  
    <ImportingConstructor()>  
    Public Sub New(ByVal MyAddin As IMyAddin)  
        _theAddin = MyAddin  
    End Sub  
  
End Class  
```  
  
```csharp  
public class MyClass   
{  
    private IMyAddin _theAddin;  
  
    //Default constructor will NOT be  
    //used because the ImportingConstructor  
    //attribute is present.  
    public MyClass() { }  
  
    //This constructor will be used.  
    //An import with contract type IMyAddin is   
    //declared automatically.  
    [ImportingConstructor]   
    public MyClass(IMyAddin MyAddin)   
    {  
        _theAddin = MyAddin;  
    }  
}  
```  
  
 By default, the `ImportingConstructor` attribute uses inferred contract types and contract names for all of the parameter imports. It is possible to override this by decorating the parameters with `Import` attributes, which can then define the contract type and contract name explicitly. The following code demonstrates a constructor that uses this syntax to import a derived class instead of a parent class.  
  
```vb  
<ImportingConstructor()>  
Public Sub New(<Import(GetType(IMySubAddin))> ByVal MyAddin As IMyAddin)  
  
End Sub  
```  
  
```csharp  
[ImportingConstructor]   
public MyClass([Import(typeof(IMySubAddin))]IMyAddin MyAddin)   
{  
    _theAddin = MyAddin;  
}  
```  
  
 In particular, you should be careful with collection parameters. For example, if you specify `ImportingConstructor` on a constructor with a parameter of type `IEnumerable<int>`, the import will match a single export of type `IEnumerable<int>`, instead of a set of exports of type `int`. To match a set of exports of type `int`, you have to decorate the parameter with the `ImportMany` attribute.  
  
 Parameters declared as imports by the `ImportingConstructor` attribute are also marked as *prerequisite imports*. MEF normally allows exports and imports to form a *cycle*. For example, a cycle is where object A imports object B, which in turn imports object A. Under ordinary circumstances, a cycle is not a problem, and the composition container constructs both objects normally.  
  
 When an imported value is required by the constructor of a part, that object cannot participate in a cycle. If object A requires that object B be constructed before it can be constructed itself, and object B imports object A, then the cycle will be unable to resolve and a composition error will occur. Imports declared on constructor parameters are therefore prerequisite imports, which must all be filled before any of the exports from the object that requires them can be used.  
  
### Optional Imports  
 The `Import` attribute specifies a requirement for the part to function. If an import cannot be fulfilled, the composition of that part will fail and the part will not be available.  
  
 You can specify that an import is *optional* by using the `AllowDefault` property. In this case, the composition will succeed even if the import does not match any available exports, and the importing property will be set to the default for its property type (`null` for object properties, `false` for Booleans, or zero for numeric properties.) The following class uses an optional import.  
  
```vb  
Public Class MyClass1  
  
    <Import(AllowDefault:=True)>  
    Public Property thePlugin As Plugin  
  
    'If no matching export is available,  
    'thePlugin will be set to null.  
End Class  
```  
  
```csharp  
public class MyClass  
{  
    [Import(AllowDefault = true)]  
    public Plugin thePlugin { get; set; }  
  
    //If no matching export is avaliable,  
    //thePlugin will be set to null.  
}  
```  
  
### Importing Multiple Objects  
 The `Import` attribute will only be successfully composed when it matches one and only one export. Other cases will produce a composition error. To import more than one export that matches the same contract, use the `ImportMany` attribute. Imports marked with this attribute are always optional. For example, composition will not fail if no matching exports are present. The following class imports any number of exports of type `IMyAddin`.  
  
```vb  
Public Class MyClass1  
  
    <ImportMany()>  
    Public Property MyAddin As IEnumerable(Of IMyAddin)  
  
End Class  
```  
  
```csharp  
public class MyClass  
{  
    [ImportMany]  
    public IEnumerable<IMyAddin> MyAddin { get; set; }  
}  
```  
  
 The imported array can be accessed by using ordinary `IEnumerable<T>` syntax and methods. It is also possible to use an ordinary array (`IMyAddin[]`) instead.  
  
 This pattern can be very important when you use it in combination with the `Lazy<T>` syntax. For example, by using `ImportMany`, `IEnumerable<T>`, and `Lazy<T>`, you can import indirect references to any number of objects and only instantiate the ones that become necessary. The following class shows this pattern.  
  
```vb  
Public Class MyClass1  
  
    <ImportMany()>  
    Public Property MyAddin As IEnumerable(Of Lazy(Of IMyAddin))  
  
End Class  
```  
  
```csharp  
public class MyClass  
{  
    [ImportMany]  
    public IEnumerable<Lazy<IMyAddin>> MyAddin { get; set; }  
}  
```  
  
<a name="avoiding_discovery"></a>   
## Avoiding Discovery  
 In some cases, you may want to prevent a part from being discovered as part of a catalog. For example, the part may be a base class intended to be inherited from, but not used. There are two ways to accomplish this. First, you can use the `abstract` keyword on the part class. Abstract classes never provide exports, although they can provide inherited exports to classes that derive from them.  
  
 If the class cannot be made abstract, you can decorate it with the `PartNotDiscoverable` attribute. A part decorated with this attribute will not be included in any catalogs. The following example demonstrates these patterns. `DataOne` will be discovered by the catalog. Since `DataTwo` is abstract, it will not be discovered. Since `DataThree` used the `PartNotDiscoverable` attribute, it will not be discovered.  
  
```vb  
<Export()>  
Public Class DataOne  
    'This part will be discovered   
    'as normal by the catalog.  
End Class  
  
<Export()>  
Public MustInherit Class DataTwo  
    'This part will not be discovered  
    'by the catalog.  
End Class  
  
<PartNotDiscoverable()>  
<Export()>  
Public Class DataThree  
    'This part will also not be discovered  
    'by the catalog.  
End Class  
```  
  
```csharp  
[Export]  
public class DataOne  
{  
    //This part will be discovered  
    //as normal by the catalog.  
}  
  
[Export]  
public abstract class DataTwo  
{  
    //This part will not be discovered  
    //by the catalog.  
}  
  
[PartNotDiscoverable]  
[Export]  
public class DataThree  
{  
    //This part will also not be discovered  
    //by the catalog.  
}  
```  
  
<a name="metadata_and_metadata_views"></a>   
## Metadata and Metadata Views  
 Exports can provide additional information about themselves known as *metadata*. Metadata can be used to convey properties of the exported object to the importing part. The importing part can use this data to decide which exports to use, or to gather information about an export without having to construct it. For this reason, an import must be lazy to use metadata.  
  
 To use metadata, you typically declare an interface known as a *metadata view*, which declares what metadata will be available. The metadata view interface must have only properties, and those properties must have `get` accessors. The following interface is an example metadata view.  
  
```vb  
Public Interface IPluginMetadata  
  
    ReadOnly Property Name As String  
  
    <DefaultValue(1)>  
    ReadOnly Property Version As Integer  
  
End Interface  
```  
  
```csharp  
public interface IPluginMetadata  
{  
    string Name { get; }  
  
    [DefaultValue(1)]    
    int Version { get; }  
}  
```  
  
 It is also possible to use a generic collection, `IDictionary<string, object>`, as a metadata view, but this forfeits the benefits of type checking and should be avoided.  
  
 Ordinarily, all of the properties named in the metadata view are required, and any exports that do not provide them will not be considered a match. The `DefaultValue` attribute specifies that a property is optional. If the property is not included, it will be assigned the default value specified as a parameter of `DefaultValue`. The following are two different classes decorated with metadata. Both of these classes would match the previous metadata view.  
  
```vb  
<Export(GetType(IPlugin))>  
<ExportMetadata("Name", "Logger")>  
<ExportMetadata("Version", 4)>  
Public Class MyLogger  
    Implements IPlugin  
  
End Class  
  
'Version is not required because of the DefaultValue  
<Export(GetType(IPlugin))>  
<ExportMetadata("Name", "Disk Writer")>  
Public Class DWriter  
    Implements IPlugin  
  
End Class  
```  
  
```csharp  
[Export(typeof(IPlugin)),  
    ExportMetadata("Name", "Logger"),  
    ExportMetadata("Version", 4)]  
public class Logger : IPlugin  
{  
}  
  
[Export(typeof(IPlugin)),  
    ExportMetadata("Name", "Disk Writer")]   
    //Version is not required because of the DefaultValue  
public class DWriter : IPlugin  
{  
}  
```  
  
 Metadata is expressed after the `Export` attribute by using the `ExportMetadata` attribute. Each piece of metadata is composed of a name/value pair. The name portion of the metadata must match the name of the appropriate property in the metadata view, and the value will be assigned to that property.  
  
 It is the importer that specifies what metadata view, if any, will be in use. An import with metadata is declared as a lazy import, with the metadata interface as the second type parameter to `Lazy<T,T>`. The following class imports the previous part with metadata.  
  
```vb  
Public Class Addin  
  
    <Import()>  
    Public Property plugin As Lazy(Of IPlugin, IPluginMetadata)  
End Class  
```  
  
```csharp  
public class Addin  
{  
    [Import]  
    public Lazy<IPlugin, IPluginMetadata> plugin;  
}  
```  
  
 In many cases, you will want to combine metadata with the `ImportMany` attribute, in order to parse through the available imports and choose and instantiate only one, or filter a collection to match a certain condition. The following class instantiates only `IPlugin` objects that have the `Name` value "Logger".  
  
```vb  
Public Class User  
  
    <ImportMany()>  
    Public Property plugins As IEnumerable(Of Lazy(Of IPlugin, IPluginMetadata))  
  
    Public Function InstantiateLogger() As IPlugin  
  
        Dim logger As IPlugin  
        logger = Nothing  
  
        For Each Plugin As Lazy(Of IPlugin, IPluginMetadata) In plugins  
            If (Plugin.Metadata.Name = "Logger") Then  
                logger = Plugin.Value  
            End If  
        Next  
        Return logger  
    End Function  
  
End Class  
```  
  
```csharp  
public class User  
{  
    [ImportMany]  
    public IEnumerable<Lazy<IPlugin, IPluginMetadata>> plugins;  
  
    public IPlugin InstantiateLogger ()  
    {  
        IPlugin logger = null;  
  
        foreach (Lazy<IPlugin, IPluginMetadata> plugin in plugins)  
        {  
            if (plugin.Metadata.Name = "Logger") logger = plugin.Value;  
        }  
        return logger;  
    }  
}  
```  
  
<a name="import_and_export_inheritance"></a>   
## Import and Export Inheritance  
 If a class inherits from a part, that class may also become a part. Imports are always inherited by subclasses. Therefore, a subclass of a part will always be a part, with the same imports as its parent class.  
  
 Exports declared by using the `Export` attribute are not inherited by subclasses. However, a part can export itself by using the `InheritedExport` attribute. Subclasses of the part will inherit and provide the same export, including contract name and contract type. Unlike an `Export` attribute, `InheritedExport` can be applied only at the class level, and not at the member level. Therefore, member-level exports can never be inherited.  
  
 The following four classes demonstrate the principles of import and export inheritance. `NumTwo` inherits from `NumOne`, so `NumTwo` will import `IMyData`. Ordinary exports are not inherited, so `NumTwo` will not export anything. `NumFour` inherits from `NumThree`. Because `NumThree` used `InheritedExport`, `NumFour` has one export with contract type `NumThree`. Member-level exports are never inherited, so `IMyData` is not exported.  
  
```vb  
<Export()>  
Public Class NumOne  
    <Import()>  
    Public Property MyData As IMyData  
End Class  
  
Public Class NumTwo  
    Inherits NumOne  
  
    'Imports are always inherited, so NumTwo will  
    'Import IMyData  
  
    'Ordinary exports are not inherited, so  
    'NumTwo will NOT export anything.  As a result it  
    'will not be discovered by the catalog!  
  
End Class  
  
<InheritedExport()>  
Public Class NumThree  
  
    <Export()>  
    Public Property MyData As IMyData  
  
    'This part provides two exports, one of  
    'contract type NumThree, and one of   
    'contract type IMyData.  
  
End Class  
  
Public Class NumFour  
    Inherits NumThree  
  
    'Because NumThree used InheritedExport,  
    'this part has one export with contract   
    'type NumThree.  
  
    'Member-level exports are never inherited,  
    'so IMyData is not exported.  
  
End Class  
```  
  
```csharp  
[Export]  
public class NumOne  
{  
    [Import]  
    public IMyData MyData { get; set; }  
}  
  
public class NumTwo : NumOne  
{  
    //Imports are always inherited, so NumTwo will   
    //import IMyData.  
  
    //Ordinary exports are not inherited, so   
    //NumTwo will NOT export anything. As a result it   
    //will not be discovered by the catalog!  
}  
  
[InheritedExport]  
public class NumThree  
{  
    [Export]  
    Public IMyData MyData { get; set; }  
  
    //This part provides two exports, one of  
    //contract type NumThree, and one of  
    //contract type IMyData.  
}  
  
public class NumFour : NumThree  
{  
    //Because NumThree used InheritedExport,  
    //this part has one export with contract  
    //type NumThree.  
  
    //Member-level exports are never inherited,  
    //so IMyData is not exported.  
}  
```  
  
 If there is metadata associated with an `InheritedExport` attribute, that metadata will also be inherited. (For more information, see the earlier "Metadata and Metadata Views" section.) Inherited metadata cannot be modified by the subclass. However, by re-declaring the `InheritedExport` attribute with the same contract name and contract type, but with new metadata, the subclass can replace the inherited metadata with new metadata. The following class demonstrates this principle. The `MegaLogger` part inherits from `Logger` and includes the `InheritedExport` attribute. Since `MegaLogger` re-declares new metadata named Status, it does not inherit the Name and Version metadata from `Logger`.  
  
```vb  
<InheritedExport(GetType(IPlugin))>  
<ExportMetadata("Name", "Logger")>  
<ExportMetadata("Version", 4)>  
Public Class Logger  
    Implements IPlugin  
  
    'Exports with contract type IPlugin  
    'and metadata "Name" and "Version".  
End Class  
  
Public Class SuperLogger  
    Inherits Logger  
  
    'Exports with contract type IPlugin and   
    'metadata "Name" and "Version", exactly the same  
    'as the Logger class.  
  
End Class  
  
<InheritedExport(GetType(IPlugin))>  
<ExportMetadata("Status", "Green")>  
Public Class MegaLogger  
    Inherits Logger  
  
    'Exports with contract type IPlugin and   
    'metadata "Status" only. Re-declaring   
    'the attribute replaces all metadata.  
  
End Class  
```  
  
```csharp  
[InheritedExport(typeof(IPlugin)),  
    ExportMetadata("Name", "Logger"),  
    ExportMetadata("Version", 4)]  
public class Logger : IPlugin  
{  
    //Exports with contract type IPlugin and   
    //metadata "Name" and "Version".  
}  
  
public class SuperLogger : Logger  
{  
    //Exports with contract type IPlugin and   
    //metadata "Name" and "Version", exactly the same  
    //as the Logger class.  
}  
  
[InheritedExport(typeof(IPlugin)),  
    ExportMetadata("Status", "Green")]  
public class MegaLogger : Logger        {  
    //Exports with contract type IPlugin and   
    //metadata "Status" only. Re-declaring   
    //the attribute replaces all metadata.  
}  
```  
  
 When re-declaring the `InheritedExport` attribute to override metadata, make sure that the contract types are the same. (In the previous example, `IPlugin` is the contract type.) If they differ, instead of overriding, the second attribute will create a second, independent export from the part. Generally, this means that you will have to explicitly specify the contract type when you override an `InheritedExport` attribute, as shown in the previous example.  
  
 Since interfaces cannot be instantiated directly, they generally cannot be decorated with `Export` or `Import` attributes. However, an interface can be decorated with an `InheritedExport` attribute at the interface level, and that export along with any associated metadata will be inherited by any implementing classes. The interface itself will not be available as a part, however.  
  
<a name="custom_export_attributes"></a>   
## Custom Export Attributes  
 The basic export attributes, `Export` and `InheritedExport`, can be extended to include metadata as attribute properties. This technique is useful for applying similar metadata to many parts, or creating an inheritance tree of metadata attributes.  
  
 A custom attribute can specify the contract type, the contract name, or any other metadata. In order to define a custom attribute, a class inheriting from `ExportAttribute` (or `InheritedExportAttribute`) must be decorated with the `MetadataAttribute` attribute. The following class defines a custom attribute.  
  
```vb  
<MetadataAttribute()>  
<AttributeUsage(AttributeTargets.Class, AllowMultiple:=false)>  
Public Class MyAttribute  
    Inherits ExportAttribute  
  
    Public Property MyMetadata As String  
  
    Public Sub New(ByVal myMetadata As String)  
        MyBase.New(GetType(IMyAddin))  
  
        myMetadata = myMetadata  
    End Sub  
  
End Class  
```  
  
```csharp  
[MetadataAttribute]  
[AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]  
public class MyAttribute : ExportAttribute  
{  
    public MyAttribute(string myMetadata)   
        : base(typeof(IMyAddin))  
    {  
        MyMetadata = myMetadata;  
    }  
  
    public string MyMetadata { get; private set; }  
}  
```  
  
 This class defines a custom attribute named `MyAttribute` with contract type `IMyData` and some metadata named `MyMetadata`. All properties in a class marked with the `MetadataAttribute` attribute are considered to be metadata defined in the custom attribute. The following two declarations are equivalent.  
  
```vb  
<Export(GetType(IMyAddin))>  
<ExportMetadata("MyMetadata", "theData")>  
Public Property myAddin As MyAddin  
  
<MyAttribute("theData")>  
Public Property myAddin As MyAddin  
```  
  
```csharp  
[Export(typeof(IMyAddin)),   
    ExportMetadata("MyMetadata", "theData")]  
public MyAddin myAddin { get; set; }  
```  
  
```  
[MyAttribute("theData")]  
public MyAddin myAddin { get; set; }  
```  
  
 In the first declaration, the contract type and metadata are explicitly defined. In the second declaration, the contract type and metadata are implicit in the customized attribute. Particularly in cases where a large amount of identical metadata must be applied to many parts (for example, author or copyright information), using a custom attribute can save a lot of time and duplication. Further, inheritance trees of custom attributes can be created to allow for variations.  
  
 To create optional metadata in a custom attribute, you can use the `DefaultValue` attribute. When this attribute is applied to a property in a custom attribute class, it specifies that the decorated property is optional and does not have to be supplied by an exporter. If a value for the property is not supplied, it will be assigned the default value for its property type (usually `null`, `false`, or 0.)  
  
<a name="creation_policies"></a>   
## Creation Policies  
 When a part specifies an import and composition is performed, the composition container attempts to find a matching export. If it matches the import with an export successfully, the importing member is set to an instance of the exported object. Where this instance comes from is controlled by the exporting part's *creation policy*.  
  
 The two possible creation policies are *shared* and *non-shared*. A part with a creation policy of shared will be shared between every import in the container for a part with that contract. When the composition engine finds a match and has to set an importing property, it will instantiate a new copy of the part only if one does not already exist; otherwise, it will supply the existing copy. This means that many objects may have references to the same part. Such parts should not rely on internal state that might be changed from many places. This policy is appropriate for static parts, parts that provide services, and parts that consume a lot of memory or other resources.  
  
 A part with the creation policy of non-shared will be created every time a matching import for one of its exports is found. A new copy will therefore be instantiated for every import in the container that matches one of the part's exported contracts. The internal state of these copies will not be shared. This policy is appropriate for parts where each import requires its own internal state.  
  
 Both the import and the export can specify the creation policy of a part, from among the values `Shared`, `NonShared`, or `Any`. The default is `Any` for both imports and exports. An export that specifies `Shared` or `NonShared` will only match an import that specifies the same, or that specifies `Any`. Similarly, an import that specifies `Shared` or `NonShared` will only match an export that specifies the same, or that specifies `Any`. Imports and exports with incompatible creation policies are not considered a match, in the same way as an import and export whose contract name or contract type are not a match. If both import and export specify `Any`, or do not specify a creation policy and default to `Any`, the creation policy will default to shared.  
  
 The following example shows both imports and exports specifying creation policies. `PartOne` does not specify a creation policy, so the default is `Any`. `PartTwo` does not specify a creation policy, so the default is `Any`. Since both import and export default to `Any`, `PartOne` will be shared. `PartThree` specifies a `Shared` creation policy, so `PartTwo` and `PartThree` will share the same copy of `PartOne`. `PartFour` specifies a `NonShared` creation policy, so `PartFour` will be non-shared in `PartFive`. `PartSix` specifies a `NonShared` creation policy. `PartFive` and `PartSix` will each receive separate copies of `PartFour`. `PartSeven` specifies a `Shared` creation policy. Because there is no exported `PartFour` with a creation policy of `Shared`, the `PartSeven` import does not match anything and will not be filled.  
  
```vb  
<Export()>  
Public Class PartOne  
    'The default creation policy for an export is Any.  
End Class  
  
Public Class PartTwo  
  
    <Import()>  
    Public Property partOne As PartOne  
  
    'The default creation policy for an import is Any.  
    'If both policies are Any, the part will be shared.  
  
End Class  
  
Public Class PartThree  
  
    <Import(RequiredCreationPolicy:=CreationPolicy.Shared)>  
    Public Property partOne As PartOne  
  
    'The Shared creation policy is explicitly specified.  
    'PartTwo and PartThree will receive references to the  
    'SAME copy of PartOne.  
  
End Class  
  
<Export()>  
<PartCreationPolicy(CreationPolicy.NonShared)>  
Public Class PartFour  
    'The NonShared creation policy is explicitly specified.  
End Class  
  
Public Class PartFive  
  
    <Import()>  
    Public Property partFour As PartFour  
  
    'The default creation policy for an import is Any.  
    'Since the export's creation policy was explictly  
    'defined, the creation policy for this property will  
    'be non-shared.  
  
End Class  
  
Public Class PartSix  
  
    <Import(RequiredCreationPolicy:=CreationPolicy.NonShared)>  
    Public Property partFour As PartFour  
  
    'Both import and export specify matching creation   
    'policies.  PartFive and PartSix will each receive   
    'SEPARATE copies of PartFour, each with its own  
    'internal state.  
  
End Class  
  
Public Class PartSeven  
  
    <Import(RequiredCreationPolicy:=CreationPolicy.Shared)>  
    Public Property partFour As PartFour  
  
    'A creation policy mismatch.  Because there is no   
    'exported PartFour with a creation policy of Shared,  
    'this import does not match anything and will not be  
    'filled.  
  
End Class  
```  
  
```csharp  
[Export]  
public class PartOne  
{  
    //The default creation policy for an export is Any.  
}  
  
public class PartTwo  
{  
    [Import]  
    public PartOne partOne { get; set; }  
  
    //The default creation policy for an import is Any.  
    //If both policies are Any, the part will be shared.  
}  
  
public class PartThree  
{  
    [Import(RequiredCreationPolicy = CreationPolicy.Shared)]  
    public PartOne partOne { get; set; }  
  
    //The Shared creation policy is explicitly specified.  
    //PartTwo and PartThree will receive references to the  
    //SAME copy of PartOne.  
}  
  
[Export]  
[PartCreationPolicy(CreationPolicy.NonShared)]  
public class PartFour  
{  
    //The NonShared creation policy is explicitly specified.  
}  
  
public class PartFive  
{  
    [Import]  
    public PartFour partFour { get; set; }  
  
    //The default creation policy for an import is Any.  
    //Since the export's creation policy was explictly  
    //defined, the creation policy for this property will  
    //be non-shared.  
}  
  
public class PartSix  
{  
    [Import(RequiredCreationPolicy = CreationPolicy.NonShared)]  
    public PartFour partFour { get; set; }  
  
    //Both import and export specify matching creation   
    //policies.  PartFive and PartSix will each receive   
    //SEPARATE copies of PartFour, each with its own  
    //internal state.  
}  
  
public class PartSeven  
{  
    [Import(RequiredCreationPolicy = CreationPolicy.Shared)]  
    public PartFour partFour { get; set; }  
  
    //A creation policy mismatch.  Because there is no   
    //exported PartFour with a creation policy of Shared,  
    //this import does not match anything and will not be  
    //filled.  
}  
```  
  
<a name="life_cycle_and_disposing"></a>   
## Life Cycle and Disposing  
 Because parts are hosted in the composition container, their life cycle can be more complex than ordinary objects. Parts can implement two important life cycle-related interfaces: `IDisposable` and `IPartImportsSatisfiedNotification`.  
  
 Parts that require work to be performed at shut down or that need to release resources should implement `IDisposable`, as usual for .NET Framework objects. However, since the container creates and maintains references to parts, only the container that owns a part should call the `Dispose` method on it. The container itself implements `IDisposable`, and as portion of its cleanup in `Dispose` it will call `Dispose` on all the parts that it owns. For this reason, you should always dispose the composition container when it and any parts it owns are no longer needed.  
  
 For long-lived composition containers, memory consumption by parts with a creation policy of non-shared can become a problem. These non-shared parts can be created multiple times and will not be disposed until the container itself is disposed. To deal with this, the container provides the `ReleaseExport` method. Calling this method on a non-shared export removes that export from the composition container and disposes it. Parts that are used only by the removed export, and so on down the tree, are also removed and disposed. In this way, resources can be reclaimed without disposing the composition container itself.  
  
 `IPartImportsSatisfiedNotification` contains one method named `OnImportsSatisfied`. This method is called by the composition container on any parts that implement the interface when composition has been completed and the part's imports are ready for use. Parts are created by the composition engine to fill the imports of other parts. Before the imports of a part have been set, you cannot perform any initialization that relies on or manipulates imported values in the part constructor unless those values have been specified as prerequisites by using the `ImportingConstructor` attribute. This is normally the preferred method, but in some cases, constructor injection may not be available. In those cases, initialization can be performed in `OnImportsSatisfied`, and the part should implement `IPartImportsSatisfiedNotification`.  
  
## See Also  
 [Channel 9 Video: Open Up Your Applications with the Managed Extensibility Framework](http://channel9.msdn.com/events/TechEd/NorthAmerica/2009/DTL328)  
 [Channel 9 Video: Managed Extensibility Framework (MEF) 2.0](http://channel9.msdn.com/posts/NET-45-Oleg-Lvovitch-and-Kevin-Ransom-Managed-Extensibility-Framework-MEF-20)
