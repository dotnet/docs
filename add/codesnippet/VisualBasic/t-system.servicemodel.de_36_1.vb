Public Class MyServiceCredentials
    Inherits ServiceCredentials
    Private additionalCertificateValue As X509Certificate2

    Public Sub New() 
    
    End Sub

    Protected Sub New(ByVal other As MyServiceCredentials) 
        MyBase.New(other)
        Me.additionalCertificate = other.additionalCertificate
    End Sub
    
    
    Public Property AdditionalCertificate() As X509Certificate2 
        Get
            Return Me.additionalCertificateValue
        End Get
        Set
            If value Is Nothing Then
                Throw New ArgumentNullException("value")
            End If
            Me.additionalCertificateValue = value
        End Set
    End Property

    Public Overrides Function CreateSecurityTokenManager() As SecurityTokenManager 
        Return MyBase.CreateSecurityTokenManager()
    
    End Function
    
    
    Protected Overrides Function CloneCore() As ServiceCredentials 
        Return New MyServiceCredentials(Me)
    
    End Function
End Class