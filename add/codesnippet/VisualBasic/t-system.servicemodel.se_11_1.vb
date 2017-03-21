    Public Class CreditCardTokenParameters
        Inherits SecurityTokenParameters

        Public Sub New()
        End Sub

        Protected Sub New(ByVal other As CreditCardTokenParameters)
            MyBase.New(other)
        End Sub

        Protected Overrides Function CloneCore() As SecurityTokenParameters
            Return New CreditCardTokenParameters(Me)
        End Function

        Protected Overrides Sub InitializeSecurityTokenRequirement(ByVal requirement As SecurityTokenRequirement)
            requirement.TokenType = Constants.CreditCardTokenType
            Return
        End Sub

        ' A credit card token has no cryptography, no windows identity, and supports only client authentication.
        Protected Overrides ReadOnly Property HasAsymmetricKey() As Boolean
            Get
                Return False
            End Get
        End Property

        Protected Overrides ReadOnly Property SupportsClientAuthentication() As Boolean
            Get
                Return True
            End Get
        End Property

        Protected Overrides ReadOnly Property SupportsClientWindowsIdentity() As Boolean
            Get
                Return False
            End Get
        End Property

        Protected Overrides ReadOnly Property SupportsServerAuthentication() As Boolean
            Get
                Return False
            End Get
        End Property

        Protected Overrides Function CreateKeyIdentifierClause(ByVal token As SecurityToken, _
                                                               ByVal referenceStyle As SecurityTokenReferenceStyle) As SecurityKeyIdentifierClause
            If referenceStyle = SecurityTokenReferenceStyle.Internal Then
                Return token.CreateKeyIdentifierClause(Of LocalIdKeyIdentifierClause)()
            Else
                Throw New NotSupportedException("External references are not supported for credit card tokens")
            End If
        End Function

    End Class