Option Strict On
Option Explicit On

' <snippet13>
Imports System.Runtime.InteropServices
' </snippet13>
Imports System.Windows.Forms

' <snippet40>

Class Sample
    'Private s As IInkCursor

End Class
' </snippet40>

' Requires a reference to Microsoft DAO 3.6 Object Library
' Requires a reference to Microsoft ActiveX Data Objects 2.8 Library

' Or just use these fake things
Namespace ADODB
    Class Command
    End Class
    Class CommandClass
    End Class
    Class Connection
        Event ConnectComplete(ByVal pError As [Error], ByRef asStatus As EventStatusEnum, ByVal pConnection As Connection)
        Public ConnectionString As String
        Sub Open()
        End Sub
    End Class
    Class [Error]
        Public Description As String
    End Class
    Class EventStatusEnum
    End Class
End Namespace
Namespace DAO
    Class DBEngine
        Function OpenDatabase(ByVal s As String) As Database
            Return Nothing
        End Function
    End Class
    Enum RecordsetTypeEnum
        dbOpenForwardOnly
    End Enum
    Enum RecordsetOptionEnum
        dbReadOnly
    End Enum
    Class Database
        Function OpenRecordset(ByVal s As String, ByVal a As RecordsetTypeEnum, ByVal b As RecordsetOptionEnum) As Recordset
            Return Nothing
        End Function
    End Class
    Class Recordset
        Function Fields() As Collection
            Return Nothing
        End Function
        Sub Close()
        End Sub
    End Class
    Class Field
        Public Value As Object
    End Class
End Namespace

Class Class27d75f0a54ab4ee1b91d43513a19b12d
    ' 27d75f0a-54ab-4ee1-b91d-43513a19b12d
    ' How to: Call Windows APIs (Visual Basic)

    ' <snippet1>
    ' Defines the MessageBox function.
    Public Class Win32
        Declare Auto Function MessageBox Lib "user32.dll" (
            ByVal hWnd As Integer, ByVal txt As String,
            ByVal caption As String, ByVal Type As Integer
            ) As Integer
    End Class

    ' Calls the MessageBox function.
    Public Class DemoMessageBox
        Public Shared Sub Main()
            Win32.MessageBox(0, "Here's a MessageBox", "Platform Invoke Sample", 0)
        End Sub
    End Class
    ' </snippet1>

End Class

Public Class Class7b07a463bc7243929ba09dfcb697a44f
    ' 7b07a463-bc72-4392-9ba0-9dfcb697a44f
    ' Walkthrough: Creating COM Objects with Visual Basic 2005

    Class class2
        ' <snippet2>
        Public Const ClassId As String = ""
        Public Const InterfaceId As String = ""
        Public Const EventsId As String = ""
        ' </snippet2>
    End Class


    ' <snippet5>
    <ComClass(ComClass1.ClassId, ComClass1.InterfaceId, ComClass1.EventsId)>
    Public Class ComClass1
        ' </snippet5>

        ' <snippet3>
        Public Const ClassId As String = "2C8B0AEE-02C9-486e-B809-C780A11530FE"
        ' </snippet3>

        ' <snippet4>
        Public Const InterfaceId As String = "3D8B5BA4-FB8C-5ff8-8468-11BF6BD5CF91"
        Public Const EventsId As String = "2B691787-6ED7-401e-90A4-B3B9C0360E31"
        ' </snippet4>

        ' <snippet6>
        Public Sub New()
            MyBase.New()
        End Sub
        ' </snippet6>

        Public Sub test()
        End Sub
    End Class
End Class

'Class Class7e5cf5198b644ac58116705fe26c846d
'    ' 7e5cf519-8b64-4ac5-8116-705fe26c846d
'    ' 'As Any' is not supported in 'Declare' statements

'    ' <snippet7>
'    Declare Function GetUserName Lib "advapi32.dll" Alias "GetUserNameA" (
'        ByVal lpBuffer As String,
'        ByRef nSize As Integer) As Integer
'    ' </snippet7>

'    ' <snippet8>
'    Declare Sub SetData Lib "..\LIB\UnmgdLib.dll" (
'        ByVal x As Short,
'        <System.Runtime.InteropServices.MarshalAsAttribute(
'            System.Runtime.InteropServices.UnmanagedType.AsAny)>
'            ByVal o As Object)
'    ' </snippet8>

