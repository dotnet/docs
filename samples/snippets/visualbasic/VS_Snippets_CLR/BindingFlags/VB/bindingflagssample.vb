' <snippet1>
Imports System
Imports System.Reflection
Imports System.IO

Class Invoke

    Public Shared Sub Main()
        ' BindingFlags.InvokeMethod
        ' Call a static method.
        Dim t As Type = GetType(TestClass)

        Console.WriteLine()
        Console.WriteLine("Invoking a static method.")
        Console.WriteLine("-------------------------")
        t.InvokeMember("SayHello", BindingFlags.InvokeMethod Or BindingFlags.Public _
            Or BindingFlags.Static, Nothing, Nothing, New Object() {})

        ' BindingFlags.InvokeMethod
        ' Call an instance method.
        Dim c As New TestClass()
        Console.WriteLine()
        Console.WriteLine("Invoking an instance method.")
        Console.WriteLine("----------------------------")
        c.GetType().InvokeMember("AddUp", BindingFlags.InvokeMethod, Nothing, c, New Object() {})
        c.GetType().InvokeMember("AddUp", BindingFlags.InvokeMethod, Nothing, c, New Object() {})

        ' BindingFlags.InvokeMethod
        ' Call a method with parameters.
        Dim args() As Object = {100.09, 184.45}
        Dim result As Object
        Console.WriteLine()
        Console.WriteLine("Invoking a method with parameters.")
        Console.WriteLine("---------------------------------")
        result = t.InvokeMember("ComputeSum", BindingFlags.InvokeMethod, Nothing, Nothing, args)
        Console.WriteLine("{0} + {1} = {2}", args(0), args(1), result)

        ' BindingFlags.GetField, SetField
        Console.WriteLine()
        Console.WriteLine("Invoking a field (getting and setting.)")
        Console.WriteLine("--------------------------------------")
        ' Get a field value.
        result = t.InvokeMember("Name", BindingFlags.GetField, Nothing, c, New Object() {})
        Console.WriteLine("Name == {0}", result)
        ' Set a field.
        t.InvokeMember("Name", BindingFlags.SetField, Nothing, c, New Object() {"NewName"})
        result = t.InvokeMember("Name", BindingFlags.GetField, Nothing, c, New Object() {})
        Console.WriteLine("Name == {0}", result)

        Console.WriteLine()
        Console.WriteLine("Invoking an indexed property (getting and setting.)")
        Console.WriteLine("--------------------------------------------------")
        ' BindingFlags.GetProperty 
        ' Get an indexed property value.
        Dim index As Integer = 3
        result = t.InvokeMember("Item", BindingFlags.GetProperty, Nothing, c, New Object() {index})
        Console.WriteLine("Item[{0}] == {1}", index, result)
        ' BindingFlags.SetProperty
        ' Set an indexed property value.
        index = 3
        t.InvokeMember("Item", BindingFlags.SetProperty, Nothing, c, New Object() {index, "NewValue"})
        result = t.InvokeMember("Item", BindingFlags.GetProperty, Nothing, c, New Object() {index})
        Console.WriteLine("Item[{0}] == {1}", index, result)

        Console.WriteLine()
        Console.WriteLine("Getting a field or property.")
        Console.WriteLine("----------------------------")
        ' BindingFlags.GetField
        ' Get a field or property.
        result = t.InvokeMember("Name", BindingFlags.GetField Or BindingFlags.GetProperty, Nothing, _
            c, New Object() {})
        Console.WriteLine("Name == {0}", result)
        ' BindingFlags.GetProperty
        result = t.InvokeMember("Value", BindingFlags.GetField Or BindingFlags.GetProperty, Nothing, _
            c, New Object() {})
        Console.WriteLine("Value == {0}", result)

        Console.WriteLine()
        Console.WriteLine("Invoking a method with named parameters.")
        Console.WriteLine("---------------------------------------")
        ' BindingFlags.InvokeMethod
        ' Call a method using named parameters.
        Dim argValues() As Object = {"Mouse", "Micky"}
        Dim argNames() As [String] = {"lastName", "firstName"}
        t.InvokeMember("PrintName", BindingFlags.InvokeMethod, Nothing, Nothing, argValues, Nothing, _
            Nothing, argNames)

        Console.WriteLine()
        Console.WriteLine("Invoking a default member of a type.")
        Console.WriteLine("------------------------------------")
        ' BindingFlags.Default
        ' Call the default member of a type.
        Dim t3 As Type = GetType(TestClass2)
        t3.InvokeMember("", BindingFlags.InvokeMethod Or BindingFlags.Default, Nothing, _
            New TestClass2(), New Object() {})

        Console.WriteLine()
        Console.WriteLine("Invoking a method with ByRef parameters.")
        Console.WriteLine("----------------------------------------")
        ' BindingFlags.Static, NonPublic, and Public
        ' Invoking a member by reference.
        Dim m As MethodInfo = t.GetMethod("Swap")
        args = New Object(1) {}
        args(0) = 1
        args(1) = 2
        m.Invoke(New TestClass(), args)
        Console.WriteLine("{0}, {1}", args(0), args(1))

        ' BindingFlags.CreateInstance
        ' Creating an instance.
        Console.WriteLine()
        Console.WriteLine("Creating an instance with parameterless constructor.")
        Console.WriteLine("----------------------------------------------------")
        Dim obj As Object = GetType(TestClass).InvokeMember("TestClass", BindingFlags.CreateInstance, _
            Nothing, Nothing, New Object() {})
        Console.WriteLine("Instance of {0} created.", obj.GetType().Name)

        Console.WriteLine()
        Console.WriteLine("Creating an instance with a constructor that has parameters.")
        Console.WriteLine("------------------------------------------------------------")
        obj = GetType(TestClass).InvokeMember("TestClass", BindingFlags.CreateInstance, Nothing, _
            Nothing, New Object() { "Hello, World!" })
        Console.WriteLine("Instance of {0} created with initial value '{1}'.", obj.GetType().Name, _
            obj.GetType().InvokeMember("Name", BindingFlags.GetField, Nothing, obj, Nothing))

        ' BindingFlags.DeclaredOnly
        Console.WriteLine()
        Console.WriteLine("DeclaredOnly instance members.")
        Console.WriteLine("------------------------------")
        Dim memInfo As System.Reflection.MemberInfo() = t.GetMembers(BindingFlags.DeclaredOnly Or _
            BindingFlags.Public Or BindingFlags.Instance)
        Dim i As Integer
        For i = 0 To memInfo.Length - 1
            Console.WriteLine(memInfo(i).Name)
        Next i

        ' BindingFlags.IgnoreCase
        Console.WriteLine()
        Console.WriteLine("Using IgnoreCase and invoking the PrintName method.")
        Console.WriteLine("---------------------------------------------------")
        t.InvokeMember("printname", BindingFlags.IgnoreCase Or BindingFlags.Public Or _
            BindingFlags.Static Or BindingFlags.InvokeMethod, Nothing, Nothing, _
            New Object() {"Brad", "Smith"})

        ' BindingFlags.FlattenHierarchy
        Console.WriteLine()
        Console.WriteLine("Using FlattenHierarchy to get inherited static protected and public members." )
        Console.WriteLine("----------------------------------------------------------------------------")
        Dim finfos() As FieldInfo = GetType(MostDerived).GetFields(BindingFlags.NonPublic Or _
              BindingFlags.Public Or BindingFlags.Static Or BindingFlags.FlattenHierarchy)
        For Each finfo As FieldInfo In finfos
            Console.WriteLine("{0} defined in {1}.", finfo.Name, finfo.DeclaringType.Name)
        Next

        Console.WriteLine()
        Console.WriteLine("Without FlattenHierarchy." )
        Console.WriteLine("-------------------------")
        finfos = GetType(MostDerived).GetFields(BindingFlags.NonPublic Or BindingFlags.Public Or _
              BindingFlags.Static)
        For Each finfo As FieldInfo In finfos
            Console.WriteLine("{0} defined in {1}.", finfo.Name, finfo.DeclaringType.Name)
        Next
    End Sub
