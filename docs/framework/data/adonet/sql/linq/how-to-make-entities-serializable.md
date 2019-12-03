---
title: "How to: Make Entities Serializable"
ms.date: "03/30/2017"
ms.assetid: a6c5bf6e-064a-4f77-b74c-76b3a5dec309
---
# How to: Make Entities Serializable
You can make entities serializable when you generate your code. Entity classes are decorated with the <xref:System.Runtime.Serialization.DataContractAttribute> attribute, and columns with the <xref:System.Runtime.Serialization.DataMemberAttribute> attribute.  
  
 Developers using Visual Studio can use the Object Relational Designer for this purpose.  
  
 If you are using the SQLMetal command-line tool, use the **/serialization** option with the `unidirectional` argument. For more information, see [SqlMetal.exe (Code Generation Tool)](../../../../tools/sqlmetal-exe-code-generation-tool.md).  
  
## Example  
 The following SQLMetal command lines produce files that have serializable entities.  
  
```console  
sqlmetal /code:nwserializable.vb /language:vb "c:\northwnd.mdf" /sprocs /functions /pluralize /serialization:unidirectional  
```  
  
```console  
sqlmetal /code:nwserializable.cs /language:csharp "c:\northwnd.mdf" /sprocs /functions /pluralize /serialization:unidirectional  
```  
  
## See also

- [Serialization](serialization.md)
- [Creating the Object Model](creating-the-object-model.md)
