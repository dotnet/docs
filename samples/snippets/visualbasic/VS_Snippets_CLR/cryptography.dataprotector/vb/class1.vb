'<Snippet1>
Imports System
Imports System.Security
Imports System.Security.Cryptography
Imports System.Security.Permissions



Public NotInheritable Class MyDataProtector
    Inherits DataProtector

    Public Property Scope() As DataProtectionScope
        Get
            Return Scope
        End Get
        Set(value As DataProtectionScope)
        End Set
        '<Snippet2>
    End Property ' This implementation gets the HashedPurpose from the base class and passes it as OptionalEntropy to ProtectedData.
    ' The default for DataProtector is to prepend the hash to the plain text, but because we are using the hash 
    ' as OptionalEntropy there is no need to prepend it.

    Protected Overrides ReadOnly Property PrependHashedPurposeToPlaintext() As Boolean
        Get
            Return False
        End Get
    End Property

    '</Snippet2>
    '<Snippet3>
    ' To allow a service to hand out instances of a DataProtector we demand unrestricted DataProtectionPermission 
    ' in the constructor, but Assert the permission when ProviderProtect is called.  This is similar to FileStream
    ' where access is checked at time of creation, not time of use.
    <SecuritySafeCritical(), DataProtectionPermission(SecurityAction.Assert, ProtectData:=True)> _
    Protected Overrides Function ProviderProtect(ByVal userData() As Byte) As Byte()
        ' Delegate to ProtectedData
        Return ProtectedData.Protect(userData, GetHashedPurpose(), Scope)

    End Function 'ProviderProtect

    '</Snippet3>
    '<Snippet4>
    ' To allow a service to hand out instances of a DataProtector we demand unrestricted DataProtectionPermission 
    ' in the constructor, but Assert the permission when ProviderUnProtect is called.  This is similar to FileStream
    ' where access is checked at time of creation, not time of use.
    <SecuritySafeCritical(), DataProtectionPermission(SecurityAction.Assert, UnprotectData:=True)> _
    Protected Overrides Function ProviderUnprotect(ByVal encryptedData() As Byte) As Byte()
        ' Delegate to ProtectedData
        Return ProtectedData.Unprotect(encryptedData, GetHashedPurpose(), Scope)

    End Function 'ProviderUnprotect

    '</Snippet4>
    Public Overrides Function IsReprotectRequired(ByVal encryptedData() As Byte) As Boolean
        ' For now, this cannot be determined, so always return true;
        Return True

    End Function 'IsReprotectRequired

    '<Snippet5>
    ' Public constructor
    ' The Demand for DataProtectionPermission is in the constructor because we Assert this permission 
    ' in the ProviderProtect/ProviderUnprotect methods. 
    <DataProtectionPermission(SecurityAction.Demand, Unrestricted:=True), SecuritySafeCritical()> _
    Public Sub New(ByVal appName As String, ByVal primaryPurpose As String, ParamArray specificPurpose() As String)
        MyBase.New(appName, primaryPurpose, specificPurpose)

    End Sub 'New
End Class 'MyDataProtector
'</Snippet5>
'</Snippet1>