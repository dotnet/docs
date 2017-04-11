Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ComponentModel

Namespace BusinessLayerValidation
'<SnippetIDataErrorInfo>
	Public Class Person
        Implements IDataErrorInfo

        Private _age As Integer
        Public Property Age() As Integer
            Get
                Return _age
            End Get
            Set(ByVal value As Integer)
                _age = value
            End Set
        End Property

        Public ReadOnly Property [Error]() As String Implements IDataErrorInfo.Error
            Get
                Return Nothing
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal columnName As String) As String Implements IDataErrorInfo.Item
            Get
                Dim result As String = Nothing

                If columnName = "Age" Then
                    If Me._age < 0 OrElse Me._age > 150 Then
                        result = "Age must not be less than 0 or greater than 150."
                    End If
                End If
                Return result
            End Get
        End Property
    End Class
'</SnippetIDataErrorInfo>
End Namespace
