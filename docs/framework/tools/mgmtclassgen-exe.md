---
title: "Mgmtclassgen.exe (Management Strongly Typed Class Generator)"
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
  - "CIM types"
  - "Management Strongly Typed Class Generator"
  - "WMI class"
  - "Mgmtclassgen.exe"
  - "early-bound managed classes"
ms.assetid: 02ce6699-49b5-4a0b-b0d5-1003c491232e
caps.latest.revision: 21
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Mgmtclassgen.exe (Management Strongly Typed Class Generator)
The Management Strongly Typed Class Generator tool enables you to quickly generate an early-bound managed class for a specified Windows Management Instrumentation (WMI) class. The generated class simplifies the code you must write to access an instance of the WMI class.  
  
## Syntax  
  
```  
mgmtclassgen   
WMIClass [options]   
```  
  
|Argument|Description|  
|--------------|-----------------|  
|*WMIClass*|The Windows Management Instrumentation class for which to generate an early-bound managed class.|  
  
|Option|Description|  
|------------|-----------------|  
|**/l**  *language*|Specifies the language in which to generate the early-bound managed class. You can specify **CS** (C#; default), **VB** (Visual Basic),  **MC** (C++), or **JS** (JScript) as the language argument.|  
|**/m**  *machine*|Specifies the computer to connect to, where the WMI class resides. The default is the local computer.|  
|**/n**  *path*|Specifies the path to the WMI namespace that contains the WMI class. If you do not specify this option, the tool generates code for *WMIClass* in the default **Root\cimv2** namespace.|  
|**/o**  *classnamespace*|Specifies the .NET namespace in which to generate the managed code class. If you do not specify this option, the tool generates the namespace using the WMI namespace and the schema prefix. The schema prefix is the part of the class name preceding the underscore character. For example, for the **Win32_OperatingSystem** class in the **Root\cimv2** namespace, the tool would generate the class in **ROOT.CIMV2.Win32**.|  
|**/p**  *filepath*|Specifies the path to the file in which to save the generated code. If you do not specify this option, the tool creates the file in the current directory. It names the class and file in which it generates the class using the *WMIClass* argument. The name of the class and the file are the same as the name of the *WMIClass.* If *WMIClass* contains an underscore character, the tool uses the part of the class name following the underscore character. For example, if the *WMIClass* name is in the format **Win32_LogicalDisk**, the generated class and file is named "logicaldisk". If a file already exists, the tool overwrites the existing file.|  
|**/pw**  *password*|Specifies the password to use when logging on to a computer specified by the **/m** option.|  
|**/u**  *user name*|Specifies the user name to use when logging on to a computer specified by the **/m** option.|  
|**/?**|Displays command syntax and options for the tool.|  
  
## Remarks  
 Mgmtclassgen.exe uses the <xref:System.Management.ManagementClass.GetStronglyTypedClassCode%2A?displayProperty=nameWithType> method. Therefore, you can use any custom code provider to generate code in managed languages other than C#, Visual Basic, and JScript.  
  
 Note that generated classes are bound to the schema for which they are generated. If the underlying schema changes, you must regenerate the class if you want it to reflect changes to the schema.  
  
 The following table shows how WMI Common Information Model (CIM) types map to data types in a generated class:  
  
|CIM type|Data type in the generated class|  
|--------------|--------------------------------------|  
|CIM_SINT8|**SByte**|  
|CIM_UINT8|**Byte**|  
|CIM_SINT16|**Int16**|  
|CIM_UINT16|**UInt16**|  
|CIM_SINT32|**Int32**|  
|SIM_UINT32|**UInt32**|  
|CIM_SINT64|**Int64**|  
|CIM_UINT64|**UInt64**|  
|CIM_REAL32|**Single**|  
|CIM_REAL64|**Double**|  
|CIM_BOOLEAN|**Boolean**|  
|CIM_String|**String**|  
|CIM_DATETIME|**DateTime** or **TimeSpan**|  
|CIM_REFERENCE|**ManagementPath**|  
|CIM_CHAR16|**Char**|  
|CIM_OBJECT|**ManagementBaseObject**|  
|CIM_IUNKNOWN|**Object**|  
|CIM_ARRAY|Array of the above mentioned objects|  
  
 Note the following behaviors when you generate a WMI class:  
  
-   It is possible for a standard public property or method to have the same name as an existing property or method. If this occurs, the tool changes the name of the property or method in the generated class to avoid naming conflicts.  
  
-   It is possible for the name of a property or method in a generated class to be a keyword in the target programming language. If this occurs, the tool changes the name of the property or method in the generated class to avoid naming conflicts.  
  
-   In WMI, qualifiers are modifiers that contain information to describe a class, instance, property, or method. WMI uses standard qualifiers such as **Read**, **Write**, and **Key** to describe a property in a generated class. For example, a property that is modified with a **Read** qualifier is defined only with a property **get** accessor in the generated class. Because a property marked with the **Read** qualifier is intended to be read-only, a **set** accessor is not defined.  
  
-   A numeric property can be modified by the **Values** and **ValueMaps** qualifiers to indicate that the property can be set only to specified permissible values. An enumeration is generated with these **Values** and **ValueMaps** and the property is mapped to the enumeration.  
  
-   The WMI uses the term singleton to describe a class that can have only one instance. Therefore, the default constructor for a singleton class will initialize the class to the only instance of the class.  
  
-   A WMI class can have properties that are objects. When you generate a strongly-typed class for this type of WMI class, you should consider generating strongly-typed classes for the types of the embedded object properties. This will allow you to access the embedded objects in a strongly-typed manner. Note that the generated code might not be able to detect the type of the embedded object. In this case, a comment will be created in the generated code to notify you of this issue. You can then modify the generated code to type the property to the other generated class.  
  
-   In WMI, the data value of the CIM_DATETIME data type can represent either a specific date and time or a time interval. If the data value represents a date and time, the data type in the generated class is **DateTime**. If the data value represents a time interval, the data type in the generated class is **TimeSpan**.  
  
 You can alternately generate a strongly-typed class using the Server Explorer Management Extension in Visual Studio .NET.  
  
 For more information about WMI, see the **Windows Management Instrumentation** topic in the Platform SDK documentation.  
  
## Examples  
 The following command generates a managed class in C# code for the **Win32_LogicalDisk** WMI class in the **Root\cimv2** namespace. The tool writes the managed class to the source file at c:\disk.cs in the **ROOT.CIMV2.Win32** namespace.  
  
```  
mgmtclassgen Win32_LogicalDisk /n root\cimv2 /l CS /p c:\disk.cs  
```  
  
 The following code example shows how to use a generated class programmatically. First, an instance of the class is enumerated and the path is printed. Next, an instance of the generated class to be initialized is created with an instance of WMI. `Process` is the class generated for **Win32_Process** and `LogicalDisk` is the class generated for **Win32_LogicalDisk** in the **Root\cimv2** namespace.  
  
```vb  
Imports System  
Imports System.Management  
Imports ROOT.CIMV2.Win32  
  
Public Class App     
   Public Shared Sub Main()        
      ' Enumerate instances of the Win32_process.  
      ' Print the Name property of the instance.  
      Dim ps As Process     
      For Each ps In  Process.GetInstances()  
         Console.WriteLine(ps.Name)  
      Next ps  
  
      ' Initialize the instance of LogicalDisk with  
      ' the WMI instance pointing to logical drive d:.  
      Dim dskD As New LogicalDisk(New _  
         ManagementPath("win32_LogicalDisk.DeviceId=""d:"""))  
      Console.WriteLine(dskD.Caption)  
   End Sub  
End Class  
```  
  
```csharp  
using System;  
using System.Management;  
using ROOT.CIMV2.Win32;  
  
public class App  
{  
   public static void Main()  
   {  
      // Enumerate instances of the Win32_process.  
      // Print the Name property of the instance.  
      foreach(Process ps in Process.GetInstances())  
      {  
         Console.WriteLine(ps.Name);  
      }  
  
      // Initialize the instance of LogicalDisk with  
      // the WMI instance pointing to logical drive d:.  
      LogicalDisk dskD = new LogicalDisk(new ManagementPath(  
        "win32_LogicalDisk.DeviceId=\"d:\""));  
      Console.WriteLine(dskD.Caption);  
   }  
}  
```  
  
## See Also  
 <xref:System.Management>  
 <xref:System.Management.ManagementClass.GetStronglyTypedClassCode%2A?displayProperty=nameWithType>  
 <xref:System.CodeDom.Compiler.CodeDomProvider?displayProperty=nameWithType>  
 [Tools](../../../docs/framework/tools/index.md)  
 [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md)
