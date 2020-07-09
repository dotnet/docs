Option Strict On

' <Snippet1>
Public Class Person
    Private m_Age As Integer

    Public Property Age As Integer
        Get
            Return m_Age
        End Get
        Set
            If value < 0 Or value > 125 Then
                Throw New ArgumentOutOfRangeException("The value of the Age property must be between 0 and 125.")
            Else
                m_Age = value
            End If
        End Set
    End Property
End Class
' </Snippet1>
