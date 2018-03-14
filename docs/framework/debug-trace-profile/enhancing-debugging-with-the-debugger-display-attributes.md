---
title: "Enhancing Debugging with the Debugger Display Attributes"
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
  - "cpp"
helpviewer_keywords: 
  - "debugger, display attributes"
  - "DebuggerTypeProxyAttribute attribute"
  - "debugging [.NET Framework], debugger display attributes"
  - "DebuggerDisplayAttribute attribute"
  - "display attributes for debugger"
  - "DebuggerBrowsableAttribute attribute"
ms.assetid: 72bb7aa9-459b-42c4-9163-9312fab4c410
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Enhancing Debugging with the Debugger Display Attributes
Debugger display attributes allow the developer of the type, who specifies and best understands the runtime behavior of that type, to also specify what that type will look like when it is displayed in a debugger. In addition, debugger display attributes that provide a `Target` property can be applied at the assembly level by users without knowledge of the source code. The <xref:System.Diagnostics.DebuggerDisplayAttribute> attribute controls how a type or member is displayed in the debugger variable windows. The <xref:System.Diagnostics.DebuggerBrowsableAttribute> attribute determines if and how a field or property is displayed in the debugger variable windows. The <xref:System.Diagnostics.DebuggerTypeProxyAttribute> attribute specifies a substitute type, or a proxy, for a type and changes the way the type is displayed in debugger windows. When you view a variable that has a proxy, or substitute type, the proxy stands in for the original type in the debugger display window**.** The debugger variable windowdisplays only the public members of the proxy type. Private members are not displayed.  
  
## Using the DebuggerDisplayAttribute  
 The <xref:System.Diagnostics.DebuggerDisplayAttribute.%23ctor%2A> constructor has a single argument: a string to be displayed in the value column for instances of the type. This string can contain braces ({ and }). The text within a pair of braces is evaluated as an expression. For example, the following C# code causes "Count = 4" to be displayed when the plus sign (+) is selected to expand the debugger display for an instance of `MyHashtable`.  
  
```csharp
[DebuggerDisplay("Count = {count}")]  
class MyHashtable  
{  
    public int count = 4;  
}  
```
  
 Attributes applied to properties referenced in the expression are not processed. For the C# compiler, a general expression is allowed that has only implicit access to this reference for the current instance of the target type. The expression is limited; there is no access to aliases, locals, or pointers. In C# code, you can use a general expression between the braces that has implicit access to the `this` pointer for the current instance of the target type only.  
  
 For example, if a C# object has an overridden `ToString()`, the debugger will call the override and show its result instead of the standard `{<typeName>}.` Thus, if you have overridden `ToString()`, you do not need to use <xref:System.Diagnostics.DebuggerDisplayAttribute>. If you use both, the <xref:System.Diagnostics.DebuggerDisplayAttribute> attribute takes precedence over the `ToString()` override.  
  
## Using the DebuggerBrowsableAttribute  
 Apply the <xref:System.Diagnostics.DebuggerBrowsableAttribute> to a field or property to specify how the field or property is to be displayed in the debugger window. The constructor for this attribute takes one of the <xref:System.Diagnostics.DebuggerBrowsableState> enumeration values, which specifies one of the following states:  
  
-   <xref:System.Diagnostics.DebuggerBrowsableState.Never> indicates that the member is not displayed in the data window.  For example, using this value for the <xref:System.Diagnostics.DebuggerBrowsableAttribute> on a field removes the field from the hierarchy; the field is not displayed when you expand the enclosing type by clicking the plus sign (+) for the type instance.  
  
-   <xref:System.Diagnostics.DebuggerBrowsableState.Collapsed> indicates that the member is displayed but not expanded by default.  This is the default behavior.  
  
-   <xref:System.Diagnostics.DebuggerBrowsableState.RootHidden> indicates that the member itself is not shown, but its constituent objects are displayed if it is an array or collection.  
  
