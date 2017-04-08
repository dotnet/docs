'<Snippet1>
Imports System
Imports Microsoft.Win32.SafeHandles
Imports System.Runtime.InteropServices

Class SafeHandlesExample


    Shared Sub Main()
        Dim uMutex As New UnmanagedMutex("YourCompanyName_SafeHandlesExample_MUTEX")

        Try

            uMutex.Create()
            Console.WriteLine("Mutex created. Press Enter to release it.")
            Console.ReadLine()


        Catch e As Exception
            Console.WriteLine(e)
        Finally
            uMutex.Release()
            Console.WriteLine("Mutex Released.")
        End Try

        Console.ReadLine()

    End Sub
End Class


Class UnmanagedMutex



    ' Use interop to call the CreateMutex function.
    ' For more information about CreateMutex,
    ' see the unmanaged MSDN reference library.
    <DllImport("kernel32.dll", CharSet:=CharSet.Unicode)> _
    Shared Function CreateMutex(ByVal lpMutexAttributes As IntPtr, ByVal bInitialOwner As Boolean, ByVal lpName As String) As SafeWaitHandle

    End Function



    ' Use interop to call the ReleaseMutex function.
    ' For more information about ReleaseMutex,
    ' see the unmanaged MSDN reference library.
    <DllImport("kernel32.dll")> _
    Public Shared Function ReleaseMutex(ByVal hMutex As SafeWaitHandle) As Boolean

    End Function



    Private handleValue As SafeWaitHandle = Nothing
    Private mutexAttrValue As IntPtr = IntPtr.Zero
    Private nameValue As String = Nothing


    Public Sub New(ByVal Name As String)
        nameValue = Name

    End Sub



    Public Sub Create()
        If nameValue Is Nothing AndAlso nameValue.Length = 0 Then
            Throw New ArgumentNullException("nameValue")
        End If

        handleValue = CreateMutex(mutexAttrValue, True, nameValue)

        ' If the handle is invalid,
        ' get the last Win32 error 
        ' and throw a Win32Exception.
        If handleValue.IsInvalid Then
            Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error())
        End If

    End Sub


    Public ReadOnly Property Handle() As SafeWaitHandle
        Get
            ' If the handle is valid,
            ' return it.
            If Not handleValue.IsInvalid Then
                Return handleValue
            Else
                Return Nothing
            End If
        End Get
    End Property


    Public ReadOnly Property Name() As String
        Get
            Return nameValue
        End Get
    End Property



    Public Sub Release()
        ReleaseMutex(handleValue)

    End Sub
End Class
'</Snippet1>