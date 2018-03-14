'<snippet36>
Imports System
Imports System.Runtime.InteropServices

'<snippet37>

Public Delegate Function FPtr( ByVal value As Integer ) As Boolean
Public Delegate Function FPtr2( ByVal value As String ) As Boolean

Public Class LibWrap
    ' Declares managed prototypes for unmanaged functions.
    Declare Sub TestCallBack Lib "..\LIB\PinvokeLib.dll" ( ByVal cb _
        As FPtr, ByVal value As Integer )

    Declare Sub TestCallBack2 Lib "..\LIB\PinvokeLib.dll" ( ByVal cb2 _
        As FPtr2, ByVal value As String )
End Class
'</snippet37>

'<snippet38>
Public Class App
   Public Shared Sub Main()
        Dim cb As FPtr
        cb = AddressOf App.DoSomething
        Dim cb2 As FPtr2
        cb2 = AddressOf App.DoSomething2
        LibWrap.TestCallBack( cb, 99 )
        LibWrap.TestCallBack2( cb2, "abc" )
    End Sub 'Main

    Public Shared Function DoSomething( ByVal value As Integer ) As Boolean
        Console.WriteLine( ControlChars.CrLf + "Callback called with param: {0}", value )
        ' ...
        Return True
    End Function

    Public Shared Function DoSomething2( ByVal value As String ) As Boolean
        Console.WriteLine( ControlChars.CrLf + "Callback called with param: {0}", value )
        ' ...
        Return True
    End Function
End Class
'</snippet38>
'</snippet36>
