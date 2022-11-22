Imports System
Imports System.Runtime.Serialization
Imports System.Security.Permissions

Namespace ca2237

    ' <SerializableAttribute> _ 
    Public Class BaseType
        Implements ISerializable

        Dim baseValue As Integer

        Sub New()
            baseValue = 3
        End Sub

        Protected Sub New(
         info As SerializationInfo, context As StreamingContext)

            baseValue = info.GetInt32("baseValue")

        End Sub

        Overridable Sub GetObjectData(
         info As SerializationInfo, context As StreamingContext) _
         Implements ISerializable.GetObjectData

            info.AddValue("baseValue", baseValue)

        End Sub

    End Class

End Namespace