End Class

Public Class TestClass
    Public Name As String
    Private values() As [Object] = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}

    Default Public Property Item(ByVal index As Integer) As [Object]
        Get
            Return values(index)
        End Get
        Set(ByVal Value As [Object])
            values(index) = Value
        End Set
    End Property

    Public ReadOnly Property Value() As [Object]
        Get
            Return "the value"
        End Get
    End Property

    Public Sub New(ByVal initName As String)
        Name = initName
    End Sub 

    Public Sub New()
        MyClass.New("initialName")
    End Sub 

    Private methodCalled As Integer = 0

    Public Shared Sub SayHello()
        Console.WriteLine("Hello")
    End Sub 

    Public Sub AddUp()
        methodCalled += 1
        Console.WriteLine("AddUp Called {0} times", methodCalled)
    End Sub 

    Public Shared Function ComputeSum(ByVal d1 As Double, ByVal d2 As Double) As Double
        Return d1 + d2
    End Function 

    Public Shared Sub PrintName(ByVal firstName As [String], ByVal lastName As [String])
        Console.WriteLine("{0},{1}", lastName, firstName)
    End Sub 

    Public Sub PrintTime()
        Console.WriteLine(DateTime.Now)
    End Sub 

    Public Sub Swap(ByRef a As Integer, ByRef b As Integer)
        Dim x As Integer = a
        a = b
        b = x
    End Sub
