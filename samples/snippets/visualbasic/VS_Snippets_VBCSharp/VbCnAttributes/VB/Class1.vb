' <snippet17>
Imports System.Runtime.InteropServices
' </snippet17>

' Need a reference to System.Web.Services.dll for this to work.
' <snippet19>
Imports System.Web.Services
' </snippet19>

' <snippet13>
Imports System.Reflection
<Assembly: AssemblyTitleAttribute("Production assembly 4"),
Module: CLSCompliant(True)> 
' </snippet13>

Class Class2b1703ed443749b3bc0b568094324f47
    ' Application of Attributes

    Class tmp1
        ' <snippet14>
        <CustomAttr(Update:=True)> Class Class1
            ' </snippet14>
        End Class
    End Class


    Class tmp2
        ' <snippet15>
        <CustomAttr(True, False)> Class Class1
            ' </snippet15>
        End Class
    End Class


    Class tmp3
        ' <snippet16>
        <CustomAttr(Update:=True, Keep:=False)> Class Class1
            ' </snippet16>
        End Class
    End Class

    ' <snippet18>
    Declare Auto Sub CopyFile Lib "Kernel32.Lib" (
       <MarshalAs(UnmanagedType.LPWStr)> ByVal existingfile As String,
       <MarshalAs(UnmanagedType.LPWStr)> ByVal newfile As String,
       ByVal failifexists As Boolean
    )
    ' </snippet18>

    ' <snippet20>
    <WebMethod()> Public Function HelloWorld() As String
        HelloWorld = "Hello World..."
    End Function
    ' </snippet20>


    Private Class CustomAttr
        Inherits System.Attribute
        Public Sub New(Optional ByVal Update As Boolean = True, Optional ByVal Keep As Boolean = True)
        End Sub
        Public Property Update() As Boolean
            Get
            End Get
            Set(ByVal Value As Boolean)
            End Set
        End Property
        Public Property Keep() As Boolean
            Get
            End Get
            Set(ByVal Value As Boolean)
            End Set
        End Property
    End Class

End Class
