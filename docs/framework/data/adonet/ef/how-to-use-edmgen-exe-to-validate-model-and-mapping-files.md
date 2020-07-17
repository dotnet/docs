---
title: "How to: Use EdmGen.exe to Validate Model and Mapping Files"
ms.date: "03/30/2017"
ms.assetid: 2641906a-971a-4d0b-8aee-13fabc02a1cc
---
# How to: Use EdmGen.exe to Validate Model and Mapping Files
This topic shows how to use the [EDM Generator (EdmGen.exe)](edm-generator-edmgen-exe.md) tool to validate the model and mapping files. For more information, see [Entity Data Model](../entity-data-model.md).  
  
### To validate the School model using EdmGen.exe  
  
1. Create the School database. For more information, see [Creating the School Sample Database](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb399731(v=vs.100)).  
  
2. Generate the School model. For more information, see [How to: Use EdmGen.exe to Generate the Model and Mapping Files](how-to-use-edmgen-exe-to-generate-the-model-and-mapping-files.md).  
  
3. At the command prompt, execute the following command without line breaks:  
  
    ```console
    "%windir%\Microsoft.NET\Framework\v4.0.30319\edmgen.exe" /mode:ValidateArtifacts /inssdl:.\School.ssdl /inmsl:.\School.msl /incsdl:.\School.csdl  
    ```  
  
## See also

- [How to: Manually Configure an Entity Framework Project](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb738546(v=vs.100))
- [ADO.NET Entity Data Model Tools](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb399249(v=vs.100))
- [How to: Pre-Generate Views to Improve Query Performance](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb896240(v=vs.100))
- [How to: Use EdmGen.exe to Generate Object-Layer Code](how-to-use-edmgen-exe-to-generate-object-layer-code.md)
