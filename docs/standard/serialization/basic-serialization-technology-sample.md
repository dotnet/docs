---
title: "Basic Serialization Technology Sample"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9d824e16-08d1-4a36-bc7f-2388c1f75f34
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Basic Serialization Technology Sample
[Download sample](https://download.microsoft.com/download/4/7/B/47B2164C-E780-4B10-8DE4-2CB5B886E0A6/Technologies/Serialization/Runtime%20Serialization/Basic.zip.exe)  
  
 This sample demonstrates the common language runtime's ability to serialize an object graph in memory to a stream. This sample can use either the <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter> or the <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> for serialization. A linked list, filled with data, is serialized or deserialized to or from a file stream. In either case the list is displayed so that you can see the results. The linked list is of type `LinkedList`, a type defined by this sample.  
  
 Review comments in the source code and build.proj files for more information on serialization.  
  
### To build the sample using the Command Prompt  
  
1.  Navigate to one of the language-specific subdirectories under the Technologies\Serialization\Runtime Serialization\Basic directory, using the command prompt.  
  
2.  Type **msbuild SerializationCS.sln**, **msbuild SerializationJSL.sln** or **msbuild SerializationVB.sln**, depending on your choice of programming language, at the command line.  
  
### To build the sample using Visual Studio  
  
1.  Open [!INCLUDE[fileExplorer](../../../includes/fileexplorer-md.md)] and navigate to one of the language-specific subdirectories for the sample.  
  
2.  Double-click the icon for the SerializationCS.sln, SerializationJSL.sln or SerializationVB.sln file, depending on your choice of programming language, to open the file in Visual Studio.  
  
3.  In the **Build** menu, select **Build Solution**.  
  
 The sample application will be built in the default \bin or \bin\Debug subdirectory.  
  
### To run the sample  
  
1.  Navigate to the directory containing the built executable.  
  
2.  Type **Serialization.exe**, along with the parameter values you desire, at the command line.  
  
    > [!NOTE]
    >  This sample builds a console application. You must launch it using the command prompt in order to view its output.  
  
## Remarks  
 The sample application accepts command line parameters indicating which test you would like to execute. To serialize a 10-node list to a file named **Test.xml** using the SOAP formatter, use the parameters **sx Test.xml 10**.  
  
 For Example:  
  
 **Serialize.exe -sx Test.xml 10**  
  
 To deserialize the **Test.xml** file from the previous example, use the parameters **dx Test.xml**.  
  
 For Example:  
  
 **Serialize.exe -dx Test.xml**  
  
 In the two examples above, the "x" in the command line switch indicates that you want XML SOAP serialization. You can use "b" in its place to use binary serialization. If you wish to try serialization with a very large number of nodes, you might want to redirect the console output to a file.  
  
 For Example:  
  
 **Serialize.exe -sb Test.bin 10000 >somefile.txt**  
  
 The following bullets briefly describe the classes and technologies used by this sample.  
  
-   Runtime Serialization  
  
    -   <xref:System.Runtime.Serialization.IFormatter> Used to refer to either a <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> or a <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter> object.  
  
    -   <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> Used to serialize a linked list to a stream in a binary format. The binary formatter uses a format that only the <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> type understands. However, the data is concise.  
  
    -   <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter> Used to serialize a linked list to a stream in the SOAP format. SOAP is a standard format.  
  
-   Stream I/O  
  
    -   <xref:System.IO.Stream> Used to serialize and deserialize. The specific stream type used in this sample is the <xref:System.IO.FileStream> type. However, serialization can be used with any type derived from <xref:System.IO.Stream>.  
  
    -   <xref:System.IO.File> Used to create <xref:System.IO.FileStream> objects for reading and creating files on disk.  
  
    -   <xref:System.IO.FileStream> Used to serialize and deserialize linked lists.  
  
## See Also  
 <xref:System.IO>  
 <xref:System.IO.File>  
 <xref:System.IO.FileStream>  
 <xref:System.IO.Stream>  
 <xref:System.Random>  
 <xref:System.Runtime.Serialization>  
 <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter>  
 <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter>  
 <xref:System.Runtime.Serialization.IFormatter>  
 <xref:System.SerializableAttribute>  
 <xref:System.Xml.Serialization>  
 [Basic Serialization](../../../docs/standard/serialization/basic-serialization.md)  
 [Binary Serialization](../../../docs/standard/serialization/binary-serialization.md)  
 [Controlling XML Serialization Using Attributes](../../../docs/standard/serialization/controlling-xml-serialization-using-attributes.md)  
 [Introducing XML Serialization](../../../docs/standard/serialization/introducing-xml-serialization.md)  
 [Serialization](../../../docs/standard/serialization/index.md)  
 [XML and SOAP Serialization](../../../docs/standard/serialization/xml-and-soap-serialization.md)
