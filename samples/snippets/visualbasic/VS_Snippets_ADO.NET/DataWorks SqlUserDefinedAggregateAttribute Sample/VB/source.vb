'<Snippet1>
Imports System
Imports System.Data
Imports System.IO
Imports Microsoft.SqlServer.Server

<Serializable(), SqlUserDefinedAggregate(Microsoft.SqlServer.Server.Format.UserDefined, _ 
                                         IsInvariantToNulls:=True, _ 
                                         IsInvariantToDuplicates:=False, _
                                         IsInvariantToOrder:=False, _
                                         MaxByteSize:=8000)> _
Public Class Concatenate
    Implements Microsoft.SqlServer.Server.IBinarySerialize
'</Snippet1>

Public Sub Read(ByVal r As BinaryReader) Implements Microsoft.SqlServer.Server.IBinarySerialize.Read
        
    End Sub

    Public Sub Write(ByVal w As BinaryWriter) Implements Microsoft.SqlServer.Server.IBinarySerialize.Write
        
    End Sub
End Class