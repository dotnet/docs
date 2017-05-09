All: DataContractResolver.dll Types.dll

Types.dll: types.cs
  csc /t:library types.cs /r:System.Runtime.Serialization.dll /r:System.Xml.dll

DataContractResolver.dll: DataContractResolver.cs Types.dll
  csc /t:library DataContractResolver.cs /r:System.Runtime.Serialization.dll /r:types.dll