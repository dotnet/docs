' Copyright (c) Microsoft Corporation. All rights reserved.

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Imports System.Runtime.Serialization
Namespace Microsoft.Syndication.Samples

    <DataContract()> _
    Public Class DataContractExtension
        <DataMember()> _
        Public Key As String

        <DataMember()> _
        Public Value As Integer

        Public Overloads Overrides Function ToString() As String
            Return [String].Format("DataContractExtension: Key={0}, Value={1}", Key, Value)
        End Function
    End Class

    Public Class XmlSerializerExtension

        Public m_Key As String
        Public m_Value As String

        Public Property Key() As String
            Get
                Return m_Key
            End Get
            Set(ByVal value As String)
                m_Key = value
            End Set
        End Property
        Public Property Value() As Integer
            Get
                Return m_Value
            End Get
            Set(ByVal value As Integer)
                m_Value = value
            End Set
        End Property

        Public Overloads Overrides Function ToString() As String
            Return [String].Format("XmlSerializerExtension: Key={0}, Value={1}", Key, Value)
        End Function
    End Class
End Namespace