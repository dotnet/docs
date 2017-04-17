'<snippet22>
Imports System
Imports System.Runtime.InteropServices

'<snippet23>
' Declares a managed structure for each unmanaged structure.
<StructLayout(LayoutKind.Sequential, CharSet := CharSet.Ansi)> _
Public Structure MyPerson
    Public first As String
    Public last As String
End Structure 'MyPerson

<StructLayout(LayoutKind.Sequential)> _
Public Structure MyPerson2
    Public person As IntPtr
    Public age As Integer
End Structure 'MyPerson2

<StructLayout(LayoutKind.Sequential)> _
Public Structure MyPerson3
    Public person As MyPerson
    Public age As Integer
End Structure 'MyPerson3

<StructLayout(LayoutKind.Sequential)> _
Public Structure MyArrayStruct
    Public flag As Boolean
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=3)> _
    Public vals As Integer()
End Structure 'MyArrayStruct

Public Class LibWrap
    ' Declares managed prototypes for unmanaged functions.
    Declare Function TestStructInStruct Lib "..\LIB\PinvokeLib.dll" ( _
        ByRef person2 As MyPerson2) As Integer

    Declare Function TestStructInStruct3 Lib "..\LIB\PinvokeLib.dll" ( _
        ByVal person3 As MyPerson3) As Integer

    Declare Function TestArrayInStruct Lib "..\LIB\PinvokeLib.dll" ( _
        ByRef myStruct As MyArrayStruct) As Integer
End Class 'LibWrap

'</snippet23>

'<snippet24>
Public Class App
    Public Shared Sub Main()
        ' Structure with a pointer to another structure.
        Dim personName As MyPerson
        personName.first = "Mark"
        personName.last = "Lee"
  
        Dim personAll As MyPerson2
        personAll.age = 30
  
        Dim buffer As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf( _
            personName))
        Marshal.StructureToPtr(personName, buffer, False)

        personAll.person = buffer

        Console.WriteLine(ControlChars.CrLf & "Person before call:")
        Console.WriteLine("first = {0}, last = {1}, age = {2}", _
            personName.first, personName.last, personAll.age)

        Dim res As Integer = LibWrap.TestStructInStruct(personAll)

        Dim personRes As MyPerson = _
            CType(Marshal.PtrToStructure(personAll.person, _
            GetType(MyPerson)), MyPerson)

        Marshal.FreeCoTaskMem(buffer)

        Console.WriteLine("Person after call:")
        Console.WriteLine("first = {0}, last = {1}, age = {2}", _
        personRes.first, _
            personRes.last, personAll.age)

        ' Structure with an embedded structure.
        Dim person3 As New MyPerson3()
        person3.person.first = "John"
        person3.person.last = "Evans"
        person3.age = 27
        LibWrap.TestStructInStruct3(person3)

        ' Structure with an embedded array.
        Dim myStruct As New MyArrayStruct()

        myStruct.flag = False
        Dim array(2) As Integer
        myStruct.vals = array
        myStruct.vals(0) = 1
        myStruct.vals(1) = 4
        myStruct.vals(2) = 9

        Console.WriteLine(vbNewLine + "Structure with array before call:")
        Console.WriteLine(myStruct.flag)
        Console.WriteLine("{0} {1} {2}", myStruct.vals(0), _
            myStruct.vals(1), myStruct.vals(2))

        LibWrap.TestArrayInStruct(myStruct)
        Console.WriteLine(vbNewLine + "Structure with array after call:")
        Console.WriteLine(myStruct.flag)
        Console.WriteLine("{0} {1} {2}", myStruct.vals(0), _
            myStruct.vals(1), myStruct.vals(2))
    End Sub 'Main
End Class 'App
'</snippet24>
'</snippet22>
