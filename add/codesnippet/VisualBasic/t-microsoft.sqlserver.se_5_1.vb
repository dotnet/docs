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