End Class

<DefaultMemberAttribute("PrintTime")> _
Public Class TestClass2

    Public Sub PrintTime()
        Console.WriteLine(DateTime.Now)
    End Sub 
End Class

Public Class Base
    Shared BaseOnlyPrivate As Integer = 0
    Protected Shared BaseOnly As Integer = 0
End Class

Public Class Derived 
    Inherits Base
    Public Shared DerivedOnly As Integer = 0
End Class

Public Class MostDerived 
    Inherits Derived
End Class

' This example produces output similar to the following:
'
'Invoking a static method.
'-------------------------
'Hello
'
'Invoking an instance method.
'----------------------------
'AddUp Called 1 times
'AddUp Called 2 times
'
'Invoking a method with parameters.
'---------------------------------
'100.09 + 184.45 = 284.54
'
'Invoking a field (getting and setting.)
'--------------------------------------
'Name == initialName
'Name == NewName
'
'Invoking an indexed property (getting and setting.)
'--------------------------------------------------
'Item[3] == 3
'Item[3] == NewValue
'
'Getting a field or property.
'----------------------------
'Name == NewName
'Value == the value
'
'Invoking a method with named parameters.
'---------------------------------------
'Mouse,Micky
'
'Invoking a default member of a type.
'------------------------------------
'12/23/2009 4:34:22 PM
'
'Invoking a method with ByRef parameters.
'----------------------------------------
'2, 1
'
'Creating an instance with parameterless constructor.
'----------------------------------------------------
'Instance of TestClass created.
'
'Creating an instance with a constructor that has parameters.
'------------------------------------------------------------
'Instance of TestClass created with initial value 'Hello, World!'.
'
'DeclaredOnly instance members.
'------------------------------
'get_Item
'set_Item
'get_Value
'AddUp
'PrintTime
'Swap
'.ctor
'.ctor
'Item
'Value
'Name
'
'Using IgnoreCase and invoking the PrintName method.
'---------------------------------------------------
'Smith,Brad
'
'Using FlattenHierarchy to get inherited static protected and public members.
'----------------------------------------------------------------------------
'DerivedOnly defined in Derived.
'BaseOnly defined in Base.
'
'Without FlattenHierarchy.
'-------------------------
'
' </snippet1>
