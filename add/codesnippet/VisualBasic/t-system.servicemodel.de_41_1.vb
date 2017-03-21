Public Class MyClientCredentials
    Inherits ClientCredentials
    Private creditCardNumberValue As String

    Public Sub New() 
    
    End Sub 'New
    
    ' Perform client credentials initialization.    
    Protected Sub New(ByVal other As MyClientCredentials) 
        MyBase.New(other)
        ' Clone fields defined in this class.
        Me.creditCardNumberValue = other.creditCardNumberValue
    
    End Sub

    Public Property CreditCardNumber() As String 
        Get
            Return Me.creditCardNumberValue
        End Get
        Set
            If value Is Nothing Then
                Throw New ArgumentNullException("value")
            End If
            Me.creditCardNumberValue = value
        End Set
    End Property

    Public Overrides Function CreateSecurityTokenManager() As SecurityTokenManager 
        ' Return your implementation of the SecurityTokenManager.
        Return New MyClientCredentialsSecurityTokenManager(Me)
    
    End Function
    
    Protected Overrides Function CloneCore() As ClientCredentials 
        ' Implement the cloning functionality.
        Return New MyClientCredentials(Me)
    
    End Function
End Class