[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native,
     IsByteOrdered=true,  
     Name="Point",ValidationMethodName = "ValidatePoint")]
public struct Point : INullable
{