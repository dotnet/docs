'<Snippet1>
Imports System
Imports System.Security
Imports System.Security.Permissions
Imports System.Security.Cryptography



Public NotInheritable Class MemoryProtector
    Inherits DataProtector

    Public Property Scope() As MemoryProtectionScope
        Get
            Return Scope
        End Get
        Set(value As MemoryProtectionScope)
        End Set
        '<Snippet2>
    End Property

    Protected Overrides ReadOnly Property PrependHashedPurposeToPlaintext() As Boolean
        Get
            ' Signal the DataProtector to prepend the hash of the purpose to the data.
            Return True
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
        ProtectedMemory.Protect(userData, Scope)
        Return userData

    End Function 'ProviderProtect

    '</Snippet3>
    '<Snippet4>
    ' To allow a service to hand out instances of a DataProtector we demand unrestricted DataProtectionPermission 
    ' in the constructor, but Assert the permission when ProviderUnprotect is called..  This is similar to FileStream
    ' where access is checked at time of creation, not time of use.
    <SecuritySafeCritical(), DataProtectionPermission(SecurityAction.Assert, UnprotectData:=True)> _
    Protected Overrides Function ProviderUnprotect(ByVal encryptedData() As Byte) As Byte()

        ProtectedMemory.Unprotect(encryptedData, Scope)
        Return encryptedData

    End Function 'ProviderUnprotect

    '</Snippet4>
    Public Overrides Function IsReprotectRequired(ByVal encryptedData() As Byte) As Boolean
        ' For now, this cannot be determined so always return true.
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
End Class 'MemoryProtector
'</Snippet5>
'</Snippet1>