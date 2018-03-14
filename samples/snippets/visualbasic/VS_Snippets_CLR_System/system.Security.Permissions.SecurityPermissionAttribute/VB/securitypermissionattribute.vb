'<Snippet1>
' This sample demonstrates the use of the SecurityPermissionAttribute.
Imports System
Imports System.Security.Permissions
Imports System.Security
Imports Microsoft.VisualBasic



Class [MyClass]

    Public Shared Sub PermissionDemo()
        Try
            DenySecurityPermissions()
            DenyAllSecurityPermissions()
            DoNotDenySecurityPermissions()
        Catch e As Exception
            Console.WriteLine(e.Message.ToString())
        End Try
    End Sub 'PermissionDemo




    ' This method demonstrates the use of the SecurityPermissionAttribute to deny individual security permissions.
    '<Snippet2>
    '<Snippet3>
    '<Snippet4>
    '<Snippet5>
    '<Snippet6>
    '<Snippet7>
    '<Snippet8>
    '<Snippet9>
    '<Snippet11>
    '<Snippet12>
    '<Snippet13>
    '<Snippet15>
    '<Snippet16>
    '<Snippet17>
    ' Set the Assertion,UnmanagedCode, ControlAppDomain, ControlDomainPolicy, ontrolEvidence, 
    ' ControlPolicy, ControlPrincipal, ControlThread, Execution, Flags, Infrastructure, 
    ' RemotingConfiguration, SerializationFormatter, and SkipVerification properties.
    <SecurityPermissionAttribute(SecurityAction.Deny, Assertion:=True), _
    SecurityPermissionAttribute(SecurityAction.Deny, ControlAppDomain:=True), _
    SecurityPermissionAttribute(SecurityAction.Deny, ControlDomainPolicy:=True), _
    SecurityPermissionAttribute(SecurityAction.Deny, ControlEvidence:=True), _
    SecurityPermissionAttribute(SecurityAction.Deny, ControlPolicy:=True), _
    SecurityPermissionAttribute(SecurityAction.Deny, ControlPrincipal:=True), _
    SecurityPermissionAttribute(SecurityAction.Deny, ControlThread:=True), _
    SecurityPermissionAttribute(SecurityAction.Deny, Execution:=True), _
    SecurityPermissionAttribute(SecurityAction.Deny, Flags:=SecurityPermissionFlag.NoFlags), _
    SecurityPermissionAttribute(SecurityAction.Deny, Infrastructure:=True), _
    SecurityPermissionAttribute(SecurityAction.Deny, RemotingConfiguration:=True), _
    SecurityPermissionAttribute(SecurityAction.Deny, SerializationFormatter:=True), _
    SecurityPermissionAttribute(SecurityAction.Deny, SkipVerification:=True), _
    SecurityPermissionAttribute(SecurityAction.Deny, UnmanagedCode:=True)> _
    Public Shared Sub DenySecurityPermissions()
        '</Snippet2>
        '</Snippet3>
        '</Snippet4>
        '</Snippet5>
        '</Snippet6>
        '</Snippet7>
        '</Snippet8>
        '</Snippet9>
        '</Snippet11>
        '</Snippet12>
        '</Snippet13>
        '</Snippet15>
        '</Snippet16>
        '</Snippet17>
        Console.WriteLine("Executing DenySecurityPermissions.")
        Console.WriteLine("Denied all permissions individually.")
        TestSecurityPermissions()
    End Sub 'DenySecurityPermissions


    ' This method demonstrates the use of SecurityPermissionFlag.AllFlags to deny all security permissions.
    <SecurityPermissionAttribute(SecurityAction.Deny, Flags:=SecurityPermissionFlag.AllFlags)> _
    Public Shared Sub DenyAllSecurityPermissions()
        Console.WriteLine(ControlChars.Lf & "Executing DenyAllSecurityPermissions.")
        Console.WriteLine("Denied all permissions using SecurityPermissionFlag.AllFlags.")
        TestSecurityPermissions()
    End Sub 'DenyAllSecurityPermissions


    ' This method demonstrates the effect of not denying security permissions.
    Public Shared Sub DoNotDenySecurityPermissions()
        Console.WriteLine(ControlChars.Lf & "Executing DoNotDenySecurityPermissions.")
        Console.WriteLine("No permissions have been denied.")
        DemandSecurityPermissions()
    End Sub 'DoNotDenySecurityPermissions


    Public Shared Sub TestSecurityPermissions()
        Console.WriteLine(ControlChars.Lf & "Executing TestSecurityPermissions." & ControlChars.Lf)
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.Assertion)
            Console.WriteLine("Demanding SecurityPermissionFlag.Assertion")
            ' This demand should cause an exception.
            sp.Demand()
            ' The TestFailed method is called if an exception is not thrown.
            TestFailed()
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.Assertion failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.ControlAppDomain)
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlAppDomain")
            sp.Demand()
            TestFailed()
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.ControlAppDomain failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.ControlDomainPolicy)
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlDomainPolicy")
            sp.Demand()
            TestFailed()
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.ControlDomainPolicy failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.ControlEvidence)
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlEvidence")
            sp.Demand()
            TestFailed()
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.ControlEvidence failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.ControlPolicy)
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlPolicy")
            sp.Demand()
            TestFailed()
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.ControlPolicy failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.ControlPrincipal)
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlPrincipal")
            sp.Demand()
            TestFailed()
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.ControlPrincipal failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.ControlThread)
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlThread")
            sp.Demand()
            TestFailed()
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.ControlThread failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.Execution)
            Console.WriteLine("Demanding SecurityPermissionFlag.Execution")
            sp.Demand()
            TestFailed()
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.Execution failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.Infrastructure)
            Console.WriteLine("Demanding SecurityPermissionFlag.Infrastructure")
            sp.Demand()
            TestFailed()
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.Infrastructure failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.RemotingConfiguration)
            Console.WriteLine("Demanding SecurityPermissionFlag.RemotingConfiguration")
            sp.Demand()
            TestFailed()
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.RemotingConfiguration failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.SerializationFormatter)
            Console.WriteLine("Demanding SecurityPermissionFlag.SerializationFormatter")
            sp.Demand()
            TestFailed()
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.SerializationFormatter failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.SkipVerification)
            Console.WriteLine("Demanding SecurityPermissionFlag.SkipVerification")
            sp.Demand()
            TestFailed()
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.SkipVerification failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.UnmanagedCode)
            Console.WriteLine("Demanding SecurityPermissionFlag.UnmanagedCode")
            ' This demand should cause an exception.
            sp.Demand()
            ' The TestFailed method is called if an exception is not thrown.
            TestFailed()
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.UnmanagedCode failed: " & e.Message))
        End Try
    End Sub 'TestSecurityPermissions


    Public Shared Sub TestFailed()
        Console.WriteLine("In TestFailed method.")
        Console.WriteLine("Throwing an exception.")
        Throw New Exception()
    End Sub 'TestFailed