'End Class

Class Class9280ca967a9347a38d016d01be0657cb
    ' 9280ca96-7a93-47a3-8d01-6d01be0657cb
    ' Walkthrough: Calling Windows APIs

    ' <snippet9>
    Declare Auto Function MBox Lib "user32.dll" Alias "MessageBox" (
        ByVal hWnd As Integer,
        ByVal txt As String,
        ByVal caption As String,
        ByVal Typ As Integer) As Integer
    ' </snippet9>

    ' <snippet11>
    Const MB_ICONQUESTION As Integer = &H20
    Const MB_YESNO As Integer = &H4
    Const IDYES As Integer = 6
    Const IDNO As Integer = 7
    ' </snippet11>

    Dim WithEvents Button1 As New Button
    ' <snippet12>
    Private Sub Button1_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles Button1.Click

        ' Stores the return value.
        Dim RetVal As Integer
        RetVal = MBox(0, "Declare DLL Test", "Windows API MessageBox",
            MB_ICONQUESTION Or MB_YESNO)

        ' Check the return value.
        If RetVal = IDYES Then
            MsgBox("You chose Yes")
        Else
            MsgBox("You chose No")
        End If
    End Sub
    ' </snippet12>

    ' <snippet14>
    Declare Sub SetData Lib "..\LIB\UnmgdLib.dll" (
        ByVal x As Short,
        <MarshalAsAttribute(UnmanagedType.AsAny)>
            ByVal o As Object)
    ' </snippet14>

    Class class16
        ' <snippet16>
        Public Shared Function MoveFile(
            ByVal src As String,
            ByVal dst As String) As Boolean
            ' Leave the body of the function empty.
        End Function
        ' </snippet16>
    End Class

    ' <snippet17>
    <DllImport("KERNEL32.DLL", EntryPoint:="MoveFileW", SetLastError:=True,
        CharSet:=CharSet.Unicode, ExactSpelling:=True,
        CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function MoveFile(
        ByVal src As String,
        ByVal dst As String) As Boolean
        ' Leave the body of the function empty.
    End Function
    ' </snippet17>

    Dim WithEvents Button2 As New Button
    ' <snippet18>
    Private Sub Button2_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles Button2.Click

        Dim RetVal As Boolean = MoveFile("c:\tmp\Test.txt", "c:\Test.txt")
        If RetVal = True Then
            MsgBox("The file was moved successfully.")
        Else
            MsgBox("The file could not be moved.")
        End If
    End Sub
    ' </snippet18>

End Class

Class Classb324cc1eb03c4f39aea66a6d5bfd0e37
    ' b324cc1e-b03c-4f39-aea6-6a6d5bfd0e37
    ' Troubleshooting Interoperability

    Public Sub Method20()
        ' <snippet20>
        Dim cmd As New ADODB.Command
        ' </snippet20>
    End Sub

    ' <snippet21>
    Class DerivedCommand
        Inherits ADODB.CommandClass
    End Class
    ' </snippet21>

    ' <snippet23>
    ' Class level variable.
    Shared DBEngine As New DAO.DBEngine

    Sub DAOOpenRecordset()
        Dim db As DAO.Database
        Dim rst As DAO.Recordset
        Dim fld As DAO.Field
        ' Open the database.
        db = DBEngine.OpenDatabase("C:\nwind.mdb")

        ' Open the Recordset.
        rst = db.OpenRecordset(
            "SELECT * FROM Customers WHERE Region = 'WA'",
            DAO.RecordsetTypeEnum.dbOpenForwardOnly,
            DAO.RecordsetOptionEnum.dbReadOnly)
        ' Print the values for the fields in the debug window.
        For Each fld In rst.Fields
            Debug.WriteLine(fld.Value.ToString & ";")
        Next
        Debug.WriteLine("")
        ' Close the Recordset.
        rst.Close()
    End Sub
    ' </snippet23>

    Class Class24
        Inherits Form

        ' <snippet24>
        ' To use this example, add a reference to the
        '     Microsoft ActiveX Data Objects 2.8 Library
        ' from the COM tab of the project references page.
        Dim WithEvents cn As New ADODB.Connection
        Sub ADODBConnect()
            cn.ConnectionString = "..."
            cn.Open()
            MsgBox(cn.ConnectionString)
        End Sub

        Private Sub Form1_Load(ByVal sender As System.Object,
            ByVal e As System.EventArgs) Handles MyBase.Load

            ADODBConnect()
        End Sub

        Private Sub cn_ConnectComplete(
            ByVal pError As ADODB.Error,
            ByRef adStatus As ADODB.EventStatusEnum,
            ByVal pConnection As ADODB.Connection) Handles cn.ConnectComplete

            '  This is the event handler for the cn_ConnectComplete event raised
            '  by the ADODB.Connection object when a database is opened.
            Dim x As Integer = 6
            Dim y As Integer = 0
            Try
                x = CInt(x / y) ' Attempt to divide by zero.
                ' This procedure would fail silently without exception handling.
            Catch ex As Exception
                MsgBox("There was an error: " & ex.Message)
            End Try
        End Sub
        ' </snippet24>
    End Class

    Public Sub Method25()
        ' <snippet25>
        Try
            ' Place call to COM object here.
        Catch ex As Exception
            ' Display information about the failed call.
        End Try
        ' </snippet25>
    End Sub

    ' <snippet26>
    Sub ProcessParams(ByVal c As Object)
        'Use the arguments here.
    End Sub
    ' </snippet26>

    ' <snippet27>
    Sub PassByVal(ByVal pError As ADODB.Error)
        ' The extra set of parentheses around the arguments
        ' forces them to be passed by value.
        ProcessParams((pError.Description))
    End Sub
    ' </snippet27>

End Class

Class Classf8e7263ade1348d1b67cca1adf3544d9
    ' f8e7263a-de13-48d1-b67c-ca1adf3544d9
    ' Walkthrough: Implementing Inheritance with COM Objects

    Class ComObject1
        Class MathFunctionsClass

            Private mvarProp1 As Short
            Public Overridable Property Prop1() As Short
                Get
                    'Used when retrieving a property's value.
                    Return mvarProp1
                End Get
                Set(ByVal Value As Short)
                    'Used when assigning a value to the property.
                    mvarProp1 = Value
                End Set
            End Property

            Overridable Function AddNumbers(
                ByVal SomeNumber As Short,
                ByVal AnotherNumber As Short) As Short
                AddNumbers = SomeNumber + AnotherNumber
            End Function

        End Class
    End Class

    Class MathClass
        ' <snippet31>
        ' The inherited class is called MathFunctions in the base class,
        ' but the interop assembly appends the word Class to the name.
        Inherits ComObject1.MathFunctionsClass
        ' </snippet31>

        ' <snippet32>
        '  This method overloads the method AddNumbers from the base class.
        Overloads Function AddNumbers(
            ByVal SomeNumber As Integer,
            ByVal AnotherNumber As Integer) As Integer

            Return SomeNumber + AnotherNumber
        End Function
        ' </snippet32>

        ' <snippet33>
        '  The following function extends the inherited class.
        Function SubtractNumbers(
            ByVal SomeNumber As Integer,
            ByVal AnotherNumber As Integer) As Integer

            Return AnotherNumber - SomeNumber
        End Function
        ' </snippet33>
    End Class

    Public Sub Method34()
        ' <snippet34>
        Dim Result1 As Short
        Dim Result2 As Integer
        Dim Result3 As Integer
        Dim MathObject As New MathClass
        Result1 = MathObject.AddNumbers(4S, 2S) ' Add two Shorts.
        Result2 = MathObject.AddNumbers(4, 2) 'Add two Integers.
        Result3 = MathObject.SubtractNumbers(2, 4) ' Subtract 2 from 4.
        MathObject.Prop1 = 6 ' Set an inherited property.

        MsgBox("Calling the AddNumbers method in the base class " &
               "using Short type numbers 4 and 2 = " & Result1)
        MsgBox("Calling the overloaded AddNumbers method using " &
               "Integer type numbers 4 and 2 = " & Result2)
        MsgBox("Calling the SubtractNumbers method " &
               "subtracting 2 from 4 = " & Result3)
        MsgBox("The value of the inherited property is " &
                MathObject.Prop1)
        ' </snippet34>
    End Sub

End Class

