Imports System.ServiceModel
Imports System.Security.Permissions
Imports System.Runtime.Serialization
Imports System.Xml
Namespace DataContractsPrime
    'C_DataContractVersioning#1
    '<snippet1>
    ' Version 1
    <DataContract()> _
    Public Class Person
        <DataMember()> _
        Private Phone As String
    End Class
    '</snippet1>

End Namespace


Namespace DataContracts
    '<snippet2>
    ' Version 2. This is a non-breaking change because the data contract 
    ' has not changed, even though the type has.
    <DataContract()> _
    Public Class Person
        <DataMember(Name:="Phone")> _
        Private Telephone As String
    End Class
    '</snippet2>
    'C_DataContractVersioning#2

    '<snippet3>
    ' Version 1 of a data contract, on machine V1.
    <DataContract(Name:="Car")> _
    Public Class CarV1
        <DataMember()> _
        Private Model As String
    End Class

    ' Version 2 of the same data contract, on machine V2.
    <DataContract(Name:="Car")> _
    Public Class CarV2
        <DataMember()> _
        Private Model As String

        <DataMember()> _
        Private HorsePower As Integer
    End Class
    '</snippet3>

    Public Class Test

        Shared Sub Main()

        End Sub
    End Class
End Namespace
