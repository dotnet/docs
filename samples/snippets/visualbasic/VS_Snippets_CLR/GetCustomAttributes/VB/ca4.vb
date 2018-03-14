' <Snippet4>
Imports System
Imports System.Reflection
Imports System.Security
Imports System.Runtime.InteropServices

' Define an enumeration of Win32 unmanaged types
Public Enum UnmanagedType
    User
    GDI
    Kernel
    Shell
    Networking
    Multimedia
End Enum 'UnmanagedType

' Define the Unmanaged attribute.
Public Class UnmanagedAttribute 
             Inherits Attribute

    ' Storage for the UnmanagedType value.
    Protected thisType As UnmanagedType
    
    ' Set the unmanaged type in the constructor.
    Public Sub New(ByVal type As UnmanagedType) 
        thisType = type
    End Sub 'New
    
    ' Define a property to get and set the UnmanagedType value.
    Public Property Win32Type() As UnmanagedType 
        Get
            Return thisType
        End Get
        Set
            thisType = Win32Type
        End Set
    End Property
End Class 'UnmanagedAttribute 

' Create a class for an imported Win32 unmanaged function.
Public Class Win32
    <DllImport("user32.dll", CharSet:=CharSet.Unicode)> _
    Public Shared Function MessageBox(ByVal hWnd As Integer, _
                                      ByVal Text As String, _
                                      ByVal caption As String, _
                                      ByVal type As Integer) As Integer
    End Function 'MessageBox
End Class 'Win32

Public Class AClass
    ' Add some attributes to Win32CallMethod.
    <Obsolete("This method is obsolete. Use managed MsgBox instead."), _
     Unmanaged(UnmanagedType.User)>  _
    Public Sub Win32CallMethod() 
        Win32.MessageBox(0, "This is an unmanaged call.", "Caution!", 0)    
    End Sub 'Win32CallMethod
End Class 'AClass

Class DemoClass
    Shared Sub Main(ByVal args() As String) 
        ' Get the AClass type to access its metadata.
        Dim clsType As Type = GetType(AClass)
        ' Get the type information for Win32CallMethod.
        Dim mInfo As MethodInfo = clsType.GetMethod("Win32CallMethod")
        If Not (mInfo Is Nothing) Then
            ' Iterate through all the attributes of the method.
            Dim attr As Attribute
            For Each attr In  Attribute.GetCustomAttributes(mInfo)
                ' Check for the Obsolete attribute.
                If attr.GetType().Equals(GetType(ObsoleteAttribute)) Then
                    Console.WriteLine("Method {0} is obsolete. The message is:", mInfo.Name)
                    Console.WriteLine("  ""{0}""", CType(attr, ObsoleteAttribute).Message)
                ' Check for the Unmanaged attribute.
                ElseIf attr.GetType().Equals(GetType(UnmanagedAttribute)) Then
                    Console.WriteLine("This method calls unmanaged code.")
                    Console.WriteLine( _
                            String.Format("The Unmanaged attribute type is {0}.", _
                            CType(attr, UnmanagedAttribute).Win32Type))
                    Dim myCls As New AClass()
                    myCls.Win32CallMethod()
                End If
            Next attr
        End If
    End Sub 'Main
End Class 'DemoClass

'
'This code example produces the following results. 
'
'First, the compilation yields the warning, "...This method is 
'obsolete. Use managed MsgBox instead."
'Second, execution yields a message box with a title of "Caution!" 
'and message text of "This is an unmanaged call." 
'Third, the following text is displayed in the console window:
'
'Method Win32CallMethod is obsolete. The message is:
'  "This method is obsolete. Use managed MsgBox instead."
'This method calls unmanaged code.
'The Unmanaged attribute type is User.
' 
' </Snippet4>
