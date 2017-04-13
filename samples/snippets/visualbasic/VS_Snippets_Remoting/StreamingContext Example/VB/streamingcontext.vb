'<snippet1>
Imports System
Imports System.IO
Imports System.Collections
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization
Imports System.Runtime.InteropServices
Imports System.Security.Permissions

<Assembly: SecurityPermission( _
SecurityAction.RequestMinimum, Execution:=True)> 
' This class includes several Win32 interop definitions.
Friend Class Win32
    Public Shared ReadOnly InvalidHandleValue As New IntPtr(-1)
    Public Const FILE_MAP_WRITE As Int32 = 2
    Public Const PAGE_READWRITE As Int32 = &H4

    <DllImport("Kernel32", CharSet:=CharSet.Unicode)> _
    Public Shared Function CreateFileMapping(ByVal hFile As IntPtr, _
                                             ByVal pAttributes As IntPtr, _
                                             ByVal flProtect As Int32, _
                                             ByVal dwMaximumSizeHigh As Int32, _
                                             ByVal dwMaximumSizeLow As Int32, _
                                             ByVal pName As String) As IntPtr
    End Function

    <DllImport("Kernel32", CharSet:=CharSet.Unicode)> _
    Public Shared Function OpenFileMapping(ByVal dwDesiredAccess As Int32, _
                                           ByVal bInheritHandle As Boolean, _
                                           ByVal name As String) As IntPtr
    End Function

    <DllImport("Kernel32", CharSet:=CharSet.Unicode)> _
    Public Shared Function CloseHandle(ByVal handle As IntPtr) As Boolean
    End Function

    <DllImport("Kernel32", CharSet:=CharSet.Unicode)> _
    Public Shared Function MapViewOfFile(ByVal hFileMappingObject As IntPtr, _
                                         ByVal dwDesiredAccess As Int32, _
                                         ByVal dwFileOffsetHigh As Int32, _
                                         ByVal dwFileOffsetLow As Int32, _
                                         ByVal dwNumberOfBytesToMap As IntPtr) _
                                         As IntPtr
    End Function

    <DllImport("Kernel32", CharSet:=CharSet.Unicode)> _
    Public Shared Function UnmapViewOfFile(ByVal address As IntPtr) As Boolean
    End Function

    <DllImport("Kernel32", CharSet:=CharSet.Unicode)> _
    Public Shared Function DuplicateHandle(ByVal hSourceProcessHandle As IntPtr, _
                                           ByVal hSourceHandle As IntPtr, _
                                           ByVal hTargetProcessHandle As IntPtr, _
                                           ByRef lpTargetHandle As IntPtr, _
                                           ByVal dwDesiredAccess As Int32, _
                                           ByVal bInheritHandle As Boolean, _
                                           ByVal dwOptions As Int32) As Boolean
    End Function

    Public Const DUPLICATE_CLOSE_SOURCE As Int32 = &H1
    Public Const DUPLICATE_SAME_ACCESS As Int32 = &H2

    <DllImport("Kernel32", CharSet:=CharSet.Unicode)> Public Shared Function GetCurrentProcess() As IntPtr
    End Function
End Class