> [!NOTE]
>  The <xref:System.Diagnostics.DebuggerBrowsableAttribute> is not supported by Visual Basic in the .NET Framework version 2.0.  
  
 The following code example shows the use of the <xref:System.Diagnostics.DebuggerBrowsableAttribute> to prevent the property following it from appearing in the debug window for the class.  
  
```csharp
[DebuggerBrowsable(DebuggerBrowsableState.Never)]  
public static string y = "Test String";  
```  
  
## Using the DebuggerTypeProxy  
 Use the <xref:System.Diagnostics.DebuggerTypeProxyAttribute> attribute when you need to significantly and fundamentally change the debugging view of a type, but not change the type itself. The <xref:System.Diagnostics.DebuggerTypeProxyAttribute> attribute is used to specify a display proxy for a type, allowing a developer to tailor the view for the type.  This attribute, like the <xref:System.Diagnostics.DebuggerDisplayAttribute>, can be used at the assembly level, in which case the <xref:System.Diagnostics.DebuggerTypeProxyAttribute.Target%2A> property specifies the type for which the proxy will be used. The recommended usage is that this attribute specifies a private nested type that occurs within the type to which the attribute is applied.  An expression evaluator that supports type viewers checks for this attribute when a type is displayed. If the attribute is found, the expression evaluator substitutes the display proxy type for the type the attribute is applied to.  
  
 When the <xref:System.Diagnostics.DebuggerTypeProxyAttribute> is present, the debugger variable window displays only the public members of the proxy type. Private members are not displayed. The behavior of the data window is not changed by attribute-enhanced views.  
  
 To avoid unnecessary performance penalties, attributes of the display proxy are not processed until the object is expanded, either through the user clicking the plus sign (+) next to the type in a data window, or through the application of the <xref:System.Diagnostics.DebuggerBrowsableAttribute> attribute. Therefore, it is recommended that no attributes be applied to the display type. Attributes can and should be applied within the body of the display type.  
  
 The following code example shows the use of the <xref:System.Diagnostics.DebuggerTypeProxyAttribute> to specify a type to be used as a debugger display proxy.  
  
```csharp
[DebuggerTypeProxy(typeof(HashtableDebugView))]  
class MyHashtable : Hashtable  
{  
    private const string TestString =   
        "This should not appear in the debug window.";  
  
    internal class HashtableDebugView  
    {  
        private Hashtable hashtable;  
        public const string TestStringProxy =   
            "This should appear in the debug window.";  
  
        // The constructor for the type proxy class must have a   
        // constructor that takes the target type as a parameter.  
        public HashtableDebugView(Hashtable hashtable)  
        {  
            this.hashtable = hashtable;  
        }  
    }  
}  
```  
  
## Example  
  
### Description  
 The following code example can be viewed in [!INCLUDE[vsprvslong](../../../includes/vsprvslong-md.md)] to see the results of applying the <xref:System.Diagnostics.DebuggerDisplayAttribute>, <xref:System.Diagnostics.DebuggerBrowsableAttribute>, and <xref:System.Diagnostics.DebuggerTypeProxyAttribute> attributes.  
  
### Code  
 [!code-cpp[System.Diagnostics.DebuggerBrowsableAttribute#1](../../../samples/snippets/cpp/VS_Snippets_CLR_System/system.Diagnostics.DebuggerBrowsableAttribute/cpp/program.cpp#1)]
 [!code-csharp[System.Diagnostics.DebuggerBrowsableAttribute#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.Diagnostics.DebuggerBrowsableAttribute/CS/program.cs#1)]
 [!code-vb[System.Diagnostics.DebuggerBrowsableAttribute#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.Diagnostics.DebuggerBrowsableAttribute/VB/module1.vb#1)]  
  
## See Also  
 <xref:System.Diagnostics.DebuggerDisplayAttribute>  
 <xref:System.Diagnostics.DebuggerBrowsableAttribute>  
 <xref:System.Diagnostics.DebuggerTypeProxyAttribute>
