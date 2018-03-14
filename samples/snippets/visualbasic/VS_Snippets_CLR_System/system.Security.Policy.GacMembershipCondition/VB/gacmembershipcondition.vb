' <Snippet1>
Imports System
Imports System.Security
Imports System.Security.Policy
Imports System.Collections

Public Class GacMembershipConditionDemo

    ' Demonstrate the Copy method, which creates an identical 
    ' copy of the current permission.
    Private Function CopyDemo() As Boolean
        Console.WriteLine( _
            "*************************************************************")
        '<Snippet2>
        Dim Gac1 As New GacMembershipCondition
        Console.WriteLine("Original membership condition = ")
        Console.WriteLine(Gac1.ToXml().ToString())
        Try
            Dim membershipCondition As IMembershipCondition = Gac1.Copy()
            Console.WriteLine("Result of Copy = ")
            Console.WriteLine(CType(membershipCondition, _
                GacMembershipCondition).ToXml().ToString())
        Catch e As Exception
            Console.WriteLine(("Copy failed : " & Gac1.ToString() & _
                e.ToString()))
            Return False
        End Try

        '</Snippet2>
        Return True
    End Function 'CopyDemo

    ' Demonstrate the Check method, which determines whether the specified 
    ' evidence satisfies the membership condition.
    Private Function CheckDemo() As Boolean
        Console.WriteLine( _
            "*************************************************************")
        '<Snippet3>
        Dim Gac1 As New GacMembershipCondition
        Dim myGac As New GacInstalled
        Try
            Dim hostEvidence() As Object = {myGac}
            Dim assemblyEvidence() As Object

            Dim myEvidence As New Evidence(hostEvidence, assemblyEvidence)
            Dim retCode As Boolean = Gac1.Check(myEvidence)
            Console.WriteLine(("Result of Check = " & retCode.ToString() _
                & ControlChars.Lf))
        Catch e As Exception
            Console.WriteLine(("Check failed : " & Gac1.ToString() & _ 
                e.ToString()))
            Return False
        End Try
        '</Snippet3>
        Return True
    End Function 'CheckDemo

    ' Demonstrate the GetHashCode method, which returns a hash code
    ' for the specified membership condition.
    Private Function GetHashCodeDemo() As Boolean
        Console.WriteLine( _
            "*************************************************************")
        '<Snippet4>
        Dim Gac1 As New GacMembershipCondition
        Try
            Console.WriteLine( _
                ("Result of GetHashCode for a GacMembershipCondition = " _
                & Gac1.GetHashCode().ToString() & ControlChars.Lf))
        Catch e As Exception
            Console.WriteLine(("GetHashCode failed : " & _
                Gac1.ToString() & e.ToString()))
            Return False
        End Try

        '</Snippet4>
        Return True
    End Function 'GetHashCodeDemo

    'Demonstrate the ToXml and FromXml methods, including the overloads. 
    ' ToXml creates an XML encoding of the membership condition and its 
    ' current state; FromXml reconstructs a membership condition with the 
    ' specified state from the XML encoding.
    Private Function ToFromXmlDemo() As Boolean
        Console.WriteLine( _
            "*************************************************************")
        Try
            '<Snippet5>
            Dim Gac1 As New GacMembershipCondition
            Dim Gac2 As New GacMembershipCondition

            ' Roundtrip a GacMembershipCondition to and from an XML encoding.
            Gac2.FromXml(Gac1.ToXml())
            Dim result As Boolean = Gac2.Equals(Gac1)
            If result Then
                Console.WriteLine(("Result of ToXml() = " & _ 
                    Gac2.ToXml().ToString()))
                Console.WriteLine(("Result of ToFromXml roundtrip = " & _ 
                    Gac2.ToString()))
            Else
                Console.WriteLine(Gac2.ToString())
                Console.WriteLine(Gac1.ToString())
                Return False
            End If
            '</Snippet5>

            '<Snippet6>
            Dim Gac3 As New GacMembershipCondition
            Dim Gac4 As New GacMembershipCondition
            Dim policyEnumerator As IEnumerator = _
                SecurityManager.PolicyHierarchy()
            While policyEnumerator.MoveNext()
                Dim currentLevel As PolicyLevel = _
                    CType(policyEnumerator.Current, PolicyLevel)
                If currentLevel.Label = "Machine" Then
                    Console.WriteLine(("Result of ToXml(level) = " & _
                        Gac3.ToXml(currentLevel).ToString()))
                    Gac4.FromXml(Gac3.ToXml(), currentLevel)
                    Console.WriteLine(("Result of FromXml(element, level) = " _
                        & Gac4.ToString()))
                End If
            End While
            '</Snippet6>
        Catch e As Exception
            Console.WriteLine(("ToFromXml failed. " & e.ToString()))
            Return False
        End Try

        Return True
    End Function 'ToFromXmlDemo

    ' Invoke all demos.
    Public Function RunDemo() As Boolean

        Dim returnCode As Boolean = True
        Dim tempReturnCode As Boolean

        ' Call the Copy demo.
        tempReturnCode = CopyDemo()
        If tempReturnCode = True Then
            Console.Out.WriteLine("Copy demo completed successfully.")
        Else
            Console.Out.WriteLine("Copy demo failed.")
        End If

        returnCode = tempReturnCode AndAlso returnCode

        ' Call the Check demo.
        tempReturnCode = CheckDemo()
        If tempReturnCode = True Then
            Console.Out.WriteLine("Check demo completed successfully.")
        Else
            Console.Out.WriteLine("Check demo failed.")
        End If

        returnCode = tempReturnCode AndAlso returnCode

        ' Call the GetHashCode demo.
        tempReturnCode = GetHashCodeDemo()
        If tempReturnCode = True Then
            Console.Out.WriteLine("GetHashCode demo completed successfully.")
        Else
            Console.Out.WriteLine("GetHashCode demo failed.")
        End If

        returnCode = tempReturnCode AndAlso returnCode

        ' Call the ToFromXml demo.
        tempReturnCode = ToFromXmlDemo()
        If tempReturnCode = True Then
            Console.Out.WriteLine("ToFromXml demo completed successfully.")
        Else
            Console.Out.WriteLine("ToFromXml demo failed.")
        End If

        returnCode = tempReturnCode AndAlso returnCode
        Return returnCode
    End Function 'RunDemo

    ' Test harness.
    Public Overloads Shared Sub Main(ByVal args() As [String])
        Try
            Dim testcase As New GacMembershipConditionDemo
            Dim returnCode As Boolean = testcase.RunDemo()
            If returnCode Then
                Console.Out.WriteLine( _
                    "The GacMembershipCondition demo completed successfully.")
                Console.Out.WriteLine("Press the Enter key to exit.")
                Dim consoleInput As String = Console.ReadLine()
                System.Environment.ExitCode = 100
            Else
                Console.Out.WriteLine("The GacMembershipCondition demo failed.")
                Console.Out.WriteLine("Press the ENTER key to exit.")
                Dim consoleInput As String = Console.ReadLine()
                System.Environment.ExitCode = 101
            End If
        Catch e As Exception
            Console.Out.WriteLine("The GacIdentityPermission demo failed.")
            Console.WriteLine(e.ToString())
            Console.Out.WriteLine("Press the Enter key to exit.")
            Dim consoleInput As String = Console.ReadLine()
            System.Environment.ExitCode = 101
        End Try
    End Sub 'Main
End Class 'GacMembershipConditionDemo

' </Snippet1>
