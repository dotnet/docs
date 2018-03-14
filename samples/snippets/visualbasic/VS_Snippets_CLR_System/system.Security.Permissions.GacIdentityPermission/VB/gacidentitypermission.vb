' <Snippet1>
Imports System
Imports System.Security
Imports System.Security.Permissions
Imports Microsoft.VisualBasic



Public Class GacIdentityPermissionDemo

    ' <Snippet2>
    ' IsSubsetOf determines whether the current permission is a subset of the specified permission.
    Private Function IsSubsetOfDemo() As Boolean
        Try
            '<Snippet9>
            Dim Gac1 As New GacIdentityPermission
            Dim Gac2 As New GacIdentityPermission(PermissionState.None)
            If (Gac1.Equals(Gac2)) Then
                Console.WriteLine("GacIdentityPermission() equals GacIdentityPermission(PermissionState.None).")
            End If
            '</Snippet9>
            If Gac1.IsSubsetOf(Gac2) Then
                Console.WriteLine((Gac1.ToString() & " is a subset of " & Gac2.ToString()))
            Else
                Console.WriteLine((Gac1.ToString() & " is not a subset of " & Gac2.ToString()))
            End If
        Catch e As Exception
            Console.WriteLine(("An exception was thrown : " & e.ToString().ToString()))
            Return False
        End Try
        Return True
    End Function 'IsSubsetOfDemo

    ' </Snippet2>
    ' <Snippet3>
    ' Union creates a new permission that is the union of the current permission 
    ' and the specified permission.
    Private Function UnionDemo() As Boolean
        '<Snippet7>
        Dim Gac1 As New GacIdentityPermission(PermissionState.None)
        '</Snippet7>
        '<Snippet8>
        Dim Gac2 As New GacIdentityPermission
        '</Snippet8>
        Try
            Dim p3 As GacIdentityPermission = CType(Gac1.Union(Gac2), GacIdentityPermission)

            If Not (p3 Is Nothing) Then
                Console.WriteLine("The union of two GacIdentityPermissions was successful.")

            Else
                Console.WriteLine("The union of two GacIdentityPermissions failed.")
                Return False
            End If
        Catch e As Exception
            Console.WriteLine(("An exception was thrown : " & e.ToString()))
            Return False
        End Try

        Return True
    End Function 'UnionDemo

    ' </Snippet3>
    ' <Snippet4>
    ' Intersect creates and returns a new permission that is the intersection of the 
    ' current permission and the specified permission.
    Private Function IntersectDemo() As Boolean
        Dim Gac1 As New GacIdentityPermission
        Dim Gac2 As New GacIdentityPermission
        Try
            Dim p3 As GacIdentityPermission = CType(Gac1.Intersect(Gac2), GacIdentityPermission)
            If Not (p3 Is Nothing) Then
                Console.WriteLine(("The intersection of the two permissions = " & p3.ToString() & ControlChars.Lf))

            Else
                Console.WriteLine("The intersection of the two permissions is null." & ControlChars.Lf)
            End If
        Catch e As Exception
            Console.WriteLine(("An exception was thrown : " & e.ToString()))
            Return False
        End Try

        Return True
    End Function 'IntersectDemo

    '</Snippet4>
    '<Snippet5>
    'Copy creates and returns an identical copy of the current permission.
    Private Function CopyDemo() As Boolean

        Dim Gac1 As New GacIdentityPermission
        Dim Gac2 As New GacIdentityPermission
        Console.WriteLine("**************************************************************************")
        Try
            Gac2 = CType(Gac1.Copy(), GacIdentityPermission)
            If Not (Gac2 Is Nothing) Then
                Console.WriteLine(("Result of copy = " & Gac2.ToString() & ControlChars.Lf))
            End If

        Catch e As Exception
            Console.WriteLine(("Copy failed : " & Gac1.ToString() & e.ToString()))
            Return False
        End Try

        Return True
    End Function 'CopyDemo

    '</Snippet5>
    '<Snippet6>
    ' ToXml creates an XML encoding of the permission and its current state; FromXml reconstructs a 
    ' permission with the specified state from the XML encoding. 
    Private Function ToFromXmlDemo() As Boolean
        Dim Gac1 As New GacIdentityPermission
        Dim Gac2 As New GacIdentityPermission
        Console.WriteLine("**************************************************************************")
        Try
            Gac2 = New GacIdentityPermission(PermissionState.None)
            Gac2.FromXml(Gac1.ToXml())
            Dim result As Boolean = Gac2.Equals(Gac1)
            If Gac2.IsSubsetOf(Gac1) AndAlso Gac1.IsSubsetOf(Gac2) Then
                Console.WriteLine(("Result of ToFromXml = " & Gac2.ToString()))
            Else
                Console.WriteLine(Gac2.ToString())
                Console.WriteLine(Gac1.ToString())
                Return False
            End If
        Catch e As Exception
            Console.WriteLine(("ToFromXml failed. " & e.ToString()))
            Return False
        End Try

        Return True
    End Function 'ToFromXmlDemo

    '</Snippet6>
    ' Invoke all demos.
    Public Function RunDemo() As Boolean

        Dim returnCode As Boolean = True
        Dim tempReturnCode As Boolean
        ' Call the IsSubsetOf demo.
        tempReturnCode = IsSubsetOfDemo()
        If tempReturnCode Then
            Console.Out.WriteLine("IsSubsetOf demo completed successfully.")
        Else
            Console.Out.WriteLine("Subset demo failed.")
        End If
        returnCode = tempReturnCode AndAlso returnCode

        ' Call the Union demo.
        tempReturnCode = UnionDemo()
        If tempReturnCode Then
            Console.Out.WriteLine("Union demo completed successfully.")
        Else
            Console.Out.WriteLine("Union demo failed.")
        End If
        returnCode = tempReturnCode AndAlso returnCode

        ' Call the Intersect demo.	
        tempReturnCode = IntersectDemo()
        If tempReturnCode Then
            Console.Out.WriteLine("Intersect demo completed successfully.")
        Else
            Console.Out.WriteLine("Intersect demo failed.")
        End If
        returnCode = tempReturnCode AndAlso returnCode


        ' Call the Copy demo.	
        tempReturnCode = CopyDemo()
        If tempReturnCode Then
            Console.Out.WriteLine("Copy demo completed successfully.")
        Else
            Console.Out.WriteLine("Copy demo failed.")
        End If
        returnCode = tempReturnCode AndAlso returnCode

        ' Call the ToFromXML demo.	
        tempReturnCode = ToFromXmlDemo()
        If tempReturnCode Then
            Console.Out.WriteLine("ToFromXML demo completed successfully.")
        Else
            Console.Out.WriteLine("ToFromXml demo failed.")
        End If
        returnCode = tempReturnCode AndAlso returnCode

        Return returnCode
    End Function 'RunDemo

    ' Test harness.
    Public Overloads Shared Sub Main(ByVal args() As [String])
        Try
            Dim testcase As New GACIdentityPermissionDemo
            Dim returnCode As Boolean = testcase.RunDemo()
            If returnCode Then
                Console.Out.WriteLine("The GacIdentityPermission demo completed successfully.")
                Console.Out.WriteLine("Press the Enter key to exit.")
                Dim consoleInput As String = Console.ReadLine()
                System.Environment.ExitCode = 100
            Else
                Console.Out.WriteLine("The GacIdentityPermission demo failed.")
                Console.Out.WriteLine("Press the Enter key to exit.")
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
End Class 'GacIdentityPermissionDemo



' </Snippet1>