'<Snippet18>
    Public Shared Sub DemandSecurityPermissions()
        Console.WriteLine(ControlChars.Lf & "Executing DemandSecurityPermissions." & ControlChars.Lf)
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.Assertion)
            Console.WriteLine("Demanding SecurityPermissionFlag.Assertion")
            sp.Demand()
            Console.WriteLine("Demand for SecurityPermissionFlag.Assertion succeeded.")
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.Assertion failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.ControlAppDomain)
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlAppDomain")
            sp.Demand()
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlAppDomain succeeded.")
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.ControlAppDomain failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.ControlDomainPolicy)
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlDomainPolicy")
            sp.Demand()
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlDomainPolicy succeeded.")
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.ControlDomainPolicy failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.ControlEvidence)
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlEvidence")
            sp.Demand()
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlEvidence succeeded.")
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.ControlEvidence failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.ControlPolicy)
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlPolicy")
            sp.Demand()
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlPolicy succeeded.")
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.ControlPolicy failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.ControlPrincipal)
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlPrincipal")
            sp.Demand()
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlPrincipal succeeded.")
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.ControlPrincipal failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.ControlThread)
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlThread")
            sp.Demand()
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlThread succeeded.")
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.ControlThread failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.Execution)
            Console.WriteLine("Demanding SecurityPermissionFlag.Execution")
            sp.Demand()
            Console.WriteLine("Demand for SecurityPermissionFlag.Execution succeeded.")
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.Execution failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.Infrastructure)
            Console.WriteLine("Demanding SecurityPermissionFlag.Infrastructure")
            sp.Demand()
            Console.WriteLine("Demand for SecurityPermissionFlag.Infrastructure succeeded.")
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.Infrastructure failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.RemotingConfiguration)
            Console.WriteLine("Demanding SecurityPermissionFlag.RemotingConfiguration")
            sp.Demand()
            Console.WriteLine("Demand for SecurityPermissionFlag.RemotingConfiguration succeeded.")
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.RemotingConfiguration failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.SerializationFormatter)
            Console.WriteLine("Demanding SecurityPermissionFlag.SerializationFormatter")
            sp.Demand()
            Console.WriteLine("Demand for SecurityPermissionFlag.SerializationFormatter succeeded.")
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.SerializationFormatter failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.SkipVerification)
            Console.WriteLine("Demanding SecurityPermissionFlag.SkipVerification")
            sp.Demand()
            Console.WriteLine("Demand for SecurityPermissionFlag.SkipVerification succeeded.")
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.SkipVerification failed: " & e.Message))
        End Try
        Try
            Dim sp As New SecurityPermission(SecurityPermissionFlag.UnmanagedCode)
            Console.WriteLine("Demanding SecurityPermissionFlag.UnmanagedCode")
            sp.Demand()
            Console.WriteLine("Demand for SecurityPermissionFlag.UnmanagedCode succeeded.")
        Catch e As Exception
            Console.WriteLine(("Demand for SecurityPermissionFlag.UnmanagedCode failed: " & e.Message))
        End Try
    End Sub 'DemandSecurityPermissions
'</Snippet18>

    Overloads Shared Sub Main(ByVal args() As String)
        PermissionDemo()
    End Sub 'Main
End Class '[MyClass] 
'</Snippet1>