' This class wraps memory that can be simultaneously 
' shared by multiple AppDomains and Processes.
<Serializable()> Public NotInheritable Class SharedMemory
    Implements ISerializable
    Implements IDisposable

    ' The handle and string that identify 
    ' the Windows file-mapping object.
    Private m_hFileMap As IntPtr = IntPtr.Zero
    Private m_name As String

    ' The address of the memory-mapped file-mapping object.
    Private m_address As IntPtr
    <SecurityPermissionAttribute(SecurityAction.LinkDemand, _
    Flags:=SecurityPermissionFlag.UnmanagedCode)> _
    Public Function GetByte(ByVal offset As Int32) As Byte
        Dim b(0) As Byte
        Marshal.Copy(New IntPtr(m_address.ToInt64() + offset), b, 0, 1)
        Return b(0)
    End Function

    <SecurityPermissionAttribute(SecurityAction.LinkDemand, _
    Flags:=SecurityPermissionFlag.UnmanagedCode)> _
    Public Sub SetByte(ByVal offset As Int32, ByVal value As Byte)
        Dim b(0) As Byte
        b(0) = value
        Marshal.Copy(b, 0, New IntPtr(m_address.ToInt64() + offset), 1)
    End Sub


    ' The constructors.
    Public Sub New(ByVal size As Int32)
        Me.New(size, Nothing)
    End Sub

    Public Sub New(ByVal size As Int32, ByVal name As String)
        m_hFileMap = Win32.CreateFileMapping(Win32.InvalidHandleValue, _
           IntPtr.Zero, Win32.PAGE_READWRITE, 0, size, name)
        If (m_hFileMap.Equals(IntPtr.Zero)) Then _
           Throw New Exception("Could not create memory-mapped file.")
        m_name = name
        m_address = Win32.MapViewOfFile(m_hFileMap, _
           Win32.FILE_MAP_WRITE, 0, 0, IntPtr.Zero)
    End Sub


    ' The cleanup methods.
    Public Sub Dispose() Implements IDisposable.Dispose
        GC.SuppressFinalize(Me)
        Dispose(True)
    End Sub

    Private Sub Dispose(ByVal disposing As Boolean)
        Win32.UnmapViewOfFile(m_address)
        Win32.CloseHandle(m_hFileMap)
        m_address = IntPtr.Zero
        m_hFileMap = IntPtr.Zero
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub


    ' Private helper methods.
    Private Shared Function AllFlagsSet(ByVal flags As Int32, _
                                        ByVal flagsToTest As Int32) As Boolean
        Return (flags And flagsToTest) = flagsToTest
    End Function

    Private Shared Function AnyFlagsSet(ByVal flags As Int32, _
                                        ByVal flagsToTest As Int32) As Boolean
        Return (flags And flagsToTest) <> 0
    End Function


    ' The security attribute demands that code that calls  
    ' this method have permission to perform serialization.
    <SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter:=True)> _
    Sub GetObjectData(ByVal info As SerializationInfo, _
                      ByVal context As StreamingContext) _
                      Implements ISerializable.GetObjectData
        ' The context's State member indicates where the object will be deserialized.

        ' A SharedMemory object cannot be serialized 
        ' to any of the following destinations.
        Const InvalidDestinations As StreamingContextStates = _
           StreamingContextStates.CrossMachine Or _
           StreamingContextStates.File Or _
           StreamingContextStates.Other Or _
           StreamingContextStates.Persistence Or _
           StreamingContextStates.Remoting
        If AnyFlagsSet(CType(context.State, Int32), _
                       CType(InvalidDestinations, Int32)) Then
            Throw New SerializationException("The SharedMemory object " & _
               "cannot be serialized to any of the following streaming contexts: " _
               & InvalidDestinations)
        End If

        Const DeserializableByHandle As StreamingContextStates = _
                 StreamingContextStates.Clone Or _
                 StreamingContextStates.CrossAppDomain

        If AnyFlagsSet(CType(context.State, Int32), _
              CType(DeserializableByHandle, Int32)) Then
            info.AddValue("hFileMap", m_hFileMap)
        End If

        Const DeserializableByName As StreamingContextStates = _
                 StreamingContextStates.CrossProcess   ' The same computer.
        If AnyFlagsSet(CType(context.State, Int32), CType(DeserializableByName, _
                       Int32)) Then
            If m_name = Nothing Then
                Throw New SerializationException("The SharedMemory object " & _
                   "cannot be serialized CrossProcess because it was not constructed " & _
                   "with a String name.")
            End If
            info.AddValue("name", m_name)
        End If
    End Sub

    Private Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        ' The context's State member indicates where the object was serialized from.

        Const InvalidSources As StreamingContextStates = _
                 StreamingContextStates.CrossMachine Or _
                 StreamingContextStates.File Or _
                 StreamingContextStates.Other Or _
                 StreamingContextStates.Persistence Or _
                 StreamingContextStates.Remoting

        If AnyFlagsSet(CType(context.State, Int32), CType(InvalidSources, Int32)) Then
            Throw New SerializationException("The SharedMemory object " & _
               "cannot be deserialized from any of the following stream contexts: " & _
               InvalidSources)
        End If

        Const SerializedByHandle As StreamingContextStates = _
                 StreamingContextStates.Clone Or _
                 StreamingContextStates.CrossAppDomain ' The same process.
        If AnyFlagsSet(CType(context.State, Int32), _
              CType(SerializedByHandle, Int32)) Then
            Try
                Win32.DuplicateHandle(Win32.GetCurrentProcess(), _
                   CType(info.GetValue("hFileMap", GetType(IntPtr)), IntPtr), _
                      Win32.GetCurrentProcess(), m_hFileMap, 0, False, _
                      Win32.DUPLICATE_SAME_ACCESS)
            Catch e As SerializationException
                Throw New SerializationException("A SharedMemory was not " & _
                   "serialized using any of the following streaming contexts: " & _
                   SerializedByHandle)
            End Try
        End If

        Const SerializedByName As StreamingContextStates = _
                 StreamingContextStates.CrossProcess   ' The same computer.
        If AnyFlagsSet(CType(context.State, Int32), _
                       CType(SerializedByName, Int32)) Then
            Try
                m_name = info.GetString("name")
            Catch e As SerializationException
                Throw New SerializationException("A SharedMemory object " & _
                   "was not serialized using any of the following streaming contexts: " & _
                   SerializedByName)
            End Try
            m_hFileMap = Win32.OpenFileMapping(Win32.FILE_MAP_WRITE, False, m_name)
        End If
        If Not m_hFileMap.Equals(IntPtr.Zero) Then
            m_address = Win32.MapViewOfFile(m_hFileMap, _
               Win32.FILE_MAP_WRITE, 0, 0, IntPtr.Zero)
        Else
            Throw New SerializationException("A SharedMemory object " & _
               "could not be deserialized.")
        End If
    End Sub
