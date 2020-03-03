Class Window1 

End Class

'<SnippetIDataErrorInfoData> 
Public Class PersonImplementsIDataErrorInfo
    Implements System.ComponentModel.IDataErrorInfo
    Private m_age As Integer

    Public Property Age() As Integer
        Get
            Return m_age
        End Get
        Set(ByVal value As Integer)
            m_age = value
        End Set
    End Property

    Public ReadOnly Property [Error]() As String _
                    Implements System.ComponentModel.IDataErrorInfo.Error
        Get
            Return ""
        End Get
    End Property

    Default Public ReadOnly Property Item(ByVal name As String) As String _
                            Implements System.ComponentModel.IDataErrorInfo.Item
        Get
            Dim result As String = Nothing

            If name = "Age" Then
                If Me.m_age < 0 OrElse Me.m_age > 150 Then
                    result = "Age must not be less than 0 or greater than 150."
                End If
            End If
            Return result
        End Get
    End Property
End Class
'</SnippetIDataErrorInfoData> 

'<SnippetThrowExceptionData> 
Public Class PersonThrowException
    Private m_age As Integer

    Public Property Age() As Integer
        Get
            Return m_age
        End Get
        Set(ByVal value As Integer)

            If value < 0 OrElse value > 150 Then
                Throw New ArgumentException("Age must not be less than 0 or greater than 150.")
            End If
            m_age = value
        End Set
    End Property
End Class
'</SnippetThrowExceptionData> 

