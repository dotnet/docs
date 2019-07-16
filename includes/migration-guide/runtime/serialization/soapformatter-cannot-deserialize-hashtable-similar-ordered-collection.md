### SoapFormatter cannot deserialize Hashtable and similar ordered collection objects

|   |   |
|---|---|
|Details|The <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter?displayProperty=name> does not guarantee that objects serialized under one .NET Framework version will successfully deserialize under a different version. Specifically, some ordered collections (like <xref:System.Collections.Hashtable?displayProperty=name>) added members between 4.0 and 4.5 such that objects of these types cannot deserialize with .NET Framework 4.0 if they were serialized with .NET Framework 4.5. Note that if the serialized data is both serialized and deserialized with the same .NET Framework version, no issue will occur.|
|Suggestion|<xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter?displayProperty=name> serialization should be replaced with <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter?displayProperty=name> serialization or <xref:System.Runtime.Serialization.NetDataContractSerializer?displayProperty=name> to be resilient to .NET Framework changes.|
|Scope|Minor|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter.Serialize(System.IO.Stream,System.Object)?displayProperty=nameWithType></li><li><xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter.Serialize(System.IO.Stream,System.Object,System.Runtime.Remoting.Messaging.Header[])?displayProperty=nameWithType></li><li><xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter.Deserialize(System.IO.Stream)?displayProperty=nameWithType></li><li><xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter.Deserialize(System.IO.Stream,System.Runtime.Remoting.Messaging.HeaderHandler)?displayProperty=nameWithType></li></ul>|
