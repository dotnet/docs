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