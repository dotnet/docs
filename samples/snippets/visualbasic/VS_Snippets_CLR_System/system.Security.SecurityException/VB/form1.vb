'<Snippet1>
Imports System
Imports System.Data
Imports System.Security
Imports System.Security.Permissions
Imports System.Security.Policy
Imports System.Reflection
Imports System.Runtime.Serialization

<Assembly: KeyContainerPermissionAttribute(SecurityAction.RequestRefuse, _
    Flags:=KeyContainerPermissionFlags.Import)> 

Class EntryPoint

    <STAThread()> _
    Shared Sub Main()
        Dim eP As New EntryPoint()
        eP.RunCode()
        Console.WriteLine("Press the ENTER key to exit.")
        Console.Read()

    End Sub 'Main

    Sub RunCode()
        Try
            ' Deny a permission.
            Dim kCP1 As New KeyContainerPermission( _
                KeyContainerPermissionFlags.Decrypt)
            kCP1.Deny()

            ' Demand the denied permission and display the 
            ' exception properties.
            Display("Demanding a denied permission. " & vbLf & vbLf)
            DemandDeniedPermission()
            Display("************************************************" & vbLf)
            CodeAccessPermission.RevertDeny()

            ' Demand the permission refused in the 
            ' assembly-level attribute.
            Display("Demanding a refused permission. " & vbLf & vbLf)
            DemandRefusedPermission()
            Display("************************************************" & vbLf)

            ' Demand the permission implicitly refused through a 
            ' PermitOnly attribute. Permit only the permission that 
            ' will cause the failure and the security permissions 
            ' necessary to display the results of the failure.
            Dim permitOnly As New PermissionSet(PermissionState.None)
            permitOnly.AddPermission( _
                New KeyContainerPermission(KeyContainerPermissionFlags.Import))
            permitOnly.AddPermission(New SecurityPermission( _
                SecurityPermissionFlag.ControlEvidence Or _ 
                SecurityPermissionFlag.ControlPolicy Or _
                SecurityPermissionFlag.SerializationFormatter))
            permitOnly.PermitOnly()
            Display( _
                "Demanding an implicitly refused permission. " & vbLf & vbLf)
            DemandPermitOnly()
        Catch sE As Exception
            Display("************************************************" & vbLf)
            '<Snippet17>
            Display("Displaying an exception using the ToString method: ")
            Display(sE.ToString())
            '</Snippet17>
        End Try
    End Sub 'RunCode

    Sub DemandDeniedPermission()
        Try
            Dim kCP As New KeyContainerPermission( _
                KeyContainerPermissionFlags.Decrypt)
            kCP.Demand()
        Catch sE As SecurityException
            '<Snippet2>
            Display("The denied permission is: " & _
                CType(sE.DenySetInstance, PermissionSet).ToString())
            '</Snippet2>
            '<Snippet3>
            Display("The demanded permission is: " & sE.Demanded.ToString())
            '</Snippet3>
            '<Snippet4>
            Display("The security action is: " & sE.Action.ToString())
            '</Snippet4>
            '<Snippet5>
            Display("The method is: " & sE.Method.ToString())
            '</Snippet5>
            '<Snippet6>
            Display( _
                "The permission state at the time of the exception was: " & _
                sE.PermissionState)
            '</Snippet6>
            '<Snippet7>
            Display("The permission that failed was: " & _
                CType(sE.FirstPermissionThatFailed, _
                IPermission).ToXml().ToString())
            '</Snippet7>
            '<Snippet8>
            Display("The permission type is: " & sE.PermissionType.ToString())
            '</Snippet8>
            '<Snippet9>
            Display("Demonstrating the use of the GetObjectData method.")
            Dim si As New SerializationInfo( _
                GetType(EntryPoint), New FormatterConverter())
            sE.GetObjectData(si, _
                New StreamingContext(StreamingContextStates.All))
            Display("The FirstPermissionThatFailed from the " & _
                "call to GetObjectData is: ")
            Display(si.GetString("FirstPermissionThatFailed"))
        End Try
        '</Snippet9>
    End Sub 'DemandDeniedPermission

    Sub DemandRefusedPermission()
        Try
            Dim kCP As New KeyContainerPermission( _
                KeyContainerPermissionFlags.Import)
            kCP.Demand()
        Catch sE As SecurityException
            '<Snippet10>
            Display("The refused permission set is: " & _
                sE.RefusedSet.ToString())
            '</Snippet10>
            '<Snippet11>
            Display("The exception message is: " & sE.Message)
            '</Snippet11>
            '<Snippet12>
            Display("The failed assembly is: " & _
                sE.FailedAssemblyInfo.EscapedCodeBase)
            '</Snippet12>
            '<Snippet13>
            Display("The granted set is: " & vbLf & sE.GrantedSet)
            '</Snippet13>
            Display("The permission that failed is: " & CType( _
                sE.FirstPermissionThatFailed, IPermission).ToXml().ToString())
            Display("The permission type is: " & sE.PermissionType.ToString())
            '<Snippet14>
            Display("The source is: " & sE.Source)
        End Try
        '</Snippet14>
    End Sub 'DemandRefusedPermission

    Sub DemandPermitOnly()
        Try
            Dim kCP As New KeyContainerPermission( _
                KeyContainerPermissionFlags.Decrypt)
            kCP.Demand()
        Catch sE As SecurityException
            '<Snippet15>
            Display("The permitted permission is: " & _
                CType(sE.PermitOnlySetInstance, PermissionSet).ToString())
            '</Snippet15>
            Display("The demanded permission is: " & sE.Demanded.ToString())
            Display("The security action is: " & sE.Action.ToString())
            Display("The method is: " & sE.Method.ToString())
            Display("The permission state at the time of the exception was: " & _
                sE.PermissionState)
            Display("The permission that failed was: " & CType( _
                sE.FirstPermissionThatFailed, IPermission).ToXml().ToString())
            Display("The permission type is: " & sE.PermissionType.ToString())

            '<Snippet16>
            ' Demonstrate the SecurityException constructor by 
            ' throwing the exception again.
            Display("Rethrowing the exception thrown as a result of a " & _
                "PermitOnly security action.")
            Throw New SecurityException(sE.Message, sE.DenySetInstance, _
                sE.PermitOnlySetInstance, sE.Method, sE.Demanded, _
                CType(sE.FirstPermissionThatFailed, IPermission))
            '</Snippet16>
        End Try

    End Sub 'DemandPermitOnly

    Sub Display(ByVal line As String)

        Console.WriteLine(line)

    End Sub 'Display
End Class 'EntryPoint
'</Snippet1>