End Class

Class App
    <STAThread()> Shared Sub Main()
        Serialize()
        Console.WriteLine()
        Deserialize()
    End Sub

    Shared Sub Serialize()
        ' Create a hashtable of values that will eventually be serialized.
        Dim sm As New SharedMemory(1024, "MyMemory")
        Dim x As Int32
        For x = 0 To 99
            sm.SetByte(x, x)
        Next

        Dim b(9) As Byte
        For x = 0 To b.Length - 1
            b(x) = sm.GetByte(x)
        Next
        Console.WriteLine(BitConverter.ToString(b))

        ' To serialize the hashtable (and its key/value pairs), you must first 
        ' open a stream for writing. Use a file stream here.
        Dim fs As New FileStream("DataFile.dat", FileMode.Create)

        ' Construct a BinaryFormatter telling it where 
        ' the objects will be serialized to.
        Dim formatter As New BinaryFormatter(Nothing, _
           New StreamingContext(StreamingContextStates.CrossAppDomain))
        Try
            formatter.Serialize(fs, sm)
        Catch e As SerializationException
            Console.WriteLine("Failed to serialize. Reason: " + e.Message)
            Throw
        Finally
            fs.Close()
        End Try
    End Sub

    Shared Sub Deserialize()
        ' Declare the hashtable reference.
        Dim sm As SharedMemory = Nothing

        ' Open the file containing the data that you want to deserialize.
        Dim fs As New FileStream("DataFile.dat", FileMode.Open)
        Try
            Dim Formatter As New BinaryFormatter(Nothing, _
               New StreamingContext(StreamingContextStates.CrossAppDomain))

            ' Deserialize the SharedMemory object from the file and 
            ' assign the reference to the local variable.
            sm = DirectCast(Formatter.Deserialize(fs), SharedMemory)
        Catch e As SerializationException
            Console.WriteLine("Failed to deserialize. Reason: " & e.Message)
        Finally
            fs.Close()
        End Try

        ' To prove that the SharedMemory object deserialized correctly, 
        ' display some of its bytes to the console.
        Dim b(9) As Byte
        Dim x As Int32
        For x = 0 To b.Length - 1
            b(x) = sm.GetByte(x)
        Next
        Console.WriteLine(BitConverter.ToString(b))
    End Sub
End Class
'</snippet1>
