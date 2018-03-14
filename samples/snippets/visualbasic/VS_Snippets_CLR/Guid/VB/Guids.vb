' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Runtime.InteropServices

' Guid for the interface IMyInterface.
<Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4")> _
Interface IMyInterface
    Sub MyMethod()
End Interface

' Guid for the coclass MyTestClass.
<Guid("936DA01F-9ABD-4d9d-80C7-02AF85C822A8")> _
Public Class MyTestClass
    Implements IMyInterface

    Public Sub MyMethod() Implements IMyInterface.MyMethod
    End Sub

    Public Shared Sub Main()
        Dim IMyInterfaceAttribute As GuidAttribute = CType(Attribute.GetCustomAttribute(GetType(IMyInterface), GetType(GuidAttribute)),
                                                           GuidAttribute)

        Console.WriteLine("IMyInterface Attribute: " + IMyInterfaceAttribute.Value)

        ' Use the string to create a guid.
        Dim myGuid1 As New Guid(IMyInterfaceAttribute.Value)
        ' Use a byte array to create a guid.
        Dim myGuid2 As New Guid(myGuid1.ToByteArray())

        If myGuid1.Equals(myGuid2) Then
            Console.WriteLine("myGuid1 equals myGuid2")
        Else
            Console.WriteLine("myGuid1 does not equal myGuid2")
        End If 

        ' The equality operator can also be used to determine if two guids have same value.
        If myGuid1.ToString() = myGuid2.ToString() Then
            Console.WriteLine("myGuid1 == myGuid2")
        Else
            Console.WriteLine("myGuid1 != myGuid2")
        End If
    End Sub
End Class
' The example displays the following output:
'       IMyInterface Attribute: F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4
'       myGuid1 equals myGuid2
'       myGuid1 == myGuid2
' </Snippet1>
