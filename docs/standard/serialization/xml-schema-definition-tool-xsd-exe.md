---
title: "XML Schema Definition Tool (Xsd.exe)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a6e6e65c-347f-4494-9457-653bf29baac2
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# XML Schema Definition Tool (Xsd.exe)
The XML Schema Definition (Xsd.exe) tool generates XML schema or common language runtime classes from XDR, XML, and XSD files, or from classes in a runtime assembly.  
  
## Syntax  
  
```  
xsd file.xdr [/outputdir:directory][/parameters:file.xml]  
xsd file.xml [/outputdir:directory] [/parameters:file.xml]  
xsd file.xsd {/classes | /dataset} [/element:element]   
             [/enableLinqDataSet] [/language:language]   
                          [/namespace:namespace] [/outputdir:directory] [URI:uri]   
                          [/parameters:file.xml]  
xsd {file.dll | file.exe} [/outputdir:directory] [/type:typename [...]][/parameters:file.xml]  
```  
  
## Argument  
  
|Argument|Description|  
|--------------|-----------------|  
|*file.extension*|Specifies the input file to convert. You must specify the extensionas one of the following: .xdr, .xml, .xsd, .dll, or .exe.<br /><br /> If you specify an XDR schema file (.xdr extension), Xsd.exe converts the XDR schema to an XSD schema. The output file has the same name as the XDR schema, but with the .xsd extension.<br /><br /> If you specify an XML file (.xml extension), Xsd.exe infers a schema from the data in the file and produces an XSD schema. The output file has the same name as the XML file, but with the .xsd extension.<br /><br /> If you specify an XML schema file (.xsd extension), Xsd.exe generates source code for runtime objects that correspond to the XML schema.<br /><br /> If you specify a runtime assembly file (.exe or .dll extension), Xsd.exe generates schemas for one or more types in that assembly. You can use the `/type` option to specify the types for which to generate schemas. The output schemas are named schema0.xsd, schema1.xsd, and so on. Xsd.exe produces multiple schemas only if the given types specify a namespace using the `XMLRoot` custom attribute.|  
  
## General Options  
  
|Option|Description|  
|------------|-----------------|  
|**/h**[**elp**]|Displays command syntax and options for the tool.|  
|**/o**[**utputdir**]**:***directory*|Specifies the directory for output files. This argument can appear only once. The default is the current directory.|  
|**/?**|Displays command syntax and options for the tool.|  
|**/P[arameters]:** *file.xml*|Read options for various operation modes from the specified .xml file. The short form is '/p:'. For more information, see the following Remarks section.|  
  
## XSD File Options  
 You must specify only one of the following options for .xsd files.  
  
|Option|Description|  
|------------|-----------------|  
|**/c**[**lasses**]|Generates classes that correspond to the specified schema. To read XML data into the object, use the `System.Xml.Serialization.XmlSerializer.Deserializer` method.|  
|**/d**[**ataset**]|Generates a class derived from <xref:System.Data.DataSet> that corresponds to the specified schema. To read XML data into the derived class, use the `System.Data.DataSet.ReadXml` method.|  
  
 You can also specify any of the following options for .xsd files.  
  
