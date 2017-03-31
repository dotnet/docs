'<snippet1>
' This sample demonstrates how to set code access permissions programmatically.  It creates a
' new parent and child code group pair, and allows the user to optionally delete the child group 
' and/or the parent code group.  It also shows the result of a ResolvePolicy call, and displays 
' the permissions for the three security levels; Enterprise, Machine, and User.
Imports System
Imports System.Collections
Imports System.Security
Imports System.Security.Policy
Imports System.Security.Permissions
Imports System.Reflection
Imports System.Globalization
Imports Microsoft.VisualBasic


Class PolicyLevelSample


    Shared Sub Main()
        Console.WriteLine("*************************************************************************************")
        Console.WriteLine("Create an AppDomain policy level.")
        Console.WriteLine("Use the AppDomain to demonstrate PolicyLevel methods and properties.")
        Console.WriteLine("*************************************************************************************")
        CreateAPolicyLevel()
        Dim intranetZoneEvidence As New Evidence(New Object() {New Zone(SecurityZone.Intranet)}, Nothing)
        Console.WriteLine("*************************************************************************************")
        Console.WriteLine("Show the result of ResolvePolicy on this computer for LocalIntranet zone evidence.")
        Console.WriteLine("*************************************************************************************")
        CheckEvidence(intranetZoneEvidence)
        Console.WriteLine("*************************************************************************************")
        Console.WriteLine("Enumerate the permission sets for Machine policy level.")
        Console.WriteLine("*************************************************************************************")
        ListMachinePermissionSets()
        Console.Out.WriteLine("Press the Enter key to exit.")
        Dim consoleInput As String = Console.ReadLine()
    End Sub 'Main


    Public Shared Sub CreateAPolicyLevel()
        Try
            '<Snippet2> 
            ' Create an AppDomain policy level.
            Dim pLevel As PolicyLevel = PolicyLevel.CreateAppDomainLevel()
            '</Snippet2>
            ' The root code group of the policy level combines all
            ' permissions of its children.
            Dim rootCodeGroup As UnionCodeGroup
            Dim ps As New PermissionSet(PermissionState.None)
            ps.AddPermission(New SecurityPermission(SecurityPermissionFlag.Execution))

            rootCodeGroup = New UnionCodeGroup(New AllMembershipCondition, New PolicyStatement(ps, PolicyStatementAttribute.Nothing))

            ' This code group grants FullTrust to assemblies with the strong
            ' name key from this assembly.
            Dim myCodeGroup As New UnionCodeGroup(New StrongNameMembershipCondition(New StrongNamePublicKeyBlob(GetKey()), Nothing, Nothing), New PolicyStatement(New PermissionSet(PermissionState.Unrestricted), PolicyStatementAttribute.Nothing))
            myCodeGroup.Name = "My CodeGroup"

            '<Snippet4>  
            ' Add the code groups to the policy level.
            rootCodeGroup.AddChild(myCodeGroup)
            pLevel.RootCodeGroup = rootCodeGroup
            Console.WriteLine("Permissions granted to all code running in this AppDomain level: ")
            Console.WriteLine(rootCodeGroup.ToXml())
            Console.WriteLine("Child code groups in RootCodeGroup:")
            Dim codeGroups As IList = pLevel.RootCodeGroup.Children
            Dim codeGroup As IEnumerator = codeGroups.GetEnumerator()
            While codeGroup.MoveNext()
                Console.WriteLine((ControlChars.Tab + CType(codeGroup.Current, CodeGroup).Name))
            End While
            '</Snippet4>
            '<Snippet5>  
            Console.WriteLine("Demonstrate adding and removing named permission sets.")
            Console.WriteLine("Original named permission sets:")
            ListPermissionSets(pLevel)
            Dim myInternet As NamedPermissionSet = pLevel.GetNamedPermissionSet("Internet")
            '</Snippet5>
            myInternet.Name = "MyInternet"
            '<Snippet6> 
            pLevel.AddNamedPermissionSet(myInternet)
            '</Snippet6>
            Console.WriteLine(ControlChars.Lf + "New named permission sets:")
            ListPermissionSets(pLevel)
            myInternet.RemovePermission(GetType(System.Security.Permissions.FileDialogPermission))
            '<Snippet7> 
            pLevel.ChangeNamedPermissionSet("MyInternet", myInternet)
            '</Snippet7>
            '<Snippet8>
            pLevel.RemoveNamedPermissionSet("MyInternet")
            '</Snippet8>
            Console.WriteLine(ControlChars.Lf + "Current permission sets:")
            ListPermissionSets(pLevel)
            pLevel.AddNamedPermissionSet(myInternet)
            Console.WriteLine(ControlChars.Lf + "Updated named permission sets:")
            ListPermissionSets(pLevel)
            '<Snippet9> 
            pLevel.Reset()
            '</Snippet9>
            Console.WriteLine(ControlChars.Lf + "Reset named permission sets:")
            ListPermissionSets(pLevel)
            '<Snippet10> 
            Console.WriteLine(ControlChars.Lf + "Type property = " + pLevel.Type.ToString())
            '</Snippet10>
            '<Snippet11> 
            Console.WriteLine("The result of GetHashCode is " + pLevel.GetHashCode().ToString())
            '</Snippet11>
            Console.WriteLine("StoreLocation property for the AppDomain level is empty, since AppDomain policy " + "cannot be saved to a file.")
            Console.WriteLine("StoreLocation property = " + pLevel.StoreLocation)
            '<Snippet12> 
            Dim pLevelCopy As PolicyLevel = PolicyLevel.CreateAppDomainLevel()
            ' Create a copy of the PolicyLevel using ToXml/FromXml.
            pLevelCopy.FromXml(pLevel.ToXml())

            If ComparePolicyLevels(pLevel, pLevelCopy) Then
                Console.WriteLine("The ToXml/FromXml roundtrip was successful.")
            Else
                Console.WriteLine("ToXml/FromXml roundtrip failed.")
            End If
            '</Snippet12>
            Console.WriteLine("Show the result of resolving policy for evidence unique to the AppDomain policy level.")
            Dim myEvidence As New Evidence(New Object() {myCodeGroup}, Nothing)
            CheckEvidence(pLevel, myEvidence)
            Return
        Catch e As Exception
            Console.WriteLine(e.Message)
            Return
        End Try
    End Sub 'CreateAPolicyLevel

    ' Compare two PolicyLevels using ToXml and FromXml.
    Private Shared Function ComparePolicyLevels(ByVal pLevel1 As PolicyLevel, ByVal pLevel2 As PolicyLevel) As Boolean
        Dim retVal As Boolean = False
        Dim firstCopy As PolicyLevel = PolicyLevel.CreateAppDomainLevel()
        Dim secondCopy As PolicyLevel = PolicyLevel.CreateAppDomainLevel()
        ' Create copies of the two PolicyLevels passed in.
        ' Convert the two PolicyLevels to their canonical form using ToXml and FromXml.
        firstCopy.FromXml(pLevel1.ToXml())
        secondCopy.FromXml(pLevel2.ToXml())
        If firstCopy.ToXml().ToString().CompareTo(secondCopy.ToXml().ToString()) = 0 Then
            retVal = True
        End If
        Return retVal
    End Function 'ComparePolicyLevels


    '<Snippet13>  
    ' Demonstrate the use of ResolvePolicy for the supplied evidence and a specified policy level.
    Private Overloads Shared Sub CheckEvidence(ByVal pLevel As PolicyLevel, ByVal evidence As Evidence)
        ' Display the code groups to which the evidence belongs.
        Console.WriteLine(ControlChars.Tab + "ResolvePolicy for the given evidence: ")
        Dim codeGroup As IEnumerator = evidence.GetEnumerator()
        While codeGroup.MoveNext()
            Console.WriteLine((ControlChars.Tab + ControlChars.Tab + CType(codeGroup.Current, CodeGroup).Name))
        End While
        Console.WriteLine("The current evidence belongs to the following root CodeGroup:")
        ' pLevel is the current PolicyLevel, evidence is the Evidence to be resolved.
        Dim cg1 As CodeGroup = pLevel.ResolveMatchingCodeGroups(evidence)
        Console.WriteLine((pLevel.Label + " Level"))
        Console.WriteLine((ControlChars.Tab + "Root CodeGroup = " + cg1.Name))

        ' Show how Resolve is used to determine the set of permissions that 
        ' the security system grants to code, based on the evidence.
        ' Show the granted permissions. 
        Console.WriteLine(ControlChars.Lf + "Current permissions granted:")
        Dim pState As PolicyStatement = pLevel.Resolve(evidence)
        Console.WriteLine(pState.ToXml().ToString())

        Return
    End Sub 'CheckEvidence

    '</Snippet13>
    '<Snippet14> 
    Private Shared Sub ListPermissionSets(ByVal pLevel As PolicyLevel)
        Dim namedPermissions As IList = pLevel.NamedPermissionSets
        Dim namedPermission As IEnumerator = namedPermissions.GetEnumerator()
        While namedPermission.MoveNext()
            Console.WriteLine((ControlChars.Tab + CType(namedPermission.Current, NamedPermissionSet).Name))
        End While
    End Sub 'ListPermissionSets

    '</Snippet14>
    Private Shared Function GetKey() As Byte()
        Return [Assembly].GetCallingAssembly().GetName().GetPublicKey()
    End Function 'GetKey

    '<Snippet15>  
    ' Demonstrate the use of ResolvePolicy for passed in evidence.
    Private Overloads Shared Sub CheckEvidence(ByVal evidence As Evidence)
        ' Display the code groups to which the evidence belongs.
        Console.WriteLine("ResolvePolicy for the given evidence.")
        Console.WriteLine(ControlChars.Tab + "Current evidence belongs to the following code groups:")
        Dim policyEnumerator As IEnumerator = SecurityManager.PolicyHierarchy()
        ' Resolve the evidence at all the policy levels.
        While policyEnumerator.MoveNext()
            Dim currentLevel As PolicyLevel = CType(policyEnumerator.Current, PolicyLevel)
            Dim cg1 As CodeGroup = currentLevel.ResolveMatchingCodeGroups(evidence)
            Console.WriteLine((ControlChars.Lf + ControlChars.Tab + currentLevel.Label + " Level"))
            Console.WriteLine((ControlChars.Tab + ControlChars.Tab + "CodeGroup = " + cg1.Name))
            Dim cgE1 As IEnumerator = cg1.Children.GetEnumerator()
            While cgE1.MoveNext()
                Console.WriteLine((ControlChars.Tab + ControlChars.Tab + ControlChars.Tab + "Group = " + CType(cgE1.Current, CodeGroup).Name))
            End While
            Console.WriteLine((ControlChars.Tab + "StoreLocation = " + currentLevel.StoreLocation))
        End While

        Return
    End Sub 'CheckEvidence

    '</Snippet15>
    '<Snippet16> 
    Private Shared Sub ListMachinePermissionSets()
        Console.WriteLine(ControlChars.Lf + "Permission sets in Machine policy level:")
        Dim policyEnumerator As IEnumerator = SecurityManager.PolicyHierarchy()
        While policyEnumerator.MoveNext()

            Dim currentLevel As PolicyLevel = CType(policyEnumerator.Current, PolicyLevel)
            If currentLevel.Label = "Machine" Then

                Dim namedPermissions As IList = currentLevel.NamedPermissionSets
                Dim namedPermission As IEnumerator = namedPermissions.GetEnumerator()
                While namedPermission.MoveNext()
                    Console.WriteLine((ControlChars.Tab + CType(namedPermission.Current, NamedPermissionSet).Name))
                End While
            End If
        End While
    End Sub 'ListMachinePermissionSets
End Class 'PolicyLevelSample 
'</Snippet16>
'</Snippet1>