' <Snippet1>
Imports System
Imports System.Security
Imports System.Security.Permissions



Public Class UIPermissionDemo


    Public Shared Sub Main(ByVal args() As String)
        IsSubsetOfDemo()
        CopyDemo()
        UnionDemo()
        IntersectDemo()
        ToFromXmlDemo()

    End Sub 'Main


    ' <Snippet2>
    ' IsSubsetOf determines whether the current permission is a subset of the specified permission.
    Private Shared Sub IsSubsetOfDemo()
        '<Snippet8>
        Dim uiPerm1 As New UIPermission(UIPermissionWindow.SafeTopLevelWindows)
        '</Snippet8>
        Dim uiPerm2 As New UIPermission(UIPermissionWindow.SafeSubWindows)
        CheckIsSubsetOfWindow(uiPerm1, uiPerm2)
        '<Snippet9>
        uiPerm1 = New UIPermission(UIPermissionClipboard.AllClipboard)
        '</Snippet9>
        uiPerm2 = New UIPermission(UIPermissionClipboard.OwnClipboard)
        CheckIsSubsetOfClipBoard(uiPerm1, uiPerm2)

    End Sub 'IsSubsetOfDemo

    Private Shared Sub CheckIsSubsetOfWindow(ByVal uiPerm1 As UIPermission, ByVal uiPerm2 As UIPermission)
        If uiPerm1.IsSubsetOf(uiPerm2) Then
            Console.WriteLine(uiPerm1.Window.ToString() + " is a subset of " + uiPerm2.Window.ToString())
        Else
            Console.WriteLine(uiPerm1.Window.ToString() + " is not a subset of " + uiPerm2.Window.ToString())
        End If

        If uiPerm2.IsSubsetOf(uiPerm1) Then
            Console.WriteLine(uiPerm2.Window.ToString() + " is a subset of " + uiPerm1.Window.ToString())
        Else
            Console.WriteLine(uiPerm2.Window.ToString() + " is not a subset of " + uiPerm1.Window.ToString())
        End If

    End Sub 'CheckIsSubsetOfWindow

    Private Shared Sub CheckIsSubsetOfClipBoard(ByVal uiPerm1 As UIPermission, ByVal uiPerm2 As UIPermission)
        If uiPerm1.IsSubsetOf(uiPerm2) Then
            Console.WriteLine(uiPerm1.Clipboard.ToString() + " is a subset of " + uiPerm2.Clipboard.ToString())
        Else
            Console.WriteLine(uiPerm1.Clipboard.ToString() + " is not a subset of " + uiPerm2.Clipboard.ToString())
        End If

        If uiPerm2.IsSubsetOf(uiPerm1) Then
            Console.WriteLine(uiPerm2.Clipboard.ToString() + " is a subset of " + uiPerm1.Clipboard.ToString())
        Else
            Console.WriteLine(uiPerm2.Clipboard.ToString() + " is not a subset of " + uiPerm1.Clipboard.ToString())
        End If

    End Sub 'CheckIsSubsetOfClipBoard

    ' </Snippet2>
    ' <Snippet3>
    ' Union creates a new permission that is the union of the current permission
    ' and the specified permission.
    Private Shared Sub UnionDemo()
        Dim uiPerm1 As New UIPermission(UIPermissionWindow.SafeTopLevelWindows)
        Dim uiPerm2 As New UIPermission(UIPermissionWindow.SafeSubWindows)
        Dim p3 As UIPermission = CType(uiPerm1.Union(uiPerm2), UIPermission)
        Try
            If Not (p3 Is Nothing) Then
                Console.WriteLine("The union of " + uiPerm1.Window.ToString() + " and " + vbLf + vbTab + uiPerm2.Window.ToString() + " is " + vbLf + vbTab + p3.Window.ToString() + vbLf)

            Else
                Console.WriteLine("The union of " + uiPerm1.Window.ToString() + " and " + vbLf + vbTab + uiPerm2.Window.ToString() + " is null." + vbLf)
            End If
        Catch e As SystemException
            Console.WriteLine("The union of " + uiPerm1.Window.ToString() + " and " + vbLf + vbTab + uiPerm2.Window.ToString() + " failed.")

            Console.WriteLine(e.Message)
        End Try

    End Sub 'UnionDemo

    ' </Snippet3>
    ' <Snippet4>
    ' Intersect creates and returns a new permission that is the intersection of the
    ' current permission and the permission specified.
    Private Shared Sub IntersectDemo()
        '<Snippet10>
        Dim uiPerm1 As New UIPermission(UIPermissionWindow.SafeTopLevelWindows, UIPermissionClipboard.OwnClipboard)
        '</Snippet10>
        Dim uiPerm2 As New UIPermission(UIPermissionWindow.SafeSubWindows, UIPermissionClipboard.NoClipboard)
        Dim p3 As UIPermission = CType(uiPerm1.Intersect(uiPerm2), UIPermission)

        Console.WriteLine("The intersection of " + uiPerm1.Window.ToString() + " and " + vbLf + vbTab + uiPerm2.Window.ToString() + " is " + p3.Window.ToString() + vbLf)
        Console.WriteLine("The intersection of " + uiPerm1.Clipboard.ToString() + " and " + vbLf + vbTab + uiPerm2.Clipboard.ToString() + " is " + p3.Clipboard.ToString() + vbLf)

    End Sub 'IntersectDemo


    '</Snippet4>
    '<Snippet5>
    'Copy creates and returns an identical copy of the current permission.
    Private Shared Sub CopyDemo()

        Dim uiPerm1 As New UIPermission(UIPermissionWindow.SafeTopLevelWindows)
        '<Snippet7>
        Dim uiPerm2 As New UIPermission(PermissionState.None)
        '</Snippet7>
        uiPerm2 = CType(uiPerm1.Copy(), UIPermission)
        If Not (uiPerm2 Is Nothing) Then
            Console.WriteLine("The copy succeeded:  " + uiPerm2.ToString() + " " + vbLf)
        End If

    End Sub 'CopyDemo

    '</Snippet5>
    '<Snippet6>
    ' ToXml creates an XML encoding of the permission and its current state; FromXml reconstructs a
    ' permission with the specified state from the XML encoding.
    Private Shared Sub ToFromXmlDemo()


        Dim uiPerm1 As New UIPermission(UIPermissionWindow.SafeTopLevelWindows)
        Dim uiPerm2 As New UIPermission(PermissionState.None)
        uiPerm2.FromXml(uiPerm1.ToXml())
        Dim result As Boolean = uiPerm2.Equals(uiPerm1)
        If result Then
            Console.WriteLine("Result of ToFromXml = " + uiPerm2.ToString())
        Else
            Console.WriteLine(uiPerm2.ToString())
            Console.WriteLine(uiPerm1.ToString())
        End If

    End Sub 'ToFromXmlDemo 
End Class 'UIPermissionDemo
'</Snippet6>

' </Snippet1>
' This code example creates the following output:

'SafeTopLevelWindows is not a subset of SafeSubWindows
'SafeSubWindows is a subset of SafeTopLevelWindows
'AllClipboard is not a subset of OwnClipboard
'OwnClipboard is a subset of AllClipboard
'The copy succeeded:  <IPermission class="System.Security.Permissions.UIPermissio
'n, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
'version="1"
'Window="SafeTopLevelWindows"/>


'The union of SafeTopLevelWindows and
'        SafeSubWindows is
'        SafeTopLevelWindows

'The intersection of SafeTopLevelWindows and
'        SafeSubWindows is SafeSubWindows

'The intersection of OwnClipboard and
'        NoClipboard is NoClipboard

'Result of ToFromXml = <IPermission class="System.Security.Permissions.UIPermissi
'on, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"

'version="1"
'Window="SafeTopLevelWindows"/>