|Option|Description|  
|------------|-----------------|  
|**/e**[**lement**]**:***element*|Specifies the element in the schema to generate code for. By default all elements are typed. You can specify this argument more than once.|  
|**/enableDataBinding**|Implements the <xref:System.ComponentModel.INotifyPropertyChanged> interface on all generated types to enable data binding. The short form is `/edb`.|  
|**/enableLinqDataSet**|(Short form: `/eld`.) Specifies that the generated DataSet can be queried against using LINQ to DataSet. This option is used when the /dataset option is also specified. For more information, see [LINQ to DataSet Overview](../../../docs/framework/data/adonet/linq-to-dataset-overview.md) and [Querying Typed DataSets](../../../docs/framework/data/adonet/querying-typed-datasets.md). For general information about using LINQ, see [LINQ (Language-Integrated Query)](https://msdn.microsoft.com/library/a73c4aec-5d15-4e98-b962-1274021ea93d).|  
|**/f**[**ields**]|Generates fields instead of properties. By default, properties are generated.|  
|**/l**[**anguage**]**:***language*|Specifies the programming language to use. Choose from `CS` (C#, which is the default), `VB` (Visual Basic), `JS` (JScript), or `VJS` (Visual J#). You can also specify a fully qualified name for a class implementing <xref:System.CodeDom.Compiler.CodeDomProvider?displayProperty=nameWithType>|  
|**/n**[**amespace**]**:***namespace*|Specifies the runtime namespace for the generated types. The default namespace is `Schemas`.|  
|**/nologo**|Suppresses the banner.|  
|**/order**|Generates explicit order identifiers on all particle members.|  
|**/o[ut]:** *directoryName*|Specifies the output directory to place the files in. The default is the current directory.|  
|**/u**[**ri**]**:***uri*|Specifies the URI for the elements in the schema to generate code for. This URI, if present, applies to all elements specified with the `/element` option.|  
  
## DLL and EXE File Options  
  
|Option|Description|  
|------------|-----------------|  
|**/t**[**ype**]**:***typename*|Specifies the name of the type to create a schema for. You can specify multiple type arguments. If *typename* does not specify a namespace, Xsd.exe matches all types in the assembly with the specified type. If *typename* specifies a namespace, only that type is matched. If *typename* ends with an asterisk character (\*), the tool matches all types that start with the string preceding the \*. If you omit the `/type` option, Xsd.exe generates schemas for all types in the assembly.|  
  
## Remarks  
 The following table shows the operations that Xsd.exe performs.  
  
 XDR to XSD  
 Generates an XML schema from an XML-Data-Reduced schema file. XDR is an early XML-based schema format.  
  
 XML to XSD  
 Generates an XML schema from an XML file.  
  
 XSD to DataSet  
 Generates common language runtime <xref:System.Data.DataSet> classes from an XSD schema file. The generated classes provide a rich object model for regular XML data.  
  
 XSD to Classes  
 Generates runtime classes from an XSD schema file. The generated classes can be used in conjunction with <xref:System.Xml.Serialization.XmlSerializer?displayProperty=nameWithType> to read and write XML code that follows the schema.  
  
 Classes to XSD  
 Generates an XML schema from a type or types in a runtime assembly file. The generated schema defines the XML format used by `System.Xml.Serialization.XmlSerializer`.  
  
 Xsd.exe only allows you to manipulate XML schemas that follow the XML Schema Definition (XSD) language proposed by the World Wide Web Consortium (W3C). For more information on the XML Schema Definition proposal or the XML standard, see http://w3.org.  
  
## Setting Options with an XML File  
 By using the `/parameters` switch, you can specify a single XML file that sets various options. The options you can set depend on how you are using the XSD.exe tool. Choices include generating schemas, generating code files, or generating code files that include `DataSet` features. For example, you can set the `<assembly\>` element to the name of an executable (.exe) or type library (.dll) file when generating a schema, but not when generating a code file. The following XML shows how to use the `<generateSchemas\>` element with a specified executable:  
  
```xml  
<!-- This is in a file named GenerateSchemas.xml. -->  
<xsd xmlns='http://microsoft.com/dotnet/tools/xsd/'>  
<generateSchemas>  
   <assembly>ConsoleApplication1.exe</assembly>  
</generateSchemas>  
</xsd>  
```  
  
 If the preceding XML is contained in a file named GenerateSchemas.xml, then use the `/parameters` switch by typing the following at a command prompt and pressing ENTER:  
  
 `xsd /p:GenerateSchemas.xml`  
  
 On the other hand, if you are generating a schema for a single type found in the assembly, you can use the following XML:  
  
```xml  
<!-- This is in a file named GenerateSchemaFromType.xml. -->  
<xsd xmlns='http://microsoft.com/dotnet/tools/xsd/'>  
<generateSchemas>  
   <type>IDItems</type>  
</generateSchemas>  
</xsd>  
```  
  
 But to use preceding code, you must also supply the name of the assembly at the command prompt. Type the following at a command prompt (presuming the XML file is named GenerateSchemaFromType.xml):  
  
 `xsd /p:GenerateSchemaFromType.xml ConsoleApplication1.exe`  
  
 You must specify only one of the following options for the `\<generateSchemas>` element.  
  
|Element|Description|  
|-------------|-----------------|  
|\<assembly>|Specifies an assembly to generate the schema from.|  
|\<type>|Specifies a type found in an assembly to generate a schema for.|  
|\<xml>|Specifies an XML file to generate a schema for.|  
|\<xdr>|Specifies an XDR file to generate a schema for.|  
  
 To generate a code file, use the `<generateClasses\>` element. The following example generates a code file. Note that two attributes are also shown that allow you to set the programming language and namespace of the generated file.  
  
```xml  
<xsd xmlns='http://microsoft.com/dotnet/tools/xsd/'>  
<generateClasses language='VB' namespace='Microsoft.Serialization.Examples'/>  
</xsd>  
<!-- You must supply an .xsd file when typing in the command line.-->  
<!-- For example: xsd /p:genClasses mySchema.xsd -->  
```  
  
 Options you can set for the `\<generateClasses>` element include the following.  
  
|Element|Description|  
|-------------|-----------------|  
|\<element>|Specifies an element in the .xsd file to generate code for.|  
|\<schemaImporterExtensions>|Specifies a type derived from the <xref:System.Xml.Serialization.Advanced.SchemaImporterExtension> class.|  
|\<schema>|Specifies a XML Schema file to generate code for.  Multiple XML Schema files can be specified using multiple \<schema> elements.|  
  
 The following table shows the attributes that can also be used with the `<generateClasses\>` element.  
  
|Attribute|Description|  
|---------------|-----------------|  
|language|Specifies the programming language to use. Choose from `CS` (C#, the default), `VB` (Visual Basic), `JS` (JScript), or `VJS` (Visual J#). You can also specify a fully qualified name for a class that implements <xref:System.CodeDom.Compiler.CodeDomProvider>.|  
|namespace|Specifies the namespace for the generated code. The namespace must conform to CLR standards (for example, no spaces or backslash characters).|  
|options|One of the following values: `none`, `properties` (generates properties instead of public fields), `order`, or `enableDataBinding` (see the `/order` and `/enableDataBinding` switches in the preceding XSD File Options section.|  
  
 You can also control how `DataSet` code is generated by using the `<generateDataSets\>` element. The following XML specifies that the generated codeuses `DataSet` structures (such as the <xref:System.Data.DataTable> class) to create Visual Basic code for a specified element. The generated DataSet structures will support LINQ queries.  
  
 `<xsd xmlns='http://microsoft.com/dotnet/tools/xsd/'>`  
  
 `<generateDataSet language='VB' namespace='Microsoft.Serialization.Examples' enableLinqDataSet='true'>`  
  
 `</generateDataSet>`  
  
 `</xsd>`  
  
 Options you can set for the `<generateDataSet\>` element include the following.  
  
|Element|Description|  
|-------------|-----------------|  
|\<schema>|Specifies an XML Schema file to generate code for. Multiple XML Schema files can be specified using multiple \<schema> elements.|  
  
 The following table shows the attributes that can be used with the `<generateDataSet\>` element.  
  
|Attribute|Description|  
|---------------|-----------------|  
|enableLinqDataSet|Specifies that the generated DataSet can be queried against using LINQ to DataSet. The default value is false.|  
|language|Specifies the programming language to use. Choose from `CS` (C#, the default), `VB` (Visual Basic), `JS` (JScript), or `VJS` (Visual J#). You can also specify a fully qualified name for a class that implements <xref:System.CodeDom.Compiler.CodeDomProvider>.|  
|namespace|Specifies the namespace for the generated code. The namespace must conform to CLR standards (for example, no spaces or backslash characters).|  
  
 There are attributes that you can set on the top level `<xsd\>` element. These options can be used with any of the child elements (`<generateSchemas\>`, `<generateClasses\>` or `<generateDataSet\>`). The following XML code generates code for an element named "IDItems" in the output directory named "MyOutputDirectory".  
  
```xml  
<xsd xmlns='http://microsoft.com/dotnet/tools/xsd/' output='MyOutputDirectory'>  
<generateClasses>  
<element>IDItems</element>  
</generateClasses>  
</xsd>  
```  
  
 The following table shows the attributes that can also be used with the `\<xsd>` element.  
  
|Attribute|Description|  
|---------------|-----------------|  
|output|The name of a directory where the generated schema or code file will be placed.|  
|nologo|Suppresses the banner. Set to `true` or `false`.|  
|help|Displays command syntax and options for the tool. Set to `true` or `false`.|  
  
## Examples  
 The following command generates an XML schema from `myFile.xdr` and saves it to the current directory.  
  
```  
xsd myFile.xdr   
```  
  
 The following command generates an XML schema from `myFile.xml` and saves it to the specified directory.  
  
```  
xsd myFile.xml /outputdir:myOutputDir  
```  
  
 The following command generates a data set that corresponds to the specified schema in the C# language and saves it as `XSDSchemaFile.cs` in the current directory.  
  
```  
xsd /dataset /language:CS XSDSchemaFile.xsd  
```  
  
 The following command generates XML schemas for all types in the assembly `myAssembly.dll` and saves them as `schema0.xsd` in the current directory.  
  
```  
xsd myAssembly.dll    
```  
  
## See Also  
 <xref:System.Data.DataSet>  
 <xref:System.Xml.Serialization.XmlSerializer?displayProperty=nameWithType>  
 [Tools](../../../docs/framework/tools/index.md)      
 [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md)  
 [LINQ to DataSet Overview](../../../docs/framework/data/adonet/linq-to-dataset-overview.md)  
 [Querying Typed DataSets](../../../docs/framework/data/adonet/querying-typed-datasets.md)  
 [LINQ (Language-Integrated Query)](https://msdn.microsoft.com/library/a73c4aec-5d15-4e98-b962-1274021ea93d)
